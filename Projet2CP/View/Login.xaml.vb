Public Class Window1

    Private Sub Image1_ImageFailed(ByVal sender As System.Object, ByVal e As System.Windows.ExceptionRoutedEventArgs)

    End Sub

    Private Sub Image1_ImageFailed_1(ByVal sender As System.Object, ByVal e As System.Windows.ExceptionRoutedEventArgs)

    End Sub
    Private Sub adminPassword_PasswordChanged(ByVal sender As System.Object, ByVal e As RoutedEventArgs)
        If UserPassword.Password.Length = 0 Then
            adminPasswordHint.Visibility = Windows.Visibility.Visible
        Else
            adminPasswordHint.Visibility = Windows.Visibility.Hidden
        End If

    End Sub

    Private Sub Image1_ImageFailed_2(ByVal sender As System.Object, ByVal e As System.Windows.ExceptionRoutedEventArgs) Handles Image1.ImageFailed

    End Sub

    Private Sub Login_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Login.Click
        If Migration.login(1, UserPassword.Password) Then
            Dim mainWindow As New MainWindow
            Me.Close()
            mainWindow.Show()
        Else : UserPassword.Password = ""
        End If
    End Sub


End Class
