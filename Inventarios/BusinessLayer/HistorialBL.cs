using Inventarios.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using Inventarios.DataLayer;

namespace Inventarios.BusinessLayer
{
    public class HistorialBL
    {
        public List<HistorialMod> obtenerHistorial(int tipoMovimiento)
        {
            List<HistorialMod> lstHistorialInfo = new List<HistorialMod>();
            HistorialDL historialDL = new HistorialDL();
            DataTable historialDataTable = new DataTable();

            historialDataTable = historialDL.obtenerHistorial(tipoMovimiento);

            if (historialDataTable.Rows.Count > 0)
            {
                foreach (DataRow row in historialDataTable.Rows)
                {
                    HistorialMod historialInfo = new HistorialMod();

                    historialInfo.idHistorial = int.Parse(row["idHistorial"].ToString());
                    historialInfo.descripcion = row["descripcion"].ToString();
                    historialInfo.tipoMovimiento = int.Parse(row["tipoMovimiento"].ToString());

                    if (historialInfo.tipoMovimiento == 1)
                        historialInfo.movimiento = "Entrada";
                    else
                        historialInfo.movimiento = "Salida";

                    historialInfo.idUsuario = int.Parse(row["idUsuario"].ToString());
                    historialInfo.usuario = row["nombreUSuario"].ToString();
                    historialInfo.idProducto = int.Parse(row["idProducto"].ToString());
                    historialInfo.producto = row["nombreProducto"].ToString();
                    historialInfo.fechaMovimiento = DateTime.Parse(row["fechaMovimiento"].ToString());

                    lstHistorialInfo.Add(historialInfo);
                }
            }
            else
            {
                HistorialMod ProductoInfo = new HistorialMod();

                HistorialMod historialInfo = new HistorialMod();

                historialInfo.idHistorial = 0;
                historialInfo.descripcion = "No Se Encontró Información";
                historialInfo.tipoMovimiento = 0;
                historialInfo.movimiento = "N/A";
                historialInfo.idUsuario = 0;
                historialInfo.usuario = "N/A";
                historialInfo.idProducto = 0;
                historialInfo.producto = "N/A";
                historialInfo.fechaMovimiento = DateTime.Parse("01/01/1900");

                lstHistorialInfo.Add(ProductoInfo);
            }

            return lstHistorialInfo;
        }

        public int Insertarhistorial(HistorialMod historialInfo)
        {
            HistorialDL historialDL = new HistorialDL();
            int resultadoProceso = 0;
            DataTable historialDataTable = new DataTable();

            historialDataTable = historialDL.Insertarhistorial(historialInfo);

            int Resultado = int.Parse(historialDataTable.Rows[0]["Resultado"].ToString());

            if (Resultado >= 1)
            {
                resultadoProceso = Resultado;
            }

            return resultadoProceso;
        }
    }
}