Public Class EtudiantView

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'Modifierbutton.IsEnabled = Repository.admin
        Savebutton.Visibility = Windows.Visibility.Hidden
    End Sub
    Private Sub ComboBox_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim list As New List(Of String)
        list.Add("1")
        list.Add("2")
        list.Add("3")
        list.Add("4")
        NiveauCB.ItemsSource = list
    End Sub
    Private Sub Sexecb_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim list As New List(Of String)
        list.Add("Masculin")
        list.Add("Féminin")
        Sexecb.ItemsSource = list
    End Sub
    Private modeModif As Boolean = False
    Private Sub Modifierbutton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Modifierbutton.Click
        NomfrTB.IsReadOnly = False
        NomATB.IsReadOnly = False
        PrenomfrTB.IsReadOnly = False
        PrenomATB.IsReadOnly = False
        LieuNais.IsReadOnly = False
        Wilaya.IsReadOnly = False
        DateNais.IsEnabled = True
        Adresse.IsReadOnly = False
        Ville.IsReadOnly = False
        wilayaNais.IsReadOnly = False
        codePostale.IsReadOnly = False
        nomPere.IsReadOnly = False
        nomMere.IsReadOnly = False
        Sexecb.IsEnabled = True
        modeModif = True
        Savebutton.Visibility = Windows.Visibility.Visible
        Modifierbutton.Visibility = Windows.Visibility.Hidden
        releve.IsEnabled = False
        releve_glob.IsEnabled = False
        Attestation.IsEnabled = False
        Validite()
    End Sub


    Private Sub NomfrTB_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.TextChangedEventArgs) Handles NomfrTB.TextChanged
        If modeModif = True Then
            If modeModif = True Then
                If NomfrTB.Text.Length <> 0 Then
                    nomV.Visibility = Windows.Visibility.Hidden
                Else
                    nomV.Visibility = Windows.Visibility.Visible
                End If
            End If
            Validite()
        End If
    End Sub

    Private Sub nomPere_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.TextChangedEventArgs) Handles nomPere.TextChanged
        If modeModif = True Then
            If modeModif = True Then
                If nomPere.Text.Length <> 0 Then
                    nomPereV.Visibility = Windows.Visibility.Hidden
                Else
                    nomPereV.Visibility = Windows.Visibility.Visible
                End If
            End If
            Validite()
        End If

    End Sub

    Private Sub nomMere_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.TextChangedEventArgs) Handles nomMere.TextChanged
        If modeModif = True Then
            If modeModif = True Then
                If nomMere.Text.Length <> 0 Then
                    nomMomV.Visibility = Windows.Visibility.Hidden
                Else
                    nomMomV.Visibility = Windows.Visibility.Visible
                End If
            End If
            Validite()
        End If
    End Sub

    Private Sub LieuNais_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.TextChangedEventArgs) Handles LieuNais.TextChanged
        If modeModif = True Then
            If modeModif = True Then
                If LieuNais.Text.Length <> 0 Then
                    lieuNV.Visibility = Windows.Visibility.Hidden
                Else
                    lieuNV.Visibility = Windows.Visibility.Visible
                End If
            End If
            Validite()
        End If
    End Sub

    Private Sub wilayaNais_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.TextChangedEventArgs) Handles wilayaNais.TextChanged
        If modeModif = True Then
            If modeModif = True Then
                If wilayaNais.Text.Length <> 0 Then
                    wilayaNV.Visibility = Windows.Visibility.Hidden
                Else
                    wilayaNV.Visibility = Windows.Visibility.Visible
                End If
            End If
            Validite()
        End If
    End Sub

    Private Sub PrenomfrTB_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.TextChangedEventArgs) Handles PrenomfrTB.TextChanged
        If modeModif = True Then
            If modeModif = True Then
                If PrenomfrTB.Text.Length <> 0 Then
                    prenomV.Visibility = Windows.Visibility.Hidden
                Else
                    prenomV.Visibility = Windows.Visibility.Visible
                End If
            End If
            Validite()
        End If
    End Sub

    Private Sub Adresse_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.TextChangedEventArgs) Handles Adresse.TextChanged
        If modeModif = True Then
            If modeModif = True Then
                If Adresse.Text.Length <> 0 Then
                    adresseV.Visibility = Windows.Visibility.Hidden
                Else
                    adresseV.Visibility = Windows.Visibility.Visible
                End If
            End If
            Validite()
        End If
    End Sub

    Private Sub Ville_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.TextChangedEventArgs) Handles Ville.TextChanged
        If modeModif = True Then
            If modeModif = True Then
                If Ville.Text.Length <> 0 Then
                    VilleV.Visibility = Windows.Visibility.Hidden
                Else
                    VilleV.Visibility = Windows.Visibility.Visible
                End If
            End If
            Validite()
        End If
    End Sub

    Private Sub Wilaya_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.TextChangedEventArgs) Handles Wilaya.TextChanged
        If modeModif = True Then
            If modeModif = True Then
                If Wilaya.Text.Length <> 0 Then
                    wilayaV.Visibility = Windows.Visibility.Hidden
                Else
                    wilayaV.Visibility = Windows.Visibility.Visible
                End If
            End If
            Validite()
        End If
    End Sub

    Private Sub codePostale_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.TextChangedEventArgs) Handles codePostale.TextChanged
        If modeModif = True Then
            Try
                Integer.Parse(codePostale.Text)
                If codePostale.Text.Length <> 5 Then Throw New Exception()
                codePF.Visibility = Windows.Visibility.Hidden
            Catch ex As Exception
                codePF.Visibility = Windows.Visibility.Visible
            End Try
            Validite()
        End If
    End Sub

    Private Sub PrenomATB_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.TextChangedEventArgs) Handles PrenomATB.TextChanged
        If modeModif = True Then
            If modeModif = True Then
                If PrenomATB.Text.Length <> 0 Then
                    prenomAV.Visibility = Windows.Visibility.Hidden
                Else
                    prenomAV.Visibility = Windows.Visibility.Visible
                End If
            End If
            Validite()
        End If
    End Sub

    Private Sub NomATB_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.TextChangedEventArgs) Handles NomATB.TextChanged
        If modeModif = True Then
            If modeModif = True Then
                If NomATB.Text.Length <> 0 Then
                    nomAV.Visibility = Windows.Visibility.Hidden
                Else
                    nomAV.Visibility = Windows.Visibility.Visible
                End If
            End If
            Validite()
        End If
    End Sub

    Private Sub Validite()
        If modeModif = True Then
            If nomV.IsVisible Or prenomV.IsVisible Or adresseV.IsVisible Then
                Savebutton.IsEnabled = False
            ElseIf nomAV.IsVisible Or prenomAV.IsVisible Or wilayaV.IsVisible Then
                Savebutton.IsEnabled = False
            ElseIf lieuNV.IsVisible Or wilayaNV.IsVisible Or codePF.IsVisible Then
                Savebutton.IsEnabled = False
            ElseIf nomMomV.IsVisible Or nomPereV.IsVisible Or VilleV.IsVisible Then
                Savebutton.IsEnabled = False
            ElseIf DateNV.IsVisible Then
                Savebutton.IsEnabled = False
            Else
                Savebutton.IsEnabled = True
            End If
        End If
    End Sub

    Private Sub DateNais_SelectedDateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles DateNais.SelectedDateChanged
        If modeModif = True Then
            If modeModif = True Then
                If DateNais.Text.Length <> 0 Then
                    DateNV.Visibility = Windows.Visibility.Hidden
                Else
                    DateNV.Visibility = Windows.Visibility.Visible
                End If
            End If
            Validite()
        End If
    End Sub

    Private Sub Savebutton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Savebutton.Click
        modeModif = False
        Modifierbutton.Visibility = Windows.Visibility.Visible
        Savebutton.Visibility = Windows.Visibility.Hidden
        releve.IsEnabled = True
        releve_glob.IsEnabled = True
        Attestation.IsEnabled = True
        NomfrTB.IsReadOnly = True
        NomATB.IsReadOnly = True
        PrenomfrTB.IsReadOnly = True
        PrenomATB.IsReadOnly = True
        LieuNais.IsReadOnly = True
        Wilaya.IsReadOnly = True
        DateNais.IsEnabled = False
        Adresse.IsReadOnly = True
        Ville.IsReadOnly = True
        wilayaNais.IsReadOnly = True
        codePostale.IsReadOnly = True
        nomPere.IsReadOnly = True
        nomMere.IsReadOnly = True
        Sexecb.IsEnabled = False
    End Sub

End Class