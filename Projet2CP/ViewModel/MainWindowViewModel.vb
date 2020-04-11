Imports System.Collections.ObjectModel
Public Class MainWindowViewModel
    Inherits ViewModelBase
    Private _workspaces As ObservableCollection(Of WorkspaceViewModel)
    Property Workspaces As ObservableCollection(Of WorkspaceViewModel)
        Get
            Return _workspaces
        End Get
        Set(ByVal value As ObservableCollection(Of WorkspaceViewModel))
            _workspaces = value
        End Set
    End Property
    Private _commands As ObservableCollection(Of CommandViewModel)
    Public Property Commands As ObservableCollection(Of CommandViewModel)
        Get
            Return _commands
        End Get
        Set(ByVal value As ObservableCollection(Of CommandViewModel))
            _commands = value
        End Set
    End Property

    Public Sub New()
        _workspaces = New ObservableCollection(Of WorkspaceViewModel)()
        'We'll add a starting menu here at initializing

        _commands = New ObservableCollection(Of CommandViewModel)({
            New CommandViewModel("Recherche Etudiant", New RelayCommand(AddressOf Me.AddRechercheEtudiantView)),
            New CommandViewModel("Recherche Promotion", New RelayCommand(AddressOf Me.AddRecherchePromoView)),
            New CommandViewModel("Statistiques", New RelayCommand(AddressOf Me.AddStatisticsView))})
    End Sub

    Private Sub AddRechercheEtudiantView(ByVal o As Object)
        Dim workspace As WorkspaceViewModel = New RechercheEtudiantViewModel("Recherche Etudiant", AddressOf Me.AddEtudiantView)
        AddHandler workspace.Close, AddressOf Me.OnWorkspaceClose

        Workspaces.Add(workspace)
    End Sub
    Private Sub AddRecherchePromoView(ByVal o As Object)
        Dim workspace As WorkspaceViewModel = New RecherchePromoViewModel("Recherche Promotion")
        AddHandler workspace.Close, AddressOf Me.OnWorkspaceClose

        Workspaces.Add(workspace)
    End Sub
    Private Sub AddStatisticsView(ByVal o As Object)
        Dim workspace As WorkspaceViewModel = New StatisticsViewModel("Statistiques")
        AddHandler workspace.Close, AddressOf Me.OnWorkspaceClose

        Workspaces.Add(workspace)
    End Sub
    Private Sub AddEtudiantView(ByVal o As Object)
        Dim e As New Etudiant With {.Adresse = "Moscou", .CodePostal = 1500, .DateNais = New Date(), .LieuNais = "Bejaia", .LieuNaisA = "Bejaia arabe", .Matricule = "18/0225", .Nom = "Mohamed", .NomA = "Mohamed Arabe", .NomMere = "Nom mere", .Prenom = "prenom", .PrenomA = "prenom arabe", .PrenomPere = "prenom pere", .Ville = "alger", .Wilaya = "alger", .WilayaNaisA = "Baghdad", .WilayaNaisCode = 12}
        e = Repository.paracours_etudiant(e)
        Dim workspace As WorkspaceViewModel = New EtudiantViewModel("Etudiant", e)
        AddHandler workspace.Close, AddressOf Me.OnWorkspaceClose

        _workspaces.Add(workspace)
    End Sub

    Private Sub OnWorkspaceClose(ByVal sender As WorkspaceViewModel)
        Workspaces.Remove(sender)
    End Sub
End Class
