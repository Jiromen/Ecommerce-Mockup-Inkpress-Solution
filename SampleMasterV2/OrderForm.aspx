<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="OrderForm.aspx.cs" Inherits="SampleMasterV2.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <style type="text/css">
        .btn-custom2 {
            color: #000;
            background-color: #bb1161;
            border-color: #bb1161;
            
        }
        .btn-custom3 {
            color: #000;
            background-color: #d44835;
            border-color: #d44835; 
        }
        .auto-style2 {
            flex: 0 0 auto;
            width: 99%;
        }
        </style>

<section class="vh-100 h-custom gradient-custom-5">
  <div class="container py-5 h-100" style="height: 505px">
    <div class="row-10 d-flex justify-content-center align-items-center h-100">
      <div class="auto-style2">
        <div class="card card-registration card-registration-2" style="border-radius: 15px; left: 0px; top: 0px; width: 1232px;">
          <div class="card-body p-6">
            <div class="row g-0">
              <div class="col-lg-6"> 
                  <!--left part-->
                <div class="p-5">
                  <h3 class="fw-normal mb-5" style="color: #d44835;">Cart</h3>
             <div class="row"> 
                <div class="col-md-6 mb-1 pb-1"> <!--dropdown products w/ quantity-->
                    <div class="form-outline">
                        <asp:DropDownList ID="drpdwnProduct" style="border-radius: 8px;" class="form-control form-control-lg"  runat="server" DataTextField="a" Width="213px" Height="45px" DataSourceID="SqlDataSource1" CssClass="auto-style4"></asp:DropDownList> 
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT prod_id as [a] FROM product_tbl where prod_status='Available'"></asp:SqlDataSource>
                        <label class="form-label" for="drpdwnProduct">Select Product ID</label>
                     </div>
                </div>
                    <!--quantity-->
                    <div class="col-md-6 mb-4 pb-2 mb-md-0 pb-md-0">

                        <div class="form-outline">
                        <asp:TextBox ID="txtquantity" runat="server"  class="form-group form-control-lg" AutoPostBack="True" OnTextChanged="txtquantity_TextChanged"></asp:TextBox>
                        <label class="form-label" for="txtquantity">Enter Quantity</label>
                        </div>
                        <div id ="RFVquantity" class="form-text">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtquantity" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                      </div>
            </div>
                
                <div class="row"> <!--Total-->
                       <!--TotalCost-->
                    <div class="col-md-6 mb-4 pb-2 mb-md-0 pb-md-0">
                        <div class="form-outline" >
                           <label class="form-label" for="txtTotal">Item Total: </label>
                           <asp:TextBox ID="txtTotal" style="border-radius: 8px; text-align:center" runat="server" Enabled="false" Height="41px" Width="107px"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                    <div class="col-md-6 mb-5 pb-2 mb-md-0 pb-md-0">
                        <div class="form-outline">
                            <br />
                            <asp:Button ID="addCart" runat="server" Text="Add to Cart" Visible="false" Enabled="false" class="btn btn-dark btn-lg"  data-mdb-ripple-color="dark" OnClick="addCart_Click" />
                        </div>
                    </div>
                  </div>
                </div>
              </div> <!--end ng left part -->
             <!-- full address part-->
                <div class="col-lg-6 bg-orderright text-white"> 
                <div class="p-5">
               
                    <div>
                        <asp:GridView ID="GridViewProducts" runat="server" BackColor="#76b5c5" style="border-radius: 15px"  ForeColor="Black" Height="139px" HorizontalAlign="Center" Width="512px">
                            <AlternatingRowStyle BackColor="#ABDBE3" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <HeaderStyle HorizontalAlign="Center" BackColor="#1AC7E6" />
                            <RowStyle HorizontalAlign="Center" />
                        </asp:GridView>
                    </div>
                    <br/>
                    <asp:Button ID="goCart" runat="server" Text="View Cart" class="btn btn-light btn-lg"  data-mdb-ripple-color="dark" OnClick="goCart_Click" CausesValidation="False" ValidateRequestMode="Disabled" />

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
