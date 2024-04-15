namespace Blazor_MestreDetalhes.Data
{
    public class Pedido2
    {
        public int PedidoID { get; set; }
        public string? ClienteNome { get; set; }
        public string? ClienteFoto { get; set; }
        public DateTime PedidoData { get; set; }
        public List<PedidoDetalhes2>? PedidoDetalhes { get; set; }
    }
}
