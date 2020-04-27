Public Class PromotionParcours
    Inherits Promotion
    Implements IPromoStatistics
    Private _listeEtudiants As List(Of EtudiantParcours)


    'Properties

    Public Property ListeEtudiants() As List(Of EtudiantParcours)
        Get
            Return _listeEtudiants
        End Get
        Set(ByVal value As List(Of EtudiantParcours))
            Me._listeEtudiants = value
        End Set
    End Property
    'Fin des Properties

    Public Function getEtudiantDistribution() As List(Of Double) Implements IPromoStatistics.getEtudiantDistribution
        Dim resultat As List(Of Double) = New List(Of Double)()

        For i = 1 To 20
            resultat.Add(0)
        Next

        Return resultat
    End Function

    Public Function getTauxReussite() As Object Implements IPromoStatistics.getTauxReussite
        Dim i As Integer = 0

        Return New With {.NbrReussite = i, .NbrEchec = NbInscrits - i}
    End Function

    Public Function getTauxReussiteParSexe() As Object Implements IPromoStatistics.getTauxReussiteParSexe
        Dim M, F, MT, FT As Integer
        M = 0
        F = 0
        MT = 0

        FT = Me.NbInscrits - MT

        Return New With {.NbrReussiteMasculin = M, .NbrEchecMasculin = MT - M, .NbrReussiteFeminin = F, .NbrEchecFeminin = FT - F}
    End Function
End Class
