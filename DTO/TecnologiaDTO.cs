using System.ComponentModel.DataAnnotations;

namespace projeto.DTO
{
    public class TecnologiaDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage="Campo nome obrigatório!")]
        public string Nome { get; set; }
    }
}