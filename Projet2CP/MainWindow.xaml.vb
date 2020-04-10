Imports System.Data

Class MainWindow
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        DataContext = New MainWindowViewModel()
        'Migration()
    End Sub
End Class
