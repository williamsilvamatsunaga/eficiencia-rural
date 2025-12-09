using System.ComponentModel.DataAnnotations;

namespace eficiencia_rural.Models.Dtos
{
    public class Propriedade_insumoDTO
    {
        [Required]
        [MinLength(1)]
        public List<int> PropriedadesIds { get; set; } = [];
    }
}
