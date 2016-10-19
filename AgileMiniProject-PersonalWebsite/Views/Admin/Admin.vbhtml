@ModelType AdminViewModel
@*
    Agile Mini Project - Personal Website
    Agile Programming
    Fall 2016
    Katie Cater, Lucas Lokken, Austing Prueher, Pheng Vang
*@

@Code

End Code

@functions

    Function ShowActive(ByVal active As Boolean) As HtmlString

        If active Then
            Return New HtmlString("<span class=""glyphicon glyphicon-triangle-right"" aria-hidden=""true""></span>")
        Else
            Return New HtmlString("")
        End If


    End Function

End Functions

<div Class="panel panel-default form-horizontal">
    <div Class="panel-body">
         <div Class="col-md-12 text-center">
             <h2>@ViewData("Title")</h2>
             <h4 class="success">@ViewData("Success")</h4>
             <h4 class="error">@ViewData("Error")</h4>
        </div>
    </div>
</div>      

<div Class="panel panel-default form-horizontal">
        <div Class="col-md-12" id="ProfilePhoto">
            <h3>Profile Photo</h3>
        </div>
        <div class="panel-body">
        <div  id="ProfilePhotoGroup" hidden>
            <br />
            <br />
            <br />
            <h4>Current Profile Photos</h4>
            <br />
            <br />
            <table Class="col-lg-offset-1 col-lg-11" id="ProfilePhotosTable">
                <tr>
                    <th>Active</th>
                    <th>Photo</th>
                    <th>Photo Name</th>
                    <th>Select</th>
                    <th>Delete</th>
                </tr>
                @For Each profilePhoto In Model.profilePhotos
                    @Using (Html.BeginForm("SelectProfilePhoto", "Admin", FormMethod.Post))

                        @Html.AntiForgeryToken()
                        @<tr>
                            <td>@ShowActive(profilePhoto.Active)</td>
                            <td><img class="img-responsive center" src="@Url.Action("GetImageByID", "Admin", New With {.ID = profilePhoto.ID})" alt="Profile Photo" /></td>
                            <td>@profilePhoto.PhotoName</td>
                            <input type="hidden" name="ID" value="@profilePhoto.ID" Class="btn btn-default" />
                            <td><input type="submit" name="submit" value="Select" Class="btn btn-default" /></td>
                            <td><input type="submit" name="submit" value="Delete" Class="btn btn-default" /></td>
                        </tr>                       
                    End Using
                Next
            </table>  
            <br />
            <br />
            <h4 Class="col-lg-12">Upload New Profile Photo</h4>
            <br />
            <br />
            @Using (Html.BeginForm("UploadPhoto", "Admin", Nothing, FormMethod.Post, New With {.enctype = "multipart/form-data"}))

            @Html.AntiForgeryToken()
            @<div Class="form-group">
                <div Class="col-lg-offset-1 col-lg-11">
                    <input type ="file" id="Avatar" name="upload" Class="btn btn-default" />
                </div>
            </div>
            @<div Class="form-group">
                <div Class="col-lg-offset-2 col-lg-10">
                    <input type = "submit" value="Upload Photo" Class="btn btn-default" />
                </div>
            </div>
            End Using
        </div>
    </div>
</div>


@Using (Html.BeginForm("UpdateUserInfo", "Admin", FormMethod.Post, New With {.class = "form-horizontal"}))

    @Html.AntiForgeryToken()

    @<div Class="panel panel-default form-horizontal">
         <div Class="col-md-12" id="UserInfo">
             <h3>User Info</h3>
         </div>
         <div class="panel-body">
             <div  id="UserInfoGroup" hidden>
                 <div Class="col-md-6">
                     <div Class="form-group">
                         <label for="Name" class="col-lg-3 control-label">Name:</label>
                         <div Class="col-md-6">
                             <input type="text" class="form-control" name="Name" id="Name" value="@Model.userInfo.Name" required>
                         </div>
                     </div>
                     <div Class="form-group">
                         <label for="Address" class="col-lg-3 control-label">Address:</label>
                         <div Class="col-md-6">
                             <input type="text" class="form-control" name="Address" id="Address" value="@Model.userInfo.Address">
                         </div>
                     </div>
                     <div Class="form-group">
                         <label for="City" class="col-lg-3 control-label">City:</label>
                         <div Class="col-md-6">
                             <input type="text" class="form-control" name="City" id="City" value="@Model.userInfo.City">
                         </div>
                     </div>
                     <div Class="form-group">
                         <label for="State" class="col-lg-3 control-label">State:</label>
                         <div Class="col-md-6">
                             <input type="text" class="form-control" name="State" id="State" value="@Model.userInfo.State">
                         </div>
                     </div>
                     <div Class="form-group">
                         <label for="Zip" class="col-lg-3 control-label">Zip Code:</label>
                         <div Class="col-md-6">
                             <input type="number" class="form-control" name="Zip" id="Zip" value="@Model.userInfo.Zip">
                         </div>
                     </div>
                     <div Class="form-group">
                         <label for="Phone" class="col-lg-3 control-label">Phone:</label>
                         <div Class="col-md-6">
                             <input type="tel" class="form-control" name="Phone" id="Phone" value="@Model.userInfo.Phone">
                         </div>
                     </div>
                 </div>
                 <div Class="col-md-6">
                     <div Class="form-group">
                         <label for="Email" class="col-lg-3 control-label">Email:</label>
                         <div Class="col-md-6">
                             <input type="email" class="form-control" name="Email" id="Email" value="@Model.userInfo.Email" required>
                         </div>
                     </div>
                     <div Class="form-group">
                         <label for="Github" class="col-lg-3 control-label">Github:</label>
                         <div Class="col-md-6">
                             <input type="url" class="form-control" name="Github" id="Github" value="@Model.userInfo.GitHub">
                         </div>
                     </div>
                     <div Class="form-group">
                         <label for="Twitter" class="col-lg-3 control-label">Twitter:</label>
                         <div Class="col-md-6">
                             <input type="url" class="form-control" name="Twitter" id="Twitter" value="@Model.userInfo.Twitter">
                         </div>
                     </div>
                     <div Class="form-group">
                         <label for="Facebook" class="col-lg-3 control-label">Facebook:</label>
                         <div Class="col-md-6">
                             <input type="url" class="form-control" name="Facebook" id="Facebook" value="@Model.userInfo.Facebook">
                         </div>
                     </div>
                     <div Class="form-group">
                         <label for="LinkedIn" class="col-lg-3 control-label">LinkedIn:</label>
                         <div Class="col-md-6">
                             <input type="url" class="form-control" name="LinkedIn" id="LinkedIn" value="@Model.userInfo.LinkedIn">
                         </div>
                     </div>
                 </div>
                <div Class="col-md-12">
                    <div Class="form-group">
                        <div Class="col-md-12 text-center">
                            <input type="submit" value="Update Info" Class="btn btn-default" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
End Using

<div Class="panel panel-default form-horizontal">
    <div Class="col-md-12" id="Experience">
        <h3>Experience</h3>
    </div>
    <div class="panel-body">
        <div id="ExperienceGroup" hidden>
            <table id="ExperienceTable">
                <tr>
                    <th>Company Name</th>
                    <th>Company City</th>
                    <th>Company State</th>
                    <th>Company Position</th>
                    <th>Start Date</th>
                    <th>End Date</th>
                </tr>
                @For Each experience In Model.experiences

                    @Using (Html.BeginForm("DeleteExperience", "Admin", FormMethod.Post))

                        @Html.AntiForgeryToken()
                        @<tr>
                            <input type="hidden" name="ID" value="@experience.ID" Class="btn btn-default" />
                            <td>@experience.CompanyName</td>
                            <td>@experience.CompanyCity</td>
                            <td>@experience.CompanyState</td>
                            <td>@experience.CompanyPosition</td>
                            <td>@experience.CompanyStartDate</td>
                            <td>@experience.CompanyEndDate</td>
                            <td><input type="submit" name="DeleteExperience" value="Delete" Class="btn btn-default" /></td>
                        </tr>
                    End Using
                Next
            </table>
            @Using (Html.BeginForm("AddExperience", "Admin", FormMethod.Post))
                @Html.AntiForgeryToken()
                @<div Class="col-lg-6">
                    <div Class="form-group">
                        <hr />
                        <h3>Add Experience</h3>
                    </div>
                    <div Class="form-group">
                        <Label for="CompanyName" class="col-lg-4 control-label">Company Name:</Label>
                        <input type="text" Class="form-control" name="CompanyName" id="CompanyName" value="" required>
                    </div>
                    <div Class="form-group">
                        <Label for="CompanyCity" class="col-lg-4 control-label">Company City:</Label>
                        <input type="text" Class="form-control" name="CompanyCity" id="CompanyCity" value="" required>
                    </div>
                    <div Class="form-group">
                        <Label for="CompanyState" class="col-lg-4 control-label">Company State:</Label>
                        <input type="text" Class="form-control" name="CompanyState" id="CompanyState" value="" required>
                    </div>
                    <div Class="form-group">
                        <Label for="CompanyPosition" class="col-lg-4 control-label">Company Position:</Label>
                        <input type="text" Class="form-control" name="CompanyPosition" id="CompanyPosition" value="" required>
                    </div>
                    <div Class="form-group">
                        <Label for="CompanyStartDate" class="col-lg-4 control-label">Start Date:</Label>
                        <input type="text" Class="form-control" name="CompanyStartDate" id="CompanyStartDate" value="" required>
                    </div>
                    <div Class="form-group">
                        <Label for="CompanyEndDate" class="col-lg-4 control-label">End Date:</Label>
                        <input type="text" Class="form-control" name="CompanyEndDate" id="CompanyEndDate" value="" required>
                    </div>>
                    <div Class="col-lg-12 ">
                        <input type="submit" name="AddExperience" value="Add Experience" Class="center-block btn btn-default" />
                    </div>
                </div>
            End Using
        </div>
    </div>
</div>

<div Class="panel panel-default form-horizontal">
    <div Class="col-md-12" id="Education">
        <h3>Education</h3>
    </div>
    <div class="panel-body">
        <div id="EducationGroup" hidden>
            <table id="EducationTable">
                <tr>
                    <th>School Name</th>
                    <th>School City</th>
                    <th>School State</th>
                    <th>Degree Earned</th>
                    <th>Degree Year</th>
                    <th>Delete</th>
                </tr>
                @For Each education In Model.educations

                    @Using (Html.BeginForm("DeleteEducation", "Admin", FormMethod.Post))

                        @Html.AntiForgeryToken()
                        @<tr>
                            <input type="hidden" name="ID" value="@education.ID" Class="btn btn-default" />
                            <td>@education.SchoolName</td>
                            <td>@education.SchoolCity</td>
                            <td>@education.SchoolState</td>
                            <td>@education.DegreeEarned</td>
                            <td>@education.DegreeYear</td>
                            <td><input type="submit" name="DeleteEducation" value="Delete" Class="btn btn-default" /></td>
                        </tr>
                    End Using
                Next
            </table>
            @Using (Html.BeginForm("AddEducation", "Admin", FormMethod.Post))
                @Html.AntiForgeryToken()
                @<div Class="col-lg-6">
                    <div Class="form-group">
                        <hr />
                        <h3>Add Education</h3>
                    </div>
                    <div Class="form-group">
                        <Label for="SchoolName" class="col-lg-4 control-label">School Name:</Label>
                        <input type="text" Class="form-control" name="SchoolName" id="SchoolName" value="" required>
                    </div>
                    <div Class="form-group">
                        <Label for="SchoolCity" class="col-lg-4 control-label">School City:</Label>
                        <input type="text" Class="form-control" name="SchoolCity" id="SchoolCity" value="" required>
                    </div>
                    <div Class="form-group">
                        <Label for="SchoolState" class="col-lg-4 control-label">School State:</Label>
                        <input type="text" Class="form-control" name="SchoolState" id="SchoolState" value="" required>
                    </div>
                     <div Class="form-group">
                         <Label for="DegreeEarned" class="col-lg-4 control-label">Degree Earned:</Label>
                         <input type="text" Class="form-control" name="DegreeEarned" id="DegreeEarned" value="" required>
                     </div>
                     <div Class="form-group">
                         <Label for="DegreeYear" class="col-lg-4 control-label">Degree Year:</Label>
                         <input type="text" Class="form-control" name="DegreeYear" id="DegreeYear" value="" required>
                     </div>
                    <div Class="col-lg-12 ">
                        <input type="submit" name="AddEducation" value="Add Education" Class="center-block btn btn-default" />
                    </div>
                </div>
            End Using    
        </div>
    </div>
</div>

<div Class="panel panel-default form-horizontal">
    <div Class="col-md-12" id="Skills">
        <h3>Skills</h3>
    </div>
    <div class="panel-body">
        <div id="SkillsGroup" hidden>
            <table id="SkillsTable">
                <tr>
                    <th>Skill Type</th>
                    <th>Skill Name</th>
                    <th>Delete</th>
                </tr>
                @For Each skill In Model.skills

                    @Using (Html.BeginForm("DeleteSkill", "Admin", FormMethod.Post))

                        @Html.AntiForgeryToken()
                        @<tr>
                            <input type="hidden" name="ID" value="@skill.ID" Class="btn btn-default" />
                            <td>@skill.SkillType</td>
                            <td>@skill.SkillName</td>
                            <td><input type="submit" name="DeleteSkill" value="Delete" Class="btn btn-default" /></td>
                        </tr>
                    End Using
                Next
            </table>
            @Using (Html.BeginForm("AddSkill", "Admin", FormMethod.Post))
                @Html.AntiForgeryToken()
                @<div Class="col-lg-6">
                    <div Class="form-group">
                        <hr />
                        <h3>Add Skill</h3>
                    </div>
                    <div Class="form-group">
                        <Label for="SkillType" class="col-lg-4 control-label">Skill Type:</Label>
                        <input type="text" Class="form-control" name="SkillType" id="SkillType" value="" required>
                    </div>
                    <div Class="form-group">
                        <Label for="SkillName" class="col-lg-4 control-label">Skill Name:</Label>
                        <input type="text" Class="form-control" name="SkillName" id="SkillName" value="" required>
                    </div>
                    <div Class="col-lg-12 ">
                        <input type="submit" name="AddSkill" value="Add Skill" Class="center-block btn btn-default" />
                    </div>
                </div>
            End Using
        </div>
    </div>
</div>

<div Class="panel panel-default form-horizontal">
    <div Class="col-md-12" id="Projects">
        <h3>Projects</h3>
    </div>
    <div class="panel-body">
        <div id="ProjectsGroup" hidden>
            <table id="ProjectsTable">
                <tr>
                    <th>Project Name</th>
                    <th>Project Description</th>
                    <th>Project Link</th>
                    <th>Delete</th>
                </tr>
                @For Each project In Model.projects

                    @Using (Html.BeginForm("DeleteProject", "Admin", FormMethod.Post))

                        @Html.AntiForgeryToken()
                        @<tr>
                            <input type="hidden" name="ID" value="@project.ID" Class="btn btn-default" />
                            <td>@project.ProjectName</td>
                            <td>@project.ProjectDescription</td>
                            <td>@project.ProjectLink</td>
                            <td><input type="submit" name="DeleteProject" value="Delete" Class="btn btn-default" /></td>
                        </tr>
                    End Using
                Next
            </table>         
            @Using (Html.BeginForm("AddProject", "Admin", FormMethod.Post))
                @Html.AntiForgeryToken()
                @<div Class="col-lg-6">
                     <div Class="form-group">
                         <hr />
                        <h3>Add Project</h3>
                     </div>
                    <div Class="form-group">
                        <Label for="ProjectName" class="col-lg-4 control-label">Project Name:</Label>
                        <input type="text" Class="form-control" name="ProjectName" id="ProjectName" value="" required>
                    </div>
                    <div Class="form-group">
                        <Label for="ProjectDescription" class="col-lg-4 control-label">Project Description:</Label>
                        <input type="text" Class="form-control" name="ProjectDescription" id="ProjectDescription" value="" required>
                    </div>
                    <div Class="form-group">
                        <Label for="ProjectLink" class="col-lg-4 control-label">Project Link:</Label>
                        <input type="text" Class="form-control" name="ProjectLink" id="ProjectLink" value="" required>
                    </div>
                    <div Class="col-lg-12 ">
                        <input type="submit" name="AddProject" value="Add Project" Class="center-block btn btn-default" />
                    </div>
                </div>
            End Using         
        </div>
    </div>
</div>

<div Class="panel panel-default form-horizontal">
    <div Class="col-md-12" id="Styles">
        <h3>Themes</h3>
    </div>
    <div class="panel-body">
        <div  id="ThemesGroup" hidden>
            <table id="StylesTables">
                <tr>
                    <th>Active</th>
                    <th>Name</th>
                    <th>Select</th>
                </tr>
                @For Each stylesheet In Model.styleSheets

                    @Using (Html.BeginForm("SelectStyleSheet", "Admin", FormMethod.Post))

                    @Html.AntiForgeryToken()
                    @<tr>
                        <td>@ShowActive(stylesheet.Active)</td>
                        <td>@stylesheet.StyleSheetName</td>
                        <input type = "hidden" name="ID" value="@stylesheet.ID" Class="btn btn-default" />
                        <td><input type = "submit" name="UpdateStylesheet" value="Select" Class="btn btn-default" /></td>
                    </tr>
                    End Using
                Next
            </table>
        </div>
    </div>
</div>


<Script>

    $(document).ready(function () {

        $("#admin").addClass("active");

        var link = document.createElement("link");
        link.href = "../../@Model.activeStylesheet.StyleSheetLink";
        link.type = "text/css";
        link.rel = "stylesheet";
        document.getElementsByTagName("head")[0].appendChild(link);

    });

    $("#ProfilePhoto").click(function () {

        $("#ProfilePhotoGroup").toggle()
    });

    $("#UserInfo").click(function () {

        $("#UserInfoGroup").toggle()
    });

    $("#Experience").click(function () {

        $("#ExperienceGroup").toggle()
    });

    $("#Education").click(function () {

        $("#EducationGroup").toggle()
    });

    $("#Skills").click(function () {

        $("#SkillsGroup").toggle()
    });

    $("#Projects").click(function () {

        $("#ProjectsGroup").toggle()
    });

    $("#Styles").click(function () {

        $("#ThemesGroup").toggle()
    });

</script>