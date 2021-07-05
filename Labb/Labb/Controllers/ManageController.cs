using Labb.Data;
using Labb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private readonly ApplicationDbContext _cntx;
        public ManageController(ApplicationDbContext cntx)
        {
            _cntx = cntx;
        }
        public IActionResult Restaurantes()
        {
            if(HttpContext.User.UserHasType(_cntx, "admin"))
            {
                List<Restaurante> restaurantes = _cntx.Restaurantes.Include(rest => rest.admin).Where(rest => !rest.Validado && rest.admin == null).ToList();
                ViewData["Restaurantes"] = restaurantes;
                return View();
            }
            else
            {
                return Unauthorized();
            }
        }
        public IActionResult Clientes()
        {
            if (HttpContext.User.UserHasType(_cntx, "admin"))
            {
                List<Cliente> clientes = _cntx.Clientes.Include(cli=>cli.IdUtilizadorNavigation).ToList();
                ViewData["clientes"] = clientes;
                return View();
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
