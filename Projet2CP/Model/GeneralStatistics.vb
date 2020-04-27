Public Interface IGeneralStatistics
    Inherits IStatistics

    'Retourne une liste d'objets avec la forme { .nbEtudiants, .nbMasculin, .nbFeminin} ordonnee 
    'telle que chaque element de la liste represente une annee (ex. 1989 equivaut a l'element 0 dans la liste)
    Function nombreEtudiantsGeneral() As List(Of Object)

    'Retourne une liste d'objets avec la forme {.nbReussite, .nbEchec} pour un niveau donne, ordonnee 
    'telle que chaque element de la liste represente une annee (ex. 1989 equivaut a l'element 0 dans la liste)
    Function nombreReussiteGeneral(ByVal niv As Niveau) As List(Of Object)

    'Retourne un Dictionnaire avec la forme (SerieBac, Nombre de nouveaux etudiants) pour une annee donnee
    'sous reserve que l'annee soit sur deux caracteres
    Function distributionBacheliers(ByVal annee As String) As Dictionary(Of String, Integer)
End Interface

Public Class GeneralStatistics
    Implements IGeneralStatistics

    Public Function distributionBacheliers(ByVal annee As String) As System.Collections.Generic.Dictionary(Of String, Integer) Implements IGeneralStatistics.distributionBacheliers
        Return Repository.distributionBacheliers(annee)
    End Function

    Public Function nombreEtudiantsGeneral() As System.Collections.Generic.List(Of Object) Implements IGeneralStatistics.nombreEtudiantsGeneral
        Return Repository.nombreEtudiantsGeneral()
    End Function

    Public Function nombreReussiteGeneral(ByVal niv As Niveau) As System.Collections.Generic.List(Of Object) Implements IGeneralStatistics.nombreReussiteGeneral
        Return Repository.nombreReussiteGeneral(niv)
    End Function
End Class
