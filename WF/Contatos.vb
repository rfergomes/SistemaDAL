
Public Class Contatos
    Private Sub Contatos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CarregaDataGrid()
    End Sub

    Private Sub btNovo_Click(sender As Object, e As EventArgs) Handles btNovo.Click
        Limpar()
        HabilitarCampos(True)
        With Me
            .btNovo.Enabled = False
            .btCancelar.Enabled = True
            .txtPesquisar.Enabled = False
            .btSalvar.Enabled = True
            .txtId.Enabled = False
            .txtNome.Focus()
        End With
    End Sub

    Private Sub btSalvar_Click(sender As Object, e As EventArgs) Handles btSalvar.Click
        If Me.txtNome.Text = "" And Me.txtEmail.Text = "" Then MsgBox("Os campos Nome e E-mail são obrigatórios", MessageBoxIcon.Warning, "Atenção") : Exit Sub
        Me.btNovo.Enabled = True
        If Me.txtId.Text = "" Or Me.txtId.Text = 0 Then
            'Incluir

        Else
            'Alterar

        End If

    End Sub

    Private Sub btCancelar_Click(sender As Object, e As EventArgs) Handles btCancelar.Click
        Limpar()
        Me.txtPesquisar.Focus()
    End Sub

    Private Sub txtPesquisar_DoubleClick(sender As Object, e As EventArgs) Handles txtPesquisar.DoubleClick
        Me.txtPesquisar.Text = Nothing
    End Sub

    Private Sub Limpar()
        HabilitarCampos(False)
        With Me
            .txtPesquisar.Enabled = True
            .txtPesquisar.Text = ""
            .txtId.Text = ""
            .txtNome.Text = ""
            .txtTelefone.Text = ""
            .txtCelular.Text = ""
            .txtEmail.Text = ""
            .btNovo.Enabled = True
            .btCancelar.Enabled = False
            .btSalvar.Enabled = False
        End With
    End Sub

    Private Sub HabilitarCampos(ByRef Habilitar As Boolean)
        With Me
            '.txtId.Enabled = Habilitar
            .txtNome.Enabled = Habilitar
            .txtTelefone.Enabled = Habilitar
            .txtCelular.Enabled = Habilitar
            .txtEmail.Enabled = Habilitar
        End With
    End Sub



    Private Sub CarregaDataGrid()
        Me.DataGridView1.DataSource = BLL.Contatos.GetTodosContatosDS.Tables(0)
    End Sub
End Class
