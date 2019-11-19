<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmOK
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
Me.lblMessage = New System.Windows.Forms.Label
Me.Label1 = New System.Windows.Forms.Label
Me.Button1 = New System.Windows.Forms.Button
Me.Label2 = New System.Windows.Forms.Label
Me.Timer1 = New System.Windows.Forms.Timer
Me.SuspendLayout()
'
'mainMenu1
'
Me.mainMenu1.MenuItems.Add(Me.MenuItem1)
'
'MenuItem1
'
Me.MenuItem1.Text = "закрыть"
'
'lblMessage
'
Me.lblMessage.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
Me.lblMessage.Location = New System.Drawing.Point(3, 204)
Me.lblMessage.Name = "lblMessage"
Me.lblMessage.Size = New System.Drawing.Size(229, 64)
Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter
'
'Label1
'
Me.Label1.BackColor = System.Drawing.Color.Lime
Me.Label1.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
Me.Label1.ForeColor = System.Drawing.Color.Yellow
Me.Label1.Location = New System.Drawing.Point(3, 4)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(233, 30)
Me.Label1.Text = "УСПЕШНО"
Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
'
'Button1
'
Me.Button1.BackColor = System.Drawing.Color.LawnGreen
Me.Button1.Location = New System.Drawing.Point(3, 53)
Me.Button1.Name = "Button1"
Me.Button1.Size = New System.Drawing.Size(234, 108)
Me.Button1.TabIndex = 2
Me.Button1.Text = "НАЖМИТЕ ДЛЯ ОСТАНОВКИ"
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(5, 169)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(227, 20)
Me.Label2.Text = "Код фильтра записан"
Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
'
'Timer1
'
Me.Timer1.Interval = 5000
'
'frmOK
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
Me.AutoScroll = True
Me.ClientSize = New System.Drawing.Size(240, 268)
Me.ControlBox = False
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.lblMessage)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.Button1)
Me.Menu = Me.mainMenu1
Me.Name = "frmOK"
Me.Text = "Записано"
Me.ResumeLayout(False)

End Sub
    Private WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
