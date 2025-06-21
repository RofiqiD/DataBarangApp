Imports MySql.Data.MySqlClient
Imports ZstdSharp.Unsafe

Public Class Form1
    Dim conn As New MySqlConnection("server=localhost;port=3306;username=root;password=;database=produklagi1")
    Dim i As Integer
    Dim dr As MySqlDataReader
    Public Sub save()
        Try
            conn.Open()
            Dim cmd As New MySqlCommand("INSERT INTO produk(id, nama, kategori, stok, harga) VALUES (@id,@nama,@kategori,@stok,@harga)", conn)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@id", TextBox1.Text)
            cmd.Parameters.AddWithValue("@nama", TextBox2.Text)
            cmd.Parameters.AddWithValue("@kategori", ComboBox1.Text)
            cmd.Parameters.AddWithValue("@stok", TextBox3.Text)
            cmd.Parameters.AddWithValue("@harga", TextBox4.Text)
            i = cmd.ExecuteNonQuery
            If i > 0 Then
                MessageBox.Show("Data Berhasil Disimpan", "Tambah Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Data Gagal di Simpan", "Tambah Data", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
        End Try

    End Sub
    Public Sub data_load()
        DataGridView1.Rows.Clear()

        Try
            conn.Open()
            Dim cmd As New MySqlCommand("Select * from produk", conn)
            dr = cmd.ExecuteReader
            While dr.Read
                DataGridView1.Rows.Add(dr.Item("id"), dr.Item("nama"), dr.Item("kategori"), dr.Item("stok"), dr.Item("harga"))
            End While
            dr.DisposeAsync()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub
    Public Sub ubah()
        Try
            conn.Open()
            Dim cmd As New MySqlCommand("UPDATE produk SET nama=@nama,kategori=@kategori,stok=@stok, harga=@harga WHERE id=@id", conn)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@id", TextBox1.Text)
            cmd.Parameters.AddWithValue("@nama", TextBox2.Text)
            cmd.Parameters.AddWithValue("@kategori", ComboBox1.Text)
            cmd.Parameters.AddWithValue("@stok", TextBox3.Text)
            cmd.Parameters.AddWithValue("@harga", TextBox4.Text)

            i = cmd.ExecuteNonQuery
            If i > 0 Then
                MessageBox.Show("Data Berhasil Diubah", "Tambah Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Data Gagal di Ubah", "Tambah Data", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
        End Try
        TextBox1.ReadOnly = False
        Button1.Enabled = True
    End Sub
    Public Sub hapus()
        If MsgBox("Apakah anda yakin akan menghapus data tersebut?", MsgBoxStyle.Question + vbYesNo) = vbYes Then
            Try
                conn.Open()
                Dim cmd As New MySqlCommand("DELETE FROM produk WHERE id=@id", conn)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@id", TextBox1.Text)
                i = cmd.ExecuteNonQuery
                If i > 0 Then
                    MessageBox.Show("Data Berhasil Dihapus", "Tambah Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Data Gagal di Hapus", "Tambah Data", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Close()
            End Try
            TextBox1.ReadOnly = False
            Button1.Enabled = True
        Else
            Return

        End If
    End Sub
    Public Sub bersih()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        ComboBox1.Text = ""

        TextBox1.ReadOnly = False
        Button1.Enabled = True
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        data_load()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        save()
        bersih()
        data_load()


    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TextBox1.Text = DataGridView1.CurrentRow.Cells(0).Value
        TextBox2.Text = DataGridView1.CurrentRow.Cells(1).Value
        ComboBox1.Text = DataGridView1.CurrentRow.Cells(2).Value
        TextBox3.Text = DataGridView1.CurrentRow.Cells(3).Value
        TextBox4.Text = DataGridView1.CurrentRow.Cells(4).Value
        TextBox1.ReadOnly = True
        Button1.Enabled = False

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ubah()
        bersih()
        data_load()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        hapus()
        bersih()
        data_load()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        bersih()
        data_load()

    End Sub




    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim ds As New DataSet1
        Dim dt As New DataTable
        dt = ds.Tables("produk")
        For i = 0 To DataGridView1.RowCount - 1
            dt.Rows.Add(DataGridView1.Rows(i).Cells(0).Value,
                        DataGridView1.Rows(i).Cells(1).Value,
                        DataGridView1.Rows(i).Cells(2).Value,
                        DataGridView1.Rows(i).Cells(3).Value,
                        DataGridView1.Rows(i).Cells(4).Value)

        Next
        With Form2.ReportViewer1.LocalReport
            .ReportPath = "C:\Users\ASUS\Downloads\week7\week7\Report1.rdlc"
            .DataSources.Clear()
            .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSetProduk", dt))
        End With
        Form2.Show()
        Form2.ReportViewer1.RefreshReport()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        DataGridView1.Rows.Clear()

        Try
            conn.Open()
            Dim cmd As New MySqlCommand("Select * from produk where id like '%" & TextBox5.Text & "%' or nama like '%" & TextBox5.Text & "%'", conn)
            dr = cmd.ExecuteReader
            While dr.Read
                DataGridView1.Rows.Add(dr.Item("id"), dr.Item("nama"), dr.Item("kategori"), dr.Item("stok"), dr.Item("harga"))
            End While
            dr.DisposeAsync()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
        End Try


    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class