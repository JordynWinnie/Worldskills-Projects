<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TemperatureRecording.aspx.cs" Inherits="Covid19WebApp.TemperatureRecording" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            Temperature Recording</p>
        Name:<asp:TextBox ID="nameTb" runat="server" Width="467px"></asp:TextBox>
&nbsp;<p>
            Email:<asp:TextBox ID="emailTb" runat="server"></asp:TextBox>
        </p>
        <p>
            Contact:<asp:TextBox ID="contactTb" runat="server"></asp:TextBox>
        </p>
        <p>
            Temperature:<asp:TextBox ID="temperatureTb" runat="server"></asp:TextBox>
        </p>
        <p>
            Floor Number:<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Height="16px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="474px">
            </asp:DropDownList>
        </p>
        <p>
            Unit Number:<asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" Height="26px" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" Width="488px">
            </asp:DropDownList>
        </p>
        <p>
            <asp:Label ID="locationLabel" runat="server" Text="Label"></asp:Label>
        </p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Record Temperature" Width="597px" />
    </form>
</body>
</html>
