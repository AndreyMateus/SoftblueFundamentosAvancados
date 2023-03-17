namespace SoftblueFundamentosAvancados_12_Aula_Criando_Um_Assembly_Compartilhado;

public class StringUtils
{
    // Assemblies COMPARTILHADOS são aqueles que ficam ARMAZENADOS EM UM DIRETÓRIO ESPECÍFICO DO COMPUTADOR, ESSE DIRETÓRIO É CHAMADO DE "GAC / GLOBAL ASSEMBLY CACHE", o GAC é onde ficam TODOS os ASSEMBLIES COMPARTILHADOS, assim os outros projetos acessam diretamente esse assembly.
    // E nesse caso NÃO OCORRE A CÓPIA DO ASSEMBLY para DENTRO do PROJETO, isso só ocorre em ASSEMBLIES PRIVADOS, aqui nós temos ACESSO DIRETO AO ARQUIVO.
    // Então se ele for ALTERADO, TODAS as aplicações/Projetos que usam esse ASSEMBLY, terão acesso a essas ALTERAÇÕES.

    // OBS: para deixar uma Library/DLL no GAG, temos que usar um STRONG NAME.
    // Após isso será gerada uma Chave.snk 
    
    // Para colocar a DLL no GAC, você terá que:
    // 1 - Abrir o Developer Command Prompt -> COMO ADMINISTRADOR
    // 2.1 - Compilar o Projeto para que a CLASSE vire uma DLL
    // 2 - Dentro do terminal ir até a pasta onde está o Projeto Compilado em DLL
    // 2.2 - Geralmente fica em SeuProjeto/bin/debug
    // 3 - agora use o comando "gacutil /i nomeDoAssemblyAqui.dll", o "/i" é de INSTALAR o assembly no gac.
    // OBS: o NOME DO ASSEMBLY é o NOME DO PROJETO com a extensão .DLL, pois é o Projeto compilado em DLL
    // OBS2: Caso queira verificar se o PROJETO.DLL/ASSEMBLY foi adicionado ao GAC, basta repetir o comando gacutil, PORÉM USANDO O /l, assim: gacutil /l nomeDoProjeto.dll, se ele estiver instalado, então será mostrando o assembly e algumas de suas propriedades.
    
    /*  -------------OBSERVAÇÃO IMPORTANTE ------------
    Quando você compila uma solução que contém dois ou mais projetos, cada projeto é compilado em seu próprio assembly separado. Cada projeto da solução resultará em um assembly separado com seu próprio arquivo .dll ou .exe.
        
    A solução é simplesmente um contêiner para gerenciar e organizar os projetos em um ambiente de desenvolvimento. Quando você compila a solução, o Visual Studio compila cada projeto individualmente e, em seguida, os vincula em um único aplicativo ou biblioteca quando é necessário.
    */
    
    public static string Capitalize(string texto)
    {
        if (texto == null)
        {
            return null;
        }
        if (texto.Length == 0)
        {
            return texto;
        }

        char c = char.ToUpper(texto[0]);
        return c + texto.Substring(1);
    }
    
}