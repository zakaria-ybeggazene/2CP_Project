Imports System.Collections.ObjectModel

Public Class RechercheEtudiantViewModel
    Inherits WorkspaceViewModel

    Public Sub New(ByVal displayName As String, ByRef w As ObservableCollection(Of WorkspaceViewModel))
        MyBase.New(displayName)
        v = New RechercheEtudiantView()
        Me._workspaces = w
        Me.EtudiantOnglet = New RelayCommand(AddressOf AddEtudiantView)
    End Sub

    Private _workspaces As ObservableCollection(Of WorkspaceViewModel)
    Private v As RechercheEtudiantView

    Private _etudiantOnglet As ICommand
    Public Property EtudiantOnglet As ICommand
        Get
            Return _etudiantOnglet
        End Get
        Set(ByVal value As ICommand)
            _etudiantOnglet = value
        End Set
    End Property

    Private Sub AddEtudiantView(ByVal o As Object)
        Dim e As New Etudiant With {.Adresse = "Moscou", .CodePostal = 1500, .DateNais = New Date(), .LieuNais = "Bejaia", .LieuNaisA = "Bejaia arabe", .Matricule = "18/0225", .Nom = "Mohamed", .NomA = "Mohamed Arabe", .NomMere = "Nom mere", .Prenom = "prenom", .PrenomA = "prenom arabe", .PrenomPere = "prenom pere", .Ville = "alger", .Wilaya = "alger", .WilayaNaisA = "Baghdad", .WilayaNaisCode = 12}
        e = Repository.paracours_etudiant(e)
        Dim workspace As WorkspaceViewModel = New EtudiantViewModel("Etudiant", e)
        AddHandler workspace.Close, AddressOf Me.OnWorkspaceClose

        _workspaces.Add(workspace)
    End Sub
    Private Sub OnWorkspaceClose(ByVal sender As WorkspaceViewModel)
        _workspaces.Remove(sender)
    End Sub
End Class
