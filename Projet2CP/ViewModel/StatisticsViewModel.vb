Public Class StatisticsViewModel
    Inherits WorkspaceViewModel

    Public Sub New(ByVal displayName As String)
        MyBase.New(displayName)
        v = New Statistics()
    End Sub

    Private v As Statistics
End Class
