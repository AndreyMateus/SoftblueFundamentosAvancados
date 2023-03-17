namespace SoftblueFundamentosAvancados_13_Aula_Usando_Um_Assembly_Compartilhado;

class Program
{
    public static void Main(string[] args)
    {
      // Se o Projeto com a DLL na qual você quer adicionar a REFERÊNCIA, não estiver na mesma SOLUTION/SOLUÇÃO, você tem que ir Até o GAC é procurar a DLL lá.

      string result = SoftblueFundamentosAvancados_12_Aula_Criando_Um_Assembly_Compartilhado.StringUtils.Capitalize("c#");// Esse método converte a string em Upper Case
      Console.WriteLine(result);


    }
}