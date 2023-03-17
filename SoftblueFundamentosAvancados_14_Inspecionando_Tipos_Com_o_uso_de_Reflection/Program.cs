using System.Reflection;

namespace SoftblueFundamentosAvancados_14_Inspecionando_Tipos_Com_o_uso_de_Reflection;

class Program
{
    public static void Main(string[] args)
    { 
        Console.WriteLine("Digite o Nome Completo da Classe(FULL QUALIFIED NAME)");
        // Exemplo: FULL QUALIFIED NAME => System.String
        string className = Console.ReadLine();

        Type type = Type.GetType(className);

        PropertyInfo[] arrayProps =  type.GetProperties();
        foreach (PropertyInfo index in arrayProps)
        {
            Console.WriteLine($"{index.Name} => {index.PropertyType}");
        }

        // Se o Método não existir, o valor de retorno será NULL
        // Se existir, eu armazenarei o MÉTODO dentro de uma variável do TIPO MethodInfo
        MethodInfo methodInfo = type.GetMethod("Init");
        
        if (methodInfo != null)
        {
            Object objectReturn = Activator.CreateInstance(type);
            // Aqui nós precisamos passar o Objeto do TIPO que contém o método
            // O parâmetro NULL é no caso do método passado não conter parâmetros
            methodInfo.Invoke(objectReturn,null);
        }
        else
        {
            Console.WriteLine("O Método não pode ser encontrado !");
        }

    }
}

class MyClass
{
    public int Idade { get; set; }

    public void Init()
    {
        Console.WriteLine("O método Init foi executado");
    }
}