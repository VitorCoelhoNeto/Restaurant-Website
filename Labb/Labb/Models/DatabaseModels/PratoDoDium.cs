using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Labb.Models
{
    public partial class PratoDoDium
    {
        public PratoDoDium()
        {
            PratoFavoritos = new HashSet<PratoFavorito>();
        }

        [Key]
        [Column("id_Prato")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPrato { get; set; }
        [Required]
        [Column("nome")]
        [StringLength(250)]
        public string Nome { get; set; }
        [Required]
        [Column("descricao")]
        [StringLength(250)]
        public string Descricao { get; set; }
        [Required]
        [Column("tipo_prato")]
        [StringLength(250)]
        public string TipoPrato { get; set; }
        [Required]
        [Column("foto")]
        [StringLength(300)]
        public string Foto { get; set; }
        [Column("preco", TypeName = "money")]
        public decimal Preco { get; set; }
        [Column("data_prato", TypeName = "date")]
        public DateTime DataPrato { get; set; }
        [Column("apagado", TypeName = "bit")]
        public bool Apagado { get; set; }
        public Restaurante restaurante { get; set; }

        [InverseProperty(nameof(PratoFavorito.IdPratoNavigation))]
        public virtual ICollection<PratoFavorito> PratoFavoritos { get; set; }
    }
}
