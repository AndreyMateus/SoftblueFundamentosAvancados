namespace SoftblueFundamentosAvancados_06_Delegates_Genericos_Action_e_Func;

class Program
{
    public static void Main(string[] args)
    {
        Temperatura temperatura = new Temperatura();

        // Com Delegate e GENERICS
        Func<double,double> ConversorParaCelsius = temperatura.ParaCelsius;
        Func<double,double> ConversorParaFahrenheint = temperatura.ParaFahrenheint;

        Action<double> PrintConversorParaCelsius = temperatura.PrintCelsius ;
        PrintConversorParaCelsius(ConversorParaCelsius(80));

        Action<double> PrintConversorFahrenheint = temperatura.PrintFahrenheint;
        PrintConversorFahrenheint(ConversorParaFahrenheint(20));

        // Com Delegate, mas SEM GENERICS
        //double valorConvertidoCelsius = ConversorParaCelsius(90);
        //double valorConvertidoFahrenheint = ConversorParaFahrenheint(25);
        //Console.WriteLine(valorConvertidoCelsius);
        //Console.WriteLine(valorConvertidoFahrenheint);


        // Sem Delegate
        //double celsius = temperatura.ParaCelsius(90);
        //double fahrenheint = temperatura.ParaFahrenheint(205);
        //Console.WriteLine(celsius);
        //Console.WriteLine(fahrenheint);

    }
}

// Tipo de Delegate NÃO genérico
//public delegate double TemperaturaConversorHandler(double valor);

class Temperatura
{
    public double ParaFahrenheint(double celcius)
    {
        return ((celcius * 9) /  5) + 32;
    }

    public double ParaCelsius(double fahrenheint)
    {
        return ((fahrenheint - 32) * 5) / 9;
    }

    public void PrintFahrenheint(double valor)
    {
        Console.WriteLine($"Temperatura em fahrenheint é {valor}");
    }
    public void PrintCelsius(double valor)
    {
        Console.WriteLine($"Temperatura em Celsius é: {valor}");
    }
}

