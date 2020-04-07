Imports SAPBusinessObjects.WPF.Viewer
Public Class ReportWindow
    Public Property Viewer As CrystalReportsViewer
        Get
            Return CrystalReportsViewer
        End Get
        Set(ByVal value As CrystalReportsViewer)
            CrystalReportsViewer = value
        End Set
    End Property
End Class
