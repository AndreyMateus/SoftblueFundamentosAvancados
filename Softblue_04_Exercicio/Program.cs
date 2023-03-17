namespace Softblue_04_Exercicio;

class Program
{
    public static void Main(string[] args)
    {
        List<int> lista = new List<int>() {3, 7, 2, 4, 6};

        Converter<int,double> conversor = x => (double)x/ 2;
        List<double> listaDivid = lista.ConvertAll(conversor);
        
        listaDivid.ForEach((double x) => Console.WriteLine(x));





    }
}