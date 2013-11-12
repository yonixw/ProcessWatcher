<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.niMain = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.rtb = New System.Windows.Forms.RichTextBox()
        Me.tmr1 = New System.Windows.Forms.Timer(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.dlgOpen = New System.Windows.Forms.OpenFileDialog()
        Me.SuspendLayout()
        '
        'niMain
        '
        Me.niMain.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.niMain.Icon = CType(resources.GetObject("niMain.Icon"), System.Drawing.Icon)
        Me.niMain.Text = "Process Watcher"
        Me.niMain.Visible = True
        '
        'rtb
        '
        Me.rtb.Location = New System.Drawing.Point(12, 12)
        Me.rtb.Name = "rtb"
        Me.rtb.ReadOnly = True
        Me.rtb.Size = New System.Drawing.Size(384, 231)
        Me.rtb.TabIndex = 0
        Me.rtb.Text = ""
        '
        'tmr1
        '
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(321, 249)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Exit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(240, 249)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Calc MD5"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'dlgOpen
        '
        Me.dlgOpen.Title = "Select file to checksum..."
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(408, 281)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.rtb)
        Me.Name = "frmMain"
        Me.Text = "Process Watcher"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents niMain As System.Windows.Forms.NotifyIcon
    Friend WithEvents rtb As System.Windows.Forms.RichTextBox
    Friend WithEvents tmr1 As System.Windows.Forms.Timer
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents dlgOpen As System.Windows.Forms.OpenFileDialog

End Class
