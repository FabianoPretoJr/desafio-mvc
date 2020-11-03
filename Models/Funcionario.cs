using System;

namespace projeto.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Cargo { get; set; }
        public DateTime InicioWA { get; set; }
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public DateTime TerminoWA { get; set; }
        public Vaga Vaga { get; set; }
        public Gft Gft { get; set; }
    }
}