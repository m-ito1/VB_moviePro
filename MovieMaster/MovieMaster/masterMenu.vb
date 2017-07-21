Public Class masterMenu
    Private Sub masterMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

<<<<<<< HEAD
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        genreMaster.Show()
        My.Application.ApplicationContext.MainForm = genreMaster
=======
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim f As New movieMaster
        f.Show()
        My.Application.ApplicationContext.MainForm = f
>>>>>>> 62239578c106cee93157d9023baa6e3e8502aaff
        Me.Close()
    End Sub
End Class