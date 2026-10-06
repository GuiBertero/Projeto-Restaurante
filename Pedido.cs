using System;

namespace ProjetoPedidos.Models
{
    public class Pedido
    {
        private int id;
        private string cliente;
        private Item[] itens;

        public Pedido(int id, string cliente)
        {
            this.id = id;
            this.cliente = cliente;
            this.itens = new Item[10];
        }

        public int getId()
        {
            return id;
        }

        public string getCliente()
        {
            return cliente;
        }

        public bool adicionarItem(Item item)
        {
            for (int i = 0; i < itens.Length; i++)
            {
                if (itens[i] == null)
                {
                    itens[i] = item;
                    return true;
                }
            }

            return false;
        }

        public bool removerItem(Item item)
        {
            for (int i = 0; i < itens.Length; i++)
            {
                if (itens[i] == item)
                {
                    itens[i] = null;
                    return true;
                }
            }

            return false;
        }

        public double calcularTotal()
        {
            double total = 0;

            for (int i = 0; i < itens.Length; i++)
            {
                if (itens[i] != null)
                {
                    total += itens[i].getPreco();
                }
            }

            return total;
        }

        public string dadosDoPedido()
        {
            string dados = "";

            dados += "ID: " + id + "\n";
            dados += "Cliente: " + cliente + "\n";
            dados += "Itens:\n";

            for (int i = 0; i < itens.Length; i++)
            {
                if (itens[i] != null)
                {
                    dados += "- " + itens[i].getDescricao();
                    dados += " - R$ " + itens[i].getPreco().ToString("F2") + "\n";
                }
            }

            dados += "Total: R$ " + calcularTotal().ToString("F2");

            return dados;
        }

        public Item[] getItens()
        {
            return itens;
        }
    }
}
