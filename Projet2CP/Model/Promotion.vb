Imports System.Collections

Public Class Promotion
    Private _annee, _nbInscrits, _nbDoublants, _nbRattrap As Integer
    Private _niveau As Niveau
    Private _listeEtudiants As List(Of Etudiant)
    Private _listeMatieres As Dictionary(Of Matiere, Decimal)


    'Properties
    Public Property Annee() As Integer
        Get
            Return _annee
        End Get
        Set(ByVal value As Integer)
            Me._annee = value
        End Set
    End Property

    Public Property NbInscrits() As Integer
        Get
            Return _nbInscrits
        End Get
        Set(ByVal value As Integer)
            Me._nbInscrits = value
        End Set
    End Property



    Public Property NbDoublants As Integer
        Get
            Return _nbDoublants
        End Get
        Set(ByVal value As Integer)
            Me._nbDoublants = value
        End Set
    End Property

    Public Property NbRattrap() As Integer
        Get
            Return _nbRattrap
        End Get
        Set(ByVal value As Integer)
            Me._nbRattrap = value
        End Set
    End Property

    Public Property NiveauP() As Niveau
        Get
            Return _niveau
        End Get
        Set(ByVal value As Niveau)
            Me._niveau = value
        End Set
    End Property

    Public Property ListeEtudiants() As List(Of Etudiant)
        Get
            Return _listeEtudiants
        End Get
        Set(ByVal value As List(Of Etudiant))
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

End Class
