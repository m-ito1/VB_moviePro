Public Class inputViewer
    Dim cn As System.Data.SqlClient.SqlConnection
    Dim con As New Class1
    Dim util As New util
    Dim insertDao As New insertDao
    Dim command As New SqlClient.SqlCommand
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cheakNotation()
        Dim Name As String = TextBox1.Text
        Dim Pass As String = TextBox2.Text
        Dim id As String = TextBox3.Text
        insertDao.addProcess(Name, Pass, id)
        util.forwardScreen(Me, complete)

    End Sub
    Private Sub inputViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn = con.Connect()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        util.forwardScreen(Me, viewerMaster)
    End Sub
    Sub cheakNotation()
        If System.Text.RegularExpressions.Regex.IsMatch(
        TextBox1.Text, "\d{2}") Then
            Console.WriteLine("マッチ")

        End If
    End Sub
End Class