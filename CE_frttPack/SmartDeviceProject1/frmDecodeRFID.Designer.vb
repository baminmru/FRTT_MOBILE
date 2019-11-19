<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmDecodeRFID
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtTagID = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtLT = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtFT = New System.Windows.Forms.TextBox
        Me.lblStatus = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer
        Me.cmdChangeFilter = New System.Windows.Forms.Button
        Me.cmdClearTagID = New System.Windows.Forms.Button
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
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(7, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(218, 16)
        Me.Label1.Text = "Метка"
        '
        'txtTagID
        '
        Me.txtTagID.Location = New System.Drawing.Point(8, 25)
        Me.txtTagID.Name = "txtTagID"
        Me.txtTagID.Size = New System.Drawing.Size(177, 21)
        Me.txtTagID.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(7, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(205, 18)
        Me.Label2.Text = "Тип лотка"
        '
        'txtLT
        '
        Me.txtLT.Location = New System.Drawing.Point(8, 78)
        Me.txtLT.Name = "txtLT"
        Me.txtLT.Size = New System.Drawing.Size(217, 21)
        Me.txtLT.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 20)
        Me.Label3.Text = "Тип фильтра"
        '
        'txtFT
        '
        Me.txtFT.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular)
        Me.txtFT.Location = New System.Drawing.Point(9, 125)
        Me.txtFT.Name = "txtFT"
        Me.txtFT.Size = New System.Drawing.Size(216, 26)
        Me.txtFT.TabIndex = 5
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(9, 237)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(218, 28)
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'cmdChangeFilter
        '
        Me.cmdChangeFilter.Location = New System.Drawing.Point(9, 157)
        Me.cmdChangeFilter.Name = "cmdChangeFilter"
        Me.cmdChangeFilter.Size = New System.Drawing.Size(218, 77)
        Me.cmdChangeFilter.TabIndex = 9
        Me.cmdChangeFilter.Text = "Сменить тип фильтра"
        '
        'cmdClearTagID
        '
        Me.cmdClearTagID.Location = New System.Drawing.Point(191, 17)
        Me.cmdClearTagID.Name = "cmdClearTagID"
        Me.cmdClearTagID.Size = New System.Drawing.Size(34, 29)
        Me.cmdClearTagID.TabIndex = 14
        Me.cmdClearTagID.Text = "X"
        '
        'frmDecodeRFID
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdClearTagID)
        Me.Controls.Add(Me.cmdChangeFilter)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.txtFT)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtLT)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtTagID)
        Me.Controls.Add(Me.Label1)
        Me.Menu = Me.mainMenu1
        Me.Name = "frmDecodeRFID"
        Me.Text = "Расшифровать метку"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTagID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtLT As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFT As System.Windows.Forms.TextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Public WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents cmdChangeFilter As System.Windows.Forms.Button
    Friend WithEvents cmdClearTagID As System.Windows.Forms.Button
End Class
