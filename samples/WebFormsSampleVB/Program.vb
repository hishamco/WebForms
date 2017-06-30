Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Threading.Tasks
Imports Microsoft.AspNetCore.Hosting

Namespace WebFormsSampleVB
    Public Module Program
        Public Sub Main(args As String())
            Dim host = New WebHostBuilder().
            UseKestrel().
            UseContentRoot(Directory.GetCurrentDirectory()).
            UseIISIntegration().
            UseStartup(Of Startup)().
            UseEnvironment(EnvironmentName.Development).
            Build()

            host.Run()
        End Sub
    End Module
End Namespace
