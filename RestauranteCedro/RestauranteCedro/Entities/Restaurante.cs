using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestauranteCedro.Entities
{
    [Table("Restaurante")]
    public class Restaurante
    {
        [Key]
        [Column("id")]
        public int id { get; set; }
    
        [Column("nome")]
        [Required]
        public string nome { get; set; }
    }
}