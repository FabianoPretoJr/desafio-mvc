using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

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
        [StringLength(7, ErrorMessage="Deve conter 7 caracteres!")]
        [MinLength(7, ErrorMessage="Deve conter 7 caracteres!")]
        public string Matricula { get; set; }

        [Required(ErrorMessage="Campo nome obrigatório!")]
        [StringLength(70, ErrorMessage="Máximo 70 caracteres!")]
        [MinLength(3, ErrorMessage="mínimo 3 caracteres!")]
        public string Nome { get; set; }

        [Required(ErrorMessage="Campo termino WA obrigatório!")]
        public DateTime TerminoWA { get; set; }

        [Required(ErrorMessage="Campo vaga obrigatório!")]
        public int VagaID { get; set; }

        [Required(ErrorMessage="Campo unidade GFT obrigatório!")]
        public int GftID { get; set; }

        [Required(ErrorMessage="Campo tecnologias obrigatório!")]
        public string TecnologiaID { get; set; }
        public string TecnologiaIDAntigos { get; set; }
    }
}