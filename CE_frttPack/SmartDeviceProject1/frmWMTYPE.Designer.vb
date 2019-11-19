<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmWMTYPE
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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(213, 52)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "KDF"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(13, 61)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(212, 55)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "MULFI"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(13, 122)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(213, 61)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "FilterShooter"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(14, 189)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(212, 63)
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "LINKUP"
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.Add(Me.MenuItem1)
        '
        'MenuItem1
        '
        Me.MenuItem1.Text = "Назад"
        '
        'frmWMTYPE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.KeyPreview = True
        Me.Menu = Me.MainMenu1
        Me.Name = "frmWMTYPE"
        Me.Text = "Тип машины"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
End Class
