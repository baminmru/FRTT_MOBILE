<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmSelectFSRC
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
        Me.cmdFromList = New System.Windows.Forms.Button
        Me.cmdManual = New System.Windows.Forms.Button
        Me.cmdFromWM = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.Add(Me.MenuItem1)
        '
        'MenuItem1
        '
        Me.MenuItem1.Text = "назад"
        '
        'cmdFromList
        '
        Me.cmdFromList.Location = New System.Drawing.Point(10, 13)
        Me.cmdFromList.Name = "cmdFromList"
        Me.cmdFromList.Size = New System.Drawing.Size(215, 64)
        Me.cmdFromList.TabIndex = 0
        Me.cmdFromList.Text = "Выбрать из списка"
        '
        'cmdManual
        '
        Me.cmdManual.Location = New System.Drawing.Point(8, 83)
        Me.cmdManual.Name = "cmdManual"
        Me.cmdManual.Size = New System.Drawing.Size(216, 70)
        Me.cmdManual.TabIndex = 1
        Me.cmdManual.Text = "Ввести вручную"
        '
        'cmdFromWM
        '
        Me.cmdFromWM.Location = New System.Drawing.Point(8, 159)
        Me.cmdFromWM.Name = "cmdFromWM"
        Me.cmdFromWM.Size = New System.Drawing.Size(215, 71)
        Me.cmdFromWM.TabIndex = 2
        Me.cmdFromWM.Text = "С активной машины"
        '
        'frmSelectFSRC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdFromWM)
        Me.Controls.Add(Me.cmdManual)
        Me.Controls.Add(Me.cmdFromList)
        Me.Menu = Me.mainMenu1
        Me.Name = "frmSelectFSRC"
        Me.Text = "Способ выбора фильтра"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdFromList As System.Windows.Forms.Button
    Friend WithEvents cmdManual As System.Windows.Forms.Button
    Friend WithEvents cmdFromWM As System.Windows.Forms.Button
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
End Class
