namespace Atendimento.Domain.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public DateTime DataPedido { get; set; } = DateTime.UtcNow;
        public ICollection<ItemPedido> Itens { get; set; } = new List<ItemPedido>();
    }

}
