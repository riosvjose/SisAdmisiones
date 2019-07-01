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
            Session["strUsuario"] = "USR_SIS_ADMISIONES";
            Session["UsuarioLogin"] = "USR_SIS_ADMISIONES";
            Session["strUsuarioBD"] = "USR_SIS_ADMISIONES";
            Session["strPassword"] = "vhtmP.37609_c";
            //Session["strServidor"] = "ucbp";
            Session["strServidor"] = "ucbl";

            Session["strRol"] = "0"; // 1 administrativo, 0 externo
            Session["strOperacion"] = "0"; // 0 registrar, 1 consolidar
            Session["strPersonaRegistrar"] = ""; // num_sec_datos_personales tabla admins_datos_personales
            axVarSes.Escribe("strPersonaRegistrar", string.Empty);
            axVarSes.Escribe("strCrearNuevoFamiliar", string.Empty);
            axVarSes.Escribe("strCrearNuevoAlumno", string.Empty);
            axVarSes.Escribe("strNSAlumno", string.Empty);
            axVarSes.Escribe("strNSFamiliar", string.Empty);
            Response.Write(@"<script language='javascript'>window.close();</script>");
            Response.Redirect("~/Default.aspx");
        }
    }
}