Public Class RecherchePromoViewModel
    Inherits WorkspaceViewModel

    Public Sub New(ByVal displayName As String)
        MyBase.New(displayName)
        v = New RecherchePromoView()
    End Sub

    Private v As RecherchePromoView
End Class
