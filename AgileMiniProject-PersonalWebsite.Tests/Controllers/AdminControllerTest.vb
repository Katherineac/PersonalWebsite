Imports System.Net.Mime.MediaTypeNames
Imports System.Text
Imports System.Web
Imports System.Web.Mvc
Imports AgileMiniProject_PersonalWebsite.PersonalWebsite
Imports NUnit.Framework

Namespace PersonalWebsite

    <TestClass()>
    Public Class AdminControllerTest

        <TestMethod()> Public Sub AdminTest()
            ' Arrange
            Dim controller As New AdminController()

            ' Act
            Dim result As ActionResult = DirectCast(controller.Admin(), ActionResult)

            ' Assert
            Assert.IsNotNull(result)
        End Sub

        <TestMethod()> Public Sub UploadPhotoTest()
            ' Arrange
            Dim controller As New AdminController()

            ' Act
            'Dim result As ViewResult = DirectCast(controller.UploadPhoto(), ViewResult)

            ' Assert
            'Assert.IsNotNull(result)
        End Sub

        <TestMethod()> Public Sub SelectProfilePhotoTest()
            ' Arrange
            Dim controller As New AdminController()

            ' Act
            Dim result As ActionResult = DirectCast(controller.SelectProfilePhoto(New Photo), ActionResult)

            ' Assert
            Assert.IsNotNull(result)
        End Sub

        <TestMethod()> Public Sub UpdateUserInfoTest()
            ' Arrange
            Dim controller As New AdminController()

            ' Act
            Dim result As ViewResult = DirectCast(controller.UpdateUserInfo(New UserInfo), ActionResult)

            ' Assert
            Assert.IsNotNull(result)
        End Sub

        <TestMethod()> Public Sub SelectStyleSheetTest()
            ' Arrange
            Dim controller As New AdminController()

            ' Act
            Dim result As ViewResult = DirectCast(controller.SelectStyleSheet(New Style), ViewResult)

            ' Assert
            Assert.IsNotNull(result)
        End Sub

        <TestMethod()> Public Sub GetImageTest()
            ' Arrange
            Dim controller As New AdminController()

            ' Act
            Dim result As FileResult = DirectCast(controller.GetImage(), FileResult)

            ' Assert
            Assert.IsNotNull(result)
        End Sub

        <TestMethod()> Public Sub GetImageByIDTest()
            ' Arrange
            Dim controller As New AdminController()

            ' Act
            Dim result As FileResult = DirectCast(controller.GetImageByID(New Photo), FileResult)

            ' Assert
            Assert.IsNotNull(result)
        End Sub

    End Class

End Namespace
