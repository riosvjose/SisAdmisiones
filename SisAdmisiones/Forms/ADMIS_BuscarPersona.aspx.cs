﻿using System;
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
    public partial class ADMIS_BuscarPersona : System.Web.UI.Page
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
                /*libproc.StrConexion = axVarSes.Lee<string>("strConexion");
                if (libproc.AccesoObjetoUsuario("ALM_ALM_AdministrarAlmacenes"))
                {
                    lisubdeptos = new BD_GEN_Subdeptos();
                    lisubdeptos.StrConexion = axVarSes.Lee<string>("strConexion");
                    ddlSubdeptos.DataSource = lisubdeptos.DTVerSubdeptos();
                    ddlSubdeptos.DataTextField = "NOMBRE";
                    ddlSubdeptos.DataValueField = "NUM_SEC_subdepartamento";
                    ddlSubdeptos.DataBind();
                    if (!string.IsNullOrEmpty(ddlSubdeptos.SelectedValue))
                    {
                        llenartabla();
                    }
                }
                else
                {
                    axVarSes.Escribe("MostrarMensajeError", "1");
                    Response.Redirect("Index.aspx");
                }*/
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        protected void llenartabla()
        {
            
        }
        #endregion

        #region "Eventos"
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarDatosIniciales(axVarSes.Lee<string>("strConexion"));
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
            gvUsuarios.DataSource = libDatos.dtObtenerPersonas(tbusuario.Text);
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