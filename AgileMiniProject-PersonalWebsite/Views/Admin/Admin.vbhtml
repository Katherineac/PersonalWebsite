@imports  GridMVC.html
@ModelType AdminViewModel
@*
    Agile Mini Project - Personal Website
    Agile Programming
    Fall 2016
    Katie Cater, Lucas Lokken, Austing Prueher, Pheng Vang
*@
<link href="~/Content/Gridmvc.css" rel="stylesheet" />
<script src="~/Scripts/gridmvc.js"></script>
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
                             <input type="text" class="form-control" name="Name" id="Name" value="@Model.userInfo.Name">
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
                             <input type="text" class="form-control" name="Zip" id="Zip" value="@Model.userInfo.Zip">
                         </div>
                     </div>
                     <div Class="form-group">
                         <label for="Phone" class="col-lg-3 control-label">Phone:</label>
                         <div Class="col-md-6">
                             <input type="text" class="form-control" name="Phone" id="Phone" value="@Model.userInfo.Phone">
                         </div>
                     </div>
                 </div>
                 <div Class="col-md-6">
                     <div Class="form-group">
                         <label for="Email" class="col-lg-3 control-label">Email:</label>
                         <div Class="col-md-6">
                             <input type="text" class="form-control" name="Email" id="Email" value="@Model.userInfo.Email">
                         </div>
                     </div>
                     <div Class="form-group">
                         <label for="Github" class="col-lg-3 control-label">Github:</label>
                         <div Class="col-md-6">
                             <input type="text" class="form-control" name="Github" id="Github" value="@Model.userInfo.GitHub">
                         </div>
                     </div>
                     <div Class="form-group">
                         <label for="Twitter" class="col-lg-3 control-label">Twitter:</label>
                         <div Class="col-md-6">
                             <input type="text" class="form-control" name="Twitter" id="Twitter" value="@Model.userInfo.Twitter">
                         </div>
                     </div>
                     <div Class="form-group">
                         <label for="Facebook" class="col-lg-3 control-label">Facebook:</label>
                         <div Class="col-md-6">
                             <input type="text" class="form-control" name="Facebook" id="Facebook" value="@Model.userInfo.Facebook">
                         </div>
                     </div>
                     <div Class="form-group">
                         <label for="LinkedIn" class="col-lg-3 control-label">LinkedIn:</label>
                         <div Class="col-md-6">
                             <input type="text" class="form-control" name="LinkedIn" id="LinkedIn" value="@Model.userInfo.LinkedIn">
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

    $("#Styles").click(function () {

        $("#ThemesGroup").toggle()
    });

</script>