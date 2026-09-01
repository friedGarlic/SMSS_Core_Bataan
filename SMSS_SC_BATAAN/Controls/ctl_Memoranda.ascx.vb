
Partial Class ctl_Memoranda
    Inherits System.Web.UI.UserControl

    Property Ismemoranda() As String
        Get
            Return Me.lblMemoranda.Text
        End Get
        Set(ByVal value As String)
            lblMemoranda.Text = value
        End Set
    End Property
    Property Isremarks() As String
        Get
            Return Me.lblremarks.Text
        End Get
        Set(ByVal value As String)
            lblremarks.Text = value
        End Set
    End Property
    Property ISAssessperson() As String
        Get
            Return Me.lblpersonassesment.Text
        End Get
        Set(ByVal value As String)
            lblpersonassesment.Text = value
        End Set
    End Property
    Property ISDateAssess() As String
        Get
            Return Me.lbldateassess.Text
        End Get
        Set(ByVal value As String)
            lbldateassess.Text = value
        End Set
    End Property
    Property ISdateencoded() As String
        Get
            Return Me.lblencode.Text
        End Get
        Set(ByVal value As String)
            lblencode.Text = value
        End Set
    End Property
    Property IsencodedBy() As String
        Get
            Return Me.lblencodedby.Text
        End Get
        Set(ByVal value As String)
            lblencodedby.Text = value
        End Set
    End Property
    Property ISDateupdated() As String
        Get
            Return Me.lblupdated.Text
        End Get
        Set(ByVal value As String)
            lblupdated.Text = value
        End Set
    End Property
    Property IsupdatedBy() As String
        Get
            Return Me.lblupdateby.Text
        End Get
        Set(ByVal value As String)
            lblupdateby.Text = value
        End Set
    End Property
End Class
