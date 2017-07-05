<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>{{title}} - {{applicationName}}</title>
    <link rel="stylesheet" href="https://ajax.aspnetcdn.com/ajax/bootstrap/3.3.5/css/bootstrap.min.css" />
</head>
<body style="padding-top: 70px;">
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand">{{applicationName}}</a>
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <li><a href="/">Home</a></li>
                    <li><a href="/Calculator">Calculator</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="container body-content">
        <h1>{{title}}</h1>
        <form method="post">
            <asp:CheckBox Name="cbWebForms" Text="WebForms"></asp:CheckBox><br/>
            <asp:CheckBox Name="cbMVC" Text="MVC"></asp:CheckBox><br/>
            <asp:RadioButton Name="rbCS" GroupName="Languages" Text="C#"></asp:RadioButton><br/>
            <asp:RadioButton Name="rbFS" GroupName="Languages" Text="F#"></asp:RadioButton><br/>
            <asp:RadioButton Name="rbVB" GroupName="Languages" Text="VB"></asp:RadioButton><br/>
            <asp:Literal Name="litGreeting"></asp:Literal><br />
            <asp:Button Name="btnPost" CssClass="btn btn-primary" Text="Post"></asp:Button>
            <span class="label label-info">
                <asp:Literal Name="litPostBack" Text="IsPostBack: False"></asp:Literal>
            </span>
        </form>
        <hr />
        <footer>
            <p>&copy; 2017 - {{applicationName}}</p>
        </footer>
    </div>
    <script src="https://ajax.aspnetcdn.com/ajax/jquery/jquery-2.1.4.min.js"></script>
    <script src="https://ajax.aspnetcdn.com/ajax/bootstrap/3.3.5/bootstrap.min.js"></script>
</body>
</html>