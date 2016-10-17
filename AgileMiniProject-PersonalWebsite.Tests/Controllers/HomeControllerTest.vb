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

        <TestMethod()> Public Sub ContactSubmitInvalidEmail()
            ' Arrange
            Dim controller As New HomeController()

            ' Act: Invalid Email
            Dim postResult As ViewResult = DirectCast(controller.ContactSubmit("testName", "test@test.", "testMessage"), ViewResult)

            ' Assert
            Assert.AreEqual(postResult.ViewBag.Message, "Sorry but you entered an invalid email address, please try again!")


        End Sub


        <TestMethod()> Public Sub ContactSubmitInvalidName()
            ' Arrange
            Dim controller As New HomeController()

            ' Act: Invalid Name
            Dim postResult As ViewResult = DirectCast(controller.ContactSubmit("", "test@test.com", "testMessage"), ViewResult)

            ' Assert
            Assert.AreEqual(postResult.ViewBag.Message, "Please enter in your name!")


        End Sub

        <TestMethod()> Public Sub ContactSubmitInvalidMessage()
            ' Arrange
            Dim controller As New HomeController()

            ' Act: Invalid Message
            Dim postResult As ViewResult = DirectCast(controller.ContactSubmit("test", "test@test.com", ""), ViewResult)

            ' Assert
            Assert.AreEqual(postResult.ViewBag.Message, "Please enter in a message!")


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
