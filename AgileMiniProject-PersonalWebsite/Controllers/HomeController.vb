'Agile Mini Project - Personal Website
'Agile Programming
'Fall 2016
'Katie Cater, Lucas Lokken, Austing Prueher, Pheng Vang

Option Infer On

Imports System
Imports System.IO
Imports System.Threading.Tasks
Imports AgileMiniProject_PersonalWebsite
Imports Microsoft.Ajax.Utilities
Namespace PersonalWebsite


    Public Class HomeController
        Inherits Controller

        Private _service As IService

        Public Sub New()

        End Sub

        Function Index() As ActionResult

            Dim avm As AboutViewModel = New AboutViewModel()

            Using db As ApplicationDbContext = New ApplicationDbContext

                avm.styleSheet = db.Style.Where(Function(x) x.Active.Equals(True)).FirstOrDefault()

                avm.userInfo = db.UserInfo.FirstOrDefault()

            End Using

            ViewBag.Title = "Index/About"
            ViewBag.Message = "Index/About info here.."
            ViewBag.Content = "This has been designed as a portfolio template."
            ViewBag.Content2 = "This is not a real person."
            ViewBag.Content3 = "My name is John Smithson and I graduated from CVTC in 2016 with an associates in Mobile Development."
            ViewBag.Content4 = "I am currently pursuing a career in software development in the Eau Claire Area."
            ViewBag.Content5 = "Please look at the rest of my site for my experience, projects I've worked on, and how to contact me."
            ViewBag.Content6 = "Thank you for visiting, have a great day."

            Return View(avm)

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

                Dim volunteerList As New List(Of Volunteer)
                volunteerList = db.Volunteer.OrderBy(Function(e) e.EndDate).ToList()

                For Each volunteer As Volunteer In volunteerList
                    rvm.volunteer.Add(volunteer)
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

            Dim pvm As ProjectsViewModel = New ProjectsViewModel()

            Using db As ApplicationDbContext = New ApplicationDbContext

                pvm.styleSheet = db.Style.Where(Function(x) x.Active.Equals(True)).FirstOrDefault()

                pvm.userInfo = db.UserInfo.FirstOrDefault()

            End Using

            ViewBag.Title = "Projects"
            ViewBag.Message = "Projects goes here..."

            Return View(pvm)

        End Function

        Function Contact() As ActionResult

            Dim cvm As ContactViewModel = New ContactViewModel()

            Using db As ApplicationDbContext = New ApplicationDbContext

                cvm.styleSheet = db.Style.Where(Function(x) x.Active.Equals(True)).FirstOrDefault()

                cvm.userInfo = db.UserInfo.FirstOrDefault()

            End Using

            ViewBag.Title = "Contact"
            ViewBag.Message = "Contact form goes here..."

            Return View(cvm)

        End Function

        '
        ' POST: /ContactSubmit
        <HttpPost>
        <AllowAnonymous>
        Public Function ContactSubmit(name As String, email As String, message As String) As ActionResult

            ViewBag.Title = "Contact Submitted"

            ' Check if email is valid
            ' RFC 5322 Official Standard for email validation
            Dim emailPattern As New Regex("^[_a-z0-9-]+(.[a-z0-9-]+)@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$")
            If (String.IsNullOrEmpty(email) Or (Not emailPattern.IsMatch(email))) Then

                ViewBag.Message = "Sorry but you entered an invalid email address, please try again!"
                Return View()
            End If

            ' Check if name is valid
            ' Checking that name is not empty
            If (String.IsNullOrEmpty(name)) Then
                ViewBag.Message = "Please enter in your name!"
                Return View()
            End If

            ' Check if message is valid by making sure it isn't null or empty
            If (String.IsNullOrEmpty(message)) Then
                ViewBag.Message = "Please enter in a message!"
                Return View()
            End If

            ViewBag.Message = "Thank you " + name + ", your email address " + email + " has been forwarded to John Smith with the message: " + message
            Return View()
        End Function



        Function Admin() As ActionResult

            Dim avm As AdminViewModel = New AdminViewModel()

            Using db As ApplicationDbContext = New ApplicationDbContext

                avm.styleSheets = db.Style.ToList()

                avm.userInfo = db.UserInfo.FirstOrDefault()

            End Using

            _service = New Service()

            ViewBag.Title = _service.AdminTitleExample()
            ViewBag.Message = _service.AdminMessageExample()

            Return View(avm)

        End Function

    End Class
End Namespace
