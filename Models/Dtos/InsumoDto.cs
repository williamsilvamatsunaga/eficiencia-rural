using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eficiencia_rural.Models.Dtos
{
    public class InsumoDto
    {
        [Required(ErrorMessage = "A descrição é obrigatório")]
        public required string Descricao { get; set; }

        [Required(ErrorMessage = "A categoria é obrigatório")]
        public required string Categoria { get; set; }
    }
}
