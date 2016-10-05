'Agile Mini Project - Personal Website
'Agile Programming
'Fall 2016
'Katie Cater, Lucas Lokken, Austing Prueher, Pheng Vang

Imports System
Imports AgileMiniProject_PersonalWebsite
Imports Microsoft.Ajax.Utilities
Namespace PersonalWebsite


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

            Dim rvm As ResumeViewModel = New ResumeViewModel()

            Using db As ApplicationDbContext = New ApplicationDbContext

                rvm.styleSheet = db.Style.Where(Function(x) x.Active.Equals(True)).FirstOrDefault()

                rvm.userInfo = db.UserInfo.FirstOrDefault()

                Dim experienceList As New List(Of Experience)
                experienceList = db.Experience.OrderByDescending(Function(e) e.CompanyEndDate).ToList()

                For Each experience As Experience In experienceList
                    rvm.experience.Add(experience)
                Next

                Dim educationList As New List(Of Education)
                educationList = db.Education.OrderByDescending(Function(e) e.DegreeYear).ToList()

                For Each education As Education In educationList
                    rvm.education.Add(education)
                Next

                Dim skillList As New List(Of Skill)
                skillList = db.Skill.OrderBy(Function(e) e.SkillType).ToList()

                For Each skill As Skill In skillList
                    rvm.skill.Add(skill)
                Next

            End Using

            ViewBag.Title = "Resume"
            ViewBag.Message = "Resume info goes here..."
            ViewBag.Experience = "Experience"
            ViewBag.Education = "Education"
            ViewBag.Skills = "Skills"
            ViewBag.VolunteerExperience = "Volunteer Experience"

            Return View(rvm)

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
End Namespace
