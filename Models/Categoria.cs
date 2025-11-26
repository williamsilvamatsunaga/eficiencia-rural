using System.ComponentModel.DataAnnotations.Schema;

namespace eficiencia_rural.Models
{
    [Table("categoria")]
    public class Categoria
    {
        [Column("id_categoria")]
        public int Id { get; set; }

        [Column("bezerro_cat")]
        public string Bezerro { get; set; }

        [Column("bezerra_cat")]
        public string Bezerra { get; set; }

        [Column("novilha_cat")]
        public string Novilha { get; set; }

        [Column("garrote_cat")]
        public string Garrote { get; set; }

        [Column("vaca_cat")]
        public string Vaca {  get; set; }

        [Column("touro_cat")]
        public string Touro { get; set; }

        
    }
}
