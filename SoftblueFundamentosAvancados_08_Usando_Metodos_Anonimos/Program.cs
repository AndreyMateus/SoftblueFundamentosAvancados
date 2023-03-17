using System.ComponentModel;

namespace SoftblueFundamentosAvancados_08_Usando_Metodos_Anonimos;

class Program
{
    public static void Main(string[] args)
    {
        Numbergenerator numbergenerator = new Numbergenerator();
       
        // Método Anônimo
        numbergenerator.callback += delegate(object sender, NumberEventargs eventargs)
        {
            Console.WriteLine($"{eventargs.Number}");
        };
        numbergenerator.Start();
    }
}

class Numbergenerator
{
    public event EventHandler<NumberEventargs> callback;
    private Random random = new Random();
    
    public void Start()
    {
        while (true)
        {
            if (callback != null)
            {
                callback(this, new NumberEventargs(){ Number =random.Next(100)});
            }
            Thread.Sleep(1000);
        }
    }
}
public class NumberEventargs : EventArgs
{
    public int Number { get; set; }
}
