Public Class Window1

    Private Sub Image1_ImageFailed(sender As System.Object, e As System.Windows.ExceptionRoutedEventArgs)

    End Sub

    Private Sub Image1_ImageFailed_1(sender As System.Object, e As System.Windows.ExceptionRoutedEventArgs)

    End Sub
    Private Sub adminPassword_PasswordChanged(sender As System.Object, e As RoutedEventArgs)
        If adminPassword.Password.Length = 0 Then
            adminPasswordHint.Visibility = Windows.Visibility.Visible
        Else
            adminPasswordHint.Visibility = Windows.Visibility.Hidden
        End If

    End Sub

    Private Sub Image1_ImageFailed_2(sender As System.Object, e As System.Windows.ExceptionRoutedEventArgs) Handles Image1.ImageFailed

    End Sub


    Private Sub Login_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles Login.Click
        Dim mainWindow As New MainWindow
        Me.Close()
        mainWindow.Show()
    End Sub
End Class
