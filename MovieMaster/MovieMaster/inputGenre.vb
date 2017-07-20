Public Class inputGenre

    Private cn As New System.Data.SqlClient.SqlConnection
    Private con As New Connection()
    Dim flag As Boolean = True
    Dim idflag As Boolean = True
    Dim check As String

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = " " Or TextBox1.Text = "　" Then

            TextBox1.Text = ""
        End If
    End Sub
    Private Sub TextBox2_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox2.TextChanged

        If TextBox2.Text = " " Or TextBox2.Text = "　" Then

            TextBox2.Text = ""
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        flag = True



        If TextBox1.Text = String.Empty Then

            MsgBox("ジャンル名を入力してください")



            If idflag Then

            checkForm()

            If flag Then

                Insert()
                complete.Show()
                My.Application.ApplicationContext.MainForm = complete
                Me.Close()

            Else
                MsgBox("入力された内容はすでに存在します")

            End If
        Else
                MsgBox("入力されたIDが正しくありません" & vbCrLf & "1～9の半角数字で入力してください")
            End If

        End If


    End Sub

    Private Sub checkForm()

        cn = con.Connect()

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
            flag = False
        End If


    End Sub

    Private Sub Insert()

        cn = con.Connect()

        Dim cmd As New SqlClient.SqlCommand

        'コネクションの指定
        cmd.Connection = cn
        'コマンドの種類をテキストにする（省略可）
        cmd.CommandType = CommandType.Text
        '実行するSQLを指定
        cmd.CommandText = "INSERT INTO M_GENRE(GENRE_ID,GENRE_NAME,DELETE_FLAG,CREATE_DATE,CREATE_USER) VALUES(@id,@name,0,GETDATE(),'00')"
        cmd.Parameters.AddWithValue("@id", TextBox2.Text)
        cmd.Parameters.AddWithValue("@name", TextBox1.Text)

        Dim sr As SqlClient.SqlDataReader
        sr = cmd.ExecuteReader()

        Dim cReader As System.Data.SqlClient.SqlDataReader = sr

        cmd.Dispose()

        If (cReader.Read()) Then
            flag = False
        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        genreMaster.Show()
        My.Application.ApplicationContext.MainForm = genreMaster
        Me.Close()
    End Sub

    Private Sub inputGenre_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.MaxLength = 40
        TextBox2.MaxLength = 1
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object,
        e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If (e.KeyChar < "0"c Or "9"c < e.KeyChar) And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub
End Class