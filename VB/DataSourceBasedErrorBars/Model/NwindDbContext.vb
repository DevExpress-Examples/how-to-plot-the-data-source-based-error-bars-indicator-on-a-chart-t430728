Imports System.Linq
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity
Imports System

Namespace ErrorBarsWin

    Partial Public Class NwindDbContext
        Inherits DbContext

        Public Sub New()
            MyBase.New("name=NwindDbContext")
        End Sub

        Public Overridable Property Categories() As DbSet(Of Category)
        Public Overridable Property Products() As DbSet(Of Product)

        Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
            modelBuilder.Entity(Of Product)().Property(Function(e) e.UnitPrice).HasPrecision(10, 4)

            modelBuilder.Entity(Of Product)().Property(Function(e) e.EAN13).IsUnicode(False)
        End Sub
    End Class
End Namespace
