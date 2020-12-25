using System;

namespace cadastro_produto
{
    class Loja
    {
        public void CadastrarProduto(Produto[] prod)
        {
            string opcao;

            if (EstoqueCompleto(prod).Equals(true))
            {
                Console.WriteLine("Estoque completo, não é possível cadastrar mais um produto.");
            }

            else
            {
                for (int i = 0; i < prod.Length; i++)
                {
                    prod[i] = new Produto();
                    Console.WriteLine("Informe a descrição do produto");
                    prod[i].descricao = Console.ReadLine();

                    Console.WriteLine("Informe o preço: ");
                    prod[i].preco = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Informe o custo: ");
                    prod[i].custo = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Informe o código do produto: ");
                    prod[i].id = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Deseja cadastrar mais um produto? S/N \n");
                    opcao = Console.ReadLine();

                    if (opcao.Equals("N") || opcao.Equals("n"))
                    {
                        break;
                    }
                }
            }
        }

        public double PrecoMedioProdutos(Produto[] prod)
        {
            double total = 0;

            for (int i = 0; i < prod.Length; i++)
            {
                total += prod[i].preco;
            }

            return total / prod.Length;
        }

        public void ImprimiListagemProdutosEstoque(Produto[] prod)
        {
            for (int i = 0; i < prod.Length; i++) 
            {
                Console.WriteLine($"Código: {prod[i].id}");
                Console.WriteLine($"Descrição: {prod[i].descricao}");
                Console.WriteLine($"Custo: R$ {prod[i].custo}");
                Console.WriteLine($"Preço: R$ {prod[i].preco}");
                Console.WriteLine($"Lucro: R$ {prod[i].preco - prod[i].custo}\n");
            }

        }

        private bool EstoqueCompleto(Produto[] prod)
        {
            for (int i = 0; i < prod.Length; i++)
            {
                if (prod[i] == null)
                {
                    return false;
                }
            }

            return true;
        }
        
        public double AtualizarPrecoProduto(Produto[] prod, int codigo)
        {
            string opcao;
            double percentual;
            double novoValor;

            for (int i = 0; i < prod.Length; i++)
            {
                if (prod[i].id == codigo)
                {
                    Console.WriteLine("Informe se será feito um acréscimo ou desconto do valor. DIGITE (acrescimo/desconto) ");
                    opcao = Console.ReadLine();

                    if (opcao.Equals("acrescimo"))
                    {
                        Console.Write("Informe o percentual de acrescimo: ");
                        percentual = Convert.ToDouble(Console.ReadLine());
                        novoValor = ((percentual * prod[i].preco) / 100) + prod[i].preco;

                        prod[i].preco = novoValor;

                        return novoValor;
                    }
                    
                    Console.Write("Informe o percentual de desconto: ");
                    percentual = Convert.ToDouble(Console.ReadLine());
                    novoValor = prod[i].preco - ((percentual * prod[i].preco) / 100);

                    prod[i].preco = novoValor;

                    return novoValor;
                }
            }

            return 0;
        }
    }
}
