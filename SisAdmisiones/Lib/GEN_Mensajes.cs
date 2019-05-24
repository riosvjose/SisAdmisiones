using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using nsGEN_VarSession;

namespace nsGEN_Mensajes
{
    public class GEN_Mensajes
    {
        GEN_VarSession axVarSes = new GEN_VarSession();

        public GEN_Mensajes()
        { }

        public void Llamar_Pagina_Error(System.Web.UI.Page pagina, string strMensajeError)
        {
            axVarSes.Escribe("errores", strMensajeError);
            pagina.Response.Redirect("error.aspx");
        }

        public void Llamar_Pagina_Principal(System.Web.UI.Page pagina, string strMensaje)
        {
            axVarSes.Escribe("Menu1_Mensaje", strMensaje);
            pagina.Response.Redirect("Menu1.aspx");
        }

        public void Llamar_Pagina_Index(System.Web.UI.Page pagina, string strMensaje, int intTipoMensaje)
        {
            // intTipoMensaje: 0: no mensaje, 1: mensaje de OK, 2: mensaje de error

            axVarSes.Escribe("Index_Mensaje", strMensaje);
            axVarSes.Escribe("Index_TipoMensaje", intTipoMensaje.ToString());
            pagina.Response.Redirect("Index.aspx");
        }

        public void Mensaje_TXT(string strMensaje, int axTipo, int axSimbolo, ref System.Web.UI.WebControls.Label lblMensaje)
        {
            switch (axTipo)
            {
                case 1:
                    if (axSimbolo == 1)
                        lblMensaje.Text = "<br><img src=\"images/bien.gif\" width=\"20\" height=\"15\">" + strMensaje;
                    else
                        lblMensaje.Text = "<font color=\"geen\">" + strMensaje + "</font>";
                    break;
                case 2:
                    if (axSimbolo == 1)
                        lblMensaje.Text = "<br><img src=\"images/mal.gif\" width=\"20\" height=\"15\">" + strMensaje;
                    else
                        lblMensaje.Text = "<font color=\"red\">" + strMensaje + "</font>";
                    break;
                case 3:
                    if (axSimbolo == 1)
                        lblMensaje.Text = "<br><img src=\"images/advert1.gif\" width=\"20\" height=\"15\">" + strMensaje;
                    else
                        lblMensaje.Text = "<font color=\"yellow\">" + strMensaje + "</font>";
                    break;
                default:
                    break;
            }

        }



    }
}