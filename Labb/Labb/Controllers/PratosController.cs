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
    public class PratosController : Controller
    {
        private readonly ApplicationDbContext _cntx;
        public PratosController(ApplicationDbContext cntx)
        {
            _cntx = cntx;
        }
        [Authorize]
        public IActionResult Index(string NomePrato, string Tipo)
        {
            if (!string.IsNullOrEmpty(NomePrato) || !string.IsNullOrEmpty(Tipo))
            {
                ViewData["FirstSearch"] = true;
                ViewData["NomePrato"] = NomePrato;
                ViewData["Tipo"] = Tipo;
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
            if (!HttpContext.User.UserHasType(_cntx, "rest"))
            {
                int UID = int.Parse(HttpContext.User.GetUserId());
                List<PratoFavorito> ptfs = _cntx.PratoFavoritos.Where(pf => pf.IdCliente == UID).ToList();
                List<PratoDoDium> pdu = new List<PratoDoDium>();
                foreach(PratoFavorito pf in ptfs)
                {
                    PratoDoDium pd = _cntx.PratoDoDia.Include(pdd => pdd.restaurante).First(pdd => pdd.IdPrato == pf.IdPrato);
                    if (!pd.Apagado)
                    {
                        pdu.Add(pd);
                    }
                }
                ViewData["favoritos"] = pdu;
                return View();
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
