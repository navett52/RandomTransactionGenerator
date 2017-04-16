<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:RegularExpressionValidator ID="timeValRegex" runat="server" ControlToValidate="txtTimeOfTransaction" ErrorMessage="Please Enter a valid time in the format (HH:MM)" ValidationExpression="([0-1]?\d|2[0-3]):([0-5]?\d)(:([0-5]?\d))?"></asp:RegularExpressionValidator>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Calendar ID="calDate" runat="server" OnSelectionChanged="calDate_SelectionChanged"></asp:Calendar>
                    <br />
                    <label>Please Enter a valid time in the format (HH:MM)</label>
                    <br />
                    <label>Time of Transaction: </label><asp:TextBox runat="server" ID="txtTimeOfTransaction"></asp:TextBox><asp:RequiredFieldValidator ID="rfvTime" ControlToValidate="txtTimeOfTransaction" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Button ID="btnGenerateTrans" runat="server" Text="Generate Transaction" OnClick="btnGenerateTrans_Click" />
                    <br />
                    <table>
                        <tr>
                            <td><label>StoreID: </label></td>
                            <td><asp:TextBox runat="server" ID="txtStoreID" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><label>EmployeeID: </label></td>
                            <td><asp:TextBox runat="server" ID="txtEmployeeID" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><label>LoyaltyID: </label></td>
                            <td><asp:TextBox runat="server" ID="txtLoyaltyID" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><label>ProductID: </label></td>
                            <td><asp:TextBox runat="server" ID="txtProductID" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><label>CouponID: </label></td>
                            <td><asp:TextBox runat="server" ID="txtCouponID" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><label>Qty: </label></td>
                            <td><asp:TextBox runat="server" ID="txtQty" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><label>TransactionTypeID: </label></td>
                            <td><asp:TextBox runat="server" ID="txtTransactionTypeID" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><label>PricePerSellableUnitAsMarked: </label></td>
                            <td><asp:TextBox runat="server" ID="txtPricePerSellableUnitAsMarked" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><label>PricePerSellableUnitToCustomer: </label></td>
                            <td><asp:TextBox runat="server" ID="txtPricePerSellableUnitToCustomer" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><label>CouponDetailID: </label></td>
                            <td><asp:TextBox runat="server" ID="txtCouponDetailID" ReadOnly="True"></asp:TextBox></td>
                        </tr>                     
                    </table>
                    <asp:Button ID="btnAddTrans" Enabled="false" runat="server" Text="Add Transaction" OnClick="btnAddTrans_Click" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
