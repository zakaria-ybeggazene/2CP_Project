Public Class WorkspaceViewModel
    Inherits ViewModelBase
    Public Sub New(ByVal displayName As String)
        If Command() Is Nothing Then Throw New ArgumentNullException("command")
        MyBase.DisplayName = displayName
        Me.CloseCommand = New RelayCommand(AddressOf OnClose)
    End Sub
    Private _command As ICommand
    Public Property CloseCommand As ICommand
        Get
            Return _command
        End Get
        Set(ByVal value As ICommand)
            _command = value
        End Set
    End Property
    Public Event Close(ByVal o As WorkspaceViewModel)

    Public Sub OnClose(ByVal o As WorkspaceViewModel)
        RaiseEvent Close(Me)
    End Sub
End Class
