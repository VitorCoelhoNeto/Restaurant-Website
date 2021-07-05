using Labb.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Labb.Data
{
    public class Utilizador : IdentityUser<int>
    {
        [Column("bloqueado_valor")]
        public bool? BloqueadoValor { get; set; }
        [Column("bloqueado_razao")]
        [StringLength(250)]
        public string BloqueadoRazao { get; set; }
        [Column("bloqueado_duracao")]
        public DateTime BloqueadoDuracao { get; set; }

        [InverseProperty("IdUtilizadorNavigation")]
        public virtual Administrador Administrador { get; set; }
        [InverseProperty("IdUtilizadorNavigation")]
        public virtual Cliente Cliente { get; set; }
        [InverseProperty("IdUtilizadorNavigation")]
        public virtual Restaurante Restaurante { get; set; }
    }
}
