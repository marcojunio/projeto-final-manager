using System;

namespace cadastro_produto
{
    class Program
    {
        public static string Menu()
        {
            string opcao;

            Console.WriteLine();
            Console.WriteLine("Bem vindo! informe a letra referente a uma opção abaixo");
            Console.WriteLine("a) Cadastrar produto");
            Console.WriteLine("b) Atuazlizar o preço de um produto");
            Console.WriteLine("c) Imprimir o preço médio dos produtos");
            Console.WriteLine("d) Imprimir listagem de produtos");
            Console.WriteLine("e) Sair");
            Console.WriteLine();
            opcao = Console.ReadLine();

            return opcao;
        }

        static void Main(string[] args)
        {
            Produto [] produtos = new Produto[100];
            bool parada = true;
            Loja loja = new Loja();

            while (parada)
            {
                string opcao = Menu();

                switch (opcao)
                {
                    case "a":
                        loja.CadastrarProduto(produtos);
                        break;

                    case "b":
                        
                        int codigo;
                        Console.Write("Informe o código do produto a ser alterado: ");
                        codigo = Convert.ToInt32(Console.ReadLine());
                        double novoValor = loja.AtualizarPrecoProduto(produtos, codigo);

                        if (novoValor == 0)
                        {
                            Console.WriteLine("Código informado inexistente");
                        }
                        else
                        {
                            Console.WriteLine($"Valor alterado com sucesso para R$: {novoValor}");
                        }
                        
                        break;
                    
                    case "c":
                        Console.WriteLine($"O preço médio dos produtos cadastrados é de: {loja.PrecoMedioProdutos(produtos)}");
                        break;

                    case "d":
                        loja.ImprimiListagemProdutosEstoque(produtos);
                        break;

                    case "e":
                        parada = false;
                        break;
                }

            }

            Console.WriteLine("Até logo !!");
            Console.ReadKey();
        }
    }
}
