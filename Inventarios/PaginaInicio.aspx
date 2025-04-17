<%@ Page Title="" Language="C#" MasterPageFile="~/Inventario.Master" AutoEventWireup="true" CodeBehind="PaginaInicio.aspx.cs" Inherits="Inventarios.PaginaInicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main class="main-content  mt-0">
      <div style="background-color: gray;">
        <% #region Cuerpo %>
        <div class="my-1 align-content-center">
          <div visible="false">
            <h3 class="text-white"></h3>
          </div>
          <div class="p-2">
            <div class="row">
              <div class="col-md-5">
                  <img src="../img/Logo_Sitio.png" class="img-fluid border-radius-lg" alt="Responsive image">
              </div>
              <div class="col-md-2">
                  <h3 class="text-white" id="TextoCentral" runat="server"></h3>
              </div>
              <div class="col-md-5 p-5">
                  <img src="../img/Logo_Empresa.png" class="img-fluid border-radius-lg" alt="Responsive image">
              </div>
            </div>
          </div>
        </div>
        <% #endregion %>
      </div>
    </main>
</asp:Content>
