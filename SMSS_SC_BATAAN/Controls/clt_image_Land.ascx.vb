Imports System.Web.UI.WebControls.Image

Partial Class clt_image_Land
    Inherits System.Web.UI.UserControl


    'Property Ismage() As Image
    '    Get
    '        Return Image1
    '    End Get
    '    Set(ByVal value As Image)
    '        Image1 = value
    '    End Set
    'End Property

    Property IsDatetaken() As String
        Get
            Return lbldatetake.Text
        End Get
        Set(ByVal value As String)
            lbldatetake.Text = value
        End Set
    End Property

    Property Islbluploaded() As String
        Get
            Return lblupload.Text
        End Get
        Set(ByVal value As String)
            lblupload.Text = value
        End Set
    End Property

    Property ISposition() As String
        Get
            Return lblposition.Text
        End Get
        Set(ByVal value As String)
            lblposition.Text = value
        End Set
    End Property

End Class
