namespace  SoftblueFundamentosAvancados_09_Aula_Definindo_Expressões_Lambda;

class Program
{
    public static void Main(string[] args)
    {
        // Se quiser ESPECIFICAR o TIPO dos parâmetro é OBRIGATÓRIO o uso dos PARÊNTESES, porém normalmente ela não é muito utilizada.
        // Quando você tem apenas uma INSTRUÇÃO o RETURN é implicito, então ele retornará automaticamente.
        List<int> l = BuildList(1, 100,x => x * 2 );
        
        foreach (int i in l)
        {
            Console.WriteLine(i);
        }
        
    }

    static List<int> BuildList(int start, int end, ItemHandler handler)
    {
        List<int> l = new List<int>();
        l.Add(start);
        int n = handler(start);
        
        while ( n <= end)
        {
            l.Add(n);
            n = handler(n);
        }
        return l;
    }
    
}
delegate int ItemHandler(int number);