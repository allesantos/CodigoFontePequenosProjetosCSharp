using System;
using System.IO;
using Newtonsoft.Json.Linq;

class Program
{
    static void Main()
    {
        var baseDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory);
        if (baseDirectory == null || baseDirectory.Parent == null || baseDirectory.Parent.Parent == null)
        {
            Console.WriteLine("Caminho do diretório inválido.");
            return;
        }
        var parentDirectory = baseDirectory.Parent?.Parent?.Parent;
        if (parentDirectory == null)
        {
            Console.WriteLine("Caminho do diretório inválido.");
            return;
        }
        string jsonFile = Path.Combine(parentDirectory.FullName, "faturamento.json");

        if (!File.Exists(jsonFile))
        {
            Console.WriteLine("Arquivo JSON não encontrado.");
            return;
        }

        string jsonData = File.ReadAllText(jsonFile);
        JArray faturamentoArray = JArray.Parse(jsonData);
        
        double menor = double.MaxValue, maior = double.MinValue, soma = 0;
        int diasValidos = 0, diasAcimaMedia = 0;

        foreach (var item in faturamentoArray)
        {
            var valorToken = item["valor"];
            if (valorToken != null)
            {
                double valor = (double)valorToken;
                if (valor > 0)
                {
                    if (valor < menor) menor = valor;
                    if (valor > maior) maior = valor;
                    soma += valor;
                    diasValidos++;
                }
            }
        }

        double media = soma / diasValidos;
        foreach (var item in faturamentoArray)
        {
            var valorToken = item["valor"];
            if (valorToken != null)
            {
                double valor = (double)valorToken;
                if (valor > media)
                {
                    diasAcimaMedia++;
                }
            }
        }

        Console.WriteLine($"Menor faturamento: {menor:F2}");
        Console.WriteLine($"Maior faturamento: {maior:F2}");
        Console.WriteLine($"Dias acima da média: {diasAcimaMedia}");
    }
}
