using System.Reflection;

namespace SoftblueFundamentosAvancados_16_Criando_um_Framework_de_Execução;

public class Result
{
    public Type ClassType { get; private set; }
    public MethodInfo MethodInfo { get; private set; }
    public TimeSpan Time { get; private set; }

    public Result(Type classType, MethodInfo methodInfo, TimeSpan timeSpan)
    {
        this.ClassType = classType;
        this.MethodInfo = methodInfo;
        this.Time = timeSpan;
    }

    public override string ToString()
    {
        return $"Nome da Classe: {ClassType.Name}," +
               $"Nome do Método: {MethodInfo.Name}," +
               $"Tempo de Execução: {Time.Hours:00}:{Time.Minutes:00}:{Time.Seconds:00}:{Time.Microseconds:000}";
    }
}