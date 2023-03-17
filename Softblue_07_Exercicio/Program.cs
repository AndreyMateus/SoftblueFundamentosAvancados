using System.Reflection;
using System.Runtime.InteropServices.JavaScript;

namespace Softblue_07_Exercicio;

/*
 * Crie uma aplicação que faça o seguinte:
    1) Solicite ao usuário um nome de uma classe.
    
    2) Liste os métodos dessa classe que não são sejam estáticos, públicos, e que tenham 0 parâmetros ou 1 ou mais parâmetros do tipo string.
    
    3) Peça para que o usuário escolha um método da lista para executar.
    
    4) Solicite ao usuário o valor para cada um dos parâmetros a serem fornecidos ao método,caso existam.
    
    5) Crie um objeto da classe escolhida (chamando o construtor padrão, sem parâmetros).
    
    6) Chame o método escolhido pelo usuário com os valores de parâmetros fornecidos pelo
    usuário no objeto recém-criado.
    
    7) Mostre na tela as informações impressas pelo método.
    
    Para testar o funcionamento da aplicação, crie uma classe qualquer com alguns métodos que atendem os requisitos anteriormente descritos e faça chamadas a estes métodos.
    
    Dica: Métodos como GetMethods() e GetParameters() podem ser utilizados para obter as
    informações a respeito de métodos e parâmetros. Consulte a documentação do C# para obter
    mais detalhes.
 */
class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Digite o Nome da Classe: (FULL QUALIFIED NAME) ");
        string nameClass = Console.ReadLine();

        // Transformando o INPUT em TYPE para manipular
        Type typeClass = Type.GetType(nameClass);

        // Pegando os métodos do TYPE 
        // Retornará uma Matriz/Array vazio se não tiver métodos
        MethodInfo[] methodInfos = typeClass.GetMethods();

        // Lista com os os Métodos que serão a opção do Menu
        List<MethodInfo> listTypeMethodsReturned = new List<MethodInfo>();

        for (int m = 0; m < methodInfos.Length; m++)
        {
            // O método não pode ser Estático E Público
            if (!(methodInfos[m].IsStatic && methodInfos[m].IsPublic))
            {
                // Pegando os parâmetros de cada método  a cada ITERAÇÃO
                // E Validando se o Método chamado TEM parâmetros
                if (methodInfos[m].GetParameters().Length > 0)
                {
                    for (int i = 0; i < methodInfos[m].GetParameters().Length; i++)
                    {
                        // Validando se os parâmetros são do TIPO STRING
                        if ((methodInfos[m].GetParameters()[i].ParameterType == Type.GetType("System.String")))
                        {
                            // Verificando se eu já tenho o Método dentro da Lista
                            if (!listTypeMethodsReturned.Contains(methodInfos[m]))
                            {
                                listTypeMethodsReturned.Add(methodInfos[m]);
                            }
                        }
                    }
                }

                // Método que não possuem parâmetro, IDEPENDENTE DO TIPO
                else if (methodInfos[m].GetParameters().Length == 0)
                {
                    // Verificando se eu já tenho o Método dentro da Lista
                    if (!listTypeMethodsReturned.Contains(methodInfos[m]))
                    {
                        listTypeMethodsReturned.Add(methodInfos[m]);
                    }
                }
            }
        }

        // todo: Transformar essa parte em função se der
        Console.WriteLine("ESCOLHA UM MÉTODO: ");
        Console.WriteLine("-------------------------------------------");
        // Exibindo os métodos da lista
        for (int j = 0; j < listTypeMethodsReturned.Count(); j++)
        {
            Console.WriteLine($"ASSINATURA: {listTypeMethodsReturned[j]}");
            Console.WriteLine($"Opção:[{j}] - Nome: {listTypeMethodsReturned[j].Name}");
            Console.WriteLine("-------------------------------------------");
        }

        // Verificando se a lista com os métodos de determinado TIPO não é vazia
        if (listTypeMethodsReturned.Count != 0)
        {
            // Pegando o número/posição de qual método do tipo será executado, baseando-se na posição/índice da lista.
            int optionList = int.Parse(Console.ReadLine());

            // Verificando o método verificado não é nulo, Se uma opção foi escolhida.
            if (listTypeMethodsReturned[optionList] != null)
            {
                #region NoParams

                // Validando para que os métodos aqui NÃO TENHAM PARÂMETRO ALGUM
                if (listTypeMethodsReturned[optionList].GetParameters().Length == 0)
                {
                    /*
                     *  ----------------OBSERVAÇÃO--------------
                     * Aqui eu precisei criar um IF para caso o tipo SEJA VOID, pois assim eu não precisarei retornar, apenas executar.
                     *
                     * E Também crie a VERSÃO caso seja um OUTRO TIPO assim PRECISAREI RETORNAR O VALOR
                     */

                    // Caso seja do tipo VOID e não tenha parâmetros somente irá executar 
                    if (listTypeMethodsReturned[optionList].ReturnType == Type.GetType("System.Void"))
                    {
                        Object newClassInstance = Activator.CreateInstance(typeClass);
                        listTypeMethodsReturned[optionList].Invoke(newClassInstance, null);
                    }

                    // Caso NÃO SEJA VOID E NÃO tenha parâmetros, irá retornar o valor
                    if (listTypeMethodsReturned[optionList].ReturnType != Type.GetType("System.Void"))
                    {
                        // Criando um objeto para usar o método escolhido, a partir do mesmo objeto.
                        Object newClassInstance = Activator.CreateInstance(typeClass);

                        // Usando o Método a partir do OBJETO criado
                        Console.WriteLine(listTypeMethodsReturned[optionList].Invoke(typeClass, null));
                    }
                }

                #endregion NoParams

                #region HaveParams

                // Caso tenha parâmetros
                else if (listTypeMethodsReturned[optionList].GetParameters().Length > 0)
                {
                    ParameterInfo[] parametersMandatory = listTypeMethodsReturned[optionList].GetParameters();
                    for (int i = 0; i < listTypeMethodsReturned[optionList].GetParameters().Length; i++)
                    {
                        Console.WriteLine(
                            $"Params Type: {listTypeMethodsReturned[optionList].GetParameters()[i].ParameterType}");
                    }

                    // Pegando valor de INPUT de parâmetro pelo usuário
                    Console.WriteLine("Agora Digite os parâmetros de acordo com a ordem de TIPOS mostrada");
                    Object[] typesParams = new Object[parametersMandatory.Length];
                    for (int i = 0; i < parametersMandatory.Length; i++)
                    {
                        Console.Write("Digite o valor do parametro: ");
                        typesParams[i] = Console.ReadLine();
                    }

                    // Se o TIPO NÃO tem retorno e TEM PARÂMETRO
                    if (listTypeMethodsReturned[optionList].ReturnType == Type.GetType("System.Void"))
                    {
                        Object newClassInstance = Activator.CreateInstance(typeClass);
                        listTypeMethodsReturned[optionList].Invoke(newClassInstance, typesParams);
                    }

                    // Se o TIPO TEM retorno e TEM PARÂMETRO
                    else if (listTypeMethodsReturned[optionList].ReturnType != Type.GetType("System.Void"))
                    {
                        Object newClassInstance = Activator.CreateInstance(typeClass);
                        Console.WriteLine(listTypeMethodsReturned[optionList].Invoke(newClassInstance, typesParams));
                    }
                }

                #endregion HaveParams
            }
        }
    }
}

// Classe para Teste da aplicação
public class Teste
{
    public string MetodoRetornoComParam(string nome)
    {
        return $"Seu nome é: {nome}";
    }

    public string MetodoRetornoSemParam()
    {
        return "Fui Executado e retornei o valor  e executei, não possui params";
    }

    public void MetodoVazioSemParametro()
    {
        Console.WriteLine("Fui Executado e não tenho parâmetro");
    }

    public void MetodoVazioComParametro(string nome)
    {
        Console.WriteLine($"Fui Executado e o texto digitado é: {nome}");
    }
}