Imports System.Collections.Generic
Imports AgileMiniProject_PersonalWebsite.PersonalWebsite
Imports NUnit.Framework

Public Class AdminViewModel

    Public userInfo As UserInfo

    Public activeStylesheet As Style

    Public styleSheets As New List(Of Style)

    Public profilePhotos As New List(Of Photo)

    Sub New()
        Me.styleSheets = New List(Of Style)
        Me.profilePhotos = New List(Of Photo)
    End Sub

End Class
