namespace ForParty.Models
{
    public class PedidoDTO
    {
        public int Id { get; set; }
        public DateTime HoraEntrada { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? Pedido { get; set; }
    }
}
