namespace SoftblueFundamentosAvancados_04_Criando_Castings_Customizados;

class Program
{
    public static void Main(string[] args)
    {
        // O Casting é usado quando queremos mudar o TIPO do DADO
        // OBS: nesse caso ele é usado para CONVERTER um TIPO COMPLEXO para PRIMITIVO ou vice versa, mas tipos complexos para tipos complexos ou tipos primitivos para tipos primitivos não precisam de um casting personalizado,
        // E pode ocorrer de 2 Maneiras, de forma IMPLÍCITA e EXPLICITA
        // Iremos fazer um CASTING CUSTOMIZADO, É CUSTOMIZADO PORQUE NÓS IREMOS DEFINIR AS "REGRAS" DO CASTING. 
        // Quando se utilizando o "casting customizado", você não precisa se submeter as regras de casting da própria linguagem, você pode implementar o casting da forma que você quiser.
        // OBS: só se pode ter  UMA VERSÃO DO MESMO CASTING, então você tem que escolher se ele será IMPLICITO ou EXPLICITO.
        // Você também pode fazer uma versão OPOSTA DO CASTING, onde tanto  a transformação pode ocorrer no TIPO que é recebido, ou no TIPO que é passado.
        
        LetraAlfabeto la = new LetraAlfabeto('B');
        
        //char charLaImplicito = la; // CASTING IMPLICITO
        //Console.WriteLine(charLaImplicito);

        char charLaExplicito = (char)la;
        Console.WriteLine(charLaExplicito);

        LetraAlfabeto letraAlfabeto = (LetraAlfabeto)'X';

    }
}

class LetraAlfabeto
{
    private char caractere;

    public LetraAlfabeto(char caractere)
    {
        this.caractere = char.ToUpper(caractere);
    }

    #region Mesmo Casting
    // public static implicit operator char(LetraAlfabeto la)
    // {
    //     return la.caractere;
    // }
    public static implicit operator char(LetraAlfabeto la)
    {
        return la.caractere;
    }
    #endregion Mesmo Casting
   
    // Um Casting diferente/oposto do de cima
    public static implicit operator LetraAlfabeto(char c)
    {
        return new LetraAlfabeto(c);
    }
}