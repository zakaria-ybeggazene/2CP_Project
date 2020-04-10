Imports System.Collections.ObjectModel

Public Class RechercheEtudiantView

    Public Sub New()

        InitializeComponent()



    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)

    End Sub


    Private Sub PreNomChangedfr(ByVal sender As System.Object, ByVal e As RoutedEventArgs)
        If PreNomfr.Text.Length = 0 Then
            PreNomHintfr.Visibility = Windows.Visibility.Visible
        Else
            PreNomHintfr.Visibility = Windows.Visibility.Hidden
        End If

    End Sub
    Private Sub NomChangedfr(ByVal sender As System.Object, ByVal e As RoutedEventArgs)
        If Nomfr.Text.Length = 0 Then
            NomHintfr.Visibility = Windows.Visibility.Visible
        Else
            NomHintfr.Visibility = Windows.Visibility.Hidden
        End If

    End Sub
    Private Sub WilayaChanged(ByVal sender As System.Object, ByVal e As RoutedEventArgs)
        If Wilaya.Text.Length = 0 Then
            WilayaHint.Visibility = Windows.Visibility.Visible
        Else
            WilayaHint.Visibility = Windows.Visibility.Hidden
        End If

    End Sub

    Private Sub MatriculeChanged(ByVal sender As System.Object, ByVal e As RoutedEventArgs)
        If Matricule.Text.Length = 0 Then
            MatriculeHint.Visibility = Windows.Visibility.Visible
        Else
            MatriculeHint.Visibility = Windows.Visibility.Hidden
        End If

    End Sub



    'just for test 
    Private Sub thisONe(ByVal sender As System.Object, ByVal e As RoutedEventArgs)
        Dim Etudiants As List(Of Etudiant) = New List(Of Etudiant)()
        Etudiants.Add(New Etudiant() With {
            .Nom = "hakim",
            .Prenom = "addjou",
            .Matricule = "123456",
            .DateNais = New DateTime(2000, 7, 23),
            .LieuNais = "alger",
            .AnnIns = 2018
        })
        Etudiants.Add(New Etudiant() With {
            .Nom = "hakim",
            .Prenom = "addjou",
            .Matricule = "123456",
            .DateNais = New DateTime(2000, 7, 23),
            .LieuNais = "alger",
            .AnnIns = 2018
        })
        Etudiants.Add(New Etudiant() With {
            .Nom = "hakim",
            .Prenom = "addjou",
            .Matricule = "123456",
            .DateNais = New DateTime(2000, 7, 23),
            .LieuNais = "alger",
            .AnnIns = 2018
        })
        Etudiants.Add(New Etudiant() With {
            .Nom = "hakim",
            .Prenom = "addjou",
            .Matricule = "123456",
            .DateNais = New DateTime(2000, 7, 23),
            .LieuNais = "alger",
            .AnnIns = 2018
        })
        Etudiants.Add(New Etudiant() With {
            .Nom = "hakim",
            .Prenom = "addjou",
            .Matricule = "123456",
            .DateNais = New DateTime(2000, 7, 23),
            .LieuNais = "alger",
            .AnnIns = 2018
        })
        Etudiants.Add(New Etudiant() With {
            .Nom = "hakim",
            .Prenom = "addjou",
            .Matricule = "123456",
            .DateNais = New DateTime(2000, 7, 23),
            .LieuNais = "alger",
            .AnnIns = 2018
        })
        Etudiants.Add(New Etudiant() With {
            .Nom = "hakim",
            .Prenom = "addjou",
            .Matricule = "123456",
            .DateNais = New DateTime(2000, 7, 23),
            .LieuNais = "alger",
            .AnnIns = 2018
        })
        Etudiants.Add(New Etudiant() With {
            .Nom = "hakim",
            .Prenom = "addjou",
            .Matricule = "123456",
            .DateNais = New DateTime(2000, 7, 23),
            .LieuNais = "alger",
            .AnnIns = 2018
        })
        Etudiants.Add(New Etudiant() With {
            .Nom = "hakim",
            .Prenom = "addjou",
            .Matricule = "123456",
            .DateNais = New DateTime(2000, 7, 23),
            .LieuNais = "alger",
            .AnnIns = 2018
        })
        Etudiants.Add(New Etudiant() With {
            .Nom = "hakim",
            .Prenom = "addjou",
            .Matricule = "123456",
            .DateNais = New DateTime(2000, 7, 23),
            .LieuNais = "alger",
            .AnnIns = 2018
        })
        Etudiants.Add(New Etudiant() With {
            .Nom = "hakim",
            .Prenom = "addjou",
            .Matricule = "123456",
            .DateNais = New DateTime(2000, 7, 23),
            .LieuNais = "alger",
            .AnnIns = 2018
        })
        Etudiants.Add(New Etudiant() With {
            .Nom = "hakim",
            .Prenom = "addjou",
            .Matricule = "123456",
            .DateNais = New DateTime(2000, 7, 23),
            .LieuNais = "alger",
            .AnnIns = 2018
        })
        Etudiants.Add(New Etudiant() With {
            .Nom = "hakim",
            .Prenom = "addjou",
            .Matricule = "123456",
            .DateNais = New DateTime(2000, 7, 23),
            .LieuNais = "alger",
            .AnnIns = 2018
        })
        Etudiants.Add(New Etudiant() With {
            .Nom = "hakim",
            .Prenom = "addjou",
            .Matricule = "123456",
            .DateNais = New DateTime(2000, 7, 23),
            .LieuNais = "alger",
            .AnnIns = 2018
        })
        Etudiants.Add(New Etudiant() With {
            .Nom = "hakim",
            .Prenom = "addjou",
            .Matricule = "123456",
            .DateNais = New DateTime(2000, 7, 23),
            .LieuNais = "alger",
            .AnnIns = 2018
        })
        Etudiants.Add(New Etudiant() With {
            .Nom = "hakim",
            .Prenom = "addjou",
            .Matricule = "123456",
            .DateNais = New DateTime(2000, 7, 23),
            .LieuNais = "alger",
            .AnnIns = 2018
        })
        Etudiants.Add(New Etudiant() With {
            .Nom = "hakim",
            .Prenom = "addjou",
            .Matricule = "123456",
            .DateNais = New DateTime(2000, 7, 23),
            .LieuNais = "alger",
            .AnnIns = 2018
        })
        Etudiants.Add(New Etudiant() With {
            .Nom = "hakim",
            .Prenom = "addjou",
            .Matricule = "123456",
            .DateNais = New DateTime(2000, 7, 23),
            .LieuNais = "alger",
            .AnnIns = 2018
        })
        Etudiants.Add(New Etudiant() With {
            .Nom = "hakim",
            .Prenom = "addjou",
            .Matricule = "123456",
            .DateNais = New DateTime(2000, 7, 23),
            .LieuNais = "alger",
            .AnnIns = 2018
        })


        Mygrid.ItemsSource = Etudiants
    End Sub

    Private Sub Image2_ImageFailed(ByVal sender As System.Object, ByVal e As System.Windows.ExceptionRoutedEventArgs)

    End Sub

    Private Sub Mygrid_SelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles Mygrid.SelectionChanged

    End Sub

    Private Sub Openbutton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)

    End Sub

    Private Sub Login_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Filter.Click

    End Sub

    Private Sub Filter_FocusableChanged(ByVal sender As System.Object, ByVal e As System.Windows.DependencyPropertyChangedEventArgs)

    End Sub
End Class
