namespace SoftblueFundamentosAvancados_05_Callback_através_de_Delegates;

class Program
{
    public static void Main(string[] args)
    {
        // O Objetivo é notificar a classe Carro toda vez que o Semáforo mudar de cor.

        // Carro carro1 = new Carro(1);
        // Carro carro2 = new Carro(2);
        // Carro carro3 = new Carro(3);
        Semaforo semaforo = new Semaforo();
        
        //s.AdicionarCallback(new SemaforoHandler(carro.SemaforoAlterado));
        // OU
        // semaforo.AdicionarCallback(carro1.SemaforoAlterado);
        // semaforo.AdicionarCallback(carro2.SemaforoAlterado);
        // semaforo.AdicionarCallback(carro3.SemaforoAlterado);
        // semaforo.Iniciar();

        
        // Também podemos fazer isso d euma forma mais dinâmica
        for (int i = 0; i < 3; i++)
        {
            Carro c = new Carro(i);
            semaforo.AdicionarCallback(c.SemaforoAlterado);
        }
        semaforo.Iniciar();
        
    }
}

enum Cor
{
    VERDE,
    VERMELHO,
    AMARELO,
}

// Criando o TIPO do delegate.
// Lembre-se que internamente o delegate cria uma Classe.
delegate void SemaforoHandler(Cor cor);

class Semaforo
{
     private Cor cor =  Cor.VERMELHO;
     private SemaforoHandler callback;
     
     public void Iniciar()
     {
         while (true)
         {
             if (cor == Cor.VERMELHO)
             {
                 cor = Cor.VERDE;
             }
             else if (cor == Cor.VERDE)
             {
                 cor = Cor.AMARELO;
             }
             else if (cor == Cor.AMARELO)
             {
                 cor = Cor.VERMELHO;
             }
             Console.WriteLine($"Semáforo mudou para {cor}");
             
             // Passando o valor para a callback
             callback(cor);
             
             Thread.Sleep(2000);
         }
     }

     public void AdicionarCallback(SemaforoHandler handler)
     {
         this.callback += handler ;
     }
     
}

class Carro
{
    private int id;

    public Carro(int id)
    {
        this.id = id;
    }

    // O tipo desse método tem que ser do mesmo TIPO/ASSINATURA do Delegate
    // Esse é o método que tem que ser chamado se uma COR for passada pela Callback.
    public void SemaforoAlterado(Cor cor)
    {
        Console.WriteLine($"Carro id: {id} notificado, cor: {cor}");
    }
    
}

