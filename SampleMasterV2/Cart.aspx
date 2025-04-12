<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="SampleMasterV2.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <section class="vh-100 h-custom gradient-custom-5">
        <div class="container py-5 h-100" >
            <div class="row-10 d-flex justify-content-center align-items-center h-100">
                <div class="card card-registration card-registration-3" style="border-radius: 15px;">
                    <div class="card-body p-6">
                        <div class="container p-5">
                            <asp:Button ID="btnBack" runat="server" Text="Back to Product Menu" Enabled="true" class="btn btn-light btn-lg"  data-mdb-ripple-color="dark" OnClick="btnBack_Click" />
                            <label></label>
                            <asp:GridView ID="GridViewCart" class="table table-striped table-info thead-dark"  style="border-radius: 15px" runat="server" Width="930px" HorizontalAlign="Center">
                            </asp:GridView>
                            <br />
                            <div class="row">
                                <div class="col-md-2 mb-1 pb-1">
                                    <div class="form-outline">
                                        <label>Edit Cart</label>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-2 mb-1 pb-1">
                                <div class="form-outline">
                                
                                <asp:TextBox ID="txtprodid" runat="server" class="form-control-lg" AutoPostBack="True" OnTextChanged="txtprodid_TextChanged" Width="101px" Height="30px"></asp:TextBox>
                                <label class="form-label" for="txtprodid">Order Id</label>

                                </div>
                                </div>
                                <div class="col-md-2 mb-1 pb-1">
                                <div class="form-outline">
                                
                                <asp:TextBox ID="txtqty" runat="server" style="border-radius: 8px;" class="form-control-lg" AutoPostBack="True" Enabled="False" OnTextChanged="txtqty_TextChanged" Width="101px"  Height="30px"></asp:TextBox>
                                <label class="form-label" for="txtqty">Quantity</label>

                                </div>
                                </div>
                                <div class="col-md-2 mb-1 pb-1">
                                <div class="form-outline">
                                
                                <asp:TextBox ID="txttotal" class="form-control-lg" runat="server" style="border-radius: 8px;" Enabled="False" Width="101px" Height="30px"></asp:TextBox>
                                <label class="form-label" for="txttotal">Total</label>

                                </div>
                                </div>

                            </div>                          


                            <asp:Button ID="UpdateBtn" class="btn btn-light btn-dark" runat="server" Text="Update" Visibile="False"  OnClick="UpdateBtn_Click" />
                            <asp:Button ID="DeleteBtn" class="btn btn-light btn-dark" runat="server" Text="Delete" Visibile="False" OnClick="DeleteBtn_Click" />
                            <asp:Button ID="CheckOutBtn" class="btn btn-light btn-dark" runat="server" Text="Check Out" Visibile="False" Enabled="True" OnClick="CheckOutBtn_Click" />
                        </div>
                        </div>
                    </div>
                </div>
            </div>
    </section>
</asp:Content>
