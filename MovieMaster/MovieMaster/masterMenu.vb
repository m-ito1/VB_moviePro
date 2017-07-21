Public Class masterMenu
    Dim util As New util
    Private Sub masterMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

<<<<<<< HEAD
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        genreMaster.Show()
        My.Application.ApplicationContext.MainForm = genreMaster
        Me.Close()
=======
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        util.forwardScreen(Me, viewerMaster)
>>>>>>> f43f48aef18949d58417ec67a06c183b440021ed
    End Sub
End Class