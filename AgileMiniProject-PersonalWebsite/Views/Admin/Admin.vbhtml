@ModelType AdminViewModel
@*
    Agile Mini Project - Personal Website
    Agile Programming
    Fall 2016
    Katie Cater, Lucas Lokken, Austing Prueher, Pheng Vang
*@

@Code

End Code

<h2>@ViewData("Title")</h2>
<h3>@ViewData("Message")</h3>

@Using (Html.BeginForm("UploadPhoto", "Admin", Nothing, FormMethod.Post, New With {.enctype = "multipart/form-data"}))

    @Html.AntiForgeryToken()

    @<div Class="form-group">
            @Html.Label("Avatar", New With {.class = "control-label col-md-2"})
             <div Class="col-md-10">
                 <input type="file" id="Avatar" name="upload" />
             </div>
         </div>
    @<div Class="form-group">
            <div Class="col-md-offset-2 col-md-10">
                <input type = "submit" value="Upload Photo" Class="btn btn-default" />
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

</script>