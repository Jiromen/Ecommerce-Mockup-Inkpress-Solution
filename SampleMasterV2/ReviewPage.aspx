<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ReviewPage.aspx.cs" Inherits="SampleMasterV2.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

<section class="vh-100 h-custom gradient-custom-5">
  <div class="container py-5 h-100" style="height: 505px">
    <div class="row-10 d-flex justify-content-center align-items-center h-100">
      <div class="auto-style2">
        <div class="card card-registration card-registration-2" style="border-radius: 15px; left: 0px; top: 0px; width: 1232px;">
          <div class="card-body p-6">
            <div class="row g-0">
              <div class="col-lg-6"> 
            <h3 class="fw-normal mb-5" style="color: #4835d4;">Customer Reviews</h3>
            <asp:GridView ID="GridViewR" class="table table-striped table-info thead-dark"  runat="server" Width="1190px" HorizontalAlign="Center"></asp:GridView>
              </div>
            </div>
          </div>            
        </div>        
      </div>          
     </div>
   </div>
</section>
</asp:Content>
