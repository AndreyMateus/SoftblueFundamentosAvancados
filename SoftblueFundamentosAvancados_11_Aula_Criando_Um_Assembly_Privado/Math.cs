namespace SoftblueFundamentosAvancados_11_Aula_Criando_Um_Assembly_Privado;

// Criando um Assembly/Libray
// um assembly não pode ser executado diretamente, ele é feito para ser incorporado em outros projetos.

public class Math
{
    // Adição
    public static int Sum(int x, int y)
    {
        return x + y;
    }
    
    // Subtração
    public int Subtract(int x, int y)
    {
        return x - y;
    }
}