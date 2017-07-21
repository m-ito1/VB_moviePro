Public Class masterMenu
    Dim util As New util
    Private Sub masterMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        util.forwardScreen(Me, viewerMaster)
    End Sub
End Class