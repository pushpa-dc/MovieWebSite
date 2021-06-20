<%@ Page Title="Movies" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Movies.aspx.cs" Inherits="MovieWebsite.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="py-2">Movies</h1>
    <hr />
    <asp:DataList runat="server" ID="datalist" RepeatColumns="4" CellPadding="2">
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

                td {
                    width: 300px;
                    padding: 15px;
                }

                .checked {
                    color: orange;
                }
            </style>
            <a href="/Detail?id=<%# Eval("Id")%>">
                <div class="card">
                    <%# Eval("Poster")%>
                    <div class="card-body">
                        <h5 class="card-title text-warning"><%# Eval("Movie")%></h5
                        <hr />
                        <p class="card-text">Release Year : <%# Eval("Release Year")%></p>
                        <hr />
                        <span class="fa fa-star checked"></span>
                        <span class="fa fa-star checked"></span>
                        <span class="fa fa-star checked"></span>
                        <span class="fa fa-star"></span>
                        <span class="fa fa-star"></span>
                    </div>
                </div>

            </a>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
