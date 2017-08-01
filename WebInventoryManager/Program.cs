using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using GerenciadorProdutosWCF;
using GerenciadorComprasWCF;


namespace WebInventoryManager
{
    class Program
    {
        static ServicoGerenciadorProdutos gerenciaProdutos = new ServicoGerenciadorProdutos();

        static void Main(string[] args)
        {
            ManualResetEvent CompletedEvent = new ManualResetEvent(false);


            List<Produto> produtos = gerenciaProdutos.ObterProdutos();

            foreach (var produto in produtos)
            {
                Console.WriteLine(produto.Nome);
            }

            
            Console.WriteLine("1. Adicionar Produto");
            Console.WriteLine("2. Remover Produto");
            Console.WriteLine("3. Listar Produtos");
            var comando = Convert.ToInt32(Console.ReadLine());


            switch (comando)
            {
                case 1:
                    Adicionar();
                    break;
                case 2:
                    Remover();
                    break;
                case 3:
                    ExibirTodos();
                    break;
            }


            Console.ReadLine();

        }

        
        public static void Adicionar()
        {
            Console.WriteLine("Qual o nome do Produto?");
            var nome = Console.ReadLine();

            Console.WriteLine("Qual a descrição do Produto?");
            var descricao = Console.ReadLine();

            Console.WriteLine("Qual a categoria do Produto?");
            var categoria =  Console.ReadLine();

            Console.WriteLine("Qual o preço do Produto?");
            var preco = Console.ReadLine();

            Produto produto = new Produto();

            produto.Nome = produto.Nome;
            produto.Descricao = produto.Descricao;
            produto.Categoria = produto.Categoria;
            produto.Preco = produto.Preco;


            gerenciaProdutos.AdicionarProduto(produto);

        }
       
        public static void ExibirTodos()
        {
            gerenciaProdutos.ObterProdutos();
        }

        public static void Remover()
        {
            Console.WriteLine("qual o produto Quer Deletar?");
            var produto = Console.ReadLine();

            var remova = gerenciaProdutos.ObterProdutos().SingleOrDefault(x => x.Nome == produto);

            gerenciaProdutos.RemoverProduto(remova);
        }
        
    }
}
