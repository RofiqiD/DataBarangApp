Imports System.Globalization
Imports System.Reflection.Emit
Imports System.Windows.Controls
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Public Class Form6
    Public conn As New MySqlConnection
    Public da As MySqlDataAdapter
    Public ds As DataSet

    Private Sub koneksi()
        Dim strconn As String
        Try
            strconn = "server=localhost;user=root;password=;database=produklagi1"
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.ConnectionString = strconn
            conn.Open()
        Catch ex As Exception
            MsgBox("Koneksi ke database gagal: " & ex.Message, MsgBoxStyle.Critical, "Kesalahan")
        End Try
    End Sub
    Private Sub formorder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set the text of Label1 based on the passed product name
        If Not String.IsNullOrEmpty(ProductName) Then
            Label1.Text = ProductName
        End If
        TbJumlah.Text = "0"
        Totalharga.Text = "0.00"

    End Sub
    Private Function GetProductPrice(productId As Integer) As Decimal
        Dim price As Decimal = -1 ' Default to -1 to indicate not found
        Try
            conn.Open()
            Dim cmd As New MySqlCommand("SELECT harga FROM produk WHERE id = @ProductId", conn)
            cmd.Parameters.AddWithValue("@ProductId", productId)

            ' Execute the command and read the price
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            If reader.Read() Then
                price = reader.GetDecimal("harga")
            End If
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error retrieving price: " & ex.Message)
        Finally
            conn.Close()
        End Try
        Return price
    End Function


    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Buka koneksi
            Call koneksi()

            ' Query untuk mengambil data
            Dim query As String = "SELECT * FROM produk"
            Dim da As New MySqlDataAdapter(query, conn)

            ' Inisialisasi DataSet
            ds = New DataSet()
            da.Fill(ds, "produk")

            ' Periksa apakah tabel "barang" ada
            If ds.Tables.Contains("produk") Then
                DataGridView1.DataSource = ds.Tables("produk")
            Else
                MessageBox.Show("Tabel 'barang' tidak ditemukan dalam DataSet.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat memuat data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Tutup koneksi
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            Call koneksi()
            Dim id As String = TextBox1.Text.Trim()
            Dim query As String
            If id = "" Then
                TextBox2.Clear()
                'TextBox3.Clear()
                TextBox4.Clear()
                TextBox5.Clear()
                Totalharga.Clear()
                btnkembali.Clear()
                TbJumlah.Clear()

                query = "SELECT * FROM produk"
            Else
                query = "SELECT * FROM produk WHERE Id = '" & id & "'"
            End If

            Dim da As New MySqlDataAdapter(query, conn)
            Dim ds As New DataSet()
            da.Fill(ds, "produk")

            If ds.Tables("produk").Rows.Count > 0 Then
                DataGridView1.DataSource = ds.Tables("produk")
                Dim row As DataRow = ds.Tables("produk").Rows(0)
                TextBox2.Text = row("nama").ToString()
                'TextBox3.Text = row("kategori").ToString()
                TextBox4.Text = row("stok").ToString() ' Harga barang
                TextBox5.Text = row("harga").ToString()
                TotalHarga.Text = row("harga").ToString()
                btnkembali.Text = row("kategori").ToString()
                TbJumlah.Text = row("stok").ToString()

            Else
                TextBox2.Clear()
                'TextBox3.Clear()
                TextBox4.Clear()
                TextBox5.Clear()
                TotalHarga.Clear()
                btnkembali.Clear()
                TbJumlah.Clear()
                MessageBox.Show("Data tidak ditemukan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat mencari data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Private Sub btnuangbayar_TextChanged(sender As Object, e As EventArgs) Handles btnuangbayar.TextChanged
        Dim uangMasuk As String = btnuangbayar.Text.Trim()
        ' Validasi input untuk memastikan hanya angka yang valid
        If IsNumeric(uangMasuk) Then
            btnuangbayar.Text = uangMasuk
        Else
            MessageBox.Show("Masukkan hanya angka untuk uang.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            btnuangbayar.Clear()
        End If
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles btnuangbayar.TextChanged
        Try
            ' Pastikan input di TextBox7 hanya angka
            Dim uangMasuk As Decimal
            If Decimal.TryParse(btnuangbayar.Text, uangMasuk) Then
                ' Ambil nilai dari TextBox6 (harga)
                Dim harga As Decimal = Decimal.Parse(Totalharga.Text)

                ' Hitung pengembalian
                Dim pengembalian As Decimal = uangMasuk - harga

                ' Tampilkan hasil di TextBox8
                btnkembali.Text = pengembalian.ToString("F2") ' Format dengan dua angka desimal
            Else
                MessageBox.Show("Masukkan hanya angka untuk uang.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                btnuangbayar.Clear()
                btnkembali.Clear()
            End If
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan dalam menghitung pengembalian: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub Buttonhitungharga_Click(sender As Object, e As EventArgs) Handles Buttonhitungharga.Click
        Dim currentQuantity As Integer
        If Integer.TryParse(Totalharga.Text, currentQuantity) Then
            Dim productPrice As Decimal = GetProductPrice(ProductId)
            If productPrice >= 0 Then
                Dim totalPrice As Decimal = currentQuantity * productPrice
                Totalharga.Text = totalPrice.ToString("C2") ' Display total price in currency format
            Else
                MessageBox.Show("Product price not found.")
                Totalharga.Text = "0.00" ' Reset total price if not found
            End If
        Else
            MessageBox.Show("Please enter a valid quantity.")
        End If
    End Sub

    Private Sub Buttonbayar_Click(sender As Object, e As EventArgs) Handles bayar.Click
        Try
            ' Validate quantity input
            Dim quantity As Integer
            If Not Integer.TryParse(TbJumlah.Text, quantity) Then
                MessageBox.Show("Please enter a valid quantity.")
                Return
            End If

            ' Validate address input
            If String.IsNullOrEmpty(TbJumlah.Text) Then
                MessageBox.Show("Address cannot be empty.")
                Return
            End If

            ' Check stock availability
            conn.Open()
            Dim checkStockCmd As New MySqlCommand("SELECT stok FROM produk WHERE id = @ProductId", conn)
            checkStockCmd.Parameters.AddWithValue("@ProductId", ProductId)
            Dim stock As Integer = Convert.ToInt32(checkStockCmd.ExecuteScalar())
            conn.Close()

            If stock < quantity Then
                MessageBox.Show("Insufficient stock available.")
                Return
            End If

            ' Save transaction to database
            conn.Open()
            Dim cmd As New MySqlCommand("INSERT INTO transaksi (id_produk, harga_total, total_bayar, alamat, jumlah_beli) VALUES (@ProductId, @TotalPrice, @TotalBayar, @Address, @Quantity)", conn)
            cmd.Parameters.AddWithValue("@ProductId", ProductId)
            '' cmd.Parameters.AddWithValue("@UserId", UserId) ' Ambil id_user dari properti
            cmd.Parameters.AddWithValue("@TotalPrice", Decimal.Parse(Totalharga.Text, NumberStyles.Currency))
            cmd.Parameters.AddWithValue("@TotalBayar", Decimal.Parse(Totalharga.Text, NumberStyles.Currency))
            cmd.Parameters.AddWithValue("@Address", TbJumlah.Text)
            cmd.Parameters.AddWithValue("@Quantity", quantity)
            cmd.ExecuteNonQuery()

            ' Reduce stock in product table
            Dim updateStockCmd As New MySqlCommand("UPDATE produk SET stok = stok - @Quantity WHERE id = @ProductId", conn)
            updateStockCmd.Parameters.AddWithValue("@Quantity", quantity)
            updateStockCmd.Parameters.AddWithValue("@ProductId", ProductId)
            updateStockCmd.ExecuteNonQuery()

            MessageBox.Show("Transaction saved successfully.")

            ' Refresh DataGridView in transaksi.vb
            If TransactionForm() IsNot Nothing Then
                TransactionForm.RefreshTransactions()
            End If

        Catch ex As Exception
            MessageBox.Show("Error saving transaction: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub TBJumlah_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TbJumlah.KeyPress
        ' Allow only digits and control characters (like backspace)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Function ProductId() As Object
        Throw New NotImplementedException()
    End Function

    Private Function TransactionForm() As Object
        Throw New NotImplementedException()
    End Function

    Private Sub Buttonkurang_Click(sender As Object, e As EventArgs) Handles Buttonkurang.Click
        ' Decrement the value in TbJumlah by 1
        Dim currentQuantity As Integer
        If Integer.TryParse(TbJumlah.Text, currentQuantity) Then
            If currentQuantity > 0 Then
                currentQuantity -= 1
                TbJumlah.Text = currentQuantity.ToString()
            Else
                MessageBox.Show("Quantity cannot be less than zero.")
            End If
        Else
            TbJumlah.Text = "0" ' Default to 0 if the text is invalid
        End If
    End Sub

    Private Sub TbJumlah_TextChanged(sender As Object, e As EventArgs) Handles TbJumlah.TextChanged
        Dim value As Integer
        If Not Integer.TryParse(TbJumlah.Text, value) Then
            TbJumlah.Text = "0" ' Reset to 0 if invalid input
        End If
    End Sub

    Private Sub Buttontambah_Click(sender As Object, e As EventArgs) Handles Buttontambah.Click
        ' Increment the value in TbJumlah by 1
        Dim currentQuantity As Integer
        If Integer.TryParse(TbJumlah.Text, currentQuantity) Then
            currentQuantity += 1
            TbJumlah.Text = currentQuantity.ToString()
        Else
            TbJumlah.Text = "1" ' Default to 1 if the text is invalid
        End If

    End Sub

    Private Sub Totalharga_TextChanged(sender As Object, e As EventArgs) Handles Totalharga.TextChanged

    End Sub

    Private Sub btnkembali_TextChanged(sender As Object, e As EventArgs) Handles btnkembali.TextChanged

    End Sub
End Class
