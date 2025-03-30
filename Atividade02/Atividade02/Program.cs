using System;

class Program
{
    static void Main()
    {
        Console.Write("Digite seu nome completo: ");
        string nome = Console.ReadLine();

        string nomeCifrado = CifrarNome(nome);
        Console.WriteLine($"Nome cifrado: {nomeCifrado}");
    }

    static string CifrarNome(string nome)
    {
        char[] caracteres = nome.ToCharArray();

        for (int i = 0; i < caracteres.Length; i++)
        {
            char c = caracteres[i];

            if (char.IsLetter(c)) // Verifica se é uma letra
            {
                char baseChar = char.IsUpper(c) ? 'A' : 'a';
                char novoCaractere = (char)(c + 2); // Desloca 2 posições para frente

                // Verifica se ultrapassou o alfabeto e ajusta para iniciar do 'A'
                if ((char.IsUpper(c) && novoCaractere > 'Z') || (char.IsLower(c) && novoCaractere > 'z'))
                {
                    novoCaractere -= (char)26;
                }

                caracteres[i] = novoCaractere;
            }
        }

        return new string(caracteres);
    }
}