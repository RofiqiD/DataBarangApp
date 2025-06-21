Public Class child1


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim form5 As New Form5()

        ' Set the MdiParent to the parent form (which should be the main form)
        form5.MdiParent = Me.MdiParent

        ' Show the child2 form
        form5.Show()
    End Sub


End Class