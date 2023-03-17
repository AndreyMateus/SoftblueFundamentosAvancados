namespace Softblue_05_Exercicio;

public class Pessoa
{
    public double Peso { get; set; }
    public double Altura { get; set; }

    public double CalcularImc(Calculo calculo)
    {
        if (calculo != null)
        {
            return calculo(Peso,Altura);
        }
        return -1;
    }
}
public delegate double Calculo(double peso, double altura);