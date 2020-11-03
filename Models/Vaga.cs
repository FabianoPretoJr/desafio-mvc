using System;

namespace projeto.Models
{
    public class Vaga
    {
        public int Id { get; set; }
        public DateTime AberturaVaga { get; set; }
        public string CodVaga { get; set; }
        public string DescricaoVaga { get; set; }
        public string Projeto { get; set; }
        public int QtdVaga { get; set; }
    }
}