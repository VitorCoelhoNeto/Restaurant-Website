using Labb.Data;
using Labb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Labb.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public RestaurantesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get(bool takeaway, bool local, bool entrega, bool manha, bool tarde, bool noite, string morada = "", string nome = "", int page = 0, int perpage = 0)
        {
            RestauranteSearchFilters rsf = new RestauranteSearchFilters()
            {
                Entrega = entrega,
                Local = local,
                Manha = manha,
                Morada = morada,
                Noite = noite,
                Nome = nome,
                TakeAway = takeaway,
                Tarde = tarde
            };
            List<Restaurante> restaurantes = new List<Restaurante>();
            if (!rsf.TakeAway && !rsf.Local && !rsf.Entrega)
            {
                restaurantes = _context.Restaurantes.Include(rest=>rest.admin).Where(rest=>rest.admin != null && rest.Validado).ToList();
            }
            else
            {
                restaurantes = _context.Restaurantes.Include(rest => rest.admin).Where(rest => rest.admin != null && rest.Validado && rest.TipoTakeaway == rsf.TakeAway && rest.TipoLocal == rsf.Local && rest.TipoEntrega == rsf.Entrega).ToList();
            }
            restaurantes = rsf.FiltrarHoras(restaurantes);
            if (!string.IsNullOrEmpty(rsf.Morada))
            {
                restaurantes = restaurantes.Where(rest => rest.Morada.ToLower().Contains(rsf.Morada.ToLower())).ToList();
            }
            if (!string.IsNullOrEmpty(rsf.Nome))
            {
                restaurantes = restaurantes.Where(rest => rest.Nome.ToLower().Contains(rsf.Nome.ToLower())).ToList();
            }
            if(page == 0 && perpage == 0)
            {
                return Ok(restaurantes);
            }
            else
            {
                return Ok(restaurantes.GetPage(page, perpage));
            }
        }
        [Authorize]
        [HttpGet]
        [Route("/api/[controller]/[action]")]
        public IActionResult Favorito(string idRestaurante)
        {
            if(!HttpContext.User.UserHasType(_context, "rest"))
            {
                string UID = HttpContext.User.GetUserId(); //retorna o id do utilizador
                if (_context.RestauranteFavoritos.Any(pf => pf.IdCliente.ToString() == UID && pf.IdRestaurante.ToString() == idRestaurante)) // se o utilizador já tem o restaurante como favorito
                {
                    try
                    {
                        RestauranteFavorito rf = _context.RestauranteFavoritos.First(pf => pf.IdCliente.ToString() == UID && pf.IdRestaurante.ToString() == idRestaurante); // Obter o restaurante favorito para o eliminar
                        _context.RestauranteFavoritos.Remove(rf); // remover o restaurante
                        _context.SaveChanges(); //salvar
                    }
                    catch (Exception)
                    {
                        //O metodo first pode dar exeptions mas não deve a menos que algo corra muito mal por causa do any que valida se o favorito existe
                    }
                    return Ok("Removed");
                }
                else //O utilizador não tem o restaurante como favorito
                {
                    //Adicionar o restaurante aos favoritos
                    _context.RestauranteFavoritos.Add(new RestauranteFavorito()
                    {
                        IdCliente = int.Parse(UID),
                        IdRestaurante = int.Parse(idRestaurante)
                    });
                    //salvar
                    _context.SaveChanges();
                    return Ok("Added");
                }
            }
            else
            {
                //Utilizador é restaurante
                return Unauthorized();
            }
        }
        [Authorize]
        [HttpPost]
        [Route("/api/[controller]/[action]")]
        public IActionResult CreatePlate()
        {
            if (HttpContext.User.UserHasType(_context, "rest") && _context.Restaurantes.Find(int.Parse(HttpContext.User.GetUserId())).Validado)
            {
                try
                {
                    string nome = HttpContext.Request.Form["nome"];
                    string desc = HttpContext.Request.Form["desc"];
                    string tipo = HttpContext.Request.Form["tipo"];
                    decimal preco = Convert.ToDecimal(HttpContext.Request.Form["preco"]);
                    IFormFile image = HttpContext.Request.Form.Files["image"];
                    if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(desc) || string.IsNullOrEmpty(tipo) || preco == 0 || image == null)
                    {
                        return StatusCode(400, new { ErrorCode = 1, Error = "Missing Fields" });
                    }
                    if(!Directory.Exists(Path.Combine(Environment.CurrentDirectory, "wwwroot", "Images")))
                    {
                        Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "wwwroot", "Images"));
                    }
                    string guid;
                    bool validguid;
                    do
                    {
                        guid = Guid.NewGuid().ToString();
                        if (System.IO.File.Exists(Path.Combine(Environment.CurrentDirectory, "wwwroot", "Images", $"{guid}{Path.GetExtension(image.FileName)}")))
                        {
                            validguid = false;
                        }
                        else
                        {
                            validguid = true;
                        }
                    } while (!validguid);
                    FileStream str = new FileStream(Path.Combine(Environment.CurrentDirectory, "wwwroot", "Images", $"{guid}{Path.GetExtension(image.FileName)}"), FileMode.Create);
                    image.CopyTo(str);
                    str.Close();
                    Restaurante moi = _context.Restaurantes.Find(int.Parse(HttpContext.User.GetUserId()));
                    PratoDoDium pdu = new PratoDoDium()
                    {
                        DataPrato = DateTime.Today,
                        Descricao = desc,
                        Nome = nome,
                        TipoPrato = tipo,
                        Preco = preco,
                        restaurante = moi,
                        Foto = Path.Combine("/Images", $"{guid}{Path.GetExtension(image.FileName)}"),
                        Apagado = false,
                        IdPrato = _context.PratoDoDia.Count() + 1
                    };
                    _context.PratoDoDia.Add(pdu);
                    _context.SaveChanges();
                    pdu.restaurante = null;
                    return Ok(pdu);
                }
                catch (Exception)
                {
                    return StatusCode(400, new { ErrorCode = 2, Error = "Converting or Saving Error" });
                }
            }
            else
            {
                return Unauthorized();
            }
        }
        [Authorize]
        [HttpGet]
        [Route("/api/[controller]/[action]")]
        public IActionResult GetPlates()
        {
            if(HttpContext.User.UserHasType(_context, "rest") && _context.Restaurantes.Find(int.Parse(HttpContext.User.GetUserId())).Validado)
            {
                List<PratoDoDium> pratos = _context.PratoDoDia.Include(prato => prato.restaurante).Where(prato => prato.restaurante.IdUtilizador == int.Parse(HttpContext.User.GetUserId()) && !prato.Apagado).ToList();
                foreach(PratoDoDium prato in pratos)
                {
                    prato.restaurante = null;
                }
                return Ok(pratos);
            }
            else
            {
                return Unauthorized();
            }
        }
        [Authorize]
        [HttpDelete]
        [Route("/api/[controller]/[action]/{id}")]
        public IActionResult DeletePlate(int id)
        {
            if (HttpContext.User.UserHasType(_context, "rest") && _context.Restaurantes.Find(int.Parse(HttpContext.User.GetUserId())).Validado)
            {
                try
                {
                    PratoDoDium pdu = _context.PratoDoDia.Find(id);
                    if(pdu == null)
                    {
                        throw new Exception();
                    }
                    if (pdu.Apagado)
                    {
                        return StatusCode(400, new { ErrorCode = 2, Error = "O prato não existe" });
                    }
                    pdu.Apagado = true;
                    _context.Entry(pdu).State = EntityState.Modified;
                    _context.SaveChanges();
                    return Ok();
                }
                catch (Exception)
                {
                    return StatusCode(400, new { ErrorCode = 1, Error = "Não foi possivel efetuar a pesquisa" });
                }
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
