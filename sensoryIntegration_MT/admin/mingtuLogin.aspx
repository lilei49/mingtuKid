<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="sensoryIntegration_MT.admin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>明途感统管理平台</h3>
            <div>
                <asp:Label ID="Label1" runat="server" Text="账号："></asp:Label>
                <asp:TextBox ID="userName" runat="server" Text="请输入账号"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label2" runat="server" Text="密码："></asp:Label>
                <asp:TextBox ID="pwd" runat="server" Text="请输入密码"></asp:TextBox>
            </div>
            <asp:Button ID="Button1" runat="server" Text="Button" />
        </div>
    </form>
</body>
</html>
