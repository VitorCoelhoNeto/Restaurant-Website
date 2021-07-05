using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Labb.Data;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Labb.Models
{
    [Table("Restaurante")]
    //[Index(nameof(Telefone), Name = "UQ__Restaura__2A16D97F6E7F5125", IsUnique = true)]
    public partial class Restaurante
    {
        public Restaurante()
        {
            RestauranteFavoritos = new HashSet<RestauranteFavorito>();
        }

        [Key]
        [Column("id_Utilizador")]
        public int IdUtilizador { get; set; }
        [Required]
        [Column("nome")]
        [StringLength(50)]
        public string Nome { get; set; }
        [Required]
        [Column("descricao")]
        [StringLength(50)]
        public string Descricao { get; set; }
        [Required]
        [Column("foto")]
        [StringLength(250)]
        public string Foto { get; set; }
        [Column("validado")]
        public bool Validado { get; set; }
        [Column("telefone", TypeName = "numeric(9, 0)")]
        public decimal Telefone { get; set; }
        [Required]
        [Column("morada")]
        [StringLength(50)]
        public string Morada { get; set; }
        [Required]
        [Column("gps")]
        [StringLength(50)]
        public string Gps { get; set; }
        [Required]
        [Column("dia_descanso")]
        [StringLength(50)]
        public string DiaDescanso { get; set; }
        [Column("tipo_takeaway")]
        public bool? TipoTakeaway { get; set; }
        [Column("tipo_local")]
        public bool? TipoLocal { get; set; }
        [Column("tipo_entrega")]
        public bool? TipoEntrega { get; set; }
        [Required]
        [Column("hora_de_abertura")]
        [StringLength(5)]
        public string HoraDeAbertura { get; set; }
        [Required]
        [Column("hora_de_fecho")]
        [StringLength(5)]
        public string HoraDeFecho { get; set; }
        public ICollection<PratoDoDium> listaPratos { get; set; }
        public Administrador admin { get; set; }


        [ForeignKey(nameof(IdUtilizador))]
        [InverseProperty(nameof(Utilizador.Restaurante))]
        public virtual Utilizador IdUtilizadorNavigation { get; set; }
        [InverseProperty(nameof(RestauranteFavorito.IdRestauranteNavigation))]
        public virtual ICollection<RestauranteFavorito> RestauranteFavoritos { get; set; }
    }
}
