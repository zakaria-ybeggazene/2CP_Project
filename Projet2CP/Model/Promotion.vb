Imports System.Collections

Public MustInherit Class Promotion
    Private _annee, _nbInscrits As Integer
    Private _niveau As Niveau

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

    Public Property NiveauP() As Niveau
        Get
            Return _niveau
        End Get
        Set(ByVal value As Niveau)
            Me._niveau = value
        End Set
    End Property
End Class
