Public Class FormGuestBook

    Private Sub FormGuestBook_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        WebBrowser1.DocumentText = "<html><body></body></html>"
        Dim doc As mshtml.IHTMLDocument2 = WebBrowser1.Document.DomDocument
        doc.designMode = "On"

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim s As String = WebBrowser1.DocumentText.Replace(vbCrLf, "")

        Dim r As Regex = New Regex("(<BODY>)(.+?)(</BODY>)", RegexOptions.ECMAScript)

        Dim m As Match = r.Match(s)

        Dim t As String = ""

        While m.Success
            t += m.Groups(2).Value
            m = m.NextMatch()
        End While

        Dim r1 As Regex = New Regex("(<[^>]+>)", RegexOptions.ECMAScript)

        Dim m1 As Match = r1.Match(t)

        While m1.Success
            t = t.Replace(m1.Groups(1).Value, m1.Groups(1).Value.ToLower)
            m1 = m1.NextMatch()
        End While

        WebBrowser1.DocumentText = t

        BackgroundWorker1.RunWorkerAsync(WebBrowser1.DocumentText)

    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork


        zdevo_editGuestBook(Me.TextBox1.Text, e.Argument(0))

        Me.Close()

    End Sub
End Class