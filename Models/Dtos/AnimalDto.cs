using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eficiencia_rural.Models.Dtos
{
    public class AnimalDto
    {
        [Required(ErrorMessage = "A identificação é obrigatório")]
        public required string Nome { get; set; }

    }
}
