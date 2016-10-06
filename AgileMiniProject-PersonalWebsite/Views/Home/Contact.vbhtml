@ModelType ContactViewModel
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
        <section class="col-lg-4 sidebar">
            <p>@Model.userInfo.Name</p>
            <img class="img-responsive" src="@Url.Action("GetImage", "Admin")" alt="Profile Photo" />
            <a href="mailto:@Model.userInfo.Email"><i class="fa fa-envelope" aria-hidden="true"></i> Email</a>
            <a href="@Model.userInfo.Facebook"><i class="fa fa-facebook-official" aria-hidden="true"></i> Facebook</a>
            <a href="@Model.userInfo.Twitter"><i class="fa fa-twitter-square" aria-hidden="true"></i> Twitter</a>
            <a href="@Model.userInfo.LinkedIn"><i class="fa fa-linkedin-square" aria-hidden="true"></i> LinkedIn</a>
            <a href="@Model.userInfo.GitHub"><i class="fa fa-github-square" aria-hidden="true"></i> Github</a>
        </section>
        <div class="col-lg-8" id="maincontent">
            <h2>@ViewData("Title")</h2>
            <h3>@ViewData("Message")</h3>
            <form id="contact_form" action="#" method="POST" enctype="multipart/form-data">
                <div class="row">
                    <label for="name">Your name:</label><br />
                    <input id="name" class="input" name="name" type="text" value="" size="30" /><br />
                </div>
                <div class="row">
                    <label for="email">Your email:</label><br />
                    <input id="email" class="input" name="email" type="text" value="" size="30" /><br />
                </div>
                <div class="row">
                    <label for="message">Your message:</label><br />
                    <textarea id="message" class="input" name="message" rows="7" cols="30"></textarea><br />
                </div>
                <input id="submit_button" type="submit" value="Send email" />
            </form>
            <br />
        </div>
    </div>
</div>
<div class="col-lg-12">
    <hr />
    <footer class="footer text-center">
        <p>&copy; @DateTime.Now.Year - @Model.userInfo.Name</p>
    </footer>
</div>



@*Scripts*@
<script>

    $(document).ready(function () {

        $("#contact").addClass("active");

        var link = document.createElement("link");
        link.href = "../../@Model.styleSheet.StyleSheetLink";
        link.type = "text/css";
        link.rel = "stylesheet";
        document.getElementsByTagName("head")[0].appendChild(link);
    });

</script>
