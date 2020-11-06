namespace projeto.Models
{
    public class FuncionarioTecnologia
    {
        public int FuncionarioID { get; set; }
        public Funcionario Funcionario { get; set; }
        public int TecnologiaID { get; set; }
        public Tecnologia Tecnologia { get; set; }
    }
}