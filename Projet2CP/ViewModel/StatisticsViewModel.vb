Public Class StatisticsViewModel
    Inherits WorkspaceViewModel

    Public Sub New(ByVal displayName As String, ByVal obj As IStatistics)
        MyBase.New(displayName)

        If obj Is Nothing Then
            SelectGeneralStatistics(Nothing)
        Else
            SelectPromoStatistics(CType(obj, IPromoStatistics))
        End If
        _commands = New List(Of RelayCommand)({
                    New RelayCommand(AddressOf SelectGeneralStatistics),
                    New RelayCommand(AddressOf SelectPromoStatistics),
                    New RelayCommand(AddressOf SelectMatiereStatistics)
                })
    End Sub

    Private _selectedViewModel As ViewModelBase
    Public Property SelectedViewModel As ViewModelBase
        Get
            Return _selectedViewModel
        End Get
        Set(ByVal value As ViewModelBase)
            _selectedViewModel = value
            OnPropertyChanged("SelectedViewModel")
        End Set
    End Property

    Private _commands As List(Of RelayCommand)
    ReadOnly Property RightCommand As ICommand
        Get
            Dim i As Integer
            If _selectedViewModelIndex = 0 Then
                i = 2
            Else
                i = _selectedViewModelIndex - 1
            End If
            Return _commands(i)
        End Get
    End Property
    ReadOnly Property LeftCommand As ICommand
        Get
            Return _commands((_selectedViewModelIndex + 1) Mod 3)
        End Get
    End Property
    Private _selectedViewModelIndex As Integer = 0
    WriteOnly Property SelectedViewModelIndex As Integer
        Set(ByVal value As Integer)
            _selectedViewModelIndex = value
            OnPropertyChanged("RightCommand")
            OnPropertyChanged("LeftCommand")
        End Set
    End Property

    Private Sub SelectGeneralStatistics(ByVal obj As IGeneralStatistics)
        SelectedViewModelIndex = 0
        SelectedViewModel = New GeneralStatisticsViewModel("Statistiques génerales", obj)

    End Sub
    Private Sub SelectPromoStatistics(ByVal obj As IPromoStatistics)
        SelectedViewModelIndex = 1
        SelectedViewModel = New PromoStatisticsViewModel("Statistiques Promotion", obj)
    End Sub
    Private Sub SelectMatiereStatistics(ByVal obj As IMatiereStatistics)
        SelectedViewModelIndex = 2
        SelectedViewModel = New MatiereStatisticsViewModel("Statistiques Matiere", obj)
    End Sub

End Class
