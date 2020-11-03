using System.ComponentModel.DataAnnotations;

namespace projeto.DTO
{
    public class FuncionarioTecnologiaDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int FuncionarioID { get; set; }

        [Required]
        public int TecnologiaID { get; set; }
    }
}