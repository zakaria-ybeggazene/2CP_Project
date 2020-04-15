Public Class SetPasword
    Private Sub userPassword_PasswordChanged(ByVal sender As System.Object, ByVal e As RoutedEventArgs)
        If userPassword.Password.Length = 0 Then
            userPasswordHint.Visibility = Windows.Visibility.Visible
        Else
            userPasswordHint.Visibility = Windows.Visibility.Hidden
        End If
       
    End Sub
    Private Sub AdminPassword_PasswordChanged(ByVal sender As System.Object, ByVal e As RoutedEventArgs)

        If AdminPassword.Password.Length = 0 Then
            AdminPasswordHint.Visibility = Windows.Visibility.Visible
        Else
            AdminPasswordHint.Visibility = Windows.Visibility.Hidden
        End If

    End Sub
    Private Sub ConfirmUserPassword_PasswordChanged(ByVal sender As System.Object, ByVal e As RoutedEventArgs)
       
        If ConfirmUserPassword.Password.Length = 0 Then
            ConfirmUserPasswordHint.Visibility = Windows.Visibility.Visible
        Else
            ConfirmUserPasswordHint.Visibility = Windows.Visibility.Hidden
        End If
        If ConfirmUserPassword.Password.Length <> 0 And ConfirmUserPassword.Password <> userPassword.Password Then
            UserPasswordLabel.Visibility = Windows.Visibility.Visible
        Else
            UserPasswordLabel.Visibility = Windows.Visibility.Hidden
        End If
        If AdminPasswordLabel.Visibility = Windows.Visibility.Hidden And UserPasswordLabel.Visibility = Windows.Visibility.Hidden Then
            If AdminPassword.Password.Length <> 0 And userPassword.Password.Length <> 0 Then
                terminerButton.IsEnabled = True
                terminerButton.Opacity = 1
                ImportbarVerified.Visibility = Windows.Visibility.Visible
            Else
                terminerButton.IsEnabled = False
                terminerButton.Opacity = 0.5
                ImportbarVerified.Visibility = Windows.Visibility.Hidden
            End If

        Else
            terminerButton.IsEnabled = False
            terminerButton.Opacity = 0.5
            ImportbarVerified.Visibility = Windows.Visibility.Hidden
        End If
    End Sub
    Private Sub ConfirmAdminPassword_PasswordChanged(ByVal sender As System.Object, ByVal e As RoutedEventArgs)

        If ConfirmAdminPassword.Password.Length = 0 Then
            ConfirmAdminPasswordHint.Visibility = Windows.Visibility.Visible
        Else
            ConfirmAdminPasswordHint.Visibility = Windows.Visibility.Hidden
        End If
        If ConfirmAdminPassword.Password.Length <> 0 And ConfirmAdminPassword.Password <> AdminPassword.Password Then
            AdminPasswordLabel.Visibility = Windows.Visibility.Visible
        Else
            AdminPasswordLabel.Visibility = Windows.Visibility.Hidden
        End If
        If AdminPasswordLabel.Visibility = Windows.Visibility.Hidden And UserPasswordLabel.Visibility = Windows.Visibility.Hidden Then
            If AdminPassword.Password.Length <> 0 And userPassword.Password.Length <> 0 Then
                terminerButton.IsEnabled = True
                terminerButton.Opacity = 1
                ImportbarVerified.Visibility = Windows.Visibility.Visible
            Else
                terminerButton.IsEnabled = False
                terminerButton.Opacity = 0.5
                ImportbarVerified.Visibility = Windows.Visibility.Hidden
            End If

        Else
            terminerButton.IsEnabled = False
            terminerButton.Opacity = 0.5
            ImportbarVerified.Visibility = Windows.Visibility.Hidden
        End If
    End Sub

  
End Class
