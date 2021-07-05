using Labb.Data;
using Labb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ManageController : ControllerBase
    {
        private readonly ApplicationDbContext _cntx;
        public ManageController(ApplicationDbContext cntx)
        {
            _cntx = cntx;
        }
        [HttpPost]
        public IActionResult BlockUser(int UID, string razao, int duracao)
        {
            if (UID == 0)
            {
                UID = int.Parse(HttpContext.Request.Form["UID"]);
            }
            if (string.IsNullOrEmpty(razao))
            {
                razao = HttpContext.Request.Form["razao"];
            }
            if (duracao == 0)
            {
                duracao = int.Parse(HttpContext.Request.Form["duracao"]);
            }
            if (HttpContext.User.UserHasType(_cntx, "admin"))
            {
                try
                {
                    Utilizador usr = _cntx.Users.Find(UID);
                    usr.BloqueadoValor = true;
                    usr.BloqueadoRazao = razao;
                    usr.BloqueadoDuracao = DateTime.Now.AddHours(duracao);
                    _cntx.Entry(usr).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _cntx.SaveChanges();
                    return Ok();
                }
                catch (Exception)
                {
                    return StatusCode(400);
                }
            }
            else
            {
                return Unauthorized();
            }
        }
        [HttpPost]
        public IActionResult UpgradeUser(int UID)
        {
            if (UID == 0)
            {
                UID = int.Parse(HttpContext.Request.Form["UID"]);
            }
            if (HttpContext.User.UserHasType(_cntx, "admin"))
            {
                try
                {
                    Cliente cliente = _cntx.Clientes.Find(UID);
                    _cntx.Entry(cliente).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    _cntx.SaveChanges();
                    _cntx.Administradors.Add(new Administrador()
                    {
                        IdUtilizador = UID
                    });
                    _cntx.SaveChanges();
                    return Ok();
                }
                catch (Exception)
                {
                    return StatusCode(400);
                }
            }
            else
            {
                return Unauthorized();
            }
        }
        [HttpPost]
        public IActionResult AcceptRestaurante(int RID)
        {
            if (RID == 0)
            {
                RID = int.Parse(HttpContext.Request.Form["RID"]);
            }
            if (HttpContext.User.UserHasType(_cntx, "admin"))
            {
                try
                {
                    Restaurante rest = _cntx.Restaurantes.Find(RID);
                    rest.admin = _cntx.Administradors.Find(int.Parse(HttpContext.User.GetUserId()));
                    rest.Validado = true;
                    _cntx.Entry(rest).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _cntx.SaveChanges();
                    return Ok();
                }
                catch (Exception)
                {
                    return StatusCode(400);
                }
            }
            else
            {
                return Unauthorized();
            }
        }
        [HttpPost]
        public IActionResult DenyRestaurante(int RID)
        {
            if(RID == 0)
            {
                RID = int.Parse(HttpContext.Request.Form["RID"]);
            }
            if (HttpContext.User.UserHasType(_cntx, "admin"))
            {
                try
                {
                    Restaurante rest = _cntx.Restaurantes.Find(RID);
                    rest.admin = _cntx.Administradors.Find(int.Parse(HttpContext.User.GetUserId()));
                    rest.Validado = false;
                    _cntx.Entry(rest).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _cntx.SaveChanges();
                    return Ok();
                }
                catch (Exception)
                {
                    return StatusCode(400);
                }
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
