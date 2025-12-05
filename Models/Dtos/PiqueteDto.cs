using System.ComponentModel.DataAnnotations;

namespace eficiencia_rural.Models.Dtos
{
    public class PiqueteDto
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public required string Nome { get; set; }
    }
}
