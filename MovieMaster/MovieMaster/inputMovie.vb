Public Class inputMovie

    'ロード時
    Private Sub inputMovie_Load(sender As Object, e As EventArgs) Handles Me.Load

        TextBox1.MaxLength = 2
        TextBox2.MaxLength = 30
        TextBox3.MaxLength = 1

    End Sub

    '追加完了ボタン
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Dim movieID, movieName, genreID As String
        Dim dao As New MovieDao

        movieID = TextBox1.Text

        movieName = TextBox2.Text

        genreID = TextBox3.Text

        If Not (movieID = "") And Not (movieName = "") And Not (genreID = "") Then

            Dim check As Boolean = dao.searchMovie(movieName)

            If check = True Then

                dao.addMovie(movieID, movieName, genreID)

                Dim f As New complete
                f.Show()
                My.Application.ApplicationContext.MainForm = f
                Me.Close()

            Else
                MsgBox("映画名は既に登録されています")
            End If

        End If

    End Sub

    '戻るボタン
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim f As New movieMaster
        f.Show()
        My.Application.ApplicationContext.MainForm = f
        Me.Close()
    End Sub

    '映画IDのtextboxに文字が入力されたとき
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress

        If (e.KeyChar < "0"c Or e.KeyChar > "9"c) And e.KeyChar <> vbBack Then
            e.Handled = True
        End If

    End Sub

    'ジャンルIDのtextboxに文字が入力されたとき
    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress

        If (e.KeyChar < "0"c Or e.KeyChar > "9"c) And e.KeyChar <> vbBack Then
            e.Handled = True
        End If

    End Sub

    '映画名のtextbox変更時
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

        If TextBox2.Text = " " Or TextBox2.Text = "　" Then

            TextBox2.Text = ""

        End If

    End Sub
End Class