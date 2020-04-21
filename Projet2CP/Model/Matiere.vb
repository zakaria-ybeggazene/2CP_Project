
Public Class Matiere
    Implements IMatiereStatistics

    Private _codMat, _libeMat As String
    Private _niveau As Niveau
    Private _coef As Integer

    'ensemble des matieres chargé a chaque lancement du programme afin d'eviter les requetes a la base de donnée
    Private Shared _matieres As List(Of Matiere)

    Public Shared Sub initialiserMatieres(ByVal matieres As List(Of Matiere))
        _matieres = matieres
    End Sub

    Public Shared Function getMatiere(ByVal codeMat As String, ByVal niveau As Niveau) As Matiere

        Dim result As Matiere = New Matiere With {.CodMat = codeMat, .NiveauM = niveau}
        Dim trouve As Boolean = False
        For Each m As Matiere In _matieres
            If m.Equals(result) Then
                result = m
                trouve = True
                Exit For
            End If
        Next
        If trouve Then
            Return result
        Else
            Return Nothing
        End If
    End Function

    Shared ReadOnly Property Matieres As List(Of Matiere)
        Get
            Return _matieres
        End Get
    End Property


    'Properties
    Public Property CodMat() As String
        Get
            Return _codMat
        End Get
        Set(ByVal value As String)
            Me._codMat = value
        End Set
    End Property

    Public Property LibeMat() As String
        Get
            Return _libeMat
        End Get
        Set(ByVal value As String)
            Me._libeMat = value
        End Set
    End Property

    Public Property NiveauM() As Niveau
        Get
            Return _niveau
        End Get
        Set(ByVal value As Niveau)
            Me._niveau = value
        End Set
    End Property

    Public Property Coef() As Integer
        Get
            Return _coef
        End Get
        Set(ByVal value As Integer)
            Me._coef = value
        End Set
    End Property

    Public Overrides Function Equals(ByVal obj As Object) As Boolean
        If CType(obj, Matiere)._codMat.CompareTo(Me._codMat) = 0 And CType(obj, Matiere).NiveauM = _niveau Then
            Return True
        Else
            Return False
        End If

    End Function
    Public Overrides Function GetHashCode() As Integer
        Return Util.GetHash(_codMat.GetHashCode() & _niveau.ToString.GetHashCode()).GetHashCode()
    End Function

    Public Function moyennes() As List(Of Double) Implements IMatiereStatistics.MoyennesMatiere
        Return Repository.moyennesMatiere(Me)
    End Function

    Public Function tauxReussite() As List(Of Object) Implements IMatiereStatistics.tauxReussiteMatiere
        Return Repository.tauxReussiteMatiere(Me)
    End Function

End Class
