<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
    <div>
        <fieldset>
            <legend>商品資訊</legend>
            <table style="width: 100%;">
                <tr>
                    <td>商品名稱
                    </td>
                    <td>
                        <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="請輸入商品名稱"
                            ControlToValidate="txtProductName"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>重量
                    </td>
                    <td>
                        <asp:TextBox ID="txtProductWeight" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="請輸入商品重量"
                            ControlToValidate="txtProductWeight"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>長
                    </td>
                    <td>
                        <asp:TextBox ID="txtProductLength" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="請輸入商品長度"
                            ControlToValidate="txtProductLength"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>寬
                    </td>
                    <td>
                        <asp:TextBox ID="txtProductWidth" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="請輸入商品寬度"
                            ControlToValidate="txtProductWidth"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>高
                    </td>
                    <td>
                        <asp:TextBox ID="txtProductHeight" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="請輸入商品高度"
                            ControlToValidate="txtProductHeight"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>物流商
                    </td>
                    <td>
                        <asp:DropDownList ID="drpCompany" runat="server">
                            <asp:ListItem>請選擇</asp:ListItem>
                            <asp:ListItem Value="1">黑貓</asp:ListItem>
                            <asp:ListItem Value="2">新竹貨運</asp:ListItem>
                            <asp:ListItem Value="3">郵局</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="drpCompany"
                            InitialValue="請選擇" runat="server" ErrorMessage="請選擇物流商"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <asp:Button ID="btnCalculate" runat="server" Text="計算運費"
                OnClick="btnCalculate_Click" />
        </fieldset>
    </div>
    <div>
        <fieldset>
            <legend>結果</legend>物流商：<asp:Label ID="lblCompany" runat="server"></asp:Label>
            <br />
            運費：<asp:Label ID="lblCharge" runat="server"></asp:Label>
        </fieldset>
    </div>
</asp:Content>