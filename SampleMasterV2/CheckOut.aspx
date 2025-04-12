<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CheckOut.aspx.cs" Inherits="SampleMasterV2.CheckOut" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <section class="vh-100 h-custom gradient-custom-5">
        <div class="container py-5 h-100" >
            <div class="row-10 d-flex justify-content-center align-items-center h-100">
                <div class="card card-registration card-registration-3" style="border-radius: 15px;">
                    <div class="card-body p-5">
                        <div class="row">
                            <div class="col-md-4 mb-0 pb-0">

                                <div class="form-outline">
                                    <asp:GridView ID="GridViewCart" class="table table-striped table-info thead-dark " runat="server" Width="1000px"></asp:GridView>
                                </div>
                            </div>
                        </div>

                        <div class="row"> 
                                <!--fname-->
                            <div class="col-md-3 mb-1 pb-1">

                                <div class="form-outline">
                                    <p><asp:TextBox ID="txtfirstname" style="border-radius: 8px;" Enabled="false" runat="server" Width="200px"  Height="40px"></asp:TextBox></p>
                                    <p><label class="form-label" for="txtfirstname">First Name</label></p>
                                </div>
                            </div>
                            <div class="col-md-3 mb-1 pb-1">

                                <div class="form-outline">
                                    <p><asp:TextBox ID="txtlastname" style="border-radius: 8px;" Enabled="false" runat="server" Width="200px"  Height="40px"></asp:TextBox></p>
                                    <p><label class="form-label" for="txtlastname">Last Name</label></p>

                                </div>
                            </div>
                            <div class="col-md-3 mb-1 pb-1">

                                <div class="form-outline">
                                    <p><asp:TextBox ID="txtnumber" style="border-radius: 8px;" Enabled="false" runat="server" Width="200px"  Height="40px"></asp:TextBox></p>
                                    <p><label class="form-label" for="txtnumber">Contact Number</label></p>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3 mb-0 pb-0">

                                <div class="form-outline">
                                    <p><asp:TextBox ID="txtstreet" style="border-radius: 8px;" Enabled="false" runat="server" Width="200px"  Height="40px"></asp:TextBox></p>
                                    <p><label class="form-label" for="txtstreet">Street</label></p>

                                </div>
                            </div>
                            <div class="col-md-3 mb-0 pb-0">

                                <div class="form-outline">
                                    <p><asp:TextBox ID="txtbrgy" style="border-radius: 8px;" Enabled="false" runat="server" Width="200px"  Height="40px"></asp:TextBox></p>
                                    <p><label class="form-label" for="txtbrgy">Barangay</label></p>

                                </div>
                            </div>
                            <div class="col-md-3 mb-0 pb-0">

                                <div class="form-outline">
                                    <p><asp:TextBox ID="txtcity" style="border-radius: 8px;" Enabled="false" runat="server" Width="200px"  Height="40px"></asp:TextBox></p>
                                    <p><label class="form-label" for="txtcity">City</label></p>

                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3 mb-0 pb-0">

                                <div class="form-outline">
                                    <p><asp:TextBox ID="txtprovince" style="border-radius: 8px;" Enabled="false" runat="server" Width="200px"  Height="40px"></asp:TextBox></p>
                                    <p><label class="form-label" for="txtprovince">Province</label></p>

                                </div>
                            </div>
                            <div class="col-md-3 mb-0 pb-0">

                                <div class="form-outline">
                                    <p><asp:TextBox ID="txtzip" style="border-radius: 8px;" Enabled="false" runat="server" Width="200px"  Height="40px"></asp:TextBox></p>
                                    <p><label class="form-label" for="txtcity">Zip Code</label></p>

                                </div>
                            </div>
                        </div>

                        <div class="row">
                                <div class="col-md-3 mb-1 pb-0">

                                    <div class="form-outline">
                                        <asp:DropDownList ID="drpdwnPayment" runat="server" style="border-radius: 8px;" AutoPostBack="true" OnSelectedIndexChanged="drpdwnPayment_SelectedIndexChanged" Width="200px"  Height="40px">
                                            <asp:ListItem>Cash</asp:ListItem>
                                            <asp:ListItem>Gcash</asp:ListItem>
                                            <asp:ListItem>Paymaya</asp:ListItem>
                                        </asp:DropDownList> 
                                        <p><label class="form-label" for="txtpayment" style="width: 233px">Payment Method</label></p>
                                    </div>
                                </div>
                                <div class="col-md-3 mb-1 pb-0">

                                    <div class="form-outline">
                                        <asp:TextBox ID="txtaccnum" style="border-radius: 8px;" Enabled="false" runat="server" Width="200px"  Height="40px"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Must enter valid number" ControlToValidate="txtaccnum" ValidationExpression="^\d{11}"></asp:RegularExpressionValidator>
                                        <p><label class="form-label" for="txtaccnum" style="width: 172px">Account Number</label></p>
                                    </div>
                                </div>
                                <div class="col-md-3 mb-0 pb-0">

                                    <div class="form-outline">
                                        <asp:TextBox ID="txtTotal" style="border-radius: 8px;" Enabled="false" runat="server" Width="200px"  Height="40px"></asp:TextBox>
                                        <p><label class="form-label" for="txttotal">Total</label></p>
                                    </div>
                                </div>
                                <div class="form-outline">
                                    <asp:Button ID="PlaceOrder" class="btn btn-custom btn-lg text-bg-dark" runat="server" OnClick="PlaceOrderBtn_Click" Text="Place Order" />
                                </div>
                            </div>
            </div>
            </div>
        </div>
        </div>
    </section>
</asp:Content>
