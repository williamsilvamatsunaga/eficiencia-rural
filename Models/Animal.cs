using System.ComponentModel.DataAnnotations.Schema;

namespace eficiencia_rural.Models
{
    [Table("animal")]
    public class Animal
    {
        [Column("id_animal")]
        public int Id { get; set; }

        [Column("identificacao_ani")]
        public string Indentificacao { get; set; }

        [Column("dt_nascimento_ani")]
        public DateTime DataNascimento { get; set; }

        [Column("peso_ani")]
        public double Peso { get; set; }

        [Column("id_animal")]
        public virtual Categoria? Categoria { get; set; }
        [Column("fk_id_categoria")]
        public int fk_id_categoria { get; set; }

        public virtual Propriedade? Propriedade { get; set; }
        [Column("fk_id_propriedade")]
        public int fk_id_propriedade { get; set; }

    }
}
