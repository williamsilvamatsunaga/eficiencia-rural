using System.ComponentModel.DataAnnotations;

namespace eficiencia_rural.Models.Dtos
{
    public class PiqueteDto
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public required string Nome { get; set; }

        [Required]
        public required double Tamanho { get; set; }

        [Required]
        public required string TipoPastagem { get; set; }

        [Required]
        public required int fk_id_propriedade { get; set; }


    }
}
