using System.ComponentModel.DataAnnotations;

namespace projeto.DTO
{
    public class GftDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage="Campo CEP obrigatório!")]
        public string Cep { get; set; }

        [Required(ErrorMessage="Campo cidade obrigatório!")]
        public string Cidade { get; set; }

        [Required(ErrorMessage="Campo endereço obrigatório!")]
        public string Endereco { get; set; }

        [Required(ErrorMessage="Campo estado obrigatório!")]
        public string Estado { get; set; }

        [Required(ErrorMessage="Campo nome obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage="Campo telefone obrigatório!")]
        public string Telefone { get; set; }
    }
}