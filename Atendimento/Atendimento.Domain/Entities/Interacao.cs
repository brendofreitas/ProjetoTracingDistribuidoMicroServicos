namespace Atendimento.Domain.Entities
{
    public class Interacao
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public string Tipo { get; set; } = string.Empty; // Ex: "Reclamação", "Elogio", "Dúvida"
        public string Mensagem { get; set; } = string.Empty;
        public DateTime Data { get; set; } = DateTime.UtcNow;
    }

}
