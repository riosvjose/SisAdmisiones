using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nsGEN_Java
{
    // Creado por: Milco Cortez; Fecha: 17/03/2015
    // Ultima modificación: Milco Cortez;  Fecha:26/03/2015
    // Descripción: Habilita diferentes métodos para ejecutar java scripts 
                //Invocar una ventana emergente Java script. 

    public class GEN_Java
    {
        private string strmensaje = string.Empty;  // the name field 
        public string strMensaje    // the Name property
        {
            get { return strmensaje; }
            set { strmensaje = value; }
        }

        private int axestilo = 1;
        public int axEstilo
        {
            get { return axestilo; }
            set { axestilo = value; }
        }

        public GEN_Java()
        { }

        public void Desplegar_Mensage_Java(System.Web.UI.Page Page1, string strMensaje1, int axEstilo1)
        {
            string strScript = "<script language=JavaScript>";
            switch (axEstilo1)
            {
                case 2:
                    strScript += "alert(\"" + strMensaje1 + "\");";
                    break;
                case 3:
                    strScript += "alert(\"" + strMensaje1 + "\");";
                    break;
                default:
                    strScript += "alert(\"" + strMensaje1 + "\");";
                    break;
            }
            strScript += "</script>";

            if (Page1.ClientScript.IsStartupScriptRegistered("clientScript") == false)
            {
                Page1.ClientScript.RegisterStartupScript(this.GetType(), "Alerta", strScript);
            }
        }

        public void Desplegar_Mensage_Java_Redireccion(System.Web.UI.Page Page1, string strMensaje1, string Pagina)
        {
            string strScript = "<script language=JavaScript>";
            strScript += "alert(\"" + strMensaje1 + "\");window.open('" + Pagina + "','_self');";
            strScript += "</script>";

            if (Page1.ClientScript.IsStartupScriptRegistered("clientScript") == false)
            {
                Page1.ClientScript.RegisterStartupScript(this.GetType(), "Alerta", strScript);
            }
        }


    }
}