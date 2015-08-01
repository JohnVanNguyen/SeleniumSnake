Public Class Fruit

    Private _index = 0
    Public Property index()
        Get
            Return _index
        End Get
        Set(value)
            _index = value
        End Set
    End Property

    Public Sub New(p_index As Integer)
        index = p_index
    End Sub
End Class
