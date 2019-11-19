<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmSetFilter
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
        Me.cmdWrite = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblFT = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer
        Me.lblTag = New System.Windows.Forms.Label
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
        Me.MenuItem2.Text = "сброс"
        '
        'cmdWrite
        '
        Me.cmdWrite.Enabled = False
        Me.cmdWrite.Location = New System.Drawing.Point(13, 100)
        Me.cmdWrite.Name = "cmdWrite"
        Me.cmdWrite.Size = New System.Drawing.Size(215, 121)
        Me.cmdWrite.TabIndex = 0
        Me.cmdWrite.TabStop = False
        Me.cmdWrite.Text = "Записать код фильтра"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(13, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(215, 25)
        Me.Label1.Text = "Выбран код фильтра"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFT
        '
        Me.lblFT.Font = New System.Drawing.Font("Tahoma", 28.0!, System.Drawing.FontStyle.Bold)
        Me.lblFT.Location = New System.Drawing.Point(3, 32)
        Me.lblFT.Name = "lblFT"
        Me.lblFT.Size = New System.Drawing.Size(234, 65)
        Me.lblFT.Text = "ПУСТОЙ"
        Me.lblFT.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'lblTag
        '
        Me.lblTag.Location = New System.Drawing.Point(4, 233)
        Me.lblTag.Name = "lblTag"
        Me.lblTag.Size = New System.Drawing.Size(236, 22)
        '
        'frmSetFilter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblTag)
        Me.Controls.Add(Me.lblFT)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdWrite)
        Me.Menu = Me.mainMenu1
        Me.Name = "frmSetFilter"
        Me.Text = "Запись типа фильтра"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdWrite As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblFT As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents lblTag As System.Windows.Forms.Label
End Class
