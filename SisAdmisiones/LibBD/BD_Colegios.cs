using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using nsiBD_Interfaces;
using nsGEN_OracleBD;
using nsGEN_Mensajes;
using nsGEN_Cadenas;
using System.Data;

namespace nsBD_GEN
{
    // Creado por: Willy Tenorio Palza; Fecha: 09/11/2015
    // Ultima modificación: 
    // Descripción: Clase referente a la tabla COLEGIOS

    public class BD_Colegios : iBD_Tablas
    {
        #region Variables Locales

        GEN_OracleBD OracleBD = new GEN_OracleBD();
        GEN_Mensajes libMensajes = new GEN_Mensajes();
        GEN_Cadenas libCadenas = new GEN_Cadenas();
        private string strSql = string.Empty;

        #endregion

        #region Atributos

        // Campos de la tabla COLEGIOS
        private long _num_sec = 0;            
        private string _nombre = string.Empty; 
        private long _num_sec_localidad = 0;   

        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        // Definicion GET y SET de los campos de la tabla COLEGIOS
        public long NumSec { get { return _num_sec; } set { _num_sec = value; } }
        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public long NumSecLocalidad { get { return _num_sec_localidad; } set { _num_sec_localidad = value; } }
		
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

        // Definición del contructor de la clase COLEGIOS
        public BD_Colegios()
        {
            _num_sec = 0;           
            _nombre = string.Empty; 
            _num_sec_localidad = 0; 

            _mensaje = string.Empty;
            _strconexion = string.Empty;
        }

        #endregion

        #region Metodos iBD_Tablas y Públicos

        // Método para insertar un dato en la tabla COLEGIOS
        public bool Insertar()
        {
            bool blOperacionCorrecta = false;
            
            strSql = "insert into COLEGIOS (  " +
                        "num_sec, " +
                        "nombre, " +
                        "num_sec_localidad " +
                        ") " +
                        "values " +
                        "( colegios_sec.nextval, " +
                        "'" + _nombre + "', " +
                        _num_sec_localidad.ToString() + " " +
                        ")";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();

            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible insertar el dato. Se encontró un error al insertar en la tabla COLEGIOS. " + _mensaje;
            
            return blOperacionCorrecta;
        }

        // Método para MODIFICAR un dato en la tabla COLEGIOS
        public bool Modificar()
        {
            bool blOperacionCorrecta = false;

            strSql = "update COLEGIOS " +
                        "set " +
                        "nombre = '" + _nombre + "', " +
                        "num_sec_localidad = " + _num_sec_localidad.ToString() + " " +
                        "where num_sec = " + _num_sec.ToString();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();

            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible actualizar el dato. Se encontró un error al actualizar en la tabla COLEGIOS. " + _mensaje;
            
            return blOperacionCorrecta;
        }

        // Método para ELIMINAR un dato en la tabla COLEGIOS
        public bool Borrar()
        {
            bool blOperacionCorrecta = false;
            strSql = "delete COLEGIOS " +
                     "where num_sec = " + _num_sec.ToString();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();

            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible borrar el dato. Se encontró un error al eliminar en la tabla COLEGIOS. " + _mensaje;
            return blOperacionCorrecta;
        }

        // Método para VER un dato en la tabla COLEGIOS
        public bool Ver()
        {
            bool Encontrado = false;
            if (!string.IsNullOrEmpty(_num_sec.ToString()))
            {
                DataTable dt = new DataTable();
                strSql = "select " +
                         "num_sec, " +
                         "nombre, " +
                         "num_sec_localidad " +
                         "from COLEGIOS " +
                         "where num_sec = " + _num_sec.ToString();
                OracleBD.MostrarError = false;
                OracleBD.StrConexion = _strconexion;
                OracleBD.Sql = strSql;
                OracleBD.sqlDataTable();
                dt = OracleBD.DataTable;
                if (dt.Rows.Count == 1)
                {
                    Encontrado = true;
                    DataRow dr = dt.Rows[0];
                    _num_sec = Convert.ToInt64(dr["num_sec"].ToString());
                    _nombre = dr["nombre"].ToString();
                    _num_sec_localidad = Convert.ToInt64(dr["num_sec_localidad"].ToString());
                }
                dt.Dispose();
            }
            if (!Encontrado)
            {
                _num_sec = 0;
                _nombre = string.Empty;
                _num_sec_localidad = 0;
            }
            return Encontrado;
        }
        
        #endregion


        #region Procedimientos y Funciones Públicas

        public string SQLListadoColegios()
        {
            strSql = "select 0 num_sec_colegio, ' [SIN BACHILLERATO REGISTRADO] ' colegio " +
                     "from dual " +
                     "union " +
                     "select c.num_sec num_sec_colegio, c.nombre||' | '||p.nombre||';'||l.nombre colegio " +
                     "from colegios c, localidades l, estados e, paises p " +
                     "where c.num_sec_localidad = l.num_sec " +
                     "and l.num_sec_estado = e.num_sec " +
                     "and e.num_sec_pais = p.num_sec " +
                     "order by colegio";
            return strSql;
        }

        public string SQLListadoColegioPorPais(string strNSPais)
        {
            strSql = "select a.num_sec num_sec_colegio, b.num_sec num_sec_localidad, a.nombre colegio, b.nombre ciudad, c.nombre estado, d.nombre pais " +
                     "from colegios a, localidades b, estados c, paises d " +
                     "where a.num_sec_localidad = b.num_sec " +
                     "and b.num_sec_estado = c.num_sec " +
                     "and c.num_sec_pais = " + strNSPais + " " +
                     "and c.num_sec_pais = d.num_sec " +
                     "order by colegio";
            return strSql;
        }
        public DataTable dtColegiosLocalidad()
        {
            strSql = "select a.num_sec num_sec_colegio, b.num_sec num_sec_localidad, a.nombre colegio " +
                     "from colegios a, localidades b" +
                     " where a.num_sec_localidad = b.num_sec " +
                     "and b.num_sec="+_num_sec_localidad+
                     "order by colegio";
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }
        #endregion
    }
}