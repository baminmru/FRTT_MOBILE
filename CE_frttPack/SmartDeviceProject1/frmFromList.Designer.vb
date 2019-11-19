<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmFromList
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
        Me.cmbFT = New System.Windows.Forms.ListBox
        Me.cmdOK = New System.Windows.Forms.Button
        Me.VS = New System.Windows.Forms.VScrollBar
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
        'cmbFT
        '
        Me.cmbFT.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.cmbFT.Location = New System.Drawing.Point(8, 14)
        Me.cmbFT.Name = "cmbFT"
        Me.cmbFT.Size = New System.Drawing.Size(197, 176)
        Me.cmbFT.TabIndex = 10
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(8, 205)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(218, 51)
        Me.cmdOK.TabIndex = 11
        Me.cmdOK.Text = "Записать код фильтра"
        '
        'VS
        '
        Me.VS.Location = New System.Drawing.Point(184, 14)
        Me.VS.Name = "VS"
        Me.VS.Size = New System.Drawing.Size(44, 176)
        Me.VS.TabIndex = 12
        '
        'frmFromList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.ControlBox = False
        Me.Controls.Add(Me.VS)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmbFT)
        Me.Menu = Me.mainMenu1
        Me.Name = "frmFromList"
        Me.Text = "Выбор из списка"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents cmbFT As System.Windows.Forms.ListBox
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents VS As System.Windows.Forms.VScrollBar
End Class
