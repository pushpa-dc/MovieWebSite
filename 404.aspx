<%@ Page Title="Not Found" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="404.aspx.cs" Inherits="MovieWebsite._404" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div class="ag-page-404">
  <div class="ag-toaster-wrap">
    <div class="ag-toaster">
      <div class="ag-toaster_back"></div>
      <div class="ag-toaster_front">
        <div class="js-toaster_lever ag-toaster_lever"></div>
      </div>
      <div class="ag-toaster_toast-handler">
        <div class="ag-toaster_shadow"></div>
        <div class="js-toaster_toast ag-toaster_toast js-ag-hide"></div>
      </div>
    </div>

    <canvas id="canvas-404" class="ag-canvas-404"></canvas>
    <img class="ag-canvas-404_img" src="https://raw.githubusercontent.com/SochavaAG/example-mycode/master/pens/404-error-smoke-from-toaster/images/smoke.png">
  </div>
</div>
    <a href="/Movies.aspx">Go Back</a>
</asp:Content>
