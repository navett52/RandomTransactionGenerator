<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Calendar ID="calDate" runat="server" OnSelectionChanged="calDate_SelectionChanged"></asp:Calendar>
        <asp:TextBox ID="txtTime" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnGenerateTrans" runat="server" Text="Generate Transaction" OnClick="btnGenerateTrans_Click" />
        <asp:Button ID="btnAddTrans" runat="server" Text="Add Transaction" OnClick="btnAddTrans_Click" />
    </div>
    </form>
</body>
</html>
