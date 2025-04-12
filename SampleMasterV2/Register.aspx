<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SampleMasterV2.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <style type="text/css">
        .btn-custom {
            color: #000;
            background-color: #3572d4;
            border-color: #3572d4;
        }
        </style>

<section class="vh-100 h-custom gradient-custom-5">
  <div class="container py-5 h-100">
    <div class="row-10 d-flex justify-content-center align-items-center h-100">
      <div class="col-11">
        <div class="card card-registration card-registration-2" style="border-radius: 15px;">
          <div class="card-body p-0">
            <div class="row g-0">
              <div class="col-lg-6"> 
                  <!--left part-->
                <div class="p-5">
                  <h3 class="fw-normal mb-5" style="color: #4835d4;">Personal Information</h3>
                  <!-- firstname at lasname-->
                    <div class="row"> 
                    <!--fname-->
                      <div class="col-md-6 mb-1 pb-1">

                      <div class="form-outline">
                            <asp:TextBox ID="txtfirstname" runat="server" class="form-control form-control-lg"></asp:TextBox>
                            <label class="form-label" for="txtfirstname">First name</label>
                      </div>
                        <div id ="RFVfname" class="form-text">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtfirstname" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        </div>
                    <!--lname-->
                    <div class="col-md-6 mb-1 pb-1">

                        <div class="form-outline">
                        <asp:TextBox ID="txtlastname" runat="server"  class="form-control form-control-lg"></asp:TextBox>
                        <label class="form-label" for="txtlastname">Last name</label>
                        </div>
                        <div id ="RFVlname" class="form-text">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtlastname" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                      </div>
                    </div>

                  

                  <div class="row"> <!--PhoneNumber/dating businessarea with dropdown-->
                       <!--PhoneNumber-->
                    <div class="col-md-6 mb-4 pb-2 mb-md-0 pb-md-0">
                       
                        <div class="form-outline">
                           <asp:TextBox ID="txtnumber" runat="server" class="form-control form-control-lg"></asp:TextBox>
                            <label class="form-label" for="txtnumber">Phone Number</label>
                        </div>
                        <div id ="RFVnum" class="form-text">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtnumber" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtnumber" ForeColor="Red" ErrorMessage="Enter a valid contact number." ValidationExpression="^\d{11}"></asp:RegularExpressionValidator>
                        </div>
                     </div>
                  </div>
                    <!--email/dating position-->
                 <div class="mb-2 pb-1"> 
                    <div class="form-outline">
                      <asp:TextBox ID="txtemail" runat="server" class="form-control form-control-lg"></asp:TextBox>
                      <label class="form-label" for="txtemail">Email</label>
                    </div>
                    <div id ="RFVemail" class="form-text">
                    <asp:RegularExpressionValidator ID="RegEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Enter a valid E-mail Address." ForeColor="Red" ValidationExpression="^\w{1,}\@\w{1,}\.[a-z]{2,}"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="Rfvemail" runat="server" ControlToValidate="txtEmail" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                 </div>

             <div class="mb-4 pb-1"> <!--password-->
                <div class="form-outline">
                      <asp:TextBox ID="txtpassword" type="password" runat="server" class="form-control form-control-lg"></asp:TextBox>
                      <label class="form-label" for="txtpassword">Password</label>
                 </div>
                 <div id ="RFVpass" class="form-text">
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtpassword" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
               </div>

                </div>
              </div> <!--end ng left part -->







             <!-- full address part-->
              <div class="col-lg-6 bg-indigo text-white"> 
                <div class="p-5">
                  <h3 class="fw-normal mb-5">Full Address</h3>

                  <div class="mb-3 pb-1"> <!--street part-->
                    <div class="form-outline form-white">
                        <asp:TextBox type="text" ID="txtstreet" runat="server" class="form-control form-control-lg"></asp:TextBox>
                      <label class="form-label" for="txtstreet">Street</label>
                    </div>
                      <div id ="RFVstreetname" class="form-text">
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtstreet" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                      </div>
                  </div>

                  <div class="mb-3 pb-2"> <!--barangay part-->
                    <div class="form-outline form-white">
                        <asp:TextBox ID="txtbrgy" runat="server" class="form-control form-control-lg"></asp:TextBox>
                      <label class="form-label" for="txtbrgy">Barangay</label>
                    </div>
                      <div id ="RFVbrgyname" class="form-text">
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtbrgy" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                      
                  </div>

            <div class="row">
                <div class="col-md-5 mb-3 pb-2"> <!--zip-->

                    <div class="form-outline form-white">
                            <asp:TextBox id="txtzip" runat="server" class="form-control form-control-lg"></asp:TextBox>
                            <label class="form-label" for="txtzip">Zip Code</label>
                    </div>
                    <div id ="RFVzipname" class="form-text">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtzip" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtzip"  ErrorMessage="4 digits only." ForeColor="Red" ValidationExpression="^\d{4}"></asp:RegularExpressionValidator>
                    </div>
                </div>
                    <div class="col-md-7 mb-3 pb-2"> <!--city-->

                      <div class="form-outline form-white">   
                          <asp:TextBox ID="txtcity" runat="server" class="form-control form-control-lg"></asp:TextBox>
                        <label class="form-label" for="txtcity">City</label>
                      </div>
                        <div id ="RFVcityname" class="form-text">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtcity" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
             </div>

                <div class="mb-3 pb-2">
                    <div class="form-outline form-white"> <!--Province-->
                    <asp:TextBox ID="txtprovince" runat="server" class="form-control form-control-lg"></asp:TextBox>
                      <label class="form-label" for="txtprovince">Province</label>
                    </div>
                    <div id ="RFVprovincee" class="form-text">
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtprovince" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>


                    <asp:Button ID="RegisterBtn" runat="server" Text="Register" class="btn btn-light btn-lg"  data-mdb-ripple-color="dark" OnClick="RegisterBtn_Click"/>
                
                    <asp:Button ID="ClearBtn" runat="server" Text="Clear"  class="btn btn-custom btn-lg"  data-mdb-ripple-color="dark" OnClick="ClearBtn_Click" UseSubmitBehavior="False" CausesValidation="False" />
                </div>
              </div> <!-- end ng rightpart-->
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</section>

</asp:Content>
