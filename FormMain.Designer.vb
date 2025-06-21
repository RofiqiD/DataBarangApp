<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransaksiToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.HomeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutUsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransaksiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OrderToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MulaiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem, Me.TransaksiToolStripMenuItem1, Me.OrderToolStripMenuItem1, Me.MenuToolStripMenuItem1, Me.MulaiToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(2, 1, 0, 1)
        Me.MenuStrip1.Size = New System.Drawing.Size(533, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem
        '
        Me.ToolStripMenuItem.Name = "ToolStripMenuItem"
        Me.ToolStripMenuItem.Size = New System.Drawing.Size(74, 22)
        Me.ToolStripMenuItem.Text = "MenuItem"
        '
        'TransaksiToolStripMenuItem1
        '
        Me.TransaksiToolStripMenuItem1.Name = "TransaksiToolStripMenuItem1"
        Me.TransaksiToolStripMenuItem1.Size = New System.Drawing.Size(66, 22)
        Me.TransaksiToolStripMenuItem1.Text = "Transaksi"
        '
        'HomeToolStripMenuItem
        '
        Me.HomeToolStripMenuItem.Name = "HomeToolStripMenuItem"
        Me.HomeToolStripMenuItem.Size = New System.Drawing.Size(52, 22)
        Me.HomeToolStripMenuItem.Text = "Home"
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(50, 22)
        Me.MenuToolStripMenuItem.Text = "Menu"
        '
        'AboutUsToolStripMenuItem
        '
        Me.AboutUsToolStripMenuItem.Name = "AboutUsToolStripMenuItem"
        Me.AboutUsToolStripMenuItem.Size = New System.Drawing.Size(47, 22)
        Me.AboutUsToolStripMenuItem.Text = "order"
        '
        'DataToolStripMenuItem
        '
        Me.DataToolStripMenuItem.Name = "DataToolStripMenuItem"
        Me.DataToolStripMenuItem.Size = New System.Drawing.Size(42, 22)
        Me.DataToolStripMenuItem.Text = "data"
        '
        'TransaksiToolStripMenuItem
        '
        Me.TransaksiToolStripMenuItem.Name = "TransaksiToolStripMenuItem"
        Me.TransaksiToolStripMenuItem.Size = New System.Drawing.Size(65, 22)
        Me.TransaksiToolStripMenuItem.Text = "transaksi"
        '
        'OrderToolStripMenuItem
        '
        Me.OrderToolStripMenuItem.Name = "OrderToolStripMenuItem"
        Me.OrderToolStripMenuItem.Size = New System.Drawing.Size(47, 22)
        Me.OrderToolStripMenuItem.Text = "order"
        '
        'OrderToolStripMenuItem1
        '
        Me.OrderToolStripMenuItem1.Name = "OrderToolStripMenuItem1"
        Me.OrderToolStripMenuItem1.Size = New System.Drawing.Size(49, 22)
        Me.OrderToolStripMenuItem1.Text = "Order"
        '
        'MenuToolStripMenuItem1
        '
        Me.MenuToolStripMenuItem1.Name = "MenuToolStripMenuItem1"
        Me.MenuToolStripMenuItem1.Size = New System.Drawing.Size(50, 22)
        Me.MenuToolStripMenuItem1.Text = "Menu"
        '
        'MulaiToolStripMenuItem
        '
        Me.MulaiToolStripMenuItem.Name = "MulaiToolStripMenuItem"
        Me.MulaiToolStripMenuItem.Size = New System.Drawing.Size(49, 22)
        Me.MulaiToolStripMenuItem.Text = "Mulai"
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(533, 292)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FormMain"
        Me.Text = "Form3"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents HomeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MenuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutUsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TransaksiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OrderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TransaksiToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents OrderToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents MenuToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents MulaiToolStripMenuItem As ToolStripMenuItem
End Class
