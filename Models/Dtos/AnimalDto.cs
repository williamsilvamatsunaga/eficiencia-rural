using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eficiencia_rural.Models.Dtos
{
    public class AnimalDto
    {
        [Required(ErrorMessage = "A identificação é obrigatório")]
        public string? Identificacao { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        public double Peso { get; set; }

        [Required]
        public int fk_id_categoria { get; set; }

        [Required]
        public int fk_id_propriedade { get; set; }

    }
}
