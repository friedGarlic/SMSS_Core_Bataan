
Partial Class ctl_Machinery_Details
    Inherits System.Web.UI.UserControl

    Property IsRemarks() As String
        Get
            Return lbldeascriptionRemarks.Text
        End Get
        Set(ByVal value As String)
            lbldeascriptionRemarks.Text = value
        End Set
    End Property
    Property Ismechpermitno() As String
        Get
            Return lblpermitno.Text
        End Get
        Set(ByVal value As String)
            lblpermitno.Text = value
        End Set
    End Property
    Property Iscertificate() As String
        Get
            Return lblcertificate.Text
        End Get
        Set(ByVal value As String)
            lblcertificate.Text = value
        End Set
    End Property
    Property IsDateIssunace() As String
        Get
            Return lblinsuannce.Text
        End Get
        Set(ByVal value As String)
            lblinsuannce.Text = value
        End Set
    End Property

    Property Isexpirationdate() As String
        Get
            Return lblexpirationdate.Text
        End Get
        Set(ByVal value As String)
            lblexpirationdate.Text = value
        End Set
    End Property
    Property Isinspecteddate() As String
        Get
            Return lbldateinspected.Text
        End Get
        Set(ByVal value As String)
            lbldateinspected.Text = value
        End Set
    End Property
    Property IsinspectedBy() As String
        Get
            Return lbinspected.Text
        End Get
        Set(ByVal value As String)
            lbinspected.Text = value
        End Set
    End Property
End Class
