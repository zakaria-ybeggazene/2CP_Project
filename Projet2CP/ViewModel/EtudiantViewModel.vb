Public Class EtudiantViewModel
    Inherits WorkspaceViewModel

    Public Sub New(ByVal displayName As String, ByVal e As Etudiant)
        MyBase.New(displayName)
        v = New EtudiantView()
        Me.Etudiant = e
        Me.ReportCommand = New RelayCommand(AddressOf OpenReportsWindow)
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

    Private Sub OpenReportsWindow(ByVal o As Object)
        Dim reportWindow As ReportWindow = New ReportWindow
        reportWindow.Viewer.ViewerCore.ReportSource = CrystalReports.Attestation(_etudiant)
        reportWindow.Show()
    End Sub
    Private v As EtudiantView
End Class
