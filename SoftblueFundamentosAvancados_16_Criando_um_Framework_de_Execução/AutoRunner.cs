// Import para usar o Reflection

using System.Diagnostics;
using System.Reflection;

namespace SoftblueFundamentosAvancados_16_Criando_um_Framework_de_Execução;

public static class AutoRunner
{
    public static List<Result> Run()
    {
        // Pegando a informação do ASSEMBLY/PROJETO que CHAMOU/EXECUTOU este método
        Assembly assembly = Assembly.GetCallingAssembly();
        
        // Retornando os TIPOS em um array de TYPE
        Type[] typesInAssembly = assembly.GetTypes();

        // Lista para guardar os resultados
        List<Result> listResultReturn = new List<Result>();
        
        // Stopwatch é um TIPO crômetro, ele deixa com que você o INICIE ele quando ALGO é INICIADO e após o TERMINO da EXECUÇÃO você PARA ele.
        Stopwatch stopwatch = new Stopwatch();
        
        foreach (Type type in typesInAssembly)
        {
            // Pegando somente as CLASSES/TIPOS dos TYPES que contém o ATTRIBUTE
            if (type.GetCustomAttribute<RunClassAttribute>() != null)
            {
                MethodInfo[] methodInfos = type.GetMethods();
                foreach (MethodInfo method in methodInfos)
                {
                    // Pegando somente os Métodos que contém o ATTRIBUTE 
                    // E verificando se o método é STATIC
                    if (method.GetCustomAttribute<RunMethodAttribute>() != null && method.IsStatic)
                    {
                        stopwatch.Start();
                        // Como o objeto é estático, eu passo NULL como primeiro parâmetro, pois nenhum objeto o chama, ele se auto executa sem precisar de uma instância, isso por ser STATIC, e como não tem parâmetros, eu também passo NULL como segundo parâmetro
                        method.Invoke(null,null);
                        stopwatch.Stop();
                        listResultReturn.Add(new Result(type,method,stopwatch.Elapsed));
                        stopwatch.Reset();
                    }
                }
            }
            
        }
        // Retornando a lista com os  Result contendo o TYPE da CLASS, o TYPE do MÉTODO e o TEMPO de EXECUÇÃO DO MÉTODO EXECUTADO.
        return listResultReturn;
    }
    
}