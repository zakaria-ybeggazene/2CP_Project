Public Class EtudiantViewModel
    Inherits WorkspaceViewModel

    Public Sub New(ByVal displayName As String, ByVal e As Etudiant)
        MyBase.New(displayName)
        v = New EtudiantView()
        Me.Etudiant = e
        Me.ReportCommand = New RelayCommand(AddressOf ReportWindow)
    End Sub

    Private _etudiant As Etudiant
    Public Property Etudiant As Etudiant
        Get
            Return _etudiant
        End Get
        Set(ByVal value As Etudiant)
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
        Dim s As String = CType(o, String)
        If s = "Attestation" Then
            reportWindow.Viewer.ViewerCore.ReportSource = CrystalReports.Attestation(_etudiant)
        ElseIf s = "ReleveNotes" Then
            Try
                reportWindow.Viewer.ViewerCore.ReportSource = CrystalReports.ReleveNotes(_etudiant, _etudiant.Parcours(CType(Niveau.Trim, Integer) - 1).Niveau)
            Catch e As Exception

            End Try
        End If
        reportWindow.Show()
    End Sub
    Private v As EtudiantView
End Class
