﻿namespace Dieta.Core.Data
{
    public class PedidoDetalhes
    {
        public int PedidoID { get; set; }
        public int ProdutoID { get; set; }
        public string? ProdutoNome { get; set; }
        public double? Quantidade { get; set; }
        public double? Preco { get; set; }
    }
}
