<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ReviewForm.aspx.cs" Inherits="SampleMasterV2.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <style type="text/css">
  .wide {
      height:100%;
     width:100%;
     min-width:100%;
  }
        </style>

<section class="page-section vh-100 gradient-custom-5" id="portfolio">
<div class="row d-flex justify-content-center mt-5 p-5">
    <div class="col-md-6">
      <div class="card card-body py-m-5 " style="border-radius: 15px;"">
        <div> <asp:GridView ID="GridViewOrder" class="table" style="border-radius: 15px" runat="server"></asp:GridView>
        <div class="card-body m-7 bg-primary" style="border-radius:15px" >
         <div class="fw-bold lead mb-5 text-white">Leave a review here</div>
          <div class="row-10 d-flex justify-content-center align-items-center h-100">   

            <div class="col-lg-8">
              <table class="table">
                    <thead class="text-white fw-normal mb-5">
                    </thead>
                        <tr>
                            <td><asp:TextBox ID="txtOrderid" runat="server" class="form-control form-control-lg" OnTextChanged="txtOrderid_TextChanged" AutoPostBack="True"></asp:TextBox> <label class="form-label text-white" for="txtorderid">Enter your Order ID here</label></td>
                        <td></td>
                        <td></td>
                            <td></td>
                        </tr>

                        
                     <tbody>
                        <tr>
                        <td><div class="form-group green-border-focus">
                            <label for="exampleFormControlTextarea4"></label>
                            <asp:TextBox ID="txtRevmsg" runat="server" class="form-control form-control-lg" textmode="MultiLine" Enabled="False"></asp:TextBox>
                                <label class="form-label text-white" for="txtOrderid">Enter your message here</label>
                        </div></td>
                        <th scope="col"></th>
                        <td>
                        <td></td>
                        </tr>
                         <tr><td><asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-light btn-lg" OnClick="btnSubmit_Click" /></td>
                             <td></td>
                             <td></td>
                             <td></td>
                         </tr>
                    </tbody>
                    </table>
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

