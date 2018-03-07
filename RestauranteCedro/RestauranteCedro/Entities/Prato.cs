using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestauranteCedro.Entities
{
    [Table("Prato")]
    public class Prato
    {
        [Key]
        [Column("id")]
        public int id { get; set; }
        
        [Column("descricao")]
        [Required]
        public string descricao { get; set; }
        
        [Column("preco")]
        [Required]
        public double preco { get; set; }
        
        [Column("idRestaurante")]
        [Required]
        public int idRestaurante { get; set; }
        
        //public Restaurante restaurante { get; set; }
    }
}