Public Class EtudiantView

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
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
        Validite()
        MsgBox("bouton cliqué, modeModif = " & modeModif)
    End Sub


    Private Sub NomfrTB_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.TextChangedEventArgs) Handles NomfrTB.TextChanged
        If modeModif = True Then
            'MsgBox("suis dans nom")
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
            'MsgBox("suis dans nompere")
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
            'MsgBox("suis dans nomere")
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
            'MsgBox("suis dans lieunais")
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
            'MsgBox("suis dans wilayanais")
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
            'MsgBox("suis dans prénom")
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
            'MsgBox("suis dans adresse")
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
            'MsgBox("suis dans ville")
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
            'MsgBox("suis dans wilaya")
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
            'MsgBox("suis dans codepostal")
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
            'MsgBox("suis dans prénomA")
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
            'MsgBox("suis dans nomA")
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
                MsgBox("il y a un label rouge ")
            ElseIf nomAV.IsVisible Or prenomAV.IsVisible Or wilayaV.IsVisible Then
                Savebutton.IsEnabled = False
                MsgBox("il y a un label rouge ")
            ElseIf lieuNV.IsVisible Or wilayaNV.IsVisible Or codePF.IsVisible Then
                Savebutton.IsEnabled = False
                MsgBox("il y a un label rouge ")
            ElseIf nomMomV.IsVisible Or nomPereV.IsVisible Or VilleV.IsVisible Then
                Savebutton.IsEnabled = False
                MsgBox("il y a un label rouge ")
            Else
                Savebutton.IsEnabled = True
                MsgBox("il n'y a pas de label rouge: ")
            End If
        End If
    End Sub
End Class
