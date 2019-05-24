using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using nsiBD_Interfaces;
using nsGEN_OracleBD;
using nsGEN_Mensajes;
using nsGEN_Cadenas;

namespace nsBD_GEN
{
    // Creado por: Willy Tenorio Palza; Fecha: 10/11/2015
    // Ultima modificación: 
    // Descripción: Clase referente a la tabla TITULOS

    public class BD_Titulos : iBD_Tablas
    {
        #region Variables Locales

        GEN_OracleBD OracleBD = new GEN_OracleBD();
        GEN_Mensajes libMensajes = new GEN_Mensajes();
        GEN_Cadenas libCadenas = new GEN_Cadenas();
        private string strSql = string.Empty;

        #endregion

        #region Atributos

        // Campos de la tabla TITULOS
        private long _num_sec = 0;                     
        private string _numero = string.Empty;         
        private short _tipo = 0;                       
        private long _num_sec_persona = 0;             
        private long _num_sec_carrera = 0;             
        private string _titulo_en = string.Empty;      
        private short _unidad_titulacion = 0;          
        private string _codigo_usuario = string.Empty; 
        private short _grado_titulo = 0;               
        private short _activo = 0;                     
        private string _fecha = string.Empty;          
        private string _num_resolucion = string.Empty; 
        private short _tipo_defensa = 0;               
        private string _fecha_defensa = string.Empty;  
        private string _fecha_emision = string.Empty;  
        private string _fecha_legal = string.Empty;    
        private string _fecha_entrega = string.Empty;  
        private string _folio = string.Empty;          
        private string _partida = string.Empty;        
        private string _libro = string.Empty;          
        private string _observaciones = string.Empty;  
        private string _nombre_tesis = string.Empty;   
        private short _nota_tesis = 0;                 

        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        // Definicion GET y SET de los campos de la tabla TITULOS
        public long NumSec { get { return _num_sec; } set { _num_sec = value; } }
        public string Numero { get { return _numero; } set { _numero = value; } }
        public short Tipo { get { return _tipo; } set { _tipo = value; } }
        public long NumSecPersona { get { return _num_sec_persona; } set { _num_sec_persona = value; } }
        public long NumSecCarrera { get { return _num_sec_carrera; } set { _num_sec_carrera = value; } }
        public string TituloEn { get { return _titulo_en; } set { _titulo_en = value; } }
        public short UnidadTitulacion { get { return _unidad_titulacion; } set { _unidad_titulacion = value; } }
        public string CodigoUsuario { get { return _codigo_usuario; } set { _codigo_usuario = value; } }
        public short GradoTitulo { get { return _grado_titulo; } set { _grado_titulo = value; } }
        public short Activo { get { return _activo; } set { _activo = value; } }
        public string Fecha { get { return _fecha; } set { _fecha = value; } }
        public string NumResolucion { get { return _num_resolucion; } set { _num_resolucion = value; } }
        public short TipoDefensa { get { return _tipo_defensa; } set { _tipo_defensa = value; } }
        public string FechaDefensa { get { return _fecha_defensa; } set { _fecha_defensa = value; } }
        public string FechaEmision { get { return _fecha_emision; } set { _fecha_emision = value; } }
        public string FechaLegal { get { return _fecha_legal; } set { _fecha_legal = value; } }
        public string FechaEntrega { get { return _fecha_entrega; } set { _fecha_entrega = value; } }
        public string Folio { get { return _folio; } set { _folio = value; } }
        public string Partida { get { return _partida; } set { _partida = value; } }
        public string Libro { get { return _libro; } set { _libro = value; } }
        public string Observaciones { get { return _observaciones; } set { _observaciones = value; } }
        public string NombreTesis { get { return _nombre_tesis; } set { _nombre_tesis = value; } }
        public short NotaTesis { get { return _nota_tesis; } set { _nota_tesis = value; } }
		
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

        // Definición del contructor de la clase TITULOS
        public BD_Titulos()
        {
            _num_sec = 0;                   
            _numero = string.Empty;         
            _tipo = 0;                      
            _num_sec_persona = 0;           
            _num_sec_carrera = 0;           
            _titulo_en = string.Empty;      
            _unidad_titulacion = 0;         
            _codigo_usuario = string.Empty; 
            _grado_titulo = 0;              
            _activo = 0;                    
            _fecha = string.Empty;          
            _num_resolucion = string.Empty; 
            _tipo_defensa = 0;              
            _fecha_defensa = string.Empty;  
            _fecha_emision = string.Empty;  
            _fecha_legal = string.Empty;    
            _fecha_entrega = string.Empty;  
            _folio = string.Empty;          
            _partida = string.Empty;        
            _libro = string.Empty;          
            _observaciones = string.Empty;  
            _nombre_tesis = string.Empty;   
            _nota_tesis = 0;                

            _mensaje = string.Empty;
            _strconexion = string.Empty;
        }

        #endregion

        #region Metodos iBD_Tablas

        // Método para insertar un dato en la tabla TITULOS
        public bool Insertar()
        {
            bool OperacionCorrecta = false;
            return OperacionCorrecta;
        }

        // Método para MODIFICAR un dato en la tabla TITULOS
        public bool Modificar()
        {
            bool OperacionCorrecta = false;
            return OperacionCorrecta;
        }

        // Método para ELIMINAR un dato en la tabla TITULOS
        public bool Borrar()
        {
            bool OperacionCorrecta = false;
            return OperacionCorrecta;
        }

        // Método para VER un dato en la tabla TITULOS
        public bool Ver()
        {
            bool OperacionCorrecta = false;
            return OperacionCorrecta;
        }

        #endregion

        #region Procedimientos y Funciones Publicas

        public bool RevisarAlumnoTitulado()
        {
            strSql = "select distinct num_sec_carrera " +
                     "from  " +
                     "( " +
                     "	select num_sec_carrera " +
                     "	from ucbadmin.titulos " +
                     "	where num_sec_persona = " + _num_sec_persona.ToString().Trim() + " " +
                     "	UNION  " +
                     "	select num_sec_carrera " +
                     "	from ucbadmin.egresados_titulados " +
                     "	where num_sec_persona = " + _num_sec_persona.ToString().Trim() + " " +
                     "	and tipo = 3 " +
                     ")";
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            if (OracleBD.DataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }

        #endregion
    }
}