Imports System.Security.Cryptography
Imports System.Text
Imports Microsoft.Win32
Imports System.IO

Public Class Util
    ''Attribut designant la largeur de l'écran
    Public Shared width As Double = System.Windows.SystemParameters.WorkArea.Width - 218
    ''Fonction utilitaire pour recuperer le niveau a partir du cycle et de l'année
    Public Shared Function GetNiveau(ByVal Cycle As String, ByVal Annee As Integer) As Niveau
        If Cycle = "TRC" Then
            If Annee = 1 Then
                Return Niveau.TRC1
            Else
                Return Niveau.TRC2
            End If
        ElseIf Cycle = "SI" Then
            If Annee = 3 Then
                Return Niveau.SI1
            ElseIf Annee = 4 Then
                Return Niveau.SI2
            Else
                Return Niveau.SI3
            End If
        Else
            If Annee = 3 Then
                Return Niveau.SIQ1
            ElseIf Annee = 4 Then
                Return Niveau.SIQ2
            Else
                Return Niveau.SIQ3
            End If
        End If
    End Function

    Public Shared Function GetOption(ByVal niveau As Niveau) As String
        Select Case niveau
            Case HistoESI.Niveau.TRC1, HistoESI.Niveau.TRC2
                Return "TRC"
            Case HistoESI.Niveau.SI1, HistoESI.Niveau.SI2, HistoESI.Niveau.SI3
                Return "SI"
            Case HistoESI.Niveau.SIQ1, HistoESI.Niveau.SIQ2, HistoESI.Niveau.SIQ3
                Return "SIQ"
            Case Else
                Return ""
        End Select
    End Function
    Public Shared Function GetAnneEt(ByVal niveau As Niveau) As Integer
        Select Case niveau
            Case HistoESI.Niveau.TRC1
                Return 1
            Case HistoESI.Niveau.TRC2
                Return 2
            Case HistoESI.Niveau.SI1, HistoESI.Niveau.SIQ1
                Return 3
            Case HistoESI.Niveau.SI2, HistoESI.Niveau.SIQ2
                Return 4
            Case Else
                Return 5
        End Select
    End Function
    Public Shared Function stringToNiveau(ByVal strNiv As String) As Niveau
        Dim niv As Niveau
        Select Case strNiv
            Case "TRC1"
                niv = HistoESI.Niveau.TRC1
            Case "TRC2"
                niv = HistoESI.Niveau.TRC2
            Case "SI1"
                niv = HistoESI.Niveau.SI1
            Case "SIQ1"
                niv = HistoESI.Niveau.SIQ1
            Case "SI2"
                niv = HistoESI.Niveau.SI2
            Case "SIQ2"
                niv = HistoESI.Niveau.SIQ2
            Case "SI3"
                niv = HistoESI.Niveau.SI3
            Case "SIQ3"
                niv = HistoESI.Niveau.SIQ3
            Case Else
        End Select
        Return niv
    End Function
    Public Shared Function GetAnneeUniv(ByVal annee As String) As String
        Dim anneeUnivStr As String
        If annee = 99 Then
            anneeUnivStr = "1999 / 2000"
        ElseIf annee > 60 Then
            anneeUnivStr = "19" & annee & " / 19" & annee + 1
        ElseIf annee >= 0 And annee < 9 Then
            anneeUnivStr = "20" & annee & " /200" & annee + 1
        Else
            anneeUnivStr = "20" & annee & " /20" & annee + 1
        End If
        Return anneeUnivStr
    End Function
    Public Shared Function GetDecisionRN(ByVal dec As String) As String
        Dim decStr As String
        Select Case dec
            Case 1
                decStr = "Admis"
            Case 2
                decStr = "Admis avec rachat"
            Case 3
                decStr = "Redouble"
            Case 4
                decStr = "Non Admis"
            Case 5
                decStr = "Maladie"
            Case 6
                decStr = "Abandon"
            Case Else
                decStr = ""
        End Select
        Return decStr
    End Function
    Public Shared Function GetDecisionPV(ByVal dec As String) As String
        Dim decStr As String
        Select Case dec
            Case 1
                decStr = "Admis"
            Case 2
                decStr = "Admis R"
            Case 3
                decStr = "Redouble"
            Case 4
                decStr = "Non Admis"
            Case 5
                decStr = "Maladie"
            Case 6
                decStr = "Abandon"
            Case Else
                decStr = ""
        End Select
        Return decStr
    End Function
    Public Shared Function GetMention(ByVal mention As Integer) As String
        Dim menStr As String
        Select Case mention
            Case 1
                menStr = "Très Bien"
            Case 2
                menStr = "Bien"
            Case 3
                menStr = "Assez Bien"
            Case 4
                menStr = "Passable"
            Case 6
                menStr = "Passe au Rattrapage"
            Case 7
                menStr = "Abandon"
            Case 8
                menStr = "Redouble"
            Case Else
                menStr = ""
        End Select
        Return menStr
    End Function
    Public Shared Function GetMentionPV(ByVal mention As Integer) As String
        Dim menStr As String
        Select Case mention
            Case 1
                menStr = "TB"
            Case 2
                menStr = "Bien"
            Case 3
                menStr = "AB"
            Case 4
                menStr = "Pass."
            Case 6
                menStr = "Rattr."
            Case 7
                menStr = "ABN"
            Case 8
                menStr = "RDB"
            Case Else
                menStr = ""
        End Select
        Return menStr
    End Function

    Public Shared Function dbNullToString(ByVal o As Object) As String
        If IsDBNull(o) Then
            Return ""
        Else
            Return o.ToString.Trim
        End If
    End Function
    Public Shared Function dbNullToInteger(ByVal o As Object) As Integer
        If IsDBNull(o) Then
            Return 0
        Else
            Return o
        End If
    End Function
    Public Shared Function dbNullToDouble(ByVal o As Object) As Double
        If IsDBNull(o) Then
            Return 0
        Else
            Return o
        End If
    End Function

    Public Shared Function compareAnneEtude(ByVal x As AnneeEtude, ByVal y As AnneeEtude) As Integer
        If x.Niveau <> y.Niveau Then
            Return x.AnnetIn.CompareTo(y.AnnetIn)
        Else
            Dim a As Integer = x.Annee
            Dim b As Integer = y.Annee
            If a > 60 Then
                a += 1900
            Else
                a += 2000
            End If
            If b > 60 Then
                b += 1900
            Else
                b += 2000
            End If

            Return a.CompareTo(b)
        End If
    End Function

    'Fonction de hachage //Source du code est une solution dans le site stack overflow
    Public Shared Function GetHash(ByVal theInput As String) As String

        Using hasher As SHA256 = SHA256.Create()    ' create hash object

            ' Convert to byte array and get hash
            Dim dbytes As Byte() =
                 hasher.ComputeHash(Encoding.UTF8.GetBytes(theInput))

            ' sb to create string from bytes
            Dim sBuilder As New StringBuilder()

            ' convert byte data to hex string
            For n As Integer = 0 To dbytes.Length - 1
                sBuilder.Append(dbytes(n).ToString("X2"))
            Next n

            Return sBuilder.ToString()
        End Using

    End Function

    Public Shared Sub EncodeVisual(ByVal visual As FrameworkElement, ByVal encoder As BitmapEncoder, ByVal addHeight As Integer, ByVal addWidth As Integer)

        Dim sd As New SaveFileDialog()
        sd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"

        If sd.ShowDialog = True Then


            Dim fileName As String = sd.FileName

            Dim bitmap As New RenderTargetBitmap(visual.ActualWidth + addWidth, visual.ActualHeight + addHeight, 96, 96, PixelFormats.Pbgra32)
            bitmap.Render(visual)
            Dim frame = BitmapFrame.Create(bitmap)
            encoder.Frames.Add(frame)
            Dim stream = File.Create(fileName)
            encoder.Save(stream)
            stream.Close()
        End If


    End Sub

    Public Shared ReglageIconPath As String = "M1.39,7.02H0.9C0.4,7.02,0,7.45,0,7.95v2.69c0,0.51,0.4,0.87,0.9,0.87H1.4c0.81,0,1.3,1.18,0.72,1.76" &
    "l-0.33,0.33c-0.36,0.34-0.36,0.93,0,1.27l1.88,1.9c0.34,0.34,0.91,0.34,1.27,0l0.55-0.55c0.57-0.57,1.52-0.16,1.52,0.64v0.81" &
    "c0,0.49,0.4,0.87,0.9,0.87h2.69c0.49,0,0.9-0.36,0.9-0.87v-0.81c0-0.79,0.97-1.19,1.52-0.63l0.55,0.55c0.34,0.34,0.91,0.34,1.27,0" &
    "l1.88-1.88c0.36-0.36,0.34-0.93,0-1.27l-0.33-0.34c-0.58-0.57-0.09-1.76,0.72-1.76h0.51c0.49,0,0.9-0.36,0.9-0.87V7.96" &
    "c0-0.49-0.4-0.93-0.9-0.93h-0.49c-0.81,0-1.31-1.21-0.75-1.78l0.36-0.34c0.34-0.34,0.34-0.91,0-1.25l-1.88-1.88" &
    "c-0.36-0.36-0.93-0.34-1.27,0l-0.36,0.31c-0.57,0.58-1.73,0.1-1.73-0.72V0.93c0-0.49-0.4-0.93-0.9-0.93H7.92" &
    "c-0.49,0-0.9,0.43-0.9,0.93v0.45c0,0.82-1.17,1.3-1.73,0.72L4.94,1.75c-0.34-0.36-0.93-0.36-1.27,0l-1.9,1.9" &
    "c-0.34,0.34-0.34,0.91,0,1.27l0.36,0.33C2.7,5.81,2.2,7.02,1.39,7.02z M9.29,5.71c1.99,0,3.58,1.6,3.58,3.58s-1.6,3.58-3.58,3.58" &
    "s-3.58-1.6-3.58-3.58C5.71,7.3,7.32,5.71,9.29,5.71z"





    Public Shared PromotionIconPath As String = "M24.52,14.93c-2.21-1.81-4.58-3.01-5.07-3.25c-0.05-0.03-0.09-0.08-0.09-0.14V8.11" &
 "c0.43-0.29,0.72-0.78,0.72-1.33V3.21c0-1.77-1.44-3.21-3.21-3.21h-0.38H16.1c-1.77,0-3.21,1.44-3.21,3.21v3.56" &
 "c0,0.56,0.28,1.05,0.72,1.33v3.43c0,0.06-0.03,0.12-0.09,0.14c-0.49,0.24-2.86,1.44-5.07,3.25c-0.4,0.33-0.63,0.82-0.63,1.33v2.44" &
 "h8.67h8.66v-2.44C25.15,15.75,24.92,15.26,24.52,14.93z M32.45,12.53C30.6,11,28.61,10,28.2,9.8c-0.05-0.02-0.07-0.07-0.07-0.12V6.8" &
 "c0.36-0.24,0.6-0.65,0.6-1.12V2.69c0-1.48-1.21-2.69-2.69-2.69h-0.32H25.4c-1.48,0-2.69,1.21-2.69,2.69v2.99" &
 "c0,0.47,0.24,0.88,0.6,1.12v2.88c0,0.05-0.03,0.09-0.07,0.12c-0.25,0.12-1.12,0.56-2.17,1.23c1.06,0.58,2.73,1.58,4.31,2.88" &
 "c0.56,0.45,0.92,1.08,1.06,1.77H33v-2.05C32.98,13.21,32.79,12.8,32.45,12.53z M9.75,9.8C9.7,9.78,9.68,9.73,9.68,9.68V6.8" &
 "c0.36-0.24,0.6-0.65,0.6-1.12V2.69C10.28,1.21,9.07,0,7.59,0H7.27H6.94C5.46,0,4.25,1.21,4.25,2.69v2.99c0,0.47,0.24,0.88,0.6,1.12" &
 "v2.88c0,0.05-0.03,0.09-0.07,0.12C4.37,10,2.38,11,0.53,12.53C0.2,12.81,0,13.21,0,13.65v2.05h6.57c0.13-0.69,0.5-1.32,1.06-1.77" &
 "c1.58-1.3,3.25-2.3,4.31-2.88C10.87,10.35,10,9.92,9.75,9.8z"

    Public Shared EtudiantIconPath As String = "M15.64,14.93c-2.07-1.81-4.29-3.01-4.75-3.25c-0.05-0.03-0.08-0.08-0.08-0.14V8.11" &
 "c0.41-0.29,0.67-0.78,0.67-1.33V3.21C11.48,1.44,10.13,0,8.47,0H8.12H7.76C6.09,0,4.75,1.44,4.75,3.21v3.56" &
 "c0,0.56,0.27,1.05,0.67,1.33v3.43c0,0.06-0.03,0.12-0.08,0.14c-0.46,0.24-2.68,1.44-4.75,3.25C0.22,15.26,0,15.75,0,16.27v2.44h8.12" &
 "h8.11v-2.44C16.23,15.75,16.01,15.26,15.64,14.93z"

    Public Shared LoginIconPath As String = "M8.79,11.52H0.43C0.19,11.52,0,11.28,0,10.98s0.19-0.55,0.43-0.55h8.35c0.24,0,0.43,0.24,0.43,0.55" &
 "C9.22,11.28,9.02,11.52,8.79,11.52z M7.23,14.13c-0.28,0-0.5-0.22-0.5-0.5c0-0.13,0.05-0.26,0.15-0.35l2.3-2.3l-2.3-2.3" &
 "c-0.19-0.19-0.19-0.51,0-0.7c0.19-0.19,0.51-0.19,0.7,0l2.65,2.65c0.19,0.19,0.19,0.51,0,0.7c0,0,0,0,0,0l-2.65,2.65" &
 "C7.49,14.08,7.36,14.13,7.23,14.13L7.23,14.13z M15.11,21.45c-4.44,0-8.35-2.67-9.98-6.8c-0.15-0.37,0.04-0.8,0.41-0.95" &
 "c0.37-0.15,0.8,0.04,0.95,0.41c1.4,3.57,4.79,5.87,8.62,5.87c5.11,0,9.26-4.15,9.26-9.26s-4.15-9.26-9.26-9.26" &
 "c-3.83,0-7.21,2.31-8.62,5.87C6.34,7.71,5.91,7.89,5.54,7.75C5.16,7.6,4.98,7.17,5.13,6.8C6.75,2.67,10.67,0,15.11,0" &
 "c5.91,0,10.72,4.81,10.72,10.72S21.02,21.45,15.11,21.45L15.11,21.45z M19.34,11.02c-1.44-0.47-2.04-1.05-2.04-1.05l-0.05,0.05" &
 "c-0.43,0.4-0.9,0.64-1.33,0.64h-0.04c-0.43,0-0.9-0.24-1.33-0.64L14.5,9.96c0,0-0.6,0.58-2.04,1.05c-2.12,0.79-1.49,4.02-1.49,4.05" &
 "c0.07,0.36,0.11,0.48,0.14,0.5c2.13,0.95,7.44,0.95,9.57,0c0.03-0.01,0.07-0.14,0.14-0.5C20.83,15.04,21.48,11.83,19.34,11.02z" &
 " M18.14,6.9l-0.02-0.02c-0.12-0.11-0.11-0.1-0.11-0.1s0.21-1.05,0.04-1.55c-0.26-0.79-1.83-1.33-2.15-1.39c0,0-0.19-0.04-0.2-0.04" &
 "c0,0-0.25-0.05-0.53,0.08C14.98,3.94,14,4.39,13.73,5.23c-0.17,0.5,0.04,1.55,0.04,1.55s0.01-0.01-0.11,0.1L13.64,6.9" &
 "c-0.08,0.09-0.06,0.38,0.03,0.68c0.08,0.3,0.18,0.38,0.21,0.45c0.25,1.19,1.14,2.21,2.03,2.21s1.73-1.02,1.99-2.21" &
 "c0.03-0.07,0.13-0.15,0.21-0.45C18.2,7.28,18.22,6.97,18.14,6.9z"




    Public Shared StatisticsIconPath As String = "M21.43,0.15C21.33,0.05,21.19,0,21.05,0l-2.38,0.08c-0.29,0.01-0.51,0.25-0.5,0.53" &
 "c0.01,0.29,0.25,0.51,0.53,0.5l0.48-0.02l0.09,0.09l-0.85,0.68l-3.63,2.9L12.91,3.4L9.68,1.05c-0.26-0.19-0.6-0.2-0.87-0.03" &
 "L1.13,5.9C0.77,6.13,0.66,6.61,0.89,6.97c0.15,0.23,0.4,0.36,0.65,0.36c0.14,0,0.29-0.04,0.41-0.12l2.16-1.37L9.2,2.61L11,3.93" &
 "l3.35,2.44c0.28,0.2,0.67,0.2,0.94-0.02l5.08-4.05l0.11,0.11l-0.02,0.48c-0.01,0.29,0.21,0.52,0.5,0.53c0.01,0,0.01,0,0.02,0" &
 "c0.28,0,0.51-0.22,0.52-0.5l0.08-2.38C21.58,0.39,21.53,0.25,21.43,0.15z M22.62,17.16H22.1V7.37c0-0.62-0.5-1.12-1.12-1.12h-1.65" &
 "c-0.62,0-1.12,0.5-1.12,1.12v9.79h-1.48v-6.22c0-0.62-0.5-1.12-1.12-1.12h-1.65c-0.62,0-1.12,0.5-1.12,1.12v6.22h-1.48V7.63" &
 "c0-0.62-0.5-1.12-1.12-1.12H8.63c-0.62,0-1.12,0.5-1.12,1.12v9.53H6.04v-3.17c0-0.62-0.5-1.12-1.12-1.12H3.27" &
 "c-0.62,0-1.12,0.5-1.12,1.12v3.17H0.52C0.23,17.16,0,17.39,0,17.68s0.23,0.52,0.52,0.52h22.1c0.29,0,0.52-0.23,0.52-0.52" &
 "C23.13,17.39,22.9,17.16,22.62,17.16z"

    Public Shared LogoutIconPath As String = "M1.59,11.52h8.35c0.24,0,0.43-0.24,0.43-0.55s-0.19-0.55-0.43-0.55H1.59c-0.24,0-0.43,0.24-0.43,0.55" &
 "C1.16,11.28,1.35,11.52,1.59,11.52z M3.15,14.13c0.28,0,0.5-0.22,0.5-0.5c0-0.13-0.05-0.26-0.15-0.35l-2.3-2.3l2.3-2.3" &
 "c0.19-0.19,0.19-0.51,0-0.7s-0.51-0.19-0.7,0l-2.65,2.65c-0.19,0.19-0.19,0.51,0,0.7c0,0,0,0,0,0l2.65,2.65" &
 "C2.89,14.08,3.02,14.13,3.15,14.13L3.15,14.13z M15.11,21.45c-4.44,0-8.35-2.67-9.98-6.8c-0.15-0.37,0.04-0.8,0.41-0.95" &
 "c0.37-0.15,0.8,0.04,0.95,0.41c1.4,3.57,4.79,5.87,8.62,5.87c5.11,0,9.26-4.15,9.26-9.26s-4.15-9.26-9.26-9.26" &
 "c-3.83,0-7.21,2.31-8.62,5.87C6.34,7.71,5.91,7.89,5.54,7.75C5.16,7.6,4.98,7.17,5.13,6.8C6.75,2.67,10.67,0,15.11,0" &
 "c5.91,0,10.72,4.81,10.72,10.72S21.02,21.45,15.11,21.45L15.11,21.45z M19.34,11.02c-1.44-0.47-2.04-1.05-2.04-1.05l-0.05,0.05" &
 "c-0.43,0.4-0.9,0.64-1.33,0.64h-0.04c-0.43,0-0.9-0.24-1.33-0.64L14.5,9.96c0,0-0.6,0.58-2.04,1.05c-2.12,0.79-1.49,4.02-1.49,4.05" &
 "c0.07,0.36,0.11,0.48,0.14,0.5c2.13,0.95,7.44,0.95,9.57,0c0.03-0.01,0.07-0.14,0.14-0.5C20.83,15.04,21.48,11.83,19.34,11.02z" &
 " M18.14,6.9l-0.02-0.02c-0.12-0.11-0.11-0.1-0.11-0.1s0.21-1.05,0.04-1.55c-0.26-0.79-1.83-1.33-2.15-1.39c0,0-0.19-0.04-0.2-0.04" &
 "c0,0-0.25-0.05-0.53,0.08C14.98,3.94,14,4.39,13.73,5.23c-0.17,0.5,0.04,1.55,0.04,1.55s0.01-0.01-0.11,0.1L13.64,6.9" &
 "c-0.08,0.09-0.06,0.38,0.03,0.68c0.08,0.3,0.18,0.38,0.21,0.45c0.25,1.19,1.14,2.21,2.03,2.21s1.73-1.02,1.99-2.21" &
 "c0.03-0.07,0.13-0.15,0.21-0.45C18.2,7.28,18.22,6.97,18.14,6.9z"

    Public Shared ExportIconPath As String = "M17.9,7.5c-0.4,0-0.7,0.3-0.7,0.7v10.4H1.4V2.9h10.4c0.4,0,0.7-0.3,0.7-0.7s-0.3-0.7-0.7-0.7H0.7" &
 "C0.3,1.4,0,1.7,0,2.1v17.1C0,19.7,0.3,20,0.7,20h17.1c0.4,0,0.7-0.3,0.7-0.7V8.2C18.6,7.8,18.3,7.5,17.9,7.5z M19.8,0.2" &
 "C19.6,0.1,19.5,0,19.3,0h-4.6c-0.4,0-0.7,0.3-0.7,0.7s0.3,0.7,0.7,0.7h2.9L9.5,9.5c-0.3,0.3-0.3,0.7-0.1,1c0.2,0.3,0.7,0.3,1,0.1" &
 "c0,0,0.1,0,0.1-0.1l8.1-8.1v2.9c0,0.4,0.3,0.7,0.7,0.7S20,5.8,20,5.4V0.7C20,0.5,19.9,0.4,19.8,0.2z"




End Class
