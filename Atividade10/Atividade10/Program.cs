using System;

class Program
{
    static void Main()
    {
        Random rand = new Random();
        int numeroSecreto = rand.Next(1, 51);
        int tentativas = 5;

        Console.WriteLine("Tente adivinhar um número entre 1 e 50!");

        while (tentativas > 0)
        {
            Console.Write($"Você tem {tentativas} tentativa(s). Digite um número: ");

            try
            {
                int palpite = int.Parse(Console.ReadLine());

                if (palpite < 1 || palpite > 50)
                {
                    Console.WriteLine("Número fora do intervalo! Digite um número entre 1 e 50.");
                    continue;
                }

                if (palpite == numeroSecreto)
                {
                    Console.WriteLine("Parabéns! Você acertou o número!");
                    return;
                }
                else if (palpite < numeroSecreto)
                {
                    Console.WriteLine("Tente um número maior!");
                }
                else
                {
                    Console.WriteLine("Tente um número menor!");
                }

                tentativas--;
            }
            catch (FormatException)
            {
                Console.WriteLine("Entrada inválida! Digite um número inteiro.");
            }
        }

        Console.WriteLine($"Fim de jogo! O número correto era {numeroSecreto}.");
    }
}
