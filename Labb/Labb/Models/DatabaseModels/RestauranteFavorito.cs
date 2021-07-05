using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Labb.Models
{
    [Table("Restaurante_Favorito")]
    public partial class RestauranteFavorito
    {
        [Key]
        [Column("id_Restaurante")]
        public int IdRestaurante { get; set; }
        [Key]
        [Column("id_Cliente")]
        public int IdCliente { get; set; }

        [ForeignKey(nameof(IdCliente))]
        [InverseProperty(nameof(Cliente.RestauranteFavoritos))]
        public virtual Cliente IdClienteNavigation { get; set; }
        [ForeignKey(nameof(IdRestaurante))]
        [InverseProperty(nameof(Restaurante.RestauranteFavoritos))]
        public virtual Restaurante IdRestauranteNavigation { get; set; }
    }
}
