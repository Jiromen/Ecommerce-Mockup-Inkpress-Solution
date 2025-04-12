<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminReviews.aspx.cs" Inherits="SampleMasterV2.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>

    <section class="page-section vh-100 bg-light" id="portfolio">
            <div class="container">
    <table class="auto-style1">
        <tr>
            <td><h2>Reviews Management</h2></td>
        </tr>
        <tr>
            <td>
    <asp:GridView ID="GridViewReviews" runat="server" BorderStyle="Solid" CaptionAlign="Top" CellPadding="4" HorizontalAlign="Left" Width="992px">
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
                <p style="vertical-align: middle">
                    Review ID:
                    <asp:TextBox ID="txtRevid" runat="server" AutoPostBack="True" OnTextChanged="txtRevid_TextChanged" Height="40px" Width="170px"></asp:TextBox>
&nbsp;Name:
                    <asp:TextBox ID="txtName" runat="server" Enabled="False" Height="40px" Width="170px"></asp:TextBox>
&nbsp;Order ID:
                    <asp:TextBox ID="txtOrderid" runat="server" Enabled="False" Height="40px" Width="170px"></asp:TextBox>
&nbsp;Status:
                    <asp:DropDownList ID="drpdwnStatus" runat="server" Enabled="False" Height="40px" Width="170px">
                        <asp:ListItem>Show</asp:ListItem>
                        <asp:ListItem>Hide</asp:ListItem>
                    </asp:DropDownList>
                </p>
                <p style="vertical-align: top">
                    Review:
                    <asp:TextBox ID="txtRevmsg" runat="server" Enabled="False" Height="80px" Width="700px"></asp:TextBox>
                </p>
                <p style="vertical-align: top">
                    <asp:Button ID="btnUpdate" runat="server" Visible="false" OnClick="btnUpdate_Click" Text="Update" PostBackUrl="~/AdminReviews.aspx" />
                </p>
            </td>
        </tr>
    </table>
    <br />
                </div>
        </section>
</asp:Content>
