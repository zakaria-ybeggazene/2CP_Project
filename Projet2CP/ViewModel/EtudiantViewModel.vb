Public Class EtudiantViewModel
    Inherits WorkspaceViewModel

    Public Sub New(ByVal displayName As String, ByVal e As Etudiant)
        MyBase.New(displayName)
        v = New EtudiantView()
        Me.Etudiant = e
        Me.ReportAttestationCommand = New RelayCommand(AddressOf ReportAttestationWindow)
        Me.ReportReleveCommand = New RelayCommand(AddressOf ReportReleveWindow)
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
    Private _reportAttestationCommand As ICommand
    Public Property ReportAttestationCommand As ICommand
        Get
            Return _reportAttestationCommand
        End Get
        Set(ByVal value As ICommand)
            _reportAttestationCommand = value
        End Set
    End Property

    Private Sub ReportAttestationWindow(ByVal o As Object)
        Dim reportWindow As ReportWindow = New ReportWindow
        reportWindow.Viewer.ViewerCore.ReportSource = CrystalReports.Attestation(_etudiant)
        reportWindow.Show()
    End Sub
    Private _reportReleveCommand As ICommand
    Public Property ReportReleveCommand As ICommand
        Get
            Return _reportReleveCommand
        End Get
        Set(ByVal value As ICommand)
            _reportReleveCommand = value
        End Set
    End Property

    Private Sub ReportReleveWindow(ByVal o As Object)
        Dim reportWindow As ReportWindow = New ReportWindow
        reportWindow.Viewer.ViewerCore.ReportSource = CrystalReports.ReleveNotes(_etudiant, Niveau.TRC1)
        reportWindow.Show()
    End Sub
    Private v As EtudiantView
End Class
