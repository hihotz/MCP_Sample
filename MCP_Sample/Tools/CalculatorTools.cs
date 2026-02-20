using System.ComponentModel;
using ModelContextProtocol.Server;

namespace MCP_Sample.Tools;

[McpServerToolType]
public class CalculatorTools
{
    [McpServerTool(Name = "add")]
    [Description("두 숫자를 더한 결과를 반환합니다.")]
    public int Add([Description("첫 번째 숫자")] int a, [Description("두 번째 숫자")] int b)
    {
        return a + b;
    }

    [McpServerTool(Name = "subtract")]
    [Description("첫 번째 숫자에서 두 번째 숫자를 뺀 결과를 반환합니다.")]
    public int Subtract([Description("첫 번째 숫자")] int a, [Description("두 번째 숫자")] int b)
    {
        return a - b;
    }

    [McpServerTool(Name = "multiply")]
    [Description("두 숫자를 곱한 결과를 반환합니다.")]
    public int Multiply([Description("첫 번째 숫자")] int a, [Description("두 번째 숫자")] int b)
    {
        return a * b;
    }

    [McpServerTool(Name = "divide")]
    [Description("첫 번째 숫자를 두 번째 숫자로 나눈 결과를 반환합니다.")]
    public double Divide([Description("첫 번째 숫자")] int a, [Description("두 번째 숫자")] int b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("0으로 나눌 수 없습니다.");
        }

        return (double)a / b;
    }
}
