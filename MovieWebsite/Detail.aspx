<%@ Page Title="Movie Detail" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="MovieWebsite.Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DataList runat="server" ID="datalist1" RepeatColumns="1" CellPadding="1">
        <ItemTemplate>
        <div class="row"> 
            <style runat="server">
                a {
                    text-decoration: none !important;
                }
                #MainContent_datalist1{
                   width:100%;
                   padding:30px;
                }
                .poster {
                    border: 0px;
                }

                img {
                    width: 100%;
                    height: 100%;
                }

                td {
                    width: 200%;
                    padding: 15px;
                }
                .row {
                    background-color: #000;
                }

                .media {
                    color: white !important;
                }
                 .checked {
                    color: orange;
                }
            </style>
            <div class="media">
                <div class="align-self-center mr-3"><%# Eval("Poster")%></div>
                <div class="media-body p-2">
                    <h5 class="mt-0 text-warning"><%# Eval("Movie")%></h5>
                    <p>Release Year : <%# Eval("Release Year")%></p>
                    <p>Director : <%# Eval("Director")%></p>
                    <p>Genre : <%# Eval("Genre")%></p>
                        <span class="fa fa-star checked"></span>
                        <span class="fa fa-star checked"></span>
                        <span class="fa fa-star checked"></span>
                        <span class="fa fa-star"></span>
                        <span class="fa fa-star"></span>
                    <p class="mb-0"><%#Eval("Description") %></p>
                </div>
            </div>
            </div>
        </ItemTemplate>
    </asp:DataList>

    <asp:DataList runat="server" ID="datalist2" RepeatColumns="3" CellPadding="1">
        <ItemTemplate>

            </ItemTemplate>
            </asp:DataList>
</asp:Content>
