Imports System.ComponentModel
Imports System.IO
Imports System.Threading
Imports System.Windows.Forms.DataFormats
Imports BlinkStickDotNet


Public Class frmMain
    Dim BS As BlinkStick
    Dim sColor As String = ""
    Dim sColorOld As String = ""
    Dim sTeamsStatus = ""
    Dim sUserProfile As String = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
    Dim sTeamsLogFile As String = sUserProfile & "\AppData\Roaming\Microsoft\Teams\logs.txt"
    Dim bBlinking As Boolean = False
    Dim bBlinkingOld As Boolean = False

    Private Sub bSetColor_Click(sender As Object, e As EventArgs) Handles bSetColor.Click
        BS = BlinkStick.FindFirst()
        If BS IsNot Nothing Then
            If BS.OpenDevice() Then
                'BS.SetMode(2)         'istn' working right.  hmm
                'BS.SetColor("red")
                'BS.Blink("red")
                'mode    0 - Normal, 1 - Inverse, 2 - WS2812
                'BS.Morph("red")
                'BS.Pulse("red", 1, 1000, 50)
                sColor = txtColor.Text
                BS.SetColor(0, 0, sColor)
                BS.SetColor(0, 1, sColor)
            End If
        Else
            MsgBox("BlinkStick not found.", MsgBoxStyle.Critical, "BlinkStick for Teams")
        End If
    End Sub

    Private Sub tmrLightConrol_Tick(sender As Object, e As EventArgs) Handles tmrLightControl.Tick
        lblTeamsStatus.Text = sTeamsStatus
        tmrLightControl.Enabled = False
        If sColor IsNot sColorOld Then
            sColorOld = sColor
            BS = BlinkStick.FindFirst()
            If BS IsNot Nothing Then
                If BS.OpenDevice() Then
                    BS.SetColor(0, 0, sColor)
                    BS.SetColor(0, 1, sColor)
                End If
            End If
        End If
        If bBlinking = True Then
            tmrBlinkControl.Enabled = True
        Else
            tmrBlinkControl.Enabled = False
        End If
    End Sub

    Private Sub subCheckTeams()
        Dim logFileStream As New FileStream(sTeamsLogFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
        Dim logFileReader As New StreamReader(logFileStream)
        Dim sLogLine As String
        Dim sStatusLine As String   'StatusIndicatorStateService

        While Not logFileReader.EndOfStream
            sLogLine = logFileReader.ReadLine()
            If InStr(sLogLine, "StatusIndicatorStateService") Then
                sStatusLine = sLogLine
            End If
        End While

        If InStr(sStatusLine, "Available") Then
            sTeamsStatus = "Available"
            bBlinking = False
            sColor = "green"
            lblTeamsColor.BackColor = Color.Green

        ElseIf InStr(sStatusLine, "Away") Then
            sTeamsStatus = "Away"
            bBlinking = False
            sColor = "black"
            lblTeamsColor.BackColor = Color.Black

        ElseIf InStr(sStatusLine, "OnThePhone") Then
            sTeamsStatus = "OnThePhone"
            bBlinking = True
            sColor = "red"
            lblTeamsColor.BackColor = Color.Red

        ElseIf InStr(sStatusLine, "InAMeeting") Then
            sTeamsStatus = "InAMeeting"
            bBlinking = False
            sColor = "red"
            lblTeamsColor.BackColor = Color.Red

        ElseIf InStr(sStatusLine, "DoNotDisturb") Then
            sTeamsStatus = "DoNotDisturb"
            bBlinking = True
            sColor = "red"
            lblTeamsColor.BackColor = Color.Red

        ElseIf InStr(sStatusLine, "Presenting") Then
            sTeamsStatus = "Presenting"
            bBlinking = True
            sColor = "red"
            lblTeamsColor.BackColor = Color.Red

        ElseIf InStr(sStatusLine, "Busy") Then
            sTeamsStatus = "Busy"
            bBlinking = False
            sColor = "red"
            lblTeamsColor.BackColor = Color.Red

        ElseIf InStr(sStatusLine, "Offline") Then
            sTeamsStatus = "Offline"
            bBlinking = False
            sColor = "black"
            lblTeamsColor.BackColor = Color.Black

        ElseIf InStr(sStatusLine, "BeRightBack") Then
            sTeamsStatus = "BeRightBack"
            bBlinking = True
            sColor = "purple"
            lblTeamsColor.BackColor = Color.Purple

        Else
            sTeamsStatus = sStatusLine
            bBlinking = False
            sColor = "black"
            lblTeamsColor.BackColor = Color.Black

        End If

        lblTeamsStatus.Text = sTeamsStatus
        If sColor = sColorOld And bBlinking = bBlinkingOld Then
        Else
            tmrLightControl.Enabled = True
        End If

        logFileReader = Nothing
        logFileStream = Nothing

    End Sub
    Private Sub tmrCheckTeams_Tick(sender As Object, e As EventArgs) Handles tmrCheckTeams.Tick
        subCheckTeams()
    End Sub

    Private Sub frmMain_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing
        BS = BlinkStick.FindFirst()
        If BS IsNot Nothing Then
            If BS.OpenDevice() Then
                BS.SetColor(0, 0, "black")
                BS.SetColor(0, 1, "black")
                BS.TurnOff()
            End If
        End If
    End Sub

    Private Sub bTestButton_Click(sender As Object, e As EventArgs) Handles bTestButton.Click
        BS = BlinkStick.FindFirst()
        If BS IsNot Nothing Then
            If BS.OpenDevice() Then
                'BS.SetColor(0, 0, "red")
                'BS.SetColor(0, 1, "red")

                'Thread.Sleep(1000)
                BS.Blink(0, 0, "purple")
                BS.Blink(0, 1, "purple")
                'mode    0 - Normal, 1 - Inverse, 2 - WS2812
                'BS.Morph("red")
                'BS.Pulse("red", 1, 1000, 50)
            End If
        End If
    End Sub

    Private Sub tmrBlinkControl_Tick(sender As Object, e As EventArgs) Handles tmrBlinkControl.Tick
        bBlinkingOld = bBlinking
        BS = BlinkStick.FindFirst()
        If BS IsNot Nothing Then
            If BS.OpenDevice() Then
                BS.Blink(sColor)
                'mode    0 - Normal, 1 - Inverse, 2 - WS2812
                'BS.Morph("red")
                'BS.Pulse("red", 1, 1000, 50)
            End If
        End If
    End Sub
End Class
