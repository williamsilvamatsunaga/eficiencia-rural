using System.ComponentModel.DataAnnotations.Schema;

namespace eficiencia_rural.Models
{
    [Table("propriedade")]
    public class Propriedade
    {
        [Column("id_propriedade")]
        public int Id { get; set; }

        [Column("nome_pro")]
        public string? Nome { get; set; }

        [Column("tamanho_pro")]
        public double Tamanho { get; set; }

        [Column("endereco_pro")]
        public string? Endereco { get; set; }

        public ICollection<PropriedadeInsumo> PropriedadesInsumos { get; set; } = [];
    }
}
