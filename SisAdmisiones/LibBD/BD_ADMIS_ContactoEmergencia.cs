using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using nsiBD_Interfaces;
using nsGEN_OracleBD;
using nsGEN_Mensajes;
using nsGEN_Cadenas;
using nsGEN;
using System.Data;

namespace SisAdmisiones
{
    // Creado por: Ignacio Rios; Fecha: 26/04/2019
    // Ultima modificación: 
    // Descripción: Clase referente a la tabla ADMIS_CONTACTO_EMERGENCIA

    public class BD_ADMIS_ContactoEmergencia : iBD_Tablas
    {
        #region Variables Locales

        GEN_OracleBD OracleBD = new GEN_OracleBD();
        GEN_Mensajes libMensajes = new GEN_Mensajes();
        GEN_Cadenas libCadenas = new GEN_Cadenas();
        SIS_GeneralesSistema GeneralesSistema = new SIS_GeneralesSistema();
        private string strSql = string.Empty;

        #endregion

        #region Atributos

        // Campos de la tabla ADMIS_CONTACTO_EMERGENCIA
        private long _num_sec_datos_personales = 0;
        private string _nombre_completo = string.Empty;
        private string _telefono_contacto1 = string.Empty;
        private string _telefono_contacto2 = string.Empty;
        public string _usuario_registro = string.Empty;
        public string _fecha_registro = string.Empty;

        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        // Definicion GET y SET de los campos de la tabla ADMIS_CONTACTO_EMERGENCIA
        public long NumSecDatosPer { get { return _num_sec_datos_personales; } set { _num_sec_datos_personales = value; } }
        public string NombreCompleto { get { return _nombre_completo; } set { _nombre_completo = value; } }
        public string TelefonoContacto1 { get { return _telefono_contacto1; } set { _telefono_contacto1 = value; } }
        public string TelefonoContacto2 { get { return _telefono_contacto2; } set { _telefono_contacto2 = value; } }
        public string FechaRegistro { get { return _fecha_registro; } set { _fecha_registro = value; } }
        public string UsuarioRegistro { get { return _usuario_registro; } set { _usuario_registro = value; } }

        // Definicion GET y SET para las otras propiedades 
        public string Mensaje
        {
            get { return _mensaje; }
        }
        public string StrConexion
        {
            get { return _strconexion; }
            set { _strconexion = value; }
        }

        #endregion

        #region Constructor

        // Definición del contructor de la clase ADMIS_CONTACTO_EMERGENCIA
        public BD_ADMIS_ContactoEmergencia()
        {
            _num_sec_datos_personales = 0;
            _nombre_completo = string.Empty;
            _telefono_contacto1 = string.Empty;
            _telefono_contacto2 = string.Empty;
            _usuario_registro = string.Empty;
            _fecha_registro = string.Empty;

            _mensaje = string.Empty;
            _strconexion = string.Empty;
        }

        #endregion

        #region Metodos iBD_Tablas

        // Método para insertar un dato en la tabla ADMIS_CONTACTO_EMERGENCIA
        public bool Insertar()
        {
            bool blOperacionCorrecta = true;
            if (blOperacionCorrecta)
            {
                strSql = cadSqlInsertar();
                OracleBD.MostrarError = false;
                OracleBD.StrConexion = _strconexion;
                OracleBD.Sql = strSql;
                OracleBD.EjecutarSqlTrans();

                _mensaje = OracleBD.Mensaje;
                blOperacionCorrecta = !OracleBD.Error;
                if (OracleBD.Error)
                    _mensaje = "No fue posible insertar el dato. Se encontró un error al insertar en la tabla ADMIS_CONTACTO_EMERGENCIA. " + _mensaje;
            }
            return blOperacionCorrecta;
        }

        // Método para MODIFICAR un dato en la tabla ADMIS_CONTACTO_EMERGENCIA
        public bool Modificar()
        {
            bool blOperacionCorrecta = true;
            if (blOperacionCorrecta)
            {
                strSql = cadSqlActualizar();
                OracleBD.MostrarError = false;
                OracleBD.StrConexion = _strconexion;
                OracleBD.Sql = strSql;
                OracleBD.EjecutarSqlTrans();

                _mensaje = OracleBD.Mensaje;
                blOperacionCorrecta = !OracleBD.Error;
                if (OracleBD.Error)
                    _mensaje = "No fue posible modificar el dato. Se encontró un error al modificar en la tabla ADMIS_CONTACTO_EMERGENCIA. " + _mensaje;
            }
            return blOperacionCorrecta;
        }

        // Método para ELIMINAR un dato en la tabla ADMIS_CONTACTO_EMERGENCIA
        public bool Borrar()
        {
            bool blOperacionCorrecta = false;
            return blOperacionCorrecta;
        }

        // Método para VER un dato en la tabla ADMIS_CONTACTO_EMERGENCIA
        public bool Ver()
        {
            bool blEncontrado = false;
            string strSql = string.Empty;
            if (!string.IsNullOrEmpty(_num_sec_datos_personales.ToString()))
            {
                strSql = "select a.*, to_char(a.fecha_registro, 'dd/mm/yyyy') FECHA_REGISTRO_FORMATO" +
                         " from ADMIS_CONTACTO_EMERGENCIA a" +
                         " where a.num_sec_datos_per = " + _num_sec_datos_personales;
                OracleBD.MostrarError = false;
                OracleBD.StrConexion = _strconexion;
                OracleBD.Sql = strSql;
                OracleBD.sqlDataTable();
                if (OracleBD.DataTable.Rows.Count > 0)
                {
                    blEncontrado = true;
                    _num_sec_datos_personales = Convert.ToInt64(OracleBD.DataTable.Rows[0]["NUM_SEC_DATOS_PER"].ToString());
                    _nombre_completo = OracleBD.DataTable.Rows[0]["nombre_completo"].ToString();
                    _telefono_contacto1 = OracleBD.DataTable.Rows[0]["telefono_contacto1"].ToString();
                    _telefono_contacto2 = OracleBD.DataTable.Rows[0]["telefono_contacto2"].ToString();
                    _usuario_registro = OracleBD.DataTable.Rows[0]["USUARIO_REGISTRO"].ToString();
                    _fecha_registro = OracleBD.DataTable.Rows[0]["FECHA_REGISTRO_FORMATO"].ToString();
                }
            }
            if (!blEncontrado)
            {
                _num_sec_datos_personales = 0;
                _nombre_completo = string.Empty;
                _telefono_contacto1 = string.Empty;
                _telefono_contacto2 = string.Empty;
                _usuario_registro = string.Empty;
                _fecha_registro = string.Empty;

                _usuario_registro = string.Empty;
                _fecha_registro = string.Empty;
            }
            return blEncontrado;
        }

        #endregion

        #region Procedimientos y Funciones Locales

        public DataTable dtObtenerPersonas(string parametro)
        {
            string[] partes;
            partes = parametro.Split(' ');
            strSql = string.Empty;
            if (partes.Length == 1)
            {
                strSql = "select * " +
                    "from " +
                    " admis_datos_personales" +
                    " where (primer_apellido like '%" +parametro + "%' " +
                    " or segundo_apellido like '%" + parametro + "%' " +
                    " or nombres like '%" + parametro + "%' " +
                    " or doc_identidad like '%" + parametro + "%')";
            }
            else
            {
                for (int i = 0; i < partes.Length; i++)
                {
                    strSql += "(select * " +
                        "from " +
                        " admis_datos_personales" +
                        " where (primer_apellido like '%" + partes[i] + "%' " +
                        " or segundo_apellido like '%" + partes[i] + "%' " +
                        " or nombres like '%" + partes[i] + "%' " +
                        " or doc_identidad like '%" + partes[i] + "%'))";
                    if (!string.IsNullOrEmpty(partes[i + 1]))
                    {
                        strSql += " UNION ";
                    }
                }
            }
            strSql += " order by primer_apellido, segundo_apellido, nombres";
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }
        public string cadSqlInsertar()
        {
            strSql = "insert into ADMIS_CONTACTO_EMERGENCIA " +
                       "(NUM_SEC_DATOS_PER, NOMBRE_COMPLETO, TELEFONO_CONTACTO1, TELEFONO_CONTACTO2, FECHA_REGISTRO, USUARIO_REGISTRO) " +
                       "values " +
                       "(" + _num_sec_datos_personales + ", " +
                       " upper('" + _nombre_completo + "')," +
                       " upper('" + _telefono_contacto1 + "')," +
                       " upper('" + _telefono_contacto2 + "')," +
                       " sysdate, " +
                       " upper('" + _usuario_registro + "'))";
            return strSql;
        }
        public string cadSqlActualizar()
        {
            strSql = "update ADMIS_CONTACTO_EMERGENCIA set" +
                        " NOMBRE_COMPLETO= upper('" + _nombre_completo + "')," +
                        " TELEFONO_CONTACTO1= upper('" + _telefono_contacto1 + "')," +
                        " TELEFONO_CONTACTO2= upper('" + _telefono_contacto2 + "')," +
                        " FECHA_REGISTRO=sysdate," +
                        " USUARIO_REGISTRO=  upper('" + _usuario_registro + "')" +
                        " where num_sec_datos_per = " + _num_sec_datos_personales;
            return strSql;
        }

       
        #endregion
    }
}