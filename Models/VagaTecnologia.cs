namespace projeto.Models
{
    public class VagaTecnologia
    {
        public int VagaID { get; set; }
        public Vaga Vaga { get; set; }
        public int TecnologiaID { get; set; }
        public Tecnologia Tecnologia { get; set; }
    }
}