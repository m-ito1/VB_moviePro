Public Class movieMaster

    Private list As List(Of String())
    Private page As Integer = 0
    Private maxPage As Integer
    Private count As Integer = 0
    Private updateFlag As Boolean = False
    Private returnFlag As Boolean = False
    Private radio As String = ""

    '画面ロード時
    Private Sub movieMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim dao As New MovieDao

        list = dao.getMovieName()

        For i As Integer = 0 To 3

            If i >= 0 And i < list.Count() Then

                Select Case i

                    Case 0
                        TextBox1.Text = list(i)(1)
                        RadioButton1.Text = list(i)(0)
                        RadioButton1.Enabled = True
                    Case 1
                        TextBox2.Text = list(i)(1)
                        RadioButton2.Text = list(i)(0)
                        RadioButton2.Enabled = True
                    Case 2
                        TextBox3.Text = list(i)(1)
                        RadioButton3.Text = list(i)(0)
                        RadioButton3.Enabled = True
                    Case 3
                        TextBox4.Text = list(i)(1)
                        RadioButton4.Text = list(i)(0)
                        RadioButton4.Enabled = True


                End Select

            Else

                Exit For

            End If

            count = count + 1

        Next

        emptyProcess(count)

        count = 0

    End Sub

    '追加ボタン
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim f As New inputMovie
        f.Show()
        My.Application.ApplicationContext.MainForm = f
        Me.Close()

    End Sub

    ' >>のボタン
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        For i As Integer = page + 4 To page + 7

            If i >= 0 And i < list.Count() Then

                pagingSurport(i, 0)


            Else
                If count >= 1 Then

                    page = page + 4

                End If

                Exit For

            End If

            count = count + 1

        Next

        If count = 4 Then

            page = page + 4

        End If

        emptyProcess(count)

        count = 0

    End Sub

    '  <<のボタン
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        For i As Integer = page - 4 To page - 1

            If i >= 0 And i < list.Count() Then

                pagingSurport(i, 1)

            Else

                If count >= 1 Then

                    page = page - 4

                End If

                Exit For

            End If

            count = count + 1

        Next

        If count = 4 Then

            page = page - 4

        End If

        count = 0

    End Sub

    '更新ボタン
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If updateFlag = False Then

            getRadio()

            For Each rb As RadioButton In GroupBox1.Controls.OfType(Of RadioButton)

                If Not (rb.Checked) Then

                    rb.Enabled = False

                End If

            Next

            Select Case radio
                Case 1
                    TextBox1.ReadOnly = False

                Case 2
                    TextBox2.ReadOnly = False

                Case 3
                    TextBox3.ReadOnly = False

                Case 4
                    TextBox4.ReadOnly = False


            End Select

            Button2.Text = "完了"
            Button1.Enabled = False
            Button3.Enabled = False
            Button5.Enabled = False
            Button6.Enabled = False

            returnFlag = True
            updateFlag = True

        ElseIf updateFlag = True Then

            Dim dao As New MovieDao
            Dim movieName As String = ""
            Dim movieID As String = ""

            Select Case radio
                Case 1
                    movieName = TextBox1.Text
                    movieID = RadioButton1.Text

                Case 2
                    movieName = TextBox2.Text
                    movieID = RadioButton2.Text

                Case 3
                    movieName = TextBox3.Text
                    movieID = RadioButton3.Text

                Case 4
                    movieName = TextBox4.Text
                    movieID = RadioButton4.Text


            End Select

            dao.updateMovie(movieName, movieID)

            Dim f As New complete
            f.Show()
            My.Application.ApplicationContext.MainForm = f
            Me.Close()

        End If

    End Sub

    '削除ボタン
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim result As DialogResult = MessageBox.Show(Me, "削除してもよろしいでしょうか", "削除",
                                                     MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)

        If result = 6 Then

            Dim dao As New MovieDao
            Dim movieName As String = ""
            Dim movieID As String = ""

            getRadio()

            Select Case radio
                Case 1

                    movieID = RadioButton1.Text

                Case 2

                    movieID = RadioButton2.Text

                Case 3

                    movieID = RadioButton3.Text

                Case 4

                    movieID = RadioButton4.Text


            End Select

            dao.deleteMovie(movieID)

            Dim f As New complete
            f.Show()
            My.Application.ApplicationContext.MainForm = f
            Me.Close()

        End If

    End Sub

    '戻るボタン
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        If returnFlag = False Then

            Dim f As New masterMenu
            f.Show()
            My.Application.ApplicationContext.MainForm = f
            Me.Close()

        ElseIf returnFlag = True Then
            Dim f As New movieMaster
            f.Show()
            My.Application.ApplicationContext.MainForm = f
            Me.Close()
        End If
    End Sub

    'ラジオボタン確認処理
    Sub getRadio()
        For Each rb As RadioButton In GroupBox1.Controls.OfType(Of RadioButton)

            If rb.Checked Then

                radio = rb.Tag

            End If

        Next
    End Sub

    'ページング時の余白の処理
    Sub emptyProcess(count As Integer)

        Select Case count
            Case 1
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""

                RadioButton2.Text = ""
                RadioButton3.Text = ""
                RadioButton4.Text = ""

                RadioButton2.Enabled = False
                RadioButton3.Enabled = False
                RadioButton4.Enabled = False

            Case 2
                TextBox3.Text = ""
                TextBox4.Text = ""

                RadioButton3.Text = ""
                RadioButton4.Text = ""

                RadioButton3.Enabled = False
                RadioButton4.Enabled = False

            Case 3
                TextBox4.Text = ""

                RadioButton4.Text = ""

                RadioButton4.Enabled = False

        End Select
    End Sub

    'ページング処理
    Sub pagingSurport(i As Integer, j As Integer)

        If j = 0 Then

            Select Case i

                Case page + 4
                    TextBox1.Text = list(i)(1)
                    RadioButton1.Text = list(i)(0)
                    RadioButton1.Enabled = True
                Case page + 5
                    TextBox2.Text = list(i)(1)
                    RadioButton2.Text = list(i)(0)
                    RadioButton2.Enabled = True
                Case page + 6
                    TextBox3.Text = list(i)(1)
                    RadioButton3.Text = list(i)(0)
                    RadioButton3.Enabled = True
                Case page + 7
                    TextBox4.Text = list(i)(1)
                    RadioButton4.Text = list(i)(0)
                    RadioButton4.Enabled = True

            End Select

        ElseIf j = 1 Then

            Select Case i

                Case page - 1
                    TextBox4.Text = list(i)(1)
                    RadioButton4.Text = list(i)(0)
                    RadioButton4.Enabled = True
                Case page - 2
                    TextBox3.Text = list(i)(1)
                    RadioButton3.Text = list(i)(0)
                    RadioButton3.Enabled = True
                Case page - 3
                    TextBox2.Text = list(i)(1)
                    RadioButton2.Text = list(i)(0)
                    RadioButton2.Enabled = True
                Case page - 4
                    TextBox1.Text = list(i)(1)
                    RadioButton1.Text = list(i)(0)
                    RadioButton1.Enabled = True

            End Select

        End If
    End Sub

End Class