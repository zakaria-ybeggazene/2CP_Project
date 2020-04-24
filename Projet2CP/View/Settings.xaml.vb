Public Class Settings

    Private Sub UserPasswordbutton_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles UserPasswordbutton.Click

    End Sub


    Private Sub Image4_ImageFailed(sender As System.Object, e As System.Windows.ExceptionRoutedEventArgs) Handles Image4.ImageFailed

    End Sub

    Private Sub Password_PasswordChanged(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles Password.PasswordChanged
        If Password.Password.Length = 0 Then
            PasswordHint.Visibility = Windows.Visibility.Visible
        Else
            PasswordHint.Visibility = Windows.Visibility.Hidden
        End If
    End Sub

    Private Sub NewPassword_PasswordChanged(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles NewPassword.PasswordChanged, NewadPassword.PasswordChanged
        If NewPassword.Password.Length = 0 Then
            NewPasswordHint.Visibility = Windows.Visibility.Visible
        Else
            NewPasswordHint.Visibility = Windows.Visibility.Hidden
        End If
    End Sub


    Private Sub UserPasswordClosebutton_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles UserPasswordClosebutton.Click
        Password.Password = ""
        NewPassword.Password = ""
    End Sub

    Private Sub AdPassword_PasswordChanged(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles AdPassword.PasswordChanged
        If AdPassword.Password.Length = 0 Then
            AdminPasswordHint.Visibility = Windows.Visibility.Visible
        Else
            AdminPasswordHint.Visibility = Windows.Visibility.Hidden
        End If
    End Sub

    Private Sub NewadPassword_PasswordChanged(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles NewadPassword.PasswordChanged, NewPassword.PasswordChanged
        If NewadPassword.Password.Length = 0 Then
            NewAdPasswordHint.Visibility = Windows.Visibility.Visible
        Else
            NewAdPasswordHint.Visibility = Windows.Visibility.Hidden
        End If
    End Sub

    Private Sub AdminPasswordClosebutton_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles AdminPasswordClosebutton.Click
        AdPassword.Password = ""
        NewadPassword.Password = ""
    End Sub
End Class
