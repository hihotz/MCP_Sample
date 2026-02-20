# MCP_Sample
C# ASP.NET Core로 만드는 MCP Sample

## 프로젝트를 시작하기 전에

이 프로젝트는 MCP 개념 학습을 위해 제작한 프로젝트임

Codex 5.3 버전을 사용해 샘플 프로젝트 생성하였으며, .net 10버전을 사용함

## 프로젝트 시작

VS Code 사용 시 터미널에 아래 명령어 입력

```powershell
# 경로 지정이 안된 경우,
cd 프로젝트 경로

# 프로젝트 시작 (Aspire 프로젝트 시작)
dotnet run --project MCP_Sample.AppHost
```

## MCP 테스트 방법

initialize -> tools/list -> tools/call 순서로 테스트하면됨

아래 코드를 VS Code 터미널에 작성해서 테스트 동작하기.. 단, 1번의 서버 실행과 나머지 항목은 각각 다른 터미널에서 실행해야함

추가로, 아래 로컬 호스트(`http://127.0.0.1:5198`)의 경우 실제 서버 동작 위치로 변경해주기


1. 서버 실행
```powershell
dotnet run --project MCP_Sample\MCP_Sample.csproj --urls http://127.0.0.1:5198
```

2. initialize(세션 생성)
```powershell
$headers = @{
  Accept = "application/json, text/event-stream"
  "MCP-Protocol-Version" = "2025-06-18"
}
$initBody = '{"jsonrpc":"2.0","id":1,"method":"initialize","params":{"protocolVersion":"2025-06-18","capabilities":{},"clientInfo":{"name":"manual-test","version":"1.0"}}}'
$r = Invoke-WebRequest -Uri "http://127.0.0.1:5198/" -Method Post -Headers $headers -ContentType "application/json" -Body $initBody
$r.Content
$session = $r.Headers["Mcp-Session-Id"]
$session
```

3. tools/list(tools 리스트 조회)
```powershell
$headers["Mcp-Session-Id"] = $session
$listBody = '{"jsonrpc":"2.0","id":2,"method":"tools/list","params":{}}'
(Invoke-WebRequest -Uri "http://127.0.0.1:5198/" -Method Post -Headers $headers -ContentType "application/json" -Body $listBody).Content
```   


실제 tools 기능을 테스트/사용하는 경우, 아래와 같이 호출

```powershell
# multiply(곱하기)
$callBody = '{"jsonrpc":"2.0","id":3,"method":"tools/call","params":{"name":"multiply","arguments":{"a":6,"b":7}}}'
(Invoke-WebRequest -Uri "http://127.0.0.1:5198/" -Method Post -Headers $headers -ContentType "application/json" -Body $callBody).Content

# divide(나누기)
$callBody = '{"jsonrpc":"2.0","id":4,"method":"tools/call","params":{"name":"divide","arguments":{"a":10,"b":4}}}'
(Invoke-WebRequest -Uri "http://127.0.0.1:5198/" -Method Post -Headers $headers -ContentType "application/json" -Body $callBody).Content
```

## 라이선스

- 프로젝트 라이선스: [MIT](./LICENSE)
- 서드파티 패키지 고지: [THIRD-PARTY-NOTICES](./THIRD-PARTY-NOTICES.md)
