namespace Dieta.Core.Entities
{
    public class Pedido
    {
        public int PedidoID { get; set; }
        public string? ClienteNome { get; set; }
        public string? ClienteFoto { get; set; }
        public DateTime PedidoData { get; set; }
        public List<PedidoDetalhes>? PedidoDetalhes { get; set; }
    }
}
