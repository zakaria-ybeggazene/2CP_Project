Public Class CommandViewModel
    Inherits ViewModelBase
    Public Sub New(ByVal displayName As String, ByVal command As ICommand, ByVal iconPath As String)
        If command Is Nothing Then Throw New ArgumentNullException("command")
        MyBase.DisplayName = displayName
        Me.Command = command
        Me.IconPath = iconPath
    End Sub
    Private _command As ICommand
    Public Property Command As ICommand
        Get
            Return _command
        End Get
        Set(ByVal value As ICommand)
            _command = value
        End Set
    End Property
    Public Property IconPath As String
End Class