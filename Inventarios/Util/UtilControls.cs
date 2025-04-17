using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Inventarios.Util
{
    public class UtilControls
    {
        public static void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }

        public static void SweetBox(String ex, String sub, String type, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>swal('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "','" + sub.Replace("\r\n", "\\n").Replace("'", "") + "','" + type + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }

        public static void SweetBoxConfirm(String ex, String sub, String type, string url, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>";
            s += "swal({title: '" + ex + "',text: '" + sub + "',type: '" + type + "',showCancelButton: false,confirmButtonColor: '#DD6B55', confirmButtonText: 'OK',closeOnConfirm: true},function(){document.location.href = '" + url + "';});</SCRIPT>";

            //string s = "<SCRIPT language='javascript'>swal({title:'" + ex.Replace("\r\n", "\\n").Replace("',text:", "") + "','" + sub.Replace("\r\n", "\\n").Replace("'", "") + "','" + type + "',false,'#DD6B55','OK',true); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }
    }
}