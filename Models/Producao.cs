using System.ComponentModel.DataAnnotations.Schema;

namespace eficiencia_rural.Models
{
    [Table("producao")]
    public class Producao
    {
        [Column("id_producao")]
        public int Id { get; set; }

        [Column("valor_unitario_pro")]
        public double ValorUnitario { get; set; }

        [Column("data_hora_inicio_pro")]
        public DateTime? DataHoraInicio { get; set; }

        [Column("qtd_litros_pro")]
        public double QuantidadeLitros { get; set; }
        public virtual Animal? Animal { get; set; }
        [Column("fk_id_animal")]
        public int fk_id_animal {  get; set; }

    }
}
