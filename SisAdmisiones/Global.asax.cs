using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace SisAdmisiones
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            // SERVIDOR PRUEBA UCBP ** copiar valores en form salir
            Session["strUsuario"] = "ucbadmin";
            Session["UsuarioLogin"] = "ucbadmin";
            Session["strUsuarioBD"] = "ucbadmin";
            Session["strPassword"] = "Prueba_2192";
            Session["strServidor"] = "ucbp";
            
            Session["EnviarNotificaciones"] = false;
            Session["Path"] = "";
            // SERVIDOR PRODUCCIÓN UCBL ** copiar valores en form salir
            //Session["strUsuario"] = "USR_DOCENTES_INTERNET";
            //Session["strUsuarioBD"] = "USR_DOCENTES_INTERNET";
            //Session["strPassword"] = "sdjUCB-621#7";
            //Session["strServidor"] = "ucbl";
            //Session["EnviarNotificaciones"] = true;
            Session["strConexion"] = "Data Source= " + Session["strServidor"] + ";Password=" + Session["strPassword"] + ";User ID=" + Session["strUsuario"] + ";";


            Session["bEnviarNotificaciones"] = false;
            Session["UsuarioPersonaNumSec"] = "";
            Session["strDeptoUsuario"] = "";

            //***** PARAMETROS PARA OPCIONES DE SISTEMA
            Session["strRol"] = "0"; // 1 administrativo, 0 externo
            Session["strOperacion"] = "0"; // 0 registrar, 1 consolidar
            Session["strPersonaRegistrar"] = ""; // num_sec_dator_personale tabla admins datos personales
            Session["strMensajeExito"] = ""; // Mensaje de exito operacion
            Session["strCrearNuevoAlumno"] = ""; // Para verificar si persona existe
            Session["strCrearNuevoFamiliar"] = ""; // Para verificar si familiar existe
            Session["strNSAlumno"] = ""; // NumSec persona del estudiante si ya estaba registrado
            Session["strNSFamiliar"] = ""; // NumSec persona del familiar si ya estaba registrado

            // ***** PARAMETROS ENVIO DE CORREOS DE TAREAS ÚNICAS
            Session["Email_IPHost"] = "";
            Session["Email_Cuenta"] = "";
            Session["Email_Usuario"] = "";
            Session["Email_Clave"] = "";
            Session["EnviarCorreo"] = "0";       // 0:no enviar;  1: enviar
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}