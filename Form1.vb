Public Class Form1
    Shared arTargetExts As String()
    Shared arReplaceWordsSJIS As String()
    Shared arReplaceWordsUTF8 As String()
    Shared arReplaceWordsEUCJP As String()

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        arTargetExts = My.Settings.target_exts.Split(";"c)
        arReplaceWordsSJIS = My.Settings.replace_words_sjis.Split(";"c)
        arReplaceWordsUTF8 = My.Settings.replace_words_utf8.Split(";"c)
        arReplaceWordsEUCJP = My.Settings.replace_words_eucjp.Split(";"c)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox_from.SelectedIndex = 0 '自動

        Dim n As Integer = arReplaceWordsSJIS.Count
        If n <> arReplaceWordsUTF8.Count OrElse n <> arReplaceWordsEUCJP.Count Then
            MsgBox("設定値 My.Setting.replace_words_XXX のワードの数が一致している必要があります")
            Application.Exit()
        End If

        'ウィンドウの大きさを復元
        Dim ar As String() = My.Settings.form_geometory.Split(","c)
        If ar.Count = 2 Then
            Me.Width = Integer.Parse(ar(0))
            Me.Height = Integer.Parse(ar(1))
        End If

        'カラムの幅を復元
        ar = My.Settings.form_geometory.Split(","c)
        If ar.Count = ListView1.Columns.Count Then
            For i As Integer = 0 To ListView1.Columns.Count - 1
                ListView1.Columns(i).Width = Integer.Parse(ar(i))
            Next
        End If

        'チェックボックス復元
        CheckBox_replaceword.Checked = My.Settings.replace_word
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        'ウィンドウの大きさを記憶
        My.Settings.form_geometory = Me.Width.ToString & ","c & Me.Height.ToString

        'カラムの幅を記憶
        Dim s As String = ""
        For i As Integer = 0 To ListView1.Columns.Count - 1
            If i > 0 Then s &= ","c
            s &= ListView1.Columns(i).Width.ToString
        Next
        My.Settings.listview_geometory = s

        My.Settings.replace_word = CheckBox_replaceword.Checked

    End Sub

    Private Sub ButtonSrc_Click(sender As Object, e As EventArgs) Handles ButtonSrc.Click
        Dim FolderBrowserDialog1 As New FolderBrowserDialog()
        FolderBrowserDialog1.Description = "読み込みフォルダの選択"
        ' ルートになる特殊フォルダを設定する (初期値 SpecialFolder.Desktop)
        FolderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer
        If My.Settings.src_folder.Length > 0 AndAlso IO.Directory.Exists(My.Settings.src_folder) Then
            FolderBrowserDialog1.SelectedPath = My.Settings.src_folder
        End If
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            My.Settings.src_folder = FolderBrowserDialog1.SelectedPath
            Label_src.Text = FolderBrowserDialog1.SelectedPath
            ScanFiles(FolderBrowserDialog1.SelectedPath, ListView1)
        End If
        FolderBrowserDialog1.Dispose()
    End Sub



    Private Class LVIDATA
        Public enc As Text.Encoding
        Public ret As RET
        Sub New(_enc As Text.Encoding, _ret As RET)
            enc = _enc
            ret = _ret
        End Sub
    End Class

    '渡されたディレクトリをスキャンし、リストビューに書き出す
    Private Sub ScanFiles(dir As String, lv As ListView)
        lv.Items.Clear()
        lv.BeginUpdate()

        'ディレクトリ内のファイル一覧を取得
        For Each path As String In IO.Directory.GetFiles(dir)

            '拡張子を取り出す
            Dim ext As String = IO.Path.GetExtension(path).ToUpper()

            'どの拡張子を対象にするかはMy.Settings.target_extsで定義している
            If Array.IndexOf(arTargetExts, ext) >= 0 Then

                'ファイル名を設定
                Dim lvi As New ListViewItem(IO.Path.GetFileName(path))

                'ファイルサイズを設定
                Dim fi As New IO.FileInfo(path)
                If fi.Length < 10000 Then
                    lvi.SubItems.Add(fi.Length.ToString("D") & "B"c)
                ElseIf fi.Length < 1000000 Then
                    lvi.SubItems.Add((fi.Length / 1000).ToString("F0") & "KB")
                ElseIf fi.Length < 1000000000 Then
                    lvi.SubItems.Add((fi.Length / 1000000).ToString("F0") & "MB")
                Else
                    lvi.SubItems.Add((fi.Length / 1000000000).ToString("F1") & "GB")
                End If

                '更新日時を設定
                lvi.SubItems.Add(fi.LastWriteTime.ToString("yyyy/MM/dd HH:ss"))

                'エンコードを取得
                Dim enc As Text.Encoding = Nothing
                Dim ret As RET = RET.Unknown
                GetCodeFromFile(path, enc, ret)

                If enc Is Nothing Then
                    lvi.SubItems.Add("Unknown")
                Else
                    lvi.SubItems.Add(enc.EncodingName)
                End If

                If ret = RET.LF Then
                    lvi.SubItems.Add("LF")
                ElseIf ret = ret.CrLf Then
                    lvi.SubItems.Add("CRLF")
                Else
                    lvi.SubItems.Add("Unknown")
                End If

                'エンコード情報はタグに記憶
                lvi.Tag = New LVIDATA(enc, ret)
                lv.Items.Add(lvi)
            End If
        Next
        lv.EndUpdate()
    End Sub

    Private Sub CheckBox_overwrite_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_overwrite.CheckedChanged
        Label_dst.Enabled = Not CheckBox_overwrite.Checked
        ButtonDst.Enabled = Not CheckBox_overwrite.Checked
    End Sub

    Private Sub ButtonDst_Click(sender As Object, e As EventArgs) Handles ButtonDst.Click
        Dim FolderBrowserDialog1 As New FolderBrowserDialog()
        FolderBrowserDialog1.Description = "書き込みフォルダの選択"
        ' ルートになる特殊フォルダを設定する (初期値 SpecialFolder.Desktop)
        FolderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer
        If My.Settings.dst_folder.Length > 0 AndAlso IO.Directory.Exists(My.Settings.dst_folder) Then
            FolderBrowserDialog1.SelectedPath = My.Settings.dst_folder
        End If
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            My.Settings.dst_folder = FolderBrowserDialog1.SelectedPath
            Label_dst.Text = FolderBrowserDialog1.SelectedPath
        End If
        FolderBrowserDialog1.Dispose()
    End Sub

    'Windows的な設定
    Private Sub ButtonPresetWin_Click(sender As Object, e As EventArgs) Handles ButtonPresetWin.Click
        ComboBox_from.SelectedIndex = 0 '自動
        ComboBox_to.SelectedIndex = 0   'SJIS
        ComboBox_ret.SelectedIndex = 1  'CRLF
    End Sub

    'Linux的な設定
    Private Sub ButtonPresetLinux_Click(sender As Object, e As EventArgs) Handles ButtonPresetLinux.Click
        ComboBox_from.SelectedIndex = 0 '自動
        ComboBox_to.SelectedIndex = 1   'UTF8
        ComboBox_ret.SelectedIndex = 2  'LF
    End Sub

    Private Enum ENCTYPE
        Other
        SJIS
        UTF8
        EUCJP
    End Enum

    Private Sub ButtonDoIt_Click(sender As Object, e As EventArgs) Handles ButtonDoIt.Click

        'コンボボックスの選択状態を取得

        Dim _from As Text.Encoding
        Select Case ComboBox_from.SelectedIndex
            Case 0 : _from = Nothing'自動
            Case 1 : _from = System.Text.Encoding.GetEncoding(932) 'sjis
            Case 2 : _from = System.Text.Encoding.GetEncoding(65001) 'utf8
            Case 3 : _from = System.Text.Encoding.GetEncoding(51932) 'euc-jp
            Case Else
                MsgBox("不明な文字コード指定(From)", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly)
                Exit Sub
        End Select

        Dim _to As Text.Encoding
        Dim enctype As ENCTYPE
        Select Case ComboBox_to.SelectedIndex
            Case 0
                _to = System.Text.Encoding.GetEncoding(932)    'sjis
                enctype = ENCTYPE.SJIS
            Case 1
                _to = New Text.UTF8Encoding(False)             'utf8(BOM無し)
                enctype = ENCTYPE.UTF8
            Case 2
                _to = System.Text.Encoding.GetEncoding(51932)  'euc-jp
                enctype = ENCTYPE.EUCJP
            Case Else
                MsgBox("不明な文字コード指定(To)", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly)
                Exit Sub
        End Select

        Dim _ret As RET
        Select Case ComboBox_ret.SelectedIndex
            Case 0 : _ret = RET.Keep'保持
            Case 1 : _ret = RET.CRLF
            Case 2 : _ret = RET.LF
            Case Else
                MsgBox("不明な改行コード指定", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly)
                Exit Sub
        End Select

        If ListView1.SelectedItems.Count = 0 Then
            If MsgBox("ファイルが選択されていません。" & vbNewLine & "すべてのファイルを変換しますか？", MsgBoxStyle.Question Or MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
                Exit Sub
            Else
                '全選択
                For Each lvi As ListViewItem In ListView1.Items
                    lvi.Selected = True
                Next
            End If
        End If

        '選択されたファイルをチェック
        For Each lvi As ListViewItem In ListView1.SelectedItems
            Dim srcPath As String = Label_src.Text & "\" & lvi.Text
            If Not IO.File.Exists(srcPath) Then
                MsgBox("存在しないファイルがあります。" & vbNewLine & "読み込み元フォルダを再選択してください。" & vbNewLine & vbNewLine & srcPath, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            Dim lvidata As LVIDATA = lvi.Tag

            If _from Is Nothing AndAlso lvidata.enc Is Nothing Then
                MsgBox("エンコードの不明なファイルが含まれています。" & vbNewLine & "これらは自動で変換できません。", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly)
                Exit Sub
            End If
        Next

        '選択されたファイルを順番に処理
        Dim count As Integer = 0
        For Each lvi As ListViewItem In ListView1.SelectedItems
            Dim srcPath As String = Label_src.Text & "\" & lvi.Text
            Dim dstPath As String
            If CheckBox_overwrite.Checked Then
                dstPath = srcPath
            Else
                dstPath = Label_dst.Text & "\" & lvi.Text
            End If

            Dim lvidata As LVIDATA = lvi.Tag

            '読み込むエンコードを決定
            Dim enc As Text.Encoding
            If _from Is Nothing Then
                enc = lvidata.enc '自動
            Else
                enc = _from '指定
            End If

            'ファイルからすべて読み込む
            Dim str As String = IO.File.ReadAllText(srcPath, enc)

            If _ret <> RET.Keep Then
                '一旦LFにする
                str = str.Replace(vbCrLf, vbLf)
                If _ret = RET.CRLF Then
                    'CRLFにする
                    str = str.Replace(vbLf, vbCrLf)
                End If
            End If

            '文字コードを表すワードを置換する
            If CheckBox_replaceword.Checked AndAlso enctype <> ENCTYPE.Other Then

                Dim replaceWords As String() = {} '置換先のワード配列を指す
                Select Case enctype
                    Case ENCTYPE.SJIS : replaceWords = arReplaceWordsSJIS
                    Case ENCTYPE.UTF8 : replaceWords = arReplaceWordsUTF8
                    Case ENCTYPE.EUCJP : replaceWords = arReplaceWordsEUCJP
                End Select

                '置換元になるワードは元のエンコーディングに関係なしに、全部試している（雑）
                If enctype <> ENCTYPE.SJIS Then
                    For i As Integer = 0 To arReplaceWordsSJIS.Count - 1
                        Dim word As String = arReplaceWordsSJIS(i)
                        If word.Length > 0 Then str = str.Replace(word, replaceWords(i)) '完全一致したときだけ置換（改良したい）
                    Next
                End If
                If enctype <> ENCTYPE.UTF8 Then
                    For i As Integer = 0 To arReplaceWordsUTF8.Count - 1
                        Dim word As String = arReplaceWordsUTF8(i)
                        If word.Length > 0 Then str = str.Replace(word, replaceWords(i))
                    Next
                End If
                If enctype <> ENCTYPE.EUCJP Then
                    For i As Integer = 0 To arReplaceWordsEUCJP.Count - 1
                        Dim word As String = arReplaceWordsEUCJP(i)
                        If word.Length > 0 Then str = str.Replace(word, replaceWords(i))
                    Next
                End If
            End If

            'ファイルにすべて書き込む
            IO.File.WriteAllText(dstPath, str, _to)
            count += 1
        Next

        MsgBox("変換しました。 " & count.ToString & " Files")
    End Sub


    Private Enum RET As Byte
        Unknown = 0
        Keep = 0
        LF = 1
        CRLF = 2
    End Enum

    'ファイルを分析し、推定される文字エンコードと改行コードを返す
    Private Shared Sub GetCodeFromFile(path As String, ByRef enc As System.Text.Encoding, ByRef ret As RET)
        Dim fs As New System.IO.FileStream(path, IO.FileMode.Open, IO.FileAccess.Read)
        Dim bs As Byte() = New Byte(4095) {}
        enc = Nothing
        ret = RET.Unknown
        Do
            Dim readSize As Integer = fs.Read(bs, 0, bs.Length)
            If readSize = 0 Then Exit Do 'ファイルの最後まで読んだら終わり

            '文字エンコードを調査
            If enc Is Nothing OrElse enc Is System.Text.Encoding.ASCII Then
                enc = GetCode(bs, readSize)
            End If

            '改行コードを調査
            If ret = RET.Unknown Then
                Dim i As Integer = Array.IndexOf(bs, CByte(10)) 'LF
                If i >= 0 Then ret = RET.LF
                If i > 0 AndAlso bs(i - 1) = CByte(13) Then ret = RET.CRLF 'CRLF
            End If

            'エンコードと改行コードが判明したら終了
            If ret <> RET.Unknown AndAlso enc IsNot Nothing Then Exit Do
        Loop
        fs.Close()
    End Sub

    ''' <summary>
    ''' 文字コードを判別する
    ''' </summary>
    ''' <remarks>
    ''' Jcode.pmのgetcodeメソッドを移植したものです。
    ''' Jcode.pm(http://openlab.ring.gr.jp/Jcode/index-j.html)
    ''' Jcode.pmの著作権情報
    ''' Copyright 1999-2005 Dan Kogai <dankogai@dan.co.jp>
    ''' This library is free software; you can redistribute it and/or modify it
    '''  under the same terms as Perl itself.
    ''' </remarks>
    ''' <param name="bytes">文字コードを調べるデータ</param>
    ''' <returns>適当と思われるEncodingオブジェクト。
    ''' 判断できなかった時はnull。</returns>
    Private Shared Function GetCode(ByVal bytes As Byte(), len As Integer) As System.Text.Encoding
        Const bEscape As Byte = &H1B
        Const bAt As Byte = &H40
        Const bDollar As Byte = &H24
        Const bAnd As Byte = &H26
        Const bOpen As Byte = &H28 ''('
        Const bB As Byte = &H42
        Const bD As Byte = &H44
        Const bJ As Byte = &H4A
        Const bI As Byte = &H49

        Dim b1 As Byte, b2 As Byte, b3 As Byte, b4 As Byte

        'Encode::is_utf8 は無視

        Dim isBinary As Boolean = False
        Dim i As Integer
        For i = 0 To len - 1
            b1 = bytes(i)
            If b1 <= &H6 OrElse b1 = &H7F OrElse b1 = &HFF Then
                ''binary'
                isBinary = True
                If b1 = &H0 AndAlso i < len - 1 AndAlso bytes(i + 1) <= &H7F Then
                    'smells like raw unicode
                    Return System.Text.Encoding.Unicode
                End If
            End If
        Next
        If isBinary Then
            Return Nothing
        End If

        'not Japanese
        Dim notJapanese As Boolean = True
        For i = 0 To len - 1
            b1 = bytes(i)
            If b1 = bEscape OrElse &H80 <= b1 Then
                notJapanese = False
                Exit For
            End If
        Next
        If notJapanese Then
            Return System.Text.Encoding.ASCII
        End If

        For i = 0 To len - 3
            b1 = bytes(i)
            b2 = bytes(i + 1)
            b3 = bytes(i + 2)

            If b1 = bEscape Then
                If b2 = bDollar AndAlso b3 = bAt Then
                    'JIS_0208 1978
                    'JIS
                    Return System.Text.Encoding.GetEncoding(50220)
                ElseIf b2 = bDollar AndAlso b3 = bB Then
                    'JIS_0208 1983
                    'JIS
                    Return System.Text.Encoding.GetEncoding(50220)
                ElseIf b2 = bOpen AndAlso (b3 = bB OrElse b3 = bJ) Then
                    'JIS_ASC
                    'JIS
                    Return System.Text.Encoding.GetEncoding(50220)
                ElseIf b2 = bOpen AndAlso b3 = bI Then
                    'JIS_KANA
                    'JIS
                    Return System.Text.Encoding.GetEncoding(50220)
                End If
                If i < len - 3 Then
                    b4 = bytes(i + 3)
                    If b2 = bDollar AndAlso b3 = bOpen AndAlso b4 = bD Then
                        'JIS_0212
                        'JIS
                        Return System.Text.Encoding.GetEncoding(50220)
                    End If
                    If i < len - 5 AndAlso
                        b2 = bAnd AndAlso b3 = bAt AndAlso b4 = bEscape AndAlso
                        bytes(i + 4) = bDollar AndAlso bytes(i + 5) = bB Then
                        'JIS_0208 1990
                        'JIS
                        Return System.Text.Encoding.GetEncoding(50220)
                    End If
                End If
            End If
        Next

        'should be euc|sjis|utf8
        'use of (?:) by Hiroki Ohzaki <ohzaki@iod.ricoh.co.jp>
        Dim sjis As Integer = 0
        Dim euc As Integer = 0
        Dim utf8 As Integer = 0
        For i = 0 To len - 2
            b1 = bytes(i)
            b2 = bytes(i + 1)
            If ((&H81 <= b1 AndAlso b1 <= &H9F) OrElse
                (&HE0 <= b1 AndAlso b1 <= &HFC)) AndAlso
                ((&H40 <= b2 AndAlso b2 <= &H7E) OrElse
                 (&H80 <= b2 AndAlso b2 <= &HFC)) Then
                'SJIS_C
                sjis += 2
                i += 1
            End If
        Next
        For i = 0 To len - 2
            b1 = bytes(i)
            b2 = bytes(i + 1)
            If ((&HA1 <= b1 AndAlso b1 <= &HFE) AndAlso
                (&HA1 <= b2 AndAlso b2 <= &HFE)) OrElse
                (b1 = &H8E AndAlso (&HA1 <= b2 AndAlso b2 <= &HDF)) Then
                'EUC_C
                'EUC_KANA
                euc += 2
                i += 1
            ElseIf i < len - 2 Then
                b3 = bytes(i + 2)
                If b1 = &H8F AndAlso (&HA1 <= b2 AndAlso b2 <= &HFE) AndAlso
                    (&HA1 <= b3 AndAlso b3 <= &HFE) Then
                    'EUC_0212
                    euc += 3
                    i += 2
                End If
            End If
        Next
        For i = 0 To len - 2
            b1 = bytes(i)
            b2 = bytes(i + 1)
            If (&HC0 <= b1 AndAlso b1 <= &HDF) AndAlso
                (&H80 <= b2 AndAlso b2 <= &HBF) Then
                'UTF8
                utf8 += 2
                i += 1
            ElseIf i < len - 2 Then
                b3 = bytes(i + 2)
                If (&HE0 <= b1 AndAlso b1 <= &HEF) AndAlso
                    (&H80 <= b2 AndAlso b2 <= &HBF) AndAlso
                    (&H80 <= b3 AndAlso b3 <= &HBF) Then
                    'UTF8
                    utf8 += 3
                    i += 2
                End If
            End If
        Next
        'M. Takahashi's suggestion
        'utf8 += utf8 / 2;

        Debug.WriteLine(String.Format("sjis = {0}, euc = {1}, utf8 = {2}", sjis, euc, utf8))
        If euc > sjis AndAlso euc > utf8 Then
            'EUC
            Return System.Text.Encoding.GetEncoding(51932)
        ElseIf sjis > euc AndAlso sjis > utf8 Then
            'SJIS
            Return System.Text.Encoding.GetEncoding(932)
        ElseIf utf8 > euc AndAlso utf8 > sjis Then
            'UTF8
            Return System.Text.Encoding.UTF8
        End If

        Return Nothing
    End Function

End Class
