
Partial Class ctl_LandInformation
    Inherits System.Web.UI.UserControl

    Property IsRevyear() As Integer
        Get
            Return Me.lblrevyear.Text
        End Get
        Set(ByVal value As Integer)
            lblrevyear.Text = value
        End Set
    End Property
    Property IsDistrictCode() As Integer
        Get
            Return Me.lbldistrict.Text
        End Get
        Set(ByVal value As Integer)
            lbldistrict.Text = value
        End Set
    End Property
    Property Isbarangaycode() As Integer
        Get
            Return Me.lblbcd.Text
        End Get
        Set(ByVal value As Integer)
            lblbcd.Text = value
        End Set
    End Property
    Property Ispin() As String
        Get
            Return Me.lblpin.Text
        End Get
        Set(ByVal value As String)
            lblpin.Text = value
        End Set
    End Property
    Property Istatus() As String
        Get
            Return Me.lblstatus.Text
        End Get
        Set(ByVal value As String)
            lblstatus.Text = value
        End Set
    End Property
    Property IStransaction() As String
        Get
            Return Me.lbltransact.Text
        End Get
        Set(ByVal value As String)
            lbltransact.Text = value
        End Set
    End Property
    Property IstransactionCode() As String
        Get
            Return lbltrcd.Text
        End Get
        Set(ByVal value As String)
            lbltrcd.Text = value
        End Set
    End Property

    Property IsUnit() As String
        Get
            Return Me.lblunit.Text
        End Get
        Set(ByVal value As String)
            Me.lblunit.Text = value
        End Set
    End Property
    Property ISBaseMarketValue() As Decimal
        Get
            Return Me.lblBMV.Text
        End Get
        Set(ByVal value As Decimal)
            lblBMV.Text = value
        End Set
    End Property
    Property IsKind() As String
        Get
            Return Me.lblkind.Text
        End Get
        Set(ByVal value As String)
            lblkind.Text = value
        End Set
    End Property
    Property ISUnitValue() As Decimal
        Get
            Return Me.lblunitvalue.Text
        End Get
        Set(ByVal value As Decimal)
            lblunitvalue.Text = value
        End Set
    End Property
    Property IsTaxable() As String
        Get
            Return Me.lbltaxable.Text
        End Get
        Set(ByVal value As String)
            lbltaxable.Text = value
        End Set
    End Property
    Property ISSortOrder() As Integer
        Get
            Return Me.lblSO.Text
        End Get
        Set(ByVal value As Integer)
            lblSO.Text = value
        End Set
    End Property
    Property Isadjustment() As Decimal
        Get
            Return Me.lbladjustment.Text
        End Get
        Set(ByVal value As Decimal)
            lbladjustment.Text = value
        End Set
    End Property
End Class
