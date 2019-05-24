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
    // Descripción: Clase referente a la tabla ESTADOS

    public class BD_Estados : iBD_Tablas
    {
        #region Variables Locales

        GEN_OracleBD OracleBD = new GEN_OracleBD();
        GEN_Mensajes libMensajes = new GEN_Mensajes();
        GEN_Cadenas libCadenas = new GEN_Cadenas();
        private string strSql = string.Empty;

        #endregion

        #region Atributos

        // Campos de la tabla ESTADOS
        private long _num_sec = 0;             
        private long _num_sec_pais = 0;        
        private string _nombre = string.Empty; 

        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        // Definicion GET y SET de los campos de la tabla ESTADOS
        public long NumSec { get { return _num_sec; } set { _num_sec = value; } }
        public long NumSecPais { get { return _num_sec_pais; } set { _num_sec_pais = value; } }
        public string Nombre { get { return _nombre; } set { _nombre = value; } }
		
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

        // Definición del contructor de la clase ESTADOS
        public BD_Estados()
        {
            _num_sec = 0;           
            _num_sec_pais = 0;      
            _nombre = string.Empty; 

            _mensaje = string.Empty;
            _strconexion = string.Empty;
        }

        #endregion

        #region Metodos iBD_Tablas

        // Método para insertar un dato en la tabla ESTADOS
        public bool Insertar()
        {
            bool OperacionCorrecta = false;
            return OperacionCorrecta;
        }

        // Método para MODIFICAR un dato en la tabla ESTADOS
        public bool Modificar()
        {
            bool OperacionCorrecta = false;
            return OperacionCorrecta;
        }

        // Método para ELIMINAR un dato en la tabla ESTADOS
        public bool Borrar()
        {
            bool OperacionCorrecta = false;
            return OperacionCorrecta;
        }

        // Método para VER un dato en la tabla ESTADOS
        public bool Ver()
        {
            bool OperacionCorrecta = false;
            return OperacionCorrecta;
        }

        #endregion

        #region Procedimientos y Funciones Locales

        #endregion

        #region Procedimientos y Funciones Públicos

        // Método para desplegar listado de las Estados, filtrado por paises
        public DataTable ListaEstados(string NSPais)
        {
            strSql = "select num_sec, nombre " +
                    "from estados " +
                    "where num_sec_pais = " + NSPais + " " +
                    "order by nombre";
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }

        // Método para desplegar el pais de un estado
        public string PaisEstado()
        {
            strSql = "select num_sec_pais " +
                    "from estados " +
                    "where num_sec = " + _num_sec;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable.Rows[0][0].ToString().Trim();
        }

        #endregion
    }
}