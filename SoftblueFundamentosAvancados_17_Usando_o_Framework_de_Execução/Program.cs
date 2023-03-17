using System.Reflection;
// Importando a DLL/Assembly após referenciá-lo
using SoftblueFundamentosAvancados_16_Criando_um_Framework_de_Execução;

namespace SoftblueFundamentosAvancados_15_Criando_um_Framework_de_Execução;

class Program
{
    public static void Main(string[] args)
    {
        // Criando um framework simples para a auto-execução de métodos, assim exercitaremos os conceitos de REFLECTION e ATTRIBUTES
        
        // Lembrando que REFLECTION é poder Gerenciar os TIPOS do ASSEMBLY que está em execução, e ATTRIBUTES são INFORMAÇÕES ADICIONAIS que você dá a algum ELEMENTO em seu código.
        
        // Executando todos os métodos
       List<Result> newListReturned = AutoRunner.Run();
       
       // Percorrendo a nova lista e Exbindo o Result que possuis as Propriedades de Tempo de Execução, Nome da Classe onde se encontrá os métodos executados, e o nome dos métodos executados.
       foreach (Result result in newListReturned)
       {
           Console.WriteLine(result);
       }
       
    }
}