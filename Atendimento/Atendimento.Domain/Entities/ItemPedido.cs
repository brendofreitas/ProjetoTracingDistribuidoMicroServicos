﻿namespace Atendimento.Domain.Entities
{
    public class ItemPedido
    {
        public int Id { get; set; }

        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }

        public int ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
    }

}
