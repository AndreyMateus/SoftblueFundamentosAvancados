namespace Softblue_03_Exercicio;

public delegate bool Filter(int numero);
class Program
{
    public static void Main(string[] args)
    {
        List<int> lista = new List<int>() {0,1,2,3,4,5,6,7,8,9,10};
        FilterList(lista, Filter);
        
        List<int> newList1 = FilterGreatedThan5(lista);
        List<int> newList2 =FilterOdd(lista);

     newList1.ForEach( a=> Console.WriteLine(a));
     newList2.ForEach( a=> Console.WriteLine(a));

    }

    public static bool Filter(int numero)
    {
        return true;
    }

    public static List<int> FilterList(List<int> listInt, Filter filter)
    {
        List<int> newList = new List<int>();
        for (int i = 0; i < listInt.Count; i++)
        {
            if (filter != null)
            {
                if (filter(i) == true)
                {
                    newList.Add(i);
                }
            }
        }
        return newList;
    }

    public static List<int> FilterGreatedThan5(List<int> listNumber)
    {
        List<int> newList = new List<int>();
        for (int i = 0; i < listNumber.Count; i++)
        {
            if (i > 5)
            {
                newList.Add(i);
            }
        }
        return newList;
    }

    public static List<int> FilterOdd(List<int> listNumber)
    {
        List<int> newList = new List<int>();
        for (int i = 0; i < listNumber.Count; i++)
        {
            if (i%2 != 0)
            {
                newList.Add(i);
            }
        }
        return newList;
    }
}
