using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using nsGEN_VarSession;
using nsGEN_Java;
using nsGEN_WebForms;

namespace SisAdmisiones.Forms
{
    public partial class Salir : System.Web.UI.Page
    {

        #region "Librerias Externas"

        GEN_VarSession axVarSes = new GEN_VarSession();
        GEN_Java libJava = new GEN_Java();
        GEN_WebForms webForms = new GEN_WebForms();

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            // SERVIDOR PRUEBA UCBP ** copiar valores en form salir
            Session["strUsuario"] = "ucbadmin";
            Session["UsuarioLogin"] = "ucbadmin";
            Session["strUsuarioBD"] = "ucbadmin";
            Session["strPassword"] = "Prueba_2192";
            Session["strServidor"] = "ucbp";

            // SERVIDOR PRODUCCIÓN UCBL ** copiar valores en form salir
            //Session["strUsuario"] = "USR_DOCENTES_INTERNET";
            //Session["strUsuarioBD"] = "USR_DOCENTES_INTERNET";
            //Session["strPassword"] = "sdjUCB-621#7";
            //Session["strServidor"] = "ucbl";
            //Session["EnviarNotificaciones"] = true;


            Session["strRol"] = "0"; // 1 administrativo, 0 externo
            Session["strOperacion"] = "0"; // 0 registrar, 1 consolidar
            Session["strPersonaRegistrar"] = "0"; // num_sec_datos_personales tabla admins_datos_personales
            Response.Write(@"<script language='javascript'>window.close();</script>");
            Response.Redirect("~/Default.aspx");
        }
    }
}