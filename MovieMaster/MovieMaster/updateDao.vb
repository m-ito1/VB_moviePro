Public Class updateDao
    Dim cn As System.Data.SqlClient.SqlConnection
    Dim con As New Class1
    Dim util As New util
    Dim command As New SqlClient.SqlCommand
    Sub conDB()
        cn = con.Connect()
    End Sub
    Sub updateProcess(befBean As viewerBean, aftBean As viewerBean)
        conDB()
        'コネクションの指定
        command.Connection = cn

        'コマンドの種類をテキストにする（省略可）
        command.CommandType = CommandType.Text

        '実行するSQLを指定
        command.CommandText = "UPDATE M_VIEWER SET VIEWER_NAME = @KEY1,UPDATE_DATE=GETDATE(),UPDATE_USER = '00' 
                                WHERE VIEWER_ID = @KEY2"
        command.Parameters.AddWithValue("@KEY1", aftBean.getName)
        command.Parameters.AddWithValue("@KEY2", befBean.getId)

        Dim iResult As Integer = command.ExecuteNonQuery()
        command.Dispose()
        MessageBox.Show(iResult.ToString())
        util.forwardScreen(viewerMaster, complete)
    End Sub
End Class
