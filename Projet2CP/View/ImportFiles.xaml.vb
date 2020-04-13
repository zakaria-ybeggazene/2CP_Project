Public Class importerfichier

    Private Sub NomFichierChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.TextChangedEventArgs)
        If Fichier.Text.Length = 0 Then
            FichierHint.Visibility = Windows.Visibility.Visible
        Else
            FichierHint.Visibility = Windows.Visibility.Hidden
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Parcourir.Click
        Migration.Migration()
        Dim mainWindow As Window1 = New Window1()
        Me.Close()
        mainWindow.Show()
    End Sub
End Class
