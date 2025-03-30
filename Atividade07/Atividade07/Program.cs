using System;

class ContaBancaria
{
    // Propriedade pública para o nome do titular
    public string Titular { get; private set; }

    // Propriedade privada para armazenar o saldo
    private decimal saldo;

    // Construtor da classe para inicializar a conta com um titular
    public ContaBancaria(string titular)
    {
        Titular = titular;
        saldo = 0;
    }

    // Método para depositar um valor na conta
    public void Depositar(decimal valor)
    {
        if (valor > 0)
        {
            saldo += valor;
            Console.WriteLine($"\nDepósito de R$ {valor:F2} realizado com sucesso!");
        }
        else
        {
            Console.WriteLine("\nO valor do depósito deve ser positivo!");
        }
    }

    // Método para sacar um valor da conta
    public void Sacar(decimal valor)
    {
        if (valor > 0 && valor <= saldo)
        {
            saldo -= valor;
            Console.WriteLine($"\nSaque de R$ {valor:F2} realizado com sucesso!");
        }
        else if (valor > saldo)
        {
            Console.WriteLine("\nSaldo insuficiente para realizar o saque!");
        }
        else
        {
            Console.WriteLine("\nO valor do saque deve ser positivo!");
        }
    }

    // Método para exibir o saldo da conta
    public void ExibirSaldo()
    {
        Console.WriteLine($"\nSaldo atual: R$ {saldo:F2}");
    }
}

class Program
{
    static void Main()
    {
        // Criando uma conta bancária
        ContaBancaria conta = new ContaBancaria("Gustavo Tozzo");

        Console.WriteLine($"Titular: {conta.Titular}");

        // Simulando operações bancárias
        conta.Depositar(1000);
        conta.ExibirSaldo();

        conta.Sacar(700); 

        conta.ExibirSaldo();

        conta.Sacar(400);

        conta.ExibirSaldo();

    }
}
