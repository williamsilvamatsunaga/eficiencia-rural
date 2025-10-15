using System.ComponentModel.DataAnnotations.Schema;

namespace eficiencia_rural.Models
{
    [Table("insumo")]
    public class Insumo
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string UnidadeMedida { get; set; }
        public string Categoria { get; set; }
        public double Quantidade { get; set; }
        public double ValorUnitario { get; set; }
    }
}
