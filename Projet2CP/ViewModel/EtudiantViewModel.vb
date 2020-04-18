Public Class EtudiantViewModel
    Inherits WorkspaceViewModel

    Public Sub New(ByVal displayName As String, ByVal e As Etudiant)
        MyBase.New(displayName)
        v = New EtudiantView()
        Me.Etudiant = e
        Me.ReportCommand = New RelayCommand(AddressOf ReportWindow)
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
