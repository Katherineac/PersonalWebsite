'Agile Mini Project - Personal Website
'Agile Programming
'Fall 2016
'Katie Cater, Lucas Lokken, Austing Prueher, Pheng Vang

' Imports
Imports System
Imports System.Activities.Expressions
Imports System.Collections
Imports System.IO
Imports System.Web.Mvc

' Using PersonalWebsite Namespace
Namespace PersonalWebsite

    ' Admin Controller Class - Inherits from Controller
    Public Class AdminController
        Inherits Controller

#Region "Admin"
        ' ActionResult for Admin Page
        Function Admin() As ActionResult

            ' Create new AdminViewModel
            Dim adminViewModel As AdminViewModel = New AdminViewModel()

            'Get DB Context and populate AdminViewModel
            Using db As ApplicationDbContext = New ApplicationDbContext

                ' Get the active Style from the DB and assign to AdminViewModel
                adminViewModel.activeStylesheet = db.Style.Where(Function(x) x.Active.Equals(True)).FirstOrDefault()

                ' Get list of all Styles from DB and assign to AdminViewModel
                adminViewModel.styleSheets = db.Style.ToList()

                ' Get list of all Photos from DB and assign to AdminViewModel
                adminViewModel.profilePhotos = db.Photo.ToList()

                ' Get User's Personal Info from DB and assign to AdminViewModel
                adminViewModel.userInfo = db.UserInfo.FirstOrDefault()

                ' Get User's Experience info from DB and assign to AdminViewModel
                adminViewModel.experiences = db.Experience.ToList()

                ' Get User's Education info from DB and assign to AdminViewModel
                adminViewModel.educations = db.Education.ToList()

                ' Get User's Skills info from DB and assign to AdminViewModel
                adminViewModel.skills = db.Skill.ToList()

                ' Get User's Project info from DB and assign to AdminViewModel
                adminViewModel.projects = db.Project.ToList()

            End Using

            ' Set View Title
            ViewBag.Title = "Admin"

            ' Get success message
            ViewBag.Success = TempData("success")

            ' Get error message
            ViewBag.Error = TempData("error")

            ' Return Admin View and pass in AdminViewModel
            Return View(adminViewModel)

        End Function
#End Region

#Region "UploadPhoto"
        ' Post Method for Uploading a Profile Photo
        <HttpPost()>
        Function UploadPhoto(ByVal upload As HttpPostedFileBase) As ActionResult

            ' Reference to article about uploading filein db
            'http://www.mikesdotnetting.com/article/260/mvc-5-with-ef-6-in-visual-basic-working-with-files

            ' Try Block for uploading and saving profile photo
            Try
                ' If the upload is not null
                If Not upload Is Nothing Then

                    ' And upload content length is greater than 0
                    If upload.ContentLength > 0 Then

                        ' Make sure upload is png or jpg
                        If CheckFileTypeIsImage(upload.FileName) Then

                            ' Declare new Photo
                            Dim avatar = New Photo()

                            ' Set new Photo to Active
                            avatar.Active = True

                            ' Assign filename to Photo
                            avatar.PhotoName = upload.FileName

                            ' Declare new filestream
                            Dim fileStream = upload.InputStream

                            ' Assign content length of upload to Photo
                            avatar.PhotoData = New Byte(upload.ContentLength) {}

                            ' Read the filestream
                            fileStream.Read(avatar.PhotoData, 0, upload.ContentLength)

                            ' Get DB Context
                            Using db As ApplicationDbContext = New ApplicationDbContext

                                ' Add photo to DB and get a reference to it
                                Dim newPhoto = db.Photo.Add(avatar)

                                ' Save changes to DB
                                db.SaveChanges()

                                ' Create query for all photos except the currently uploaded photo
                                Dim otherPhotos = From photo In db.Photo
                                                  Where photo.ID <> newPhoto.ID

                                ' Create a list of other photos using query
                                Dim otherPhotosList = otherPhotos.ToList()

                                ' Iterate thru each of the other photos
                                For Each photo In otherPhotosList
                                    ' Mark each photo as inactive
                                    photo.Active = False
                                    ' Save changes to DB
                                    db.SaveChanges()
                                Next

                                ' Create success message
                                TempData("success") = "Profile Photo Uploaded Successfully"

                            End Using
                        Else
                            ' Create Error message if upload is the wrong format
                            TempData("error") = "Photo must be .png or .jpg."
                            End If
                        Else
                            ' Create Error message if upload filesize is 0
                            TempData("error") = "Uploaded file contained no data."
                    End If
                Else
                    ' Create Error message if upload is null
                    TempData("error") = "No file was uploaded."
                End If

                ' Catch any errors during upload and save
            Catch e As DataException

                ' Create Error message
                TempData("error") = "There was an error uploading our profile photo. " + e.ToString()

            End Try

            ' Redirect to Admin ActionResult and return Admin View
            Return RedirectToAction("Admin")

        End Function
#End Region

#Region "SelectProfilePhoto"
        <HttpPost()>
        Function SelectProfilePhoto(ByVal photo As Photo) As ActionResult

            ' Get DB Context
            Using db As ApplicationDbContext = New ApplicationDbContext

                'Create query to find selected Photo
                Dim selectedPhotoQuery = From photos In db.Photo
                                         Where photos.ID = photo.ID

                ' Get the selected Photo using query
                Dim selectedPhoto = selectedPhotoQuery.FirstOrDefault()

                ' Get Value of which submit button was pressed
                Dim submitValue = HttpContext.Request.Form("submit")

                Debug.WriteLine(submitValue)

                ' If user is selecting photo...
                If (submitValue.Equals("Select")) Then

                    ' Set selected Photo to active
                    selectedPhoto.Active = True

                    'Create query to find all other Photos
                    Dim otherPhotosQuery = From photos In db.Photo
                                           Where photos.ID <> photo.ID

                    ' Get list of other Photos using query
                    Dim otherPhotosList = otherPhotosQuery.ToList()

                    ' Make sure list of other photos isn't null
                    If otherPhotosList IsNot Nothing Then

                        ' Iterate thru list of other photos and mark each inactive
                        For Each photo In otherPhotosList
                            photo.Active = False
                        Next

                    End If

                    ' If user is deleting photo...
                ElseIf (submitValue.Equals("Delete")) Then

                    ' Remove selected photo from DB
                    db.Photo.Remove(selectedPhoto)

                End If

                'Save chances to DB
                db.SaveChanges()

            End Using

            ' Redirect to Admin ActionResult and display Admin View
            Return RedirectToAction("Admin")

        End Function
#End Region

#Region "UpdateUserInfo"
        ' UpdateUserInfo ActionResult
        <HttpPost()>
        Function UpdateUserInfo(ByVal form As UserInfo) As ActionResult

            ' Check if email is valid
            ' RFC 5322 Official Standard for email validation
            Dim emailPattern As New Regex("^[_a-z0-9-]+(.[a-z0-9-]+)@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$")
            If (String.IsNullOrEmpty(form.Email) Or (Not emailPattern.IsMatch(form.Email))) Then
                Return RedirectToAction("Admin")
            End If

            ' Check if name is valid
            ' Checking that name is not empty
            If (String.IsNullOrEmpty(form.Name)) Then
                Return RedirectToAction("Admin")
            End If

            ' Get DB Context
            Using db As ApplicationDbContext = New ApplicationDbContext

                ' Get UserInfo from DB
                Dim dbUserInfo As UserInfo = db.UserInfo.FirstOrDefault()

                ' Update DB values with values from form
                dbUserInfo.Name = form.Name
                dbUserInfo.Address = form.Address
                dbUserInfo.City = form.City
                dbUserInfo.State = form.State
                dbUserInfo.Zip = form.Zip
                dbUserInfo.Phone = form.Phone
                dbUserInfo.Email = form.Email
                dbUserInfo.GitHub = form.GitHub
                dbUserInfo.Twitter = form.Twitter
                dbUserInfo.Facebook = form.Facebook
                dbUserInfo.LinkedIn = form.LinkedIn

                ' Save changes to DB
                db.SaveChanges()

            End Using

            ' Redirect to Admin AcionResult and display Admin View
            Return RedirectToAction("Admin")

        End Function
#End Region

#Region "Delete Experience"
        'HttpPost Method for Deleting an Experience
        <HttpPost()>
        Function DeleteExperience(ByVal experience As Experience) As ActionResult

            'Get DB Context
            Using db As ApplicationDbContext = New ApplicationDbContext

                'Create query to find selected Experience
                Dim selectedExperienceQuery = From experiences In db.Experience
                                              Where experiences.ID = experience.ID

                ' Get the selected Experience using query
                Dim selectedExperience = selectedExperienceQuery.FirstOrDefault()

                ' Remove selected Experience
                db.Experience.Remove(selectedExperience)

                ' Save Changes to DB
                db.SaveChanges()

            End Using

            'Redirect back to Admin ActionResult to display page Admin View
            Return RedirectToAction("Admin")

        End Function
#End Region

#Region "Add Experience"
        'HttpPost Method for Deleting an Experience
        <HttpPost()>
        Function AddExperience(ByVal form As Experience) As ActionResult

            'Get DB Context
            Using db As ApplicationDbContext = New ApplicationDbContext

                ' Create new Experience
                Dim newExperience As New Experience()

                ' Populate newExperience with form data
                newExperience.CompanyName = form.CompanyName
                newExperience.CompanyCity = form.CompanyCity
                newExperience.CompanyState = form.CompanyState
                newExperience.CompanyPosition = form.CompanyPosition
                newExperience.CompanyStartDate = form.CompanyStartDate
                newExperience.CompanyEndDate = form.CompanyEndDate

                ' Add newExperience to DB 
                db.Experience.Add(newExperience)

                ' Save Changes to DB
                db.SaveChanges()

            End Using

            'Redirect back to Admin ActionResult to display page Admin View
            Return RedirectToAction("Admin")

        End Function
#End Region

#Region "Delete Education"
        'HttpPost Method for Deleting an Education
        <HttpPost()>
        Function DeleteEducation(ByVal education As Education) As ActionResult

            'Get DB Context
            Using db As ApplicationDbContext = New ApplicationDbContext

                'Create query to find selected Education
                Dim selectedEducationQuery = From educations In db.Education
                                             Where educations.ID = education.ID

                ' Get the selected Education using query
                Dim selectedEducation = selectedEducationQuery.FirstOrDefault()

                ' Remove selected Education
                db.Education.Remove(selectedEducation)

                ' Save Changes to DB
                db.SaveChanges()

            End Using

            'Redirect back to Admin ActionResult to display page Admin View
            Return RedirectToAction("Admin")

        End Function
#End Region

#Region "Add Education"
        'HttpPost Method for Deleting an Education
        <HttpPost()>
        Function AddEducation(ByVal form As Education) As ActionResult

            'Get DB Context
            Using db As ApplicationDbContext = New ApplicationDbContext

                ' Create new Education
                Dim newEducation As New Education()

                ' Populate newEducation with form data
                newEducation.SchoolName = form.SchoolName
                newEducation.SchoolCity = form.SchoolCity
                newEducation.SchoolState = form.SchoolState
                newEducation.DegreeEarned = form.DegreeEarned
                newEducation.DegreeYear = form.DegreeYear

                ' Add newEducation to DB 
                db.Education.Add(newEducation)

                ' Save Changes to DB
                db.SaveChanges()

            End Using

            'Redirect back to Admin ActionResult to display page Admin View
            Return RedirectToAction("Admin")

        End Function
#End Region

#Region "Delete Skill"
        'HttpPost Method for Deleting an Skill
        <HttpPost()>
        Function DeleteSkill(ByVal skill As Skill) As ActionResult

            'Get DB Context
            Using db As ApplicationDbContext = New ApplicationDbContext

                'Create query to find selected Skill
                Dim selectedSkillQuery = From skills In db.Skill
                                         Where skills.ID = skill.ID

                ' Get the selected Skill using query
                Dim selectedSkill = selectedSkillQuery.FirstOrDefault()

                ' Remove selected Skill
                db.Skill.Remove(selectedSkill)

                ' Save Changes to DB
                db.SaveChanges()

            End Using

            'Redirect back to Admin ActionResult to display page Admin View
            Return RedirectToAction("Admin")

        End Function
#End Region

#Region "Add Skill"
        'HttpPost Method for Deleting an Skill
        <HttpPost()>
        Function AddSkill(ByVal form As Skill) As ActionResult

            'Get DB Context
            Using db As ApplicationDbContext = New ApplicationDbContext

                ' Create new Skill
                Dim newSkill As New Skill()

                ' Populate newSkill with form data
                newSkill.SkillType = form.SkillType
                newSkill.SkillName = form.SkillName

                ' Add newSkill to DB 
                db.Skill.Add(newSkill)

                ' Save Changes to DB
                db.SaveChanges()

            End Using

            'Redirect back to Admin ActionResult to display page Admin View
            Return RedirectToAction("Admin")

        End Function
#End Region

#Region "Delete Project"
        'HttpPost Method for Deleting an Project
        <HttpPost()>
        Function DeleteProject(ByVal project As Project) As ActionResult

            'Get DB Context
            Using db As ApplicationDbContext = New ApplicationDbContext

                'Create query to find selected Project
                Dim selectedProjectQuery = From projects In db.Project
                                           Where projects.ID = project.ID

                ' Get the selected Project using query
                Dim selectedProject = selectedProjectQuery.FirstOrDefault()

                ' Remove selected Project
                db.Project.Remove(selectedProject)

                ' Save Changes to DB
                db.SaveChanges()

            End Using

            'Redirect back to Admin ActionResult to display page Admin View
            Return RedirectToAction("Admin")

        End Function
#End Region

#Region "Add Project"
        'HttpPost Method for Deleting an Project
        <HttpPost()>
        Function AddProject(ByVal form As Project) As ActionResult

            'Get DB Context
            Using db As ApplicationDbContext = New ApplicationDbContext

                ' Create new Project
                Dim newProject As New Project()

                ' Populate newProject with form data
                newProject.ProjectName = form.ProjectName
                newProject.ProjectDescription = form.ProjectDescription
                newProject.ProjectLink = form.ProjectLink

                ' Add newProject to DB 
                db.Project.Add(newProject)

                ' Save Changes to DB
                db.SaveChanges()

            End Using

            'Redirect back to Admin ActionResult to display page Admin View
            Return RedirectToAction("Admin")

        End Function
#End Region

#Region "SelectStyleSheet"
        'HttpPost Method for Selecting a new Style
        <HttpPost()>
        Function SelectStyleSheet(ByVal stylesheet As Style) As ActionResult

            'Get DB Context
            Using db As ApplicationDbContext = New ApplicationDbContext

                'Create query to find selected Style
                Dim selectedStylesheetQuery = From style In db.Style
                                              Where style.ID = stylesheet.ID

                ' Get the selected Style using query
                Dim selectedStylesheet = selectedStylesheetQuery.FirstOrDefault()

                ' Set selected Style to active
                selectedStylesheet.Active = True

                ' Create query to get all other Styles
                Dim otherStylesheets = From style In db.Style
                                       Where style.ID <> stylesheet.ID

                ' Get List of other Styles using query
                Dim otherStylesheetsList = otherStylesheets.ToList()

                ' Iterate thru other Styles and mark inactive
                For Each style In otherStylesheetsList
                    style.Active = False
                Next

                ' Save Changes to DB
                db.SaveChanges()

            End Using

            'Redirect back to Admin ActionResult to display page Admin View
            Return RedirectToAction("Admin")

        End Function
#End Region

#Region "GetImage"
        ' Function to retrieve the Active Profile Photo and return it to a view for display
        Function GetImage() As FileResult

            ' Declare photo property
            Dim photo As Byte()

            ' Get DB Context
            Using db As ApplicationDbContext = New ApplicationDbContext

                ' Try to find an Active profile photo from the DB
                Try
                    photo = db.Photo.Where(Function(x) x.Active.Equals(True)).FirstOrDefault().PhotoData

                    ' If the result of the query is not null, return the photo to the view
                    If photo IsNot Nothing Then

                        Return New FileContentResult(photo, "image/jpeg")

                    End If

                    ' Catch any errors that may occur retrieving profile photo from the DB
                Catch ex As Exception

                    'TODO Handle Exception?

                End Try

            End Using

            ' If attmpt to retrieve profile photo is unsuccessful, return default photo instead
            Return New FilePathResult("~/Images/default-profile.jpg", "image/jpeg")

        End Function
#End Region

#Region "GetImageByID"
        ' Function to retrieve Profile Photo by ID and return it to a view for display
        Function GetImageByID(ByVal selectedPhoto As Photo) As FileResult

            ' Declare photo property
            Dim photo As Byte()

            ' Get DB Context
            Using db As ApplicationDbContext = New ApplicationDbContext

                ' Try to find an Active profile photo from the DB
                Try
                    photo = db.Photo.Where(Function(x) x.ID.Equals(selectedPhoto.ID)).FirstOrDefault().PhotoData

                    ' If the result of the query is not null, return the photo to the view
                    If photo IsNot Nothing Then

                        Return New FileContentResult(photo, "image/jpeg")

                    End If

                    ' Catch any errors that may occur retrieving profile photo from the DB
                Catch ex As Exception

                    'TODO Handle Exception?

                End Try

            End Using

            ' If attmpt to retrieve profile photo is unsuccessful, return default photo instead
            Return New FilePathResult("~/Images/default-profile.jpg", "image/jpeg")

        End Function
#End Region

        Function CheckFileTypeIsImage(ByRef FileName As String) As Boolean
            Dim indexAfterLastPeriod As Integer = FileName.LastIndexOf(".") + 1
            ' No valid index was found
            If indexAfterLastPeriod <= 0 Then
                Return False
            End If

            ' The remaining piece of the string is checked
            Dim fileType As String = FileName.Substring(indexAfterLastPeriod, FileName.Length - indexAfterLastPeriod).ToLower()
            Return fileType.Equals("png") Or fileType.Equals("jpg")
        End Function

    End Class

End Namespace