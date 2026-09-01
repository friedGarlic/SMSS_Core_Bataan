
Partial Class ctl_LandInformation_encode
    Inherits System.Web.UI.UserControl

    Property IsRevyear() As Integer
        Get
            Return Me.txtRevyer.Text
        End Get
        Set(ByVal value As Integer)
            txtRevyer.Text = value
        End Set
    End Property
    Property IsDistrictCode() As Integer
        Get
            Return Me.txtDistrictcode.Text
        End Get
        Set(ByVal value As Integer)
            txtDistrictcode.Text = value
        End Set
    End Property
    Property Isbarangaycode() As Integer
        Get
            Return Me.txtbrgycode.Text
        End Get
        Set(ByVal value As Integer)
            txtbrgycode.Text = value
        End Set
    End Property
    Property Ispin() As String
        Get
            Return Me.txtPin.Text
        End Get
        Set(ByVal value As String)
            txtPin.Text = value
        End Set
    End Property
    Property Istatus() As String
        Get
            Return Me.txtStat.Text
        End Get
        Set(ByVal value As String)
            txtStat.Text = value
        End Set
    End Property
    Property IStransaction() As String
        Get
            Return Me.txttransaction.Text
        End Get
        Set(ByVal value As String)
            txttransaction.Text = value
        End Set
    End Property
    Property IstransactionCode() As String
        Get
            Return Me.txttransactioncode.Text
        End Get
        Set(ByVal value As String)
            txttransactioncode.Text = value
        End Set
    End Property

    Property IsUnit() As String
        Get
            Return Me.txtUnit.Text
        End Get
        Set(ByVal value As String)
            Me.txtUnit.Text = value
        End Set
    End Property
    Property ISBaseMarketValue() As Decimal
        Get
            Return Me.txtbasemarketvalue.Text
        End Get
        Set(ByVal value As Decimal)
            txtbasemarketvalue.Text = value
        End Set
    End Property
    Property IsKind() As String
        Get
            Return Me.txtkind.Text
        End Get
        Set(ByVal value As String)
            txtkind.Text = value
        End Set
    End Property
    Property ISUnitValue() As Decimal
        Get
            Return Me.txtUnitvalue.Text
        End Get
        Set(ByVal value As Decimal)
            txtUnitvalue.Text = value
        End Set
    End Property
    Property IsTaxable() As String
        Get
            Return Me.txttaxable.Text
        End Get
        Set(ByVal value As String)
            txttaxable.Text = value
        End Set
    End Property
    Property ISSortOrder() As Integer
        Get
            Return Me.txtsortorder.Text
        End Get
        Set(ByVal value As Integer)
            txtsortorder.Text = value
        End Set
    End Property
    Property Isadjustment() As Decimal
        Get
            Return Me.txtadjustment.Text
        End Get
        Set(ByVal value As Decimal)
            txtadjustment.Text = value
        End Set
    End Property
End Class
