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
            Case "CS3"
                niv = Projet2CP.Niveau.CS3
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
End Class
