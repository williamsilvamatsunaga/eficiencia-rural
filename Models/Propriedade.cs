using System.ComponentModel.DataAnnotations.Schema;

namespace eficiencia_rural.Models
{
    [Table("propriedade")]
    public class Propriedade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Tamanho { get; set; }
        public string Endereco { get; set; }
    }
}
