Public Class EtudiantViewModel
    Inherits WorkspaceViewModel

    Public Sub New(ByVal displayName As String, ByVal e As EtudiantParcours)

        MyBase.New(displayName)
        v = New EtudiantView()
        Me.Etudiant = e
        Me.ReportCommand = New RelayCommand(AddressOf ReportWindow)
        If e.Sexe = 1 Then
            Me._sexe = "Masculin"
        ElseIf e.Sexe = 2 Then
            Me._sexe = "Féminin"
        End If
        _list = New List(Of String)
        Dim i As Integer = 1
        For Each a As AnneeEtude In Etudiant.Parcours
            If a.Niveau <> Projet2CP.Niveau.SI3 And a.Niveau <> Projet2CP.Niveau.SIQ3 Then
                _list.Add(i)
                i += 1
            End If
        Next
        _etudiant.Parcours = e.Parcours
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
        NomV = Windows.Visibility.Hidden
        PrenomV = Windows.Visibility.Hidden
        NomAV = Windows.Visibility.Hidden
        PrenomAV = Windows.Visibility.Hidden
        PrenomPereV = Windows.Visibility.Hidden
        NomMereV = Windows.Visibility.Hidden
        AdresseV = Windows.Visibility.Hidden
        WilayaV = Windows.Visibility.Hidden
        VilleV = Windows.Visibility.Hidden
        LieuNaisV = Windows.Visibility.Hidden
        WilayaNaisV = Windows.Visibility.Hidden
        CodePostalV = Windows.Visibility.Hidden
        DateNaisV = Windows.Visibility.Hidden
        SexeV = Windows.Visibility.Hidden

        _read_only = True
        _enable = False
        _saveVis = Visibility.Hidden
        _modifVis = Visibility.Visible
        _valide = True
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





    'booleens relatifs au view
    Private _read_only, _valide, _enable As Boolean
    Private _saveVis, _modifVis As Visibility

    Public Property Read_only() As Boolean
        Get
            Return _read_only
        End Get
        Set(ByVal value As Boolean)
            _read_only = value
            OnPropertyChanged("Read_only")
        End Set
    End Property
    Public Property Valide As Boolean
        Get
            Return _valide
        End Get
        Set(ByVal value As Boolean)
            _valide = value
            OnPropertyChanged("Valide")
        End Set
    End Property
    Public Property Enable As Boolean
        Get
            Return _enable
        End Get
        Set(ByVal value As Boolean)
            _enable = value
            OnPropertyChanged("Enable")
        End Set
    End Property
    Public Property SaveVis() As Visibility
        Get
            Return _saveVis
        End Get
        Set(ByVal value As Visibility)
            _saveVis = value
            OnPropertyChanged("SaveVis")
        End Set
    End Property
    Public Property ModifVis() As Visibility
        Get
            Return _modifVis
        End Get
        Set(ByVal value As Visibility)
            _modifVis = value
            OnPropertyChanged("ModifVis")
        End Set
    End Property







    'attributs modifiables
    Private _nom, _prenom, _nomA, _prenomA, _prenomPere, _nomMere, _adresse, _wilaya, _ville, _lieuNais, _wilayaNais, _dateNais, _sexe, _codePostal As String

    Public Property Nom As String
        Get
            Return _nom
        End Get
        Set(ByVal value As String)
            _nom = value
            If _modifVis = Visibility.Hidden Then
                If String.IsNullOrWhiteSpace(value) Then
                    NomV = Windows.Visibility.Visible
                Else
                    NomV = Windows.Visibility.Hidden
                End If
                Validite()
            End If
            OnPropertyChanged("Nom")
        End Set
    End Property

    Public Property Prenom As String
        Get
            Return _prenom
        End Get
        Set(ByVal value As String)
            _prenom = value
            If _modifVis = Visibility.Hidden Then
                If String.IsNullOrWhiteSpace(value) Then
                    PrenomV = Windows.Visibility.Visible
                Else
                    PrenomV = Windows.Visibility.Hidden
                End If
                Validite()
            End If
            OnPropertyChanged("Prenom")
        End Set
    End Property

    Public Property NomA As String
        Get
            Return _nomA
        End Get
        Set(ByVal value As String)
            _nomA = value
            If _modifVis = Visibility.Hidden Then
                If String.IsNullOrWhiteSpace(value) Then
                    NomAV = Windows.Visibility.Visible
                Else
                    NomAV = Windows.Visibility.Hidden
                End If
                Validite()
            End If
            OnPropertyChanged("NomA")
        End Set
    End Property

    Public Property PrenomA As String
        Get
            Return _prenomA
        End Get
        Set(ByVal value As String)
            _prenomA = value
            If _modifVis = Visibility.Hidden Then
                If String.IsNullOrWhiteSpace(value) Then
                    PrenomAV = Windows.Visibility.Visible
                Else
                    PrenomAV = Windows.Visibility.Hidden
                End If
                OnPropertyChanged("NomA")
                Validite()
            End If
            OnPropertyChanged("NomA")
        End Set
    End Property

    Public Property PrenomPere As String
        Get
            Return _prenomPere
        End Get
        Set(ByVal value As String)
            _prenomPere = value
            If _modifVis = Visibility.Hidden Then
                If String.IsNullOrWhiteSpace(value) Then
                    PrenomPereV = Windows.Visibility.Visible
                Else
                    PrenomPereV = Windows.Visibility.Hidden
                End If
                Validite()
            End If
            OnPropertyChanged("PrenomPere")
        End Set
    End Property

    Public Property NomMere As String
        Get
            Return _nomMere
        End Get
        Set(ByVal value As String)
            _nomMere = value
            If _modifVis = Visibility.Hidden Then
                If String.IsNullOrWhiteSpace(value) Then
                    NomMereV = Windows.Visibility.Visible
                Else
                    NomMereV = Windows.Visibility.Hidden
                End If
                Validite()
            End If
            OnPropertyChanged("NomMere")
        End Set
    End Property

    Public Property Adresse As String
        Get
            Return _adresse
        End Get
        Set(ByVal value As String)
            _adresse = value
            If _modifVis = Visibility.Hidden Then
                If String.IsNullOrWhiteSpace(value) Then
                    AdresseV = Windows.Visibility.Visible
                Else
                    AdresseV = Windows.Visibility.Hidden
                End If
                Validite()
            End If
            OnPropertyChanged("Adresse")
        End Set
    End Property

    Public Property Wilaya As String
        Get
            Return _wilaya
        End Get
        Set(ByVal value As String)
            _wilaya = value
            If _modifVis = Visibility.Hidden Then
                If String.IsNullOrWhiteSpace(value) Then
                    WilayaV = Windows.Visibility.Visible
                Else
                    WilayaV = Windows.Visibility.Hidden
                End If
                Validite()
            End If
            OnPropertyChanged("Wilaya")
        End Set
    End Property

    Public Property Ville As String
        Get
            Return _ville
        End Get
        Set(ByVal value As String)
            _ville = value
            If _modifVis = Visibility.Hidden Then
                If String.IsNullOrWhiteSpace(value) Then
                    VilleV = Windows.Visibility.Visible
                Else
                    VilleV = Windows.Visibility.Hidden
                End If
                Validite()
            End If
            OnPropertyChanged("Ville")
        End Set
    End Property

    Public Property LieuNais As String
        Get
            Return _lieuNais
        End Get
        Set(ByVal value As String)
            _lieuNais = value
            If _modifVis = Visibility.Hidden Then
                If String.IsNullOrWhiteSpace(value) Then
                    LieuNaisV = Windows.Visibility.Visible
                Else
                    LieuNaisV = Windows.Visibility.Hidden
                End If
                Validite()
            End If
            OnPropertyChanged("LieuNais")
        End Set
    End Property

    Public Property WilayaNais As String
        Get
            Return _wilayaNais
        End Get
        Set(ByVal value As String)
            _wilayaNais = value
            If _modifVis = Visibility.Hidden Then
                If String.IsNullOrWhiteSpace(value) Then
                    WilayaNaisV = Windows.Visibility.Visible
                Else
                    WilayaNaisV = Windows.Visibility.Hidden
                End If
                Validite()
            End If
            OnPropertyChanged("WilayaNais")
        End Set
    End Property

    Public Property DateNais As String
        Get
            Return _dateNais
        End Get
        Set(ByVal value As String)
            _dateNais = value
            If _modifVis = Visibility.Hidden Then
                If String.IsNullOrWhiteSpace(value) Then
                    DateNaisV = Windows.Visibility.Visible
                Else
                    DateNaisV = Windows.Visibility.Hidden
                End If
                Validite()
            End If
            OnPropertyChanged("DateNais")
        End Set
    End Property

    Public Property CodePostal As String
        Get
            Return _codePostal
        End Get
        Set(ByVal value As String)
            _codePostal = value
            If _modifVis = Visibility.Hidden Then
                Try
                    Dim code = Integer.Parse(value)
                    If value.Length <> 5 Or code <= 0 Then
                        Throw New Exception
                    End If
                    CodePostalV = Windows.Visibility.Hidden
                Catch ex As Exception
                    CodePostalV = Windows.Visibility.Visible
                End Try
                Validite()
            End If
            OnPropertyChanged("CodePostal")
        End Set
    End Property


    Public Property Sexe() As String
        Get
            Return _sexe
        End Get
        Set(ByVal value As String)
            _sexe = value
            If _modifVis = Visibility.Hidden Then
                If String.IsNullOrWhiteSpace(value) Then
                    SexeV = Windows.Visibility.Visible
                Else
                    SexeV = Windows.Visibility.Hidden
                End If
                Validite()
            End If
            OnPropertyChanged("Sexe")
        End Set
    End Property








    'labels
    Private _nomV, _prenomV, _nomAV, _prenomAV, _prenomPereV, _nomMereV, _adresseV, _wilayaV, _villeV, _lieuNaisV, _wilayaNaisV, _dateNaisV, _sexeV, _codePostalV As Windows.Visibility

    Public Property NomV As Visibility
        Get
            Return _nomV
        End Get
        Set(ByVal value As Visibility)
            _nomV = value
            OnPropertyChanged("NomV")
        End Set
    End Property

    Public Property PrenomV As Visibility
        Get
            Return _prenomV
        End Get
        Set(ByVal value As Visibility)
            _prenomV = value
            OnPropertyChanged("PrenomV")
        End Set
    End Property

    Public Property NomAV As Visibility
        Get
            Return _nomAV
        End Get
        Set(ByVal value As Visibility)
            _nomAV = value
            OnPropertyChanged("NomAV")
        End Set
    End Property

    Public Property PrenomAV As Visibility
        Get
            Return _prenomAV
        End Get
        Set(ByVal value As Visibility)
            _prenomAV = value
            OnPropertyChanged("PrenomAV")
        End Set
    End Property

    Public Property PrenomPereV As Visibility
        Get
            Return _prenomPereV
        End Get
        Set(ByVal value As Visibility)
            _prenomPereV = value
            OnPropertyChanged("PrenomPereV")
        End Set
    End Property

    Public Property NomMereV As Visibility
        Get
            Return _nomMereV
        End Get
        Set(ByVal value As Visibility)
            _nomMereV = value
            OnPropertyChanged("NomMereV")
        End Set
    End Property

    Public Property AdresseV As Visibility
        Get
            Return _adresseV
        End Get
        Set(ByVal value As Visibility)
            _adresseV = value
            OnPropertyChanged("AdresseV")
        End Set
    End Property

    Public Property WilayaV As Visibility
        Get
            Return _wilayaV
        End Get
        Set(ByVal value As Visibility)
            _wilayaV = value
            OnPropertyChanged("WilayaV")
        End Set
    End Property


    Public Property VilleV As Visibility
        Get
            Return _villeV
        End Get
        Set(ByVal value As Visibility)
            _villeV = value
            OnPropertyChanged("VilleV")
        End Set
    End Property

    Public Property LieuNaisV As Visibility
        Get
            Return _lieuNaisV
        End Get
        Set(ByVal value As Visibility)
            _lieuNaisV = value
            OnPropertyChanged("LieuNaisV")
        End Set
    End Property

    Public Property WilayaNaisV As Visibility
        Get
            Return _wilayaNaisV
        End Get
        Set(ByVal value As Visibility)
            _wilayaNaisV = value
            OnPropertyChanged("WilayaNaisV")
        End Set
    End Property

    Public Property DateNaisV As Visibility
        Get
            Return _dateNaisV
        End Get
        Set(ByVal value As Visibility)
            _dateNaisV = value
            OnPropertyChanged("DateNaisV")
        End Set
    End Property

    Public Property SexeV As Visibility
        Get
            Return _sexeV
        End Get
        Set(ByVal value As Visibility)
            _sexeV = value
            OnPropertyChanged("SexeV")
        End Set
    End Property

    Public Property CodePostalV As Visibility
        Get
            Return _codePostalV
        End Get
        Set(ByVal value As Visibility)
            _codePostalV = value
            OnPropertyChanged("CodePostalV")
        End Set
    End Property



    'modification

    Public _modifCommand As New RelayCommand(AddressOf Modification)
    Public ReadOnly Property ModifCommand As ICommand
        Get
            Return _modifCommand
        End Get
    End Property
    Private Sub Modification()
        If Repository.admin Then
            Read_only = False
            Enable = True
            SaveVis = Visibility.Visible
            ModifVis = Visibility.Hidden
        Else
            MsgBox("Connectez-vous en tant qu'administrateur pour pouvoir modifier", MsgBoxStyle.Exclamation)
        End If
    End Sub




    'sauvegrarde

    Public Sub Validite()
        If _read_only = False And Enable = True Then
            If NomV = Visibility.Visible Or PrenomV = Visibility.Visible Or AdresseV = Visibility.Visible Then
                Valide = False
            ElseIf NomAV = Visibility.Visible Or PrenomAV = Visibility.Visible Or WilayaV = Visibility.Visible Then
                Valide = False
            ElseIf LieuNaisV = Visibility.Visible Or WilayaNaisV = Visibility.Visible Or CodePostalV = Visibility.Visible Then
                Valide = False
            ElseIf NomMereV = Visibility.Visible Or PrenomPereV = Visibility.Visible Or VilleV = Visibility.Visible Then
                Valide = False
            ElseIf DateNaisV = Visibility.Visible Or SexeV = Visibility.Visible Then
                Valide = False
            Else
                Valide = True
            End If
        End If
    End Sub

    Public _saveCommand As New RelayCommand(AddressOf Sauvegarder)
    Public ReadOnly Property SaveCommand As ICommand
        Get
            Return _saveCommand
        End Get
    End Property


    Public Sub Sauvegarder()
        ModifVis = Visibility.Visible
        SaveVis = Visibility.Hidden
        Read_only = True
        Enable = False
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
            MsgBox("sauvegarde reussie", MsgBoxStyle.Information)
        ElseIf result = MsgBoxResult.No Then
            Nom = _etudiant.Nom
            Prenom = _etudiant.Prenom
            NomA = _etudiant.NomA
            PrenomA = _etudiant.PrenomA
            PrenomPere = _etudiant.PrenomPere
            NomMere = _etudiant.NomMere
            Adresse = _etudiant.Adresse
            Wilaya = _etudiant.Wilaya
            Ville = _etudiant.Ville
            LieuNais = _etudiant.LieuNais
            WilayaNais = _etudiant.WilayaNaisA
            DateNais = _etudiant.DateNais
            CodePostal = _etudiant.CodePostal
            If _etudiant.Sexe = 1 Then
                Sexe = "Masculin"
            ElseIf _etudiant.Sexe = 2 Then
                Sexe = "Féminin"
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
        Else
            MsgBox("Le rapport n'a pas pu s'ouvrir", MsgBoxStyle.Critical)
        End If
    End Sub
    Private v As EtudiantView

    Private _list As List(Of String)
    ReadOnly Property NiveauCBList As List(Of String)
        Get
            Return _list
        End Get
    End Property
End Class