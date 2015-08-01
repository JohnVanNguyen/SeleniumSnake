Imports OpenQA.Selenium

Module MainInterface

    Sub Main()
        '   Map has to be bigger than a 2 x 2
        '   if not the map will try to generate items
        '   indefinitely
        '   Map will be a square. So total area is size^2
        Dim size = 10

        '   Framework that can be changed to display on other platforms
        FrameworkUrl("c:\users\john\documents\visual studio 2013\Projects\Snake_Project\AutomatedSnakeProject\Map.html")


        '   Generate the walls of the map
        Map.MapGenerator(size)

        '   Generate random index for snake
        '   size-2 because we want to not generate
        '   on a wall
        Dim snakeHead = Map.RandomSnakeGenerator(size)
        Dim snake As New Snake(snakeHead)
        FrameworkMapUpdater(snakeHead)

        '   Generate random index for fruit taking snake into account
        '   size-2 because we want to not generate
        '   on a wall
        Dim fruitIndex = Map.RandomFruitGenerator(size, snake)
        Dim fruit As New Fruit(fruitIndex)
        FrameworkMapUpdater(fruitIndex)





        Dim input
        Do
            input = Console.ReadKey().KeyChar

            If input = "a"c Then
                snakeHead = snakeHead - 1
            ElseIf input = "w"c Then
                snakeHead = snakeHead - size
            ElseIf input = "d"c Then
                snakeHead = snakeHead + 1
            ElseIf input = "s"c Then
                snakeHead = snakeHead + size
            End If

            If snakeHead = fruitIndex Then

                '   Here we check if the snake's body engulfs the entire
                '   playable map, therefore deciding if the game is won
                '   or more fruit(s) can be spawned
                '   I added the -1 because the snake is about to add one
                '   to its size which would then make it completely
                '   take over the entire area, but without the -1
                '   a fruit will try to be generated indefinitely
                If snake.size >= (((size - 1) * (size - 1)) - 1) Then
                    '   Exit the do while loop
                    Exit Do
                End If

                '   If there is still space for fruit to spawn and
                '   since the snake reaches a fruit, spawn another fruit
                fruitIndex = Map.RandomFruitGenerator(size, snake)
                fruit.index = fruitIndex
                FrameworkMapUpdater(fruitIndex)

                '   Then allow the snake to move one space foward
                '   but also let the tail grow
                snake.AddLength(snakeHead)
                '   Do not update the framework because that would
                '   set the space to unchecked, which would cause
                '   a visual glitch with the snake
                'Framework.FrameworkMapUpdater(snakeHead)
            Else
                '   If the snake hasn't reached a fruit yet
                '   keep moving the snake and make sure the
                '   tail keeps up with the head
                FrameworkMapUpdater(snakeHead)
                FrameworkMapUpdater(snake.move(snakeHead))
            End If

        Loop While input <> "q"c


        snake.PrintSnake()
        Console.WriteLine()

        Console.ReadKey()

    End Sub

End Module
