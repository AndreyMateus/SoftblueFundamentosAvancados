namespace Softblue_01_Exercicio;

class Program
{
    public static void Main(string[] args)
    {
        Vector v1 = new Vector(2,3);
        Vector v2 = new Vector(4,5);

        Vector v3 = v1 + v2;
        Vector v4 = v3 * 3;
        Console.WriteLine(v4.x);
        Console.WriteLine(v4.y);
        
        // Testando o Casting
        string stringVetor = (string)v4;
        Console.WriteLine(stringVetor);
        
        // Exercício 2
        Vector vector = new Vector();
        vector['X'] = 5;
        vector['Y'] = 7;

        int x = vector['X'];
        Console.WriteLine(x);
        
        int y = vector['Y'];
        Console.WriteLine(y);
    }
}
public struct Vector
{
    public int x;
    public int y;
    public Vector(int x, int y) : this()
    {
        this.x = x;
        this.y = y;
    }
    // Sobreescrevendo os operadores "+" e "*"
    public static Vector operator +(Vector v1, Vector v2)
    {
        return new Vector(v1.x + v2.x, v1.y + v2.y);
    }
    public static Vector operator *(Vector v1, int i)
    {
        return new Vector(v1.x * i, v1.y * i );
    }
    
    // Fazendo um Casting Personalizado
    public static implicit operator string(Vector v1)
    {
        return string.Format("X: {0}, Y: {1}",v1.x,v1.y);
    }
    
    
    // Criando um Indexador
    public int this[char c]
    {
        get
        {
            if (c == 'X')
            {
                return this.x;
            }
            if (c == 'Y')
            {
                return this.y;
            }
            return -1;
        }
        set
        {
            if (c == 'X')
            {
                this.x = value;
            }
            else if (c == 'Y')
            {
                this.y = value;
            }
        }
    }
}