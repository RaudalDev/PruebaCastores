<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Inventarios._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main class="main-content  mt-0">
      <div class="page-header align-items-start min-vh-100" style="background-color: gray;">
        <span class="mask bg-gradient-dark opacity-6"></span>
        <div class="container my-auto">
          <div class="row">
            <div class="col-lg-4 col-md-8 col-12 mx-auto">
              <div class="card z-index-0 fadeIn3 fadeInBottom">
                <div class="card-header p-0 position-relative mt-n4 mx-3 z-index-2">
                  <div class="bg-gradient-secondary shadow-primary border-radius-lg py-3 pe-1">
                    <div class=" col-lg-12 col-md-8 col-12 mx-auto">
                        <h2 class="text-white font-weight-bolder text-center mt-2 mb-0">Inventario</h2>
                    </div>
                    <h4 class="text-white font-weight-bolder text-center mt-2 mb-0">Inicio de Sesión</h4>
                  </div>
                </div>
                <div class="card-body">
                  <form role="form" class="text-start">
                    <div class="input-group input-group-static my-3">
                      <label>Correo:</label>
                      <input id="txtUsuario" name="txtUsuario" runat="server" type="text" class="form-control">
                    </div>
                    <div class="input-group input-group-static mb-3">
                      <label>Contraseña:</label>
                      <input id="txtPassword" name="txtPassword" runat="server" type="password" class="form-control">
                    </div>
                    <div class="alert alert-danger text-white" role="alert" id="Alerta" runat="server" visible="false">
                        <strong>¡Alerta! -</strong> Usuario y/o Contraseña No Válidos.
                    </div>
                    <div class="text-center">
                      <asp:button type="button" class="btn bg-gradient-primary w-100 my-4 mb-2" runat="server" id="InicioSesion" OnClick="InicioSesion_Click" Text="Iniciar Sesión"></asp:button>
                    </div>
                  </form>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </main>

</asp:Content>
