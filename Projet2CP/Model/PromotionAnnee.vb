Public Class PromotionAnnee
    Inherits Promotion
    Implements IPromoStatistics

    Private _listeEtudiants As List(Of EtudiantAnnee)
    Private _listeMatieres As Dictionary(Of Matiere, Decimal)


    'Properties
    Public Property ListeEtudiants() As List(Of EtudiantAnnee)
        Get
            Return _listeEtudiants
        End Get
        Set(ByVal value As List(Of EtudiantAnnee))
            Me._listeEtudiants = value
        End Set
    End Property

    Public Property ListeMatiere() As Dictionary(Of Matiere, Decimal)
        Get
            Return _listeMatieres
        End Get
        Set(ByVal value As Dictionary(Of Matiere, Decimal))
            Me._listeMatieres = value
        End Set
    End Property
    'Fin des Properties

    Public Function getEtudiantDistribution() As List(Of Integer) Implements IPromoStatistics.getEtudiantDistribution
        Dim resultat As List(Of Integer) = New List(Of Integer)()

        For i = 1 To 20
            resultat.Add(0)
        Next

        For Each Etudiant As EtudiantAnnee In ListeEtudiants
            Dim i As Integer

            i = Math.Floor(Etudiant.Annee.MoyenneJ)
            Try
                resultat(i) += 1
            Catch ex As Exception
                MessageBox.Show(i)
            End Try

        Next

        Return resultat
    End Function

    Public Function getTauxReussite() As Object Implements IPromoStatistics.getTauxReussite
        Dim i As Integer = 0
        For Each Etudiant As EtudiantAnnee In ListeEtudiants
            If Etudiant.Annee.Decision = "1" Or Etudiant.Annee.Decision = "2" Then
                i += 1
            End If
        Next

        Return New With {.NbrReussite = i, .NbrEchec = NbInscrits - i}
    End Function

    Public Function getTauxReussiteParSexe() As Object Implements IPromoStatistics.getTauxReussiteParSexe
        Dim M, F, MT, FT As Integer
        M = 0
        F = 0
        MT = 0
        For Each Etudiant As EtudiantAnnee In ListeEtudiants
            If Etudiant.Sexe = "1" Then
                MT += 1
            End If

            If Etudiant.Annee.Decision = "1" Or Etudiant.Annee.Decision = "2" Then
                If Etudiant.Sexe = "1" Then
                    M += 1
                Else
                    F += 1
                End If
            End If
        Next
        FT = Me.NbInscrits - MT

        Return New With {.NbrReussiteMasculin = M, .NbrEchecMasculin = MT - M, .NbrReussiteFeminin = F, .NbrEchecFeminin = FT - F}
    End Function
End Class
