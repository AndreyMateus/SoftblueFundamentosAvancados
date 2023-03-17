namespace Softblue_05_Exercicio;

class Program
{
    public static void Main(string[] args)
    {
        Pessoa pessoa = new Pessoa();
        pessoa.Altura = 1.70;
        pessoa.Peso = 95.00;
        double pesoIMC = pessoa.CalcularImc((peso,altura) => peso / (altura * altura));
       
        Console.WriteLine($"IMC: {pesoIMC:F1}");
    }
}