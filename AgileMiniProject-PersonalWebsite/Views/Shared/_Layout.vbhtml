@*
    Agile Mini Project - Personal Website
    Agile Programming
    Fall 2016
    Katie Cater, Lucas Lokken, Austing Prueher, Pheng Vang
*@

<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>@ViewBag.Title</title>
        <link href="~/Content/bootstrap.css" rel="stylesheet" />
        <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
        <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css">
        <link href="~/Content/Site.css" rel="stylesheet" />
        @Scripts.Render("~/bundles/modernizr")
        @Scripts.Render("~/bundles/jquery")
        @Scripts.Render("~/bundles/bootstrap")
        @RenderSection("scripts", required:=False)
    </head>
    <body>
        <div class="navbar navbar-inverse navbar-fixed-top">
            <div class="container">
                <div class="navbar-header nav">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                </div>
                <div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav">
                        <li id="home">@Html.ActionLink("Home", "Index", "Home")</li>
                        <li id="resume">@Html.ActionLink("Resume", "ResumePage", "Home")</li>
                        <li id="projects">@Html.ActionLink("Projects", "Projects", "Home")</li>
                        <li id="contact">@Html.ActionLink("Contact", "Contact", "Home")</li>
                        @If Request.IsAuthenticated Then
                        @<li id = "admin" >@Html.ActionLink("Admin", "Admin", "Admin")</li>
                        End If
                    </ul>
                    @Html.Partial("_LoginPartial")
                </div>
            </div>
        </div>
        <div class="container body-content">
            @RenderBody()
        </div>
    </body>
</html>

