<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class inputMovie
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(174, 308)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(122, 47)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "完了"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(236, 158)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(192, 39)
        Me.TextBox2.TabIndex = 10
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(236, 86)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(192, 39)
        Me.TextBox1.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(198, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 31)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "映画追加"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(56, 227)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 31)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "ジャンルID"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(75, 166)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 31)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "映画名"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(236, 224)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(192, 39)
        Me.TextBox3.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(75, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 31)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "映画ID"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(380, 346)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(91, 44)
        Me.Button4.TabIndex = 14
        Me.Button4.Text = "戻る"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'inputMovie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(14.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 402)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Margin = New System.Windows.Forms.Padding(7, 8, 7, 8)
        Me.Name = "inputMovie"
        Me.Text = "inputMovie"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Button4 As Button
End Class
