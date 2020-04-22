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


    'Attributs Modifiables

    Private _sexe As String

    Private _parcours As List(Of AnneeEtude)


    'Proprietes

    Public Property Parcours() As List(Of AnneeEtude)
        Get
            Return _parcours
        End Get
        Set(ByVal value As List(Of AnneeEtude))
            _parcours = value
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


    Public _saveCommand As New RelayCommand(AddressOf Sauvegarder)
    Public ReadOnly Property SaveCommand As ICommand
        Get
            Return _saveCommand
        End Get
    End Property


    Public Sub Sauvegarder()
        MsgBox("Sauvegarde réussie")
        Dim sexe As Short
        If _sexe = "Masculin" Then
            sexe = 1
        ElseIf _sexe = "Féminin" Then
            sexe = 2
        End If
        'Dim sexe As Integer
        'Me._etudiant.Nom = _nom
        'Me._etudiant.Prenom = _prenom
        'Me._etudiant.NomA = _nomA
        'Me._etudiant.PrenomA = _prenomA
        'Me._etudiant.DateNais = _dateNais
        'Me._etudiant.LieuNais = _lieuNais
        'If _sexe = "Masculin" Then
        ' Sexe = 1
        ' ElseIf _sexe = "Feminin" Then
        ' Sexe = 2
        ' End If
        ' Me._etudiant.Wilaya = _wilayaNais
        ' Me._etudiant.WilayaNaisCode = Integer.Parse(WilayaNaisCode)
        ' Me._etudiant.WilayaNaisA = WilayaNaisA
        ' Me._etudiant.Adresse = Adresse
        ' Repository.modifierEtudiant(_etudiant)
        ' Try
        'MsgBox("validé")
        'Catch ex As Exception
        ' MsgBox("réglez les erreurs")
        'End Try
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
        End If
    End Sub
    Private v As EtudiantView
End Class
