
Partial Class ctl_BuildingInformation

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
    Property IsProjectcost() As Decimal
        Get
            Return Me.lblprojectcost.Text
        End Get
        Set(ByVal value As Decimal)
            lblprojectcost.Text = value
        End Set
    End Property
    Property Isheigth() As String
        Get
            Return Me.lblheight.Text
        End Get
        Set(ByVal value As String)
            lblheight.Text = value
        End Set
    End Property
    Property IsDatestarted() As DateTime
        Get
            Return Me.lblstarted.Text
        End Get
        Set(ByVal value As DateTime)
            lblstarted.Text = value
        End Set
    End Property
    Property ISTotalFlRArea() As Decimal
        Get
            Return Me.lbltotalflor.Text
        End Get
        Set(ByVal value As Decimal)
            lbltotalflor.Text = value
        End Set
    End Property
    Property IsNoOfFlrs() As Integer
        Get
            Return Me.lblfloors.Text
        End Get
        Set(ByVal value As Integer)
            lblfloors.Text = value
        End Set
    End Property
    Property IsDateCompleted() As DateTime
        Get
            Return Me.lblcompleted.Text
        End Get
        Set(ByVal value As DateTime)
            lblcompleted.Text = value
        End Set
    End Property
    Property ISAveAreaPerflr() As Decimal
        Get
            Return Me.lblavearea.Text
        End Get
        Set(ByVal value As Decimal)
            lblavearea.Text = value
        End Set
    End Property
    Property ISopenspace() As String
        Get
            Return Me.lblopenspace.Text
        End Get
        Set(ByVal value As String)
            lblopenspace.Text = value
        End Set
    End Property
    Property IscostPersq() As Decimal
        Get
            Return Me.lblcost.Text
        End Get
        Set(ByVal value As Decimal)
            lblcost.Text = value
        End Set
    End Property
End Class
