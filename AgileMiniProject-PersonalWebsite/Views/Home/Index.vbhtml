﻿@*
    Agile Mini Project - Personal Website
    Agile Programming
    Fall 2016
    Katie Cater, Lucas Lokken, Austing Prueher, Pheng Vang
*@

@Code

End Code

<h2>@ViewData("Title")</h2>
<h3>@ViewData("Message")</h3>
<p>@ViewData("Content")</p>

@*Scripts*@
<script>

    $(document).ready(function () {
        $("#home").addClass("active");
    });

</script>