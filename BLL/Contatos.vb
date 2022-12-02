Imports System.Data
Imports System.Collections.Generic
Imports System.Text
Imports DTO
Public Class Contatos
    Public Shared Function GetTodosContatosDS() As DataSet
        Dim ds = New DataSet
        Dim cmd = "ListaCategorias"
        Return DAL.AcessoBD.ExecutarComando("", cmd, CommandType.StoredProcedure, Nothing, DAL.AcessoBD.TipoDeComando.ExecuteDataSet)
    End Function

    Public Shared Function GetTodasContatosDT() As List(Of String)
        Dim sql = "SELECT * FROM Contatos"
        Dim dt = New DataTable
        dt = DAL.AcessoBD.ExecutarComando("SQLServer", sql, CommandType.Text, Nothing, DAL.AcessoBD.TipoDeComando.ExecuteDataTable)
        Dim retorno As List(Of String) = New List(Of String)
        For Each item As DataRow In dt.Rows
            retorno.Add(item("Nome").ToString)
        Next
        Return retorno
    End Function

    Public Shared Function GetCategorias(ByVal consultaSQL As String) As List(Of Contato)

        Dim Contatos As New List(Of Contato)
        Dim _contato As Contato
        Try
            Dim sql = "SELECT * FROM Contatos"
            Dim dt = New DataTable
            dt = DAL.AcessoBD.ExecutarComando("", sql, CommandType.Text, Nothing, DAL.AcessoBD.TipoDeComando.ExecuteDataTable)
            If dt.Rows.Count = 0 Then
                Throw New Exception("Nenhum contato encontrado")
            End If
            For Each linha As DataRow In dt.Rows
                _contato = New Contato With {
                    .Id_contato = linha("Id_contato"),
                    .Nome = linha("Nome"),
                    .Telefone = linha("Telefone"),
                    .Celular = linha("Celular"),
                    .Email = linha("Email")
                }
                Contatos.Add(_contato)
            Next
            Return Contatos
        Catch ex As Exception
            Throw
        End Try
    End Function
End Class
