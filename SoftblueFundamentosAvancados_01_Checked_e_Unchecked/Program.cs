namespace SoftblueFundamentosAvancados_01_Checked_e_Unchecked;

class Prgram
{
    public static void Main(string[] args)
    {
        short s1 = 25000;
        short s2 = 20000;

        //checked avisará quando o overflow acontecer.
        // Obs: você também pode habilitar uma opção em sua IDE e ao invés de precisar ficar usando checked no seu código, a IDE vai automaticamente verificar isso para você.
        // Porém tome cuidado, use essa opção somente em tempo de DESENVOLVIMENTO da APLICAÇÃO e até corrigir o erro de overflow, pois essa opção irá CAUSAR UM AUMENTO DE  CUSTO DE PERFORMANCE GIGANTE.
        checked
        {
            short s3 = (short)(s1 + s2);
            
            Console.WriteLine(s3);
        }
        
        // o UNCHEKED é mais utilizado para dizer que esse overflow PODE acontecer e ela não deve ser verificada, ele é bem utilizado quando se ativa a opção de verificação da IDE, assim ela só verificará os código que NÃO ESTIVEREM DENTRO DO UNCHECKED.
        unchecked
        {  
            short s4 = (short)(s1 + s2);
            
            Console.WriteLine(s4);
        }



    }
}