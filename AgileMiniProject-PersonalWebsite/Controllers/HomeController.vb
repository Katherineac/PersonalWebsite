'Agile Mini Project - Personal Website
'Agile Programming
'Fall 2016
'Katie Cater, Lucas Lokken, Austing Prueher, Pheng Vang

Imports System
Imports AgileMiniProject_PersonalWebsite
Imports Autofac

Public Class HomeController
    Inherits Controller

    Private _service As IService

    Public Sub New()

    End Sub

    Function Index() As ActionResult

        ViewBag.Title = "Index/About"
        ViewBag.Message = "Index/About info here..."

        Return View()

    End Function

    Function ResumePage() As ActionResult

        ViewBag.Title = "Resume"
        ViewBag.Message = "Resume info goes here..."

        Return View()

    End Function

    Function Projects() As ActionResult

        ViewBag.Title = "Projects"
        ViewBag.Message = "Projects goes here..."

        Return View()

    End Function

    Function Contact() As ActionResult

        ViewBag.Title = "Contact"
        ViewBag.Message = "Contact form goes here..."

        Return View()

    End Function

    Function Admin() As ActionResult

        _service = New Service()

        ViewBag.Title = _service.AdminTitleExample()
        ViewBag.Message = _service.AdminMessageExample()

        Return View()

    End Function

End Class
