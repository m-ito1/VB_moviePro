Public Class inputGenre


    Public Shared cn As System.Data.SqlClient.SqlConnection

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        checkForm()


    End Sub

    Private Sub checkForm()

        Connection()

        Dim cmd As New SqlClient.SqlCommand

        'コネクションの指定
        cmd.Connection = cn
        'コマンドの種類をテキストにする（省略可）
        cmd.CommandType = CommandType.Text
        '実行するSQLを指定
        cmd.CommandText = "SELECT GENRE_ID FROM M_GENRE WHERE GENRE_ID = @id OR GENRE_NAME = @name"
        cmd.Parameters.AddWithValue("@id", TextBox2.Text)
        cmd.Parameters.AddWithValue("@name", TextBox1.Text)

        Dim sr As SqlClient.SqlDataReader
        sr = cmd.ExecuteReader()

        Dim cReader As System.Data.SqlClient.SqlDataReader = sr

        cmd.Dispose()

        If (cReader.Read()) Then
            MsgBox("入力された内容はすでに存在します")
        End If


        disConnection()

    End Sub

    Public Sub Connection()

        '端末
        Dim ServerName As String = "192.168.0.173"
        'DB名
        Dim DBName As String = "master"
        'ユーザー名
        Dim UserId As String = "sa"
        'パスワード
        Dim Password As String = "SaPassword2017"

        cn = New System.Data.SqlClient.SqlConnection

        cn.ConnectionString =
        "Data Source = " & ServerName &
        ";Initial Catalog = " & DBName &
        ";User ID = " & UserId &
        ";Password = " & Password
        cn.Open()

    End Sub

    Public Sub disConnection()

        If cn.State <> ConnectionState.Closed Then
            cn.Close()
        End If
        cn.Dispose()

    End Sub
End Class