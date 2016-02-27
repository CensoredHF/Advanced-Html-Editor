Public Class Settings
#Region "Code"
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Form1.RichTextBox1.BackColor = Color.FromArgb(40, 44, 52)
            Form1.BackColor = Color.FromArgb(40, 44, 52)
            Form1.ToolStrip1.BackColor = Color.FromArgb(40, 44, 52)
            Form1.RichTextBox1.ForeColor = Color.White
            Form1.ListBox1.BackColor = Color.FromArgb(35, 35, 35)
            Form1.ListBox1.ForeColor = Color.White
            Form1.ToolStrip1.ForeColor = Color.White
            Form1.TreeView1.BackColor = Color.FromArgb(40, 44, 52)
            Form1.TreeView1.ForeColor = Color.White
            Form1.LoadColors()
            Dim loc As Int16
            If Form1.RichTextBox1.Text.Contains("Heading") Then
                loc = Form1.RichTextBox1.Find("Heading")
                Form1.RichTextBox1.Select(loc, 7)
                Form1.RichTextBox1.SelectionColor = Color.White
            End If
        ElseIf CheckBox1.Checked = False Then
            Form1.RichTextBox1.BackColor = Color.White
            Form1.BackColor = Color.White
            Form1.ToolStrip1.BackColor = Color.White
            Form1.RichTextBox1.BackColor = Color.White
            Form1.ListBox1.BackColor = Color.White
            Form1.ListBox1.ForeColor = Color.Black
            Form1.RichTextBox1.ForeColor = Color.Black
            Form1.ToolStrip1.ForeColor = Color.Black
            Form1.TreeView1.ForeColor = Color.Black
            Form1.TreeView1.BackColor = Color.White
            Form1.LoadColors()
            Dim loc As Int16
            If Form1.RichTextBox1.Text.Contains("Heading") Then
                loc = Form1.RichTextBox1.Find("Heading")
                Form1.RichTextBox1.Select(loc, 7)
                Form1.RichTextBox1.SelectionColor = Color.Black
            End If
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim FontShow As New FontDialog
        If FontShow.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim fontName As String
            Dim fontSize As Integer
            fontName = FontShow.Font.Name
            fontSize = FontShow.Font.Size

            TextBox1.Text = (fontName & " , " & fontSize)
            Form1.RichTextBox1.Font = New Font(fontName, fontSize, FontStyle.Regular)
        End If
    End Sub
    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            My.Settings.SaveDialog = "1"
            My.Settings.Save()
        ElseIf CheckBox3.Checked = False Then
            My.Settings.SaveDialog = "0"
            My.Settings.Save()
        End If
    End Sub
    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.SaveDialog = "1" Then
            CheckBox3.Checked = True
        ElseIf My.Settings.SaveDialog = "0" Then
            CheckBox3.Checked = False
        End If
        If My.Settings.Html = "1" Then
            CheckBox4.Checked = True
        ElseIf My.Settings.Html = "0" Then
            CheckBox4.Checked = False
        End If
    End Sub
    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.Checked = True Then
            My.Settings.Html = "1"
            My.Settings.Save()
        ElseIf CheckBox4.Checked = False Then
            My.Settings.Html = "0"
            My.Settings.Save()
        End If
    End Sub
#End Region
End Class