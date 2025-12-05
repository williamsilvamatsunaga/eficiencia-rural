using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eficiencia_rural.Models.Dtos
{
    public class PropriedadeDto
    {
        [Required(ErrorMessage = "A nome é obrigatório")]
        public required string Nome { get; set; }
    }
}
