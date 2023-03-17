namespace Softblue_06_Exercicio;

class Program
{
    public static void Main(string[] args)
    {
        List<int> listaInteiros = new List<int>(){2,4,5,6,1,0,20,25,25,3,45};
        Predicate<int> validatorPredi = (indice) => indice >= 5;
            
        // Exibindo somente os Elementos igual ou maior que 5
        Count(listaInteiros, validatorPredi).ForEach(x => Console.WriteLine(x));
    }
    static List<int> Count(List<int> list, Predicate<int> validator)
    {
        List<int> newList = new List<int>();
        
        foreach (int index in list)
        {
            if (validator(index))
            {
              newList.Add(index);
            }
        }
        return newList;
    }
}

