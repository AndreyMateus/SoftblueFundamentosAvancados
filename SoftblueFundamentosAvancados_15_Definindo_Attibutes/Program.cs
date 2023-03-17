using System.Reflection;

namespace SoftblueFundamentosAvancados_15_Definindo_Attibutes;

class Program
{
    public static void Main(string[] args)
    {
        // NÃO SE ESQUEÇA QUE USAMOS "REFLECTION" PARA MANIPULAR OS ATTRIBUTES
        
        // Acessando o ASSEMBLY que está rodando nesse EXATO MOMENTO.
        Assembly assembly = Assembly.GetExecutingAssembly();
        
        // Armazenando todos os TIPOS utlizados no Assembly
        Type[] types = assembly.GetTypes();

        foreach (Type type in types)
        {
            // Retornando TODOS os atributos do TIPO Message, se o TIPO do Atributo não existir, será RETORNADO NULL
            // MessageAttribute attr = (MessageAttribute)type.GetCustomAttribute(typeof(MessageAttribute));
            
            // Outra forma mais fácil de pegar todos os Atributos de Determinado tipo é:
            MessageAttribute attr = type.GetCustomAttribute<MessageAttribute>();
            if (attr != null)
            {
                // Exbiindo a mensagem que vai ter no ATTRIBUTE [Message]
                Console.WriteLine($" Nome da Classe: {type.FullName}, Mensagem do Attribute: {attr.Value}");
            }
        }
        
    }
}

// É uma boa prática utilizar o SEALED para a classe não ser herdada, e também o SUFIXO Attribute após o nome da classe que será o nome do atributo.     
[AttributeUsage(AttributeTargets.Class)]// Atribuindo um Atributo na Classe MessageAttribute, para que ele só possa ser utilizado em Classe.
public sealed class MessageAttribute : Attribute // Um Atributo nada mais é que uma informação a mais para determinado elemento, porém é importante que alguém o use. 
{
    public string Value { get; set; }
}

// Você pode OMITIR o SUFIXO ATTRIBUTE SOMENTE NA UTILIZAÇÃO DO ATRIBUTO, mas isso é opcinal.
[Message(Value = "Mensagem aqui")]
class A
{
    
}

[Message(Value = "Mensagem para a outra classe")]
class B
{
    
}