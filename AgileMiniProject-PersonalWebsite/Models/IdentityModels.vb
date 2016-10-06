Imports System.Security.Claims
Imports System.Threading.Tasks
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin

' You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
Public Class ApplicationUser
    Inherits IdentityUser
    Public Async Function GenerateUserIdentityAsync(manager As UserManager(Of ApplicationUser)) As Task(Of ClaimsIdentity)
        ' Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        Dim userIdentity = Await manager.CreateIdentityAsync(Me, DefaultAuthenticationTypes.ApplicationCookie)
        ' Add custom user claims here
        Return userIdentity
    End Function
End Class

Public Class ApplicationDbContext
    Inherits IdentityDbContext(Of ApplicationUser)
    Public Sub New()
        MyBase.New("DefaultConnection", throwIfV1Schema:=False)
    End Sub

    Public Shared Function Create() As ApplicationDbContext
        Return New ApplicationDbContext()
    End Function

    Public Property Education As System.Data.Entity.DbSet(Of AgileMiniProject_PersonalWebsite.PersonalWebsite.Education)
    Public Property Experience As System.Data.Entity.DbSet(Of AgileMiniProject_PersonalWebsite.PersonalWebsite.Experience)
    Public Property Project As System.Data.Entity.DbSet(Of AgileMiniProject_PersonalWebsite.PersonalWebsite.Project)
    Public Property Skill As System.Data.Entity.DbSet(Of AgileMiniProject_PersonalWebsite.PersonalWebsite.Skill)
    Public Property Style As System.Data.Entity.DbSet(Of AgileMiniProject_PersonalWebsite.PersonalWebsite.Style)
    Public Property UserInfo As System.Data.Entity.DbSet(Of AgileMiniProject_PersonalWebsite.PersonalWebsite.UserInfo)
    Public Property Volunteer As System.Data.Entity.DbSet(Of AgileMiniProject_PersonalWebsite.PersonalWebsite.Volunteer)

End Class
