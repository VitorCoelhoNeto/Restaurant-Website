using Labb.Data;
using Labb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PratosController : ControllerBase
    {
        private readonly ApplicationDbContext _cntx;
        public PratosController(ApplicationDbContext cntx)
        {
            _cntx = cntx;
        }
        [Authorize]
        [HttpGet]
        public IActionResult Get(bool zerototen, bool tentotwenty, bool twentyplus, bool vegan, bool meat, bool fish, string search = "", int page = 0, int perpage = 0)
        {
            List<PratoDoDium> pratos = _cntx.PratoDoDia.Where(plate=>plate.DataPrato == DateTime.Today && !plate.Apagado).Include(plate=>plate.restaurante).ToList();
            foreach(PratoDoDium prato in pratos)
            {
                prato.restaurante.listaPratos = null;
            }
            //Logica dos preços
            if(zerototen && tentotwenty && !twentyplus)
            {
                pratos = pratos.Where(plate => plate.Preco <= 20).ToList();
            }else if(!zerototen && tentotwenty && twentyplus)
            {
                pratos = pratos.Where(plate => plate.Preco >= 10).ToList();
            }else if(zerototen && tentotwenty && twentyplus)
            {
                //NO LOGIC
            }else if(zerototen && !tentotwenty && twentyplus)
            {
                pratos = pratos.Where(plate => plate.Preco <= 10 && plate.Preco > 20).ToList();
            }else if (zerototen)
            {
                pratos = pratos.Where(plate => plate.Preco <= 10).ToList();
            }else if (tentotwenty)
            {
                pratos = pratos.Where(plate => plate.Preco >= 10 && plate.Preco <= 20).ToList();
            }
            else if(twentyplus)
            {
                pratos = pratos.Where(plate => plate.Preco > 20).ToList();
            }
            //Logica do tipo
            if(vegan && meat && !fish)
            {
                pratos = pratos.Where(prato => prato.TipoPrato == "vegan,meat").ToList();
            }else if(!vegan && meat && fish)
            {
                pratos = pratos.Where(prato => prato.TipoPrato == "meat,fish").ToList();
            }else if(vegan && meat && fish)
            {
                //NO LOGIC
            }else if(vegan && !meat && fish)
            {
                pratos = pratos.Where(prato => prato.TipoPrato == "vegan,fish").ToList();
            }else if (vegan)
            {
                pratos = pratos.Where(prato => prato.TipoPrato == "vegan").ToList();
            }
            else if (meat)
            {
                pratos = pratos.Where(prato => prato.TipoPrato == "meat").ToList();
            }
            else if (fish)
            {
                pratos = pratos.Where(prato => prato.TipoPrato == "fish").ToList();
            }
            if (!string.IsNullOrEmpty(search))
            {
                pratos = pratos.Where(prato => prato.Nome.ToLower().Contains(search.ToLower())).ToList();
            }
            if (page == 0 && perpage == 0)
            {
                return Ok(pratos);
            }
            else
            {
                return Ok(pratos.GetPage(page, perpage));
            }
        }
        [Authorize]
        [HttpGet]
        [Route("/api/[controller]/[action]")]
        public IActionResult Favorito(int idPrato)
        {
            if (!HttpContext.User.UserHasType(_cntx, "rest"))
            {
                int UID = int.Parse(HttpContext.User.GetUserId()); //retorna o id do utilizador
                if (_cntx.PratoFavoritos.ToList().Any(pf => pf.IdCliente == UID && pf.IdPrato == idPrato)) // se o utilizador já tem o prato como favorito
                {
                    try
                    {
                        PratoFavorito rf = _cntx.PratoFavoritos.First(pf => pf.IdPrato == UID && pf.IdPrato == idPrato); // Obter o prato favorito para o eliminar
                        _cntx.PratoFavoritos.Remove(rf); // remover o prato
                        _cntx.SaveChanges(); //salvar
                    }
                    catch (Exception)
                    {
                        //O metodo first pode dar exeptions mas não deve a menos que algo corra muito mal por causa do any que valida se o favorito existe
                    }
                    return Ok("Removed");
                }
                else //O utilizador não tem o prato como favorito
                {
                    //Adicionar o prato aos favoritos
                    _cntx.PratoFavoritos.Add(new PratoFavorito()
                    {
                        IdCliente = UID,
                        IdPrato = idPrato
                    });
                    //salvar
                    _cntx.SaveChanges();
                    return Ok("Added");
                }
                
            }
            else
            {
                //Utilizador é restaurante
                return Unauthorized();
            }
        }
    }
}
