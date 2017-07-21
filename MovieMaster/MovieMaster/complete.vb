Public Class complete
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        masterMenu.Show()
        My.Application.ApplicationContext.MainForm = masterMenu
        Me.Close()
    End Sub

End Class