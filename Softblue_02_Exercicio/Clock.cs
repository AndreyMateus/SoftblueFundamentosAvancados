namespace Softblue_02_Exercicio;

public class Clock
{
    public delegate void Secondshandler(long second);
    //public Secondshandler callback;
    
    // Events
    public event EventHandler<SecondElapsedEventArgs> EventSecond; // O próprio parâmetro já está inserido IMPLICITAMENTE o próprio objeto, além do EVENTO. 
    
    private SecondElapsedEventArgs secondElapsedEventArgs = new SecondElapsedEventArgs();
    private long seconds;
    public void Start()
    {
        while (true)
        {
            if (EventSecond != null)
            {
                secondElapsedEventArgs.Seconds = seconds++;
                EventSecond(this, secondElapsedEventArgs);
                //callback(seconds);
            }
            Thread.Sleep(1000);
        }
    }
}

// Transformando a AÇÃO em um EVENTO
public class SecondElapsedEventArgs : EventArgs
{ 
   public long Seconds { get; set; }    
}

