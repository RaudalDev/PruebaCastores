<%@ Page Title="" Language="C#" MasterPageFile="~/Inventario.Master" AutoEventWireup="true" CodeBehind="Inventario.aspx.cs" Inherits="Inventarios.Inventario1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main class="main-content  mt-0" style="background-color: dimgrey;">
        <div style="background-color: gray;">
            <% #region Cuerpo %>
            <div class="my-4 align-content-center" id="SecHistorialSupervisor" runat="server">
              <div visible="false">
                <h3 class="text-white"></h3>
              </div>
              <div>
                <h3 class="text-white text-center" style="background-color: #e91e63">Inventario</h3>
              </div>
              <div visible="false">
                <h3 class="text-white"></h3>
              </div>
              <div class="p-1">
                <div class="row" id="BotonAltaProd" runat="server" visible="false">
                  <div class="col-md-9">
                    <h6 class="text-white"></h6>
                  </div>
                  <div class="col-md-3">
                    <div class="text-center align-content-end">
                      <button type="button" class="btn bg-gradient-primary w-100 my-4 mb-2" data-bs-toggle="modal" data-bs-target="#modal-Producto">Agregar Producto</button>
                    </div>
                  </div>
                </div>
              </div>
              <div class="card">
                <div class="table-responsive" style="overflow: auto; max-height: 500px">
                  <asp:GridView CssClass="table align-items-center mb-0 text-center text-dark" HeaderStyle-BackColor="#d91333" HeaderStyle-ForeColor="White" ID="grvInventarioAdmin" runat="server" AutoGenerateColumns="false" OnRowCommand="grvInventarioAdmin_RowCommand" OnRowEditing="grvInventarioAdmin_RowEditing" Visible="false">
                    <AlternatingRowStyle BackColor="LightGray" />
                    <Columns>
                        <asp:CommandField HeaderText="Agregar Existencia" ShowSelectButton="true" SelectText="Agergar" ControlStyle-CssClass="btn btn-outline-success" />
                        <asp:BoundField HeaderText="Num. Producto" DataField="idProducto" ReadOnly="true" />
                        <asp:BoundField HeaderText="Producto" DataField="nombre" ReadOnly="true" />
                        <asp:BoundField HeaderText="Existencias (Pzs)" DataField="cantidadExistencia" ReadOnly="true" />
                        <asp:BoundField HeaderText="Estatus" DataField="descEstatus" ReadOnly="true" />
                        <asp:CommandField HeaderText="Cambiar Estatus" ShowEditButton="true" EditText="Cambiar" ControlStyle-CssClass="btn btn-outline-info" />
                    </Columns>
                </asp:GridView>
                </div>
              </div>
              <div class="card">
                <div class="table-responsive" style="overflow: auto; max-height: 500px">
                  <asp:GridView CssClass="table align-items-center mb-0 text-center text-dark" HeaderStyle-BackColor="#d91333" HeaderStyle-ForeColor="White" ID="grvInventarioAlmas" runat="server" AutoGenerateColumns="false" OnRowCommand="grvInventarioAlmas_RowCommand" Visible="false">
                    <AlternatingRowStyle BackColor="LightGray" />
                    <Columns>
                        <asp:CommandField HeaderText="Salida Producto" ShowSelectButton="true" SelectText="Dar Salida" ControlStyle-CssClass="btn btn-outline-success" />
                        <asp:BoundField HeaderText="Num. Producto" DataField="idProducto" ReadOnly="true" />
                        <asp:BoundField HeaderText="Producto" DataField="nombre" ReadOnly="true" />
                        <asp:BoundField HeaderText="Existencias (Pzs)" DataField="cantidadExistencia" ReadOnly="true" />
                    </Columns>
                </asp:GridView>
                </div>
              </div>
            </div>
            <% #endregion %>
            <% #region Modales Especiales %>
            <div class="col-md-4">
              <div class="modal fade" id="modal-Producto" tabindex="-1" role="dialog" aria-labelledby="modal-Producto" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered modal-" role="document">
                  <div class="modal-content">
                    <div class="modal-body p-0">
                      <div class="card card-plain">
                        <div class="card-header pb-0 text-center">
                          <h4 class="">Nuevo Producto.</h4>
                          <p class="mb-0">Ingresa El Nombre Del Producto.</p>
                        </div>
                        <div class="card-body">
                          <main class="main-content  mt-0" style="background-color: dimgrey;">
                            <div style="background-color: dimgrey;">
                                <div class="modal-body font-weight-light my-4">
                                  <div class="p-4">
                                    <div class="row">
                                      <div class="col-md-1">
                                        <h6 class="text-white"></h6>
                                      </div>
                                      <div class="col-md-12">
                                        <h6 class="text-white">Nombre Producto:</h6>
                                        <div class="input-group input-group-outline mb-4">
                                          <input id="txtNombreProducto" runat="server" type="text" class="form-control text-black" style="background-color: white">
                                        </div>
                                      </div>
                                      <div class="col-md-1">
                                        <h6 class="text-white"></h6>
                                      </div>
                                    </div>
                                    <div class="row">
                                      <div class="col-md-2">
                                        <h6 class="text-white"></h6>
                                      </div>
                                      <div class="col-md-8">
                                        <div class="text-center align-content-end">
                                          <asp:button type="button" class="btn btn btn-primary w-100 my-4 mb-2" runat="server" id="btnNuevoProducto" Text="Registrar Producto" OnClick="btnNuevoProducto_Click"></asp:button>
                                        </div>
                                      </div>
                                      <div class="col-md-2">
                                        <h6 class="text-white"></h6>
                                      </div>
                                    </div>
                                  </div>
                                </div>
                              </div>
                          </main>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <% #endregion %>
        </div>
    </main>
</asp:Content>
