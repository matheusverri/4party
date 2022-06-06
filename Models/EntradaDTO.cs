namespace ForParty.Models
{
    public class EntradaDTO
    {
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? Email { get; set; }
        public DateTime Nascimento { get; set; }
        public SexoEnum Sexo { get; set; }
        public IngressoEnum Ingresso { get; set; }
    }
}
