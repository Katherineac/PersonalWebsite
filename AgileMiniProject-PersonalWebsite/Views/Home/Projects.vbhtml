﻿@ModelType ProjectsViewModel
@*
    Agile Mini Project - Personal Website
    Agile Programming
    Fall 2016
    Katie Cater, Lucas Lokken, Austing Prueher, Pheng Vang
*@

@Code

End Code

<div class="col-lg-12">
    <div class="panel-body col-lg-12">
        <div class="col-lg-4 sidebarContainer">
            <section class="col-lg-12" id="sidebar">
                <p>@Model.userInfo.Name</p>
                <p><img class="img-responsive center" src="@Url.Action("GetImage", "Admin")" alt="Profile Photo" /></p>
                <a href="mailto:@Model.userInfo.Email"><i class="fa fa-envelope" aria-hidden="true"></i> Email</a>
                <a href="@Model.userInfo.Facebook"><i class="fa fa-facebook-official" aria-hidden="true"></i> Facebook</a>
                <a href="@Model.userInfo.Twitter"><i class="fa fa-twitter-square" aria-hidden="true"></i> Twitter</a>
                <a href="@Model.userInfo.LinkedIn"><i class="fa fa-linkedin-square" aria-hidden="true"></i> LinkedIn</a>
                <a href="@Model.userInfo.GitHub"><i class="fa fa-github-square" aria-hidden="true"></i> Github</a>
            </section>
        </div>
        <div class="col-lg-8 maincontentContainer">
            <div class="col-lg-12" id="maincontent">
                <h2>@ViewData("Title")</h2>
                <h3>@ViewData("Message")</h3>
                <div>
                <ul>
                    @For Each project In Model.projects
                        @<li><h3>@project.ProjectName</h3></li>
                        @<li>@project.ProjectDescription</li>
                        @<li><a href="@project.ProjectLink">@project.ProjectLink</a></li>
                        @<li><br /></li>
                    Next
                </ul>
            </div>
        </div>
    </div>
</div>
<div Class="col-lg-12">
    <hr />
    <footer Class="footer text-center">
        <p>&copy; @DateTime.Now.Year - @Model.userInfo.Name</p>
    </footer>
</div>


@*Scripts*@
<script>

    $(document).ready(function () {

        $("#projects").addClass("active");

        var link = document.createElement("link");
        link.href = "../../@Model.styleSheet.StyleSheetLink";
        link.type = "text/css";
        link.rel = "stylesheet";
        document.getElementsByTagName("head")[0].appendChild(link);

    });

</script>