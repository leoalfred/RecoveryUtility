Imports System.Environment
Imports System.IO
Imports System.Net
Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim x As Integer = 0 - 1
        x = x + 1
        If x = 0 Then
            MsgBox("WARNING! THIS OPTION IS STILL UNDER TESTING. MAY NOT WORK. CHECK THE AVAILABILITY OF ANY UPDATES.", MsgBoxStyle.Information, "WARNING!")
        End If
        Dim appData As String = GetFolderPath(SpecialFolder.ApplicationData)
        Dim irecovery As New Process()
        Try
            irecovery.StartInfo.UseShellExecute = False
            irecovery.StartInfo.FileName = appData + "\Enter.bat"
            irecovery.StartInfo.CreateNoWindow = True
        Catch ex As Exception
        End Try


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button2.Text = "Done! Re-click me to re-exit from Recovery Mode."
        Dim appData As String = GetFolderPath(SpecialFolder.ApplicationData)
        Dim irecovery As New Process()
        Try
            irecovery.StartInfo.UseShellExecute = False
            irecovery.StartInfo.FileName = appData + "\s-irecovery.exe"
            irecovery.StartInfo.CreateNoWindow = True
        Catch ex As Exception
        End Try

        'Executing autoboot command
        irecovery.StartInfo.Arguments = "-c " + """" + "setenv auto-boot true" + """"
        irecovery.Start()
        Do Until irecovery.HasExited = True

        Loop

        'Executing saveenv command
        irecovery.StartInfo.Arguments = "-c " + """" + "saveenv" + """"
        irecovery.Start()
        Do Until irecovery.HasExited = True

        Loop

        'Executing reboot command
        irecovery.StartInfo.Arguments = "-c " + """" + "reboot" + """"
        irecovery.Start()
        Do Until irecovery.HasExited = True

        Loop
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("http://leoalfre.altervista.org")
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Process.Start("http://github.com")
    End Sub
End Class
