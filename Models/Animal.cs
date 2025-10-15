using System.ComponentModel.DataAnnotations.Schema;

namespace eficiencia_rural.Models
{
    [Table("animal")]
    public class Animal
    {
        public int Id { get; set; }

        public string Indentificação { get; set; }

        public DateTime DataNascimento { get; set; }

        public double Peso { get; set; }

        public virtual Categoria? Categoria { get; set; }
        public int fk_id_categoria { get; set; }
        public virtual Propriedade? Propriedade { get; set; }
        public int fk_int_propriedade { get; set; }

    }
}
