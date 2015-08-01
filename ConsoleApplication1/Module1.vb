Module Module1

    Sub Main()
        Dim int
        For i As Integer = 1 To 1000
            int = CInt(Math.Ceiling(Rnd() * 4 * 4)) - 1
            Console.Write("[" & int & "]")
            If i Mod 10 = 0 And i > 0 Then
                Console.WriteLine()
            End If
        Next
        Console.ReadKey()
    End Sub

End Module
