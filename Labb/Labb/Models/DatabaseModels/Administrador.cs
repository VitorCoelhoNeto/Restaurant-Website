using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Labb.Data;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Labb.Models
{
    [Table("Administrador")]
    public partial class Administrador
    {
        [Key]
        [Column("id_Utilizador")]
        public int IdUtilizador { get; set; }

        [ForeignKey(nameof(IdUtilizador))]
        [InverseProperty(nameof(Utilizador.Administrador))]
        public virtual Utilizador IdUtilizadorNavigation { get; set; }
    }
}
