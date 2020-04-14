'Imports Projet2CP


Public Class ModificationEtudiantViewModel
    Inherits WorkspaceViewModel

    Private _etudiant As Etudiant

    Public Sub New(ByVal displayName As String, ByVal etd As Etudiant)
        MyBase.New(displayName)
        Me._etudiant = etd
    End Sub



    Public Property Etudiant As Etudiant
        Get
            Return _etudiant
        End Get
        Set(ByVal value As Etudiant)
            _etudiant = value
        End Set
    End Property



    Public Sub Modification()
        Dim sexe As Integer
        Me._etudiant.Nom = _nom
        Me._etudiant.Prenom = _prenom
        Me._etudiant.NomA = _nomA
        Me._etudiant.PrenomA = _prenomA
        Me._etudiant.DateNais = _dateNais
        Me._etudiant.LieuNais = _lieuNais
        Me._etudiant.AnnIns = Integer.Parse(Annee)
        If _sexe = "Masculin" Then
            sexe = 1
        ElseIf _sexe = "Feminin" Then
            sexe = 2
        End If
        Me._etudiant.Wilaya = _wilayaNais
        Me._etudiant.WilayaNaisCode = Integer.Parse(WilayaNaisCode)
        Me._etudiant.WilayaNaisA = WilayaNaisA
        Me._etudiant.Adresse = Adresse
        Repository.ModifierEtuidant(_etudiant)
    End Sub

    'Command
    Private _modificationCommand As New RelayCommand(AddressOf Modification)
    Public ReadOnly Property ModificationCommand As ICommand
        Get
            Return _modificationCommand
        End Get
    End Property


    'Attributs Modifiables
    Private _matricule, _nom, _prenom, _nomA, _prenomA, _dateNais, _lieuNais, _annee, _sexe, _wilayaNais, _wilayaNaisCode, _wilayaNaisA, _adresse, _lieuNaisA, _ville, _wilaya, _prenomPere, _nomMere, _codePostal As String


    'Proprietes des attributs
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

    Public Property DateNais() As String
        Get
            Return _dateNais
        End Get
        Set(ByVal value As String)
            _dateNais = value
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
    Public Property WilayaNais() As String
        Get
            Return _wilayaNais
        End Get
        Set(ByVal value As String)
            _wilayaNais = value
        End Set
    End Property
    Public Property Sexe() As String
        Get
            Return _sexe
        End Get
        Set(ByVal value As String)
            _sexe = value
        End Set
    End Property

    Public Property Annee As String
        Get
            Return _annee
        End Get
        Set(value As String)
            _annee = value
        End Set
    End Property

    Public Property WilayaNaisCode As String
        Get
            Return _wilayaNaisCode
        End Get
        Set(value As String)
            _wilayaNaisCode = value
        End Set
    End Property

    Public Property WilayaNaisA As String
        Get
            Return _wilayaNaisA
        End Get
        Set(value As String)
            _wilayaNaisA = value
        End Set
    End Property

    Public Property LieuNaisA As String
        Get
            Return _lieuNaisA
        End Get
        Set(value As String)
            _lieuNaisA = value
        End Set
    End Property

    Public Property Ville As String
        Get
            Return _ville
        End Get
        Set(value As String)
            _ville = value
        End Set
    End Property

    Public Property Wilaya As String
        Get
            Return _wilaya
        End Get
        Set(value As String)
            _wilaya = value
        End Set
    End Property

    Public Property PrenomPere As String
        Get
            Return _prenomPere
        End Get
        Set(value As String)
            _prenomPere = value
        End Set
    End Property

    Public Property NomMere As String
        Get
            Return _nomMere
        End Get
        Set(value As String)
            _nomMere = value
        End Set
    End Property

    Public Property CodePostal As String
        Get
            Return _codePostal
        End Get
        Set(value As String)
            _codePostal = value
        End Set
    End Property

    Public Property Adresse As String
        Get
            Return _adresse
        End Get
        Set(value As String)
            _adresse = value
        End Set
    End Property
End Class
