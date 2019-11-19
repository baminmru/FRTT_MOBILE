<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmChangeFilter
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
        Me.txtTagID = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbFT = New System.Windows.Forms.ComboBox
        Me.lblStatus = New System.Windows.Forms.Label
        Me.cmdSave = New System.Windows.Forms.Button
        Me.txtFT = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtLT = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
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
        'txtTagID
        '
        Me.txtTagID.Location = New System.Drawing.Point(13, 19)
        Me.txtTagID.Name = "txtTagID"
        Me.txtTagID.Size = New System.Drawing.Size(217, 21)
        Me.txtTagID.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(11, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(218, 16)
        Me.Label1.Text = "Метка"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(11, 140)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(215, 20)
        Me.Label2.Text = "Новый тип фильтра"
        '
        'cmbFT
        '
        Me.cmbFT.Location = New System.Drawing.Point(12, 163)
        Me.cmbFT.Name = "cmbFT"
        Me.cmbFT.Size = New System.Drawing.Size(217, 22)
        Me.cmbFT.TabIndex = 6
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(12, 225)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(213, 33)
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(12, 191)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(217, 29)
        Me.cmdSave.TabIndex = 8
        Me.cmdSave.Text = "Записать"
        '
        'txtFT
        '
        Me.txtFT.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular)
        Me.txtFT.Location = New System.Drawing.Point(13, 111)
        Me.txtFT.Name = "txtFT"
        Me.txtFT.Size = New System.Drawing.Size(217, 26)
        Me.txtFT.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(13, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(215, 20)
        Me.Label3.Text = "Тип фильтра"
        '
        'txtLT
        '
        Me.txtLT.Location = New System.Drawing.Point(12, 64)
        Me.txtLT.Name = "txtLT"
        Me.txtLT.Size = New System.Drawing.Size(217, 21)
        Me.txtLT.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(12, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(215, 18)
        Me.Label4.Text = "Тип лотка"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'frmChangeFilter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtFT)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtLT)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.cmbFT)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtTagID)
        Me.Controls.Add(Me.Label1)
        Me.Menu = Me.mainMenu1
        Me.Name = "frmChangeFilter"
        Me.Text = "Сменить тип фильтра"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtTagID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbFT As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents txtFT As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtLT As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
