Imports System.Data.OleDb
Imports System.Globalization
Imports MySql.Data.MySqlClient
Imports ZstdSharp.Unsafe
Public Class formorder
    Dim conn As New MySqlConnection("server=localhost;port=3306;username=root;password=;database=produklagi1")
    Dim i As Integer
    Dim dr As MySqlDataReader

    Public Property ProductName As String
    Public Property ProductId As Integer
    Public Property TransactionForm As transaksi
    Public WithEvents DataGridView1 As New DataGridView()
    Public Property OrderForm As transaksi
    Public Property UserId As Integer

    Private Sub LoadTransactions()
        Try
            conn.Open()
            Dim cmd As New MySqlCommand("SELECT transaksi.id_transaksi, produk.nama AS product_name, transaksi.harga_total, transaksi.total_bayar, transaksi.alamat FROM transaksi JOIN produk ON transaksi.id_produk = produk.id", conn)
            Dim adapter As New MySqlDataAdapter(cmd)
            Dim table As New DataTable()

            adapter.Fill(table)
            DataGridView1.DataSource = table
        Catch ex As Exception
            MessageBox.Show("Error loading transactions: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub formorder_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Set the text of Label1 based on the passed product name
        If Not String.IsNullOrEmpty(ProductName) Then
            Label1.Text = ProductName
        End If
        TextBoxjumlahbeli.Text = "0"
        TextBoxtotalharga.Text = "0.00"
        TextBoxtotalbayar.Text = "0.00"
        LoadTransactions()

    End Sub
    Private Sub TextBoxjumlahbeli_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxjumlahbeli.KeyPress
        ' Allow only digits and control characters (like backspace)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
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
    Private Sub ButtonKurangi_Click(sender As Object, e As EventArgs) Handles ButtonKurangi.Click
        Dim currentQuantity As Integer
        If Integer.TryParse(TextBoxjumlahbeli.Text, currentQuantity) Then
            If currentQuantity > 0 Then
                currentQuantity -= 1
                TextBoxjumlahbeli.Text = currentQuantity.ToString()
            Else
                MessageBox.Show("Quantity cannot be less than zero.")
            End If
        Else
            MessageBox.Show("Please enter a valid number.")
        End If
    End Sub



    Private Sub Buttontambah_Click(sender As Object, e As EventArgs) Handles Buttontambah.Click
        Dim currentQuantity As Integer
        If Integer.TryParse(TextBoxjumlahbeli.Text, currentQuantity) Then
            currentQuantity += 1
            TextBoxjumlahbeli.Text = currentQuantity.ToString()
        Else
            MessageBox.Show("Please enter a valid number.")
        End If

    End Sub

    Private Sub Buttonhitungharga_Click(sender As Object, e As EventArgs) Handles Buttonhitungharga.Click
        Dim currentQuantity As Integer
        If Integer.TryParse(TextBoxjumlahbeli.Text, currentQuantity) Then
            Dim productPrice As Decimal = GetProductPrice(ProductId)
            If productPrice >= 0 Then
                Dim totalPrice As Decimal = currentQuantity * productPrice
                TextBoxtotalharga.Text = totalPrice.ToString("C2") ' Display total price in currency format
            Else
                MessageBox.Show("Product price not found.")
                TextBoxtotalharga.Text = "0.00" ' Reset total price if not found
            End If
        Else
            MessageBox.Show("Please enter a valid quantity.")
        End If
    End Sub



    Private Sub ButtonHitungtotal_Click(sender As Object, e As EventArgs) Handles ButtonHitungtotal.Click
        Dim totalPrice As Decimal

        ' Attempt to parse the total price from TextBoxtotalharga
        Try
            ' Remove the currency symbol and parse the value
            totalPrice = Decimal.Parse(TextBoxtotalharga.Text, NumberStyles.Currency)

            ' Add 20,000 to the total price
            totalPrice += 20000D ' Fixed amount to add

            ' Display the total amount in currency format
            TextBoxtotalbayar.Text = totalPrice.ToString("C2")
        Catch ex As FormatException
            MessageBox.Show("Please calculate the total price first.")
            TextBoxtotalbayar.Text = "0.00" ' Reset total bayar if parsing fails
        End Try
    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ' Create an instance of the MDI parent form
        Dim mdiForm As New FormMain()

        ' Optionally, you can pass data to the MDI parent form here
        ' mdiForm.SomeProperty = "Some Value"

        ' Show the MDI parent form
        mdiForm.Show()

        ' Close the current form (formorder)
        Me.Close() ' or Me.Hide() if you want to keep it in memory
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            ' Validate quantity input
            Dim quantity As Integer
            If Not Integer.TryParse(TextBoxjumlahbeli.Text, quantity) Then
                MessageBox.Show("Please enter a valid quantity.")
                Return
            End If

            ' Validate address input
            If String.IsNullOrEmpty(TextBox3.Text) Then
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
            cmd.Parameters.AddWithValue("@TotalPrice", Decimal.Parse(TextBoxtotalharga.Text, NumberStyles.Currency))
            cmd.Parameters.AddWithValue("@TotalBayar", Decimal.Parse(TextBoxtotalbayar.Text, NumberStyles.Currency))
            cmd.Parameters.AddWithValue("@Address", TextBox3.Text)
            cmd.Parameters.AddWithValue("@Quantity", quantity)
            cmd.ExecuteNonQuery()

            ' Reduce stock in product table
            Dim updateStockCmd As New MySqlCommand("UPDATE produk SET stok = stok - @Quantity WHERE id = @ProductId", conn)
            updateStockCmd.Parameters.AddWithValue("@Quantity", quantity)
            updateStockCmd.Parameters.AddWithValue("@ProductId", ProductId)
            updateStockCmd.ExecuteNonQuery()

            MessageBox.Show("Transaction saved successfully.")

            ' Refresh DataGridView in transaksi.vb
            If TransactionForm IsNot Nothing Then
                TransactionForm.RefreshTransactions()
            End If

        Catch ex As Exception
            MessageBox.Show("Error saving transaction: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

        'If e.ColumnIndex = 3 Then ' harga column
        'If e.Value IsNot Nothing Then
        'Dim value As Decimal = Convert.ToDecimal(e.Value)
        'e.Value = String.Format("{0:N0}", value) ' format as currency without decimal places
        'e.FormattingApplied = True
        'End If
        ' End If


    End Sub

    Private Sub harga_TextChanged(sender As Object, e As EventArgs) Handles harga.TextChanged

    End Sub

    Private Sub stok_TextChanged(sender As Object, e As EventArgs) Handles stok.TextChanged

    End Sub

    Private Sub kategori_TextChanged(sender As Object, e As EventArgs) Handles kategori.TextChanged

    End Sub

    Private Sub namabarang_TextChanged(sender As Object, e As EventArgs) Handles namabarang.TextChanged

    End Sub

    Private Sub id_TextChanged(sender As Object, e As EventArgs) Handles id.TextChanged
        Try
            Dim productId As Integer
            If Integer.TryParse(id.Text, productId) Then
                conn.Open()
                Dim cmd As New MySqlCommand("SELECT nama, kategori, stok, harga FROM produk WHERE id = @ProductId", conn)
                cmd.Parameters.AddWithValue("@ProductId", productId)
                Dim adapter As New MySqlDataAdapter(cmd)
                Dim table As New DataTable()

                adapter.Fill(table)
                DataGridView2.DataSource = table
            Else
                DataGridView2.DataSource = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show("Error retrieving product details: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub
End Class