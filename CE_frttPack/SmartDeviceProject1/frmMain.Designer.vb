<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmMain
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
Me.cmdDecode = New System.Windows.Forms.Button
Me.packB2P = New System.Windows.Forms.Button
Me.cmdSync = New System.Windows.Forms.Button
Me.packSH2P = New System.Windows.Forms.Button
Me.MenuItem2 = New System.Windows.Forms.MenuItem
Me.SuspendLayout()
'
'mainMenu1
'
Me.mainMenu1.MenuItems.Add(Me.MenuItem1)
Me.mainMenu1.MenuItems.Add(Me.MenuItem2)
'
'MenuItem1
'
Me.MenuItem1.Text = "Выход"
'
'cmdDecode
'
Me.cmdDecode.Location = New System.Drawing.Point(8, 195)
Me.cmdDecode.Name = "cmdDecode"
Me.cmdDecode.Size = New System.Drawing.Size(218, 30)
Me.cmdDecode.TabIndex = 0
Me.cmdDecode.Text = "Расшифровать метку"
'
'packB2P
'
Me.packB2P.Location = New System.Drawing.Point(9, 95)
Me.packB2P.Name = "packB2P"
Me.packB2P.Size = New System.Drawing.Size(217, 83)
Me.packB2P.TabIndex = 2
Me.packB2P.Text = "КАРТОН->ПЛАСТИК"
'
'cmdSync
'
Me.cmdSync.Location = New System.Drawing.Point(9, 231)
Me.cmdSync.Name = "cmdSync"
Me.cmdSync.Size = New System.Drawing.Size(215, 34)
Me.cmdSync.TabIndex = 5
Me.cmdSync.Text = "Синхронизация"
'
'packSH2P
'
Me.packSH2P.Location = New System.Drawing.Point(9, 7)
Me.packSH2P.Name = "packSH2P"
Me.packSH2P.Size = New System.Drawing.Size(214, 76)
Me.packSH2P.TabIndex = 6
Me.packSH2P.Text = "ШТРИХКОД->ПЛАСТИК"
'
'MenuItem2
'
Me.MenuItem2.Text = "Версия"
'
'frmMain
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
Me.AutoScroll = True
Me.ClientSize = New System.Drawing.Size(240, 268)
Me.ControlBox = False
Me.Controls.Add(Me.packSH2P)
Me.Controls.Add(Me.cmdSync)
Me.Controls.Add(Me.packB2P)
Me.Controls.Add(Me.cmdDecode)
Me.Menu = Me.mainMenu1
Me.Name = "frmMain"
Me.Text = "FRTT"
Me.ResumeLayout(False)

End Sub
    Friend WithEvents cmdDecode As System.Windows.Forms.Button
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents packB2P As System.Windows.Forms.Button
    Friend WithEvents cmdSync As System.Windows.Forms.Button
    Friend WithEvents packSH2P As System.Windows.Forms.Button
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem

End Class
