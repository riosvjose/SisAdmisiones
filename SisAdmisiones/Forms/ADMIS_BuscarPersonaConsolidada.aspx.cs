using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using nsGEN_VarSession;
using nsGEN_Java;
using nsGEN_WebForms;
using System.Data;
using nsGEN;

namespace SisAdmisiones.Forms
{
    public partial class ADMIS_BuscarPersonaConsolidada : System.Web.UI.Page
    {
        #region "Librerias Externas"
        GEN_VarSession axVarSes = new GEN_VarSession();
        GEN_Java libJava = new GEN_Java();
        GEN_WebForms webForms = new GEN_WebForms();
        SIS_GeneralesSistema Generales = new SIS_GeneralesSistema();

        #endregion

        #region "Clase de tablas de la Base de Datos"
        BD_ADMIS_DatosPersonales libDatos = new BD_ADMIS_DatosPersonales();
        #endregion

        #region "Funciones y procedimientos"
        private void CargarDatosIniciales(string strCon)
        {
            if (!string.IsNullOrEmpty(strCon.Trim()))
            {
                
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        #endregion

        #region "Eventos"
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (axVarSes.Lee<string>("strRol").Equals("1"))
                {
                    CargarDatosIniciales(axVarSes.Lee<string>("strConexion"));
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }            
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            pnsugeridos.Visible = true;
            libDatos.StrConexion = axVarSes.Lee<string>("strConexion");
            gvUsuarios.Visible = true;
            gvUsuarios.Columns[0].Visible = true;
            gvUsuarios.DataSource = libDatos.dtObtenerPersonasConsolidadas(tbusuario.Text);
            gvUsuarios.DataBind();
            gvUsuarios.Columns[0].Visible = false;
        }
        protected void btnVolverMenu_Click(object sender, EventArgs e)
        {
           // Response.Redirect("Index.aspx");
        }

        protected void gvDatos1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int indice = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "ver")
            {
                axVarSes.Escribe("strPersonaRegistrar", gvUsuarios.Rows[indice].Cells[0].Text);
                axVarSes.Escribe("strOperacion", "1");
                Response.Redirect("ADMIS_FormRegistro.aspx");
            }
            if (e.CommandName == "eliminar")
            {
                libDatos.StrConexion= axVarSes.Lee<string>("strConexion");
                libDatos.NumSecPersona = Convert.ToInt64(gvUsuarios.Rows[indice].Cells[0].Text);
                libDatos.Ver();
                libDatos.Estado = 2;//eliminado
                if (!libDatos.Modificar())
                {
                    pnMensajeError.Visible = true;
                    lblMensajeError.Text = "No se pudo eliminar el registro. " + libDatos.Mensaje; 
                    pnMensajeOK.Visible = false;
                    pnVacio.Focus();
                }
                else
                {
                    gvUsuarios.Visible = true;
                    gvUsuarios.Columns[0].Visible = true;
                    gvUsuarios.DataSource = libDatos.dtObtenerPersonas(tbusuario.Text);
                    gvUsuarios.DataBind();
                    gvUsuarios.Columns[0].Visible = false;
                }
            }
        }

        #endregion


    }
}