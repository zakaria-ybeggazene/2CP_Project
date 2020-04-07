Public Class Note
    Private _noju, _nosy, _nora As Decimal
    Private _ratrapage As Integer
    Private _eliminatoire As Boolean

    Public Property Noju As Decimal
        Get
            Return _noju
        End Get
        Set(ByVal value As Decimal)
            _noju = value
        End Set
    End Property
    Public Property Nosy As Decimal
        Get
            Return _nosy
        End Get
        Set(ByVal value As Decimal)
            _nosy = value
        End Set
    End Property
    Public Property Nora As Decimal
        Get
            Return _nosy
        End Get
        Set(ByVal value As Decimal)
            _nosy = value
        End Set
    End Property
    Public Property Ratrapage As Integer
        Get
            Return _ratrapage
        End Get
        Set(ByVal value As Integer)
            _ratrapage = value
        End Set
    End Property
    Public Property Eliminatoire As Boolean
        Get
            Return _eliminatoire
        End Get
        Set(ByVal value As Boolean)
            _eliminatoire = value
        End Set
    End Property

End Class
