Public Class RecherchePromoViewModel
    Inherits WorkspaceViewModel

    'Fields
    Private _niveau, _annee As String
    Private _resultat As Promotion
    Private _nbIns As Integer
    Private _promotionViewModel As ViewModelBase
    'Recherche sub
    Public Sub recherche()
        If Annee = "" Or Annee = "Année" Or Niveau = "" Or Niveau = "Niveau" Then
            MsgBox("Vous devez spécifier l'année et le niveau", MsgBoxStyle.Information)
        Else
            Dim niv As Niveau = Util.stringToNiveau(Niveau)
            Dim anneeCut As String = Annee.Substring(2)
            'Cursor = Cursors.Wait
            Mouse.OverrideCursor = Cursors.Wait
            If niv = Projet2CP.Niveau.SI3 Or niv = Projet2CP.Niveau.SIQ3 Or niv = Projet2CP.Niveau.CS3 Then
                Resultat = Repository.recherche_promo_parcours(niv, anneeCut)
                If Resultat Is Nothing Then
                    MsgBox("Promotion introuvable", MsgBoxStyle.Information)
                Else
                    NombreInscrits = Resultat.NbInscrits.ToString
                    PromotionViewModel = New ClassementViewModel(CType(Resultat, PromotionParcours), _addEtudiantView)
                End If
            Else
                Resultat = Repository.recherche_promo(niv, anneeCut)
                If Resultat Is Nothing Then
                    MsgBox("Promotion introuvable", MsgBoxStyle.Information)
                Else
                    NombreInscrits = Resultat.NbInscrits.ToString
                    PromotionViewModel = New PromotionViewModel(CType(Resultat, PromotionAnnee), _addEtudiantView)
                End If
            End If

        End If
        Mouse.OverrideCursor = Nothing
        'Cursor = Cursors.Arrow
    End Sub

    'Recherche command
    Public _rechCommand As New RelayCommand(AddressOf recherche)
    Public ReadOnly Property RechCommand As ICommand
        Get
            Return _rechCommand
        End Get
    End Property

    'Properties
    Public Property Annee() As String
        Get
            Return _annee
        End Get
        Set(ByVal value As String)
            _annee = value
        End Set
    End Property
    Public Property Niveau() As String
        Get
            Return _niveau
        End Get
        Set(ByVal value As String)
            _niveau = value
        End Set
    End Property
    Public Property Resultat() As Promotion
        Get
            Return _resultat
        End Get
        Set(ByVal value As Promotion)
            _resultat = value
            OnPropertyChanged("Resultat")
        End Set
    End Property

    Public Property NombreInscrits As String
        Get
            Return "Nombre d'inscrits  :  " & _nbIns.ToString
        End Get
        Set(ByVal value As String)
            _nbIns = value
            OnPropertyChanged("NombreInscrits")
        End Set
    End Property
    Public Property PromotionViewModel As ViewModelBase
        Get
            Return _promotionViewModel
        End Get
        Set(ByVal value As ViewModelBase)
            _promotionViewModel = value
            OnPropertyChanged("PromotionViewModel")
        End Set
    End Property

    Private _addEtudiantView As Action(Of Object)

    'NEW SUB
    Public Sub New(ByVal displayName As String, ByRef addEtudiantView As Action(Of Object), ByVal addStatisticsView As Action(Of Object))
        MyBase.New(displayName)
        _addEtudiantView = addEtudiantView
        Me.ViewStatistics = New RelayCommand(addStatisticsView)
        Me.PvDelibCommand = New RelayCommand(AddressOf generatePV)
        PromotionViewModel = New NothingViewModel("Aucune promotion selectionnée", "/Projet2CP;component/Images/undraw_two_factor_authentication_namy.png")

    End Sub
    Private _viewStatistics As RelayCommand
    Public Property ViewStatistics As RelayCommand
        Get
            Return _viewStatistics
        End Get
        Set(ByVal value As RelayCommand)
            _viewStatistics = value
        End Set

    End Property
    Private _pvDelibCommand As ICommand
    Public Property PvDelibCommand As ICommand
        Get
            Return _pvDelibCommand
        End Get
        Set(ByVal value As ICommand)
            _pvDelibCommand = value
        End Set
    End Property


    Public Sub generatePV(ByVal o As Object)
        Dim reportWindow As ReportWindow = New ReportWindow
        If Not _resultat Is Nothing Then
            Try
                reportWindow.Viewer.ViewerCore.ReportSource = CrystalReports.PvDeliberation(_resultat)
                reportWindow.Show()
            Catch e As Exception
                MsgBox("Le rapport n'a pas pu s'ouvrir", MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

End Class
