Imports AgileMiniProject_PersonalWebsite.PersonalWebsite

Public Class ResumeViewModel

    Public userInfo As UserInfo

    Public styleSheet As Style

    Public experience As IList(Of Experience)

    Public education As IList(Of Education)

    Public skill As IList(Of Skill)

    Sub New()
        Me.experience = New List(Of Experience)
        Me.education = New List(Of Education)
        Me.skill = New List(Of Skill)
    End Sub

End Class
