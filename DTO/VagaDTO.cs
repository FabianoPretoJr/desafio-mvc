using System;
using System.ComponentModel.DataAnnotations;

namespace projeto.DTO
{
    public class VagaDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage="Campo data de abertura de vaga obrigatório!")]
        public DateTime AberturaVaga { get; set; }

        [Required(ErrorMessage="Campo código da vaga obrigatório!")]
        public string CodVaga { get; set; }

        [Required(ErrorMessage="Campo descrição obrigatório!")]
        public string DescricaoVaga { get; set; }

        [Required(ErrorMessage="Campo projeto obrigatório!")]
        public string Projeto { get; set; }

        [Required(ErrorMessage="Campo quantidade de vagas obrigatório!")]
        [Range(1, 1000, ErrorMessage="Suportado apenas valores de 1 a 1000!")]
        public int QtdVaga { get; set; }

        [Required(ErrorMessage="Campo tecnologia das vagas obrigatório!")]
        public string TecnologiaID { get; set; }
        public string TecnologiaIDAntigos { get; set; }
    }
}