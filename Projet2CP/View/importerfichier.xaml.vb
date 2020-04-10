Imports Microsoft.Win32
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop
Public Class importerfichier
    Dim filePath As String
    Dim app As New Excel.Application
    Dim ins As Boolean = False
    Dim note As Boolean = False
    Dim mat As Boolean = False
    Dim rat As Boolean = False
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

    Function ParcourirButtonClicked()
        ''open the file dialog
        Dim fd As New OpenFileDialog
        Dim filePath As String
        'setup the file dialog
        fd.Title = "Select An Excel File"
        fd.Filter = "Microsoft Excel files(*.xls,*.xlsx)|*.xls;*.xlsx"
        fd.Multiselect = False
        If fd.ShowDialog() = True Then
            filePath = fd.FileName
        Else
            MsgBox("You have canceled your selection")
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
                If ws.UsedRange.Columns.Count() = 36 Then
                    If ((ws.Cells(1, 1).value = "NomEtud") And (ws.Cells(1, 2).value = "Prenoms") _
                        And (ws.Cells(1, 3).value = "NomEtudA") And (ws.Cells(1, 4).value = "PrenomsA") _
                        And (ws.Cells(1, 5).value = "MATRIC_INS") And (ws.Cells(1, 6).value = "ANSCIN") _
                        And (ws.Cells(1, 7).value = "MATRIN") And (ws.Cells(1, 8).value = "DATENAIS") _
                        And (ws.Cells(1, 9).value = "LIEUNAISA") And (ws.Cells(1, 10).value = "WILNAISA" _
                        And (ws.Cells(1, 11).value = "LIEUNAIS") And (ws.Cells(1, 12).value = "WILNAIS") _
                        And (ws.Cells(1, 13).value = "ADRESSE") And (ws.Cells(1, 14).value = "VILLE") _
                        And (ws.Cells(1, 15).value = "WILAYA") And (ws.Cells(1, 16).value = "CODPOST") _
                        And (ws.Cells(1, 17).value = "ANETIN") And (ws.Cells(1, 18).value = "CYCLIN") _
                        And (ws.Cells(1, 19).value = "OPTIIN") And (ws.Cells(1, 20).value = "NS") _
                        And (ws.Cells(1, 21).value = "NG") And (ws.Cells(1, 22).value = "MOYEIN") _
                        And (ws.Cells(1, 23).value = "RANGIN") And (ws.Cells(1, 24).value = "MENTIN") _
                        And (ws.Cells(1, 25).value = "ELIMIN") And (ws.Cells(1, 26).value = "RATRIN") _
                        And (ws.Cells(1, 27).value = "DECIIN") And (ws.Cells(1, 29).value = "WILBAC") _
                        And (ws.Cells(1, 30).value = "SEXE") And (ws.Cells(1, 31).value = "SERIEBAC") _
                        And (ws.Cells(1, 32).value = "MOYBAC") And (ws.Cells(1, 33).value = "ANNEEBAC") _
                        And (ws.Cells(1, 34).value = "FILS_DE") And (ws.Cells(1, 35).value = "ET_DE") _
                        And (ws.Cells(1, 36).value = "ADM"))) Then
                        MsgBox("valid")
                        inscritPath = filePath
                        ins = True
                    Else : MsgBox("erreur dans un des champs , réessayer")
                    End If
                Else : MsgBox("erreur dans le nombre de champs, réessayer")
                End If
            Case 2 'fichier note
                If ws.UsedRange.Columns.Count() = 11 Then
                    If ((ws.Cells(1, 1).value = "ANETNO") And (ws.Cells(1, 2).value = "ANSCNO") _
                        And (ws.Cells(1, 3).value = "COMANO") And (ws.Cells(1, 4).value = "CYCLNO") _
                        And (ws.Cells(1, 5).value = "ELIMNO") And (ws.Cells(1, 6).value = "MATRNO") _
                        And (ws.Cells(1, 7).value = "NOJUNO") And (ws.Cells(1, 8).value = "NORANO") _
                        And (ws.Cells(1, 9).value = "NOSYNO") And (ws.Cells(1, 10).value = "OPTINO") _
                        And (ws.Cells(1, 11).value = "RATRNO")) Then
                        MsgBox("valid")
                        notePath = filePath
                        note = True
                    Else : MsgBox("erreur dans un des champs , réessayer")
                    End If
                Else : MsgBox("erreur dans le nombre de champs, réessayer")
                End If
            Case 3 'fichier matiere
                If ws.UsedRange.Columns.Count() = 9 Then
                    If ((ws.Cells(1, 1).value = "ANSCMA") And (ws.Cells(1, 2).value = "ANETMA") _
                        And (ws.Cells(1, 3).value = "CYCLMA") And (ws.Cells(1, 4).value = "OPTIMA") _
                        And (ws.Cells(1, 5).value = "COMAMA") And (ws.Cells(1, 6).value = "LIBEMA") _
                        And (ws.Cells(1, 7).value = "TYPEMA") And (ws.Cells(1, 8).value = "COEFMA") _
                        And (ws.Cells(1, 9).value = "MOYMAT")) Then
                        MsgBox("valid")
                        matPath = filePath
                        mat = True
                    Else : MsgBox("erreur dans un des champs , réessayer")
                    End If
                Else : MsgBox("erreur dans le nombre de champs, réessayer")
                End If

            Case 4 'fichier rattrapage
                If ws.UsedRange.Columns.Count() = 9 Then
                    If ((ws.Cells(1, 1).value = "ANSCRA") And (ws.Cells(1, 2).value = "ANETRA") _
                        And (ws.Cells(1, 3).value = "CYCLRA") And (ws.Cells(1, 4).value = "OPTIRA") _
                        And (ws.Cells(1, 5).value = "MATRRA") And (ws.Cells(1, 6).value = "MOYERA") _
                        And (ws.Cells(1, 7).value = "MENTRA") And (ws.Cells(1, 8).value = "ELIMRA") _
                        And (ws.Cells(1, 9).value = "RATRRA")) Then
                        MsgBox("valid")
                        ratPath = filePath
                        rat = True
                        validLabel.Content = "valid!"
                    Else : MsgBox("erreur dans un des champs , réessayer")
                    End If
                Else : MsgBox("erreur dans le nombre de champs, réessayer")
                End If
            Case Else
                MsgBox("ERROR , Not valid code")
        End Select
        wb.Close()
        xlApp.Quit()
    End Sub

    Public Sub ParcourirButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles ParcourirButton.Click
        filePath = ParcourirButtonClicked()
        Fichier.Text = filePath
        If ins = False Then
            verify(filePath, 1)
            If ins = True Then
                app.Wait(DateAdd("s", 5, Now))
                file.Content = "Select NOTE File"
            End If       
        ElseIf note = False Then
            verify(filePath, 2)
            If note = True Then
                app.Wait(DateAdd("s", 5, Now))
                file.Content = "Select MATIERE File"
                'validLabel.Content = ""
            End If    
        ElseIf mat = False Then
            verify(filePath, 3)
            If mat = True Then
                app.Wait(DateAdd("s", 5, Now))
                file.Content = "Select RATTRAPAGE File"
                'validLabel.Content = ""
            End If 
        ElseIf rat = False Then
            verify(filePath, 4)
            If rat = True Then
                app.Wait(DateAdd("s", 5, Now))
                file.Content = ""
                'validLabel.Content = ""
            End If        
        End If

    End Sub

End Class