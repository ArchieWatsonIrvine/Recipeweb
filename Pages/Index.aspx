<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <asp:DropDownList runat="server" ID="ddlang" AutoPostBack="true" OnSelectedIndexChanged="ddlang_SelectedIndexChanged">
            <asp:ListItem Text="English"></asp:ListItem>
            <asp:ListItem Text="Swedish"></asp:ListItem>
        </asp:DropDownList>

        <asp:DropDownList runat="server" ID="ddlrecipes" AutoPostBack="true" OnSelectedIndexChanged="ddlrecipes_SelectedIndexChanged"></asp:DropDownList>
        
        <br />
        Title: <asp:Literal runat="server" ID="lttitle"></asp:Literal><br />
        Server: <asp:Literal runat="server" ID="ltserves"></asp:Literal><br />
        Ingedents: <asp:Literal runat="server" ID="ltindegdents"></asp:Literal><br />
        Instructions: <asp:Literal runat="server" ID="ltinstructions"></asp:Literal><br />

    </div>
    </form>
</body>
</html>
