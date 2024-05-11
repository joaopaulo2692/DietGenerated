namespace Dieta.Core.Entities
{
    public class PedidoService
    {
        //public List<Pedido>? listaAtualizada {  get; set; }
        //var listaAtualizada = new List<Pedido>();
        List<Pedido> pedidos2 = new List<Pedido>();
        List<Pedido> pedidos = new List<Pedido>()
        {
            new Pedido() { PedidoID=1, ClienteNome="Marcos",ClienteFoto="/images/marcos.jpg", PedidoData = Convert.ToDateTime("01-01-2021")},
            new Pedido() { PedidoID=2, ClienteNome="Pedro",ClienteFoto="/images/pedro.jpg" ,PedidoData = Convert.ToDateTime("11-01-2021")},
            new Pedido() { PedidoID=3, ClienteNome="Maria",ClienteFoto="/images/maria.jpg" ,PedidoData = Convert.ToDateTime("08-02-2020")},
            new Pedido() { PedidoID=4, ClienteNome="Anita",ClienteFoto="/images/anita.jpg" ,PedidoData = Convert.ToDateTime("09-03-2020")},
            new Pedido() { PedidoID=5, ClienteNome="Carolina",ClienteFoto="/images/carolina.jpg" ,PedidoData = Convert.ToDateTime("13-05-2020")},
            new Pedido() { PedidoID=6, ClienteNome="Benedito",ClienteFoto="/images/benedito.jpg" ,PedidoData = Convert.ToDateTime("15-04-2020")},
            new Pedido() { PedidoID=7, ClienteNome="Alice",ClienteFoto="/images/alice.jpg" ,PedidoData = Convert.ToDateTime("15-01-2021")},
            new Pedido() { PedidoID=8, ClienteNome="Akira",ClienteFoto="/images/akira.jpg" ,PedidoData = Convert.ToDateTime("05-01-2021")}
        };

        List<PedidoDetalhes> pedidoDetalhes = new List<PedidoDetalhes>()
        {
            new PedidoDetalhes() {PedidoID = 1, ProdutoID = 10, ProdutoNome = "Caneta", Quantidade = 5, Preco = 12.45},
            new PedidoDetalhes() {PedidoID = 1, ProdutoID = 11, ProdutoNome = "Borracha", Quantidade = 3, Preco = 10.45},
            new PedidoDetalhes() {PedidoID = 2, ProdutoID = 12, ProdutoNome = "Lápis", Quantidade = 4, Preco = 11.25},
            new PedidoDetalhes() {PedidoID = 2, ProdutoID = 13, ProdutoNome = "Caderno", Quantidade = 3, Preco = 17.35},
            new PedidoDetalhes() {PedidoID = 3, ProdutoID = 14, ProdutoNome = "Estojo", Quantidade = 2, Preco = 9.40},
            new PedidoDetalhes() {PedidoID = 3, ProdutoID = 15, ProdutoNome = "Durex", Quantidade = 7, Preco = 15.30},
            new PedidoDetalhes() {PedidoID = 3, ProdutoID = 16, ProdutoNome = "Mouse", Quantidade = 1, Preco = 10.25},
            new PedidoDetalhes() {PedidoID = 4, ProdutoID = 11, ProdutoNome = "Borracha", Quantidade = 4, Preco = 10.99},
            new PedidoDetalhes() {PedidoID = 4, ProdutoID = 18, ProdutoNome = "Grampos", Quantidade = 30, Preco = 11.99},
            new PedidoDetalhes() {PedidoID = 5, ProdutoID = 19, ProdutoNome = "Clips", Quantidade = 10, Preco = 6.55},
            new PedidoDetalhes() {PedidoID = 5, ProdutoID = 10, ProdutoNome = "Caneta", Quantidade = 2, Preco = 8.22},
            new PedidoDetalhes() {PedidoID = 5, ProdutoID = 13, ProdutoNome = "Caderno", Quantidade = 1, Preco = 7.11},
            new PedidoDetalhes() {PedidoID = 6, ProdutoID = 19, ProdutoNome = "Clips", Quantidade = 10, Preco = 6.55},
            new PedidoDetalhes() {PedidoID = 6, ProdutoID = 10, ProdutoNome = "Caneta", Quantidade = 2, Preco = 8.22},
            new PedidoDetalhes() {PedidoID = 7, ProdutoID = 10, ProdutoNome = "Caneta", Quantidade = 3, Preco = 7.11},
            new PedidoDetalhes() {PedidoID = 8, ProdutoID = 12, ProdutoNome = "Lápis", Quantidade = 2, Preco = 7.11},
            new PedidoDetalhes() {PedidoID = 8, ProdutoID = 13, ProdutoNome = "Caderno", Quantidade = 5, Preco = 7.11}
        };

        public async Task<List<Pedido>> PedidoLista()
        {
            var novoPedidoLista = new List<Pedido>();
            
            foreach(var pedido in pedidos)
            {
                pedido.PedidoDetalhes = pedidoDetalhes.Where( p=>
                                        p.PedidoID == pedido.PedidoID).ToList();

                novoPedidoLista.Add(pedido);
            }
            return await Task.FromResult(novoPedidoLista);
        }
        public async Task<List<Pedido>> PedidoLista2()
        {
            var novoPedidoLista = new List<Pedido>();

            foreach (var pedido in pedidos2)
            {
                pedido.PedidoDetalhes = pedidoDetalhes.Where(p =>
                                        p.PedidoID == pedido.PedidoID).ToList();

                novoPedidoLista.Add(pedido);
            }
            return await Task.FromResult(novoPedidoLista);
        }

        //public async Task<List<Pedido>> ExcluirNome(Pedido nome)
        //{

        //    foreach (var pedido in pedidos)
        //    {
        //        if(pedido.ClienteNome == nome.ClienteNome)
        //        {

        //            listaAtualizada.Add(pedido);
        //        }
        //    }
        //    return await Task.FromResult(listaAtualizada);

        //}

    }
}
