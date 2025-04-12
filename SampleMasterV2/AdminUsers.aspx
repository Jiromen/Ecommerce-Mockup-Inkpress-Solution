<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminUsers.aspx.cs" Inherits="SampleMasterV2.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <section class="page-section vh-100 bg-light" id="portfolio">
            <div class="container">
     <table class="auto-style1">
        <tr>
            <td><h2>Users Management</h2></td>
        </tr>
        <tr>
            <td><asp:GridView ID="GridViewUsers" runat="server" BorderStyle="Solid" CaptionAlign="Top" CellPadding="4" HorizontalAlign="Left">
            <HeaderStyle HorizontalAlign="Center" BackColor="#CCFFFF" />
            <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
    </asp:GridView>

            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
    <p>
        User ID: <asp:TextBox ID="txtUserid" runat="server" AutoPostBack="True" OnTextChanged="txtUserid_TextChanged" Height="40px" Width="170px"></asp:TextBox>

    </p>
    <p style="vertical-align: middle">
        Name:
        <asp:TextBox ID="txtUsername" runat="server" Enabled="False" Height="40px" Width="170px"></asp:TextBox>
&nbsp;Telephone Number:
        <asp:TextBox ID="txtTelnum" runat="server" Enabled="False" Height="40px" Width="170px"></asp:TextBox>
&nbsp;Email:
        <asp:TextBox ID="txtEmail" runat="server" Enabled="False" Height="40px" Width="170px"></asp:TextBox>

    </p>
    <p style="vertical-align: middle">
        Role:
        <asp:TextBox ID="txtRole" runat="server" Enabled="False" Height="40px" Width="170px"></asp:TextBox>
&nbsp;Status:
        <asp:DropDownList ID="drpdwnStatus" runat="server" Enabled="False" Height="40px" Width="170px">
            <asp:ListItem>Active</asp:ListItem>
            <asp:ListItem>Inactive</asp:ListItem>
        </asp:DropDownList>

    </p>
    <p style="vertical-align: middle">
        <asp:Button ID="btnUpdate" runat="server" Visible="false" Height="40px" OnClick="btnUpdate_Click" Text="Update" />

    </p>
            </td>
        </tr>
    </table>
                </div>
        </section>
</asp:Content>
