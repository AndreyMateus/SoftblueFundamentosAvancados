// Importando a DLL/Assembly após referenciá-lo
using SoftblueFundamentosAvancados_16_Criando_um_Framework_de_Execução;

namespace SoftblueFundamentosAvancados_15_Criando_um_Framework_de_Execução;

[RunClass]
public class A
{
    // O método será STATIC apenas para facilitar na hora de serem executados, assim eu não precisarei instanciar um Objeto da classe para executar o método.
    [RunMethod]
    public static void Execute()
    {
        Console.WriteLine("A.Execute();");
        
        // Sleep apenas para simular que um método demorou mais que o outro
        Thread.Sleep(1000);
    }
}

[RunClass]
public class B
{
    // O método será STATIC apenas para facilitar na hora de serem executados, assim eu não precisarei instanciar um Objeto da classe para executar o método.
    [RunMethod]
    public static void Start()
    {
        Console.WriteLine("B.Start();");
        
        // Sleep apenas para simular que um método demorou mais que o outro
        Thread.Sleep(2000);
    }
}