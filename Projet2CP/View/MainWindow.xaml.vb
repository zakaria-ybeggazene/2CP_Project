Class MainWindow
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        DataContext = New MainWindowViewModel(ClosingAction)
    End Sub

    Private Sub Window_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
    End Sub

    Private Sub WorkspaceList_SelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles WorkspaceList.SelectionChanged

    End Sub

    Public ClosingAction As Action(Of Boolean) = Sub(b As Boolean)
                                                     closeAll = b
                                                     If b Then
                                                         Me.Close()
                                                         Application.Current.Shutdown()
                                                     Else
                                                         Me.Close()
                                                     End If
                                                 End Sub

    Private closeAll As Boolean = True
    Protected Overrides Sub OnClosed(ByVal e As System.EventArgs)
        MyBase.OnClosed(e)
        If closeAll Then
            Application.Current.Shutdown()
        End If
    End Sub

End Class
