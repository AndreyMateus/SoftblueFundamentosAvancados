namespace SoftblueFundamentosAvancados_16_Criando_um_Framework_de_Execução;

// Esse Attributo só poderá ser usado em Classes
[AttributeUsage(AttributeTargets.Class)]
public sealed class RunClassAttribute : Attribute // As Classes classes que representam o Attribute SEMPRE TEM QUE SER PÚBLICAS e herdarem de ATTRIBUTE, OBS: se elas não forem pública, ficaram disponíveis apenas dentro do próprio projeto.
{
    
}