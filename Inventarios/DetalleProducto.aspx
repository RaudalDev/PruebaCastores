<%@ Page Title="" Language="C#" MasterPageFile="~/Inventario.Master" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="Inventarios.DetalleProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main class="main-content  mt-0" style="background-color: dimgrey;">
        <div style="background-color: gray;">
            <div>
              <h3 class="modal-title font-weight-normal text-white">Detalle Producto</h3>
            </div>
            <div visible="false">
              <h3 class="text-white"></h3>
            </div>
            <div class="p-4">
                <div class="row">
                  <div class="col-md-1">
                    <h6 class="text-white"></h6>
                  </div>
                  <div class="col-md-5">
                    <h6 class="text-white">Numero Producto:</h6>
                    <div class="input-group input-group-outline mb-4">
                      <input id="txtNoProd" runat="server" type="text" class="form-control text-black" style="background-color: white" disabled>
                    </div>
                  </div>
                  <div class="col-md-5">
                    <h6 class="text-white">Producto:</h6>
                    <div class="input-group input-group-outline mb-4">
                      <input id="txtProducto" runat="server" type="text" class="form-control text-black" style="background-color: white" disabled>
                    </div>
                  </div>
                  <div class="col-md-1">
                    <h6 class="text-white"></h6>
                  </div>
                </div>
                <div class="row" id="AgregarExist" runat="server" visible="false">
                  <div class="col-md-1">
                    <h6 class="text-white"></h6>
                  </div>
                  <div class="col-md-5">
                    <h6 class="text-white">Existencias Actuales:</h6>
                    <div class="input-group input-group-outline mb-4">
                      <input id="txtExistenciasAct" runat="server" type="text" class="form-control text-black" style="background-color: white" disabled>
                    </div>
                  </div>
                  <div class="col-md-5">
                    <h6 class="text-white">Cantidad A Agregar:</h6>
                    <div class="input-group input-group-outline mb-4">
                      <input id="txtCantidadAgr" runat="server" type="number" class="form-control text-black" style="background-color: white">
                    </div>
                  </div>
                  <div class="col-md-1">
                    <h6 class="text-white"></h6>
                  </div>
                </div>
                <div class="row" id="RegistrarSalidas" runat="server" visible="false">
                  <div class="col-md-1">
                    <h6 class="text-white"></h6>
                  </div>
                  <div class="col-md-5">
                    <h6 class="text-white">Existencias Actuales:</h6>
                    <div class="input-group input-group-outline mb-4">
                      <input id="txtExistenciasActualesS" runat="server" type="text" class="form-control text-black" style="background-color: white" disabled>
                    </div>
                  </div>
                  <div class="col-md-5">
                    <h6 class="text-white">Cantidad Por Salir:</h6>
                    <div class="input-group input-group-outline mb-4">
                      <input id="txtCantidadSalida" runat="server" type="number" class="form-control text-black" style="background-color: white">
                    </div>
                  </div>
                  <div class="col-md-1">
                    <h6 class="text-white"></h6>
                  </div>
                </div>
                <div class="row" id="BotonesAgregarExist" runat="server" visible="false">
                  <div class="col-md-1">
                    <h6 class="text-white"></h6>
                  </div>
                  <div class="col-md-3">
                    <div class="text-center align-content-end">
                      <asp:button type="button" class="btn bg-gradient-success w-100 my-4 mb-2" runat="server" id="btnAgregarExistencias" Text="Agregar Existencia" OnClick="btnAgregarExistencias_Click"></asp:button>
                    </div>
                  </div>
                  <div class="col-md-4">
                    <h6 class="text-white"></h6>
                  </div>
                  <div class="col-md-3">
                    <div class="text-center align-content-end">
                      <asp:button type="button" class="btn bg-gradient-primary w-100 my-4 mb-2" runat="server" id="btnVolver" Text="Volver" OnClick="btnVolver_Click"></asp:button>
                    </div>
                  </div>
                  <div class="col-md-1">
                    <h6 class="text-white"></h6>
                  </div>
                </div>
                <div class="row" id="BotonesRegistrarSalida" runat="server" visible="false">
                  <div class="col-md-1">
                    <h6 class="text-white"></h6>
                  </div>
                  <div class="col-md-3">
                    <div class="text-center align-content-end">
                      <asp:button type="button" class="btn bg-gradient-success w-100 my-4 mb-2" runat="server" id="btnRegistrarSalida" Text="Registrar Salida" OnClick="btnRegistrarSalida_Click"></asp:button>
                    </div>
                  </div>
                  <div class="col-md-4">
                    <h6 class="text-white"></h6>
                  </div>
                  <div class="col-md-3">
                    <div class="text-center align-content-end">
                      <asp:button type="button" class="btn bg-gradient-primary w-100 my-4 mb-2" runat="server" id="btnVolverEnt" Text="Volver" OnClick="btnVolverEnt_Click"></asp:button>
                    </div>
                  </div>
                  <div class="col-md-1">
                    <h6 class="text-white"></h6>
                  </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
