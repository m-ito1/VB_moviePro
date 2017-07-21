Public Class deleteDao
    Dim cn As System.Data.SqlClient.SqlConnection
    Dim con As New Class1
    Dim util As New util
    Dim command As New SqlClient.SqlCommand
    Dim sr As SqlClient.SqlDataReader
    Sub conDB()
        cn = con.Connect()
    End Sub
    Sub deleteProcess(bean As viewerBean)
        conDB()
        Dim name As String = bean.getName
        Dim id As String = bean.getId

        'コネクションの指定
        command.Connection = cn

        'コマンドの種類をテキストにする（省略可）
        command.CommandType = CommandType.Text

        '実行するSQLを指定
        command.CommandText = "DELETE FROM M_VIEWER WHERE VIEWER_ID = @KEY1 AND VIEWER_NAME = @KEY2"
        command.Parameters.AddWithValue("@KEY1", id)
        command.Parameters.AddWithValue("@KEY2", name)

        Dim iResult As Integer = command.ExecuteNonQuery()
        command.Dispose()
        MessageBox.Show(iResult.ToString())
        util.forwardScreen(viewerMaster, complete)


    End Sub
End Class
