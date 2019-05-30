using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

using nsiBD_Interfaces;
using nsGEN_OracleBD;
using nsGEN;

namespace nsBD_ACAD
{
    // Creado por: Willy Tenorio Palza; Fecha: 13/04/2018
    // Ultima modificación:
    // Descripción: Clase referente a la tabla FAMILIARES

    public class BD_Familiares: iBD_Tablas
    {
        #region Librerias Externas

        SIS_GeneralesSistema Generales = new SIS_GeneralesSistema();

        #endregion

        #region Variables Locales

        GEN_OracleBD OracleBD = new GEN_OracleBD();
        private string strSql = string.Empty;

        #endregion

        #region Atributos

        // Campos de la tabla FAMILIARES
        private long _num_sec_persona = 0;
        private long _num_sec_familiar = 0;
        private short _tipo = 0;

        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        // Definicion GET y SET de los campos de la tabla FAMILIARES
        public long NumSecPersona { get { return _num_sec_persona; } set { _num_sec_persona = value; } }
        public long NumSecFamiliar { get { return _num_sec_familiar; } set { _num_sec_familiar = value; } }
        public short Tipo { get { return _tipo; } set { _tipo = value; } }

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

        // Definición del contructor de la clase FAMILIARES
        public BD_Familiares()
        {
            _num_sec_persona = 0;
            _num_sec_familiar = 0;
            _tipo = 0;

            _mensaje = string.Empty;
            _strconexion = string.Empty;
        }

        #endregion

        #region Metodos iBD_Tablas y Públicos

        // Método para insertar un dato en la tabla FAMILIARES
        public bool Insertar()
        {
            bool blOperacionCorrecta = false;
            strSql = "insert into FAMILIARES (  " +
                     "num_sec_persona, " +
                     "num_sec_familiar, " +
                     "tipo " +
                     ") " +
                     "values " +
                     "( " +
                     _num_sec_persona.ToString() + ", " +
                     _num_sec_familiar.ToString() + ", " +
                     _tipo.ToString() + " " +
                     ")";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();

            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible insertar el dato. Se encontró un error al insertar en la tabla FAMILIARES. " + _mensaje;
            return blOperacionCorrecta;
        }

        // Método para MODIFICAR un dato en la tabla FAMILIARES
        public bool Modificar()
        {
            bool blOperacionCorrecta = false;
            strSql = "update FAMILIARES " +
                     "set " +
                     "num_sec_familiar = " + _num_sec_familiar.ToString() + ", " +
                     "tipo = " + _tipo.ToString() + " " +
                     "where num_sec_persona = " + _num_sec_persona.ToString() + " " +
                     "and num_sec_familiar = " + _num_sec_familiar.ToString();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();

            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible actualizar el dato. Se encontró un error al actualizar en la tabla FAMILIARES. " + _mensaje;
            return blOperacionCorrecta;
        }

        // Método para ELIMINAR un dato en la tabla FAMILIARES
        public bool Borrar()
        {
            bool blOperacionCorrecta = false;
            strSql = "delete FAMILIARES " +
                     "where num_sec_persona = " + _num_sec_persona.ToString() + " " +
                     "and num_sec_familiar = " + _num_sec_familiar.ToString();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();

            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible borrar el dato. Se encontró un error al eliminar en la tabla FAMILIARES. " + _mensaje;
            return blOperacionCorrecta;
        }

        // Método para VER un dato en la tabla FAMILIARES
        public bool Ver()
        {
            bool Encontrado = false;
            DataTable dt = new DataTable();
            strSql = "select " +
                     "num_sec_persona, " +
                     "num_sec_familiar, " +
                     "tipo " +
                     "from FAMILIARES " +
                     "where num_sec_persona = " + _num_sec_persona.ToString() + " " +
                     "and num_sec_familiar = " + _num_sec_familiar.ToString();
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
                _num_sec_familiar = Convert.ToInt64(dr["num_sec_familiar"].ToString());
                _tipo = Convert.ToInt16(dr["tipo"].ToString());
            }
            dt.Dispose();
            if (!Encontrado)
            {
                _num_sec_persona = 0;
                _num_sec_familiar = 0;
                _tipo = 0;
            }
            return Encontrado;
        }
        
        #endregion

        #region Procedimientos y Funciones Públicas

        public DataTable DTListadoFamiliares()
        {
            strSql = "select f.num_sec_familiar, per.cedula_identidad, per.ap_paterno||' '||per.ap_materno||' '||per.nombres familiar,  " +
                     "f.tipo, dom.descripcion tipo_str " +
                     "from familiares f, personas per, dominios dom " +
                     "where f.num_sec_persona = " + _num_sec_persona.ToString().Trim() + " " +
                     "and dom.dominio = 'TIPO_FAMILIAR' " +
                     "and f.num_sec_familiar = per.num_sec " +
                     "and dom.valor = f.tipo";
            OracleBD.Sql = strSql;
            OracleBD.StrConexion = _strconexion;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }

        public bool RevisarSiEsFamiliar()
        {
            strSql = " select * from familiares" +
                     " where num_sec_familiar = " + _num_sec_familiar.ToString().Trim();
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            if (OracleBD.DataTable.Rows.Count == 0)
                return false;
            else
                return true;
        }

        public bool RevisarSiExisteFamiliar()
        {
            strSql = " select * from familiares" +
                     " where num_sec_familiar = " + _num_sec_familiar.ToString().Trim()+
                     " and num_sec_persona = " + _num_sec_persona.ToString().Trim();
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            if (OracleBD.DataTable.Rows.Count == 0)
                return false;
            else
                return true;
        }

        public string cadsqInsertar ()
        {
            strSql = " insert into familiares" +
                     " (num_sec_familiar, num_sec_persona, tipo) values(" + _num_sec_familiar.ToString().Trim() +
                     " , " + _num_sec_persona.ToString().Trim()+","+_tipo+")";
            return strSql;
        }
        #endregion
    }
}