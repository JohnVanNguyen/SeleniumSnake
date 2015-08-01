Imports OpenQA.Selenium
Imports System.Collections.ObjectModel

Public Module Map

    Public Sub MapGenerator(size As Integer)
        '   Generates the walls of the map making sure the ceiling
        '   and walls are filled in
        For row As Integer = 0 To (size - 1)
            For col As Integer = 0 To (size - 1)
                If IsWallIndex(row, col, size) = True Then
                    FrameworkMapUpdater(RowColToIndex(row, col, size))
                End If
            Next
        Next
    End Sub

    Private Function IsWallIndex(row As Integer, col As Integer, size As Integer) As Boolean
        '   If on ceiling
        If row = 0 Or row = (size - 1) Then
            Return True
        End If
        '   If on walls
        If col = 0 Or col = (size - 1) Then
            Return True
        End If
        Return False
    End Function

    Public Sub MapUpdator(pixel As ReadOnlyCollection(Of OpenQA.Selenium.IWebElement), index As Integer)
        '   clicks or unclicks a checkbox at a certain index
        pixel.Item(index).Click()
    End Sub

    Public Function RandomSnakeGenerator(size As Integer) As Integer
        '   returns the index of the randomly generated item
        '   If an index is passed in, try to randomly generate without interfering
        '   incoming index
        Dim row, col As Integer
        Dim index
        '   Makes sure the call to Rnd() returns a truly random value
        Randomize()
        Do
            '   Magic randomizer I got online but changed to -1 because
            '   testing it shows good results
            index = CInt(Math.Ceiling(Rnd() * (size * size))) - 1
            '   if index generated is on ceiling or floor
            IndexToRowCol(index, row, col, size)
            '   If the index is on a wall, run the loop again
        Loop While IsWallIndex(row, col, size) = True
        Return index
    End Function

    Public Function RandomFruitGenerator(size As Integer, snake As Snake) As Integer
        '   WARNING, stays in a loop if all checkboxes are filled in by snake
        '   such that a fruit cannot be spawned if a snake is on all area
        '   Make sure to check if snake is at max size before entering

        '   returns the index of the randomly generated item
        '   If an index is passed in, try to randomly generate without interfering
        '   incoming index
        Dim row, col As Integer
        Dim index
        Dim flag As Boolean
        '   Makes sure the call to Rnd() returns a truly random value
        Randomize()
        Do
            '   Magic randomizer I got online but changed to -1 because
            '   testing it shows good results
            index = CInt(Math.Ceiling(Rnd() * (size * size))) - 1

            '   Sees if index already exists on a snake's body
            flag = snake.contains(index)

            '   if it's not on snake body, check to see if it's
            '   on a wall
            If flag = False Then
                IndexToRowCol(index, row, col, size)
                '   checks to see if it is on wall
                flag = IsWallIndex(row, col, size)
            End If
        Loop While flag = True
        Return index
    End Function

    Public Function RowColToIndex(row As Integer, col As Integer, size As Integer) As Integer
        '   Some math to find the 1D index of a theoretical 2D array
        Return (row * size) + col
    End Function

    Public Sub IndexToRowCol(index As Integer, ByRef row As Integer, ByRef col As Integer, size As Integer)
        '   First we assume that index is smaller than size, therefore rows must be on the first row
        '   and column must be what index is
        row = 0
        col = index
        While index > size
            '   Next if index is greater than size, we need to subtract size from index
            '   and add 1 to rows to indicate there are more rows than previously thought
            index -= size
            row += 1
            '   col becomes index. Even if index is greater than size, looping around will fix the issue
            col = index
        End While
    End Sub

End Module