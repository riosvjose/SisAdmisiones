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
    // Creado por: Willy Tenorio Palza; Fecha: 10/11/2015
    // Ultima modificación: 
    // Descripción: Clase referente a la tabla PAISES

    public class BD_Paises : iBD_Tablas
    {
        #region Variables Locales

        GEN_OracleBD OracleBD = new GEN_OracleBD();
        GEN_Mensajes libMensajes = new GEN_Mensajes();
        GEN_Cadenas libCadenas = new GEN_Cadenas();
        private string strSql = string.Empty;

        #endregion

        #region Atributos

        // Campos de la tabla PAISES
        private long _num_sec = 0;                   
        private string _nombre = string.Empty;       
        private string _nacionalidad = string.Empty; 

        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        // Definicion GET y SET de los campos de la tabla PAISES
        public long NumSec { get { return _num_sec; } set { _num_sec = value; } }
        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public string Nacionalidad { get { return _nacionalidad; } set { _nacionalidad = value; } }
		
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

        // Definición del contructor de la clase PAISES
        public BD_Paises()
        {
            _num_sec = 0;                 
            _nombre = string.Empty;       
            _nacionalidad = string.Empty; 

            _mensaje = string.Empty;
            _strconexion = string.Empty;
        }

        #endregion

        #region Metodos iBD_Tablas

        // Método para insertar un dato en la tabla PAISES
        public bool Insertar()
        {
            bool OperacionCorrecta = false;
            return OperacionCorrecta;
        }

        // Método para MODIFICAR un dato en la tabla PAISES
        public bool Modificar()
        {
            bool OperacionCorrecta = false;
            return OperacionCorrecta;
        }

        // Método para ELIMINAR un dato en la tabla PAISES
        public bool Borrar()
        {
            bool OperacionCorrecta = false;
            return OperacionCorrecta;
        }

        // Método para VER un dato en la tabla PAISES
        public bool Ver()
        {
            strSql = "select nombre, nacionalidad " +
                    "from paises " +
                    "where num_sec = " + _num_sec;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            if (OracleBD.DataTable.Rows.Count == 0)
            {
                _nombre = string.Empty;
                _nacionalidad = string.Empty;
            }
            else
            {
                _nombre = OracleBD.DataTable.Rows[0][0].ToString().Trim();
                _nacionalidad = OracleBD.DataTable.Rows[0][1].ToString().Trim();
            }
            return true;
        }

        #endregion

        #region Procedimientos y Funciones Locales


        #endregion

        #region Procedimientos y Funciones Publicos

        // Método para desplegar listado de las Paises
        public DataTable ListaPaises()
        {
            strSql = "select num_sec, nombre, nacionalidad " +
                     "from paises " +
                     "order by nombre";
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }

        #endregion
    }
}