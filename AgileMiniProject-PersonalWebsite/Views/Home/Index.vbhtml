@ModelType AboutViewModel
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
            <section class="col-lg-12" id="maincontent">
                <h2>@ViewData("Title")</h2>
                <h3>@ViewData("Message")</h3>
                <p>@ViewData("Content")</p>
                <p>@ViewData("Content2")</p>
                <p>@ViewData("Content3")</p>
                <p>@ViewData("Content4")</p>
                <p>@ViewData("Content5")</p>
                <p>@ViewData("Content6")</p>
            </section>
        </div>
    </div>
    <div class="col-lg-12">
        <hr />
        <footer class="footer text-center">
            <p>&copy; @DateTime.Now.Year - @Model.userInfo.Name</p>
        </footer>
    </div>
</div>

@*Scripts*@
<script>

    $(document).ready(function () {

        $("#home").addClass("active");

        var link = document.createElement("link");
        link.href = "../../@Model.styleSheet.StyleSheetLink";
        link.type = "text/css";
        link.rel = "stylesheet";
        document.getElementsByTagName("head")[0].appendChild(link);
    });

</script>
