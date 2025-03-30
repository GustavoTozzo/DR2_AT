using System;

class Program
{
    static void Main()
    {
        Console.Write("Digite sua data de nascimento (dd/MM/yyyy): ");
        DateTime dataNascimento;

        // Validação da entrada da data
        while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataNascimento))
        {
            Console.WriteLine("Formato inválido! Digite novamente no formato dd/MM/yyyy.");
            Console.Write("Digite sua data de nascimento: ");
        }

        // Obtém a data atual
        DateTime hoje = DateTime.Today;

        // Define a próxima data de aniversário
        DateTime proximoAniversario = new DateTime(hoje.Year, dataNascimento.Month, dataNascimento.Day);

        // Se o aniversário já passou este ano, ajusta para o próximo ano
        if (proximoAniversario < hoje)
        {
            proximoAniversario = proximoAniversario.AddYears(1);
        }

        // Calcula a diferença de dias
        int diasFaltando = (proximoAniversario - hoje).Days;

        // Exibe o resultado formatado
        Console.WriteLine($"\nFaltam {diasFaltando} dias para o seu aniversário!");

        // Mensagem especial se faltar menos de 7 dias
        if (diasFaltando < 7)
        {
            Console.WriteLine("\nSeu aniversário está chegando! Já preparou a comemoração?");
        }
    }
}
