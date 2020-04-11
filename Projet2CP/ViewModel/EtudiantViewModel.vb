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

    Private Sub ReportWindow(ByVal o As Object)
        Dim reportWindow As ReportWindow = New ReportWindow
        Dim s As String = CType(o, String)
        If s = "Attestation" Then
            reportWindow.Viewer.ViewerCore.ReportSource = CrystalReports.Attestation(_etudiant)
        ElseIf s = "ReleveNotes" Then
            reportWindow.Viewer.ViewerCore.ReportSource = CrystalReports.ReleveNotes(_etudiant, Niveau.TRC1)
        End If
        reportWindow.Show()
    End Sub
    Private v As EtudiantView
End Class
