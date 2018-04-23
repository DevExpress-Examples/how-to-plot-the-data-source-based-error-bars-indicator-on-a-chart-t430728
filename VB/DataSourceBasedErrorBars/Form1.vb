Imports DevExpress.XtraCharts
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows.Forms

Namespace ErrorBarsWin
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub
        Public Class AggregatedCategoryData
            Public Property CategoryName() As Object
            Public Property MeanProductPrice() As Double
            Public Property MaxProductPrice() As Double
            Public Property MinProductPrice() As Double
        End Class
        Private Function GetData() As List(Of AggregatedCategoryData)
            Dim result As New List(Of AggregatedCategoryData)()
            Using context = New NwindDbContext()
                For Each category As Category In context.Categories
                    Dim productUnitPrices = category.Products.Select(Function(p) p.UnitPrice)
                    result.Add(New AggregatedCategoryData With {.CategoryName = category.CategoryName, .MeanProductPrice = Convert.ToDouble(productUnitPrices.Aggregate(Function(p1, p2) p1 + p2) / category.Products.Count), .MinProductPrice = Convert.ToDouble(productUnitPrices.Min()), .MaxProductPrice = Convert.ToDouble(productUnitPrices.Max())})
                Next category
            End Using
            Return result
        End Function
        Private ReadOnly Property series() As Series
            Get
                Return chartControl.Series(0)
            End Get
        End Property
        #Region "#DateSourceBasedErrorBars"
        Private Sub FormOnLoad(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            Dim view As New PointSeriesView()
            view.Indicators.Add(New DataSourceBasedErrorBars With {.ShowInLegend = True, .Name = "Prices Range", .NegativeErrorDataMember = "MinProductPrice", .PositiveErrorDataMember = "MaxProductPrice"})
            series.View = view
            series.ArgumentDataMember = "CategoryName"
            series.ValueDataMembers.AddRange(New String() { "MeanProductPrice" })
            series.DataSource = GetData()
        End Sub
        #End Region ' #DateSourceBasedErrorBars
    End Class
End Namespace
