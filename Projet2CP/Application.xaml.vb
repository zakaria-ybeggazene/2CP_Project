Class Application

    ' Application-level events, such as Startup, Exit, and DispatcherUnhandledException
    ' can be handled in this file.
    Protected Overrides Sub OnStartup(ByVal e As System.Windows.StartupEventArgs)
        MyBase.OnStartup(e)

        Dim dbExists As Boolean
        dbExists = System.IO.File.Exists(My.Computer.FileSystem.CurrentDirectory & "\db.accdb")

        If dbExists Then
            Dim window As LoginWindow = New LoginWindow()
            window.Show()
        Else
            Dim window As ImportFiles = New ImportFiles()
            window.Show()
        End If

    End Sub


    Protected Overrides Sub OnExit(ByVal e As System.Windows.ExitEventArgs)
        MyBase.OnExit(e)
        Repository.disposer()
    End Sub

End Class
