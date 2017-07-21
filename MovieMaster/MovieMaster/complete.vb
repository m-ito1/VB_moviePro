Public Class complete
<<<<<<< HEAD
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        masterMenu.Show()
        My.Application.ApplicationContext.MainForm = masterMenu
        Me.Close()
=======
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim util As New util
        util.forwardScreen(Me, masterMenu)
>>>>>>> f43f48aef18949d58417ec67a06c183b440021ed
    End Sub

End Class