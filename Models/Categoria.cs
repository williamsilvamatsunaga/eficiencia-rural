using System.ComponentModel.DataAnnotations.Schema;

namespace eficiencia_rural.Models
{
    [Table("categoria")]
    public class Categoria
    {
        public int Id { get; set; }

        public string Bezerro { get; set; }

        public string Bezerra { get; set; }

        public string Novilha { get; set; }

        public string Garrote { get; set; }

        public string Vaca {  get; set; }

        public string Touro { get; set; }

        
    }
}
