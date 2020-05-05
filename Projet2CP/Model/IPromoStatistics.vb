Public Interface IPromoStatistics
    Inherits IStatistics

    Function getEtudiantDistribution() As List(Of Integer)

    Function getTauxReussite() As Object

    Function getTauxReussiteParSexe() As Object
End Interface
