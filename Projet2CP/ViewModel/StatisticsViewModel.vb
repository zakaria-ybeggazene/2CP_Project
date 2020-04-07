Public Class StatisticsViewModel
    Inherits WorkspaceViewModel

    Public Sub New(ByVal displayName As String)
        MyBase.New(displayName)
        v = New StatisticsView()
    End Sub

    Private v As StatisticsView
End Class
