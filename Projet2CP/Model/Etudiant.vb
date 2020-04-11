Imports System.Collections

Public Class Etudiant
    Enum SerieBAC
        G04
        G05
        G07
        G08
    End Enum
    Private _matricule, _nom, _prenom, _nomA, _prenomA, _adresse, _dateNais, _lieuNais, _lieuNaisA, _wilayaNaisA, _ville, _wilaya, _prenomPere, _nomMere, _codePostal As String
    Private _wilayaNaisCode, _annIns, _anneeBac As Integer
    Private _moyenneBAC As Double
    Private _parcours As List(Of AnneeEtude)

    'Constructeur
    Public Sub New()

    End Sub

    Public Sub New(ByVal matricule As String, ByVal nom As String, ByVal prenom As String, ByVal nomA As String, ByVal prenomA As String, ByVal adresse As String, ByVal lieuNais As String, ByVal lieuNaisA As String, ByVal wilayaNaisA As String, ByVal ville As String, ByVal wilaya As String, ByVal prenomPere As String, ByVal nomMere As String, ByVal wilayaNaisCode As Integer, ByVal annIns As Integer, ByVal codePostal As String, ByVal anneeBac As Integer, ByVal moyenneBAC As Double, ByVal dateNais As String, ByVal parcours As List(Of AnneeEtude))
        _matricule = matricule
        _nom = nom
        _prenom = prenom
        _nomA = nomA
        _prenomA = prenomA
        _adresse = adresse
        _lieuNais = lieuNais
        _lieuNaisA = lieuNaisA
        _wilayaNaisA = wilayaNaisA
        _ville = ville
        _wilaya = wilaya
        _prenomPere = prenomPere
        _nomMere = nomMere
        _wilayaNaisCode = wilayaNaisCode
        _annIns = annIns
        _codePostal = codePostal
        _anneeBac = anneeBac
        _moyenneBAC = moyenneBAC
        _dateNais = dateNais
        _parcours = parcours
    End Sub



    'Properties
    Public Property Matricule() As String
        Get
            Return _matricule
        End Get
        Set(ByVal value As String)
            _matricule = value
        End Set
    End Property
    Public Property Nom() As String
        Get
            Return _nom
        End Get
        Set(ByVal value As String)
            _nom = value
        End Set
    End Property
    Public Property Prenom() As String
        Get
            Return _prenom
        End Get
        Set(ByVal value As String)
            _prenom = value
        End Set
    End Property
    Public Property NomA() As String
        Get
            Return _nomA
        End Get
        Set(ByVal value As String)
            _nomA = value
        End Set
    End Property
    Public Property PrenomA() As String
        Get
            Return _prenomA
        End Get
        Set(ByVal value As String)
            _prenomA = value
        End Set
    End Property
    Public Property Adresse() As String
        Get
            Return _adresse
        End Get
        Set(ByVal value As String)
            _adresse = value
        End Set
    End Property
    Public Property LieuNais() As String
        Get
            Return _lieuNais
        End Get
        Set(ByVal value As String)
            _lieuNais = value
        End Set
    End Property
    Public Property LieuNaisA() As String
        Get
            Return _lieuNaisA
        End Get
        Set(ByVal value As String)
            _lieuNaisA = value
        End Set
    End Property
    Public Property WilayaNaisA() As String
        Get
            Return _wilayaNaisA
        End Get
        Set(ByVal value As String)
            _wilayaNaisA = value
        End Set
    End Property
    Public Property Ville() As String
        Get
            Return _ville
        End Get
        Set(ByVal value As String)
            _ville = value
        End Set
    End Property
    Public Property Wilaya() As String
        Get
            Return _wilaya
        End Get
        Set(ByVal value As String)
            _wilaya = value
        End Set
    End Property
    Public Property PrenomPere() As String
        Get
            Return _prenomPere
        End Get
        Set(ByVal value As String)
            _prenomPere = value
        End Set
    End Property
    Public Property NomMere() As String
        Get
            Return _nomMere
        End Get
        Set(ByVal value As String)
            _nomMere = value
        End Set
    End Property
    Public Property WilayaNaisCode() As Integer
        Get
            Return _wilayaNaisCode
        End Get
        Set(ByVal value As Integer)
            _wilayaNaisCode = value
        End Set
    End Property
    Public Property AnnIns() As Integer
        Get
            Return _annIns
        End Get
        Set(ByVal value As Integer)
            _annIns = value
        End Set
    End Property
    Public Property CodePostal() As String
        Get
            Return _codePostal
        End Get
        Set(ByVal value As String)
            _codePostal = value
        End Set
    End Property
    Public Property DateNais() As String
        Get
            Return _dateNais
        End Get
        Set(ByVal value As String)
            _dateNais = value
        End Set
    End Property
    Public Property Parcours As List(Of AnneeEtude)
        Get
            Return _parcours
        End Get
        Set(ByVal value As List(Of AnneeEtude))
            _parcours = value
        End Set
    End Property
End Class
