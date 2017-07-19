Public Class viewerMaster
    Dim cn As System.Data.SqlClient.SqlConnection
    Dim command As New SqlClient.SqlCommand
    Public infoDispList As New List(Of String)
    Sub viewerMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        infoDispList = getDispInfo()　'データを表示
        setInfo(infoDispList)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        forwardScreen(Me, inputViewer) '追加画面に遷移


    End Sub
    Function getDispInfo()

        Dim sr As SqlClient.SqlDataReader
        Dim infoDispList As New List(Of String)

        'コネクションの指定
        command.Connection = cn

        'コマンドの種類をテキストにする（省略可）
        command.CommandType = CommandType.Text

        '実行するSQLを指定
        command.CommandText = "SELECT USER_ID, USER_NAME FROM M_USER WHERE DELETE_FLAG = 0"

        'SQLの結果を取得する
        sr = command.ExecuteReader()
        command.Dispose()

        '取得した結果を出力する

        While sr.Read
            infoDispList.Add(sr(1))
        End While
        sr.Dispose()
        Return infoDispList
    End Function
    Sub setInfo(ByVal infoDispList As List(Of String))
        TextBox1.Text = infoDispList(0)
        TextBox2.Text = infoDispList(1)
        TextBox3.Text = infoDispList(2)
        TextBox4.Text = infoDispList(3)

    End Sub
    Public Sub forwardScreen(original As Form, target As Form)
        Dim inputViewer As New inputViewer
        target.Show()
        My.Application.ApplicationContext.MainForm = target
        original.Dispose()
    End Sub
End Class
