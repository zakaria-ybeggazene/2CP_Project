Imports System.Collections

Public Class Etudiant
    Private _matricule, _nom, _prenom, _nomA, _prenomA, _adresse, _dateNais, _lieuNais, _lieuNaisA, _wilayaNaisA, _ville, _wilaya, _prenomPere, _nomMere, _codePostal, _serieBac, _wilayaBac, _anneeBac As String
    Private _wilayaNaisCode, _annIns As Integer
    Private _moyenneBAC As Double
    Private _sexe As Short

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
    Public Property Sexe() As Short
        Get
            Return _sexe
        End Get
        Set(ByVal value As Short)
            _sexe = value
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
    Public Property MoyenneBac() As Double
        Get
            Return _moyenneBAC
        End Get
        Set(ByVal value As Double)
            _moyenneBAC = value
        End Set
    End Property
    Public Property AnneeBac() As String
        Get
            Return _anneeBac
        End Get
        Set(ByVal value As String)
            _anneeBac = value
        End Set
    End Property
    Public Property SerieBac() As String
        Get
            Return _serieBac
        End Get
        Set(ByVal value As String)
            _serieBac = value
        End Set
    End Property
    Public Property WilayaBac() As String
        Get
            Return _wilayaBac
        End Get
        Set(ByVal value As String)
            _wilayaBac = value
        End Set
    End Property

End Class

Public Class EtudiantParcours
    Inherits Etudiant
    Private _parcours As List(Of AnneeEtude)

    Public Property Parcours As List(Of AnneeEtude)
        Get
            Return _parcours
        End Get
        Set(ByVal value As List(Of AnneeEtude))
            _parcours = value
        End Set
    End Property
    ReadOnly Property Opt As String
        Get
            Dim s As String = _parcours.FindLast(Function(a) a.Niveau = Niveau.SIQ3 Or a.Niveau = Niveau.SI3).Niveau.ToString()
            Return s.Remove(s.Length - 1)
        End Get
    End Property
    ReadOnly Property TRC1 As Double
        Get
            Dim annee As AnneeEtude = _parcours.FindLast(Function(a) a.Niveau = Niveau.TRC1)
            If annee Is Nothing Then
                Return 0.0
            Else
                Return annee.MoyenneJ
            End If
        End Get
    End Property
    ReadOnly Property TRC2 As Double
        Get
            Dim annee As AnneeEtude = _parcours.FindLast(Function(a) a.Niveau = Niveau.TRC2)
            If annee Is Nothing Then
                Return 0.0
            Else
                Return annee.MoyenneJ
            End If
        End Get
    End Property
    ReadOnly Property CS1 As Double
        Get
            Dim annee As AnneeEtude = _parcours.FindLast(Function(a) a.Niveau = Niveau.SI1 Or a.Niveau = Niveau.SIQ1)
            If annee Is Nothing Then
                Return 0.0
            Else
                Return annee.MoyenneJ
            End If
        End Get
    End Property
    ReadOnly Property CS2 As Double
        Get
            Dim annee As AnneeEtude = _parcours.FindLast(Function(a) a.Niveau = Niveau.SI2 Or a.Niveau = Niveau.SIQ2)
            If annee Is Nothing Then
                Return 0.0
            Else
                Return annee.MoyenneJ
            End If
        End Get
    End Property
    ReadOnly Property CS3 As Double
        Get
            Dim annee As AnneeEtude = _parcours.FindLast(Function(a) a.Niveau = Niveau.SI3 Or a.Niveau = Niveau.SIQ3)
            If annee Is Nothing Then
                Return 0.0
            Else
                Return annee.MoyenneJ
            End If
        End Get
    End Property
    ReadOnly Property TRC1S As Double
        Get
            Dim annee As AnneeEtude = _parcours.FindLast(Function(a) a.Niveau = Niveau.TRC1)
            If annee Is Nothing Then
                Return 0.0
            Else
                Return annee.NoteRattrap
            End If
        End Get
    End Property
    ReadOnly Property TRC2S As Double
        Get
            Dim annee As AnneeEtude = _parcours.FindLast(Function(a) a.Niveau = Niveau.TRC2)
            If annee Is Nothing Then
                Return 0.0
            Else
                Return annee.NoteRattrap
            End If
        End Get
    End Property
    ReadOnly Property CS1S As Double
        Get
            Dim annee As AnneeEtude = _parcours.FindLast(Function(a) a.Niveau = Niveau.SI1 Or a.Niveau = Niveau.SIQ1)
            If annee Is Nothing Then
                Return 0.0
            Else
                Return annee.NoteRattrap
            End If
        End Get
    End Property
    ReadOnly Property CS2S As Double
        Get
            Dim annee As AnneeEtude = _parcours.FindLast(Function(a) a.Niveau = Niveau.SI2 Or a.Niveau = Niveau.SIQ2)
            If annee Is Nothing Then
                Return 0.0
            Else
                Return annee.NoteRattrap
            End If
        End Get
    End Property
    ReadOnly Property CS3S As Double
        Get
            Dim annee As AnneeEtude = _parcours.FindLast(Function(a) a.Niveau = Niveau.SI3 Or a.Niveau = Niveau.SIQ3)
            If annee Is Nothing Then
                Return 0.0
            Else
                Return annee.NoteRattrap
            End If
        End Get
    End Property
    ReadOnly Property MoyMax As Double
        Get
            Return Parcours.ConvertAll(Function(a) a.moyenneMax).Max
        End Get
    End Property
    ReadOnly Property Moy As Double
        Get
            Dim annees As List(Of AnneeEtude) = Parcours.Where(Function(a) (a.Decision.Equals("1") Or a.Decision.Equals("0"))).ToList
            Return annees.ConvertAll(Function(a) a.moyenneMax).Sum / annees.Count
        End Get
    End Property

End Class

Public Class EtudiantAnnee
    Inherits Etudiant
    Private _annee As AnneeEtude

    Public Property Annee As AnneeEtude
        Get
            Return _annee
        End Get
        Set(ByVal value As AnneeEtude)
            _annee = value
        End Set
    End Property
End Class
