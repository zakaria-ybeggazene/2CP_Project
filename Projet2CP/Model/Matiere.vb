
Public Class Matiere
    Private _codMat, _libeMat As String
    Private _niveau As Niveau
    Private _coef As Integer
    'constructeur
    Public Sub New()

    End Sub

    Public Sub New(ByVal codMat As String, ByVal libeMat As String, ByVal niveau As Niveau, ByVal coef As Integer)
        _codMat = codMat
        _libeMat = libeMat
        _niveau = niveau
        _coef = coef
    End Sub


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
        If CType(obj, Matiere)._codMat.CompareTo(Me._codMat) = 0 Then
            Return True
        Else
            Return False
        End If

    End Function
    Public Overrides Function GetHashCode() As Integer
        Return _codMat.GetHashCode()
    End Function



End Class
