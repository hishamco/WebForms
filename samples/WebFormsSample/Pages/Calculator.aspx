<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>@Model.Title - @Model.ApplicationName</title>
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
                <a class="navbar-brand">@Model.ApplicationName</a>
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
        <h1>@Model.Title</h1>
        <form method="post" class="form-inline">
            <asp:TextBox Name="txtNumber1" CssClass="form-control"></asp:TextBox>
            <asp:TextBox Name="txtNumber2"  CssClass="form-control"></asp:TextBox><br /><br />
            <asp:Button Name="btnAdd" CssClass="btn btn-default" Text="Add" Command="Button_Command" CommandName="Add"></asp:Button>
            <asp:Button Name="btnSub" CssClass="btn btn-default" Text="Sub" Command="Button_Command" CommandName="Sub"></asp:Button>
            <asp:Button Name="btnMul" CssClass="btn btn-default" Text="Mul" Command="Button_Command" CommandName="Mul"></asp:Button>
            <asp:Button Name="btnDiv" CssClass="btn btn-default" Text="Div" Command="Button_Command" CommandName="Div"></asp:Button><br /><br />
            <span class="label label-info">
                <asp:Literal Name="litResult"></asp:Literal>
            </span>
        </form>
        <hr />
        <footer>
            <p>&copy; @DateTime.Now.Year - @Model.ApplicationName</p>
        </footer>
    </div>
    <script src="https://ajax.aspnetcdn.com/ajax/jquery/jquery-2.1.4.min.js"></script>
    <script src="https://ajax.aspnetcdn.com/ajax/bootstrap/3.3.5/bootstrap.min.js"></script>
</body>
</html>