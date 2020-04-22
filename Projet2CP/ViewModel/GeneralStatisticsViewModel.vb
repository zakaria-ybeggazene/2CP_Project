Public Class GeneralStatisticsViewModel
    Inherits ViewModelBase
    Public Sub New(ByVal displayName As String, ByVal obj As IGeneralStatistics)
        MyBase.DisplayName = displayName

        _stats = New GeneralStatistics()
        'ZAKI : YOU WILL USE _stats to CALL THE FUNCTIONS
        If Not obj Is Nothing Then

        End If
        displayStatistics()
    End Sub

    Private _stats As IGeneralStatistics

    Private Sub displayStatistics()

    End Sub
End Class
