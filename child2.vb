Imports System.Data.OleDb
Imports MySql.Data.MySqlClient
Imports ZstdSharp.Unsafe


Public Class child2
    Dim conn As New MySqlConnection("server=localhost;port=3306;username=root;password=;database=produklagi1")
    Dim i As Integer
    Dim dr As MySqlDataReader

    Private Sub child2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProductData(Label1, rasa1, kategori1, toping1, harga1, 1)
        LoadProductData(Label2, rasa2, kategori2, toping2, harga2, 2)
        LoadProductData(Label3, rasa3, kategori3, toping3, harga3, 3)
        LoadProductData(Label4, rasa4, kategori4, toping4, harga4, 4)
        LoadProductData(Label5, rasa5, kaegori5, toping5, harga5, 5)
        LoadProductData(Label6, rasa6, kategori6, toping6, harga6, 20)
        AssignButtonEvents()
        ' Assuming this is the ID for Label6
    End Sub

    Private Sub LoadProductData(label As Label, rasaLabel As Label, kategoriLabel As Label, topingLabel As Label, hargaLabel As Label, id As Integer)
        Try
            conn.Open()
            Dim query As String = "SELECT nama, rasa, kategori, toping, harga FROM produk WHERE id = @id"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@id", id)

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        label.Text = reader("nama").ToString()
                        rasaLabel.Text = reader("rasa").ToString()
                        kategoriLabel.Text = reader("kategori").ToString()
                        topingLabel.Text = reader("toping").ToString()
                        hargaLabel.Text = reader("harga").ToString()
                    Else
                        label.Text = "Product not found."
                        rasaLabel.Text = ""
                        kategoriLabel.Text = ""
                        topingLabel.Text = ""
                        hargaLabel.Text = ""
                    End If
                End Using
            End Using
        Catch ex As MySqlException
            MessageBox.Show("Database error: " & ex.Message)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub



    Private Sub Button_Click(sender As Object, e As EventArgs)
        Dim clickedButton As Button = CType(sender, Button)
        Dim productName As String = String.Empty
        Dim productId As Integer = 0

        ' Determine which button was clicked and set productName and productId
        Select Case clickedButton.Name
            Case "Button1"
                productName = Label1.Text
                productId = 1
            Case "Button2"
                productName = Label2.Text
                productId = 2
            Case "Button3"
                productName = Label3.Text
                productId = 3
            Case "Button4"
                productName = Label4.Text
                productId = 4
            Case "Button5"
                productName = Label5.Text
                productId = 5
            Case "Button6"
                productName = Label6.Text
                productId = 20
        End Select

        ' Check if productName is valid
        If String.IsNullOrEmpty(productName) Then
            MessageBox.Show("Product name is empty.")
            Return
        End If

        ' Check if formorder is already open
        For Each f As Form In Application.OpenForms
            If TypeOf f Is formorder Then
                ' If formorder is already open, bring it to the front
                f.BringToFront()
                Return
            End If
        Next

        ' Open formorder and set the product name and ID
        ' Dim orderForm As New formorder()
        ' orderForm.ProductName = productName
        'orderForm.ProductId = productId
        ''orderForm.UserId = currentUserId
        ' orderForm.Show()
        Me.Hide()
    End Sub


    Private Sub AssignButtonEvents()
        AddHandler Button1.Click, AddressOf Button_Click
        AddHandler Button2.Click, AddressOf Button_Click
        AddHandler Button3.Click, AddressOf Button_Click
        AddHandler Button4.Click, AddressOf Button_Click
        AddHandler Button5.Click, AddressOf Button_Click
        AddHandler Button6.Click, AddressOf Button_Click
    End Sub

    Private Sub rasa1_Click(sender As Object, e As EventArgs) Handles rasa1.Click

    End Sub

    Private Sub rasa2_Click(sender As Object, e As EventArgs) Handles rasa2.Click

    End Sub

    Private Sub rasa3_Click(sender As Object, e As EventArgs) Handles rasa3.Click

    End Sub

    Private Sub rasa4_Click(sender As Object, e As EventArgs) Handles rasa4.Click

    End Sub

    Private Sub rasa5_Click(sender As Object, e As EventArgs) Handles rasa5.Click

    End Sub

    Private Sub rasa6_Click(sender As Object, e As EventArgs) Handles rasa6.Click

    End Sub

    Private Sub kategori1_Click(sender As Object, e As EventArgs) Handles kategori1.Click

    End Sub

    Private Sub kategori2_Click(sender As Object, e As EventArgs) Handles kategori2.Click

    End Sub

    Private Sub kategori3_Click(sender As Object, e As EventArgs) Handles kategori3.Click

    End Sub

    Private Sub kategori4_Click(sender As Object, e As EventArgs) Handles kategori4.Click

    End Sub

    Private Sub kaegori5_Click(sender As Object, e As EventArgs) Handles kaegori5.Click

    End Sub

    Private Sub kategori6_Click(sender As Object, e As EventArgs) Handles kategori6.Click

    End Sub

    Private Sub toping1_Click(sender As Object, e As EventArgs) Handles toping1.Click

    End Sub

    Private Sub toping2_Click(sender As Object, e As EventArgs) Handles toping2.Click

    End Sub

    Private Sub toping3_Click(sender As Object, e As EventArgs) Handles toping3.Click

    End Sub

    Private Sub toping4_Click(sender As Object, e As EventArgs) Handles toping4.Click

    End Sub

    Private Sub toping5_Click(sender As Object, e As EventArgs) Handles toping5.Click

    End Sub

    Private Sub toping6_Click(sender As Object, e As EventArgs) Handles toping6.Click

    End Sub

    Private Sub harga4_Click(sender As Object, e As EventArgs) Handles harga4.Click

    End Sub

    Private Sub harga5_Click(sender As Object, e As EventArgs) Handles harga5.Click

    End Sub

    Private Sub harga6_Click(sender As Object, e As EventArgs) Handles harga6.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class