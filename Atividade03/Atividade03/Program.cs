using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Calculadora Simples");
        
        double num1 = LerNumero("Digite o primeiro número: ");
        double num2 = LerNumero("Digite o segundo número: ");

        // Exibe o menu de operações
        Console.WriteLine("\nEscolha a operação:");
        Console.WriteLine("1 - Soma");
        Console.WriteLine("2 - Subtração");
        Console.WriteLine("3 - Multiplicação");
        Console.WriteLine("4 - Divisão");

        int opcao = LerOpcao();

        // Calcula e exibe o resultado
        double resultado = 0;
        bool operacaoValida = true;

        switch (opcao)
        {
            case 1:
                resultado = num1 + num2;
                Console.WriteLine($"Resultado: {num1} + {num2} = {resultado}");
                break;
            case 2:
                resultado = num1 - num2;
                Console.WriteLine($"Resultado: {num1} - {num2} = {resultado}");
                break;
            case 3:
                resultado = num1 * num2;
                Console.WriteLine($"Resultado: {num1} * {num2} = {resultado}");
                break;
            case 4:
                if (num2 != 0)
                {
                    resultado = num1 / num2;
                    Console.WriteLine($"Resultado: {num1} / {num2} = {resultado}");
                }
                else
                {
                    Console.WriteLine("A divisão por zero não é permitida.");
                    operacaoValida = false;
                }
                break;
            default:
                operacaoValida = false;
                Console.WriteLine("Opção inválida.");
                break;
        }

        if (operacaoValida)
            Console.WriteLine("Operação realizada com sucesso!");
    }

    // Método para validar entrada numérica
    static double LerNumero(string mensagem)
    {
        double numero;
        while (true)
        {
            Console.Write(mensagem);
            if (double.TryParse(Console.ReadLine(), out numero))
                return numero;
            else
                Console.WriteLine("Entrada inválida! Digite um número válido.");
        }
    }

    // Método para validar a opção da operação
    static int LerOpcao()
    {
        int opcao;
        while (true)
        {
            Console.Write("\nDigite a opção desejada (1-4): ");
            if (int.TryParse(Console.ReadLine(), out opcao) && opcao >= 1 && opcao <= 4) { 
                Console.Write($"Opção escolhida: {opcao}\n");
                return opcao;
            }
            else
                Console.WriteLine("Opção inválida! Escolha um número entre 1 e 4.");
        }
    }
}
