<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="MovieWebsite.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="margin-top: 60px">
        <div class="col-md-6 offset-md-3">
            <div class="jumbotron">
                <h2><%: Title %>.</h2>
                <div class="form-group">
                    <label for="name">Name</label>
                    <asp:TextBox ID="name" runat="server" class="form-control" ></asp:TextBox>

                </div>
                <div class="form-group">
                    <label for="address">Address</label>
                    <asp:TextBox ID="address" runat="server"  class="form-control"> </asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="phone">Phone</label>
                    <asp:TextBox ID="phone" runat="server"  class="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="email">Email</label>
                    <asp:TextBox ID="email" runat="server"  class="form-control"></asp:TextBox>
                </div>
                <div class="form-group">

                    <label for="gender">Gender</label>
                    <asp:RadioButton GroupName="gender" ID="male" runat="server" Text="Male" />
                    <asp:RadioButton GroupName="gender" ID="female" runat="server" Text="Female" />
                </div>
                <%--<br />
                <br />
                <label for="faculty">Faculty</label>
                <asp:DropDownList ID="drp_list" runat="server">
                </asp:DropDownList>
                <br />
                <br />--%>
                <textarea name="comment" cols="50" rows="5">Enter text here...</textarea><br />

                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" CssClass="btn btn-primary" Text="Send" Style="background: blue; padding: 10px; color: #fff" />
                <br />
                <br />
                <asp:Label Text="Render Text" ID="render" runat="server"></asp:Label>

            </div>
        </div>
            <asp:GridView ID="grid_student" runat="server" CssClass="table table-striped"></asp:GridView>
            <%--<asp:Button runat="server" ID="dl" CssClass="btn btn-danger" OnClick="Del_Item" Text="Delete All Record" OnClientClick="Del_Item" />--%>
       

    </div>

</asp:Content>
