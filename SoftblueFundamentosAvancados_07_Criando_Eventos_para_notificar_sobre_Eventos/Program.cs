namespace SoftblueFundamentosAvancados_07_Criando_Eventos_para_notificar_sobre_Eventos;

class Program
{
    public static void Main()
    {
        // Os EVENTS no c# representam EVENTOS que podem ser NOTIFICADOS a PESSOAS/CLASSES INTERESSADAS
        // Events não funcionam sem DELEGATES

        NumberGenerator ng = new NumberGenerator();
        //ng.AddCallback(NumberGeneratored); // Sem eventos
        //ng.Ongenerated += NgOnOngenerated; // Com Eventos

        // Com Eventos NO PADRÃO MICROSOFT
        ng.Ongenerated += NgOnOngenerated;
        
        // Gerar um número É UM EVENTO
        ng.Start();

    }
    // Eventos com PADRÃO MICROSOFT
    public static void NgOnOngenerated(Object sender, NumberEverntArgs args)
    {
        NumberGenerator ngg = (NumberGenerator)sender;
      
        Console.WriteLine($"Número Generado -> {args.Number}");
    }
    
    // Com Eventos
    // private static void NgOnOngenerated(int n)
    // {
    //     Console.WriteLine($"Número Generado -> {n}");
    // }

    // Com Delegates
    // public static void NumberGeneratored(int n)
    // {
    //     Console.WriteLine($"Número Generado -> {n}");
    // }
}

// Criando o TIPO do delegate
// Um Evento precisa de um delegate para funcionar
// o Sufixo HANDLER no nome dos delegates, é comum quando se vai usar com EVENTS/EVENTOS
//public delegate void NumberHandler(int n);

// Events no PADRÃO MICROSOFT
public delegate void NumberHandler(Object sender, NumberEverntArgs eventArgs);

public delegate void OnNumber(int n);

class NumberGenerator
{
    private Random r = new Random();
    
    // Um Evento já é público e já registra o interesse
    // Um Evento é feito para ser PÚBLICO, então não se preocupe com expor eventos públicamente.
    // O TIPO do evento é o MESMO do delegate
    public event NumberHandler Ongenerated;
    
    // Criando uma variável do TIPO do delegate
    public OnNumber callback;
    public void Start()
    {
        while (true)
        {
            int n = r.Next(100);
            // Verifico se o EVENTO NÃO é NULO, pois ninguém pode ter registrado interesse.
            if ( Ongenerated != null)
            {
               // Ongenerated(n);
               
               // Padrão EVENTS dá Microsoft
               NumberEverntArgs args = new NumberEverntArgs() { Number = n};
               Ongenerated(this,args);// o This faz referência a própria instância da classe, ou seja: ao próprio objeto que faz a ação.
            }
            
            //callback(n);
            Thread.Sleep(2000);
        }
    }

    // Usando Events eu não preciso de um método para registrar mais um método na Callback
    // public void AddCallback(OnNumber newDelegate)
    // {
    //     callback += newDelegate;
    // }
    
}

// Eventos com o Padrão da Microsoft

// O Evento/Ação deve ser filho/herdar da classe EventArgs
public class NumberEverntArgs : EventArgs
{
    // Essa Prop Number representa o Número Random Gerado
    public int Number { get; set; }
}