Imports OpenQA.Selenium
Imports System.Collections.ObjectModel

Public Module Map

    Public Sub MapGenerator(framework As Framework, size As Integer)
        '   Generates the walls of the map making sure the ceiling
        '   and walls are filled in
        Dim flag As Boolean

        For row As Integer = 0 To (size - 1)
            For col As Integer = 0 To (size - 1)
                flag = False
                '   If on ceiling, pixel must be checked
                If row = 0 Or row = (size - 1) Then
                    flag = True
                End If
                '   If on walls, pixel must be checked
                If col = 0 Or col = (size - 1) Then
                    flag = True
                End If
                If flag = True Then
                    framework.FrameworkUpdater(RowColToIndex(row, col, size))
                End If
            Next
        Next
    End Sub

    Public Sub MapUpdator(pixel As ReadOnlyCollection(Of OpenQA.Selenium.IWebElement), index As Integer)
        'clicks or unclicks a checkbox at a certain index
        pixel.Item(index).Click()
    End Sub

    Public Function FruitGenerator() As Integer
        '   returns the index of the fruit
        '   also makes sure not to generate fruit on top of snake
        Return 0
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

    Public Function IndexOfInsideWalls(index As Integer, size As Integer) As Integer
        '   Move one down from ceiling and one over from left wall
        Return index + size + 1
    End Function

End Module