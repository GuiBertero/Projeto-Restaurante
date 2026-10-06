using System;
using ProjetoPedidos.Controllers;

namespace ProjetoPedidos
{
    class Program
    {
        static void Main(string[] args)
        {
            PedidoController controller = new PedidoController();

            int opcao = -1;

            while (opcao != 0)
            {
                Console.Clear();

                Console.WriteLine("===== RESTAURANTE =====");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("1 - Criar novo pedido");
                Console.WriteLine("2 - Adicionar item ao pedido");
                Console.WriteLine("3 - Remover item do pedido");
                Console.WriteLine("4 - Consultar pedido");
                Console.WriteLine("5 - Cancelar pedido");
                Console.WriteLine("6 - Listar todos os pedidos");
                Console.WriteLine("=======================");

                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                Console.Clear();

                switch (opcao)
                {
                    case 0:
                        Console.WriteLine("Programa encerrado.");
                        break;

                    case 1:
                        controller.criarPedido();
                        break;

                    case 2:
                        controller.adicionarItem();
                        break;

                    case 3:
                        controller.removerItem();
                        break;

                    case 4:
                        controller.consultarPedido();
                        break;

                    case 5:
                        controller.cancelarPedido();
                        break;

                    case 6:
                        controller.listarPedidos();
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                if (opcao != 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Pressione ENTER para continuar...");
                    Console.ReadLine();
                }
            }
        }
    }
}
