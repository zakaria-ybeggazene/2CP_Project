Imports System.Collections.ObjectModel

Public Class RechercheEtudiantViewModel
    Inherits WorkspaceViewModel

    Private _matricule, _nom, _prenom, _nomA, _prenomA, _dateNais, _lieuNais, _annee, _sexe, _wilayaNais As String
    Private _resultats As List(Of Etudiant)
    Private v As RechercheEtudiantView

    Public Sub New(ByVal displayName As String, ByRef addEtudiantView As Action(Of Object))
        MyBase.New(displayName)
        v = New RechercheEtudiant()
       

    End Sub

    Private v As RechercheEtudiant

   

    Public Property data
        Get
            Return v.data
        End Get
        Set(ByVal value)
            v.data = value
            OnPropertyChanged("value")
        End Set
    End Property

   
End Class
