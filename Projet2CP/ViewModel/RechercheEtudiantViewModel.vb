Imports System.Collections.ObjectModel

Public Class RechercheEtudiantViewModel
    Inherits WorkspaceViewModel

    Public Sub New(ByVal displayName As String)
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
