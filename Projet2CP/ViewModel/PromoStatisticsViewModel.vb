Imports LiveCharts
Imports LiveCharts.Wpf

Public Class PromoStatisticsViewModel
    Inherits ViewModelBase

    Private _promotion As IPromoStatistics

    Public Property SeriesCollection As SeriesCollection
    Public Property PieCollection As SeriesCollection
    Public Property SexeCollection As SeriesCollection
    Public Property Labels As New List(Of String)
    Public Property Sexes As New List(Of String) From {"Masculin", "Féminin"}
    Public Property Formatter As Func(Of Integer, String)
    Public Property PointLabel As Func(Of ChartPoint, String)


    Public Sub New(ByVal displayName As String, ByVal obj As IPromoStatistics)
        MyBase.DisplayName = displayName

        _promotion = obj
        If Not obj Is Nothing Then
            'initialiser les combo box
            Dim a As Integer = CType(obj, Promotion).Annee
            If a > 60 Then
                Annee = a.ToString.Insert(0, "19")
            ElseIf a < 10 Then
                Annee = a.ToString.Insert(0, "200")
            Else
                Annee = a.ToString.Insert(0, "20")
            End If
            Niveau = CType(obj, Promotion).NiveauP.ToString
        End If
        displayStatistics()
    End Sub

    'Fields
    Private _niveau, _annee As String
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
    'Recherche sub
    Public Sub recherche()
        Try
            Mouse.OverrideCursor = Cursors.Wait
            If Annee = "" Or Annee = "Année" Or Niveau = "" Or Niveau = "Niveau" Then
                MsgBox("Vous devez spécifier l'année et le niveau", MsgBoxStyle.Information)
            Else
                Dim niv As Niveau = Util.stringToNiveau(Niveau)
                Dim anneeCut As String = Annee.Substring(2)
                _promotion = Repository.recherche_promo(niv, anneeCut)
                If _promotion Is Nothing Then
                    MsgBox("Promotion introuvable", MsgBoxStyle.Information)
                Else
                    displayStatistics()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Une erreur s'est produite")
        Finally
            Mouse.OverrideCursor = Nothing
        End Try
    End Sub

    Private Sub displayStatistics()
        SeriesCollection = New LiveCharts.SeriesCollection From {
                New LiveCharts.Wpf.ColumnSeries With {
                    .Title = "Distribution des moyennes",
                    .Values = New LiveCharts.ChartValues(Of Integer)()
                }
            }

        If _promotion Is Nothing Then
            For i = 0 To 19
                SeriesCollection(0).Values.Add(0)
            Next
        Else
            Dim distribution As List(Of Integer) = _promotion.getEtudiantDistribution()
            For i = 0 To 19
                SeriesCollection(0).Values.Add(distribution(i))
            Next
        End If
        For i = 0 To 19
            Labels.Add(CStr(i))
        Next
        Formatter = Function(value) value.ToString()

        PointLabel = Function(value) String.Format("{1:P} ({0})", value.Y, value.Participation)


        PieCollection = New SeriesCollection From {
            New PieSeries With {.Title = "Taux de reussite", .Values = New ChartValues(Of Double), .LabelPoint = PointLabel, .DataLabels = True},
            New PieSeries With {.Title = "Taux d'echec", .Values = New ChartValues(Of Double), .LabelPoint = PointLabel, .DataLabels = True}}

        Dim R, E As Integer 'R : reussite, E : echec
        If _promotion Is Nothing Then
            R = 1
            E = 0
        Else
            Dim taux As Object = _promotion.getTauxReussite()
            R = taux.NbrReussite
            E = taux.NbrEchec
        End If


        PieCollection(0).Values.Add(Convert.ToDouble(R))
        PieCollection(1).Values.Add(Convert.ToDouble(E))

        PointLabel = Function(value) String.Format("{1:P} ({0})", value.X, value.Participation)

        SexeCollection = New SeriesCollection From {
                New StackedRowSeries With {
                        .Values = New ChartValues(Of Double)(),
                        .DataLabels = True,
                        .Title = "Taux de reussite",
                        .LabelPoint = PointLabel
                    },
                  New StackedRowSeries With {
                        .Values = New ChartValues(Of Double)(),
                        .DataLabels = True,
                        .Title = "Taux d'echec",
                        .LabelPoint = PointLabel
                    }
            }
        Dim MR, FR, MF, FF As Integer 'M : masculin, F: feminin, R:reussite, F: failed
        If _promotion Is Nothing Then
            MR = 0
            FR = 0
            MF = 0
            FF = 0
        Else
            Dim tauxParSexe As Object = _promotion.getTauxReussiteParSexe()
            MR = tauxParSexe.NbrReussiteMasculin
            FR = tauxParSexe.NbrReussiteFeminin
            MF = tauxParSexe.NbrEchecMasculin
            FF = tauxParSexe.NbrEchecFeminin
        End If


        SexeCollection(0).Values.Add(Convert.ToDouble(MR))
        SexeCollection(0).Values.Add(Convert.ToDouble(FR))

        SexeCollection(1).Values.Add(Convert.ToDouble(MF))
        SexeCollection(1).Values.Add(Convert.ToDouble(FF))

        OnPropertyChanged("SeriesCollection")
        OnPropertyChanged("PieCollection")
        OnPropertyChanged("SexeCollection")
    End Sub


    Public Property exportIcon As String = Util.ExportIconPath
End Class
