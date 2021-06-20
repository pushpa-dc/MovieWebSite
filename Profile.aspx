<%@ Page Title="User Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="MovieWebsite.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView runat="server" ID="user_view" CssClass="table table-striped table-dark my-5" OnRowDataBound="user_view_RowDataBound"></asp:GridView>

    <asp:DataList runat="server" ID="userdata" RepeatColumns="1" CellPadding="1">
        <ItemTemplate>
            <style runat="server">
                a {
                    text-decoration: none !important;
                }

                .poster {
                    border: 0px;
                }

                img {
                    width: 100%;
                    height: 100%;
                }

                .userp {
                    width: 200px;
                    height: 200px;
                    border-radius:0px !important;
                }

                td {
                    width: 200%;
                    padding: 15px;
                }

                .media {
                    background: #000;
                    color: white !important;
                }

                .checked {
                    color: orange;
                }
            </style>

            <div class="media p-4">
                <div class="align-self-center mr-3"><%# Eval("Image")%></div>
                <div class="media-body p-2">
                    <h5 class="mt-0 text-warning font-weight-bold"><%# Eval("First Name")%></h5>
                    <p>Name : <%# Eval("First Name")%> <%# Eval("Last Name")%></p>
                    <p>User Name : <%# Eval("User Name")%></p>
                    <p>Create Date: <%# Eval ("Created Date")%></p>
                    <p>Password: <%# Eval("Password") %></p>
                </div>
            </div>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>


