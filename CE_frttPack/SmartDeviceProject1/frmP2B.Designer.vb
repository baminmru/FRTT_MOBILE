<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmP2B
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
        Me.txtP = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtB = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblStatus = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer
        Me.SuspendLayout()
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.Add(Me.MenuItem1)
        Me.mainMenu1.MenuItems.Add(Me.MenuItem2)
        '
        'MenuItem1
        '
        Me.MenuItem1.Text = "Закрыть"
        '
        'MenuItem2
        '
        Me.MenuItem2.Text = "Очистить"
        '
        'txtFT
        '
        Me.txtFT.Location = New System.Drawing.Point(3, 65)
        Me.txtFT.Name = "txtFT"
        Me.txtFT.ReadOnly = True
        Me.txtFT.Size = New System.Drawing.Size(227, 21)
        Me.txtFT.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(3, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 15)
        Me.Label3.Text = "Тип фильтра"
        '
        'txtP
        '
        Me.txtP.Location = New System.Drawing.Point(3, 23)
        Me.txtP.Name = "txtP"
        Me.txtP.ReadOnly = True
        Me.txtP.Size = New System.Drawing.Size(227, 21)
        Me.txtP.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 20)
        Me.Label2.Text = "Пластик"
        '
        'txtB
        '
        Me.txtB.Location = New System.Drawing.Point(3, 106)
        Me.txtB.Name = "txtB"
        Me.txtB.ReadOnly = True
        Me.txtB.Size = New System.Drawing.Size(227, 21)
        Me.txtB.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(3, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 24)
        Me.Label1.Text = "Бумага"
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(3, 164)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(227, 91)
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'frmP2B
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.txtFT)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtP)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtB)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.Menu = Me.mainMenu1
        Me.Name = "frmP2B"
        Me.Text = "Пластик -> Бумага"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents txtFT As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtP As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtB As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
End Class
