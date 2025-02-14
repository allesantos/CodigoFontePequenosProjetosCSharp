using System;

class Program
{
    static void Main()
    {
        Console.Write("Digite uma string para inverter: ");
        string? input = Console.ReadLine();
        if (input == null)
        {
            Console.WriteLine("Nenhuma entrada fornecida.");
            return;
        }
        
        char[] inverted = new char[input.Length];
        int j = 0;
        
        for (int i = input.Length - 1; i >= 0; i--)
        {
            inverted[j] = input[i];
            j++;
        }
        
        string resultado = new string(inverted);
        Console.WriteLine("String invertida: " + resultado);
    }
}
