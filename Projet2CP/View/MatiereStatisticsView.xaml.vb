Public Class MatiereStatisticsView

    Private Sub comboBox_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim list As New List(Of String)
        list.Add("Niveau")
        list.Add("TRC1")
        list.Add("TRC2")
        list.Add("SI1")
        list.Add("SIQ1")
        list.Add("SI2")
        list.Add("SIQ2")
        list.Add("SI3")
        list.Add("SIQ3")
        NiveauCB.ItemsSource = list
    End Sub
    Private Sub AnneecomboBox_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Matieres.ItemsSource = Matiere.Matieres.ConvertAll(Function(matiere) matiere.LibeMat).Distinct().ToList
    End Sub
End Class
