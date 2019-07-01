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
    // Descripción: Clase referente a la tabla ADMIS_DATOS_TUTOR

    public class BD_ADMIS_DatosTutor : iBD_Tablas
    {
        #region Variables Locales

        GEN_OracleBD OracleBD = new GEN_OracleBD();
        GEN_Mensajes libMensajes = new GEN_Mensajes();
        GEN_Cadenas libCadenas = new GEN_Cadenas();
        SIS_GeneralesSistema GeneralesSistema = new SIS_GeneralesSistema();
        private string strSql = string.Empty;

        #endregion

        #region Atributos

        // Campos de la tabla ADMIS_DATOS_TUTOR
        private long _num_sec_datos_personales = 0;
        private short _tipo_tutor = 0;
        private long _num_sec_persona = 0;
        private string _primer_apellido = string.Empty;
        private string _segundo_apellido = string.Empty;
        private string _nombres = string.Empty;
        private string _documento_identidad = string.Empty;
        private short _tipo_doc = 0;
        private short _genero = 0;
        private string _avenida_calle = string.Empty;
        private string _numero = string.Empty;
        private string _zona = string.Empty;
        private string _edificio = string.Empty;
        private string _depto = string.Empty;
        private string _piso = string.Empty;
        private long _telefono = 0;
        private string _celular = string.Empty;
        private string _email = string.Empty;
        private string _institucion_trabajo = string.Empty;
        private string _cargo = string.Empty;
        private string _telefono_trabajo = string.Empty;
        private int _autorizacion_seguimiento = 0;
        public string _usuario_registro = string.Empty;
        public string _fecha_registro = string.Empty;

        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        // Definicion GET y SET de los campos de la tabla ADMIS_DATOS_TUTOR
        public long NumSecPersona { get { return _num_sec_persona; } set { _num_sec_persona = value; } }
        public long NumSecDatosPer { get { return _num_sec_datos_personales; } set { _num_sec_datos_personales = value; } }
        public string DocIdentidad { get { return _documento_identidad; } set { _documento_identidad = value; } }
        public short TipoDocIdentidad { get { return _tipo_doc; } set { _tipo_doc = value; } }
        public short TipoTutor { get { return _tipo_tutor; } set { _tipo_tutor = value; } }
        public string PrimerApellido { get { return _primer_apellido; } set { _primer_apellido = value; } }
        public string SegundoApellido { get { return _segundo_apellido; } set { _segundo_apellido = value; } }
        public string Nombres { get { return _nombres; } set { _nombres = value; } }
        public short Genero { get { return _genero; } set { _genero = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public long Telefono { get { return _telefono; } set { _telefono = value; } }
        public string Celular { get { return _celular; } set { _celular = value; } }
        public string AvenidaCalle { get { return _avenida_calle; } set { _avenida_calle = value; } }
        public string Numero { get { return _numero; } set { _numero = value; } }
        public string Zona { get { return _zona; } set { _zona = value; } }
        public string Edificio { get { return _edificio; } set { _edificio = value; } }
        public string Piso { get { return _piso; } set { _piso = value; } }
        public string Depto { get { return _depto; } set { _depto = value; } }
        public int AutSeguimiento { get { return _autorizacion_seguimiento; } set { _autorizacion_seguimiento = value; } }
        public string InstitucionTrabajo { get { return _institucion_trabajo; } set { _institucion_trabajo = value; } }
        public string Cargo { get { return _cargo; } set { _cargo = value; } }
        public string TelefonoTrabajo { get { return _telefono_trabajo; } set { _telefono_trabajo = value; } }
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

        // Definición del contructor de la clase ADMIS_DATOS_TUTOR
        public BD_ADMIS_DatosTutor()
        {
            _num_sec_datos_personales = 0;
            _num_sec_persona = 0;
            _primer_apellido = string.Empty;
            _segundo_apellido = string.Empty;
            _nombres = string.Empty;
            _documento_identidad = string.Empty;
            _tipo_doc = 0;
            _genero = 0;
            _avenida_calle = string.Empty;
            _numero = string.Empty;
            _zona = string.Empty;
            _edificio = string.Empty;
            _depto = string.Empty;
            _telefono = 0;
            _celular = string.Empty;
            _email = string.Empty;
            _piso = string.Empty;
            _tipo_tutor = 0;
            _institucion_trabajo = string.Empty;
            _cargo = string.Empty;
            _telefono_trabajo = string.Empty;
            _autorizacion_seguimiento = 0;
            _usuario_registro = string.Empty;
            _fecha_registro = string.Empty;

            _mensaje = string.Empty;
            _strconexion = string.Empty;
        }

        #endregion

        #region Metodos iBD_Tablas

        // Método para insertar un dato en la tabla ADMIS_DATOS_TUTOR
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
                    _mensaje = "No fue posible insertar el dato. Se encontró un error al insertar en la tabla ADMIS_DATOS_TUTOR. " + _mensaje;
            }
            return blOperacionCorrecta;
        }

        // Método para MODIFICAR un dato en la tabla ADMIS_DATOS_TUTOR
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
                    _mensaje = "No fue posible modificar el dato. Se encontró un error al modificar en la tabla ADMIS_DATOS_TUTOR. " + _mensaje;
            }
            return blOperacionCorrecta;
        }

        // Método para ELIMINAR un dato en la tabla ADMIS_DATOS_TUTOR
        public bool Borrar()
        {
            bool blOperacionCorrecta = false;
            return blOperacionCorrecta;
        }

        // Método para VER un dato en la tabla ADMIS_DATOS_TUTOR
        public bool Ver()
        {
            bool blEncontrado = false;
            string strSql = string.Empty;
            if (!string.IsNullOrEmpty(_num_sec_datos_personales.ToString()))
            {
                strSql = "select a.*, to_char(a.FECHA_REGISTRO, 'dd/mm/yyyy') as FECHA_REGISTRO_FORMATO" +
                         " from ADMIS_DATOS_TUTOR a" +
                         " where a.num_sec_datos_per = " + _num_sec_datos_personales;
                OracleBD.MostrarError = false;
                OracleBD.StrConexion = _strconexion;
                OracleBD.Sql = strSql;
                OracleBD.sqlDataTable();
                if (OracleBD.DataTable.Rows.Count > 0)
                {
                    blEncontrado = true;
                    _num_sec_datos_personales = Convert.ToInt64(OracleBD.DataTable.Rows[0]["NUM_SEC_DATOS_PER"].ToString());
                    _primer_apellido = OracleBD.DataTable.Rows[0]["PRIMER_APELLIDO"].ToString();
                    _segundo_apellido = OracleBD.DataTable.Rows[0]["SEGUNDO_APELLIDO"].ToString();
                    _nombres = OracleBD.DataTable.Rows[0]["NOMBRES"].ToString();
                    _documento_identidad = OracleBD.DataTable.Rows[0]["DOC_IDENTIDAD"].ToString();
                    _tipo_doc = Convert.ToInt16(OracleBD.DataTable.Rows[0]["TIPO_DOC"].ToString());
                    _genero = Convert.ToInt16(OracleBD.DataTable.Rows[0]["GENERO"].ToString());
                    _tipo_tutor = Convert.ToInt16(OracleBD.DataTable.Rows[0]["TIPO_TUTOR"].ToString());
                    _avenida_calle = OracleBD.DataTable.Rows[0]["AVENIDA_CALLE"].ToString();
                    _numero = OracleBD.DataTable.Rows[0]["NUMERO"].ToString();
                    _zona = OracleBD.DataTable.Rows[0]["ZONA"].ToString();
                    _edificio =  OracleBD.DataTable.Rows[0]["EDIFICIO"].ToString();
                    _depto = OracleBD.DataTable.Rows[0]["DEPTO"].ToString();
                    _piso = OracleBD.DataTable.Rows[0]["PISO"].ToString();
                    _telefono = Convert.ToInt32(OracleBD.DataTable.Rows[0]["TELEFONO"].ToString());
                    _celular = OracleBD.DataTable.Rows[0]["CELULAR"].ToString();
                    _institucion_trabajo = OracleBD.DataTable.Rows[0]["INSTITUCION_TRABAJO"].ToString();
                    _cargo = OracleBD.DataTable.Rows[0]["CARGO"].ToString();
                    _telefono_trabajo = OracleBD.DataTable.Rows[0]["TELEFONO_TRABAJO"].ToString();
                    _autorizacion_seguimiento = Convert.ToInt16(OracleBD.DataTable.Rows[0]["autorizacion_seguimiento"].ToString());
                    _email = OracleBD.DataTable.Rows[0]["CORREO_ELECTRONICO"].ToString();
                    _num_sec_persona = Convert.ToInt64(OracleBD.DataTable.Rows[0]["NUM_SEC_PERSONA"].ToString());
                    _usuario_registro = OracleBD.DataTable.Rows[0]["USUARIO_REGISTRO"].ToString();
                    _fecha_registro = OracleBD.DataTable.Rows[0]["FECHA_REGISTRO_FORMATO"].ToString();
                }
            }
            if (!blEncontrado)
            {
                _num_sec_datos_personales = 0;
                _primer_apellido = string.Empty;
                _segundo_apellido = string.Empty;
                _nombres = string.Empty;
                _documento_identidad = string.Empty;
                _tipo_doc = 0;
                _genero = 0;
                _tipo_tutor = 0;
                _avenida_calle = string.Empty;
                _numero = string.Empty;
                _zona = string.Empty;
                _piso = string.Empty;
                _edificio = string.Empty;
                _depto = string.Empty;
                _telefono = 0;
                _celular = string.Empty;
                _email = string.Empty;
                _num_sec_persona = 0;   
     
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
            strSql = "insert into ADMIS_DATOS_TUTOR " +
                        "(NUM_SEC_DATOS_PER, TIPO_TUTOR, PRIMER_APELLIDO, NOMBRES, SEGUNDO_APELLIDO, DOC_IDENTIDAD, TIPO_DOC, GENERO," +
                        " AVENIDA_CALLE, NUMERO, ZONA, EDIFICIO, PISO, DEPTO,TELEFONO, CELULAR, CORREO_ELECTRONICO, NUM_SEC_PERSONA,  " +
                        " INSTITUCION_TRABAJO, CARGO, TELEFONO_TRABAJO, AUTORIZACION_SEGUIMIENTO, " +
                        " FECHA_REGISTRO, USUARIO_REGISTRO) " +
                        "values " +
                        "(" + _num_sec_datos_personales + ", " +
                        _tipo_tutor + "," +
                        " upper('" + _primer_apellido + "')," +
                        " upper('" + _nombres + "')," +
                        " upper('" + _segundo_apellido + "')," +
                        " upper('" + _documento_identidad + "')," +
                        _tipo_doc + "," +
                        _genero + "," +
                        " upper('" + _avenida_calle + "')," +
                        " upper('" + _numero + "')," +
                        " upper('" + _zona + "')," +
                        " upper('" + _edificio + "')," +
                        " upper('" + _piso + "')," +
                        " upper('" + _depto + "')," +
                        _telefono + "," +
                        " upper('" + _celular + "')," +
                        " upper('" + _email + "')," +
                        _num_sec_persona +","+
                        " upper('" + _institucion_trabajo + "')," +
                        " upper('" + _cargo + "')," +
                        " upper('" + _telefono_trabajo + "')," +
                        " upper('" + _autorizacion_seguimiento + "')," +
                        " sysdate, " +
                        " upper('" + _usuario_registro + "'))";
            return strSql;
        }
        public string cadSqlActualizar()
        {
            strSql = "update ADMIS_DATOS_TUTOR set " +
                        " PRIMER_APELLIDO= upper('" + _primer_apellido + "')" +
                        " ,NOMBRES= upper('" + _nombres + "')" +
                        " ,SEGUNDO_APELLIDO= upper('" + _segundo_apellido + "')" +
                        " ,DOC_IDENTIDAD= upper('" + _documento_identidad + "')" +
                        " ,TIPO_DOC=" + _tipo_doc +
                        " ,GENERO=" + _genero +
                        " ,TIPO_TUTOR=" + _tipo_tutor +
                        " ,AVENIDA_CALLE= upper('" + _avenida_calle + "')" +
                        " ,NUMERO= upper('" + _numero + "')" +
                        " ,ZONA= upper('" + _zona + "')" +
                        " ,EDIFICIO= upper('" + _edificio + "')" +
                        " ,PISO= upper('" + _piso + "')" +
                        " ,DEPTO= upper('" + _depto + "')" +
                        " ,TELEFONO=" + _telefono +
                        " ,CELULAR= upper('" + _celular + "')" +
                        " ,CORREO_ELECTRONICO= upper('" + _email + "')" +
                        " ,NUM_SEC_PERSONA=" + _num_sec_persona +
                        " ,INSTITUCION_TRABAJO =   upper('" + _institucion_trabajo+"')"+
                        " ,CARGO= upper('" + _cargo +"')"+
                        " ,TELEFONO_TRABAJO=  upper('" + _telefono_trabajo +"')"+
                        " ,AUTORIZACION_SEGUIMIENTO= " + _autorizacion_seguimiento +
                        " ,FECHA_REGISTRO=sysdate" +
                        " ,USUARIO_REGISTRO= upper('" + _usuario_registro + "')" +
                        " where num_sec_datos_per = " + _num_sec_datos_personales;
            return strSql;
        }
        #endregion
    }
}