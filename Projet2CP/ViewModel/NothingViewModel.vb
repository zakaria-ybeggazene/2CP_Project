Public Class NothingViewModel
    Inherits ViewModelBase

    Public Sub New(ByVal message As String, ByVal imageUrl As String)
        Me.ImageUrl = imageUrl
        Me.Message = message
    End Sub

    Public Property ImageUrl As String
    Public Property Message As String

End Class
