using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Labb.Data;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Labb.Models
{
    [Table("Cliente")]
    public partial class Cliente
    {
        public Cliente()
        {
            PratoFavoritos = new HashSet<PratoFavorito>();
            RestauranteFavoritos = new HashSet<RestauranteFavorito>();
        }

        [Key]
        [Column("id_Utilizador")]
        public int IdUtilizador { get; set; }
        [Required]
        [Column("nome")]
        [StringLength(50)]
        public string Nome { get; set; }

        [ForeignKey(nameof(IdUtilizador))]
        [InverseProperty(nameof(Utilizador.Cliente))]
        public virtual Utilizador IdUtilizadorNavigation { get; set; }
        [InverseProperty(nameof(PratoFavorito.IdClienteNavigation))]
        public virtual ICollection<PratoFavorito> PratoFavoritos { get; set; }
        [InverseProperty(nameof(RestauranteFavorito.IdClienteNavigation))]
        public virtual ICollection<RestauranteFavorito> RestauranteFavoritos { get; set; }
    }
}
