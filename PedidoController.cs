using System;
using ProjetoPedidos.Models;

namespace ProjetoPedidos.Controllers
{
    public class PedidoController
    {
        private Restaurante restaurante;

        public PedidoController()
        {
            restaurante = new Restaurante();
        }

        public void criarPedido()
        {
            Console.Write("Digite o nome do cliente: ");
            string cliente = Console.ReadLine();

            Pedido pedido = new Pedido(
                restaurante.getProxPedido(),
                cliente
            );

            if (restaurante.novoPedido(pedido))
            {
                Console.WriteLine("Pedido criado com sucesso!");
                Console.WriteLine("Número do pedido: " + pedido.getId());
            }
            else
            {
                Console.WriteLine("Limite de pedidos atingido.");
            }
        }

        public void adicionarItem()
        {
            Console.Write("Digite o ID do pedido: ");
            int idPedido = int.Parse(Console.ReadLine());

            Pedido pedido = new Pedido(idPedido, "");

            Pedido pedidoEncontrado = restaurante.buscarPedido(pedido);

            if (pedidoEncontrado == null)
            {
                Console.WriteLine("Pedido não encontrado.");
                return;
            }

            Console.Write("Digite o ID do item: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição: ");
            string descricao = Console.ReadLine();

            Console.Write("Digite o preço: ");
            double preco = double.Parse(Console.ReadLine());

            Item item = new Item(id, descricao, preco);

            if (pedidoEncontrado.adicionarItem(item))
            {
                Console.WriteLine("Item adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("O pedido já possui 10 itens.");
            }
        }

        public void removerItem()
        {
            Console.Write("Digite o ID do pedido: ");
            int idPedido = int.Parse(Console.ReadLine());

            Pedido pedido = new Pedido(idPedido, "");

            Pedido pedidoEncontrado = restaurante.buscarPedido(pedido);

            if (pedidoEncontrado == null)
            {
                Console.WriteLine("Pedido não encontrado.");
                return;
            }

            Console.Write("Digite o ID do item: ");
            int idItem = int.Parse(Console.ReadLine());

            Item[] itens = pedidoEncontrado.getItens();

            for (int i = 0; i < itens.Length; i++)
            {
                if (itens[i] != null && itens[i].getId() == idItem)
                {
                    if (pedidoEncontrado.removerItem(itens[i]))
                    {
                        Console.WriteLine("Item removido com sucesso!");
                    }

                    return;
                }
            }

            Console.WriteLine("Item não encontrado.");
        }

        public void consultarPedido()
        {
            Console.Write("Digite o ID do pedido: ");
            int idPedido = int.Parse(Console.ReadLine());

            Pedido pedido = new Pedido(idPedido, "");

            Pedido pedidoEncontrado = restaurante.buscarPedido(pedido);

            if (pedidoEncontrado != null)
            {
                Console.WriteLine();
                Console.WriteLine(pedidoEncontrado.dadosDoPedido());
            }
            else
            {
                Console.WriteLine("Pedido não encontrado.");
            }
        }

        public void cancelarPedido()
        {
            Console.Write("Digite o ID do pedido: ");
            int idPedido = int.Parse(Console.ReadLine());

            Pedido pedido = new Pedido(idPedido, "");

            if (restaurante.cancelarPedido(pedido))
            {
                Console.WriteLine("Pedido cancelado com sucesso!");
            }
            else
            {
                Console.WriteLine("Pedido não encontrado.");
            }
        }

        public void listarPedidos()
        {
            Pedido[] pedidos = restaurante.getPedidos();

            double soma = 0;

            Console.WriteLine();
            Console.WriteLine("===== PEDIDOS DO DIA =====");

            for (int i = 0; i < pedidos.Length; i++)
            {
                if (pedidos[i] != null)
                {
                    double total = pedidos[i].calcularTotal();

                    Console.WriteLine(
                        "Pedido " + pedidos[i].getId() +
                        " - R$ " + total.ToString("F2")
                    );

                    soma += total;
                }
            }

            Console.WriteLine("--------------------------");
            Console.WriteLine(
                "Soma geral: R$ " + soma.ToString("F2")
            );
        }
    }
}
