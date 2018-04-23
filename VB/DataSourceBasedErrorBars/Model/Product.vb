Imports System.Data.Entity.Spatial
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.ComponentModel.DataAnnotations
Imports System.Collections.Generic
Imports System

Namespace ErrorBarsWin

    Partial Public Class Product
        Public Property ProductID() As Integer

        <Required, StringLength(40)> _
        Public Property ProductName() As String

        Public Property SupplierID() As Integer?

        Public Property CategoryID() As Integer?

        <StringLength(20)> _
        Public Property QuantityPerUnit() As String

        <Column(TypeName := "smallmoney")> _
        Public Property UnitPrice() As Decimal?

        Public Property UnitsInStock() As Short?

        Public Property UnitsOnOrder() As Short?

        Public Property ReorderLevel() As Short?

        Public Property Discontinued() As Boolean

        <Column(TypeName := "text")> _
        Public Property EAN13() As String

        Public Overridable Property Category() As Category
    End Class
End Namespace
