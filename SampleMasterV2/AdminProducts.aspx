<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminProducts.aspx.cs" Inherits="SampleMasterV2.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <section class="page-section vh-100 bg-light" id="portfolio">
            <div class="container">
    <table class="auto-style1">
        <tr>
            <td><h2>Products Management</h2></td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridViewProducts" runat="server" BorderStyle="Solid" CaptionAlign="Top" CellPadding="4" HorizontalAlign="Left">
                    <HeaderStyle HorizontalAlign="Center" BackColor="#CCFFFF" />
                    <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
    <p><br />Product ID: <asp:TextBox ID="txtProdid" runat="server" AutoPostBack="True" OnTextChanged="txtProdid_TextChanged" Height="40px" Width="170px"></asp:TextBox></p>
    <p>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtProdid"></asp:RequiredFieldValidator>
        Product Name: <asp:TextBox ID="txtName" runat="server" Height="40px" Width="170px" Enabled="False" ></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtName"></asp:RequiredFieldValidator>
         
      
&nbsp;Category: 
       
          
        
        <asp:DropDownList ID="drpdwnCateg" runat="server" Height="40px" Width="170px" Enabled="False">
            <asp:ListItem Value="1">Select</asp:ListItem>
            <asp:ListItem>Bond Paper</asp:ListItem>
            <asp:ListItem>Cardstock</asp:ListItem>
            <asp:ListItem>Sticker Paper</asp:ListItem>
            <asp:ListItem>Photo Top</asp:ListItem>
        </asp:DropDownList>
&nbsp;Size:
        <asp:DropDownList ID="drpdwnSize" runat="server" Height="40px" Width="170px" Enabled="False">
            <asp:ListItem Value="1">Select</asp:ListItem>
            <asp:ListItem>A4</asp:ListItem>
            <asp:ListItem>Legal</asp:ListItem>
            <asp:ListItem>Letter</asp:ListItem>
        </asp:DropDownList>
&nbsp;</p>
    <p>
        GSM: <asp:TextBox ID="txtGsm" runat="server" Height="40px" Width="170px" Enabled="False"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtGsm"></asp:RequiredFieldValidator>
&nbsp; Price:
        <asp:TextBox ID="txtPrice" runat="server" Height="40px" Width="170px" Enabled="False"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="txtPrice"></asp:RequiredFieldValidator>
&nbsp;Stocks:
        <asp:TextBox ID="txtStock" runat="server" Height="40px" Width="170px" Enabled="False"></asp:TextBox>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="txtStock"></asp:RequiredFieldValidator>
        Safety Level: 
        <asp:TextBox ID="txtSafety" runat="server" Enabled="False" Height="40px" Width="170px"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ControlToValidate="txtSafety"></asp:RequiredFieldValidator>
&nbsp;Status:
        <asp:DropDownList ID="drpdwnStatus" runat="server" Height="40px" Width="170px" Enabled="False">
            <asp:ListItem Value="1">Select</asp:ListItem>
            <asp:ListItem>Available</asp:ListItem>
            <asp:ListItem>Not Available</asp:ListItem>
        </asp:DropDownList>
</p>
                <p>
                    <asp:label ID="txtsupp" runat="server" Visible="false">Supplier ID:</asp:label>
                    <asp:TextBox ID="txtSupplier" runat="server" Visible="False" Height="40px" Width="170px"></asp:TextBox>
</p>                
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ControlToValidate="txtSupplier"></asp:RequiredFieldValidator>
                <p>
                    <asp:Button ID="btnUpdateProd" runat="server" Visible="false" OnClick="btnUpdateProd_Click" Text="Update Product Details" />
&nbsp;<asp:Button ID="btnUpdateStocks" runat="server" Visible="false" OnClick="btnUpdateStocks_Click" Text="Update Stocks" />
&nbsp;</p>
    <p>
        <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Visible="false" Text="Update" />
&nbsp;<asp:Button ID="btnAdd" runat="server" Visible="false"  Text="Add Product" OnClick="btnAdd_Click" />
        <asp:Button ID="btnDelete" runat="server" Visible="false" Text="Delete Product" OnClick="btnDelete_Click" />
</p>
    <p>
        &nbsp;</p>
            </td>
        </tr>
        <tr>
            <td>
                <br />
            </td>
        </tr>
    </table>
                </div>
        </section>
</asp:Content>
