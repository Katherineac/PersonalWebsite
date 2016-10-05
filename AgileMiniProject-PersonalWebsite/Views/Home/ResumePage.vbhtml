@ModelType ResumeViewModel
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
            <img class="img-responsive" src="~/Images/profile-pictures-14.jpg" />
            <a href="mailto:@Model.userInfo.Email"><i class="fa fa-envelope" aria-hidden="true"></i> Email</a>
            <a href="@Model.userInfo.Facebook"><i class="fa fa-facebook-official" aria-hidden="true"></i> Facebook</a>
            <a href="@Model.userInfo.Twitter"><i class="fa fa-twitter-square" aria-hidden="true"></i> Twitter</a>
            <a href="@Model.userInfo.LinkedIn"><i class="fa fa-linkedin-square" aria-hidden="true"></i> LinkedIn</a>
            <a href="@Model.userInfo.GitHub"><i class="fa fa-github-square" aria-hidden="true"></i> Github</a>
        </section>
        <div class="col-lg-8" id="maincontent">
            <h2>@ViewData("Title")</h2>
            <h4>@ViewData("Message")</h4>
            <br />
            <div>
                <h3>@ViewData("Experience")</h3>
                <ul>
                    @For Each experience In Model.experience
                        @<li>@experience.CompanyName @experience.CompanyCity, @experience.CompanyState - @experience.CompanyPosition @experience.CompanyStartDate - @experience.CompanyEndDate</li>
                    Next
                </ul>
            </div>
            <br />
            <div>
                <h3>@ViewData("Education")</h3>
                <ul>
                    @For Each education In Model.education
                        @<li>@education.SchoolName @education.SchoolCity, @education.SchoolState - @education.DegreeEarned - @education.DegreeYear</li>
                    Next
                </ul>
            </div>
            <br />
            <div>
               <h3>@ViewData("Skills")</h3>
                <ul>
                    @For Each skill In Model.skill
                        @<li>@skill.SkillType - @skill.SkillName</li>
                    Next
                </ul>
            </div>
            <br />
            <div>
                <h3>@ViewData("VolunteerExperience")</h3>
            </div>
        </div>
    </div>
    <hr />
    <footer class="footer text-center">
        <p>&copy; @DateTime.Now.Year - @Model.userInfo.Name</p>
    </footer>
</div>

@*Scripts*@
<script>

    $(document).ready(function () {

        $("#resume").addClass("active");

        var link = document.createElement("link");
        link.href = "../../@Model.styleSheet.StyleSheetLink";
        link.type = "text/css";
        link.rel = "stylesheet";
        document.getElementsByTagName("head")[0].appendChild(link);

    });

</script>
