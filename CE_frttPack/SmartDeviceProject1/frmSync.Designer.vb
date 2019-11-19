<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmSync
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Private mainMenu1 As System.Windows.Forms.MainMenu

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.cmdSync = New System.Windows.Forms.Button
        Me.pbPhase = New System.Windows.Forms.ProgressBar
        Me.txtOut = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.Add(Me.MenuItem1)
        '
        'MenuItem1
        '
        Me.MenuItem1.Text = "Закрыть"
        '
        'cmdSync
        '
        Me.cmdSync.Location = New System.Drawing.Point(28, 15)
        Me.cmdSync.Name = "cmdSync"
        Me.cmdSync.Size = New System.Drawing.Size(181, 48)
        Me.cmdSync.TabIndex = 0
        Me.cmdSync.Text = "Начать синхронизацию"
        '
        'pbPhase
        '
        Me.pbPhase.Location = New System.Drawing.Point(28, 69)
        Me.pbPhase.Name = "pbPhase"
        Me.pbPhase.Size = New System.Drawing.Size(181, 26)
        '
        'txtOut
        '
        Me.txtOut.Location = New System.Drawing.Point(31, 113)
        Me.txtOut.Multiline = True
        Me.txtOut.Name = "txtOut"
        Me.txtOut.Size = New System.Drawing.Size(177, 133)
        Me.txtOut.TabIndex = 1
        '
        'frmSync
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtOut)
        Me.Controls.Add(Me.pbPhase)
        Me.Controls.Add(Me.cmdSync)
        Me.Menu = Me.mainMenu1
        Me.Name = "frmSync"
        Me.Text = "Синхронизация"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdSync As System.Windows.Forms.Button
    Friend WithEvents pbPhase As System.Windows.Forms.ProgressBar
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents txtOut As System.Windows.Forms.TextBox
End Class
