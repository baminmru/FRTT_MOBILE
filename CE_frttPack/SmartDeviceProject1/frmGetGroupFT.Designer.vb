<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmGetGroupFT
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
        Me.cmdF1 = New System.Windows.Forms.Button
        Me.cmdF2 = New System.Windows.Forms.Button
        Me.cmdF3 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.Add(Me.MenuItem1)
        '
        'MenuItem1
        '
        Me.MenuItem1.Text = "Назад"
        '
        'cmdF1
        '
        Me.cmdF1.Location = New System.Drawing.Point(13, 9)
        Me.cmdF1.Name = "cmdF1"
        Me.cmdF1.Size = New System.Drawing.Size(208, 57)
        Me.cmdF1.TabIndex = 0
        '
        'cmdF2
        '
        Me.cmdF2.Location = New System.Drawing.Point(14, 77)
        Me.cmdF2.Name = "cmdF2"
        Me.cmdF2.Size = New System.Drawing.Size(206, 68)
        Me.cmdF2.TabIndex = 1
        '
        'cmdF3
        '
        Me.cmdF3.Location = New System.Drawing.Point(15, 158)
        Me.cmdF3.Name = "cmdF3"
        Me.cmdF3.Size = New System.Drawing.Size(204, 71)
        Me.cmdF3.TabIndex = 2
        '
        'frmGetGroupFT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdF3)
        Me.Controls.Add(Me.cmdF2)
        Me.Controls.Add(Me.cmdF1)
        Me.Menu = Me.mainMenu1
        Me.Name = "frmGetGroupFT"
        Me.Text = "Выбор фильтра"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdF1 As System.Windows.Forms.Button
    Friend WithEvents cmdF2 As System.Windows.Forms.Button
    Friend WithEvents cmdF3 As System.Windows.Forms.Button
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
End Class
