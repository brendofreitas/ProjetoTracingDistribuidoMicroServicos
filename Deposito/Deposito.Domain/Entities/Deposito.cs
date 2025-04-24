namespace Deposito.Domain.Entities
{
    public class Deposito
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataEntrada { get; set; } = DateTime.UtcNow;
    }
}
