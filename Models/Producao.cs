using System.ComponentModel.DataAnnotations.Schema;

namespace eficiencia_rural.Models
{
    [Table("producao")]
    public class Producao
    {
        public int Id { get; set; }
        public DateTime DataHoraInicio { get; set; }

        public int QuantidadeVacas { get; set; }
        public double ValorUnitario { get; set; }
        public double QuantidadeLitros { get; set; }
        public virtual Animal? Animal { get; set; }
        public int fk_id_animal {  get; set; }

    }
}
