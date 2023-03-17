namespace SoftblueFundamentosAvancados_03_Definindo_Indexadores;

class Program
{
    public static void Main(string[] args)
    {
        Temperatura t = new Temperatura();

        int t1 = t[2];
        Console.WriteLine(t1);

        // Antes
        Console.WriteLine(t[12]);
        // Setando um novo valor
        t[12] = 30;
        //Vendo o novo valor
        Console.WriteLine(t[12]);
        
        // Retornando o valor, através de um índice string
        int valor = t["Jan"];
        Console.WriteLine(valor);
    }
}

class Temperatura
{
    private int[] temperaturas ={30, 31, 29, 27, 22, 15, 16, 19, 23, 26, 27, 28};
    
    //Criando um Indexador
    public int this[int i]// o This representa a própria classe e o [] é valor passado dentre os colchetes, o valor que servirá de posição, ou seja: qual posição você deseja acessar.
    {
        get
        {
            return temperaturas[i-1];
        }
        set
        {
            temperaturas[i-1] = value;
        }
    }

    public int this[string mes]// Acessando o Indexador através do INDICE[string mes], porém retornando um número do tipo inteiro
    {
        get
        {
            switch (mes)
            {
                // Aqui não precisa de BREAK, pois o RETURN encerrará  a setença de comando.
                case "Jan": return temperaturas[0];
                case "Fev": return temperaturas[1];
                case "Mar": return temperaturas[2];
                case "Abr": return temperaturas[3];
                case "Jun": return temperaturas[5];
                case "Jul": return temperaturas[6];
                case "Ago": return temperaturas[7];
                case "Set": return temperaturas[8];
                case "Out": return temperaturas[9];
                case "Nov": return temperaturas[10];
                case "Dez": return temperaturas[11];
                default: return -1;
            }
        }
        set
        {
            switch (mes)
            {
                case "Jan" : temperaturas[0] = value;
                    break;
                case "Fev" : temperaturas[1] = value;
                    break;
                case "Mar" : temperaturas[2] = value;
                    break;
                case "Abr" : temperaturas[3] = value;
                    break;
                case "Jun" : temperaturas[4] = value;
                    break;
                case "Jul" : temperaturas[5] = value;
                    break;
                case "Ago" : temperaturas[7] = value;
                    break;
                case "Set" : temperaturas[8] = value;
                    break;
                case "Out" : temperaturas[9] = value;
                    break;
                case "Nov" : temperaturas[10] = value;
                    break;
                case "Dez" : temperaturas[11] = value;
                    break;
            }
        }
    }
}