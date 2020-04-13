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

    Public Shared Function dbNullToString(ByVal o As Object) As String
        If IsDBNull(o) Then
            Return ""
        Else
            Return o
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

        Using hasher As MD5 = MD5.Create()    ' create hash object

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
