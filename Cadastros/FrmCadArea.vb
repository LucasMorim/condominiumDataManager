﻿Public Class FrmCadArea
    Dim objControle As New ClsControle
    Dim objAreas As New ClsArea
    Dim novo As String

    Private Sub btnNovCad_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        objControle.Limpar_tela(Me)
        objControle.Habilitar_tela(Me, True)
        objControle.Habilitar_botoes(Me, False)
        txtCod.Focus()
        novo = True
    End Sub
    Private Sub btnSair_Click(sender As Object, e As EventArgs) Handles btnSair.Click
        Me.Close()
    End Sub
    Private Sub FrmCadArea_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objControle.Limpar_tela(Me)
        objControle.Habilitar_tela(Me, False)
        objControle.Habilitar_botoes(Me, True)

        txtCod.Enabled = False
        grpLoc.Visible = False
    End Sub

    Private Sub BtnCad_Click(sender As Object, e As EventArgs) Handles BtnCad.Click

        If objControle.Testar_Vazio(Me) = True Then
            MessageBox.Show("Favor preencher todos os campos obrigatórios")
            objControle.Habilitar_tela(Me, True)
            objControle.Habilitar_botoes(Me, False)
            txtNom.Focus()

        Else

            objControle.Habilitar_tela(Me, False)
            objControle.Habilitar_botoes(Me, True)

            ' If Novo = False Then
            objAreas.Codigo = Val(txtCod.Text)
            ' End If

            objAreas.Nome = txtNom.Text
            objAreas.Valor = txtVal.Text
            objAreas.QuantidadeMaxima = txtQtdMax.Text


            objAreas.gravar_dados(novo)

            txtCod.Text = objAreas.Codigo
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCan.Click
        Call FrmCadArea_Load(Nothing, Nothing)
        btnLoc.Enabled = True
    End Sub

    Private Sub btnAlterar_Click(sender As Object, e As EventArgs) Handles btnAlt.Click
        objControle.Habilitar_tela(Me, True)
        objControle.Habilitar_botoes(Me, False)

        txtCod.Enabled = False
        txtNom.Focus()
        novo = False
    End Sub
    Private Sub btnLoc_Click(sender As Object, e As EventArgs) Handles btnLoc.Click
        grpLoc.Visible = True
        btnLoc.Enabled = False
        btnConfirmar.Enabled = False
        txtLoc.Text = ""
        txtLoc.Focus()
    End Sub
    Private Sub txtLoc_TextChanged(sender As Object, e As EventArgs) Handles txtLoc.TextChanged
        If txtLoc.Text <> "" Then
            btnConfirmar.Enabled = True
        Else
            btnConfirmar.Enabled = False
        End If
    End Sub
    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        If objAreas.localizar(txtLoc.Text) = True Then
            Call Mostrar_dados_da_tela()
            grpLoc.Visible = False
            btnLoc.Enabled = True
        Else
            txtLoc.Clear()
            txtLoc.Focus()
        End If
    End Sub

    Private Sub Mostrar_dados_da_tela()

        txtCod.Text = objAreas.Codigo
        txtNom.Text = objAreas.Nome
        txtVal.Text = objAreas.Valor
        txtQtdMax.Text = objAreas.QuantidadeMaxima
    End Sub

    Private Sub txtVal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtVal.KeyPress
        e.Handled = objControle.SoNumerosEVirgula(e.KeyChar)
    End Sub
End Class