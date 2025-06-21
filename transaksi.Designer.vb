<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class transaksi
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TransaksiBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet1 = New week7.DataSet1()
        Me.IdtransaksiDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HargatotalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdprodukDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.jumlah_beli = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TransaksiBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Orange
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.InactiveBorder
        Me.Button1.Location = New System.Drawing.Point(102, 223)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(499, 39)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "CETAK"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdtransaksiDataGridViewTextBoxColumn, Me.HargatotalDataGridViewTextBoxColumn, Me.IdprodukDataGridViewTextBoxColumn, Me.jumlah_beli})
        Me.DataGridView1.DataSource = Me.TransaksiBindingSource
        Me.DataGridView1.Location = New System.Drawing.Point(11, 11)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(2)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 62
        Me.DataGridView1.RowTemplate.Height = 28
        Me.DataGridView1.Size = New System.Drawing.Size(661, 197)
        Me.DataGridView1.TabIndex = 0
        '
        'TransaksiBindingSource
        '
        Me.TransaksiBindingSource.DataMember = "transaksi"
        Me.TransaksiBindingSource.DataSource = Me.DataSet1
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "DataSet1"
        Me.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'IdtransaksiDataGridViewTextBoxColumn
        '
        Me.IdtransaksiDataGridViewTextBoxColumn.DataPropertyName = "id_transaksi"
        Me.IdtransaksiDataGridViewTextBoxColumn.HeaderText = "id_transaksi"
        Me.IdtransaksiDataGridViewTextBoxColumn.MinimumWidth = 8
        Me.IdtransaksiDataGridViewTextBoxColumn.Name = "IdtransaksiDataGridViewTextBoxColumn"
        Me.IdtransaksiDataGridViewTextBoxColumn.Width = 150
        '
        'HargatotalDataGridViewTextBoxColumn
        '
        Me.HargatotalDataGridViewTextBoxColumn.DataPropertyName = "harga_total"
        Me.HargatotalDataGridViewTextBoxColumn.HeaderText = "harga_total"
        Me.HargatotalDataGridViewTextBoxColumn.MinimumWidth = 8
        Me.HargatotalDataGridViewTextBoxColumn.Name = "HargatotalDataGridViewTextBoxColumn"
        Me.HargatotalDataGridViewTextBoxColumn.Width = 150
        '
        'IdprodukDataGridViewTextBoxColumn
        '
        Me.IdprodukDataGridViewTextBoxColumn.DataPropertyName = "id_produk"
        Me.IdprodukDataGridViewTextBoxColumn.HeaderText = "id_produk"
        Me.IdprodukDataGridViewTextBoxColumn.MinimumWidth = 8
        Me.IdprodukDataGridViewTextBoxColumn.Name = "IdprodukDataGridViewTextBoxColumn"
        Me.IdprodukDataGridViewTextBoxColumn.Width = 150
        '
        'jumlah_beli
        '
        Me.jumlah_beli.DataPropertyName = "jumlah_beli"
        Me.jumlah_beli.HeaderText = "jumlah_beli"
        Me.jumlah_beli.MinimumWidth = 8
        Me.jumlah_beli.Name = "jumlah_beli"
        Me.jumlah_beli.Width = 150
        '
        'transaksi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkCyan
        Me.ClientSize = New System.Drawing.Size(680, 292)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "transaksi"
        Me.Text = "transaksi"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TransaksiBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TransaksiBindingSource As BindingSource
    Friend WithEvents DataSet1 As DataSet1
    Friend WithEvents Button1 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents IdtransaksiDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents HargatotalDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents IdprodukDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents jumlah_beli As DataGridViewTextBoxColumn
End Class
