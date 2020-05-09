Public Class WelcomeViewModel
    Inherits ViewModelBase

    Public Sub New(ByVal imageUrl As String)
        Me.ImageUrl = imageUrl
    End Sub

    Public Property ImageUrl As String
End Class
