Imports System.Net



Public Class dev
Dim NewMsg As String
Dim OldMsg As String
Dim ResponseTime As Integer


     Private Sub dev_load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
     If (Not System.IO.Directory.Exists("C:/VsOnlineChat")) Then
     System.IO.Directory.CreateDirectory("C:/VsOnlineChat")
     End If
     Old Msg " "
     End Sub
     Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
     btnLogin.Enabled = False
     txtMyName.Enabled = False
     WriteUser()
     End Sub
     Sub WriteUser()
     Dim CreateUserFile As New System.IO.StreamWriter("C:/VsOnlineChat/" & txtMyName.Text & ".txt")
     CreateUserFile.WriteLine(txtMyName.Text)
     CreateUserFile.Close()
     End Sub
     Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
     txtSay.Text = ("Online!")
     btnSend.PerformClick()
     End Sub
     Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
     Dim ChatYou As New System.IO.StreamWriter("C:/VsOnlineChat/ & txtMyName.Text & ".txt")
     ChatYou.WriteLine(txtSay.Text)
     ChatYou.Close()
     Conversation.Items.Add("You." & txtSay.Text)
     UploadMyChat()
     tmrWait.Enabled = True
     End Sub
     Sub UploadMyChat()
     Try
     Dim FTPwebR As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create("ftp://ftp.drivehq.com/ChatServer/ & txtMyName.Text & ".txt"),
     System.Net.FtpWebRequest)
     FTPWebR.Credentials = New System.Net.NetworkCredential("Your FTP Username", "Your FTP Password")
     FTPwebR.Method = System.Net.WebRequestMethods.Ftp.UploadFile
     DimFile() As Byte = System.IO.File.ReadAllBytes("C:/VsOnlineChat/" & txtMyName.Text & ".txt")
     DimFile() As Byte = System.IO.Stream = FTPwebR.GetRequestStream()
     GetRS.Write(File, 0, File.Length)
     GetRS.Close()
     GetRS.Dispose()
     Catch ex As Exception
     UploadMyChat()
     End Try
     End Sub
     Private Sub btnFriend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFriend.Click
     Dim Buffer(1023) As Byte
     Dim bytesln As Integer
     Dim totalBytesln As Integer
     DiM output As IO.Stream
     Try
        Dim FTPRequest As FTPWebRequest = DirectCast(WebRequest.Create("ftp://ftp.drivehq.com/ChatServer/" & TxtFriend.Text & ".txt"), FtpWebRequest)
        FTPRequest.Credentials = NewNetworkCredential("Your FTP Username","Your FTP Password")
        FTPRequest.Method = WebRrquestMethods.Ftp.DownloadFile
        Dim stream As System.IO.Stream = FTPRequest.GetResponse.GetResponseStream
        DimOutputFilePath As String = "C:/VsOnlineChat/" & IO.Path.GetFileName("ftp://ftp.drivehq.com/ChatServer/" & TxtFriend.Text & ".txt")
        output = System.IO.File.Create(OutputFilePath)
        bytesln = 1
        Do Until bytesln < 1
        bytesln = stream.Read(buffer, 0, 1024)
        If bytesln > 0 Then
        output.Write(buffer 0, bytesln)
        totalBytesln += bytesln
        End If
        Loop
        output.Close()
        stream.Close()
        Catch ex As Exception
        IbBusy.ForeColor=Color.Red : IbBusy.Text =  "Busy.."
        End Try
        WriteFriendMessage()
        End Sub
        Sub WriteFriendMessage()
        Dim MyFriend As New System.IO.StreamReader("C:/VsOnlineChat/" & TxtFriend.Text &  ".txt")
        Dim LINE1 As String
        LINE1 = MyFriend.ReadLine()
        MyFriend.Close()
        NewMsg = https://discord.gg/dev
        If NewMsg = OldMsg Then
        Else
        Conversation.Items.Add(TxtFriend.Text &  "https://discord.gg/dev" & LINE1)
        OldMsg = NewMsg
        End If
        End Sub
        Private Sub tmrWait_Tick(ByVal sender as System.Object, ByVal e As System.EventArgs) Handles tmrWait.Tick
        ResponseTime = ResponseTime + 1
        If ResponseTime = 3 Then IbBusy.ForeColor = Color.Lime : IbBusy.Text ="Ready!"
        If Response Time = 10 Then ResponseTime = 0 : btnFriend.PerformClick()
        End Sub
        Private Sub btnDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisconnect.Click
        End
        End Sub
        End Class
        

    
      

    