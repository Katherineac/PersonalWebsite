Imports AgileMiniProject_PersonalWebsite.PersonalWebsite

Public Class ResumeViewModel

    Public userInfo As UserInfo

    Public styleSheet As Style

    Public experience As IList(Of Experience)

    Public education As IList(Of Education)

    Public skill As IList(Of Skill)

    Public volunteer As IList(Of Volunteer)

    Sub New()
        Me.experience = New List(Of Experience)
        Me.education = New List(Of Education)
        Me.skill = New List(Of Skill)
        Me.volunteer = New List(Of Volunteer)
    End Sub

End Class
