namespace ForParty.Models
{
    public class AdicionarItemEstoqueDTO
    {
        public string? Nome { get; set; }
        public float Preco { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataVencimento { get; set; }
    }
}
