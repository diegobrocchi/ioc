Public Class Form1
    Dim m As New modem_bo
    Private Sub rbLiu_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbLiu.CheckedChanged

        Dim mh As New modem_manager("192.168.1.24", 2000)
        Try
            If rbLiu.Checked Then
                m.ModInput = ModulatorInput.liu_input
            ElseIf rbExt.Checked Then
                m.ModInput = ModulatorInput.external_input
            ElseIf rbMerda.Checked Then
                m.ModInput = ModulatorInput.undefined

            End If
            Label1.Text = m.ModInput.ToString & " selected"
            Label2.Text = mh.SetModInput(m)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub rbExt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbExt.CheckedChanged

        Dim mh As New modem_manager("192.168.1.24", 2000)
        Try
            If rbExt.Checked Then
                m.ModInput = ModulatorInput.external_input
            ElseIf rbLiu.Checked Then
                m.ModInput = ModulatorInput.liu_input
            ElseIf rbMerda.Checked Then
                m.ModInput = ModulatorInput.undefined
            End If
            Label1.Text = m.ModInput.ToString & " selected"
            Label2.Text = mh.SetModInput(m)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        End Try

    End Sub

End Class
