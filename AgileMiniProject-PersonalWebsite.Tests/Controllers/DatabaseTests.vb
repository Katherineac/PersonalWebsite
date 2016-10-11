Imports System.Data.SqlClient
Imports System.Text
Imports AgileMiniProject_PersonalWebsite.PersonalWebsite
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class DatabaseTests

    <TestMethod()> Public Sub GetUserInfo()
        Using db As ApplicationDbContext = New ApplicationDbContext
            Assert.IsNotNull(db)
            Dim testName As String = "John Smithson"
            Dim testId As Integer = 1
            Dim returnedResult As UserInfo = db.UserInfo.SqlQuery("select ID, name WHERE ID='1'").First()

            Assert.IsNotNull(returnedResult)

            Assert.AreEqual(returnedResult.Name, testName)
        End Using


    End Sub

    <TestMethod()> Public Sub GetSkillsTest()
        Using db As ApplicationDbContext = New ApplicationDbContext
            Assert.IsNotNull(db)
            Dim testSkillType As String = "Language"
            Dim testSkillName As String = "C#"
            Dim testID As Integer = 10
            Dim returnedResult As Skill = db.Skill.ToList().First()

            Assert.IsNotNull(returnedResult)

            Assert.AreEqual(testID, returnedResult.ID)
        End Using


    End Sub

End Class