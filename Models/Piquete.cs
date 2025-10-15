using System.ComponentModel.DataAnnotations.Schema;

namespace eficiencia_rural.Models
{
    [Table("piquete")]
    public class Piquete
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Tamanho { get; set; }
        public string TipoPastagem { get; set; }
        public virtual Propriedade? Propriedade { get; set; }
        public int fk_id_propriedade { get; set; }
    }
}
