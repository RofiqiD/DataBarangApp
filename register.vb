Imports System.Data.OleDb
Imports MySql.Data.MySqlClient
Imports ZstdSharp.Unsafe

Public Class register
    Dim conn As New MySqlConnection("server=localhost;port=3306;username=root;password=;database=produklagi1")
    Dim i As Integer
    Dim dr As MySqlDataReader
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Collect user inputs
        Dim username As String = usernamebx.Text.Trim()
        Dim password As String = passwordbx.Text.Trim()
        Dim email As String = emailbx.Text.Trim()

        ' Validate inputs
        If username = "" Or password = "" Or email = "" Then
            MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            ' Open the database connection
            conn.Open()

            ' Query to insert a new user
            Dim query As String = "INSERT INTO login (username, password, email) VALUES (@username, @password, @email)"
            Dim cmd As New MySqlCommand(query, conn)
            ' Add parameters to avoid SQL injection
            cmd.Parameters.AddWithValue("@username", username)
            cmd.Parameters.AddWithValue("@password", password)
            cmd.Parameters.AddWithValue("@email", email)

            ' Execute the query
            Dim result As Integer = cmd.ExecuteNonQuery()

            If result > 0 Then
                MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' Clear input fields
                usernamebx.Clear()
                passwordbx.Clear()
                emailbx.Clear()
            Else
                MessageBox.Show("Registration failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As MySqlException
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Close the database connection
            conn.Close()
        End Try

    End Sub

    Private Sub usernamebx_TextChanged(sender As Object, e As EventArgs) Handles usernamebx.TextChanged

    End Sub

    Private Sub emailbx_TextChanged(sender As Object, e As EventArgs) Handles emailbx.TextChanged

    End Sub

    Private Sub passwordbx_TextChanged(sender As Object, e As EventArgs) Handles passwordbx.TextChanged

    End Sub

    Private Sub linklogin_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linklogin.LinkClicked
        Dim login As New login()
        login.Show()
        Me.Hide()
    End Sub

    Private Sub register_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class