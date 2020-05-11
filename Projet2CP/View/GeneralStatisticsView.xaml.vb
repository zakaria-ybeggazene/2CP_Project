Imports System.IO
Imports Microsoft.Win32

Public Class GeneralStatisticsView


    Private Sub comboBox_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim list As New List(Of String)
        list.Add("Niveau")
        list.Add("TRC1")
        list.Add("TRC2")
        list.Add("SI1")
        list.Add("SIQ1")
        list.Add("SI2")
        list.Add("SIQ2")
        list.Add("SI3")
        list.Add("SIQ3")
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

    Private Sub SaveToPng(ByVal visual As FrameworkElement, ByVal addHeight As Integer, ByVal addWidth As Integer)
        Dim encoder As New PngBitmapEncoder()
        Util.EncodeVisual(visual, encoder, addHeight, addWidth)
    End Sub

    Private Sub BouttonBac_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles BouttonBac.Click
        Mouse.OverrideCursor = Cursors.Wait
        SaveToPng(PieChart1, 70, 0)
        Mouse.OverrideCursor = Nothing
    End Sub

    Private Sub BouttonNombreEtudiant_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles BouttonNombreEtudiant.Click
        Mouse.OverrideCursor = Cursors.Wait
        SaveToPng(chart, 70, 350)
        Mouse.OverrideCursor = Nothing
    End Sub

    Private Sub BouttonReussiteEchec_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles BouttonReussiteEchec.Click
        Mouse.OverrideCursor = Cursors.Wait
        SaveToPng(chart1, 70, 250)
        Mouse.OverrideCursor = Nothing
    End Sub
End Class
