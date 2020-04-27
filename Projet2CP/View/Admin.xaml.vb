Public Class Admin
    Public Shared _closeWindow As Action
    Private Sub userPassword_PasswordChanged(ByVal sender As System.Object, ByVal e As RoutedEventArgs)
        If userPassword.Password.Length = 0 Then
            userPasswordHint.Visibility = Windows.Visibility.Visible
        Else
            userPasswordHint.Visibility = Windows.Visibility.Hidden
        End If

    End Sub
End Class
