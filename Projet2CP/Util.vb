Imports System.Security.Cryptography
Imports System.Text

Public Class Util
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
            Case Projet2CP.Niveau.TRC1, Projet2CP.Niveau.TRC2
                Return "TRC"
            Case Projet2CP.Niveau.SI1, Projet2CP.Niveau.SI2, Projet2CP.Niveau.SI3
                Return "SI"
            Case Projet2CP.Niveau.SIQ1, Projet2CP.Niveau.SIQ2, Projet2CP.Niveau.SIQ3
                Return "SIQ"
            Case Else
                Return ""
        End Select
    End Function
    Public Shared Function GetAnneEt(ByVal niveau As Niveau) As Integer
        Select Case niveau
            Case Projet2CP.Niveau.TRC1
                Return 1
            Case Projet2CP.Niveau.TRC2
                Return 2
            Case Projet2CP.Niveau.SI1, Projet2CP.Niveau.SIQ1
                Return 3
            Case Projet2CP.Niveau.SI2, Projet2CP.Niveau.SIQ2
                Return 4
            Case Else
                Return 5
        End Select
    End Function
    Public Shared Function stringToNiveau(ByVal strNiv As String) As Niveau
        Dim niv As Niveau
        Select Case strNiv
            Case "TRC1"
                niv = Projet2CP.Niveau.TRC1
            Case "TRC2"
                niv = Projet2CP.Niveau.TRC2
            Case "SI1"
                niv = Projet2CP.Niveau.SI1
            Case "SIQ1"
                niv = Projet2CP.Niveau.SIQ1
            Case "SI2"
                niv = Projet2CP.Niveau.SI2
            Case "SIQ2"
                niv = Projet2CP.Niveau.SIQ2
            Case "SI3"
                niv = Projet2CP.Niveau.SI3
            Case "SIQ3"
                niv = Projet2CP.Niveau.SIQ3
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
    Public Shared Function GetDecisionCR(ByVal dec As String) As String
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

    Public Shared LoginIconPath As String = "M18.29,0h-8.26C9.7,0,9.44,0.26,9.44,0.59s0.26,0.59,0.59,0.59h7.67V17.7h-7.67c-0.33,0-0.59,0.26-0.59,0.59" &
 "c0,0.33,0.26,0.59,0.59,0.59h8.26c0.33,0,0.59-0.26,0.59-0.59V0.59C18.88,0.26,18.61,0,18.29,0z M9.67,13.15" &
 "c-0.23,0.23-0.23,0.61,0,0.84c0.23,0.23,0.6,0.23,0.83,0l4.07-4.13c0.23-0.23,0.23-0.61,0-0.84L10.5,4.9c-0.23-0.23-0.6-0.23-0.83,0" &
 "c-0.23,0.23-0.23,0.61,0,0.84l3.07,3.11H0.59C0.26,8.85,0,9.12,0,9.45s0.26,0.6,0.59,0.6h12.15L9.67,13.15z"




    Public Shared StatisticsIconPath As String = "M21.43,0.15C21.33,0.05,21.19,0,21.05,0l-2.38,0.08c-0.29,0.01-0.51,0.25-0.5,0.53" &
 "c0.01,0.29,0.25,0.51,0.53,0.5l0.48-0.02l0.09,0.09l-0.85,0.68l-3.63,2.9L12.91,3.4L9.68,1.05c-0.26-0.19-0.6-0.2-0.87-0.03" &
 "L1.13,5.9C0.77,6.13,0.66,6.61,0.89,6.97c0.15,0.23,0.4,0.36,0.65,0.36c0.14,0,0.29-0.04,0.41-0.12l2.16-1.37L9.2,2.61L11,3.93" &
 "l3.35,2.44c0.28,0.2,0.67,0.2,0.94-0.02l5.08-4.05l0.11,0.11l-0.02,0.48c-0.01,0.29,0.21,0.52,0.5,0.53c0.01,0,0.01,0,0.02,0" &
 "c0.28,0,0.51-0.22,0.52-0.5l0.08-2.38C21.58,0.39,21.53,0.25,21.43,0.15z M22.62,17.16H22.1V7.37c0-0.62-0.5-1.12-1.12-1.12h-1.65" &
 "c-0.62,0-1.12,0.5-1.12,1.12v9.79h-1.48v-6.22c0-0.62-0.5-1.12-1.12-1.12h-1.65c-0.62,0-1.12,0.5-1.12,1.12v6.22h-1.48V7.63" &
 "c0-0.62-0.5-1.12-1.12-1.12H8.63c-0.62,0-1.12,0.5-1.12,1.12v9.53H6.04v-3.17c0-0.62-0.5-1.12-1.12-1.12H3.27" &
 "c-0.62,0-1.12,0.5-1.12,1.12v3.17H0.52C0.23,17.16,0,17.39,0,17.68s0.23,0.52,0.52,0.52h22.1c0.29,0,0.52-0.23,0.52-0.52" &
 "C23.13,17.39,22.9,17.16,22.62,17.16z"

    Public Shared LogoutIconPath As String = "M8.55,17.1H1.14V1.14h7.41c0.31,0,0.57-0.26,0.57-0.57S8.87,0,8.55,0H0.57C0.26,0,0,0.26,0,0.57v17.1" &
"c0,0.31,0.26,0.57,0.57,0.57h7.98c0.31,0,0.57-0.26,0.57-0.57C9.12,17.36,8.87,17.1,8.55,17.1z M18.08,8.72l-3.93-3.99" &
"c-0.22-0.23-0.58-0.22-0.81,0c-0.22,0.22-0.22,0.59,0,0.81l2.96,3.01H4.56c-0.31,0-0.57,0.26-0.57,0.58c0,0.32,0.26,0.58,0.57,0.58" &
"H16.3l-2.96,3.01c-0.22,0.23-0.22,0.59,0,0.81c0.22,0.23,0.58,0.23,0.81,0l3.93-3.99C18.3,9.32,18.3,8.95,18.08,8.72z"
End Class
