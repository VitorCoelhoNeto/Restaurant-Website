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
    public class RestaurantesController : Controller
    {
        private readonly ApplicationDbContext _cntx;
        public RestaurantesController(ApplicationDbContext cntx)
        {
            _cntx = cntx;
        }
        [Authorize]
        public IActionResult Index(string NomeRest, string Addr)
        {
            if(!string.IsNullOrEmpty(NomeRest) || !string.IsNullOrEmpty(Addr))
            {
                ViewData["FirstSearch"] = true;
                ViewData["NomeRest"] = NomeRest;
                ViewData["Addr"] = Addr;
            }
            else
            {
                ViewData["FirstSearch"] = false;
            }
            return View();
        }
        [Authorize]
        public IActionResult Favoritos()
        {
            if(!HttpContext.User.UserHasType(_cntx, "rest"))
            {
                int UID = int.Parse(HttpContext.User.GetUserId());
                List<RestauranteFavorito> rfs = _cntx.RestauranteFavoritos.Where(rf => rf.IdCliente == UID).ToList();
                List<Restaurante> rs = new List<Restaurante>();
                foreach(RestauranteFavorito rf in rfs)
                {
                    rs.Add(_cntx.Restaurantes.Find(rf.IdRestaurante));
                }
                ViewData["favoritos"] = rs;
                return View();
            }
            else
            {
                return Unauthorized();
            }
        }
        [Authorize]
        public IActionResult Pratos()
        {
            if(HttpContext.User.UserHasType(_cntx, "rest") && _cntx.Restaurantes.Find(int.Parse(HttpContext.User.GetUserId())).Validado)
            {
                return View();
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
