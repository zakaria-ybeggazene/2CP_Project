Public Class Etudiant
    Private _matricule, _nom, _prenom, _nomA, _prenomA, _adresse, _lieuNais, _lieuNaisA, _wilayaNaisA, _ville, _wilaya, _prenomPere, _nomMere As String
    Private _wilayaNaisCode, _annIns, _codePostal As Integer
    Private _dateNais As Date

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
    Public Property CodePostal() As Integer
        Get
            Return _nom
        End Get
        Set(ByVal value As Integer)
            _nom = value
        End Set
    End Property
    Public Property DateNais() As Date
        Get
            Return _dateNais
        End Get
        Set(ByVal value As Date)
            _dateNais = value
        End Set
    End Property
End Class
