<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmNew
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
        Me.lstLT = New System.Windows.Forms.ListBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lstFT = New System.Windows.Forms.ListBox
        Me.cmdWrite = New System.Windows.Forms.Button
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
        'lstLT
        '
        Me.lstLT.Location = New System.Drawing.Point(21, 27)
        Me.lstLT.Name = "lstLT"
        Me.lstLT.Size = New System.Drawing.Size(201, 58)
        Me.lstLT.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(21, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 15)
        Me.Label1.Text = "Тип лотка"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(21, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 14)
        Me.Label2.Text = "Тип фильтра"
        '
        'lstFT
        '
        Me.lstFT.Location = New System.Drawing.Point(21, 110)
        Me.lstFT.Name = "lstFT"
        Me.lstFT.Size = New System.Drawing.Size(201, 86)
        Me.lstFT.TabIndex = 3
        '
        'cmdWrite
        '
        Me.cmdWrite.Location = New System.Drawing.Point(21, 205)
        Me.cmdWrite.Name = "cmdWrite"
        Me.cmdWrite.Size = New System.Drawing.Size(199, 34)
        Me.cmdWrite.TabIndex = 4
        Me.cmdWrite.Text = "Записать"
        '
        'frmNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdWrite)
        Me.Controls.Add(Me.lstFT)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lstLT)
        Me.Menu = Me.mainMenu1
        Me.Name = "frmNew"
        Me.Text = "Создание метки"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents lstLT As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lstFT As System.Windows.Forms.ListBox
    Friend WithEvents cmdWrite As System.Windows.Forms.Button
End Class
