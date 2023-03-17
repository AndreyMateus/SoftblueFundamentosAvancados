namespace Softblue_02_Exercicio;

class Program
{
    public static void Main(string[] args)
    {
        Clock ck = new Clock();
        //ck.callback += OnSecond;
        ck.EventSecond += CkOnEventSecond;
        
        ck.Start();
    }
    public static void CkOnEventSecond(object sender, SecondElapsedEventArgs secondElapsedEvent)
    {
        Console.WriteLine($"{secondElapsedEvent.Seconds}");
    }

    public static void OnSecond(long second)
    {
        Console.WriteLine($"{second}");
    }
}