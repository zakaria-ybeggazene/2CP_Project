Imports LiveCharts
Imports LiveCharts.Wpf

Public Class GeneralStatisticsViewModel
    Inherits ViewModelBase
    'INITIALIZED
    Public Sub New(ByVal displayName As String, ByVal obj As IGeneralStatistics)
        MyBase.DisplayName = displayName

        _stats = New GeneralStatistics()

        'Nombre Etudiants Stats Initializing
        DistributionCollection = New LiveCharts.SeriesCollection From {
                New StackedColumnSeries With {
                    .Title = "Masculin",
                    .Values = New LiveCharts.ChartValues(Of Integer)(),
                    .DataLabels = True
                },
                New StackedColumnSeries With {
                    .Title = "Féminin",
                    .Values = New LiveCharts.ChartValues(Of Integer)(),
                    .DataLabels = True
                }
            }
        Dim distributionNbIns As List(Of Object) = _stats.nombreEtudiantsGeneral()
        For i = 0 To 22
            DistributionCollection(0).Values.Add(distributionNbIns(i).nbMasculin)
            DistributionCollection(1).Values.Add(distributionNbIns(i).nbFeminin)
        Next
        For i = 0 To 22
            Labels1.Add(CStr(1989 + i))
        Next
        Formatter1 = Function(value) value.ToString()
        OnPropertyChanged("DistributionCollection")

        displayTaux()
        displaySeries()
    End Sub

    'Properties

    Private _stats As IGeneralStatistics
    Private _etudsOfNiv As List(Of Object)
    Private _series As Dictionary(Of String, Integer)
    Public Property DistributionCollection As SeriesCollection
    Public Property DistEchReuCollection As SeriesCollection
    Public Property SerBacCollection As SeriesCollection
    'LABEL ,FORMATTER FOR DISTRIBUTION NOMBRES
    Public Property Labels1 As New List(Of String)
    Public Property Formatter1 As Func(Of Double, String)
    'LABEL,FORMATTER FOR TAUX REU ECH
    Public Property Labels2 As New List(Of String)
    Public Property Formatter2 As Func(Of Double, String)
    'POINTLABEL FOR PIE
    Public Property PointLabel As Func(Of ChartPoint, String)

    'Fields
    Private _niveau, _annee As String
    'Recherche command
    Public _rechCommandTNiv As New RelayCommand(AddressOf rechercheTNiv)
    Public ReadOnly Property RechCommandTNiv As ICommand
        Get
            Return _rechCommandTNiv
        End Get
    End Property

    Public _rechCommand As New RelayCommand(AddressOf recherche)
    Public ReadOnly Property RechCommand As ICommand
        Get
            Return _rechCommand
        End Get
    End Property

    'Properties
    Public Property EtudsOfNiv As List(Of Object)
        Get
            Return _etudsOfNiv
        End Get
        Set(ByVal value As List(Of Object))
            _etudsOfNiv = value
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
    Public Property Annee() As String
        Get
            Return _annee
        End Get
        Set(ByVal value As String)
            _annee = value
        End Set
    End Property

    'Rechercher taux reussite par niveau sub
    Public Sub rechercheTNiv()
        Try
            Mouse.OverrideCursor = Cursors.Wait
            If Niveau = "" Or Niveau = "Niveau" Then
                MsgBox("Vous devez spécifier le niveau", MsgBoxStyle.Information)
            Else
                displayTaux()
            End If
        Catch ex As Exception
            MessageBox.Show("Une erreur s'est produite")
        Finally
            Mouse.OverrideCursor = Nothing
        End Try
    End Sub

    'recherche distribution des bacheliers
    Private Sub recherche()
        Try
            Mouse.OverrideCursor = Cursors.Wait
            If Annee = "" Or Annee = "Année" Then
                MsgBox("Vous devez spécifier l'année", MsgBoxStyle.Information)
            Else
                Annee = Annee.Substring(2)
                _series = _stats.distributionBacheliers(Annee)
                If _series Is Nothing Then
                    MsgBox("Données bacheliers indisponibles", MsgBoxStyle.Information)
                Else
                    displaySeries()
                End If
            End If
        Catch e As Exception
            MessageBox.Show("Une erreur s'est produite")
        Finally
            Mouse.OverrideCursor = Nothing
        End Try
    End Sub

    Private Sub displayTaux()
        If Niveau <> "" Then
            Dim niv As Niveau = Util.stringToNiveau(Niveau)
            _etudsOfNiv = _stats.nombreReussiteGeneral(niv)
            If _etudsOfNiv Is Nothing Then
                MessageBox.Show("Données Introuvables")
            Else
                DistEchReuCollection = New LiveCharts.SeriesCollection From {
                New StackedColumnSeries With {
                    .Title = "Réussite",
                    .Values = New LiveCharts.ChartValues(Of Double)(),
                    .DataLabels = True
                    },
                New StackedColumnSeries With {
                    .Title = "Echec",
                    .Values = New LiveCharts.ChartValues(Of Double)(),
                    .DataLabels = True
                    }
                }
                For i = 0 To 22
                    DistEchReuCollection(0).Values.Add(Convert.ToDouble(_etudsOfNiv(i).nbReussite))
                    DistEchReuCollection(1).Values.Add(Convert.ToDouble(_etudsOfNiv(i).nbEchec))
                Next
                For i = 0 To 22
                    Labels2.Add(CStr(1989 + i))
                Next
            End If
            Formatter2 = Function(value) value.ToString()
            OnPropertyChanged("DistEchReuCollection")
        End If
    End Sub
    Private Sub displaySeries()
        PointLabel = Function(value) String.Format("{0} ({1:P})", value.Y, value.Participation)

        SerBacCollection = New SeriesCollection


        If _series Is Nothing Then
            SerBacCollection.Add(New PieSeries With {.Title = "Pas de données", .Values = New ChartValues(Of Double), .LabelPoint = PointLabel, .DataLabels = True})
            SerBacCollection(0).Values.Add(Convert.ToDouble(1))
        ElseIf _series.Count = 0 Then
            SerBacCollection.Add(New PieSeries With {.Title = "Pas de données", .Values = New ChartValues(Of Double), .LabelPoint = PointLabel, .DataLabels = True})
            SerBacCollection(0).Values.Add(Convert.ToDouble(1))
        Else
            Dim i As Integer = 0
            For Each p As KeyValuePair(Of String, Integer) In _series
                SerBacCollection.Add(New PieSeries With {.Title = p.Key, .Values = New ChartValues(Of Double), .LabelPoint = PointLabel, .DataLabels = True})
                SerBacCollection(i).Values.Add(Convert.ToDouble(p.Value))
                i += 1
            Next
        End If
        OnPropertyChanged("SerBacCollection")
    End Sub
End Class
