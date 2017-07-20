Public Class masterMenu
    Private Sub masterMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim f As New movieMaster
        f.Show()
        My.Application.ApplicationContext.MainForm = f
        Me.Close()
    End Sub
End Class