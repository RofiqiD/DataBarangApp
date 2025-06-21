Public Class FormMain
    Public currentUserId As Integer
    Private Sub HomeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HomeToolStripMenuItem.Click
        Dim formC1 As New child1
        formC1.MdiParent = Me
        formC1.Show()
    End Sub

    Private Sub MenuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuToolStripMenuItem.Click
        Dim form5 As New Form5
        form5.MdiParent = Me
        form5.Show()
    End Sub

    ' Private Sub AboutUsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutUsToolStripMenuItem.Click
    'Dim form6 As New Form6
    ' form6.MdiParent = Me
    ' form6.Show()
    ' End Sub

    Private Sub TransaksiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransaksiToolStripMenuItem.Click
        Dim transaksi As New transaksi
        transaksi.MdiParent = Me
        transaksi.Show()
    End Sub


    Private Sub OrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrderToolStripMenuItem.Click
        Dim form6 As New Form6
        form6.MdiParent = Me
        form6.Show()
    End Sub



    'new
    Private Sub ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem.Click
        Dim form1 As New Form1
        form1.MdiParent = Me
        form1.Show()
    End Sub

    Private Sub TransaksiToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TransaksiToolStripMenuItem1.Click
        Dim transaksi As New transaksi
        transaksi.MdiParent = Me
        transaksi.Show()
    End Sub

    Private Sub OrderToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OrderToolStripMenuItem1.Click
        Dim form6 As New Form6
        form6.MdiParent = Me
        form6.Show()
    End Sub

    Private Sub MenuToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles MenuToolStripMenuItem1.Click
        Dim form5 As New Form5
        form5.MdiParent = Me
        form5.Show()
    End Sub

    Private Sub MulaiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MulaiToolStripMenuItem.Click
        Dim child1 As New child1()
        child1.Show()
        Me.Hide()
    End Sub


End Class