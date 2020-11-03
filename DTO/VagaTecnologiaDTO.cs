using System.ComponentModel.DataAnnotations;

namespace projeto.DTO
{
    public class VagaTecnologiaDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int VagaID { get; set; }

        [Required]
        public int TecnologiaID { get; set; }
    }
}