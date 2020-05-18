Imports Microsoft.Office.Interop

Public Class Admin
    Public Shared _closeWindow As Action(Of Boolean)

    Private Sub userPassword_PasswordChanged(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        If adminPassword.Password.Length = 0 Then
            userPasswordHint.Visibility = Windows.Visibility.Visible
        Else
            userPasswordHint.Visibility = Windows.Visibility.Hidden
        End If
        If wrongPassword.Visibility = Windows.Visibility.Visible Then
            wrongPassword.Visibility = Windows.Visibility.Hidden
        End If
    End Sub

    Private Sub Login_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Login.Click
        Repository.adminLogin(adminPassword.Password)
        If Repository.admin = False Then
            wrongPassword.Visibility = Windows.Visibility.Visible
        Else
            connectedLabel.Visibility = Windows.Visibility.Visible
            Me.Close()
        End If
    End Sub

    Private Sub tb_KeyDown(ByVal sender As System.Object, ByVal e As KeyEventArgs) Handles adminPassword.PreviewKeyDown

        If (e.Key = Key.Enter) Then
            Repository.adminLogin(adminPassword.Password)
            If Repository.admin = False Then
                wrongPassword.Visibility = Windows.Visibility.Visible
            Else
                connectedLabel.Visibility = Windows.Visibility.Visible
                Me.Close()
            End If
        End If
    End Sub
End Class