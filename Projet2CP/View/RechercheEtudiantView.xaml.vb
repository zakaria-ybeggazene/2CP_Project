Public Class RechercheEtudiantView

    Public Sub New()

        InitializeComponent()

    End Sub

    Private Sub PrenomChangedfr(ByVal sender As System.Object, ByVal e As RoutedEventArgs)
        If PrenomfrTB.Text.Length = 0 Then
            PrenomHintfr.Visibility = Windows.Visibility.Visible
        Else
            PrenomHintfr.Visibility = Windows.Visibility.Hidden
        End If

    End Sub
    Private Sub PrenomChangedA(ByVal sender As System.Object, ByVal e As RoutedEventArgs)
        If PrenomATB.Text.Length = 0 Then
            PrenomHintA.Visibility = Windows.Visibility.Visible
        Else
            PrenomHintA.Visibility = Windows.Visibility.Hidden
        End If

    End Sub
    Private Sub NomChangedfr(ByVal sender As System.Object, ByVal e As RoutedEventArgs)
        If NomfrTB.Text.Length = 0 Then
            NomHintfr.Visibility = Windows.Visibility.Visible
        Else
            NomHintfr.Visibility = Windows.Visibility.Hidden
        End If

    End Sub
    Private Sub NomChangedA(ByVal sender As System.Object, ByVal e As RoutedEventArgs)
        If NomATB.Text.Length = 0 Then
            NomHintA.Visibility = Windows.Visibility.Visible
        Else
            NomHintA.Visibility = Windows.Visibility.Hidden
        End If

    End Sub
    Private Sub LieuNaisChanged(ByVal sender As System.Object, ByVal e As RoutedEventArgs)
        If LieuNaisTB.Text.Length = 0 Then
            LieuNaiSHint.Visibility = Windows.Visibility.Visible
        Else
            LieuNaiSHint.Visibility = Windows.Visibility.Hidden
        End If

    End Sub
    Private Sub WilayaNaisChanged(ByVal sender As System.Object, ByVal e As RoutedEventArgs)
        If WilayaNaisTB.Text.Length = 0 Then
            WilayaNaisHint.Visibility = Windows.Visibility.Visible
        Else
            WilayaNaisHint.Visibility = Windows.Visibility.Hidden
        End If

    End Sub
    Private Sub PromoChanged(ByVal sender As System.Object, ByVal e As RoutedEventArgs)
        If PromoTB.Text.Length = 0 Then
            PromoHint.Visibility = Windows.Visibility.Visible
        Else
            PromoHint.Visibility = Windows.Visibility.Hidden
        End If

    End Sub

    Private Sub MatriculeChanged(ByVal sender As System.Object, ByVal e As RoutedEventArgs)
        If MatriculeTB.Text.Length = 0 Then
            MatriculeHint.Visibility = Windows.Visibility.Visible
        Else
            MatriculeHint.Visibility = Windows.Visibility.Hidden
        End If

    End Sub

    Private Sub comboBox_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim list As New List(Of String)
        list.Add("Sexe")
        list.Add("Masculin")
        list.Add("Feminin")
        SexeCB.ItemsSource = list
    End Sub

    Private Sub cbTest_SelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles SexeCB.SelectionChanged

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles Button2.Click
        MatriculeTB.Text = ""
        PrenomfrTB.Text = ""
        PrenomATB.Text = ""
        NomfrTB.Text = ""
        NomATB.Text = ""
        LieuNaisTB.Text = ""
        WilayaNaisTB.Text = ""
        PromoTB.Text = ""
        SexeCB.SelectedIndex = 0
        Datenaiss.SelectedDate = Nothing
    End Sub
End Class
