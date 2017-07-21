Public Class insertDao
    Dim cn As System.Data.SqlClient.SqlConnection
    Dim con As New Class1
    Dim command As New SqlClient.SqlCommand
    Sub conDB()
        cn = con.Connect()
    End Sub
    Sub addProcess(Name As String, Pass As String, id As String)
        conDB()
        'コネクションの指定
        command.Connection = cn

        'コマンドの種類をテキストにする（省略可）
        command.CommandType = CommandType.Text

        '実行するSQLを指定
        command.CommandText = "INSERT INTO M_VIEWER (VIEWER_ID, VIEWER_NAME, PASSWORD, DELETE_FLAG, CREATE_DATE, CREATE_USER)
                                VALUES(@KEY1,@KEY2,@KEY3,'0',GETDATE(),'00');"
        command.Parameters.AddWithValue("@KEY1", id)
        command.Parameters.AddWithValue("@KEY2", Name)
        command.Parameters.AddWithValue("@KEY3", Pass)

        Dim iResult As Integer = command.ExecuteNonQuery()
        command.Dispose()
        MessageBox.Show(iResult.ToString())
    End Sub

End Class
