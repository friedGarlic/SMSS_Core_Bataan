
Partial Class ctl_EquipmentInformation
    Inherits System.Web.UI.UserControl

    Property IsName() As String
        Get
            Return Me.lblName.Text
        End Get
        Set(ByVal value As String)
            lblName.Text = value
        End Set
    End Property
    Property ISdimenesion() As String
        Get
            Return Me.lblDimesion.Text
        End Get
        Set(ByVal value As String)
            lblDimesion.Text = value
        End Set
    End Property
    Property IsDescription() As String
        Get
            Return Me.lblDescription.Text
        End Get
        Set(ByVal value As String)
            lblDescription.Text = value
        End Set
    End Property

    Property IsAreaCapacity() As String
        Get
            Return Me.lblareacapacity.Text
        End Get
        Set(ByVal value As String)
            lblareacapacity.Text = value
        End Set
    End Property
    Property IsPowerInput() As String
        Get
            Return Me.lblpowerinput.Text
        End Get
        Set(ByVal value As String)
            lblpowerinput.Text = value
        End Set
    End Property
    Property Ismodel() As String
        Get
            Return Me.lblmodel.Text

        End Get
        Set(ByVal value As String)
            lblmodel.Text = value
        End Set
    End Property

    Property IsSpecification1() As String
        Get
            Return Me.lblequipmentscep1.Text
        End Get
        Set(ByVal value As String)
            lblequipmentscep1.Text = value
        End Set
    End Property
    Property IsSpecification2() As String
        Get
            Return Me.lblequipmentscep2.Text
        End Get
        Set(ByVal value As String)
            lblequipmentscep2.Text = value
        End Set
    End Property


End Class
