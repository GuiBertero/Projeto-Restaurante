namespace ProjetoPedidos.Models
{
    public class Restaurante
    {
        private int proxPedido;
        private Pedido[] pedidos;

        public Restaurante()
        {
            proxPedido = 1;
            pedidos = new Pedido[50];
        }

        public bool novoPedido(Pedido pedido)
        {
            for (int i = 0; i < pedidos.Length; i++)
            {
                if (pedidos[i] == null)
                {
                    pedidos[i] = pedido;
                    proxPedido++;
                    return true;
                }
            }

            return false;
        }

        public Pedido buscarPedido(Pedido pedido)
        {
            for (int i = 0; i < pedidos.Length; i++)
            {
                if (pedidos[i] != null && pedidos[i].getId() == pedido.getId())
                {
                    return pedidos[i];
                }
            }

            return null;
        }

        public bool cancelarPedido(Pedido pedido)
        {
            for (int i = 0; i < pedidos.Length; i++)
            {
                if (pedidos[i] != null && pedidos[i].getId() == pedido.getId())
                {
                    pedidos[i] = null;
                    return true;
                }
            }

            return false;
        }

        public int getProxPedido()
        {
            return proxPedido;
        }

        public Pedido[] getPedidos()
        {
            return pedidos;
        }
    }
}
