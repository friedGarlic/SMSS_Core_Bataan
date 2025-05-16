<%@ WebHandler Language="VB" Class="StockCardInventoryHandler" %>

Imports System
Imports System.Web
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.Shared
Imports CrystalDecisions.ReportSource

Public Class StockCardInventoryHandler : Implements IHttpHandler
    Dim prm As NameValueCollection

    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

    End Sub

    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class