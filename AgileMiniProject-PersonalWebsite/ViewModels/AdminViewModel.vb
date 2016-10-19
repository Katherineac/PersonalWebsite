Imports System.Collections.Generic
Imports AgileMiniProject_PersonalWebsite.PersonalWebsite
Imports NUnit.Framework

Public Class AdminViewModel

    Public userInfo As UserInfo

    Public activeStylesheet As Style

    Public styleSheets As New List(Of Style)

    Public profilePhotos As New List(Of Photo)

    Public experiences As New List(Of Experience)

    Public educations As New List(Of Education)

    Public skills As New List(Of Skill)

    Public projects As New List(Of Project)

    Sub New()
        Me.styleSheets = New List(Of Style)
        Me.profilePhotos = New List(Of Photo)
        Me.experiences = New List(Of Experience)
        Me.educations = New List(Of Education)
        Me.skills = New List(Of Skill)
        Me.projects = New List(Of Project)
    End Sub

End Class
