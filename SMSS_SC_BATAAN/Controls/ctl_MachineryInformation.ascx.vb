
Partial Class ctl_MachineryInformation
    Inherits System.Web.UI.UserControl

    Property ISbrand() As String
        Get
            Return lblmodel.Text
        End Get
        Set(ByVal value As String)
            lblmodel.Text = value
        End Set
    End Property
    Property IsUnitNo() As String
        Get
            Return lblunit.Text
        End Get
        Set(ByVal value As String)
            lblunit.Text = value
        End Set
    End Property
    Property Istype() As String
        Get
            Return lbltype.Text
        End Get
        Set(ByVal value As String)
            lbltype.Text = value
        End Set
    End Property
    Property Isworkingload() As String
        Get
            Return lblworkingload.Text
        End Get
        Set(ByVal value As String)
            lblworkingload.Text = value
        End Set
    End Property

    Property IsLocation() As String
        Get
            Return lbllocation.Text
        End Get
        Set(ByVal value As String)
            lbllocation.Text = value
        End Set
    End Property
    Property ISratedSpeed() As String
        Get
            Return lblratedspeed.Text
        End Get
        Set(ByVal value As String)
            lblratedspeed.Text = value
        End Set
    End Property
    Property ISNoofPassenger() As String
        Get
            Return lblnopassenger.Text
        End Get
        Set(ByVal value As String)
            lblnopassenger.Text = value
        End Set
    End Property
    Property ISCardimension() As String
        Get
            Return lblcardimesion.Text
        End Get
        Set(ByVal value As String)
            lblcardimesion.Text = value
        End Set
    End Property
    Property Isservicefloor() As String
        Get
            Return lblservicefloor.Text
        End Get
        Set(ByVal value As String)
            lblservicefloor.Text = value
        End Set
    End Property
End Class
