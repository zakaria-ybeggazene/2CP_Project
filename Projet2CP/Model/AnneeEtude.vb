
Public Class AnneeEtude
    Private _annee As String
    Private _groupe, _mention, _rang, _nbrEtudiants As Integer
    Private _niveau As Niveau
    Private _section, _adm As Char
    Private _moyenneJ As Decimal
    Private _notes As Dictionary(Of Matiere, Note)
    Public Class Rattrapage
        Private _moyenneR As Decimal
        Private _mentionR, _elim As Integer


        'Propreties
        Public Property MoyenneR() As Decimal
            Get
                Return _moyenneR
            End Get
            Set(ByVal value As Decimal)
                Me._moyenneR = value
            End Set
        End Property
        Public Property MentionR() As Integer
            Get
                Return _mentionR
            End Get
            Set(ByVal value As Integer)
                Me._mentionR = value
            End Set
        End Property
        Public Property Elim() As Integer
            Get
                Return _elim
            End Get
            Set(ByVal value As Integer)
                Me._elim = value
            End Set
        End Property
    End Class
    Private _rattrapage As Rattrapage

    'Constructeur
    Public Sub New()

    End Sub

    Public Sub New(ByVal annee As Integer, ByVal groupe As Integer, ByVal mention As Integer, ByVal niveau As Niveau, ByVal section As Char, ByVal adm As Char, ByVal moyenneJ As Decimal, ByVal rattrapage As Rattrapage)
        _annee = annee
        _groupe = groupe
        _mention = mention
        _niveau = niveau
        _section = section
        _adm = adm
        _moyenneJ = moyenneJ
        _rattrapage = rattrapage
    End Sub



    'Properties
    Public Property Annee() As String
        Get
            Return _annee
        End Get
        Set(ByVal value As String)
            Me._annee = value
        End Set
    End Property

    Public Property Groupe() As Integer
        Get
            Return _groupe
        End Get
        Set(ByVal value As Integer)
            Me._groupe = value
        End Set
    End Property

    Public Property Mention() As Integer
        Get
            Return _mention
        End Get
        Set(ByVal value As Integer)
            Me._mention = value
        End Set
    End Property

    Public Property Niveau() As Niveau
        Get
            Return _niveau
        End Get
        Set(ByVal value As Niveau)
            Me._niveau = value
        End Set
    End Property

    Public Property Section() As Char
        Get
            Return _section
        End Get
        Set(ByVal value As Char)
            Me._section = value
        End Set
    End Property

    Public Property Adm() As Char
        Get
            Return _adm
        End Get
        Set(ByVal value As Char)
            Me._adm = value
        End Set
    End Property

    Public Property MoyenneJ() As Decimal
        Get
            Return _moyenneJ
        End Get
        Set(ByVal value As Decimal)
            Me._moyenneJ = value
        End Set
    End Property
    Public Property Notes() As Dictionary(Of Matiere, Note)
        Get
            Return _notes
        End Get
        Set(ByVal value As Dictionary(Of Matiere, Note))
            Me._notes = value
        End Set
    End Property

    Public Property Rattrap() As Rattrapage
        Get
            Return _rattrapage
        End Get
        Set(ByVal value As Rattrapage)
            Me._rattrapage = value
        End Set
    End Property

    Public Property Rang() As Integer
        Get
            Return _rang
        End Get
        Set(ByVal value As Integer)
            Me._rang = value
        End Set
    End Property
    Public Property NbrEtudiants() As Integer
        Get
            Return _nbrEtudiants
        End Get
        Set(ByVal value As Integer)
            Me._nbrEtudiants = value
        End Set
    End Property

End Class
