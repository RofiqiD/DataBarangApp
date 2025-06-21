Imports System.Data.OleDb
Imports MySql.Data.MySqlClient
Imports ZstdSharp.Unsafe

Public Class login
    Dim conn As New MySqlConnection("server=localhost;port=3306;username=root;password=;database=produklagi1")
    Dim i As Integer
    Dim dr As MySqlDataReader


    Public Function Login(username As String, password As String) As Boolean
        Try
            conn.Open()
            Dim cmd As New MySqlCommand("SELECT id_user FROM login WHERE username = @Username AND password = @Password", conn)
            cmd.Parameters.AddWithValue("@Username", username)
            cmd.Parameters.AddWithValue("@Password", password)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                ''currentUserId = reader.GetInt32("id_user") ' Simpan id_user di variabel global
                reader.Close()
                Return True
            Else
                reader.Close()
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Error during login: " & ex.Message)
            Return False
        Finally
            conn.Close()
        End Try
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim username As String = usernamebx.Text.Trim()
        Dim password As String = passwordbx.Text.Trim()

        ' Validate inputs
        If username = "" Or password = "" Then
            MessageBox.Show("Please enter both username and password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            ' Open the database connection
            conn.Open()

            ' Query to check user credentials
            Dim query As String = "SELECT * FROM login WHERE username = @username AND password = @password"
            Dim cmd As New MySqlCommand(query, conn)

            ' Add parameters to prevent SQL injection
            cmd.Parameters.AddWithValue("@username", username)
            cmd.Parameters.AddWithValue("@password", password)

            ' Execute the query
            Dim dr As MySqlDataReader = cmd.ExecuteReader()

            If dr.HasRows Then
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' Redirect to another form or functionality
                Dim mdiForm As New FormMain()

                ' Optionally, you can pass data to the MDI parent form here
                ' mdiForm.SomeProperty = "Some Value"

                ' Show the MDI parent form
                mdiForm.Show()
                Me.Hide()  ' or 
            Else
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As MySqlException
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Close the database connection
            conn.Close()
        End Try



    End Sub

    Private Sub Linkregister_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Linkregister.LinkClicked
        Dim register As New register()
        register.Show()
        Me.Hide()
    End Sub

    Private Sub passwordbx_TextChanged(sender As Object, e As EventArgs) Handles passwordbx.TextChanged

    End Sub

    Private Sub usernamebx_TextChanged(sender As Object, e As EventArgs) Handles usernamebx.TextChanged

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub
End Class