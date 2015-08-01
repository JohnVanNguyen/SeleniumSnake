Imports OpenQA.Selenium

Module MainInterface

    Sub Main()
        'Map will be a square. So total area is size^2
        Dim size = 10


        Dim framework As New Framework("C:\Users\John\Documents\Visual Studio 2013\Projects\Snake_Project\Snake_Project\Map.html")

        Map.MapGenerator(framework, size)

        'Make random
        Dim snakeHead = 55

        Dim snake As New Snake(snakeHead)

        Dim input



        framework.FrameworkUpdater(snakeHead)

        Do
            input = Console.ReadKey().KeyChar

            If input = "a"c Then
                snakeHead = snakeHead - 1
                framework.FrameworkUpdater(snakeHead)
                framework.FrameworkUpdater(snake.move(snakeHead))
            ElseIf input = "w"c Then
                snakeHead = snakeHead - size
                framework.FrameworkUpdater(snakeHead)
                framework.FrameworkUpdater(snake.move(snakeHead))
            ElseIf input = "d"c Then
                snakeHead = snakeHead + 1
                framework.FrameworkUpdater(snakeHead)
                framework.FrameworkUpdater(snake.move(snakeHead))
            ElseIf input = "s"c Then
                snakeHead = snakeHead + size
                framework.FrameworkUpdater(snakeHead)
                framework.FrameworkUpdater(snake.move(snakeHead))
            End If

            If input = "1"c Then
                snakeHead = snakeHead - 1
                snake.AddLength(snakeHead)
                framework.FrameworkUpdater(snakeHead)
            ElseIf input = "5"c Then
                snakeHead = snakeHead - size
                snake.AddLength(snakeHead)
                framework.FrameworkUpdater(snakeHead)
            ElseIf input = "3"c Then
                snakeHead = snakeHead + 1
                snake.AddLength(snakeHead)
                framework.FrameworkUpdater(snakeHead)
            ElseIf input = "2"c Then
                snakeHead = snakeHead + size
                snake.AddLength(snakeHead)
                framework.FrameworkUpdater(snakeHead)
            End If


        Loop While input <> "q"c



        snake.PrintSnake()
        Console.WriteLine()

        snake.AddLength(6)

        snake.PrintSnake()
        Console.WriteLine()

        snake.move(7)

        snake.PrintSnake()
        Console.WriteLine()

        snake.AddLength(8)

        snake.PrintSnake()
        Console.WriteLine()

        Console.ReadKey()

    End Sub

End Module
