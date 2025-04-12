<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="SampleMasterV2.WebForm11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

<section class="page-section vh-100 gradient-custom-5">
    <div class="container py-5 h-100" style="height: 505px">
        <div class="row-10 d-flex justify-content-center align-items-center h-100">
            <div class="auto-style2">
                <div class="card card-registration card-registration-2" style="border-radius: 15px; left: 0px; top: 0px; width: 1232px;">
                  <div class="card-body p-6">
                    <div class="row">
                        <div class="container p-5 " >
                            <h3 class="fw-normal mb-5" style="color: #4835d4;">My Orders</h3>
                            <asp:GridView ID="GridViewOrder" style="border-radius: 15px" class="table table-striped table-info thead-dark" runat="server" Width="1100px"></asp:GridView>
                        </div>
                    </div>

                    <div class="row">
                        <div class="container p-5" >
                            <div class="col-md-6 mb-4 pb-2 mb-md-0 pb-md-0">
                                <h3 class="fw-normal mb-4" style="color: #4835d4;">View Order Details</h3>
                                <asp:TextBox ID="txtOrderid" runat="server"  class="form-control form-control-lg" AutoPostBack="True" Width="150" OnTextChanged="txtOrderid_TextChanged"></asp:TextBox>

                                <label class="form-label" for="txtOrderid">Enter Order ID</label>
                            </div>

                            <div class="col-md-6 mb-4 pb-2 mb-md-0 pb-md-0">
                                <asp:GridView ID="GridViewOrderD" class="table table-striped table-info thead-dark" runat="server" Width="1100px"></asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
              </div>
            </div>
        </div>
    </div>
</section>
</asp:Content>
