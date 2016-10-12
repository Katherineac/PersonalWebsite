Imports System
Imports System.Collections.Generic
Imports System.Text
Imports NUnit
Imports AgileMiniProject_PersonalWebsite
Imports System.Web.Mvc
Imports AgileMiniProject_PersonalWebsite.PersonalWebsite

Namespace PersonalWebsite
    <TestClass()> Public Class HomeControllerTest

        <TestMethod()> Public Sub Index()
            ' Arrange
            Dim controller As New HomeController()

            ' Act
            Dim result As ViewResult = DirectCast(controller.Index(), ViewResult)

            ' Assert
            Assert.IsNotNull(result)
        End Sub


        <TestMethod()> Public Sub Contact()
            ' Arrange
            Dim controller As New HomeController()

            ' Act
            Dim result As ViewResult = DirectCast(controller.Contact(), ViewResult)

            ' Assert
            Assert.IsNotNull(result)
        End Sub

        <TestMethod()> Public Sub ContactSubmit()
            ' Arrange
            Dim controller As New HomeController()

            ' Act
            Dim postResult As ViewResult = DirectCast(controller.ContactSubmit("testName", "testEmail@test.com", "testMessage"), ViewResult)

            ' Assert
            Assert.AreEqual(postResult.ViewBag.Message, "Thank you " + "testName" + ", your email address " + "testEmail@test.com" + " has been forwarded to John Smith with the message: " + "testMessage")


        End Sub

        <TestMethod()> Public Sub GetStylesheet()
            Dim avm As AboutViewModel = New AboutViewModel
            Using db As ApplicationDbContext = New ApplicationDbContext
                Dim result As String = avm.styleSheet.StyleSheetName
                Assert.IsNotNull(result)

                ' StringAssert.Contains(result, "Light Purple")

            End Using




        End Sub
    End Class
End Namespace
