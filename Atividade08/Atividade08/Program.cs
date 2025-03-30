using System;

class Funcionario
{
    public string Nome { get; set; }
    public string Cargo { get; set; }
    public decimal SalarioBase { get; set; }

    public Funcionario(string nome, string cargo, decimal salarioBase)
    {
        Nome = nome;
        Cargo = cargo;
        SalarioBase = salarioBase;
    }

    public virtual void ExibirSalario()
    {
        Console.WriteLine($"\nFuncionário: {Nome}");
        Console.WriteLine($"Cargo: {Cargo}");
        Console.WriteLine($"Salário: R$ {SalarioBase:F2}");
    }
}

class Gerente : Funcionario
{
    public Gerente(string nome, decimal salarioBase) : base(nome, "Gerente", salarioBase) { }

    public override void ExibirSalario()
    {
        decimal salarioComBonus = SalarioBase * 1.2m; 
        Console.WriteLine($"\nFuncionário: {Nome}");
        Console.WriteLine($"Cargo: {Cargo}");
        Console.WriteLine($"Salário com bônus: R$ {salarioComBonus:F2}");
    }
}

class Program
{
    static void Main()
    {
        Funcionario funcionario1 = new Funcionario("Gustavo Tozzo", "Desenvolvedor", 5000);
        funcionario1.ExibirSalario();

        Gerente gerente1 = new Gerente("Ana Tozzo", 8000);
        gerente1.ExibirSalario();
    }
}
