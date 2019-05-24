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
    public partial class Index : System.Web.UI.Page
    {
        #region "Librerias Externas"

        GEN_VarSession axVarSes = new GEN_VarSession();
        #endregion
        #region "Clase de tablas de la Base de Datos"

        #endregion
        #region "Funciones y procedimientos"

        private void CargarDatosIniciales(string strCon)
        {
            
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.UserAgent.IndexOf("AppleWebKit") > 0)
            {
                Request.Browser.Adapters.Clear();
            }
            if (axVarSes.Lee<string>("strConexion") == "" || axVarSes.Lee<string>("strConexion") == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (!Page.IsPostBack)
            {
                if (Convert.ToInt32(axVarSes.Lee<string>("strRol").Trim())==1)
                { 
                    CargarDatosIniciales(axVarSes.Lee<string>("strConexion"));
                }
                else
                {
                    Response.Redirect("ADMIS_FormRegistro.aspx");
                }
            }
        }
        protected void lbSalidas_Click(object sender, EventArgs e)
        {
            Response.Redirect("STRS_SAL_MenuSalidas.aspx");
        }
        protected void lbTareas_Click(object sender, EventArgs e)
        {
            Response.Redirect("STRS_TAR_MenuTareas.aspx"); 
        }
        protected void lbProyectos_Click(object sender, EventArgs e)
        {
            Response.Redirect("STRS_PROY_MenuProyectos.aspx");
        }
        protected void lbControlAulas_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(axVarSes.Lee<string>("strRolTipo").Trim()) % 5 == 0)
            {
                Response.Redirect("STRS_CON_AULA_Reportes.aspx");
            }
            if (Convert.ToInt32(axVarSes.Lee<string>("strRolTipo").Trim()) % 3 == 0)
            {
                Response.Redirect("STRS_CON_AULA_Registrar.aspx");
            }
        }
        
        #endregion
    }
}