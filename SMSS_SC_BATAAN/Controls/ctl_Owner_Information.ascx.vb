
Partial Class ctl_Owner_Information
    Inherits System.Web.UI.UserControl

    Property ISBuildingInformation() As String
        Get
            Return Me.lblbuildingInfo.Text
        End Get
        Set(ByVal value As String)
            lblbuildingInfo.Text = value
        End Set
    End Property
    Property ISBuildingLocation() As String
        Get
            Return Me.lblbuildingLocation.Text
        End Get
        Set(ByVal value As String)
            lblbuildingLocation.Text = value
        End Set
    End Property
    Property ISrptin() As Integer
        Get
            Return Me.lblrptin.Text
        End Get
        Set(ByVal value As Integer)
            lblrptin.Text = value
        End Set
    End Property

    Property ISdeclaredname() As String
        Get
            Return Me.lbldecalrename.Text
        End Get
        Set(ByVal value As String)
            lbldecalrename.Text = value
        End Set
    End Property
    Property ISBeneficialUser() As String
        Get
            Return Me.lblbeneficiary.Text
        End Get
        Set(ByVal value As String)
            lblbeneficiary.Text = value
        End Set
    End Property
    Property IsAdminsitrator() As String
        Get
            Return Me.lbladministrator.Text
        End Get
        Set(ByVal value As String)
            lbladministrator.Text = value
        End Set
    End Property
    Property ISAdminiAddress() As String
        Get
            Return lbladminitratorAddress.Text
        End Get
        Set(ByVal value As String)
            lbladminitratorAddress.Text = value
        End Set
    End Property

End Class
