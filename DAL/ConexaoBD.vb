Imports System.Configuration

Public Class ConexaoBD
    Shared _connectionString As String
    Shared _providerName As String
    ''' <summary>
    ''' Busca a cadeia de coneão do banco selecionado
    ''' </summary>
    ''' <param name="Banco"></param>
    Public Shared Sub GetAcesso(Optional ByVal Banco As String = "")
        Dim BD As String = IIf(Banco <> "", Banco, ConfigurationManager.AppSettings("BancoPadrao").ToString)
        Try
            _connectionString = ConfigurationManager.ConnectionStrings(BD).ConnectionString
            _providerName = ConfigurationManager.ConnectionStrings(BD).ProviderName
        Catch ex As Exception
            Throw New Exception("Erro na cadeia de conexão do banco " & BD)
        End Try
    End Sub
    ''' <summary>
    ''' ConnectionString
    ''' </summary>
    ''' <returns>ConnectionString</returns>
    Public Shared Function ConnectionString() As String
        Return _connectionString
    End Function
    ''' <summary>
    ''' ProviderName
    ''' </summary>
    ''' <returns>ProviderName</returns>
    Public Shared Function ProviderName() As String
        Return _providerName
    End Function
End Class
