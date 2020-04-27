Public Class PromotionViewModel
    Inherits ViewModelBase

    Public Property Promotion As PromotionAnnee
    Public Property ListeEtuds As List(Of EtudiantAnnee)
    Public Property ListeMatieres As Dictionary(Of Matiere, Decimal)

    Public Property EtudiantTab As ICommand

    Sub New(ByVal promotion As PromotionAnnee, ByRef addEtudiantView As Action(Of Object))
        Me.Promotion = promotion
        Me.ListeEtuds = promotion.ListeEtudiants
        ListeMatieres = promotion.ListeMatiere
        EtudiantTab = New RelayCommand(addEtudiantView)
    End Sub
End Class
