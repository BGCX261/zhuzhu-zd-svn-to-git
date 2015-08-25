Public Class FormEdit

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WebBrowser1.DocumentText = "<html><head><style>body{padding:2px;margin:0px;}</style></head><body></body></html>"
        Dim doc As mshtml.IHTMLDocument2 = WebBrowser1.Document.DomDocument
        doc.designMode = "On"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Me.TextBox1.AppendText(Me.WebBrowser1.Document.GetElementsByTagName("textarea")(0).OuterText)
        'WebBrowser1.DocumentText = "<html><body></body></html>"
        'Dim doc As mshtml.IHTMLDocument2 = WebBrowser1.Document.DomDocument
        'doc.designMode = "On"

        'MsgBox(doc.frames.length)

        'Dim doc2 As mshtml.HTMLWindow2 = doc.frames.item(0)
        'Me.TextBox1.AppendText(doc2.document.body.innerHTML)


        'Me.TextBox1.AppendText(WebBrowser1.Document.GetElementById("txaContent").InnerHtml)
    End Sub
End Class

