using System.ComponentModel.DataAnnotations.Schema;

namespace eficiencia_rural.Models
{
    [Table("insumo")]
    public class Insumo
    {
        [Column("id_insumo")]
        public int Id { get; set; }

        [Column("descricao_ins")]
        public string Descricao { get; set; }

        [Column("und_medida_ins")]
        public string UnidadeMedida { get; set; }

        [Column("categoria_ins")]
        public string Categoria { get; set; }

        [Column("quantidade_ins")]
        public double Quantidade { get; set; }

        [Column("valor_unit_ins")]
        public double ValorUnitario { get; set; }

        public ICollection<PropriedadeInsumo> PropriedadesInsumos { get; set; } = [];
    }
}
