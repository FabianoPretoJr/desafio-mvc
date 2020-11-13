using System;
using System.ComponentModel.DataAnnotations;

namespace projeto.DTO
{
    public class AlocacaoDTO
    {
        [Required]
        public int Id { get; set; }
        
        [Required(ErrorMessage="Campo Funcionário obrigatório!")]
        public int FuncionarioID { get; set; }

        [Required(ErrorMessage="Campo Vaga obrigatório!")]
        public int VagaID { get; set; }
    }
}