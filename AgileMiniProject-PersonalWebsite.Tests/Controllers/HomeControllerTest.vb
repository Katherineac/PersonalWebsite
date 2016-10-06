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

    <TestMethod()> Public Sub SubmitContact()
        ' Arrange
        Dim controller As New HomeController()

        ' Act
        Dim postResult As ViewResult = DirectCast(controller.ContactSubmit("testName"), ViewResult)

        ' Assert
        Assert.AreEqual(postResult.ViewBag.Message, "Name: testName")


    End Sub
End Class
End Namespace
