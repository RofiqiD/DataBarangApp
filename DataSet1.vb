Partial Class DataSet1
    Partial Public Class transaksiDataTable
        Private Sub transaksiDataTable_transaksiRowChanging(sender As Object, e As transaksiRowChangeEvent) Handles Me.transaksiRowChanging

        End Sub

        Private Sub transaksiDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.total_bayarColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub
    End Class

    Partial Public Class produkDataTable
        Private Sub produkDataTable_produkRowChanging(sender As Object, e As produkRowChangeEvent) Handles Me.produkRowChanging

        End Sub

        Private Sub produkDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.hargaColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class
End Class
