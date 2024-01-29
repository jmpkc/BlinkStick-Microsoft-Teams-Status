<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try

    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        bSetColor = New Button()
        tmrLightControl = New Timer(components)
        txtColor = New TextBox()
        Label1 = New Label()
        lblTeamsStatus = New Label()
        tmrCheckTeams = New Timer(components)
        lblTeamsColor = New Label()
        bTestButton = New Button()
        tmrBlinkControl = New Timer(components)
        SuspendLayout()
        ' 
        ' bSetColor
        ' 
        bSetColor.Location = New Point(24, 28)
        bSetColor.Name = "bSetColor"
        bSetColor.Size = New Size(101, 39)
        bSetColor.TabIndex = 0
        bSetColor.Text = "Set Color"
        bSetColor.UseVisualStyleBackColor = True
        ' 
        ' tmrLightControl
        ' 
        tmrLightControl.Enabled = True
        tmrLightControl.Interval = 1000
        ' 
        ' txtColor
        ' 
        txtColor.Location = New Point(24, 73)
        txtColor.Name = "txtColor"
        txtColor.Size = New Size(100, 23)
        txtColor.TabIndex = 4
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(148, 28)
        Label1.Name = "Label1"
        Label1.Size = New Size(78, 15)
        Label1.TabIndex = 5
        Label1.Text = "Teams Status:"
        ' 
        ' lblTeamsStatus
        ' 
        lblTeamsStatus.Location = New Point(232, 28)
        lblTeamsStatus.Name = "lblTeamsStatus"
        lblTeamsStatus.Size = New Size(184, 90)
        lblTeamsStatus.TabIndex = 6
        lblTeamsStatus.Text = "NoData"
        ' 
        ' tmrCheckTeams
        ' 
        tmrCheckTeams.Enabled = True
        tmrCheckTeams.Interval = 3000
        ' 
        ' lblTeamsColor
        ' 
        lblTeamsColor.BackColor = Color.Black
        lblTeamsColor.Location = New Point(168, 52)
        lblTeamsColor.Name = "lblTeamsColor"
        lblTeamsColor.Size = New Size(33, 25)
        lblTeamsColor.TabIndex = 7
        ' 
        ' bTestButton
        ' 
        bTestButton.Location = New Point(26, 164)
        bTestButton.Name = "bTestButton"
        bTestButton.Size = New Size(99, 32)
        bTestButton.TabIndex = 8
        bTestButton.Text = "Test"
        bTestButton.UseVisualStyleBackColor = True
        ' 
        ' tmrBlinkControl
        ' 
        tmrBlinkControl.Interval = 1000
        ' 
        ' frmMain
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(420, 259)
        Controls.Add(bTestButton)
        Controls.Add(lblTeamsColor)
        Controls.Add(lblTeamsStatus)
        Controls.Add(Label1)
        Controls.Add(txtColor)
        Controls.Add(bSetColor)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "frmMain"
        Text = "BlinkStick Teams Status"
        ResumeLayout(False)
        PerformLayout()
        'Me.Text = "Form1"
    End Sub

    Friend WithEvents bSetColor As Button
    Friend WithEvents tmrLightControl As Timer
    Friend WithEvents txtColor As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblTeamsStatus As Label
    Friend WithEvents tmrCheckTeams As Timer
    Friend WithEvents lblTeamsColor As Label
    Friend WithEvents bTestButton As Button
    Friend WithEvents tmrBlinkControl As Timer


End Class
