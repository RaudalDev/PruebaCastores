<%@ Page Title="" Language="C#" MasterPageFile="~/Inventario.Master" AutoEventWireup="true" CodeBehind="Historial.aspx.cs" Inherits="Inventarios.Historial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="my-4 align-content-center" id="SecHistorialGerente" runat="server">
      <div visible="false">
        <h3 class="text-white"></h3>
      </div>
      <div>
        <h3 class="text-white text-center" style="background-color: #e91e63">Historial</h3>
      </div>
      <div class="p-4">
        <div class="row">
          <div class="col-md-2">
            <h6 class="text-white">Todos:</h6>
            <div class="form-check">
              <input class="form-check-input" style="background-color: white" type="radio" name="flexRadioDefault2" id="rdbTodos" checked="" runat="server">
              <label class="custom-control-label text-white" for="customRadio1"></label>
            </div>
          </div>
          <div class="col-md-2">
            <h6 class="text-white">Entradas:</h6>
            <div class="form-check">
              <input class="form-check-input" style="background-color: white" type="radio" name="flexRadioDefault2" id="rdbEntradas" runat="server">
              <label class="custom-control-label text-white" for="customRadio2"></label>
            </div>
          </div>
          <div class="col-md-2">
            <h6 class="text-white">Salidas:</h6>
            <div class="form-check">
              <input class="form-check-input" style="background-color: white" type="radio" name="flexRadioDefault2" id="rdbSalidas" runat="server">
              <label class="custom-control-label text-white" for="customRadio2"></label>
            </div>
          </div>
          <div class="col-md-2">
            <h6 class="text-white"></h6>
          </div>
          <div class="col-md-4">
            <div class="text-center align-content-end">
              <asp:button type="button" class="btn bg-gradient-success w-100 my-4 mb-2" runat="server" id="btnBuscar" Text="Buscar" OnClick="btnBuscar_Click"></asp:button>
            </div>
          </div>
        </div>
      </div>
      <div class="card">
        <div class="table-responsive" style="overflow: auto; max-height: 500px">
          <asp:GridView CssClass="table align-items-center mb-0 text-center text-dark" HeaderStyle-BackColor="#d91333" HeaderStyle-ForeColor="White" ID="grvHistorial" runat="server" AutoGenerateColumns="false">
            <AlternatingRowStyle BackColor="LightGray" />
            <Columns>
                <asp:BoundField HeaderText="Folio" DataField="idHistorial" ReadOnly="true" />
                <asp:BoundField HeaderText="Movimiento" DataField="descripcion" ReadOnly="true" />
                <asp:BoundField HeaderText="Tipo movimiento" DataField="movimiento" ReadOnly="true" />
                <asp:BoundField HeaderText="Usuario Modifico" DataField="usuario" ReadOnly="true" />
                <asp:BoundField HeaderText="Producto" DataField="producto" ReadOnly="true" />
                <asp:BoundField HeaderText="Fecha y Hora" DataField="fechaMovimiento" ReadOnly="true" />
            </Columns>
        </asp:GridView>
        </div>
      </div>
    </div>
</asp:Content>
