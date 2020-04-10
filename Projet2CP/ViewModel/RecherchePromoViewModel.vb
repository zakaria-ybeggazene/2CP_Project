Public Class RecherchePromoViewModel
    Inherits WorkspaceViewModel

    Public Sub New(ByVal displayName As String)
        MyBase.New(displayName)
        v = New RecherchePromo()
    End Sub

    Private v As RecherchePromo
    Public Property value
        Get
            Return v.value
        End Get
        Set(ByVal value)
            v.value = value
            OnPropertyChanged("value")
        End Set
    End Property
End Class
