using System;
using System.IO;
using System.Collections.Generic;

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

        List<Contato> contatos = new List<Contato>();
        foreach (string linha in File.ReadAllLines(filePath))
        {
            string[] dados = linha.Split(',');
            contatos.Add(new Contato(dados[0], dados[1], dados[2]));
        }

        Console.WriteLine("Escolha o formato de exibição:");
        Console.WriteLine("1 - Markdown");
        Console.WriteLine("2 - Tabela");
        Console.WriteLine("3 - Texto Puro");
        Console.Write("Opção: ");
        string formato = Console.ReadLine();

        ContatoFormatter formatter;
        if (formato == "1") formatter = new MarkdownFormatter();
        else if (formato == "2") formatter = new TabelaFormatter();
        else formatter = new RawTextFormatter();

        formatter.ExibirContatos(contatos);
    }
}

class Contato
{
    public string Nome { get; }
    public string Telefone { get; }
    public string Email { get; }

    public Contato(string nome, string telefone, string email)
    {
        Nome = nome;
        Telefone = telefone;
        Email = email;
    }
}

abstract class ContatoFormatter
{
    public abstract void ExibirContatos(List<Contato> contatos);
}

class MarkdownFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        Console.WriteLine("\n## Lista de Contatos");
        foreach (var contato in contatos)
        {
            Console.WriteLine($"- **Nome:** {contato.Nome}");
            Console.WriteLine($"- Telefone: {contato.Telefone}");
            Console.WriteLine($"- Email: {contato.Email}\n");
        }
    }
}

class TabelaFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        Console.WriteLine("\n----------------------------------------");
        Console.WriteLine("| Nome | Telefone | Email |");
        Console.WriteLine("----------------------------------------");
        foreach (var contato in contatos)
        {
            Console.WriteLine($"| {contato.Nome} | {contato.Telefone} | {contato.Email} |");
        }
        Console.WriteLine("----------------------------------------");
    }
}

class RawTextFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        Console.WriteLine("\nContatos cadastrados:");
        foreach (var contato in contatos)
        {
            Console.WriteLine($"Nome: {contato.Nome} | Telefone: {contato.Telefone} | Email: {contato.Email}");
        }
    }
}
