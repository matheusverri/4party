namespace ForParty.Models
{
    public class ClienteCaixaDTO
    {
        public string? CPF { get; set; }
        public string? ValorTotal { get; set; }
        public List<CaixaConsumoDTO>? Consumo { get; set; }
    }
}
