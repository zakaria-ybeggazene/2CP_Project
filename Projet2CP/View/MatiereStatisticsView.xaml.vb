Public Class MatiereStatisticsView

    Private Sub comboBox_Loaded()
        Dim list As New List(Of String)
        list.Add("Niveau")
        list.Add("TRC1")
        list.Add("TRC2")
        list.Add("SI1")
        list.Add("SIQ1")
        list.Add("SI2")
        list.Add("SIQ2")
        NiveauCB.ItemsSource = list
        NiveauCB.SelectedItem = "Niveau"
    End Sub
    Private Sub AnneecomboBox_Loaded()
        Dim list As New List(Of String)
        list.Add("Matière")
        If NiveauCB.SelectedItem <> "Niveau" Then
            For Each Mat As Matiere In Matiere.Matieres
                If Util.stringToNiveau(NiveauCB.SelectedItem) = Mat.NiveauM Then
                    list.Add(Mat.LibeMat)
                End If
            Next
        End If
        Matieres.ItemsSource = list.Distinct.ToList
        Matieres.SelectedItem = "Matière"
    End Sub
    Private Sub AnneeCB_SelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles NiveauCB.SelectionChanged
        AnneecomboBox_Loaded()
    End Sub
End Class
