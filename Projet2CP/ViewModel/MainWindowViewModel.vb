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
    Private _selectedIndex As Integer = 0
    Public Property selectedIndex
        Get
            Return _selectedIndex
        End Get
        Set(ByVal value)
            _selectedIndex = value
            OnPropertyChanged("selectedIndex")
        End Set
    End Property

    Public Sub New()
        _workspaces = New ObservableCollection(Of WorkspaceViewModel)()
        'We'll add a starting menu here at initializing

        _commands = New ObservableCollection(Of CommandViewModel)({
            New CommandViewModel("Recherche Etudiant", New RelayCommand(AddressOf Me.AddRechercheEtudiantView)),
            New CommandViewModel("Recherche Promotion", New RelayCommand(AddressOf Me.AddRecherchePromoView)),
            New CommandViewModel("Statistiques", New RelayCommand(AddressOf Me.AddStatisticsView)),
            New CommandViewModel("Réglages", New RelayCommand(AddressOf Me.AddRechercheEtudiantView)),
            New CommandViewModel("Mode Administrateur", New RelayCommand(AddressOf Me.AddStatisticsView))})
    End Sub

    Private _indexRechercheEtudiant As Integer = -1
    Private Sub AddRechercheEtudiantView(ByVal o As Object)
        If _indexRechercheEtudiant = -1 Then
            Dim workspace As WorkspaceViewModel = New RechercheEtudiantViewModel("Recherche Etudiant", AddressOf Me.AddEtudiantView)
            _indexRechercheEtudiant = Workspaces.Count
            AddWorkspace(workspace)
        Else
            selectedIndex = _indexRechercheEtudiant
        End If
    End Sub

    Private Sub AddRecherchePromoView(ByVal o As Object)
        Dim workspace As WorkspaceViewModel = New RecherchePromoViewModel("Recherche Promotion", AddressOf Me.AddEtudiantView, AddressOf Me.AddStatisticsView)
        AddWorkspace(workspace)
    End Sub

    Private Sub AddStatisticsView(ByVal o As IStatistics)
        Dim workspace As WorkspaceViewModel = New StatisticsViewModel("Statistiques", o)
        AddWorkspace(workspace)
    End Sub

    Private Sub AddEtudiantView(ByVal o As Etudiant)
        Dim e As EtudiantParcours
        e = Repository.paracours_etudiant(o)
        Dim workspace As WorkspaceViewModel = New EtudiantViewModel(e.Nom.Trim & " " & e.Prenom.Trim, e)
        AddWorkspace(workspace)
    End Sub

    Private Sub AddWorkspace(ByVal workspace As WorkspaceViewModel)
        AddHandler workspace.Close, AddressOf Me.OnWorkspaceClose

        selectedIndex = Workspaces.Count
        _workspaces.Add(workspace)
    End Sub

    Private Sub OnWorkspaceClose(ByVal sender As WorkspaceViewModel)
        Workspaces.Remove(sender)

        If sender.GetType() Is GetType(RechercheEtudiantViewModel) Then
            _indexRechercheEtudiant = -1
        End If
    End Sub
End Class
