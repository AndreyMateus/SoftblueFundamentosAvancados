namespace SoftblueFundamentosAvancados_10_Aula_Closures_Em_Expressões_Lambda;

class Program
{
    public static void Main(string[] args)
    {
        // Uma expressão LAMBDA pode acessar VARIÁVEIS de FORA DELA, isso se chama CLOSURE
        // Expressão LAMBDA NÃO ARMAZENA VALOR DE VARIÁVEL, MAS SIM O ENDEREÇO DA VARIÁVEL REAL NA MEMÓRIA.
        
        int x = 10;
        
        // a Expressão LAMBDA tem que estar Assimilada a um DELEGATE
        // A Expressão LAMBDA não ARMAZENA o VALOR DA VARIÁVEL, MAS SIM O "ENDEREÇO" EM TEMPO REAL DE ONDE ESSA VARIÁVEL ESTA, Como se fosse um OBJETO, isso quer dizer que se você alterar a variável depois, irá alterar para todos, como se a variável fosse STATIC.
        Action a = () => Console.WriteLine(x);
        x = 5;
        a();

        // Criando um Array de Lamba
        Action[] actions = new Action[5];
        for (int i = 0; i < 5; i++)
        {
            int j = i; // Criando uma nova variável a cada loop, isso faz com que cada cada expressão referencie uma variável J diferente em cada espaço da memória diferente, se não fizermos isso, a expressão irá apontar para a mesma variável i, fazendo com que todos os "i" tenham o mesmo valor, pois a expressão salva o endereço da variável e não o valor, então ela sempre puxa a variável REAL na memória.
            actions[i] = () => Console.WriteLine(j);
        }

        // Executando as Lambda de dentro do array
        foreach (Action action in actions)
        {
            action();
        }

       
    }
   
}