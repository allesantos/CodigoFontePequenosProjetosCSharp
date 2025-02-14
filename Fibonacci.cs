using System;

class Program
{
    static void Main()
    {
        Console.Write("Digite um número para verificar se pertence à sequência de Fibonacci: ");
        string input = Console.ReadLine() ?? string.Empty;

        if (!int.TryParse(input, out int numero) || numero < 0)
        {
            Console.WriteLine("Entrada inválida. Por favor, insira um número inteiro positivo.");
            return;
        }

        if (EhFibonacci(numero))
            Console.WriteLine($"{numero} pertence à sequência de Fibonacci.");
        else
            Console.WriteLine($"{numero} NÃO pertence à sequência de Fibonacci.");
    }

    static bool EhFibonacci(int num)
    {
        // Usando a fórmula matemática para verificar se o número é Fibonacci
        return (EhQuadradoPerfeito(5 * num * num + 4) || EhQuadradoPerfeito(5 * num * num - 4));
    }

    static bool EhQuadradoPerfeito(int n)
    {
        int raiz = (int)Math.Sqrt(n);
        return raiz * raiz == n;
    }
}
