Public Class masterMenu
    Private Sub masterMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        genreMaster.Show()
        My.Application.ApplicationContext.MainForm = genreMaster
        Me.Close()
    End Sub
End Class