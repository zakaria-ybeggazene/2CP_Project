Public Class RecherchePromoViewModel
    Inherits WorkspaceViewModel

    Public Sub New(ByVal displayName As String)
        MyBase.New(displayName)
        v = New RecherchePromo()
    End Sub

    Private v As RecherchePromo
End Class
