<%@ Page Title="Home Page" Language="C#" 
    MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="Default.aspx.cs" Inherits="MovieWebsite.Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1>Movies</h1>
        <hr />

        <div class="row">
            <div class="col-md-3">
                <div class="form-group">
                    <label for="exampleFormControlInput1">Movie Name</label>
                    <asp:HiddenField ID="hid_movieId" runat="server" />
                    <asp:TextBox runat="server" class="form-control" ID="name" />
                </div>

                <div class="form-group">
                    <label for="exampleFormControlInput1">Release Year</label>
                    <asp:TextBox runat="server" TextMode="date" class="form-control" ID="date" />
                </div>

                <div class="form-group">
                    <label for="exampleFormControlTextarea1">Description</label>
                    <asp:TextBox class="form-control" ID="desc" mode="multiline" runat="server" />
                </div>

                <div class="form-group">
                    <label for="exampleFormControlInput1">Genere</label>
                    <asp:DropDownList ID="drp_genre" runat="server" CssClass="custom-select"></asp:DropDownList><br />
                </div>

                <div class="form-group">
                    <label for="exampleFormControlInput1">Director</label>
                    <asp:DropDownList ID="director_dropdown" TextMode="Multiple" type="multiple" runat="server" CssClass="custom-select"></asp:DropDownList>
                </div>
                <div class="form-group my-4">
                    <label class="col-md">Upload Poster</label>
                    <asp:FileUpload CssClass="btn btn-success col-md form-control-file custom-file" ID="FileUpload1" runat="server" />
                    <asp:Label Text="" ID="error_1" runat="server" />
                </div>
                <div class="d-flex form-group">
                    <asp:Button ID="add_btn" runat="server" Text="Add" CssClass="btn btn-primary col-md-6" OnClick="add_btn_Click" />
                    <asp:Button ID="delete_btn" Visible="false" runat="server" Text="Delete" CssClass="btn btn-danger col-md-6" OnClick="Delete_Click" />
                </div>
            </div>
            <div class="col-md-9">
                <asp:GridView ID="grid" runat="server" CssClass="table table-striped table-dark" OnRowDataBound="grd_movies_RowDataBound"></asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
