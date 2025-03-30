using System;
using System.IO;

class Program
{
    const string filePath = "contatos.txt";

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n=== Gerenciador de Contatos ===");
            Console.WriteLine("1 - Adicionar novo contato");
            Console.WriteLine("2 - Listar contatos cadastrados");
            Console.WriteLine("3 - Sair");
            Console.Write("\nEscolha uma opção: ");

            string opcao = Console.ReadLine();

            if (opcao == "1") AdicionarContato();
            else if (opcao == "2") ListarContatos();
            else if (opcao == "3")
            {
                Console.WriteLine("Encerrando o programa...");
                break;
            }
            else Console.WriteLine("Opção inválida!");
        }
    }

    static void AdicionarContato()
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Telefone: ");
        string telefone = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        using (StreamWriter sw = File.AppendText(filePath))
        {
            sw.WriteLine($"{nome},{telefone},{email}");
        }

        Console.WriteLine("Contato cadastrado com sucesso!");
    }

    static void ListarContatos()
    {
        if (!File.Exists(filePath) || new FileInfo(filePath).Length == 0)
        {
            Console.WriteLine("Nenhum contato cadastrado.");
            return;
        }

        Console.WriteLine("\nContatos cadastrados:");
        foreach (string linha in File.ReadAllLines(filePath))
        {
            string[] dados = linha.Split(',');
            Console.WriteLine($"Nome: {dados[0]} | Telefone: {dados[1]} | Email: {dados[2]}");
        }
    }
}
