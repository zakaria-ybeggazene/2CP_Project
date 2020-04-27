Imports Microsoft.Win32
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop
Public Class ImportFiles
    Dim filePath As String
    Dim ins As Boolean = False
    Dim notes As Boolean = False
    Dim mat As Boolean = False
    Dim rattrap As Boolean = False
    Dim inscritPath As String
    Dim notePath As String
    Dim matPath As String
    Dim ratPath As String

    Private Sub NomFichierChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.TextChangedEventArgs)
        'If Fichier.Text.Length = 0 Then
        '    FichierHint.Visibility = Windows.Visibility.Visible
        'Else
        '    FichierHint.Visibility = Windows.Visibility.Hidden
        'End If
    End Sub


    Public Sub ParcourirButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles ParcourirButton.Click

        Try
            Me.ForceCursor = True
            Mouse.OverrideCursor = Cursors.Wait
            filePath = ParcourirButtonClicked()
            Mouse.SetCursor(Cursors.Wait)
            If filePath <> "" Then
                Fichier.Content = filePath
            End If
            If ins = False Then
                verify(filePath, 1)
                If ins = True Then
                    Fichier.Content = "Nom du fichier"
                    file.Content = "SELECT NOTE FILE:"
                End If
            ElseIf notes = False Then
                verify(filePath, 2)
                If notes = True Then
                    Fichier.Content = "Nom du fichier"
                    file.Content = "SELECT MATIERE FILE:"
                End If
            ElseIf mat = False Then
                verify(filePath, 3)
                If mat = True Then
                    Fichier.Content = "Nom du fichier"
                    file.Content = "SELECT RATTRAPAGE FILE:"
                End If
            ElseIf rattrap = False Then
                verify(filePath, 4)
                If rattrap = True Then
                    Fichier.Content = "Nom du fichier"
                    file.Content = ""
                    ParcourirButton.IsEnabled = False
                    terminerButton.Opacity = "10"
                    terminerButton.IsEnabled = True
                    ImportbarVerified.Visibility = System.Windows.Visibility.Visible
                End If
            End If
        Catch ex As Exception
            MsgBox("Enter a valid path")
        Finally
            Mouse.OverrideCursor = Nothing
        End Try
    End Sub

    Private Sub terminerButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles terminerButton.Click
        Dim setPasswordWindow As SetPasword = New SetPasword(inscritPath, notePath, matPath, ratPath)
        Dim migration As MigrationViewModel = New MigrationViewModel("Migration", inscritPath, notePath, matPath, ratPath)
        setPasswordWindow.DataContext = migration
        Me.Close()
        setPasswordWindow.Show()
    End Sub

    Function ParcourirButtonClicked()
        'open the file dialog
        Dim fd As New OpenFileDialog
        Dim filePath As String
        'setup the file dialog
        fd.Title = "Select An Excel File"
        fd.Filter = "Microsoft Excel files(*.xls,*.xlsx)|*.xls;*.xlsx"
        fd.Multiselect = False
        If fd.ShowDialog() = True Then
            filePath = fd.FileName
        Else
            filePath = ""
        End If
        ParcourirButtonClicked = filePath
    End Function

    Sub verify(ByVal filePath As String, ByVal a As Short)
        Dim xlApp As New Excel.Application
        Dim wb As Excel.Workbook
        Dim ws As Excel.Worksheet
        wb = xlApp.Workbooks.Open(filePath)
        ws = wb.Worksheets(1)
        Select Case a
            Case 1 'fichier inscrit
                If ws.UsedRange.Columns.Count() = 40 Then
                    If ((ws.Cells(1, 1).value = "NomEtud") And (ws.Cells(1, 2).value = "Prenoms") _
                        And (ws.Cells(1, 3).value = "NomEtudA") And (ws.Cells(1, 4).value = "PrenomsA") _
                        And (ws.Cells(1, 5).value = "MATRIC_INS") And (ws.Cells(1, 6).value = "MATRICULE") _
                        And (ws.Cells(1, 7).value = "ANSCIN") And (ws.Cells(1, 8).value = "MATRIN") _
                        And (ws.Cells(1, 9).value = "DATENAIS") And (ws.Cells(1, 10).value = "LIEUNAISA") _
                        And (ws.Cells(1, 11).value = "WILNAISA" And (ws.Cells(1, 12).value = "LIEUNAIS") _
                        And (ws.Cells(1, 13).value = "WILNAIS") And (ws.Cells(1, 14).value = "ADRESSE") _
                        And (ws.Cells(1, 15).value = "VILLE") And (ws.Cells(1, 16).value = "WILAYA") _
                        And (ws.Cells(1, 17).value = "CODPOST") And (ws.Cells(1, 18).value = "ANETIN") _
                        And (ws.Cells(1, 19).value = "CYCLIN") And (ws.Cells(1, 20).value = "OPTIIN") _
                        And (ws.Cells(1, 21).value = "NUSEIN") And (ws.Cells(1, 22).value = "NS") _
                        And (ws.Cells(1, 23).value = "NUGRIN") And (ws.Cells(1, 24).value = "NG") _
                        And (ws.Cells(1, 25).value = "MOYEIN") And (ws.Cells(1, 26).value = "RANGIN") _
                        And (ws.Cells(1, 27).value = "MENTIN") And (ws.Cells(1, 28).value = "ELIMIN") _
                        And (ws.Cells(1, 29).value = "RATRIN") And (ws.Cells(1, 30).value = "DECIIN") _
                        And (ws.Cells(1, 31).value = "DEC") And (ws.Cells(1, 32).value = "SA") _
                        And (ws.Cells(1, 33).value = "WILBAC") And (ws.Cells(1, 34).value = "SEXE") _
                        And (ws.Cells(1, 35).value = "SERIEBAC") And (ws.Cells(1, 36).value = "MOYBAC") _
                        And (ws.Cells(1, 37).value = "ANNEEBAC") And (ws.Cells(1, 38).value = "FILS_DE") _
                        And (ws.Cells(1, 39).value = "ET_DE") And (ws.Cells(1, 40).value = "ADM"))) Then
                        MsgBox("Votre fichier est Valide", MsgBoxStyle.Information)
                        InscritsImage.Opacity = 1
                        inscritPath = filePath
                        ins = True
                    Else : Fichier.Content = ("Nom du fichier")
                        MsgBox("Erreur dans un des champs , Veuillez réessayer", MsgBoxStyle.Critical)

                    End If
                Else : Fichier.Content = ("Nom du fichier")
                    MsgBox("Erreur dans le nombre des champs , Veuillez réessayer", MsgBoxStyle.Critical)

                End If
            Case 2 'fichier note
                If ws.UsedRange.Columns.Count() = 11 Then
                    If ((ws.Cells(1, 1).value = "ANSCNO") And (ws.Cells(1, 2).value = "ANETNO") _
                        And (ws.Cells(1, 3).value = "CYCLNO") And (ws.Cells(1, 4).value = "OPTINO") _
                        And (ws.Cells(1, 5).value = "MATRNO") And (ws.Cells(1, 6).value = "COMANO") _
                        And (ws.Cells(1, 7).value = "NOJUNO") And (ws.Cells(1, 8).value = "NOSYNO") _
                        And (ws.Cells(1, 9).value = "NORANO") And (ws.Cells(1, 10).value = "ELIMNO") _
                        And (ws.Cells(1, 11).value = "RATRNO")) Then
                        MsgBox("Votre fichier est Valide", MsgBoxStyle.Information)
                        NoteImage.Opacity = 1
                        notePath = filePath
                        notes = True
                    Else : Fichier.Content = ("Nom du fichier")
                        MsgBox("Erreur dans un des champs , Veuillez réessayer", MsgBoxStyle.Critical)

                    End If
                Else : Fichier.Content = ("Nom du fichier")
                    MsgBox("Erreur dans le nombre des champs , Veuillez réessayer", MsgBoxStyle.Critical)

                End If
            Case 3 'fichier matiere
                If ws.UsedRange.Columns.Count() = 9 Then
                    If ((ws.Cells(1, 1).value = "ANSCMA") And (ws.Cells(1, 2).value = "ANETMA") _
                        And (ws.Cells(1, 3).value = "CYCLMA") And (ws.Cells(1, 4).value = "OPTIMA") _
                        And (ws.Cells(1, 5).value = "COMAMA") And (ws.Cells(1, 6).value = "LIBEMA") _
                        And (ws.Cells(1, 7).value = "TYPEMA") And (ws.Cells(1, 8).value = "COEFMA") _
                        And (ws.Cells(1, 9).value = "MOYMAT")) Then
                        MsgBox("Votre fichier est Valide", MsgBoxStyle.Information)
                        MatieresImage.Opacity = 1
                        matPath = filePath
                        mat = True
                    Else : Fichier.Content = ("Nom du fichier")
                        MsgBox("Erreur dans un des champs , Veuillez réessayer", MsgBoxStyle.Critical)

                    End If
                Else : Fichier.Content = ("Nom du fichier")
                    MsgBox("Erreur dans le nombre des champs , Veuillez réessayer", MsgBoxStyle.Critical)

                End If

            Case 4 'fichier rattrapage
                If ws.UsedRange.Columns.Count() = 9 Then
                    If ((ws.Cells(1, 1).value = "ANSCRA") And (ws.Cells(1, 2).value = "ANETRA") _
                        And (ws.Cells(1, 3).value = "CYCLRA") And (ws.Cells(1, 4).value = "OPTIRA") _
                        And (ws.Cells(1, 5).value = "MATRRA") And (ws.Cells(1, 6).value = "MOYERA") _
                        And (ws.Cells(1, 7).value = "MENTRA") And (ws.Cells(1, 8).value = "ELIMRA") _
                        And (ws.Cells(1, 9).value = "RATRRA")) Then
                        MsgBox("Votre fichier est Valide", MsgBoxStyle.Information)
                        RattrapageImage.Opacity = 1
                        ratPath = filePath
                        rattrap = True
                    Else : Fichier.Content = ("Nom du fichier")
                        MsgBox("Erreur dans un des champs , Veuillez réessayer", MsgBoxStyle.Critical)
                    End If
                Else : Fichier.Content = ("Nom du fichier")
                    MsgBox("Erreur dans le nombre des champs , Veuillez réessayer", MsgBoxStyle.Critical)
                End If
        End Select
        wb.Close()
        xlApp.Quit()
    End Sub

    Private Sub Importbar_ImageFailed(sender As System.Object, e As System.Windows.ExceptionRoutedEventArgs) Handles Importbar.ImageFailed

    End Sub
End Class