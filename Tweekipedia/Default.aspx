﻿<%@ page language="C#" autoeventwireup="true" codebehind="Default.aspx.cs" inherits="Tweekipedia._Default" culture="auto" uiculture="auto" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>Tweekipedia</title>
    <meta charset="utf-8">
    <meta name="description" content="Wikipediaをクールにツイートできるサービス。">
    <meta name="author" content="KamoKamo">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="shortcut icon" href="favicon.ico">
    <link rel="stylesheet" href="style.css">

    <!-- OGP -->
    <meta property="og:url" content="https://tweekipedia.azurewebsites.net/" />
    <meta property="og:title" runat="server" id="og_title" />
    <meta property="og:type" content="article">
    <meta property="og:description" content="<%= GetGlobalResourceObject("Resources", "description") %>" />
    <meta property="og:image" id="og_image" runat="server" />
    <meta name="twitter:card" content="summary" />
    <meta name="twitter:site" content="@tweekipedia_" />
    <meta property="og:site_name" content="Tweekipedia" />
</head>

<body>
    <asp:literal id="body_script" runat="server"></asp:literal>
    <noscript>
        <h1 style="color:red;">
            Sorry, this service is not available when you disable JavaScript.
        </h1>
    </noscript>
        <div class="center">
            <img alt="Tweekipedia Logo" src="Logos/ogp_default.png" /><br />
            <!-- The Wikipedia logo is from wikipedia.org -->
            <%= GetGlobalResourceObject("Resources", "description") %>
        </div>
        <h3>
            <%= GetGlobalResourceObject("Resources", "firstMsg") %>
        </h3>
            <div class="center">
                <input id="wikiurl_text" type="text" required oninput="input_event();" />
                <span id="input_error_span" style="display:none;">
                    <br />
                    <%= GetGlobalResourceObject("Resources", "input_error") %> 
                </span>
            </div>
            <h3>
                <%= GetGlobalResourceObject("Resources", "secondMsg") %>
            </h3>
            <div class="center">
                <button id="tweet" type="button" onclick="tweet();" disabled>
                    <%= GetGlobalResourceObject("Resources", "tweet") %> 
                </button>
                <br /><br />

                <input type="text" readonly id="copy_text" />
                <button type="button" id="copy_btn" onclick="copy_event();" disabled >
                    <%= GetGlobalResourceObject("Resources", "copy") %> 
                </button>
                <span id="copy_done_span" style="display:none;">
                    <br />
                    <%= GetGlobalResourceObject("Resources", "copy_done") %> 
                </span>
                <br /><br />
                <hr />
<a rel="license" href="http://creativecommons.org/licenses/by-sa/4.0/"><img alt="Creative Commons License" style="border-width:0" src="https://i.creativecommons.org/l/by-sa/4.0/88x31.png" /></a><br />This work is licensed under a <a rel="license" href="http://creativecommons.org/licenses/by-sa/4.0/">Creative Commons Attribution-ShareAlike 4.0 International License</a>.
                <br /><br />
                © 2019 <a href="https://comradeKamoKamo.github.io">KamoKamo</a> <br>
        This service's GitHub repository is <a href="https://github.com/comradeKamoKamo/Tweekipedia">here</a>.
            </div>
    <script src="main.js"></script>
</body>

</html>
