namespace ForParty.Models
{
    public class EstoqueDTO 
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public float Preco { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataVencimento { get; set; }
    }
}
