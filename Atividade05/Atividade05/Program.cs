using System;

class Program
{
    static void Main()
    {
        DateTime dataFormatura = new DateTime(2026, 12, 15);

        Console.Write("Digite a data atual (dd/MM/yyyy): ");
        DateTime dataAtual;

        while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataAtual) || dataAtual > DateTime.Today)
        {
            Console.WriteLine("Erro: A data informada é inválida ou está no futuro! Digite novamente.");
            Console.Write("Digite a data atual (dd/MM/yyyy): ");
        }

        if (dataAtual > dataFormatura)
        {
            Console.WriteLine("Parabéns! Você já deveria estar formado!");
            return;
        }

        TimeSpan diferenca = dataFormatura - dataAtual;
        int anos = dataFormatura.Year - dataAtual.Year;
        int meses = dataFormatura.Month - dataAtual.Month;
        int dias = dataFormatura.Day - dataAtual.Day;

        if (dias < 0)
        {
            meses--;
            dias += DateTime.DaysInMonth(dataAtual.Year, dataAtual.Month);
        }

        if (meses < 0)
        {
            anos--;
            meses += 12;
        }

        Console.WriteLine($"\nFaltam {anos} anos, {meses} meses e {dias} dias para sua formatura!");

        if (anos == 0 && meses < 6)
        {
            Console.WriteLine("\nVocê está quase terminando a Faculdade ! Prepare-se para a formatura!");
        }
    }
}
