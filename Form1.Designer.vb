<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ButtonSrc = New System.Windows.Forms.Button()
        Me.ButtonDst = New System.Windows.Forms.Button()
        Me.Label_src = New System.Windows.Forms.Label()
        Me.Label_dst = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CheckBox_overwrite = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBox_from = New System.Windows.Forms.ComboBox()
        Me.ComboBox_ret = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CheckBox_replaceword = New System.Windows.Forms.CheckBox()
        Me.ComboBox_to = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ButtonDoIt = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ButtonPresetWin = New System.Windows.Forms.Button()
        Me.ButtonPresetLinux = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonSrc
        '
        Me.ButtonSrc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonSrc.Location = New System.Drawing.Point(772, 32)
        Me.ButtonSrc.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.ButtonSrc.Name = "ButtonSrc"
        Me.ButtonSrc.Size = New System.Drawing.Size(28, 23)
        Me.ButtonSrc.TabIndex = 0
        Me.ButtonSrc.Text = "..."
        Me.ButtonSrc.UseVisualStyleBackColor = True
        '
        'ButtonDst
        '
        Me.ButtonDst.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonDst.Location = New System.Drawing.Point(772, 310)
        Me.ButtonDst.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.ButtonDst.Name = "ButtonDst"
        Me.ButtonDst.Size = New System.Drawing.Size(28, 23)
        Me.ButtonDst.TabIndex = 1
        Me.ButtonDst.Text = "..."
        Me.ButtonDst.UseVisualStyleBackColor = True
        '
        'Label_src
        '
        Me.Label_src.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_src.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label_src.Location = New System.Drawing.Point(12, 32)
        Me.Label_src.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.Label_src.Name = "Label_src"
        Me.Label_src.Size = New System.Drawing.Size(760, 23)
        Me.Label_src.TabIndex = 2
        '
        'Label_dst
        '
        Me.Label_dst.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_dst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label_dst.Location = New System.Drawing.Point(12, 310)
        Me.Label_dst.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.Label_dst.Name = "Label_dst"
        Me.Label_dst.Size = New System.Drawing.Size(760, 23)
        Me.Label_dst.TabIndex = 3
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(12, 95)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(786, 162)
        Me.ListView1.TabIndex = 4
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Name"
        Me.ColumnHeader1.Width = 200
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Size"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader2.Width = 74
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Modified"
        Me.ColumnHeader3.Width = 120
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Code"
        Me.ColumnHeader4.Width = 160
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Ret"
        Me.ColumnHeader5.Width = 80
        '
        'CheckBox_overwrite
        '
        Me.CheckBox_overwrite.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CheckBox_overwrite.AutoSize = True
        Me.CheckBox_overwrite.Location = New System.Drawing.Point(178, 285)
        Me.CheckBox_overwrite.Name = "CheckBox_overwrite"
        Me.CheckBox_overwrite.Size = New System.Drawing.Size(300, 21)
        Me.CheckBox_overwrite.TabIndex = 5
        Me.CheckBox_overwrite.Text = "コピーせずに元ファイルを上書きする(お勧めしない)"
        Me.CheckBox_overwrite.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 286)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 17)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "書き出し先フォルダ"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 17)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "読み込み元フォルダ"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 17)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "文字コード From"
        '
        'ComboBox_from
        '
        Me.ComboBox_from.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ComboBox_from.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_from.FormattingEnabled = True
        Me.ComboBox_from.Items.AddRange(New Object() {"自動", "Shift JIS", "UTF-8", "EUC-JP"})
        Me.ComboBox_from.Location = New System.Drawing.Point(16, 91)
        Me.ComboBox_from.Name = "ComboBox_from"
        Me.ComboBox_from.Size = New System.Drawing.Size(125, 24)
        Me.ComboBox_from.TabIndex = 9
        '
        'ComboBox_ret
        '
        Me.ComboBox_ret.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ComboBox_ret.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_ret.FormattingEnabled = True
        Me.ComboBox_ret.Items.AddRange(New Object() {"保持", "-> CRLF (Windows)", "-> LF     (Linux)"})
        Me.ComboBox_ret.Location = New System.Drawing.Point(323, 91)
        Me.ComboBox_ret.Name = "ComboBox_ret"
        Me.ComboBox_ret.Size = New System.Drawing.Size(173, 24)
        Me.ComboBox_ret.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(320, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 17)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "改行コード"
        '
        'CheckBox_replaceword
        '
        Me.CheckBox_replaceword.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CheckBox_replaceword.AutoSize = True
        Me.CheckBox_replaceword.Location = New System.Drawing.Point(16, 133)
        Me.CheckBox_replaceword.Name = "CheckBox_replaceword"
        Me.CheckBox_replaceword.Size = New System.Drawing.Size(386, 21)
        Me.CheckBox_replaceword.TabIndex = 12
        Me.CheckBox_replaceword.Text = "HTML/PHPファイルの場合は単語変換する ""utf-8"" ⇔ ""shift_jis"""
        Me.CheckBox_replaceword.UseVisualStyleBackColor = True
        '
        'ComboBox_to
        '
        Me.ComboBox_to.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ComboBox_to.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_to.FormattingEnabled = True
        Me.ComboBox_to.Items.AddRange(New Object() {"Shift JIS", "UTF-8", "EUC-JP"})
        Me.ComboBox_to.Location = New System.Drawing.Point(165, 91)
        Me.ComboBox_to.Name = "ComboBox_to"
        Me.ComboBox_to.Size = New System.Drawing.Size(125, 24)
        Me.ComboBox_to.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(162, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 17)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "文字コード To"
        '
        'ButtonDoIt
        '
        Me.ButtonDoIt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonDoIt.Location = New System.Drawing.Point(706, 480)
        Me.ButtonDoIt.Name = "ButtonDoIt"
        Me.ButtonDoIt.Size = New System.Drawing.Size(92, 45)
        Me.ButtonDoIt.TabIndex = 15
        Me.ButtonDoIt.Text = "変換"
        Me.ButtonDoIt.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 75)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(201, 17)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "変換したいファイルを選択（複数可）"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.ButtonPresetLinux)
        Me.GroupBox1.Controls.Add(Me.ButtonPresetWin)
        Me.GroupBox1.Controls.Add(Me.CheckBox_replaceword)
        Me.GroupBox1.Controls.Add(Me.ComboBox_from)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.ComboBox_ret)
        Me.GroupBox1.Controls.Add(Me.ComboBox_to)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 360)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(542, 165)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "変換に関する設定"
        '
        'ButtonPresetWin
        '
        Me.ButtonPresetWin.Location = New System.Drawing.Point(16, 21)
        Me.ButtonPresetWin.Name = "ButtonPresetWin"
        Me.ButtonPresetWin.Size = New System.Drawing.Size(145, 26)
        Me.ButtonPresetWin.TabIndex = 15
        Me.ButtonPresetWin.Text = "プリセット Windows"
        Me.ButtonPresetWin.UseVisualStyleBackColor = True
        '
        'ButtonPresetLinux
        '
        Me.ButtonPresetLinux.Location = New System.Drawing.Point(178, 21)
        Me.ButtonPresetLinux.Name = "ButtonPresetLinux"
        Me.ButtonPresetLinux.Size = New System.Drawing.Size(145, 26)
        Me.ButtonPresetLinux.TabIndex = 16
        Me.ButtonPresetLinux.Text = "プリセット Linux"
        Me.ButtonPresetLinux.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(810, 546)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ButtonDoIt)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CheckBox_overwrite)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Label_dst)
        Me.Controls.Add(Me.Label_src)
        Me.Controls.Add(Me.ButtonDst)
        Me.Controls.Add(Me.ButtonSrc)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "ソースファイルの文字エンコード変換"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonSrc As Button
    Friend WithEvents ButtonDst As Button
    Friend WithEvents Label_src As Label
    Friend WithEvents Label_dst As Label
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents CheckBox_overwrite As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboBox_from As ComboBox
    Friend WithEvents ComboBox_ret As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents CheckBox_replaceword As CheckBox
    Friend WithEvents ComboBox_to As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ButtonDoIt As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ButtonPresetLinux As Button
    Friend WithEvents ButtonPresetWin As Button
End Class
