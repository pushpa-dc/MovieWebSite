<%@ Page Title="Login" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.cs" Inherits="MovieWebsite.Login" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row login">
        <div class="col-md-12 text-center my-4 ">
            <a href="/">
                <img src="logo.PNG" />
            </a>
            <hr />
        </div>
        <div class="col-md-6">
            <h1>Login</h1>
            <div class="block-wrap">
                <div class="form-group col-md-10">
                    <asp:Panel ID="msg_error" runat="server" Visible="false">
                    </asp:Panel>
                </div>
                <div class="form-group">
                    <label class="col-md-12 control-label" for="<%:txt_UserName.ClientID%>">User Name</label>
                    <div class="col-md-10">
                        <asp:TextBox ID="txt_UserName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-md-2 control-label" for="<%:txt_Password.ClientID%>">Password</label>
                    <div class="col-md-10">
                        <asp:TextBox ID="txt_Password" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-10">
                        <asp:Button ID="btn_Login" CssClass="btn btn-primary btn-lg" Text="Login" runat="server" OnClick="btn_Login_Click"></asp:Button>
                    </div>
                </div>
            </div>

        </div>
        <div class="col-md-6">
            <div class="line">
                <span class="or">OR</span>
                <h1>Sign Up</h1>
                <div class="row no-gutters">
                    <div class="form-group col-md-12">
                        <asp:Label ID="msg_error1" CssClass="bg-danger d-flex w-100 text-light p-2" Text="Please fill form properly" runat="server" Visible="false" />
                    </div>
                    <div class="form-group col-md-6">
                        <label class="col-md-12 control-label" for="<%:txt_UserName.ClientID%>"></label>
                        <div class="col-md-12">
                            <asp:TextBox ID="firstName" CssClass="form-control" placeholder="First Name" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group col-md-6">
                        <label class="col-md-12 control-label" for="<%:txt_UserName.ClientID%>"></label>
                        <div class="col-md-12">
                            <asp:TextBox ID="lastName" placeholder="Last Name" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group col-md-12">
                        <label class="col-md-12 control-label" for="UserSign"></label>
                        <div class="col-md-12">
                            <asp:TextBox ID="UserName" placeholder="User Name" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group col-md-12">
                        <label class="col-md-12 control-label" for="UserSign"></label>
                        <div class="col-md-12">
                            <asp:TextBox ID="UserPassword" placeholder="Password" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group my-4">
                        <label class="col-md">Upload Profile</label>
                        <asp:FileUpload CssClass="btn btn-success col-md form-control-file custom-file" ID="FileUploadSign" runat="server" />
                        <asp:Label Text="" ID="error_1" runat="server" />
                    </div>

                    <div class="form-group col-md-12">
                        <div class="col-md-12">
                            <asp:Button ID="btn_SignUp" CssClass="btn btn-success btn-lg" Text="Sign Up" runat="server" OnClick="btn_SignUp_Click"></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
