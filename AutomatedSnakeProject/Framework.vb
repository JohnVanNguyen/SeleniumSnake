Imports OpenQA.Selenium

Public Module Framework
    Dim driver As New Firefox.FirefoxDriver()
    Dim pixel
    Dim score As IWebElement
    Dim direction As IWebElement

    Public Sub FrameworkUrl(url As String)
        driver.Url = url
        pixel = driver.FindElements(By.Name("pixel"))
        score = driver.FindElement(By.Name("score"))
        direction = driver.FindElement(By.Name("direc"))
    End Sub

    Public Sub FrameworkMapUpdater(index As Integer)
        pixel.Item(index).Click()
    End Sub

    Public Sub FrameworkScoreUpdater(p_score As Integer)
        score.Clear()
        score.SendKeys(p_score)
    End Sub

    Public Sub FrameworkDirectionUpdater(p_direction As String)
        direction.Clear()
        direction.SendKeys(p_direction)
    End Sub
End Module
