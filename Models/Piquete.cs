using System.ComponentModel.DataAnnotations.Schema;

namespace eficiencia_rural.Models
{
    [Table("piquete")]
    public class Piquete
    {
        [Column("id_piquete")]
        public int Id { get; set; }

        [Column("nome_pic")]
        public string Nome { get; set; }

        [Column("tamanho_pic")]
        public double Tamanho { get; set; }

        [Column("tipo_pastagem_pic")]
        public string TipoPastagem { get; set; }

        public virtual Propriedade? Propriedade { get; set; }
        [Column("fk_id_propriedade")]
        public int fk_id_propriedade { get; set; }
    }
}
