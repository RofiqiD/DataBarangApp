Imports MySql.Data.MySqlClient
Imports System.Globalization

Public Class transaksi
    Private connString As String = "server=localhost;port=3306;username=root;password=;database=produklagi1"

    Public Sub RefreshTransactions()
        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()
                Dim cmd As New MySqlCommand("SELECT * FROM transaksi", conn)
                Dim adapter As New MySqlDataAdapter(cmd)
                Dim table As New DataTable()

                adapter.Fill(table)
                DataGridView1.DataSource = table ' Bind the DataTable to the DataGridView
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading transactions: " & ex.Message)
        End Try
    End Sub

    Private Sub transaksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshTransactions()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim dt As DataTable = DirectCast(DataGridView1.DataSource, DataTable)
            If dt IsNot Nothing Then
                With Form3.ReportViewer1.LocalReport
                    .ReportPath = "C:\Users\ASUS\Downloads\week7\week7\Report2.rdlc"
                    .DataSources.Clear()
                    .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                End With
                Form3.Show()
                Form3.ReportViewer1.RefreshReport()
            Else
                MessageBox.Show("No data available to generate the report.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error generating report: " & ex.Message)
        End Try
    End Sub

End Class
