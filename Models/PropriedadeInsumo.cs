using System.ComponentModel.DataAnnotations.Schema;

namespace eficiencia_rural.Models
{
    [Table("propriedade_insumo")]
    public class PropriedadeInsumo
    {
        public int Id { get; set; }

        public virtual Propriedade? Propriedade { get; set; }
        public int fk_id_propriedade { get; set; }
        public virtual Insumo? Insumo { get; set; }
        public int fk_id_insumo { get; set; }
    }
}
