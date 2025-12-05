using System.ComponentModel.DataAnnotations;

namespace eficiencia_rural.Models.Dtos
{
    public class ProducaoDto
    {
        [Required(ErrorMessage = "A quantidade de litros é obrigatório")]
        public required string QuantidadeLitros { get; set; }
    }
}
