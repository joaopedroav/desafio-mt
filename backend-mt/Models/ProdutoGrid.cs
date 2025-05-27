namespace backend_mt.Models
{
    public class ProdutoGrid
    {
        public Guid ID { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Departamento { get; set; }
        public Guid DepartamentoId { get; set; }
        public double Preco { get; set; }
        public bool Status { get; set; }
    }
}
