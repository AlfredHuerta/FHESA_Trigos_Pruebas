Public Class SubItem
    Private sDescription As String
    Private ItmData As Object

    Public Sub New(ByVal pDescription As String, ByVal pItemData As Object)
        sDescription = pDescription
        ItmData = pItemData
    End Sub

    Public Property Description() As String
        Get
            Return sDescription
        End Get
        Set(svalue As String)
            sDescription = svalue
        End Set
    End Property

    Public Property ItemData() As Object
        Get
            Return ItmData
        End Get
        Set(ovalue As Object)
            ItmData = ovalue
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return sDescription
    End Function
End Class
