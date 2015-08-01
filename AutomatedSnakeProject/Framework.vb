Imports OpenQA.Selenium

Public Class Framework
    Dim driver As IWebDriver
    Dim pixel
    Public Sub New(url As String)
        driver = New Firefox.FirefoxDriver()
        driver.Url = url
        pixel = driver.FindElements(By.Name("pixel"))
    End Sub

    Public Sub FrameworkUpdater(index As Integer)
        pixel.Item(index).Click()
    End Sub
End Class
