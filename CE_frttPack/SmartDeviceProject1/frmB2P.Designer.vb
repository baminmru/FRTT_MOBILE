<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmB2P
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
        Me.mnuClose = New System.Windows.Forms.MenuItem
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtB = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtFT = New System.Windows.Forms.TextBox
        Me.Timer1 = New System.Windows.Forms.Timer
        Me.lblStatus = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.Add(Me.mnuClose)
        Me.mainMenu1.MenuItems.Add(Me.MenuItem1)
        '
        'mnuClose
        '
        Me.mnuClose.Text = "назад"
        '
        'MenuItem1
        '
        Me.MenuItem1.Text = "Очистить"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(226, 22)
        Me.Label1.Text = "Метка на картоне"
        '
        'txtB
        '
        Me.txtB.Location = New System.Drawing.Point(3, 16)
        Me.txtB.Name = "txtB"
        Me.txtB.ReadOnly = True
        Me.txtB.Size = New System.Drawing.Size(227, 21)
        Me.txtB.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(3, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 15)
        Me.Label3.Text = "Тип фильтра"
        '
        'txtFT
        '
        Me.txtFT.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold)
        Me.txtFT.Location = New System.Drawing.Point(3, 58)
        Me.txtFT.Name = "txtFT"
        Me.txtFT.ReadOnly = True
        Me.txtFT.Size = New System.Drawing.Size(227, 45)
        Me.txtFT.TabIndex = 5
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(7, 202)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(222, 59)
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(6, 107)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(223, 82)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Начать запись меток"
        '
        'frmB2P
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.txtFT)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtB)
        Me.Controls.Add(Me.Label1)
        Me.Menu = Me.mainMenu1
        Me.Name = "frmB2P"
        Me.Text = "Картон-> Пластик"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents mnuClose As System.Windows.Forms.MenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtB As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFT As System.Windows.Forms.TextBox
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
