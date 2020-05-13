Imports System.Collections.ObjectModel
Public Class MainWindowViewModel
    Inherits ViewModelBase
    Private _closeWindow As Action
    Private _workspaces As ObservableCollection(Of WorkspaceViewModel)
    Property Workspaces As ObservableCollection(Of WorkspaceViewModel)
        Get
            Return _workspaces
        End Get
        Set(ByVal value As ObservableCollection(Of WorkspaceViewModel))
            _workspaces = value
        End Set
    End Property
    Private _hello As NothingViewModel
    Private _welcome As WelcomeViewModel
    Public Property Hello As NothingViewModel
        Get
            Return _hello
        End Get
        Set(ByVal value As NothingViewModel)
            _hello = value
            OnPropertyChanged("Hello")
        End Set
    End Property
    Public Property Welcome As WelcomeViewModel
        Get
            Return _welcome
        End Get
        Set(ByVal value As WelcomeViewModel)
            _welcome = value
            OnPropertyChanged("Welcome")
        End Set
    End Property
    Private _commands As ObservableCollection(Of CommandViewModel)
    Public Property Commands As ObservableCollection(Of CommandViewModel)
        Get
            Return _commands
        End Get
        Set(ByVal value As ObservableCollection(Of CommandViewModel))
            _commands = value
            OnPropertyChanged("Commands")
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

    Public Sub New(ByVal closeWindow As Action)
        _workspaces = New ObservableCollection(Of WorkspaceViewModel)()
        'We'll add a starting menu here at initializing
        _closeWindow = closeWindow
        _helpCommand = New RelayCommand(AddressOf Me.OpenHelp)
        Welcome = New WelcomeViewModel("/HistoESI;component/Images/Welcome.png")
        setList(False)
        AddHandler Repository.AdminStateChanged, AddressOf Me.setList
    End Sub


    Public Sub setList(ByVal isAdmin As Boolean)
        _helpCommand = New RelayCommand(AddressOf Me.OpenHelp)
        If isAdmin = True Then
            Commands = New ObservableCollection(Of CommandViewModel)({
            New CommandViewModel("Etudiant", New RelayCommand(AddressOf Me.AddRechercheEtudiantView), Util.EtudiantIconPath),
            New CommandViewModel("Promotion", New RelayCommand(AddressOf Me.AddRecherchePromoView), Util.PromotionIconPath),
            New CommandViewModel("Statistiques", New RelayCommand(AddressOf Me.AddStatisticsView), Util.StatisticsIconPath),
            New CommandViewModel("Réglages", New RelayCommand(AddressOf Me.OpenSettings), Util.ReglageIconPath),
            New CommandViewModel("Se Déconnecter", New RelayCommand(AddressOf Repository.adminLogout), Util.LogoutIconPath)})
        Else
            Commands = New ObservableCollection(Of CommandViewModel)({
            New CommandViewModel("Etudiant", New RelayCommand(AddressOf Me.AddRechercheEtudiantView), Util.EtudiantIconPath),
            New CommandViewModel("Promotion", New RelayCommand(AddressOf Me.AddRecherchePromoView), Util.PromotionIconPath),
            New CommandViewModel("Statistiques", New RelayCommand(AddressOf Me.AddStatisticsView), Util.StatisticsIconPath),
            New CommandViewModel("Mode Administrateur", New RelayCommand(AddressOf Me.OpenAdminLogin), Util.LoginIconPath)})
        End If

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
        If Not e Is Nothing Then
            Dim workspace As WorkspaceViewModel = New EtudiantViewModel(e.Nom.Trim & " " & e.Prenom.Trim, e)
            AddWorkspace(workspace)
        End If
    End Sub

    Private Sub OpenSettings(ByVal o As Object)
        If Repository.admin = True Then
            Dim settingsWindow As Settings = New Settings
            Settings._closeWindow = _closeWindow
            settingsWindow.Show()
        Else
            MsgBox("Connectez-vous en tant qu'administrateur pour accéder aux Réglages", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub OpenAdminLogin(ByVal o As Object)
        Dim AdminWindow As Admin = New Admin
        Admin._closeWindow = _closeWindow
        AdminWindow.Show()
    End Sub
    Private Sub AddWorkspace(ByVal workspace As WorkspaceViewModel)
        AddHandler workspace.Close, AddressOf Me.OnWorkspaceClose

        Hello = Nothing
        selectedIndex = Workspaces.Count
        _workspaces.Add(workspace)
    End Sub

    Private _helpCommand As ICommand
    Public Property HelpCommand As ICommand
        Get
            Return _helpCommand
        End Get
        Set(ByVal value As ICommand)
            _helpCommand = value
        End Set
    End Property
    Private Sub OpenHelp()
        Process.Start("file:///" & IO.Path.GetFullPath("..\..\index.html"))
    End Sub

    Private Sub OnWorkspaceClose(ByVal sender As WorkspaceViewModel)
        Workspaces.Remove(sender)

        If _workspaces.Count = 0 Then
            Welcome = New WelcomeViewModel("/HistoESI;component/Images/Welcome.png")
        End If
        If sender.GetType() Is GetType(RechercheEtudiantViewModel) Then
            _indexRechercheEtudiant = -1
        End If
    End Sub
End Class
