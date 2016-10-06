@ModelType AdminViewModel
@*
    Agile Mini Project - Personal Website
    Agile Programming
    Fall 2016
    Katie Cater, Lucas Lokken, Austing Prueher, Pheng Vang
*@

@Code

End Code

<div Class="panel panel-default form-horizontal">
    <div class="panel-body">
         <div Class="col-md-12 text-center">
             <h2>@ViewData("Title")</h2>
             <h3>@ViewData("Message")</h3>
             <h3>@ViewData("Error")</h3>
            </div>
    </div>
</div>      

@Using (Html.BeginForm("UploadPhoto", "Admin", Nothing, FormMethod.Post, New With {.enctype = "multipart/form-data"}))

    @Html.AntiForgeryToken()

    @<div Class="panel panel-default form-horizontal">
         <div Class="col-md-12" id="ProfilePhoto">
             <h3>Profile Photo</h3>
         </div>
        <div class="panel-body">
            <div  id="ProfilePhotoGroup" hidden>
                <div Class="form-group">
                    @Html.Label("File:", New With {.class = "control-label col-md-2"})
                    <div Class="col-md-10">
                        <input type="file" id="Avatar" name="upload" Class="btn btn-default" />
                    </div>
                </div>
                <div Class="form-group">
                    <div Class="col-md-offset-2 col-md-10">
                        <input type = "submit" value="Upload Photo" Class="btn btn-default" />
                    </div>
                </div>
            </div>
        </div>
    </div>
End Using

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

<script>

    $(document).ready(function () {

        $("#admin").addClass("active");

        var link = document.createElement("link");
        link.href = "../../@Model.styleSheet.StyleSheetLink";
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

</script>