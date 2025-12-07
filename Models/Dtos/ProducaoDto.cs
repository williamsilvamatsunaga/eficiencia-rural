using System.ComponentModel.DataAnnotations;

namespace eficiencia_rural.Models.Dtos
{
    public class ProducaoDto
    {
        [Required(ErrorMessage = "A quantidade de litros é obrigatório")]
        public required double QuantidadeLitros { get; set; }

        [Required]
        public required double ValorUnitario { get; set; }

        [Required]
        public required double QuantidadeVacas { get; set; }



        //[Required]
        //public int fk_id_animal { get; set; }


    }
}
