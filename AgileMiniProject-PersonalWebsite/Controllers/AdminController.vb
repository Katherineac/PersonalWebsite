Imports System.Activities.Expressions
Imports System.Collections
Imports System.IO
Imports System.Web.Mvc

Namespace PersonalWebsite
    Public Class AdminController
        Inherits Controller

        Private _service As IService

        Function Admin() As ActionResult

            Dim avm As AdminViewModel = New AdminViewModel()

            Using db As ApplicationDbContext = New ApplicationDbContext

                avm.styleSheet = db.Style.Where(Function(x) x.Active.Equals(True)).FirstOrDefault()

                avm.userInfo = db.UserInfo.FirstOrDefault()

            End Using

            _service = New Service()

            ViewBag.Title = _service.AdminTitleExample()
            ViewBag.Message = _service.AdminMessageExample()

            Return View(avm)

        End Function

        <HttpPost()>
        Function UploadPhoto(ByVal upload As HttpPostedFileBase) As ActionResult

            'http://www.mikesdotnetting.com/article/260/mvc-5-with-ef-6-in-visual-basic-working-with-files
            Try
                If Not upload Is Nothing Then
                    If upload.ContentLength > 0 Then

                        Dim avatar = New Photo()
                        avatar.Active = True
                        avatar.PhotoName = upload.FileName

                        Dim fileStream = upload.InputStream

                        avatar.PhotoData = New Byte(upload.ContentLength) {}

                        fileStream.Read(avatar.PhotoData, 0, upload.ContentLength)

                        Using db As ApplicationDbContext = New ApplicationDbContext

                            Dim newPhoto = db.Photo.Add(avatar)
                            db.SaveChanges()

                            'Dim otherphotos = db.Photo.Where(Function(x) x.ID == Not newPhoto.ID)).ToList()
                            Dim otherPhotos = From photo In db.Photo
                                              Where photo.ID <> newPhoto.ID

                            Dim otherPhotosList = otherPhotos.ToList()

                            For Each photo In otherPhotosList
                                photo.Active = False
                                db.SaveChanges()
                            Next

                        End Using

                    End If
                End If

            Catch Dex As DataException
                'Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.")
            End Try


            Return RedirectToAction("Admin")
        End Function

        Function GetImage() As FileResult

            Dim photo As Byte()

            Using db As ApplicationDbContext = New ApplicationDbContext

                Try
                    photo = db.Photo.Where(Function(x) x.Active.Equals(True)).FirstOrDefault().PhotoData

                    If photo IsNot Nothing Then

                        Return New FileContentResult(photo, "image/jpeg")

                    End If

                Catch ex As Exception

                    'TODO Handle Exception?

                End Try

            End Using

            Return New FilePathResult("~/Images/default-profile.jpg", "image/jpeg")

        End Function

    End Class

End Namespace