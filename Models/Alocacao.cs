using System;

namespace projeto.Models
{
    public class Alocacao
    {
        public int Id { get; set; }
        public Vaga Vaga { get; set; }
        public DateTime InicioAlocacao { get; set; }
    }
}