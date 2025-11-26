using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace eficiencia_rural.Models
{
    [Table("propriedade_insumo")]
    public class PropriedadeInsumo
    {
        [Column("id_propriedade_insumo")]
        public int Id { get; set; }

        public virtual Propriedade? Propriedade { get; set; }
        [Column("fk_id_propriedade")]
        [JsonIgnore]
        public int fk_id_propriedade { get; set; }

        public virtual Insumo? Insumo { get; set; }
        [Column("fk_id_insumo")]
        [JsonIgnore]
        public int fk_id_insumo { get; set; }



    }
}
