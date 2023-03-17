namespace SoftblueFundamentosAvancados_11_Aula_Criando_Um_Assembly_Privado_Usando_a_Library;

class Program
{
    public static void Main(string[] args)
    {
        // Lembre-se que o Assembly PRIVADO é copiado para a sua pasta bin/debug/.net_versão
        // Isso após o projeto ser compilado
        // Quando temos que adicionar a referência manualmente, o assembly é privado, isso significa que a DLL/Libray que estamos usando, está dentro do próprio projeto, é feita uma cópia para cá.
        // Quando não temos que fazer isso, o ASSEMBLY é PÚBLICO, um assembly público é acessado diretamente no GAC(Global Assembly Chache)
        // Um Assembly que tenha um STRONG NAME é tratado como PÚBLICO AUTOMATICAMENTE, então ele não será copiado pelo compilador para dentro do Projeto, já um assembly que NÃO TEM UM STRONG NAME é considerado um aseembly PRIVADO
        
        /*  -------------OBSERVAÇÃO IMPORTANTE ------------
        Quando você compila uma solução que contém dois ou mais projetos, cada projeto é compilado em seu próprio assembly separado. Cada projeto da solução resultará em um assembly separado com seu próprio arquivo .dll ou .exe.
        
         A solução é simplesmente um contêiner para gerenciar e organizar os projetos em um ambiente de desenvolvimento. Quando você compila a solução, o Visual Studio compila cada projeto individualmente e, em seguida, os vincula em um único aplicativo ou biblioteca quando é necessário.
        */
        int resultado1 = SoftblueFundamentosAvancados_11_Aula_Criando_Um_Assembly_Privado.Math.Sum(2, 4);
        Console.WriteLine(resultado1);
        
    }
}