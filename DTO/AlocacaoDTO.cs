using System;
using System.ComponentModel.DataAnnotations;

namespace projeto.DTO
{
    public class AlocacaoDTO
    {
        public int Id { get; set; }
        public int FuncionarioID { get; set; }
        public int VagaID { get; set; }
    }
}