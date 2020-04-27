Public Class ClassementViewModel
    Inherits ViewModelBase

    Public Property Promotion As PromotionParcours
    Public Property ListeEtuds As List(Of EtudiantParcours)

    Public Property EtudiantTab As ICommand

    Sub New(ByVal promotion As PromotionParcours, ByRef addEtudiantView As Action(Of Object))
        Me.Promotion = promotion
        Me.ListeEtuds = promotion.ListeEtudiants
        ListeEtuds.Sort(Function(a, b) b.MoyMax.CompareTo(a.MoyMax))
        EtudiantTab = New RelayCommand(addEtudiantView)
    End Sub
End Class
