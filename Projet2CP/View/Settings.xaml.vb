Public Class Settings

    Public Shared _closeWindow As Action
    Private Sub UserPasswordbutton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles UserPasswordbutton.Click

    End Sub

    Private Sub Image4_ImageFailed(ByVal sender As System.Object, ByVal e As System.Windows.ExceptionRoutedEventArgs) Handles Image4.ImageFailed

    End Sub

    Private Sub Password_PasswordChanged(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Password.PasswordChanged
        If Password.Password.Length = 0 Then
            PasswordHint.Visibility = Windows.Visibility.Visible
        Else
            PasswordHint.Visibility = Windows.Visibility.Hidden
        End If
        If Password.Password.Length < 4 And Password.Password.Length <> 0 Then
            shortPassword1.Visibility = Windows.Visibility.Visible
        Else
            shortPassword1.Visibility = Windows.Visibility.Hidden
        End If
        samePasswordU.Visibility = Windows.Visibility.Hidden
    End Sub

    Private Sub NewPassword_PasswordChanged(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles NewPassword.PasswordChanged, NewadPassword.PasswordChanged
        If NewPassword.Password.Length = 0 Then
            NewPasswordHint.Visibility = Windows.Visibility.Visible
        Else
            NewPasswordHint.Visibility = Windows.Visibility.Hidden
        End If
        If NewPassword.Password.Length < 4 And NewPassword.Password.Length <> 0 Then
            shortPassword2.Visibility = Windows.Visibility.Visible
        Else
            shortPassword2.Visibility = Windows.Visibility.Hidden
        End If
        samePasswordU.Visibility = Windows.Visibility.Hidden
    End Sub

    Private Sub UserPasswordClosebutton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles UserPasswordClosebutton.Click
        Password.Password = ""
        NewPassword.Password = ""
    End Sub

    Private Sub AdPassword_PasswordChanged(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles AdPassword.PasswordChanged
        If AdPassword.Password.Length = 0 Then
            AdminPasswordHint.Visibility = Windows.Visibility.Visible
        Else
            AdminPasswordHint.Visibility = Windows.Visibility.Hidden
        End If
        If AdPassword.Password.Length < 4 And AdPassword.Password.Length <> 0 Then
            shortPassword3.Visibility = Windows.Visibility.Visible
        Else
            shortPassword3.Visibility = Windows.Visibility.Hidden
        End If
        samePassword.Visibility = Windows.Visibility.Hidden
    End Sub

    Private Sub NewadPassword_PasswordChanged(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles NewadPassword.PasswordChanged, NewPassword.PasswordChanged
        If NewadPassword.Password.Length = 0 Then
            NewAdPasswordHint.Visibility = Windows.Visibility.Visible
        Else
            NewAdPasswordHint.Visibility = Windows.Visibility.Hidden
        End If
        If NewadPassword.Password.Length < 4 And NewadPassword.Password.Length <> 0 Then
            shortPassword4.Visibility = Windows.Visibility.Visible
        Else
            shortPassword4.Visibility = Windows.Visibility.Hidden
        End If
        samePassword.Visibility = Windows.Visibility.Hidden
    End Sub

    Private Sub AdminPasswordClosebutton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles AdminPasswordClosebutton.Click
        AdPassword.Password = ""
        NewadPassword.Password = ""
    End Sub

    Private Sub Modifier_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Modifier.Click
        If Password.Password.Length <> 0 And NewPassword.Password.Length <> 0 Then
            If shortPassword1.Visibility = Windows.Visibility.Hidden And shortPassword2.Visibility = Windows.Visibility.Hidden Then
                If Password.Password <> NewPassword.Password Then
                    Repository.setUserPassword(Password.Password, NewPassword.Password)
                    Password.Password = ""
                    NewPassword.Password = ""
                Else
                    samePasswordU.Visibility = Windows.Visibility.Visible
                End If
            End If
        End If
    End Sub

    Private Sub ModifierAdmin_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles ModifierAdmin.Click
        If AdPassword.Password.Length <> 0 And NewadPassword.Password.Length <> 0 Then
            If shortPassword3.Visibility = Windows.Visibility.Hidden And shortPassword4.Visibility = Windows.Visibility.Hidden Then
                If AdPassword.Password <> NewadPassword.Password Then
                    Repository.setAdminPassword(AdPassword.Password, NewadPassword.Password)
                    AdPassword.Password = ""
                    NewadPassword.Password = ""
                Else
                    samePassword.Visibility = Windows.Visibility.Visible
                End If
            End If
        End If
    End Sub

    Private Sub showHide_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles showHide.Click
        If showHide.Content = "Show" Then
            dbPassword.Text = Repository.userpwd
            showHide.Content = "Hide"
        Else
            dbPassword.Text = "Password here"
            showHide.Content = "Show"
        End If
    End Sub

    Private Sub Ouvrir_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Ouvrir.Click
        Try
            Repository.openDB()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Supprimer_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Supprimer.Click
        Try
            Dim msgBoxResult As MessageBoxResult = MsgBox("Êtes-vous sûr de vouloir supprimer la BDD ? Vous serez redérigé vers l'écran de l'importation des fichiers Excel", MsgBoxStyle.YesNoCancel, "Supprimer la base de données")
            If msgBoxResult = MessageBoxResult.Yes
                Repository.deleteDB()
                Dim importerfichiers As New ImportFiles
                Me.Close()
                _closeWindow()
                importerfichiers.Show()
            End If
        Catch ex As Exception
            MsgBox("Close the database first", MsgBoxStyle.Critical)
        End Try    
    End Sub
End Class