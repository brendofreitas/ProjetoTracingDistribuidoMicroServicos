namespace Deposito.Domain.Entities
{
    public class MovimentacaoEstoque
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public int Quantidade { get; set; }
        public DateTime DataMovimentacao { get; set; }
        public string Tipo { get; set; } = "Entrada"; // ou "Saída"
    }
}
