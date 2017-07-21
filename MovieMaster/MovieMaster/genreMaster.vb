Public Class genreMaster

<<<<<<< HEAD
    Public Shared cn As System.Data.SqlClient.SqlConnection
    Private con As New Connection()
    Private namelist As New List(Of String)
    Private idlist As New List(Of String)
    Dim page As Integer = 0
    Dim maxpage As Integer
    Dim pagecount As Integer = 1
    Dim lastpage As Integer
    Dim flag As Boolean = True
    Dim radio As Integer
    Dim id As String
    Dim name As String

    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cn = con.Connect()

        Dim cmd As New SqlClient.SqlCommand


        cmd.Connection = cn
        'コマンドの種類をテキストにする（省略可）
        cmd.CommandType = CommandType.Text
        '実行するSQLを指定
        cmd.CommandText = "SELECT GENRE_ID,GENRE_NAME FROM M_GENRE"

        'SQLの結果を取得する
        Dim sr As SqlClient.SqlDataReader
        sr = cmd.ExecuteReader()

        Dim cReader As System.Data.SqlClient.SqlDataReader = sr

        cmd.Dispose()

        While (cReader.Read())
            'ジャンル名一覧をリスト化
            namelist.Add(cReader("GENRE_NAME"))
            'ジャンルIDをリスト化
            idlist.Add(cReader("GENRE_ID"))

        End While
        sr.Close()
        disConnection()
        '全何ページか取得
        maxpage = Math.Ceiling(namelist.Count / 4)
        'テキストボックスの内容表示メソッド
        textdisp(page)


    End Sub

    '追加ボタン
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        '入力フォームに遷移
        inputGenre.Show()
            My.Application.ApplicationContext.MainForm = inputGenre
            Me.Close()

    End Sub

    '更新ボタン
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        '更新ボタンが1度も押されていないかチェック
        If flag Then

            Button2.Text = "完了"
            'ラジオボタンの選択位置を特定するメソッド
            getRadio()
            'ラジオボタンで選択されたテキストボックスの書き込み許可・それ以外のボックスをロック
            Select Case radio
                Case 0
                    TextBox1.ReadOnly = False
                    TextBox2.Enabled = False
                    TextBox3.Enabled = False
                    TextBox4.Enabled = False
                Case 1
                    TextBox2.ReadOnly = False
                    TextBox1.Enabled = False
                    TextBox3.Enabled = False
                    TextBox4.Enabled = False
                Case 2
                    TextBox3.ReadOnly = False
                    TextBox1.Enabled = False
                    TextBox2.Enabled = False
                    TextBox4.Enabled = False
                Case 3
                    TextBox4.ReadOnly = False
                    TextBox1.Enabled = False
                    TextBox2.Enabled = False
                    TextBox3.Enabled = False
            End Select

            '選択された場所以外のボタンをロック
            For Each rb In GroupBox1.Controls.OfType(Of RadioButton)
                If Not (rb.Checked) Then
                    rb.Enabled = False
                End If
            Next

            '「更新」ボタン以外ロック
            Button1.Enabled = False
            Button3.Enabled = False

            Button5.Enabled = False
            Button6.Enabled = False

            '更新ボタンを押したフラグ
            flag = False
            '1度更新ボタンを押した後の完了処理
        Else

            getRadio()
            '編集したテキスト・IDの取得
            Select Case radio
                Case 0
                    id = RadioButton1.Text
                    name = TextBox1.Text
                Case 1
                    id = RadioButton2.Text
                    name = TextBox2.Text
                Case 2
                    id = RadioButton3.Text
                    name = TextBox3.Text
                Case 3
                    id = RadioButton4.Text
                    name = TextBox4.Text
            End Select

            '取得したテキスト・IDを引数にアップデートのメソッド呼び出し
            update(id, name)

            '完了画面に遷移
            complete.Show()
            My.Application.ApplicationContext.MainForm = complete
            Me.Close()

        End If

    End Sub

    '「削除」ボタン
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        '消去確認のダイアログボックスの表示
        Dim result As DialogResult = MessageBox.Show(Me, "削除してもよろしいでしょうか", "削除", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        '「はい」の場合
        If result = 6 Then
            '選択したIDの取得
            Select Case radio
                Case 0
                    id = RadioButton1.Text

                Case 1
                    id = RadioButton2.Text

                Case 2
                    id = RadioButton3.Text

                Case 3
                    id = RadioButton4.Text

            End Select
            'IDを引数にデリートメソッド呼び出し
            delete(id)
            '完了画面に遷移
            complete.Show()
            My.Application.ApplicationContext.MainForm = complete
            Me.Close()

        End If

    End Sub

    '「戻る」ボタン
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        masterMenu.Show()
        My.Application.ApplicationContext.MainForm = masterMenu
        Me.Close()
    End Sub

    '「<<」ボタン
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If pagecount > 1 Then
            page = page - 4
            textdisp(page)
            pagecount = pagecount - 1
        End If
    End Sub

    '「>>」ボタン
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        If pagecount < maxpage Then
                page = page + 4
                textdisp(page)
                pagecount = pagecount + 1
            End If

    End Sub
    'DB切断メソッド
    Public Sub disConnection()

        If cn.State <> ConnectionState.Closed Then
            cn.Close()
        End If
        cn.Dispose()

    End Sub
    'DBの情報をテキストボックスに表示andテキストボックスの読み書き切り替えメソッド
    Private Sub textdisp(i)
        '
        If 0 + i < namelist.Count() Then
            TextBox1.Text = namelist(0 + i)
            RadioButton1.Text = idlist(i + 0)
            RadioButton4.Enabled = True
        Else
            TextBox1.Text = ""
            RadioButton1.Text = ""
            RadioButton4.Enabled = False
        End If


        If 1 + i < namelist.Count() Then
            TextBox2.Text = namelist(1 + i)
            RadioButton2.Text = idlist(i + 1)
            RadioButton2.Enabled = True
        Else
            TextBox2.Text = ""
            RadioButton2.Text = ""
            RadioButton2.Enabled = False
        End If


        If 2 + i < namelist.Count() Then
            TextBox3.Text = namelist(2 + i)
            RadioButton3.Text = idlist(i + 2)
            RadioButton3.Enabled = True
        Else
            TextBox3.Text = ""
            RadioButton3.Text = ""
            RadioButton3.Enabled = False
        End If


        If 3 + i < namelist.Count() Then
            TextBox4.Text = namelist(3 + i)
            RadioButton4.Text = idlist(i + 3)
            RadioButton4.Enabled = True
        Else
            TextBox4.Text = ""
            RadioButton4.Text = ""
            RadioButton4.Enabled = False
        End If

    End Sub

    Private Sub update(id, name)

        cn = con.Connect()

        Dim cmd As New SqlClient.SqlCommand

        'コネクションの指定
        cmd.Connection = cn
        'コマンドの種類をテキストにする（省略可）
        cmd.CommandType = CommandType.Text
        '実行するSQLを指定
        cmd.CommandText = "UPDATE M_GENRE SET GENRE_NAME = @name,UPDATE_DATE = GETDATE() WHERE GENRE_ID = @id "
        cmd.Parameters.AddWithValue("@id", id)
        cmd.Parameters.AddWithValue("@name", name)

        Dim sr As SqlClient.SqlDataReader
        sr = cmd.ExecuteReader()

        Dim cReader As System.Data.SqlClient.SqlDataReader = sr

        cmd.Dispose()
        disConnection()

    End Sub

    Private Sub delete(id)

        cn = con.Connect()

        Dim cmd As New SqlClient.SqlCommand

        'コネクションの指定
        cmd.Connection = cn
        'コマンドの種類をテキストにする（省略可）
        cmd.CommandType = CommandType.Text
        '実行するSQLを指定
        cmd.CommandText = "DELETE FROM M_GENRE WHERE GENRE_ID = @id "
        cmd.Parameters.AddWithValue("@id", id)

        Dim sr As SqlClient.SqlDataReader
        sr = cmd.ExecuteReader()

        Dim cReader As System.Data.SqlClient.SqlDataReader = sr

        cmd.Dispose()
        disConnection()

    End Sub

    Private Sub getRadio()

        Dim rb As RadioButton
        For Each rb In GroupBox1.Controls.OfType(Of RadioButton)
            If (rb.Checked) Then
                radio = rb.Tag
            End If
        Next
    End Sub

=======
>>>>>>> f43f48aef18949d58417ec67a06c183b440021ed
End Class