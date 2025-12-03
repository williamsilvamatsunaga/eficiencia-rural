using System.ComponentModel.DataAnnotations.Schema;

namespace eficiencia_rural.Models
{
    [Table("categoria")]
    public class Categoria
    {
        [Column("id_categoria")]
        public int Id { get; set; }

        [Column("nome_cat")]
        public string Nome { get; set; } 
    }
}
