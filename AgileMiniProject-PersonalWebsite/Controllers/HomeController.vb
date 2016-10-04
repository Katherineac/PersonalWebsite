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
        ViewBag.Message = "Index/About info here.."
        ViewBag.Content = "This has been designed as a portfolio template."
        ViewBag.Content2 = "This is not a real person."
        ViewBag.Content3 = "My name is John Smith and I graduated from CVTC in 2014 with an associates in Software Development."
        ViewBag.Content4 = "I am currently pursuing a career in software development in the Eau Claire Area."
        ViewBag.Content5 = "Please look at the rest of my site for my experience, projects I've worked on, and how to contact me."
        ViewBag.Content6 = "Thank you for visiting, have a great day."

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
