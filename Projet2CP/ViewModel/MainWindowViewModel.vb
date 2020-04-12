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
    Private Sub AddEtudiantView(ByVal o As Etudiant)
        o = Repository.paracours_etudiant(o)
        Dim workspace As WorkspaceViewModel = New EtudiantViewModel(o.Nom.Trim & " " & o.Prenom.Trim, o)
        AddHandler workspace.Close, AddressOf Me.OnWorkspaceClose

        _workspaces.Add(workspace)
    End Sub

    Private Sub OnWorkspaceClose(ByVal sender As WorkspaceViewModel)
        Workspaces.Remove(sender)
    End Sub
End Class
