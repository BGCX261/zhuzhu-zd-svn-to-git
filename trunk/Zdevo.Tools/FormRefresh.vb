Public Class FormRefresh

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        BackgroundWorker1.RunWorkerAsync()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        BackgroundWorker2.RunWorkerAsync()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        BackgroundWorker3.RunWorkerAsync()

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        BackgroundWorker4.RunWorkerAsync()

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

        BackgroundWorker5.RunWorkerAsync()

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click

        BackgroundWorker6.RunWorkerAsync()

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click

        BackgroundWorker7.RunWorkerAsync()

    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        Dim s As String = "http://picasaweb.google.com/data/feed/base/user/rainbowsoft?kind=album&alt=rss&hl=zh_CN&access=public"

        zdevo_editPicasa(s)

    End Sub

    Private Sub BackgroundWorker2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork

        Dim s As String = "http://api.flickr.com/services/feeds/photos_public.gne?id=82775984@N00&lang=en-us&format=rss2"

        zdevo_editFlickr(s)

    End Sub

    Private Sub BackgroundWorker3_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker3.DoWork

        Dim s As String = "http://api.fanfou.com/statuses/user_timeline.rss?id=zxasd"

        zdevo_editFanfou(s)

    End Sub

    Private Sub BackgroundWorker4_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker4.DoWork

        Dim s As String = "http://feeds.delicious.com/rss/rainbowsoft"

        zdevo_editDelicious(s)

    End Sub

    Private Sub BackgroundWorker5_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker5.DoWork

        Dim s As String = "http://twitter.com/statuses/user_timeline/13548852.rss"

        zdevo_editTwitter(s)

    End Sub

    Private Sub BackgroundWorker6_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker6.DoWork

        Dim s As String = "http://www.365key.com/rss/rainbowsoft/"

        zdevo_edit365Key(s)

    End Sub

    Private Sub BackgroundWorker7_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker7.DoWork

        Dim s As String = "http://www.yupoo.com/services/feeds/photos?user_id=ff80808117e3fb00011821774c5820f0"

        zdevo_editYupoo(s)

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click

        Dim s As String = "http://www.douban.com/feed/people/2202159/interests"

        zdevo_editDouban(s)


    End Sub
End Class