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
<ul class="resumeInfo">
    <li>@ViewData("WorkHistory")</li>
    <li>@ViewData("Education")</li>
    <li>@ViewData("Skills")</li>
    <li>@ViewData("VolunteerWork")</li>
</ul>

@*Scripts*@
<script>

    $(document).ready(function () {
        $("#resume").addClass("active");
    });

</script>