Public Class Snake
    Dim body As Queue(Of Integer)
    Public Sub New(index As Integer)
        'body(size * size) = New Integer()
        body = New Queue(Of Integer)
        AddLength(index)
    End Sub

    Public Function Len() As Integer
        Return body.Count
    End Function

    Public Sub AddLength(index As Integer)
        body.Enqueue(index)
    End Sub

    Public Function move(index As Integer) As Integer
        'index is where the snake should go next
        body.Enqueue(index)
        Return body.Dequeue
    End Function

    Public Sub PrintSnake()
        For i As Integer = 0 To Len() - 1
            Console.WriteLine(body(i))
        Next
    End Sub
End Class
