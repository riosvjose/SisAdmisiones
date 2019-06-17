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
    // Descripción: Clase referente a la tabla ADMIS_DATOS_PER_DISC

    public class BD_ADMIS_DatosPer_Disc : iBD_Tablas
    {
        #region Variables Locales

        GEN_OracleBD OracleBD = new GEN_OracleBD();
        GEN_Mensajes libMensajes = new GEN_Mensajes();
        GEN_Cadenas libCadenas = new GEN_Cadenas();
        SIS_GeneralesSistema GeneralesSistema = new SIS_GeneralesSistema();
        private string strSql = string.Empty;

        #endregion

        #region Atributos

        // Campos de la tabla ADMIS_DATOS_PER_DISC
        private long _num_sec_datos_personales = 0;
        private short _tipo_discapacidad = 0;
        public string _usuario_registro = string.Empty;
        public string _fecha_registro = string.Empty;

        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        // Definicion GET y SET de los campos de la tabla ADMIS_DATOS_PER_DISC
        public long NumSecDatosPer { get { return _num_sec_datos_personales; } set { _num_sec_datos_personales = value; } }
        public short TipoDisc { get { return _tipo_discapacidad; } set { _tipo_discapacidad = value; } }
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

        // Definición del contructor de la clase ADMIS_DATOS_PER_DISC
        public BD_ADMIS_DatosPer_Disc()
        {
            _num_sec_datos_personales = 0;
            _tipo_discapacidad = 0;
            _usuario_registro = string.Empty;
            _fecha_registro = string.Empty;

            _mensaje = string.Empty;
            _strconexion = string.Empty;
        }

        #endregion

        #region Metodos iBD_Tablas

        // Método para insertar un dato en la tabla ADMIS_DATOS_PER_DISC
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
                    _mensaje = "No fue posible insertar el dato. Se encontró un error al insertar en la tabla ADMIS_DATOS_PER_DISC. " + _mensaje;
            }
            return blOperacionCorrecta;
        }

        // Método para MODIFICAR un dato en la tabla ADMIS_DATOS_PER_DISC
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
                    _mensaje = "No fue posible modificar el dato. Se encontró un error al modificar en la tabla ADMIS_DATOS_PER_DISC. " + _mensaje;
            }
            return blOperacionCorrecta;
        }

        // Método para ELIMINAR un dato en la tabla ADMIS_DATOS_PER_DISC
        public bool Borrar()
        {
            bool blOperacionCorrecta = false;
            return blOperacionCorrecta;
        }

        // Método para VER un dato en la tabla ADMIS_DATOS_PER_DISC
        public DataTable Ver()
        {
            string strSql = string.Empty;
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(_num_sec_datos_personales.ToString()))
            {
                strSql = "select a.*, to_char(a.FECHA_REGISTRO, 'dd/mm/yyyy') as FECHA_REGISTRO_FORMATO" +
                         " from ADMIS_DATOS_PER_DISC a" +
                         " where a.num_sec_datos_per = " + _num_sec_datos_personales;
                OracleBD.MostrarError = false;
                OracleBD.StrConexion = _strconexion;
                OracleBD.Sql = strSql;
                OracleBD.sqlDataTable();
                dt = OracleBD.DataTable;
            }
            return dt;
        }

        #endregion

        #region Procedimientos y Funciones Locales
        public string cadSqlInsertar()
        {
            strSql = "insert into ADMIS_DATOS_PER_DISC " +
                        "(NUM_SEC_DATOS_PER, TIPO_DISCAPACIDAD, " +
                        " FECHA_REGISTRO, USUARIO_REGISTRO) " +
                        "values " +
                        "(" + _num_sec_datos_personales + ", " +
                        _tipo_discapacidad + "," +
                        " sysdate, " +
                        " upper('" + _usuario_registro + "'))";
            return strSql;
        }
        public string cadSqlActualizar()
        {
            strSql = "update ADMIS_DATOS_PER_DISC set " +
                        " TIPO_DISCAPACIDAD=" + _tipo_discapacidad +
                        " ,FECHA_REGISTRO=sysdate" +
                        " ,USUARIO_REGISTRO= upper('" + _usuario_registro + "')" +
                        " where num_sec_datos_per = " + _num_sec_datos_personales;
            return strSql;
        }
        #endregion
    }
}