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

    Public Function getEtudiantDistribution() As List(Of Integer) Implements IPromoStatistics.getEtudiantDistribution
        Dim resultat As List(Of Integer) = New List(Of Integer)()

        For i = 1 To 20
            resultat.Add(0)
        Next

        For Each Etudiant As EtudiantParcours In ListeEtudiants
            Dim i As Integer
            Try
                i = Math.Floor(Etudiant.Moy)
                resultat(i) += 1
            Catch ex As Exception
                MsgBox("L'étudiant au matricule " & Etudiant.Matricule & " n'a aucun champs décision (DECIIN dans la bdd) au cours de ses 4 années égal à 1 ou à 2 (1 = Admis, 2 = Admis avec rachat)", MsgBoxStyle.Exclamation)
            End Try

        Next

        Return resultat
    End Function

    Public Function getTauxReussite() As Object Implements IPromoStatistics.getTauxReussite
        Dim i As Integer = 0
        For Each Etudiant As EtudiantParcours In ListeEtudiants
            Dim a As AnneeEtude = Etudiant.Parcours(Etudiant.Parcours.Count - 1)
            If a.Decision = "1" Or a.Decision = "2" Then
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
        For Each Etudiant As EtudiantParcours In ListeEtudiants
            Dim a As AnneeEtude = Etudiant.Parcours(Etudiant.Parcours.Count - 1)
            If Etudiant.Sexe = "1" Then
                MT += 1
            End If

            If a.Decision = "1" Or a.Decision = "2" Then
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
