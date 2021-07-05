using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Labb.Data;
using Labb.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace Labb.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<Utilizador> _signInManager;
        private readonly UserManager<Utilizador> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _dbcontext;

        public RegisterModel(
            UserManager<Utilizador> userManager,
            SignInManager<Utilizador> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            ApplicationDbContext dbContext
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _dbcontext = dbContext;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "User Name")]
            public string UserName { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                string TipoConta = Request.Form["TipoConta"];
                Time OpenTime = new Time();
                Time CloseTime = new Time();
                if(TipoConta == "option1")
                {
                    TipoConta = "Cliente";
                }
                else
                {
                    TipoConta = "Restaurante";
                    if (string.IsNullOrEmpty(Request.Form["RestNameBox"]))
                    {
                        //Redisplay page missing restaurante name
                        ModelState.AddModelError(string.Empty, "Precisas de introduzir o nome do restaurante");
                        return Page();
                    }
                    if (string.IsNullOrEmpty(Request.Form["Telefone"]))
                    {
                        //Redisplay page missing numero de telefone
                        ModelState.AddModelError(string.Empty, "Precisas de introduzir o numero de telefone");
                        return Page();
                    }
                    else
                    {
                        Regex PhoneNumberRegex = new Regex(@"[0-9]{9}");
                        if (!PhoneNumberRegex.IsMatch(Request.Form["Telefone"]) || ((string)Request.Form["Telefone"]).Length != 9)
                        {
                            //Redisplay page numero de telefone invalid
                            ModelState.AddModelError(string.Empty, "Precisas de introduzir um numero de telefone valido");
                            return Page();
                        }
                    }
                    if (string.IsNullOrEmpty(Request.Form["Address"]))
                    {
                        //Redisplay page missing morada
                        ModelState.AddModelError(string.Empty, "Precisas de introduzir uma morada");
                        return Page();
                    }
                    if(string.IsNullOrEmpty(Request.Form["takeaway"]) && string.IsNullOrEmpty(Request.Form["local"]) && string.IsNullOrEmpty(Request.Form["entrega"]))
                    {
                        //Redisplay page missing tipo
                        ModelState.AddModelError(string.Empty, "Precisas de selecionar um tipo");
                        return Page();
                    }
                    if (string.IsNullOrEmpty(Request.Form["DescRest"]))
                    {
                        //Redisplay page missing description
                        ModelState.AddModelError(string.Empty, "Precisas de introduzir uma descrição");
                        return Page();
                    }
                    if(Request.Form.Files["ProfilePicture"] == null)
                    {
                        //Redisplay page missing image
                        ModelState.AddModelError(string.Empty, "Precisas de selecionar uma imagem");
                        return Page();
                    }
                    if (string.IsNullOrEmpty(Request.Form["OpenTime"]))
                    {
                        //Redisplay page missing open time
                        ModelState.AddModelError(string.Empty, "Precisas de introduzir uma hora de abertura");
                        return Page();
                    }
                    else
                    {
                        OpenTime = Time.Parse(Request.Form["OpenTime"]);
                        if(OpenTime == null)
                        {
                            //Redisplay page open time invalid
                            ModelState.AddModelError(string.Empty, "Precisas de introduzir uma hora de abertura válida");
                            return Page();
                        }
                    }
                    if (string.IsNullOrEmpty(Request.Form["CloseTime"]))
                    {
                        //Redisplay page missing close time
                        ModelState.AddModelError(string.Empty, "Precisas de introduzir uma hora de fecho");
                        return Page();
                    }
                    else
                    {
                        CloseTime = Time.Parse(Request.Form["CloseTime"]);
                        if(CloseTime == null)
                        {
                            //Redisplay page close time invalid
                            ModelState.AddModelError(string.Empty, "Precisas de introduzir uma hora de fecho válida");
                            return Page();
                        }
                    }
                }
                var user = new Utilizador { UserName = Input.UserName, Email = Input.Email, BloqueadoDuracao = DateTime.MinValue, BloqueadoValor = false, BloqueadoRazao = null };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    if(TipoConta == "Cliente")
                    {
                        _logger.LogInformation("User created is of type Cliente.");
                        Cliente cli = new Cliente()
                        {
                            IdUtilizador = user.Id,
                            Nome = user.UserName
                        };
                        _dbcontext.Clientes.Add(cli);
                        _dbcontext.SaveChanges();
                    }
                    else
                    {
                        _logger.LogInformation("User created is of type Restaurante.");
                        string Restaurante = Request.Form["RestNameBox"];
                        string Telefone = Request.Form["Telefone"];
                        string Morada = Request.Form["Address"];
                        string DiaDeFolga = Request.Form["DDS"];
                        string takeaway = Request.Form["takeaway"];
                        string local = Request.Form["local"];
                        string entrega = Request.Form["entrega"];
                        string DescRest = Request.Form["DescRest"];
                        IFormFile profilepic = Request.Form.Files["ProfilePicture"];
                        if(!Directory.Exists(Path.Combine(Environment.CurrentDirectory, "wwwroot", "Images")))
                        {
                            Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "wwwroot", "Images"));
                        }
                        string guid;
                        bool validguid;
                        do
                        {
                            guid = Guid.NewGuid().ToString();
                            if (System.IO.File.Exists(Path.Combine(Environment.CurrentDirectory, "wwwroot", "Images", $"{guid}{Path.GetExtension(profilepic.FileName)}")))
                            {
                                validguid = false;
                            }
                            else
                            {
                                validguid = true;
                            }
                        } while (!validguid);
                        FileStream str = new FileStream(Path.Combine(Environment.CurrentDirectory, "wwwroot", "Images", $"{guid}{Path.GetExtension(profilepic.FileName)}"), FileMode.Create);
                        profilepic.CopyTo(str);
                        str.Close();

                        Restaurante restaurante = new Restaurante()
                        {
                            Descricao = DescRest,
                            DiaDescanso = DiaDeFolga,
                            HoraDeAbertura = OpenTime.ToString(),
                            HoraDeFecho = CloseTime.ToString(),
                            Morada = Morada,
                            Gps = "",
                            Nome = Restaurante,
                            Telefone = Convert.ToDecimal(Telefone),
                            TipoEntrega = entrega == "on",
                            TipoLocal = local == "on",
                            TipoTakeaway = takeaway == "on",
                            IdUtilizador = user.Id,
                            Validado = false,
                            Foto = Path.Combine("/Images", $"{guid}{Path.GetExtension(profilepic.FileName)}")
                        };
                        _dbcontext.Restaurantes.Add(restaurante);
                        _dbcontext.SaveChanges();
                    }
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
