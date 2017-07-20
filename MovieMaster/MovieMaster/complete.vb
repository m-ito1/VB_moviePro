Public Class complete

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim f As New masterMenu
        f.Show()
        My.Application.ApplicationContext.MainForm = f
        Me.Close()

    End Sub

End Class