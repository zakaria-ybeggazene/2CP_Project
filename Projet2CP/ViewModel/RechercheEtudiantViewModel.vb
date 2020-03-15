Public Class RechercheEtudiantViewModel
    Inherits WorkspaceViewModel

    Public Sub New(ByVal displayName As String)
        MyBase.New(displayName)
        v = New RechercheEtudiant()
    End Sub

    Private v As RechercheEtudiant
End Class
