using System;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using Labb.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Labb.Models
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal Principal)
        {
            if (Principal == null)
            {
                throw new ArgumentNullException(nameof(Principal));
            }
            else
            {
                var claim = Principal.FindFirst(ClaimTypes.NameIdentifier);
                return claim?.Value;
            }
        }
        /// <summary>
        /// This functions finds if the user is of a specific type
        /// Acepted types: admin administrator administrador rest restaurante
        /// if type is none of the above the function will return is user is cliente
        /// </summary>
        /// <param name="Principal">This Claims Principal</param>
        /// <param name="cntx">The database context</param>
        /// <param name="Type">The Type</param>
        /// <returns>True if user is of indicated type</returns>
        public static bool UserHasType(this ClaimsPrincipal Principal, ApplicationDbContext cntx, string Type)
        {
            try
            {
                int userid = int.Parse(Principal.GetUserId());
                bool isclient = cntx.Clientes.Any(cli => cli.IdUtilizador == userid);
                bool isrestaurante = cntx.Restaurantes.Any(rest => rest.IdUtilizador == userid);
                bool isadmin = cntx.Administradors.Any(admin => admin.IdUtilizador == userid);
                if (Type.ToLower() == "admin" || Type.ToLower() == "administrator" || Type.ToLower() == "administrador")
                {
                    return isadmin;
                }
                else if (Type.ToLower() == "rest" || Type.ToLower() == "restaurante")
                {
                    return isrestaurante;
                }
                else
                {
                    return isclient;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
