Public Class EtudiantView
    Private Sub Sexecb_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim list As New List(Of String)
        list.Add("Masculin")
        list.Add("Féminin")
        Sexecb.ItemsSource = list
    End Sub
    Private Sub ComboBox_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim list As New List(Of String)
        list.Add("1")
        list.Add("2")
        list.Add("3")
        list.Add("4")
        NiveauCB.ItemsSource = list
    End Sub

    Private Sub NomATB_TextChanged(sender As System.Object, e As System.Windows.Controls.TextChangedEventArgs) Handles NomATB.TextChanged

    End Sub
End Class