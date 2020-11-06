using System.Collections.Generic;

namespace projeto.Models
{
    public class Tecnologia
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<FuncionarioTecnologia> FuncionarioTecnologias { get; set; }
        public ICollection<VagaTecnologia> VagaTecnologias { get; set; }
    }
}