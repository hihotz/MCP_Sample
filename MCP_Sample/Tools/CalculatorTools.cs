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
}
