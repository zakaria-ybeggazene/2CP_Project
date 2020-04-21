Imports LiveCharts
Imports LiveCharts.Wpf

Public Class MatiereStatisticsViewModel
    Inherits ViewModelBase

    Public Sub New(ByVal displayName As String, ByVal obj As IMatiereStatistics)
        MyBase.DisplayName = displayName

        _matiere = obj
        If Not obj Is Nothing Then
            'initialiser les combo box
        End If
        displayStatistics()
    End Sub

    Private _matiere As IMatiereStatistics

    Public Property SeriesCollection As SeriesCollection
    Public Property MoyennesCollection As SeriesCollection
    Public Property Labels As New List(Of String)
    Public Property Formatter As Func(Of Double, String)
    Public Property PointLabel As Func(Of ChartPoint, String)

    'Fields
    Private _niveau, _matiereLabel As String
    'Recherche command
    Public _rechCommand As New RelayCommand(AddressOf recherche)
    Public ReadOnly Property RechCommand As ICommand
        Get
            Return _rechCommand
        End Get
    End Property

    'Properties
    Public Property MatiereLabel() As String
        Get
            Return _matiereLabel
        End Get
        Set(ByVal value As String)
            _matiereLabel = value
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
    'Recherche sub
    Public Sub recherche()
        'Try
        Cursor = Cursors.Wait
        If MatiereLabel = "" Or MatiereLabel = "Matiere" Or Niveau = "" Or Niveau = "Niveau" Then
            MsgBox("Vous devez spécifier la matière et l'option", MsgBoxStyle.Information)
        Else
            Dim niv As Niveau = Util.stringToNiveau(Niveau)
            Dim codeMat As String = Matiere.Matieres.Find(Function(m) m.LibeMat = MatiereLabel).CodMat
            _matiere = Matiere.getMatiere(codeMat, niv)

            If _matiere Is Nothing Then
                MsgBox("La matière n'existe pas", MsgBoxStyle.Information)
            Else
                displayStatistics()
            End If
        End If
        'Catch ex As Exception
        '    MessageBox.Show("Une erreur s'est produite")
        'Finally
        Cursor = Cursors.Arrow
        'End Try
    End Sub

    Private Sub displayStatistics()
        SeriesCollection = New LiveCharts.SeriesCollection From {
                New StackedColumnSeries With {
                    .Title = "Taux de reussites",
                    .Values = New LiveCharts.ChartValues(Of Double)(),
                    .DataLabels = True
                },
                New StackedColumnSeries With {
                    .Title = "Taux d'echec",
                    .Values = New LiveCharts.ChartValues(Of Double)(),
                    .DataLabels = True
                }
            }

        If _matiere Is Nothing Then
            For i = 0 To 22
                SeriesCollection(0).Values.Add(Convert.ToDouble(0))
                SeriesCollection(1).Values.Add(Convert.ToDouble(0))
            Next
        Else
            Dim distribution As List(Of Object) = _matiere.tauxReussiteMatiere()
            For i = 0 To 22
                SeriesCollection(0).Values.Add(Convert.ToDouble(distribution(i).nbrReussite))
                SeriesCollection(1).Values.Add(Convert.ToDouble(distribution(i).nbrEchec))
            Next
        End If
        For i = 0 To 22
            Labels.Add(CStr(1989 + i))
        Next
        Formatter = Function(value) value.ToString("N")

        PointLabel = Function(value) String.Format("{0} ({1:P})", value.Y, value.Participation)

        MoyennesCollection = New SeriesCollection From {
                New LineSeries With {
                        .Values = New ChartValues(Of Double)(),
                        .DataLabels = True,
                        .Title = "Moyenne du module"
                    }
            }
        If Not _matiere Is Nothing Then
            Dim moyennes As List(Of Double) = _matiere.MoyennesMatiere
            For i = 0 To 22
                MoyennesCollection(0).Values.Add(moyennes(i))
            Next

        End If

        OnPropertyChanged("SeriesCollection")
        OnPropertyChanged("MoyennesCollection")
    End Sub

    Private _cursor As Cursor
    Public Property Cursor As Cursor
        Get
            Return _cursor
        End Get
        Set(ByVal value As Cursor)
            _cursor = value
            OnPropertyChanged("Cursor")
        End Set
    End Property
    Public Property ForceCursor As Boolean = True
End Class
