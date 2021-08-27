<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128575244/16.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T430728)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/DataSourceBasedErrorBars/Form1.cs) (VB: [Form1.vb](./VB/DataSourceBasedErrorBars/Form1.vb))
<!-- default file list end -->
# How to: Plot the Data Source Based Error Bars indicator on a chart


This example demonstrates how to plot Data Source Based Error Bars on a chart.


<h3>Description</h3>

<p>To do this, add a&nbsp;<a href="https://documentation.devexpress.com/#CoreLibraries/clsDevExpressXtraChartsDataSourceBasedErrorBarstopic">DataSourceBasedErrorBars</a>&nbsp;object to the series view's&nbsp;<a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressXtraChartsXYDiagram2DSeriesViewBase_Indicatorstopic">XYDiagram2DSeriesViewBase.Indicators</a>&nbsp;collection. Then,&nbsp;specify&nbsp;which data members&nbsp;store negative and positive error values using the&nbsp;<a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressXtraChartsDataSourceBasedErrorBars_NegativeErrorDataMembertopic">DataSourceBasedErrorBars.NegativeErrorDataMember</a>&nbsp;and&nbsp;<a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressXtraChartsDataSourceBasedErrorBars_PositiveErrorDataMembertopic">DataSourceBasedErrorBars.PositiveErrorDataMember</a>&nbsp;properties.</p>

<br/>


