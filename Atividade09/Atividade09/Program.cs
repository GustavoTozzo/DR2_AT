using System;
using System.IO;

class Program
{
    const string filePath = "estoque.txt";

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n1. Inserir Produto");
            Console.WriteLine("2. Listar Produtos");
            Console.WriteLine("3. Sair");
            Console.Write("\nEscolha: ");

            string opcao = Console.ReadLine();

            if (opcao == "1") InserirProduto();
            else if (opcao == "2") ListarProdutos();
            else if (opcao == "3")
            {
                Console.WriteLine("Encerrando o programa...");
                break;
            }
            else Console.WriteLine("Opção inválida!");
        }
    }

    static void InserirProduto()
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Quantidade: ");
        string quantidade = Console.ReadLine();

        Console.Write("Preço: ");
        string preco = Console.ReadLine();

        using (StreamWriter sw = File.AppendText(filePath))
        {
            sw.WriteLine($"{nome},{quantidade},{preco}");
        }

        Console.WriteLine("Produto adicionado!");
    }

    static void ListarProdutos()
    {
        if (!File.Exists(filePath) || new FileInfo(filePath).Length == 0)
        {
            Console.WriteLine("Nenhum produto cadastrado.");
            return;
        }

        foreach (string linha in File.ReadAllLines(filePath))
        {
            string[] dados = linha.Split(',');
            Console.WriteLine($"Produto: {dados[0]} | Quantidade: {dados[1]} | Preço: R$ {dados[2]}");
        }
    }
}
