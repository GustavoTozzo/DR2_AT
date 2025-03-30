using System;

class Aluno
{
    public string Nome { get; set; }
    public string Matricula { get; set; }
    public string Curso { get; set; }
    public double MediaNotas { get; set; }

    // Método para exibir os dados do aluno
    public void ExibirDados()
    {
        Console.WriteLine("\nDados do Aluno:");
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Matrícula: {Matricula}");
        Console.WriteLine($"Curso: {Curso}");
        Console.WriteLine($"Média das Notas: {MediaNotas:F2}");
        Console.WriteLine($"Situação: {VerificarAprovacao()}");
    }

    // Método para verificar se o aluno foi aprovado
    public string VerificarAprovacao()
    {
        return MediaNotas >= 7.0 ? "Aprovado!" : "Reprovado!";
    }
}

class Program
{
    static void Main()
    {
        // Criando um objeto da classe Aluno
        Aluno aluno1 = new Aluno
        {
            Nome = "Gustavo Tozzo",
            Matricula = "1234565",
            Curso = "Análise e Desenvolvimento de Sistemas",
            MediaNotas = 8.5
        };

        aluno1.ExibirDados();
    }
}
