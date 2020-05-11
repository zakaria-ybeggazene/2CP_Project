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

    Private Sub SaveToPng(ByVal visual As FrameworkElement, ByVal addHeight As Integer, ByVal addWidth As Integer)
        Dim encoder As New PngBitmapEncoder()
        Util.EncodeVisual(visual, encoder, addHeight, addWidth)
    End Sub

    Private Sub ButtonReussite_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles ButtonReussite.Click
        Mouse.OverrideCursor = Cursors.Wait
        SaveToPng(chart, 70, 350)
        Mouse.OverrideCursor = Nothing
    End Sub

End Class
