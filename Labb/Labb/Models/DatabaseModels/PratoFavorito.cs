using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Labb.Models
{
    [Table("Prato_Favorito")]
    public partial class PratoFavorito
    {
        [Key]
        [Column("id_Cliente")]
        public int IdCliente { get; set; }
        [Key]
        [Column("id_Prato")]
        public int IdPrato { get; set; }

        [ForeignKey(nameof(IdCliente))]
        [InverseProperty(nameof(Cliente.PratoFavoritos))]
        public virtual Cliente IdClienteNavigation { get; set; }
        [ForeignKey(nameof(IdPrato))]
        [InverseProperty(nameof(PratoDoDium.PratoFavoritos))]
        public virtual PratoDoDium IdPratoNavigation { get; set; }
    }
}
