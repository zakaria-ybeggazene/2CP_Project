Imports System.Collections.ObjectModel

Public Class RechercheEtudiantView

    Public Sub New()

        InitializeComponent()



    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.Windows.RoutedEventArgs)

    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.Windows.RoutedEventArgs)

    End Sub


    Private Sub PreNomChangedfr(sender As System.Object, e As RoutedEventArgs)
        If PreNomfr.Text.Length = 0 Then
            PreNomHintfr.Visibility = Windows.Visibility.Visible
        Else
            PreNomHintfr.Visibility = Windows.Visibility.Hidden
        End If

    End Sub
    Private Sub NomChangedfr(sender As System.Object, e As RoutedEventArgs)
        If Nomfr.Text.Length = 0 Then
            NomHintfr.Visibility = Windows.Visibility.Visible
        Else
            NomHintfr.Visibility = Windows.Visibility.Hidden
        End If

    End Sub
    Private Sub WilayaChanged(sender As System.Object, e As RoutedEventArgs)
        If Wilaya.Text.Length = 0 Then
            WilayaHint.Visibility = Windows.Visibility.Visible
        Else
            WilayaHint.Visibility = Windows.Visibility.Hidden
        End If

    End Sub
   
    Private Sub MatriculeChanged(sender As System.Object, e As RoutedEventArgs)
        If Matricule.Text.Length = 0 Then
            MatriculeHint.Visibility = Windows.Visibility.Visible
        Else
            MatriculeHint.Visibility = Windows.Visibility.Hidden
        End If

    End Sub



    'just for test 
    Private Sub thisONe(sender As System.Object, e As RoutedEventArgs)
        Dim Etudiants As List(Of Etudiant) = New List(Of Etudiant)()
        Etudiants.Add(New Etudiant() With {
            .Nom = "hakim",
            .Prenom = "addjou",
            .Matricule = "123456",
            .DateNais = New DateTime(2000, 7, 23),
            .Wilaya = "alger",
            .AnnIns = 2018
        })
        Etudiants.Add(New Etudiant() With {
            .Nom = "hakim",
            .Prenom = "addjou",
            .Matricule = "123456",
            .DateNais = New DateTime(2000, 7, 23),
            .Wilaya = "alger",
            .AnnIns = 2018
        })
        Etudiants.Add(New Etudiant() With {
            .Nom = "hakim",
            .Prenom = "addjou",
            .Matricule = "123456",
            .DateNais = New DateTime(2000, 7, 23),
            .Wilaya = "alger",
            .AnnIns = 2018
        })
        Etudiants.Add(New Etudiant() With {
            .Nom = "hakim",
            .Prenom = "addjou",
            .Matricule = "123456",
            .DateNais = New DateTime(2000, 7, 23),
            .Wilaya = "alger",
            .AnnIns = 2018
        })
        Etudiants.Add(New Etudiant() With {
            .Nom = "hakim",
            .Prenom = "addjou",
            .Matricule = "123456",
            .DateNais = New DateTime(2000, 7, 23),
            .Wilaya = "alger",
            .AnnIns = 2018
        })
        Etudiants.Add(New Etudiant() With {
            .Nom = "hakim",
            .Prenom = "addjou",
            .Matricule = "123456",
            .DateNais = New DateTime(2000, 7, 23),
            .Wilaya = "alger",
            .AnnIns = 2018
        })
        Etudiants.Add(New Etudiant() With {
            .Nom = "hakim",
            .Prenom = "addjou",
            .Matricule = "123456",
            .DateNais = New DateTime(2000, 7, 23),
            .Wilaya = "alger",
            .AnnIns = 2018
        })
        Etudiants.Add(New Etudiant() With {
            .Nom = "hakim",
            .Prenom = "addjou",
            .Matricule = "123456",
            .DateNais = New DateTime(2000, 7, 23),
            .Wilaya = "alger",
            .AnnIns = 2018
        })
        Etudiants.Add(New Etudiant() With {
            .Nom = "hakim",
            .Prenom = "addjou",
            .Matricule = "123456",
            .DateNais = New DateTime(2000, 7, 23),
            .Wilaya = "alger",
            .AnnIns = 2018
        })
        Etudiants.Add(New Etudiant() With {
            .Nom = "hakim",
            .Prenom = "addjou",
            .Matricule = "123456",
            .DateNais = New DateTime(2000, 7, 23),
            .Wilaya = "alger",
            .AnnIns = 2018
        })
        Etudiants.Add(New Etudiant() With {
            .Nom = "hakim",
            .Prenom = "addjou",
            .Matricule = "123456",
            .DateNais = New DateTime(2000, 7, 23),
            .Wilaya = "alger",
            .AnnIns = 2018
        })
        Etudiants.Add(New Etudiant() With {
            .Nom = "hakim",
            .Prenom = "addjou",
            .Matricule = "123456",
            .DateNais = New DateTime(2000, 7, 23),
            .Wilaya = "alger",
            .AnnIns = 2018
        })
        Etudiants.Add(New Etudiant() With {
            .Nom = "hakim",
            .Prenom = "addjou",
            .Matricule = "123456",
            .DateNais = New DateTime(2000, 7, 23),
            .Wilaya = "alger",
            .AnnIns = 2018
        })
        Etudiants.Add(New Etudiant() With {
            .Nom = "hakim",
            .Prenom = "addjou",
            .Matricule = "123456",
            .DateNais = New DateTime(2000, 7, 23),
            .Wilaya = "alger",
            .AnnIns = 2018
        })
        Etudiants.Add(New Etudiant() With {
            .Nom = "hakim",
            .Prenom = "addjou",
            .Matricule = "123456",
            .DateNais = New DateTime(2000, 7, 23),
            .Wilaya = "alger",
            .AnnIns = 2018
        })
        Etudiants.Add(New Etudiant() With {
            .Nom = "hakim",
            .Prenom = "addjou",
            .Matricule = "123456",
            .DateNais = New DateTime(2000, 7, 23),
            .Wilaya = "alger",
            .AnnIns = 2018
        })
        Etudiants.Add(New Etudiant() With {
            .Nom = "hakim",
            .Prenom = "addjou",
            .Matricule = "123456",
            .DateNais = New DateTime(2000, 7, 23),
            .Wilaya = "alger",
            .AnnIns = 2018
        })
        Etudiants.Add(New Etudiant() With {
            .Nom = "hakim",
            .Prenom = "addjou",
            .Matricule = "123456",
            .DateNais = New DateTime(2000, 7, 23),
            .Wilaya = "alger",
            .AnnIns = 2018
        })
        Etudiants.Add(New Etudiant() With {
            .Nom = "hakim",
            .Prenom = "addjou",
            .Matricule = "123456",
            .DateNais = New DateTime(2000, 7, 23),
            .Wilaya = "alger",
            .AnnIns = 2018
        })


        Mygrid.ItemsSource = Etudiants
    End Sub

    Private Sub Image2_ImageFailed(sender As System.Object, e As System.Windows.ExceptionRoutedEventArgs)

    End Sub

    Private Sub Mygrid_SelectionChanged(sender As System.Object, e As System.Windows.Controls.SelectionChangedEventArgs) Handles Mygrid.SelectionChanged

    End Sub

    Private Sub Openbutton_Click(sender As System.Object, e As System.Windows.RoutedEventArgs)

    End Sub
 
    Private Sub Login_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles Login.Click

    End Sub
End Class
