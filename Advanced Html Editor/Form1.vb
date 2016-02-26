Imports System.IO

Public Class Form1
#Region "Dims"
    Dim Temp As String = "C:\Users\" & Environment.UserName.ToString & "\AppData\Local\Temp\index.htm"
    Dim startline As String
    Dim curserline As String
    Dim CloseForm As String = String.Empty
    Dim curserpos As Integer
    Dim word As String
    Dim x As Integer
    Dim back As Boolean = False
    Dim AutoComplete As New List(Of String)
#End Region
#Region "Code"
    Public Sub LoadColors()
        Try
            Dim loc As Int16
            If RichTextBox1.Text.Contains("<!DOCTYPE") Then
                loc = RichTextBox1.Find("<!DOCTYPE")
                RichTextBox1.Select(loc, 9)
                RichTextBox1.SelectionColor = Color.DarkOrange
            End If
            Dim wordslist As New List(Of String)
            wordslist.Add("<html>")
            wordslist.Add(" html>")
            wordslist.Add("</html>")
            wordslist.Add("<body>")
            wordslist.Add("</body>")
            Dim len As Integer = RichTextBox1.TextLength
            For Each word As String In wordslist
                Dim lastindex = RichTextBox1.Text.LastIndexOf(word)
                Dim index As Integer = 0
                While index < lastindex
                    RichTextBox1.Find(word, index, len, RichTextBoxFinds.None)
                    RichTextBox1.SelectionColor = Color.DeepPink
                    index = RichTextBox1.Text.IndexOf(word, index) + 1
                End While
            Next
            NextColor()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub NextColor()
        Dim wordslist As New List(Of String)
        wordslist.Add("<h1>")
        wordslist.Add("</h1>")
        wordslist.Add("<p>")
        wordslist.Add("</p>")
        Dim len As Integer = RichTextBox1.TextLength
        For Each word As String In wordslist
            Dim lastindex = RichTextBox1.Text.LastIndexOf(word)
            Dim index As Integer = 0
            While index < lastindex
                RichTextBox1.Find(word, index, len, RichTextBoxFinds.None)
                RichTextBox1.SelectionColor = Color.LightSalmon
                index = RichTextBox1.Text.IndexOf(word, index) + 1
            End While
        Next
        Dim loc As Int16
        If RichTextBox1.Text.Contains("Heading") Then
            loc = RichTextBox1.Find("Heading")
            RichTextBox1.Select(loc, 7)
            RichTextBox1.SelectionColor = Color.Black
        End If
    End Sub
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If CloseForm = "1" Then
            End
        Else
        End If
        If My.Settings.SaveDialog = "1" Then
            Dim PopSaveDialog As Integer = MessageBox.Show("Do you want to save changes to Untitled?", "Advanced Html Editor", MessageBoxButtons.YesNoCancel)
            If PopSaveDialog = DialogResult.Cancel Then
            ElseIf PopSaveDialog = DialogResult.No Then
                End
            ElseIf PopSaveDialog = DialogResult.Yes Then

                SaveFileDialog1.Filter = "Text Files (*.txt*)|*.txt | Html Files (*.html*)|*.html"
                If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK _
                Then
                    Dim sw As New System.IO.StreamWriter(SaveFileDialog1.FileName)
                    For Each sLine As String In RichTextBox1.Lines
                        sw.WriteLine(sLine)
                    Next
                    sw.Close()
                    CloseForm = "1"
                    Me.Close()
                End If
            Else
            End If
        End If
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CloseForm = "0"
        LoadColors()
        AddWords()
        If My.Settings.Html = "0" Then
            RichTextBox1.Text = ""
            RichTextBox1.ForeColor = Color.Black
        Else
        End If
    End Sub
    Private Sub AddWords()
        AutoComplete.Add("<!DOCTYPE html>")
        AutoComplete.Add("<html>")
        AutoComplete.Add("</html>")
        AutoComplete.Add("true")
        AutoComplete.Add("false")
        AutoComplete.Add("<body>")
        AutoComplete.Add("</body>")
        AutoComplete.Add("<h1>")
        AutoComplete.Add("</h1>")
        AutoComplete.Add("<h2>")
        AutoComplete.Add("</h2>")
        AutoComplete.Add("default")
        AutoComplete.Add("else")
        AutoComplete.Add("<script>")
        AutoComplete.Add("</script>")
        AutoComplete.Add("for")
        AutoComplete.Add("var")
        AutoComplete.Add("goto")
        AutoComplete.Add("if")
        AutoComplete.Add("long")
        AutoComplete.Add("register")
        AutoComplete.Add("return")
        AutoComplete.Add("document")
        AutoComplete.Add("getElementById")
        AutoComplete.Add("sizeof")
        AutoComplete.Add("static")
        AutoComplete.Add("struct")
        AutoComplete.Add("switch")
        AutoComplete.Add("length")
        AutoComplete.Add("union")
        AutoComplete.Add("unsigned")
        AutoComplete.Add("</footer>")
        AutoComplete.Add("<footer>")
        AutoComplete.Add("while")
        AutoComplete.Add("string")
        AutoComplete.Add("end")
        AutoComplete.Add("next")
        AutoComplete.Add("each")
        AutoComplete.Add(My.Settings.textbox)
        AutoComplete.Add("<ol>")
        AutoComplete.Add("</ol>")
        AutoComplete.Add("<li>")
        AutoComplete.Add("</li>")
        AutoComplete.Add("<ul>")
        AutoComplete.Add("</ul>")
        AutoComplete.Add("<i>")
        AutoComplete.Add("</i>")
        AutoComplete.Add("<p>")
        AutoComplete.Add("</p>")
        AutoComplete.Add("<iframe src="""">")
        AutoComplete.Add("</iframe>")
        AutoComplete.Add(My.Settings.image)
        AutoComplete.Add("<form>")
        AutoComplete.Add("</form>")
        AutoComplete.Add("<del>")
        AutoComplete.Add("</del>")
        AutoComplete.Add("<ins>")
        AutoComplete.Add("</ins>")
        AutoComplete.Add("<select>")
        AutoComplete.Add("</select>")
        AutoComplete.Add("<option value=""""></option>")
        AutoComplete.Add("</option>")
        AutoComplete.Add("confirm")
        AutoComplete.Add(My.Settings.css)
        AutoComplete.Add(My.Settings.link)
        AutoComplete.Add("<style>")
        AutoComplete.Add("</style>")
        '
        AutoComplete.Add("<table>")
        AutoComplete.Add("</table>")
        AutoComplete.Add("<tr>")
        AutoComplete.Add("</tr>")
        AutoComplete.Add("<td>")
        AutoComplete.Add("</td>")
        AutoComplete.Add("<th>")
        AutoComplete.Add("</th>")
        AutoComplete.Add(My.Settings.htmlenglish)

        AutoComplete.Add("<nav>")
        AutoComplete.Add("</nav>")
    End Sub
    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Settings.Show()
    End Sub
    Private Sub ToolStripDropDownButton1_ButtonClick(sender As Object, e As EventArgs) Handles ToolStripDropDownButton1.ButtonClick
        If IndoorToolStripMenuItem1.Checked = True Then
            WebBrowser1.Document.OpenNew(True)
            My.Computer.FileSystem.WriteAllText(Temp, RichTextBox1.Text, False)
            WebBrowser1.Document.Write(IO.File.ReadAllText(Temp))
        ElseIf WindowedToolStripMenuItem1.Checked = True Then
            My.Computer.FileSystem.WriteAllText(Temp, RichTextBox1.Text, False)
            Compiler.Show()
        ElseIf IndoorToolStripMenuItem1.Checked + WindowedToolStripMenuItem1.Checked = True Then
            WebBrowser1.Document.OpenNew(True)
            My.Computer.FileSystem.WriteAllText(Temp, RichTextBox1.Text, False)
            WebBrowser1.Document.Write(IO.File.ReadAllText(Temp))
            Compiler.Show()

        ElseIf BrowserToolStripMenuItem.Checked = True Then
            My.Computer.FileSystem.WriteAllText(Temp, RichTextBox1.Text, False)
            Process.Start(Temp)
        Else
            WebBrowser1.Document.OpenNew(True)
            My.Computer.FileSystem.WriteAllText(Temp, RichTextBox1.Text, False)
            WebBrowser1.Document.Write(IO.File.ReadAllText(Temp))
        End If
    End Sub
    Private Sub ExitToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem1.Click
        End
    End Sub
    Private Sub SettingsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem1.Click
        Settings.Show()
    End Sub
    Private Sub NewToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem1.Click
        RichTextBox1.Text = My.Settings.NewText
        LoadColors()
    End Sub
    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        OpenFileDialog1.Filter = "Text Files (*.txt)|*.txt|Html (*.html)|*.html*"
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK _
        Then
            Me.RichTextBox1.LoadFile(OpenFileDialog1.FileName, RichTextBoxStreamType.PlainText)
            TabControl1.SelectedTab.Text = Path.GetFileName(OpenFileDialog1.FileName)
            Me.Text = "Advanced Html Editor - " + Path.GetFileName(OpenFileDialog1.FileName)
        End If
    End Sub
    Private Sub OpenNewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenNewToolStripMenuItem.Click
        Dim newTab As New TabPage()
        newTab.Text = "Untitled"
        Dim Textbox As New RichTextBox
        Textbox.Dock = DockStyle.Fill
        Textbox.BorderStyle = BorderStyle.None
        Textbox.Font = New Font("Consolas", 14, FontStyle.Regular)
        newTab.Controls.Add(Textbox)
        TabControl1.TabPages.Add(newTab)
        TabControl1.SelectedTab = newTab
    End Sub
    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        TabControl1.TabPages.Remove(TabControl1.SelectedTab)
    End Sub
    Private Sub TabControl1_MouseMove(sender As Object, e As MouseEventArgs) Handles TabControl1.MouseMove
        If Settings.CheckBox2.Checked = True Then
            If (e.Button = MouseButtons.Left) Then
                TabControl1.DoDragDrop(TabControl1.SelectedTab, DragDropEffects.Move)
            End If
        Else
        End If
    End Sub
    Private Sub TabControl1_GiveFeedback(sender As Object, e As GiveFeedbackEventArgs) Handles TabControl1.GiveFeedback
        If Settings.CheckBox2.Checked = True Then
            e.UseDefaultCursors = False
        Else
        End If
    End Sub
    Private Sub TabControl1_QueryContinueDrag(sender As Object, e As QueryContinueDragEventArgs) Handles TabControl1.QueryContinueDrag
        If Settings.CheckBox2.Checked = True Then
            If Control.MouseButtons <> MouseButtons.Left Then
                e.Action = DragAction.Cancel
                Dim f As New Form
                f.Size = New Size(400, 300)
                f.StartPosition = FormStartPosition.Manual
                f.Location = MousePosition
                Dim tc As New TabControl
                tc.Dock = DockStyle.Fill
                tc.TabPages.Add(TabControl1.SelectedTab)
                f.Controls.Add(tc)
                f.Show()
                Me.Cursor = Cursors.Default
            Else
                e.Action = DragAction.Continue
                Me.Cursor = Cursors.Help
            End If
        Else
        End If
    End Sub
    Private Sub SaveAsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem1.Click
        SaveFileDialog1.Filter = "Text Files (*.txt*)|*.txt | Html Files (*.html*)|*.html"
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK _
        Then
            Dim sw As New System.IO.StreamWriter(SaveFileDialog1.FileName)
            For Each sLine As String In RichTextBox1.Lines
                sw.WriteLine(sLine)
            Next
            sw.Close()
            TabControl1.SelectedTab.Text = Path.GetFileName(SaveFileDialog1.FileName)
            Me.Text = "Advanced Html Editor - " + Path.GetFileName(SaveFileDialog1.FileName)
        End If
    End Sub
    Public Sub Save()
        Try
            Dim sw As New System.IO.StreamWriter(OpenFileDialog1.FileName)
            For Each sLine As String In RichTextBox1.Lines
                sw.WriteLine(sLine)
            Next
            sw.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub SaveToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem1.Click
        Save()
    End Sub
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Save()
    End Sub
    Private Sub RichTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles RichTextBox1.KeyDown
        If e.KeyCode = Keys.Tab And ListBox1.Visible Then
            RichTextBox1.SelectedText = Mid(ListBox1.SelectedItem, word.Length + 1, ListBox1.SelectedItem.ToString.Length - word.Length)
            e.SuppressKeyPress = True
            ListBox1.Visible = False
        ElseIf e.KeyCode = Keys.Tab And Not ListBox1.Visible Then
            RichTextBox1.SelectedText = "    "
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Up And ListBox1.Visible Then
            If ListBox1.SelectedIndex <> 0 Then
                ListBox1.SetSelected(ListBox1.SelectedIndex - 1, True)
            End If
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Down And ListBox1.Visible Then
            If ListBox1.SelectedIndex <> ListBox1.Items.Count - 1 Then
                ListBox1.SetSelected(ListBox1.SelectedIndex + 1, True)
            End If
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Left And ListBox1.Visible Then
            ListBox1.Visible = False
        ElseIf e.KeyCode = Keys.Right And ListBox1.Visible Then
            ListBox1.Visible = False
        End If
    End Sub
    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged
        Try
            ListBox1.Visible = False
            ListBox1.Items.Clear()
            startline = RichTextBox1.GetLineFromCharIndex(RichTextBox1.SelectionStart)
            curserline = RichTextBox1.GetLineFromCharIndex(RichTextBox1.SelectionStart)
            curserpos = RichTextBox1.SelectionStart

            While Mid(RichTextBox1.Text, curserpos, 1) <> vbTab And Mid(RichTextBox1.Text, curserpos, 1) <> " " And Mid(RichTextBox1.Text, curserpos, 1) <> "." And Mid(RichTextBox1.Text, curserpos, 1) <> "=" And Mid(RichTextBox1.Text, curserpos, 1) <> "(" And Mid(RichTextBox1.Text, curserpos, 1) <> ")" And Mid(RichTextBox1.Text, curserpos, 1) <> "," And Mid(RichTextBox1.Text, curserpos, 1) <> "&" And Mid(RichTextBox1.Text, curserpos, 1) <> "!" And curserline = startline
                curserpos -= 1
                curserline = RichTextBox1.GetLineFromCharIndex(curserpos)
            End While

            If curserline = startline Then
                word = Mid(RichTextBox1.Text, curserpos + 1, RichTextBox1.SelectionStart - curserpos)
            Else
                word = Mid(RichTextBox1.Text, curserpos + 2, RichTextBox1.SelectionStart - curserpos - 1)
            End If

            If curserline = startline Then
                x = curserpos - RichTextBox1.GetFirstCharIndexOfCurrentLine
            Else
                x = curserpos + 1 - RichTextBox1.GetFirstCharIndexOfCurrentLine
            End If
            Dim y As Integer = RichTextBox1.GetLineFromCharIndex(RichTextBox1.GetFirstCharIndexOfCurrentLine) - RichTextBox1.GetLineFromCharIndex(RichTextBox1.GetCharIndexFromPosition(New Point(0, 0)))

            Dim xfin As Integer = 13 + 8 * x
            Dim yfin As Integer = 30 + 16 * y
            ListBox1.Location = New Point(xfin, yfin)

            For Each auto As String In AutoComplete
                If auto.StartsWith(word) = True And word <> "" And word <> " " Then
                    ListBox1.Items.Add(auto)
                End If
            Next

            If ListBox1.Items.Count <> 0 Then
                ListBox1.Visible = True
                ListBox1.SetSelected(0, True)
            End If

        Catch ex As Exception

        End Try
    End Sub
#End Region
End Class