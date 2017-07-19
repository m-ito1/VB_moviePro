﻿Public Class genreMaster

    Public Shared cn As System.Data.SqlClient.SqlConnection
    Private list As New List(Of String)

    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Dim page As Integer = 0

        Connection()

        Dim cmd As New SqlClient.SqlCommand


        cmd.Connection = cn
        'コマンドの種類をテキストにする（省略可）
        cmd.CommandType = CommandType.Text
        '実行するSQLを指定
        cmd.CommandText = "SELECT GENRE_NAME FROM M_GENRE"

        'SQLの結果を取得する
        Dim sr As SqlClient.SqlDataReader
        sr = cmd.ExecuteReader()

        Dim cReader As System.Data.SqlClient.SqlDataReader = sr

        cmd.Dispose()

        While (cReader.Read())

            list.Add(cReader("GENRE_NAME"))

        End While
        sr.Close()
        disConnection()

        textdisp(page)


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

    Private Sub textdisp(i)

        TextBox1.Text = list(0 + i)
        TextBox2.Text = list(1 + i)
        TextBox3.Text = list(2 + i)
        TextBox4.Text = list(3 + i)


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        inputGenre.Show()
        My.Application.ApplicationContext.MainForm = inputGenre
        Me.Close()

    End Sub
End Class