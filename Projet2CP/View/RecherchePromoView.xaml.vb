Public Class RecherchePromoView

    Private Sub comboBox_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim list As New List(Of String)
        list.Add("Niveau")
        list.Add("1TRC")
        list.Add("2TRC")
        list.Add("3SI")
        list.Add("3SIQ")
        list.Add("4SI")
        list.Add("4SIQ")
        NiveauCB.ItemsSource = list
    End Sub
    Private Sub AnneecomboBox_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim list As New List(Of String)
        list.Add("Année")
        list.Add("1989")
        list.Add("1990")
        list.Add("1991")
        list.Add("1992")
        list.Add("1993")
        list.Add("1994")
        list.Add("1995")
        list.Add("1996")
        list.Add("1997")
        list.Add("1998")
        list.Add("1999")
        list.Add("2000")
        list.Add("2001")
        list.Add("2002")
        list.Add("2003")
        list.Add("2004")
        list.Add("2005")
        list.Add("2006")
        list.Add("2007")
        list.Add("2008")
        list.Add("2009")
        list.Add("2010")
        list.Add("2011")
        AnneeCB.ItemsSource = list
    End Sub
    Private Sub Openbutton_Click(sender As System.Object, e As System.Windows.RoutedEventArgs)

    End Sub
End Class
