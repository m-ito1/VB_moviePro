Public Class complete
<<<<<<< HEAD
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        masterMenu.Show()
        My.Application.ApplicationContext.MainForm = masterMenu
        Me.Close()
=======

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim f As New masterMenu
        f.Show()
        My.Application.ApplicationContext.MainForm = f
        Me.Close()

>>>>>>> 62239578c106cee93157d9023baa6e3e8502aaff
    End Sub

End Class