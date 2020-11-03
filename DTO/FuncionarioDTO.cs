using System;
using System.ComponentModel.DataAnnotations;

namespace projeto.DTO
{
    public class FuncionarioDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage="Campo cargo obrigatório!")]
        public string Cargo { get; set; }

        [Required(ErrorMessage="Campo inicio WA obrigatório!")]
        public DateTime InicioWA { get; set; }

        [Required(ErrorMessage="Campo matricula obrigatório!")]
        public string Matricula { get; set; }

        [Required(ErrorMessage="Campo nome obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage="Campo termino WA obrigatório!")]
        public DateTime TerminoWA { get; set; }

        [Required(ErrorMessage="Campo vaga obrigatório!")]
        public int VagaID { get; set; }

        [Required(ErrorMessage="Campo GFT obrigatório!")]
        public int GftID { get; set; }
    }
}