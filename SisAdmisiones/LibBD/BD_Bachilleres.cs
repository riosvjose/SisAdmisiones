using nsiBD_Interfaces;
using nsGEN_OracleBD;
using nsGEN_Mensajes;
using nsGEN_Cadenas;
using System.Data;
using System;

namespace nsBD_GEN
{
    // Creado por: Willy Tenorio Palza; Fecha: 09/11/2015
    // Ultima modificación: Willy Tenorio Palza; Fecha: 11/04/2018
    // Descripción: Clase referente a la tabla BACHILLERES

    public class BD_Bachilleres : iBD_Tablas
    {
        #region Variables Locales

        GEN_OracleBD OracleBD = new GEN_OracleBD();
        GEN_Mensajes libMensajes = new GEN_Mensajes();
        GEN_Cadenas libCadenas = new GEN_Cadenas();
        private string strSql = string.Empty;

        #endregion

        #region Atributos

        // Campos de la tabla BACHILLERES
        private long _num_sec_persona = 0;
        private long _num_sec_colegio = 0;
        private short _turno_colegio = 0;
        private short _anio_egreso = 0;
        private short _tipo = 0;
        private short _tipo_lugar_bachiller = 0;

        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        // Definicion GET y SET de los campos de la tabla BACHILLERES
        public long NumSecPersona { get { return _num_sec_persona; } set { _num_sec_persona = value; } }
        public long NumSecColegio { get { return _num_sec_colegio; } set { _num_sec_colegio = value; } }
        public short TurnoColegio { get { return _turno_colegio; } set { _turno_colegio = value; } }
        public short AnioEgreso { get { return _anio_egreso; } set { _anio_egreso = value; } }
        public short Tipo { get { return _tipo; } set { _tipo = value; } }
        public short TipoLugarBachiller { get { return _tipo_lugar_bachiller; } set { _tipo_lugar_bachiller = value; } }

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

        // Definición del contructor de la clase BACHILLERES
        public BD_Bachilleres()
        {
            _num_sec_persona = 0;
            _num_sec_colegio = 0;
            _turno_colegio = 0;
            _anio_egreso = 0;
            _tipo = 0;
            _tipo_lugar_bachiller = 0;

            _mensaje = string.Empty;
            _strconexion = string.Empty;
        }

        #endregion

        #region Metodos iBD_Tablas

        // Método para insertar un dato en la tabla BACHILLERES
        public bool Insertar()
        {
            bool blOperacionCorrecta = false;
            strSql = "insert into BACHILLERES (  " +
                     "num_sec_persona, " +
                     "num_sec_colegio, " +
                     "turno_colegio, " +
                     "anio_egreso, " +
                     "tipo, " +
                     "tipo_lugar_bachiller " +
                     ") " +
                     "values " +
                     "(" +
                     _num_sec_persona.ToString() + ", " +
                     _num_sec_colegio.ToString() + ", " +
                     _turno_colegio.ToString() + ", " +
                     _anio_egreso.ToString() + ", " +
                     _tipo.ToString() + ", " +
                     _tipo_lugar_bachiller.ToString() + " " +
                     ")";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();

            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible insertar el dato. Se encontró un error al insertar en la tabla BACHILLERES. " + _mensaje;
            return blOperacionCorrecta;
        }

        // Método para MODIFICAR un dato en la tabla BACHILLERES
        public bool Modificar()
        {
            bool blOperacionCorrecta = false;
            strSql = "update BACHILLERES " +
                     "set " +
                     "num_sec_persona = " + _num_sec_persona.ToString() + ", " +
                     "num_sec_colegio = " + _num_sec_colegio.ToString() + ", " +
                     "turno_colegio = " + _turno_colegio.ToString() + ", " +
                     "anio_egreso = " + _anio_egreso.ToString() + ", " +
                     "tipo = " + _tipo.ToString() + ", " +
                     "tipo_lugar_bachiller = " + _tipo_lugar_bachiller.ToString() + " " +
                     "where num_sec_persona = " + _num_sec_persona.ToString();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();

            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible actualizar el dato. Se encontró un error al actualizar en la tabla BACHILLERES. " + _mensaje;
            return blOperacionCorrecta;
        }

        // Método para ELIMINAR un dato en la tabla BACHILLERES
        public bool Borrar()
        {
            bool blOperacionCorrecta = false;
            strSql = "delete BACHILLERES " +
                     "where num_sec_persona = " + _num_sec_persona.ToString();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();

            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible borrar el dato. Se encontró un error al eliminar en la tabla BACHILLERES. " + _mensaje;
            return blOperacionCorrecta;
        }

        // Método para VER un dato en la tabla BACHILLERES
        public bool Ver()
        {
            bool Encontrado = false;
            if (!string.IsNullOrEmpty(_num_sec_persona.ToString()))
            {
                DataTable dt = new DataTable();
                strSql = "select " +
                         "num_sec_persona, " +
                         "num_sec_colegio, " +
                         "turno_colegio, " +
                         "anio_egreso, " +
                         "tipo, " +
                         "tipo_lugar_bachiller " +
                         "from BACHILLERES " +
                         "where num_sec_persona = " + _num_sec_persona.ToString();
                OracleBD.MostrarError = false;
                OracleBD.StrConexion = _strconexion;
                OracleBD.Sql = strSql;
                OracleBD.sqlDataTable();
                dt = OracleBD.DataTable;
                if (dt.Rows.Count == 1)
                {
                    Encontrado = true;
                    DataRow dr = dt.Rows[0];
                    _num_sec_persona = Convert.ToInt64(dr["num_sec_persona"].ToString());
                    _num_sec_colegio = Convert.ToInt64(dr["num_sec_colegio"].ToString());
                    _turno_colegio = Convert.ToInt16(dr["turno_colegio"].ToString());
                    _anio_egreso = Convert.ToInt16(dr["anio_egreso"].ToString());
                    _tipo = Convert.ToInt16(dr["tipo"].ToString());
                    _tipo_lugar_bachiller = Convert.ToInt16(dr["tipo_lugar_bachiller"].ToString());
                }
                dt.Dispose();
            }
            if (!Encontrado)
            {
                _num_sec_persona = 0;
                _num_sec_colegio = 0;
                _turno_colegio = 0;
                _anio_egreso = 0;
                _tipo = 0;
                _tipo_lugar_bachiller = 0;
            }
            return Encontrado;
        }

        #endregion

        #region Procedimientos y Funciones Locales

        public byte RevisaTituloBachiller()
        {
            OracleBD.Sql = "select valor from parametros_modulos where codigo = 33001";
            OracleBD.StrConexion = StrConexion;
            OracleBD.sqlDataTable();
            if (OracleBD.DataTable.Rows.Count == 0)
                return 0;
            else
                return System.Convert.ToByte(OracleBD.DataTable.Rows[0]["valor"]);
        }

        public string sqlCadInsertar()
        {
            strSql = "insert into BACHILLERES (  " +
                     "num_sec_persona, " +
                     "num_sec_colegio, " +
                     "turno_colegio, " +
                     "anio_egreso, " +
                     "tipo, " +
                     "tipo_lugar_bachiller " +
                     ") " +
                     "values " +
                     "(" +
                     _num_sec_persona.ToString() + ", " +
                     _num_sec_colegio.ToString() + ", " +
                     _turno_colegio.ToString() + ", " +
                     _anio_egreso.ToString() + ", " +
                     _tipo.ToString() + ", " +
                     _tipo_lugar_bachiller.ToString() + " " +
                     ")";
            return strSql;
        }

        public string sqlCadActualizar()
        {
            strSql = "update BACHILLERES set  " +
                     "num_sec_colegio=" + _num_sec_colegio.ToString() + ", " +
                     "turno_colegio=" + _turno_colegio.ToString() + ", " +
                     "anio_egreso= " + _anio_egreso.ToString() + ", " +
                     "tipo=" + _tipo.ToString() + ", " +
                     "tipo_lugar_bachiller=" + _tipo_lugar_bachiller.ToString() + " " +
                     "where num_sec_persona= "+_num_sec_persona.ToString();
            return strSql;
        }

        #endregion
    }
}