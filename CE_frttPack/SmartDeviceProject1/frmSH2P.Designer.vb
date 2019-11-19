<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmSH2P
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
Me.MenuItem2 = New System.Windows.Forms.MenuItem
Me.txtFT = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.lblStatus = New System.Windows.Forms.Label
Me.Label1 = New System.Windows.Forms.Label
Me.txtSH = New System.Windows.Forms.TextBox
Me.cmdWrite = New System.Windows.Forms.Button
Me.SuspendLayout()
'
'mainMenu1
'
Me.mainMenu1.MenuItems.Add(Me.MenuItem1)
Me.mainMenu1.MenuItems.Add(Me.MenuItem2)
'
'MenuItem1
'
Me.MenuItem1.Text = "назад"
'
'MenuItem2
'
Me.MenuItem2.Text = "Очистить"
'
'txtFT
'
Me.txtFT.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold)
Me.txtFT.Location = New System.Drawing.Point(9, 67)
Me.txtFT.Name = "txtFT"
Me.txtFT.ReadOnly = True
Me.txtFT.Size = New System.Drawing.Size(220, 45)
Me.txtFT.TabIndex = 9
'
'Label3
'
Me.Label3.Location = New System.Drawing.Point(10, 49)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(78, 15)
Me.Label3.Text = "Тип фильтра"
'
'lblStatus
'
Me.lblStatus.Location = New System.Drawing.Point(3, 213)
Me.lblStatus.Name = "lblStatus"
Me.lblStatus.Size = New System.Drawing.Size(227, 43)
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(10, 0)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(204, 22)
Me.Label1.Text = "Штрихкод со сканера"
'
'txtSH
'
Me.txtSH.Location = New System.Drawing.Point(9, 25)
Me.txtSH.Name = "txtSH"
Me.txtSH.Size = New System.Drawing.Size(220, 21)
Me.txtSH.TabIndex = 12
'
'cmdWrite
'
Me.cmdWrite.Enabled = False
Me.cmdWrite.Location = New System.Drawing.Point(7, 118)
Me.cmdWrite.Name = "cmdWrite"
Me.cmdWrite.Size = New System.Drawing.Size(221, 92)
Me.cmdWrite.TabIndex = 13
Me.cmdWrite.Text = "Начать запись меток"
'
'frmSH2P
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
Me.AutoScroll = True
Me.ClientSize = New System.Drawing.Size(240, 268)
Me.ControlBox = False
Me.Controls.Add(Me.cmdWrite)
Me.Controls.Add(Me.txtSH)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.lblStatus)
Me.Controls.Add(Me.txtFT)
Me.Controls.Add(Me.Label3)
Me.Menu = Me.mainMenu1
Me.Name = "frmSH2P"
Me.Text = "Штрихкод->пластик"
Me.ResumeLayout(False)

End Sub
    Friend WithEvents txtFT As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSH As System.Windows.Forms.TextBox
    Friend WithEvents cmdWrite As System.Windows.Forms.Button
End Class
