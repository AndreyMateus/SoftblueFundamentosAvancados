namespace SoftblueFundamentosAvancados_02_Sobrecarregando_Operadores;

class Program
{
    public static void Main(string[] args)
    {
        Fracao f1 = new Fracao(3,2);
        Fracao f2 = new Fracao(6,4);

        // Usando a Sobreescrita
        Fracao f3 = f1 * f2;
        Console.WriteLine(f3);
        
        // Usando a Sobrecarga da Sobreescrita
        Fracao f4 = f1 * 5;
        Console.WriteLine(f4);
        
        // Testando outros Operadores
        bool b1 = f1 > f2;
        Console.WriteLine(b1);
        
        bool b2 = f1 < f2;
        Console.WriteLine(b2);
        
        bool b3 = f1.Equals(f2);
        Console.WriteLine(b3);

        bool b4 = f1 == f2;
        Console.WriteLine(b4);
    }
}
class Fracao : IEquatable<Fracao>
{
    public int Numerador { get; set; }
    public int Denominador { get; set; }

    // Propertie ReadOnly
    public  double Resultado
    {
        get
        {
            return (double)Numerador / Denominador;
        }
    }
    
    public Fracao(int numerador, int denominador)
    {
        Numerador = numerador;
        Denominador = denominador;
    }

    public override string ToString()
    {
        return string.Format("{0:d}/{1:d}",Numerador,Denominador);
    }

    // Sobreescrita do OPERADOR * 
    // Toda sobrecarga de Operador tem que ser PUBLIC e STATIC, é uma regra do C#.
    public static Fracao operator * (Fracao f1, Fracao f2)
    {
        return new Fracao(f1.Numerador * f2.Numerador, f1.Denominador * f2.Denominador);
    }
    
    // Sobrecarga da Sobreescrita
    public static Fracao operator * (Fracao f, int i)
    {
        // O denominador ser somente ele próprio é a regra dessa fórmula
        return new Fracao(f.Numerador * 2,f.Denominador);
    }

    
    public static bool operator < (Fracao f1, Fracao f2)
    {
        return f1.Resultado < f2.Resultado;
    }
    public static bool operator >(Fracao f1, Fracao f2)
    {
        return f1.Resultado > f2.Resultado;
    }

    public static bool operator >= (Fracao f1, Fracao f2)
    {
        return f1.Resultado >= f2.Resultado;
    }

    public static bool operator <= (Fracao f1, Fracao f2)
    {
        return f1.Resultado <= f2.Resultado;
    }

    public static bool operator == (Fracao f1, Fracao f2)
    {
        return f1.Resultado == f2.Resultado;
    }
    public static bool operator != (Fracao f1, Fracao f2)
    {
        return f1.Resultado != f2.Resultado;
    }
    
    
    // A segunda forma de implementarmos UMA FORMA de COMPARAR OBJETO e dizer se são IGUAIS é com a IEquatable<T>
    public bool Equals(Fracao fracao)
    {
        if (fracao is null)
        {
            throw new NullReferenceException("O parâmetro não pode ser nulo");
        }
        return this.Resultado.Equals(fracao.Resultado);
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Fracao);
    }
    // Se sobreescrever o Equals, temos que sobreescrever o GetHashCode()
    public override int GetHashCode()
    {
        return Resultado.GetHashCode();
    }
}