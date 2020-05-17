Class MainWindow
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        DataContext = New MainWindowViewModel(AddressOf Me.Close)
    End Sub

    Private Sub Window_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
    End Sub

    Private Sub WorkspaceList_SelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles WorkspaceList.SelectionChanged

    End Sub

    Protected Overrides Sub OnClosed(ByVal e As System.EventArgs)
        MyBase.OnClosed(e)
        Application.Current.Shutdown()
    End Sub

End Class
