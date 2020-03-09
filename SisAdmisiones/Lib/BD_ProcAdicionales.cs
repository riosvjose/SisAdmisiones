using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using nsGEN_OracleBD;
using nsGEN_VarSession;
using System.Security.Cryptography;
using System.Text;

namespace SisAdmisiones
{
    // Creado por: Ignacio Rios Villanueva; Fecha: 07/09/218
    // Ultima modificación: Ignacio Rios Villanueva; Fecha: 16/01/2019
    // Descripción: Clase para obtener datos adicionales 
    public class BD_ProcAdicionales
    {
        #region Librerias Externas

        GEN_OracleBD OracleBD = new GEN_OracleBD();
        GEN_VarSession axVarSes = new GEN_VarSession();

        #endregion

        #region Variables Locales

        private string strSql = string.Empty;

        #endregion

        #region Atributos

        private long _num_sec_persona = 0;
        private long _num_sec_depto = 0;
        private string _fecha_registro = string.Empty;
        private string _usuario_registro = string.Empty;


        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        // Definicion GET y SET de los campos
        public long NumSecPersona { get { return _num_sec_persona; } set { _num_sec_persona = value; } }
        public long NumSecDepto { get { return _num_sec_depto; } set { _num_sec_depto = value; } }
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

        // Definición del contructor 
        public BD_ProcAdicionales()
        {
            _num_sec_persona = 0;
            _num_sec_depto = 0;
            _fecha_registro = string.Empty;
            _usuario_registro = string.Empty;

            _mensaje = string.Empty;
            _strconexion = string.Empty;
        }

        #endregion

        #region Metodos iBD_Tablas y Públicos

        // Método para insertar un dato en la tabla
        public bool Insertar()
        {
            bool blOperacionCorrecta = false;
            return blOperacionCorrecta;
        }

        // Método para MODIFICAR un dato
        public bool Modificar()
        {
            bool blOperacionCorrecta = false;
            return blOperacionCorrecta;
        }
        // Método para eliminar un dato 
        public bool Borrar()
        {
            bool blOperacionCorrecta = false;
            return blOperacionCorrecta;
        }

        // Método para VER un dato 
        public bool Ver()
        {
            bool blOperacionCorrecta = false;
            return blOperacionCorrecta;
        }

        #endregion

        #region Procedimientos y Funciones Locales


        #endregion

        #region Procedimientos y Funciones Públicos
        //Indica si un usuario puede o no acceder a un objeto
        public bool AccesoObjetoUsuario(string nombre_objeto)
        {            
            bool existe = false;
            string struser = axVarSes.Lee<string>("UsuarioNumSec");
            DataTable dt = new DataTable();
            strSql = "SELECT distinct o.num_sec_objeto " +
                    " FROM sam_usuarios_funciones fu, sam_funciones f, sam_accesos a, sam_objetos o " +
                    " WHERE fu.num_sec_usuario= " + struser +
                    " and o.nombre like '"+nombre_objeto+"%'"+
                    " and a.acceso=1"+
                    " and fu.num_sec_funcion=f.num_sec_funcion" +
                    " and f.num_sec_funcion=a.num_sec_funcion"+
                    " and a.num_sec_objeto=o.num_sec_objeto";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            if (dt.Rows.Count >0)
            {
                existe = true;
            }
            dt.Dispose();
            return existe;
        }
        //Obtiene en una lista todos los objetos a los que puede acceder un usuario
        public List<string> ListaAccesoObjetoUsuario()
        {
            List<string> AccesoObjeto = new List<string>();
            string strUser = axVarSes.Lee<string>("UsuarioNumSec");
            DataTable dt = new DataTable();
            strSql = "SELECT distinct o.num_sec_objeto, o.nombre " +
                        "FROM sam_usuarios_funciones fu, sam_funciones f, sam_accesos a, sam_objetos o " +
                        "WHERE fu.num_sec_usuario = " + strUser +
                        " and o.nombre like 'ADMIS_%' " + //Obtener todos los objetos que tienen el modulo admisiones
                        "and a.acceso = 1 " +
                        "and fu.num_sec_funcion = f.num_sec_funcion " +
                        "and f.num_sec_funcion = a.num_sec_funcion " +
                        "and a.num_sec_objeto = o.num_sec_objeto " +
                        "ORDER BY o.nombre";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            if (dt.Rows.Count > 0)
            {
                for (int x=0; dt.Rows.Count>x; x++)
                {
                    DataRow dr = dt.Rows[x];
                    AccesoObjeto.Add(dr["nombre"].ToString());
                }
            }
            dt.Dispose();
            return AccesoObjeto;
        }

        // devuelve true si la fecha indicada es menor o igual a la fecha actual
        public bool FechaMenorIgualHoy(string fecha)
        {
            bool menorigual = false;
            int dia = 0;
            DataTable dt = new DataTable();
            strSql = "SELECT trunc(sysdate) - To_Date('" + fecha.ToString().Trim() + "', 'dd/mm/yyyy') as dia FROM dual";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            if (dt.Rows.Count == 1)
            {
                DataRow dr = dt.Rows[0];
                dia = Convert.ToInt32(dr["dia"].ToString());
                if (dia >= 0)
                {
                    menorigual = true;
                }
            }
            dt.Dispose();
            return menorigual;
        }


        public bool VerificarPassword(string ci, string password)
        {
            bool verificado = false;
            string hash = string.Empty, contrasena=string.Empty;
            DataTable dt = new DataTable();
            strSql = "select ucbadmin.fn_encriptar_texto('"+password+"') as contr from dual";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            if (dt.Rows.Count == 1)
            {
                DataRow dr = dt.Rows[0];
                hash = dr["contr"].ToString();
                strSql = "select pp.password as contr" +
                        " from personas_passwords pp, personas p" +
                        " where p.doc_identidad=" + ci +
                        " and p.num_sec=pp.num_sec_persona";
                OracleBD.MostrarError = false;
                OracleBD.StrConexion = _strconexion;
                OracleBD.Sql = strSql;
                OracleBD.sqlDataTable();
                dt = OracleBD.DataTable;
                if (dt.Rows.Count == 1)
                {
                    dr = dt.Rows[0];
                    contrasena = dr["contr"].ToString();
                    if(hash.ToUpper().Equals(contrasena.ToUpper()))
                    {
                        verificado = true;
                    }
                }
            }
            dt.Dispose();
            return verificado;
        }

        public string strFechaActual()
        {
            string fecha = string.Empty;
            DataTable dt = new DataTable();
            strSql = "SELECT to_char(sysdate,'dd/mm/yyyy HH:mi') as dia FROM dual";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            if (dt.Rows.Count == 1)
            {
                DataRow dr = dt.Rows[0];
                fecha =dr["dia"].ToString();
            }
            dt.Dispose();
            return fecha;
        }
        #endregion
    }
}