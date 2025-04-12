<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminOrders.aspx.cs" Inherits="SampleMasterV2.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
        .auto-style2 {
            width: 100%;
            max-width: 1320px;
            --mdb-gutter-x: 1.5rem;
            --mdb-gutter-y: 0;
            height: 561px;
            margin-left: auto;
            margin-right: auto;
            padding-left: calc(var(--mdb-gutter-x)*0.5);
            padding-right: calc(var(--mdb-gutter-x)*0.5);
        }
        </style>

    <section class="page-section vh-100 bg-light" id="portfolio">
            <div class="auto-style2">
    <table>
    <tr>
        <td><h2>Orders</h2></td>
    </tr>
    <tr>
        <td class="auto-style5">
    <asp:GridView ID="GridViewOrders" runat="server" BorderStyle="Solid" CaptionAlign="Top" CellPadding="4" HorizontalAlign="Left">
        <HeaderStyle HorizontalAlign="Center" BackColor="#CCFFFF" />
        <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
    </asp:GridView>
        </td>
    </tr>
    <tr>
        <td class="auto-style1"></td>
    </tr>
    <tr>
        <td class="auto-style1">Order ID:
            <asp:TextBox ID="txtOrderid" runat="server" AutoPostBack="True" OnTextChanged="txtOrderid_TextChanged" Height="40px" Width="170px"></asp:TextBox>
            &nbsp;User ID: 
            <asp:TextBox ID="txtUserid" runat="server" Enabled="False" Height="40px" Width="170px"></asp:TextBox>
            &nbsp;Order Status: 
            <asp:DropDownList ID="drpdwnStatus" runat="server" Enabled="False" Height="40px" Width="170px">
                <asp:ListItem>Processing</asp:ListItem>
                <asp:ListItem>Shipping</asp:ListItem>
                <asp:ListItem>Done</asp:ListItem>
                <asp:ListItem>Cancelled</asp:ListItem>
            </asp:DropDownList>
            Payment Status: 
            <asp:DropDownList ID="drpdwnPayment" Enabled="false" runat="server" Height="40px" Width="170px"> 

                <asp:ListItem>Received</asp:ListItem>
                <asp:ListItem>Not received</asp:ListItem> 
            </asp:DropDownList>             <asp:Button ID="btnUpdate" runat="server" Text="Update" Visible="false" OnClick="btnUpdate_Click" Height="40px"/>
            </td>
    </tr>
    <tr>
        <td class="auto-style1">
        </td>
    </tr>
    <tr>
        <td><h2>Order Details</h2></td>
    </tr>

        <tr>
        <asp:GridView ID="GridViewOrderD" runat="server" BorderStyle="Solid" CaptionAlign="Top" CellPadding="4" HorizontalAlign="Left"><HeaderStyle HorizontalAlign="Center" BackColor="#CCFFFF" /><RowStyle HorizontalAlign="Center" VerticalAlign="Middle" /></asp:GridView>
        </tr>
    </table>
                </div>
        </section>
</asp:Content>
