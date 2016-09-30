'Agile Mini Project - Personal Website
'Agile Programming
'Fall 2016
'Katie Cater, Lucas Lokken, Austing Prueher, Pheng Vang

Imports AgileMiniProject_PersonalWebsite

Public Class Service
    Implements IService

    Public Sub New()

    End Sub

    Private Function IService_AdminTitleExample() As String Implements IService.AdminTitleExample
        Return "Admin"
    End Function

    Private Function IService_AdminMessageExample() As String Implements IService.AdminMessageExample
        Return "This is the admin section"
    End Function

End Class
