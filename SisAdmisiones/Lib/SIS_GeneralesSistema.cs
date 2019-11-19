using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nsGEN_OracleBD;
using System.Data;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;

namespace nsGEN
{
    public class SIS_GeneralesSistema
    {
        GEN_OracleBD OracleBD = new GEN_OracleBD();

        private string _strconexion = string.Empty;
        private string _mensaje = string.Empty;

        public string StrConexion
        {
            get { return _strconexion; }
            set { _strconexion = value; }
        }
        public string Mensaje
        {
            get { return _mensaje; }
        }

        public SIS_GeneralesSistema()
        { }

        public string FechaActual(int tipo)
        {
            string query = "";
            if (_strconexion == "")
            {
                _mensaje = "El string de conexion no esta definido.";
                return _mensaje;
            }
            else
            {
                switch (tipo)
                {
                    case 1:
                        query = "select to_char(sysdate,'dd/mm/yyyy hh24:mi:ss') from dual";
                        break;
                    case 2:
                        query = "select to_char(sysdate,'dd/mm/yyyy') from dual";
                        break;
                    case 3:
                        query = "select 'La Paz, '||to_char(sysdate, 'dd')||' de '||trim(to_char(sysdate, 'Month', 'NLS_DATE_LANGUAGE = spanish'))||' de '|| to_char(sysdate,'yyyy') from dual";
                        break;
                    default:
                        query = "select to_char(sysdate,'dd/mm/yyyy hh24:mi:ss') from dual";
                        break;
                }
                OracleBD.StrConexion = _strconexion;
                OracleBD.Sql = query;
                OracleBD.sqlDataTable();
                return OracleBD.DataTable.Rows[0].ItemArray[0].ToString();
            }
        }

        public string EdadPersona(string FechaNacimiento)
        {
            string query = "";
            if (_strconexion == "")
            {
                _mensaje = "El string de conexion no esta definido.";
                return _mensaje;
            }
            else
            {
                query = "select trunc(months_between(sysdate, to_date('" + FechaNacimiento + "', 'dd/mm/yyyy'))/12) edad from dual";
                OracleBD.StrConexion = _strconexion;
                OracleBD.Sql = query;
                OracleBD.sqlDataTable();
                return OracleBD.DataTable.Rows[0][0].ToString();
            }
        }

        public string EnviarCorreo(string CorreoDestinatario, string CorreoRemitente, string Asunto, string Cuerpo, string CuentaCorreo, string pwdCorreo, string hostCorreo, string strEnviarNotificacion)
        {
            if (strEnviarNotificacion == "0")
            {
                return "";
            }
            else
            {
                string mensaje = string.Empty;
                string EMail = string.Empty;
                bool sw = true;
                int inicio, fin;
                try
                {
                    System.Net.Mail.MailMessage correo = new System.Net.Mail.MailMessage();
                    correo.From = new System.Net.Mail.MailAddress(CorreoRemitente);
                    do
                    {
                        inicio = 0;
                        fin = CorreoDestinatario.IndexOf(",");
                        if (fin == -1)
                        {
                            sw = false;
                        }
                        else
                        {
                            EMail = CorreoDestinatario.Substring(inicio, fin);
                            correo.To.Add(EMail);
                            inicio = fin + 1;
                            CorreoDestinatario = CorreoDestinatario.Substring(inicio);
                            if (CorreoDestinatario == "")
                                sw = false;
                            else
                                sw = true;
                        }

                    } while (sw);
                    if (EMail == "")
                        correo.To.Add(CorreoDestinatario);

                    correo.Subject = Asunto;
                    correo.Body = Cuerpo;
                    correo.IsBodyHtml = true;
                    correo.Priority = System.Net.Mail.MailPriority.High;
                    System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
                    smtp.Host = hostCorreo;
                    smtp.Credentials = new System.Net.NetworkCredential(CuentaCorreo, pwdCorreo);
                    smtp.EnableSsl = false;
                    smtp.Port = 2525;
                    smtp.Send(correo);
                    mensaje = "";
                }
                catch (Exception ex)
                {
                    mensaje = "Error al enviar notificación por email: " + ex.Message;
                    // throw;
                }
                return mensaje;
            }   
        }

        public string Generar_Numero_Randomico(int NroDigitos)
        {
            Int32 max, min;
            Int64 nro;
            Random rnd = new Random();

            min = Convert.ToInt32(Math.Pow(10,NroDigitos-1));
            max = Convert.ToInt32(Math.Pow(10, NroDigitos) - 1);
            nro = rnd.Next(min,max);
            return nro.ToString();
        }

        public void AdicionarColumnas(string NombreColumna, int TipoColumna, ref DataTable myDataTable)
        {
            DataColumn col = new DataColumn();
            switch (TipoColumna)
            {
                case 1:
                    col.DataType = System.Type.GetType("System.String");
                    break;
                case 2:
                    col.DataType = System.Type.GetType("System.Double");
                    break;
                case 3:
                    col.DataType = System.Type.GetType("System.Int16");
                    break;
                case 4:
                    col.DataType = System.Type.GetType("System.Int64");
                    break;
            }
            col.ColumnName = NombreColumna;
            myDataTable.Columns.Add(col);
        }

        public void CambiarSessionTerritorio()
        {
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = "ALTER SESSION SET NLS_TERRITORY='AMERICA'";
            OracleBD.EjecutarSql();
        }

        public DataTable FechasRangoDiaSemana(string FechaInicio, string FechaFin, string dia_semana)
        {
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = "select fecha " +
                            "from " +
                            "( " +
                            "	select to_char(to_date('" + FechaInicio + "','dd/mm/yyyy') + rownum - 1, 'dd/mm/yyyy') fecha,  " +
                            "	to_char(to_date('" + FechaInicio + "','dd/mm/yyyy') + rownum - 1, 'DAY', 'NLS_DATE_LANGUAGE=SPANISH') dia_semana " +
                            "	from dominios " +
                            ") " +
                            "where to_date(fecha, 'dd/mm/yyyy') <= to_date('" + FechaFin + "','dd/mm/yyyy') " +
                            "and trim(upper(dia_semana)) = '" + dia_semana + "' " +
                            "order by to_date(fecha, 'dd/mm/yyyy')";
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }

        public object IIf(bool Expression, object TruePart, object FalsePart)
        {
            object ReturnValue = Expression == true ? TruePart : FalsePart;

            return ReturnValue;
        }

        public string getMd5Hash(string input)
        {
            MD5 md5Hasher = MD5.Create();
            Byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            int i;
            for (i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public bool VerificarMenorIgualFechaActual(string fecha)
        {
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = "select trunc(sysdate) - to_date('" + fecha + "', 'dd/mm/yyyy') from dual";
            OracleBD.sqlDataTable();
            if (Convert.ToInt16(OracleBD.DataTable.Rows[0][0]) > 0)
                return true;
            else
                return false;
        }

        public bool VerificarMayorFechaActual(string Fecha)
        {
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = "select count(0) from dual where to_date('" + Fecha + "','dd/mm/yyyy') > trunc(sysdate)";
            OracleBD.sqlDataTable();
            if (OracleBD.DataTable.Rows[0][0].ToString().Trim() == "0")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Verifica el tipo, tamaño y existencia del archivo
        /// </summary>
        /// <param name="fu">FileUpload</param>
        /// <param name="TamanioArchivo">Tamaño máximo del archivo</param>
        /// <param name="NSArchivo">NUM_SEC_ARCHIVO</param>
        /// <param name="Aplicacion">PDF, IMG</param>
        /// <returns></returns>
        public string VerificarArchivo(FileUpload fu, Int32 TamanioArchivo, string NSArchivo, string Aplicacion)
        {
            // Aplicacion = PDF, IMG
            // Devuelve una cadena vacía si no hay el archivo
            // devuelve el valor "SI" si ya existe un archivo anterior, "NO" si no hay un archivo seleccionado
            string msj = "";
            if (fu.HasFile)
            {
                switch (Aplicacion)
                {
                    case "PDF":
                        if (fu.PostedFile.ContentType == "application/pdf" || fu.PostedFile.ContentType == "application/x-pdf")
                        {
                            if (fu.PostedFile.ContentLength <= TamanioArchivo)
                            {
                                msj = "";
                            }
                            else
                            {
                                msj = "El archivo NO debe sobrepasar de " + (TamanioArchivo / 1024 / 1024).ToString().Trim() + " MB en tamaño.";
                            }
                        }
                        else
                        {
                            msj = "El archivo debe estar en formato PDF.";
                        }
                        break;
                    case "IMG":
                        if (fu.PostedFile.ContentType == "image/jpeg" ||
                            fu.PostedFile.ContentType == "image/pjpeg" ||
                            fu.PostedFile.ContentType == "image/x-png" ||
                            fu.PostedFile.ContentType == "image/png"
                            )
                        {
                            if (fu.PostedFile.ContentLength <= TamanioArchivo)
                            {
                                msj = "";
                            }
                            else
                            {
                                msj = "El archivo NO debe sobrepasar de " + TamanioArchivo / 1024 + " MB en tamaño.";
                            }
                        }
                        else
                        {
                            msj = "La fotografía debe estar en formato jpg o png.";
                        }
                        break;
                }
            }
            else
            {
                if (NSArchivo == "")
                {
                    msj = "NO";
                }
                else
                {
                    msj = "SI";
                }
            }
            return msj;
        }

        public bool IsNumeric(string Expression)
        {
            int res = 0;
            try
            {
                res = Convert.ToInt16(Expression);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Obtener el Email del usuario
        public string EmailEmpleado(string strNSPersona)
        {
            string strSql = string.Empty;
            string email = string.Empty;

            strSql = "SELECT PDA.EMAIL_UCB ";
            strSql += "FROM PERSONAS_DATOS_ADICIONALES PDA ";
            strSql += "WHERE PDA.NUM_SEC_PERSONA = ";
            strSql += strNSPersona.ToString().Trim();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql.ToString();
            OracleBD.sqlDataTable();

            DataTable dt = new DataTable();

            dt = OracleBD.DataTable;

            if (dt.Rows.Count > 0)
            {                
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["EMAIL_UCB"])))
                {
                    email = dt.Rows[0]["EMAIL_UCB"].ToString();
                }
            }
            return email;
        }

    }
}