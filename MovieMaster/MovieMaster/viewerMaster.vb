Public Class viewerMaster
<<<<<<< HEAD


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim result As DialogResult = MessageBox.Show(Me, "削除してもよろしいでしょうか", "削除", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)



=======
<<<<<<< HEAD

    Dim pegeingDao As New pegeingDao
    Dim deleteDao As New deleteDao
    Dim updateDao As New updateDao
    Dim util As New util
    Dim befBean As New viewerBean

    Dim maxpage As Integer = 0
    Dim page As Integer = 1
    Dim allCount As Integer
    Dim start As Integer = 0
    Dim stops As Integer = 4
    Sub viewerMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim infoDispList As New List(Of viewerBean)
        doReadOnly()
        allCount = pegeingDao.getCount()
        infoDispList = pegeingDao.getDispInfo1()

        If allCount Mod 4 = 0 Then
            maxpage = allCount / 4
        Else
            maxpage = (Int(allCount / 4 + 1))
        End If
        Console.WriteLine(allCount)
        Console.WriteLine(page)
        Console.WriteLine(maxpage)
        setInfo(infoDispList) 'データを表示

        buttonCheak()

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        util.forwardScreen(Me, inputViewer) '追加画面に遷移
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim aftBean As New viewerBean

        If Button2.Text = "変更" Then
            Button2.Text = "完了"
            befBean = getInfoSelectedRadio()
            releaseReadOnly()
        ElseIf Button2.Text = "完了" Then
            Button2.Text = "変更"
            aftBean = getInfoSelectedRadio()
            updateDao.updateProcess(befBean, aftBean)
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim bean As New viewerBean
        'メッセージボックスを表示する 
        Dim result As DialogResult = MessageBox.Show("削除する？",
                                             "質問",
                                             MessageBoxButtons.YesNoCancel,
                                             MessageBoxIcon.Exclamation,
                                             MessageBoxDefaultButton.Button2)
        '何が選択されたか調べる 
        If result = DialogResult.Yes Then
            bean = getInfoSelectedRadio()
            deleteDao.deleteProcess(bean)
        End If


    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim beanList As New List(Of viewerBean)
        doKuuhaku()

        If page > 0 Then
            page = page - 1
        End If

        If 4 < allCount Then
            start = start - 4
            stops = start + 3
            beanList = pegeingDao.getDispInfo2(start, stops)
        Else
            beanList = pegeingDao.getDispInfo2(0, 4)
        End If
        setInfo(beanList)
        buttonCheak()
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim beanList As New List(Of viewerBean)
        doKuuhaku()

        If page < maxpage Then
            page = page + 1
        End If

        If page * 4 < allCount Then
            start = stops + 1
            stops = start + 3
            beanList = pegeingDao.getDispInfo2(start, stops)
        Else
            start = stops + 1
            beanList = pegeingDao.getDispInfo2(start, allCount)
        End If
        setInfo(beanList)
        buttonCheak()

    End Sub

    'Viewer情報を表示する
    Sub setInfo(beanList As List(Of viewerBean))
        Dim bean As viewerBean

        If beanList.Count > 0 Then
            bean = beanList(0)
            TextBox1.Text = bean.getName
            RadioButton1.Text = bean.getId
        End If

        If beanList.Count > 1 Then
            bean = beanList(1)
            TextBox2.Text = bean.getName
            RadioButton2.Text = bean.getId
        End If

        If beanList.Count > 2 Then
            bean = beanList(2)
            TextBox3.Text = bean.getName
            RadioButton3.Text = bean.getId
        End If

        If beanList.Count > 3 Then
            bean = beanList(3)
            TextBox4.Text = bean.getName
            RadioButton4.Text = bean.getId
        End If

        Select Case beanList.Count
            Case 1
                RadioButton2.Enabled = False '押せなくする
                RadioButton3.Enabled = False
                RadioButton4.Enabled = False
            Case 2
                RadioButton3.Enabled = False
                RadioButton4.Enabled = False
            Case 3
                RadioButton4.Enabled = False
        End Select


    End Sub

    'ページングのボタンを押せるようにするか判定する
    Sub buttonCheak()
        If page < maxpage Then
            Me.Button7.Enabled = True
        Else
            Me.Button7.Enabled = False
        End If

        If page > 1 Then
            Me.Button5.Enabled = True
        Else
            Me.Button5.Enabled = False
        End If
    End Sub

    '全て空白に戻しEnabbledを解除する
    Sub doKuuhaku()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        RadioButton1.Text = ""
        RadioButton2.Text = ""
        RadioButton3.Text = ""
        RadioButton4.Text = ""
        RadioButton1.Enabled = True
        RadioButton2.Enabled = True
        RadioButton3.Enabled = True
        RadioButton4.Enabled = True

    End Sub

    '選択しているラジオボタンを検索し、textBox.textとRadioButton.textを取得する
    Function getInfoSelectedRadio()
        Dim name As String = ""
        Dim id As String = ""
        Dim bean As New viewerBean

        If RadioButton1.Checked = True Then
            name = TextBox1.Text
            id = RadioButton1.Text

        ElseIf RadioButton2.Checked = True Then
            name = TextBox2.Text
            id = RadioButton2.Text

        ElseIf RadioButton3.Checked = True Then
            name = TextBox3.Text
            id = RadioButton3.Text

        ElseIf RadioButton4.Text = True Then
            name = TextBox4.Text
            id = RadioButton4.Text
        End If

        bean.setName(name)
        bean.setId(id)
        Return bean
    End Function

    'ロード時にすべてのTextBoxのreadOnlyをtrueにする
    Sub doReadOnly()
        TextBox1.ReadOnly = True
        TextBox2.ReadOnly = True
        TextBox3.ReadOnly = True
        TextBox4.ReadOnly = True
    End Sub

    '編集ボタン押した際、該当するtextBoxのReadOnlyを解除する
    Sub releaseReadOnly()
        If RadioButton1.Checked = True Then
            TextBox1.ReadOnly = False
        ElseIf RadioButton2.Checked = True Then
            TextBox2.ReadOnly = False
        ElseIf RadioButton3.Checked = True Then
            TextBox3.ReadOnly = False
        ElseIf RadioButton4.Checked = True Then
            TextBox4.ReadOnly = False
        End If
>>>>>>> f43f48aef18949d58417ec67a06c183b440021ed
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        util.forwardScreen(Me, masterMenu)
    End Sub
=======


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim result As DialogResult = MessageBox.Show(Me, "削除してもよろしいでしょうか", "削除", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)



    End Sub

>>>>>>> origin/master
End Class
