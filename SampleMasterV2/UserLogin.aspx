<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="SampleMasterV2.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <link href="bootstrap/css/styles.css" rel="stylesheet" />

<section class="vh-100 gradient-custom-5">
  <div class="container py-5 h-100 ">
    <div class="row-10 d-flex justify-content-center align-items-center h-100">
        <!--row-5 d-flex justify-content-center align-items-center h-50-->
      <div class="col-md-6 col-lg-5 col-xl-5">
        <img src="pics/loginimage.jpg"
          class="img-fluid rounded-pill shadow-2-strong" alt="LoginImage">
      </div>
      <div class="col-md-7 col-lg-6 col-xl-4 offset-xl-1">

          <!-- Email input -->
          <div class="form-outline mb-2"> 
            <asp:TextBox ID="txtemail" runat="server" class="form-control form-control-lg"></asp:TextBox>
            <label class="form-label" for="txtemail">Email address</label>
            
          </div>
          <div id ="RFVemail" class="form-text ">
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtemail" ErrorMessage="Email is required" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
          <!-- Password input -->
          <div class="form-outline mb-2">
            <asp:TextBox ID="txtpassword" runat="server" TextMode="Password" class="form-control form-control-lg"> </asp:TextBox>
            <label class="form-label" for="txtpassword">Password</label>
               
          </div>
               <div id ="RFVpass" class="form-text">  
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtpassword" ErrorMessage="Password is required" ForeColor="Red"></asp:RequiredFieldValidator>
               </div>
          <div class ="form-outline mb-2">
            <asp:Label ID="Label2" runat="server" Text="The e-mail address or password you entered is incorrect." forecolor="Red" Visible="False"></asp:Label>
          </div>
              
       <div class="d-flex justify-content-between align-items-center" role="alert">
         

          <div class="text-center text-lg-start mt-4 pt-2">
            <asp:Button ID = "LoginButton" type="button" class="btn btn-primary btn-lg text-uppercase" 
              style="padding-left: 2.5rem; padding-right: 2.5rem;" runat="server" Text ="Login" OnClick="LoginButton_Click"/>
            <p class="small fw-bold mt-2 pt-1 mb-0">Don't have an account? <a href="Register.aspx"
                class="link-danger">Register</a></p>
           </div>
            


        </div>
          </div>
        </div>
      </div>
        
</section>
</asp:Content>
