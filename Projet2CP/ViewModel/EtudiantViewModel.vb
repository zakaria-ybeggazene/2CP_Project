Public Class EtudiantViewModel
    Inherits WorkspaceViewModel

    Public Sub New(ByVal displayName As String, ByVal e As Etudiant)

        MyBase.New(displayName)
        v = New EtudiantView()
        Me.Etudiant = e
        Me.ReportCommand = New RelayCommand(AddressOf ReportWindow)
        If e.Sexe = 1 Then
            Me._sexe = "Masculin"
        ElseIf e.Sexe = 2 Then
            Me._sexe = "Féminin"
        End If
        Dim _parcours As New List(Of AnneeEtude)
        For Each a As AnneeEtude In _etudiant.Parcours
            If a.Annee >= 88 Then
                _parcours.Add(a)
            End If
        Next
        For Each a As AnneeEtude In _etudiant.Parcours
            If a.Annee < 88 Then
                _parcours.Add(a)
            End If
        Next
        _etudiant.Parcours = _parcours
        _nom = _etudiant.Nom
        _prenom = _etudiant.Prenom
        _nomA = _etudiant.NomA
        _prenomA = _etudiant.PrenomA
        _prenomPere = _etudiant.PrenomPere
        _nomMere = _etudiant.NomMere
        _adresse = _etudiant.Adresse
        _wilaya = _etudiant.Wilaya
        _ville = _etudiant.Ville
        _lieuNais = _etudiant.LieuNais
        _wilayaNais = _etudiant.WilayaNaisA
        _codePostal = _etudiant.CodePostal
        _dateNais = _etudiant.DateNais
    End Sub

    Private _etudiant As EtudiantParcours
    Public Property Etudiant As EtudiantParcours
        Get
            Return _etudiant
        End Get
        Set(ByVal value As EtudiantParcours)
            _etudiant = value
        End Set
    End Property

    Private _nom, _prenom, _nomA, _prenomA, _prenomPere, _nomMere, _adresse, _wilaya, _ville, _lieuNais, _wilayaNais, _dateNais, _sexe, _codePostal As String




    Public Property Sexe() As String
        Get
            Return _sexe
        End Get
        Set(ByVal value As String)
            _sexe = value
        End Set
    End Property


    Public _saveCommand As New RelayCommand(AddressOf Sauvegarder)
    Public ReadOnly Property SaveCommand As ICommand
        Get
            Return _saveCommand
        End Get
    End Property


    Public Sub Sauvegarder()
        Dim result = MsgBox("Confirmer les modifications?", MsgBoxStyle.YesNo)
        If result = MsgBoxResult.Yes Then
            Dim sexe As Short
            If _sexe = "Masculin" Then
                sexe = 1
            ElseIf _sexe = "Féminin" Then
                sexe = 2
            End If
            _etudiant.Sexe = sexe
            If _dateNais.Length = 10 Then
                _etudiant.DateNais = _dateNais.Remove(6, 2)
            End If
            _etudiant.Nom = _nom
            _etudiant.Prenom = _prenom
            _etudiant.NomA = _nomA
            _etudiant.PrenomA = _prenomA
            _etudiant.PrenomPere = _prenomPere
            _etudiant.NomMere = _nomMere
            _etudiant.Adresse = _adresse
            _etudiant.Wilaya = _wilaya
            _etudiant.Ville = _ville
            _etudiant.LieuNais = _lieuNais
            _etudiant.WilayaNaisA = _wilayaNais
            _etudiant.CodePostal = _codePostal
            Repository.modifierEtudiant(_etudiant)
        ElseIf result = MsgBoxResult.No Then
            _nom = _etudiant.Nom
            _prenom = _etudiant.Prenom
            _nomA = _etudiant.NomA
            _prenomA = _etudiant.PrenomA
            _prenomPere = _etudiant.PrenomPere
            _nomMere = _etudiant.NomMere
            _adresse = _etudiant.Adresse
            _wilaya = _etudiant.Wilaya
            _ville = _etudiant.Ville
            _lieuNais = _etudiant.LieuNais
            _wilayaNais = _etudiant.WilayaNaisA
            _dateNais = _etudiant.CodePostal
            _codePostal = _etudiant.CodePostal
            If _etudiant.Sexe = 1 Then
                Me._sexe = "Masculin"
            ElseIf _etudiant.Sexe = 2 Then
                Me._sexe = "Féminin"
            End If
        End If
    End Sub

    Private _reportCommand As ICommand
    Public Property ReportCommand As ICommand
        Get
            Return _reportCommand
        End Get
        Set(ByVal value As ICommand)
            _reportCommand = value
        End Set
    End Property
    Private _niveau As String
    Public Property Niveau As String
        Get
            Return _niveau
        End Get
        Set(ByVal value As String)
            _niveau = value
        End Set
    End Property

    Public Property Nom As String
        Get
            Return _nom
        End Get
        Set(ByVal value As String)
            _nom = value
        End Set
    End Property

    Public Property Prenom As String
        Get
            Return _prenom
        End Get
        Set(ByVal value As String)
            _prenom = value
        End Set
    End Property

    Public Property NomA As String
        Get
            Return _nomA
        End Get
        Set(ByVal value As String)
            _nomA = value
        End Set
    End Property

    Public Property PrenomA As String
        Get
            Return _prenomA
        End Get
        Set(ByVal value As String)
            _prenomA = value
        End Set
    End Property

    Public Property PrenomPere As String
        Get
            Return _prenomPere
        End Get
        Set(ByVal value As String)
            _prenomPere = value
        End Set
    End Property

    Public Property NomMere As String
        Get
            Return _nomMere
        End Get
        Set(ByVal value As String)
            _nomMere = value
        End Set
    End Property

    Public Property Adresse As String
        Get
            Return _adresse
        End Get
        Set(ByVal value As String)
            _adresse = value
        End Set
    End Property

    Public Property Wilaya As String
        Get
            Return _wilaya
        End Get
        Set(ByVal value As String)
            _wilaya = value
        End Set
    End Property

    Public Property Ville As String
        Get
            Return _ville
        End Get
        Set(ByVal value As String)
            _ville = value
        End Set
    End Property

    Public Property LieuNais As String
        Get
            Return _lieuNais
        End Get
        Set(ByVal value As String)
            _lieuNais = value
        End Set
    End Property

    Public Property WilayaNais As String
        Get
            Return _wilayaNais
        End Get
        Set(ByVal value As String)
            _wilayaNais = value
        End Set
    End Property

    Public Property DateNais As String
        Get
            Return _dateNais
        End Get
        Set(ByVal value As String)
            _dateNais = value
        End Set
    End Property

    Public Property CodePostal As String
        Get
            Return _codePostal
        End Get
        Set(ByVal value As String)
            _codePostal = value
        End Set
    End Property

    Private Sub ReportWindow(ByVal o As Object)
        Dim reportWindow As ReportWindow = New ReportWindow
        Dim doPrint As Boolean
        Dim s As String = CType(o, String)
        If s = "Attestation" Then
            Try
                reportWindow.Viewer.ViewerCore.ReportSource = CrystalReports.Attestation(_etudiant)
                doPrint = True
            Catch e As Exception
                doPrint = False
            End Try
        ElseIf s = "ReleveNotes" Then
            Try
                reportWindow.Viewer.ViewerCore.ReportSource = CrystalReports.ReleveNotes(_etudiant, _etudiant.Parcours(CType(Niveau.Trim, Integer) - 1).Niveau)
                doPrint = True
            Catch e As Exception
                doPrint = False
            End Try
        ElseIf s = "ReleveGlobal" Then
            If _etudiant.Parcours(_etudiant.Parcours.Count - 1).Niveau = Projet2CP.Niveau.SIQ3 Or _etudiant.Parcours(_etudiant.Parcours.Count - 1).Niveau = Projet2CP.Niveau.SI3 Then
                Try
                    reportWindow.Viewer.ViewerCore.ReportSource = CrystalReports.ReleveNotesGlobal(_etudiant)
                    doPrint = True
                Catch e As Exception
                    doPrint = False
                End Try
            Else
                MsgBox("L'étudiant doit avoir complété ses 5 ans", MsgBoxStyle.Information)
            End If
        End If
        If doPrint Then
            reportWindow.Show()
        End If
    End Sub
    Private v As EtudiantView
End Class