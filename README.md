# SJISxUTF8
VB.NET Windowsアプリケーション：ソースファイルの文字エンコード変換

Web系プログラムはutf8でコーディングすることが多いのですが、今回たまたま
使用するサーバーがWindowsでShiftJISがデフォルトだったため、ソース移動時
に毎回コード変換するのが面倒になったので簡単なアプリケーションを作成しま
した。

<機能>
フォルダ内のHTMLやPHPのソースコードを選択し、別のフォルダにコード変換して
書き出します。

<対応文字コード>
utf-8 euc-jp shift_jis

<対応改行コード>
CRLF LF

対応ファイルはプロジェクトのプロパティからSettingを直接変更してください。
（GUIから変更できるようにはやってません）

<開発環境>
VS2017 community, VB.NET

<主な参考サイト>
DOBON.NET
https://dobon.net/vb/dotnet/string/detectcode.html
