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
    // Descripción: Clase referente a la tabla ADMIS_DATOS_PERSONALES

    public class BD_ADMIS_DatosPersonales : iBD_Tablas
    {
        #region Variables Locales

        GEN_OracleBD OracleBD = new GEN_OracleBD();
        GEN_Mensajes libMensajes = new GEN_Mensajes();
        GEN_Cadenas libCadenas = new GEN_Cadenas();
        SIS_GeneralesSistema GeneralesSistema = new SIS_GeneralesSistema();
        private string strSql = string.Empty;

        #endregion

        #region Atributos

        // Campos de la tabla ADMIS_DATOS_PERSONALES
        private long _num_sec_datos_personales = 0;
        private string _primer_apellido = string.Empty;
        private string _segundo_apellido = string.Empty;
        private string _nombres = string.Empty;
        private string _documento_identidad = string.Empty;
        private short _tipo_doc = 0;
        private short _genero = 0;
        private short _grupo_sangre = 0;
        private short _estado_civil = 0;
        private short _tipo_discapacidad = 0;
        private string _avenida_calle = string.Empty;
        private string _numero = string.Empty;
        private string _zona = string.Empty;
        private string _edificio = string.Empty;
        private string _piso = string.Empty;
        private string _depto = string.Empty;
        private long _telefono = 0;
        private string _celular = string.Empty;
        private string _email = string.Empty;
        private short _vive_con = 0;
        private string _fecha_nacimiento = string.Empty;
        private long _num_sec_localidad_nacimiento = 0;
        private long _num_sec_nacionalidad = 0;
        private long _num_sec_colegio = 0;
        private int _anio_egreso = 0;
        private short _tipo_colegio = 0;
        private short _turno = 0;
        private long _num_sec_localidad_bachillerato = 0;
        private short _area_bachillerato = 0;
        private long _num_sec_persona = 0;
        private short _estado = 0;
        private long _num_sec_semestre = 0;
        private long _num_sec_subdepartamento = 0;
        public string _observaciones = string.Empty;
        public string _usuario_registro = string.Empty;
        public string _fecha_registro = string.Empty;

        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        // Definicion GET y SET de los campos de la tabla ADMIS_DATOS_PERSONALES
        public long NumSecPersona { get { return _num_sec_persona; } set { _num_sec_persona = value; } }
        public long NumSecDatosPer { get { return _num_sec_datos_personales; } set { _num_sec_datos_personales = value; } }
        public string DocIdentidad { get { return _documento_identidad; } set { _documento_identidad = value; } }
        public short TipoDocIdentidad { get { return _tipo_doc; } set { _tipo_doc = value; } }
        public short TipoDiscapacidad { get { return _tipo_discapacidad; } set { _tipo_discapacidad = value; } }
        public string PrimerApellido { get { return _primer_apellido; } set { _primer_apellido = value; } }
        public string SegundoApellido { get { return _segundo_apellido; } set { _segundo_apellido = value; } }
        public string Nombres { get { return _nombres; } set { _nombres = value; } }
        public short Genero { get { return _genero; } set { _genero = value; } }
        public short EstadoCivil { get { return _estado_civil; } set { _estado_civil = value; } }
        public short GrupoSangre { get { return _grupo_sangre; } set { _grupo_sangre = value; } }
        public long NumSecLocalidadNac { get { return _num_sec_localidad_nacimiento; } set { _num_sec_localidad_nacimiento = value; } }
        public string FechaNacimiento { get { return _fecha_nacimiento; } set { _fecha_nacimiento = value; } }
        public long NumSecNacionalidad { get { return _num_sec_nacionalidad; } set { _num_sec_nacionalidad = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public long NumSecSemestre { get { return _num_sec_semestre; } set { _num_sec_semestre = value; } }
        public long Telefono { get { return _telefono; } set { _telefono = value; } }
        public string Celular { get { return _celular; } set { _celular = value; } }
        public short ViveCon { get { return _vive_con; } set { _vive_con = value; } }
        public int AnioBachillerato { get { return _anio_egreso; } set { _anio_egreso = value; } }
        public long NumSecColegio { get { return _num_sec_colegio; } set { _num_sec_colegio = value; } }
        public short TipoColegio { get { return _tipo_colegio; } set { _tipo_colegio = value; } }
        public short AreaColegio { get { return _area_bachillerato; } set { _area_bachillerato = value; } }
        public short Turno { get { return _turno; } set { _turno = value; } }
        public long NumSecSubdepartamento { get { return _num_sec_subdepartamento; } set { _num_sec_subdepartamento = value; } }
        public long NumSecLocalidadBachillerato { get { return _num_sec_localidad_bachillerato; } set { _num_sec_localidad_bachillerato = value; } }
        public string AvenidaCalle { get { return _avenida_calle; } set { _avenida_calle = value; } }
        public string Numero { get { return _numero; } set { _numero = value; } }
        public string Zona { get { return _zona; } set { _zona = value; } }
        public string Edificio { get { return _edificio; } set { _edificio = value; } }
        public string Piso { get { return _piso; } set { _piso = value; } }
        public string Depto { get { return _depto; } set { _depto = value; } }
        public short Estado { get { return _estado; } set { _estado = value; } }
        public string Observaciones { get { return _observaciones; } set { _observaciones = value; } }
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

        // Definición del contructor de la clase ADMIS_DATOS_PERSONALES
        public BD_ADMIS_DatosPersonales()
        {
            _num_sec_datos_personales = 0;
            _primer_apellido = string.Empty;
            _segundo_apellido = string.Empty;
            _nombres = string.Empty;
            _documento_identidad = string.Empty;
            _tipo_doc = 0;
            _genero = 0;
            _grupo_sangre = 0;
            _tipo_discapacidad = 0;
            _estado_civil = 0;
            _tipo_discapacidad = 0;
            _avenida_calle = string.Empty;
            _numero = string.Empty;
            _zona = string.Empty;
            _edificio = string.Empty;
            _piso = string.Empty;
            _depto = string.Empty;
            _telefono = 0;
            _celular = string.Empty;
            _email = string.Empty;
            _vive_con = 0;
            _fecha_nacimiento = string.Empty;
            _num_sec_localidad_nacimiento = 0;
            _num_sec_nacionalidad = 0;
            _num_sec_colegio = 0;
            _anio_egreso = 0;
            _tipo_colegio = 0;
            _turno = 0;
            _num_sec_localidad_bachillerato = 0;
            _area_bachillerato = 0;
            _num_sec_persona = 0;
            _estado = 0;
            _num_sec_semestre = 0;
            _num_sec_subdepartamento = 0;
            _observaciones = string.Empty;
            _usuario_registro = string.Empty;
            _fecha_registro = string.Empty;

            _mensaje = string.Empty;
            _strconexion = string.Empty;
        }

        #endregion

        #region Metodos iBD_Tablas

        // Método para insertar un dato en la tabla ADMIS_DATOS_PERSONALES
        public bool Insertar()
        {
            bool blOperacionCorrecta = true;
            if (blOperacionCorrecta)
            {
                strSql = CadsqlInsert();
                OracleBD.MostrarError = false;
                OracleBD.StrConexion = _strconexion;
                OracleBD.Sql = strSql;
                OracleBD.EjecutarSqlTrans();

                _mensaje = OracleBD.Mensaje;
                blOperacionCorrecta = !OracleBD.Error;
                if (OracleBD.Error)
                    _mensaje = "No fue posible insertar el dato. Se encontró un error al insertar en la tabla ADMIS_DATOS_PERSONALES. " + _mensaje;
            }
            return blOperacionCorrecta;
        }

        // Método para MODIFICAR un dato en la tabla ADMIS_DATOS_PERSONALES
        public bool Modificar()
        {
            bool blOperacionCorrecta = true;
            if (blOperacionCorrecta)
            {
                strSql = CadsqlActualizar();
                OracleBD.MostrarError = false;
                OracleBD.StrConexion = _strconexion;
                OracleBD.Sql = strSql;
                OracleBD.EjecutarSqlTrans();

                _mensaje = OracleBD.Mensaje;
                blOperacionCorrecta = !OracleBD.Error;
                if (OracleBD.Error)
                    _mensaje = "No fue posible modificar el dato. Se encontró un error al modificar en la tabla ADMIS_DATOS_PERSONALES. " + _mensaje;
            }
            return blOperacionCorrecta;
        }

        // Método para ELIMINAR un dato en la tabla ADMIS_DATOS_PERSONALES
        public bool Borrar()
        {
            bool blOperacionCorrecta = false;
            return blOperacionCorrecta;
        }

        // Método para VER un dato en la tabla ADMIS_DATOS_PERSONALES
        public bool Ver()
        {
            bool blEncontrado = false;
            string strSql = string.Empty;
            if (!string.IsNullOrEmpty(_num_sec_datos_personales.ToString()))
            {
                strSql = "select a.*, to_char(a.FECHA_NACIMIENTO, 'yyyy-MM-dd') as fecha_nacimiento_formato, to_char(a.FECHA_REGISTRO, 'dd/mm/yyyy') as FECHA_REGISTRO_FORMATO" +
                         " from ADMIS_DATOS_PERSONALES a" +
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
                    _grupo_sangre = Convert.ToInt16(OracleBD.DataTable.Rows[0]["GRUPO_SANGUINEO"].ToString());
                    _estado_civil = Convert.ToInt16(OracleBD.DataTable.Rows[0]["ESTADO_CIVIL"].ToString());
                    _tipo_discapacidad = Convert.ToInt16(OracleBD.DataTable.Rows[0]["TIPO_DISCAPACIDAD"].ToString());
                    _avenida_calle = OracleBD.DataTable.Rows[0]["AVENIDA_CALLE"].ToString();
                    _numero = OracleBD.DataTable.Rows[0]["NUMERO"].ToString();
                    _zona = OracleBD.DataTable.Rows[0]["ZONA"].ToString();
                    _edificio = OracleBD.DataTable.Rows[0]["EDIFICIO"].ToString();
                    _piso = OracleBD.DataTable.Rows[0]["PISO"].ToString();
                    _depto = OracleBD.DataTable.Rows[0]["DEPTO"].ToString();
                    _telefono = Convert.ToInt32(OracleBD.DataTable.Rows[0]["TELEFONO"].ToString());
                    _celular = OracleBD.DataTable.Rows[0]["CELULAR"].ToString();
                    _email = OracleBD.DataTable.Rows[0]["EMAIL"].ToString();
                    _vive_con = Convert.ToInt16(OracleBD.DataTable.Rows[0]["VIVE_CON"].ToString());
                    _fecha_nacimiento = OracleBD.DataTable.Rows[0]["fecha_nacimiento_formato"].ToString();
                    _num_sec_localidad_nacimiento = Convert.ToInt64(OracleBD.DataTable.Rows[0]["NUM_SEC_LOCALIDAD_NACIMIENTO"].ToString());
                    _num_sec_nacionalidad = Convert.ToInt64(OracleBD.DataTable.Rows[0]["NUM_SEC_NACIONALIDAD"].ToString());
                    _num_sec_colegio = Convert.ToInt64(OracleBD.DataTable.Rows[0]["NUM_SEC_COLEGIO"].ToString());
                    _anio_egreso = Convert.ToInt32(OracleBD.DataTable.Rows[0]["ANIO_EGRESO"].ToString());
                    _tipo_colegio = Convert.ToInt16(OracleBD.DataTable.Rows[0]["TIPO_COLEGIO"].ToString());
                    _turno = Convert.ToInt16(OracleBD.DataTable.Rows[0]["TURNO"].ToString());
                    _num_sec_localidad_bachillerato = Convert.ToInt64(OracleBD.DataTable.Rows[0]["NUM_SEC_LOCALIDAD_BACHILLERATO"].ToString());
                    _area_bachillerato = Convert.ToInt16(OracleBD.DataTable.Rows[0]["AREA_BACHILLERATO"].ToString());
                    _num_sec_persona = Convert.ToInt64(OracleBD.DataTable.Rows[0]["NUM_SEC_PERSONA"].ToString());
                    _estado = Convert.ToInt16(OracleBD.DataTable.Rows[0]["ESTADO"].ToString());
                    _num_sec_semestre = Convert.ToInt64(OracleBD.DataTable.Rows[0]["num_sec_semestre"].ToString());
                    _num_sec_subdepartamento = Convert.ToInt64(OracleBD.DataTable.Rows[0]["NUM_SEC_SUBDEPARTAMENTO"].ToString());
                    _observaciones = OracleBD.DataTable.Rows[0]["OBSERVACIONES"].ToString();
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
                _tipo_discapacidad = 0;
                _genero = 0;
                _grupo_sangre = 0;
                _estado_civil = 0;
                _tipo_discapacidad = 0;
                _avenida_calle = string.Empty;
                _numero = string.Empty;
                _zona = string.Empty;
                _edificio = string.Empty;
                _piso = string.Empty;
                _depto = string.Empty;
                _telefono = 0;
                _celular = string.Empty;
                _email = string.Empty;
                _vive_con = 0;
                _fecha_nacimiento = string.Empty;
                _num_sec_localidad_nacimiento = 0;
                _num_sec_nacionalidad = 0;
                _num_sec_colegio = 0;
                _anio_egreso = 0;
                _tipo_colegio = 0;
                _turno = 0;
                _num_sec_localidad_bachillerato = 0;
                _area_bachillerato = 0;
                _num_sec_persona = 0;
                _estado = 0;
                _num_sec_semestre = 0;
                _num_sec_subdepartamento = 0;
                _observaciones = string.Empty;
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
                    " where ( upper(primer_apellido) like  upper('%" + parametro + "%') " +
                    " or  upper(segundo_apellido) like  upper('%" + parametro + "%') " +
                    " or  upper(nombres) like  upper('%" + parametro + "%') " +
                    " or  upper(doc_identidad) like  upper('%" + parametro + "%'))" +
                    " and estado = 1 order by primer_apellido, segundo_apellido, nombres";
            }
            else
            {
                strSql = "SELECT * FROM(";
                for (int i = 0; i < partes.Length; i++)
                {
                    if ((partes[i]!=" ")&&(!string.IsNullOrEmpty(partes[i]))) {
                        if (i >0)
                        {
                            strSql += " UNION ";
                        }
                        strSql += "(select * " +
                            "from " +
                            " admis_datos_personales" +
                            " where (upper(primer_apellido) like upper('%" + partes[i] + "%') " +
                            " or upper(segundo_apellido) like upper('%" + partes[i] + "%') " +
                            " or upper(nombres) like upper('%" + partes[i] + "%') " +
                            " or upper(doc_identidad) like  upper('%" + partes[i] + "%')))";
                        
                    }
                }
                strSql += ") where estado = 1 order by primer_apellido, segundo_apellido, nombres";
            }
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }

        public DataTable dtObtenerPersonasConsolidadas(string parametro)
        {
            string[] partes;
            partes = parametro.Split(' ');
            strSql = string.Empty;
            if (partes.Length == 1)
            {
                strSql = "select * " +
                    "from " +
                    " admis_datos_personales" +
                    " where ( upper(primer_apellido) like  upper('%" + parametro + "%') " +
                    " or  upper(segundo_apellido) like  upper('%" + parametro + "%') " +
                    " or  upper(nombres) like  upper('%" + parametro + "%') " +
                    " or  upper(doc_identidad) like  upper('%" + parametro + "%'))" +
                    " and estado = 0 order by primer_apellido, segundo_apellido, nombres";
            }
            else
            {
                strSql = "SELECT * FROM(";
                for (int i = 0; i < partes.Length; i++)
                {
                    if ((partes[i] != " ") && (!string.IsNullOrEmpty(partes[i])))
                    {
                        if (i > 0)
                        {
                            strSql += " UNION ";
                        }
                        strSql += "(select * " +
                            "from " +
                            " admis_datos_personales" +
                            " where estado = 0 and (upper(primer_apellido) like upper('%" + partes[i] + "%') " +
                            " or upper(segundo_apellido) like upper('%" + partes[i] + "%') " +
                            " or upper(nombres) like upper('%" + partes[i] + "%') " +
                            " or upper(doc_identidad) like  upper('%" + partes[i] + "%')))";

                    }
                }
                strSql += ") order by primer_apellido, segundo_apellido, nombres";
            }
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }

        public DataTable dtAnios()
        {
            strSql += "select to_char(sysdate,'rrrr')-rownum+1 anio from dominios where rownum <= 90";
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }
        public bool GenerarNS()
        {
            bool blEncontrado = false;
            strSql += "select admis_datos_personales_sec.nextval num_sec from dual";
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            if (OracleBD.DataTable.Rows.Count > 0)
            {
                blEncontrado = true;
                _num_sec_datos_personales = Convert.ToInt64(OracleBD.DataTable.Rows[0][0].ToString());
            }
            return blEncontrado;
        }
        public string CadsqlInsert()
        {
            strSql = "insert into ADMIS_DATOS_PERSONALES " +
                       "(NUM_SEC_DATOS_PER, PRIMER_APELLIDO, NOMBRES, SEGUNDO_APELLIDO, DOC_IDENTIDAD, TIPO_DOC, GENERO, GRUPO_SANGUINEO, ESTADO_CIVIL, TIPO_DISCAPACIDAD," +
                       " AVENIDA_CALLE, NUMERO, ZONA, EDIFICIO, PISO, DEPTO,TELEFONO, CELULAR, EMAIL, VIVE_CON, FECHA_NACIMIENTO, NUM_SEC_LOCALIDAD_NACIMIENTO, " +
                       " NUM_SEC_COLEGIO, ANIO_EGRESO, TIPO_COLEGIO, TURNO, NUM_SEC_LOCALIDAD_BACHILLERATO, AREA_BACHILLERATO,OBSERVACIONES, NUM_SEC_PERSONA," +
                       " ESTADO, NUM_SEC_SUBDEPARTAMENTO, num_sec_semestre, NUM_SEC_NACIONALIDAD, FECHA_REGISTRO, USUARIO_REGISTRO) " +
                       "values " +
                       "(" + _num_sec_datos_personales + ", " +
                       "upper('" + _primer_apellido + "')," +
                       "upper('" + _nombres + "')," +
                       "upper('" + _segundo_apellido + "')," +
                       "upper('" + _documento_identidad + "')," +
                       _tipo_doc + "," +
                       _genero + "," +
                       _grupo_sangre + "," +
                       _estado_civil + "," +
                       _tipo_discapacidad + "," +
                       "upper('" + _avenida_calle + "')," +
                       "upper('" + _numero + "')," +
                       "upper('" + _zona + "')," +
                       "upper('" + _edificio + "')," +
                       "upper('" + _piso + "')," +
                       "upper('" + _depto + "')," +
                       _telefono + "," +
                       "upper('" + _celular + "')," +
                       "upper('" + _email + "')," +
                       _vive_con + "," +
                       "to_date('" + _fecha_nacimiento + "','dd/mm/yyyy')," +
                       _num_sec_localidad_nacimiento + "," +
                       _num_sec_colegio + "," +
                       _anio_egreso + "," +
                       _tipo_colegio + "," +
                       _turno + "," +
                       _num_sec_localidad_bachillerato + "," +
                       _area_bachillerato + "," +
                       "upper('" + _observaciones + "')," +
                       _num_sec_persona + "," +
                       _estado + "," +
                       _num_sec_subdepartamento + "," +
                       _num_sec_semestre + "," +
                       _num_sec_nacionalidad + "," +
                       " sysdate, " +
                       "upper('" + _usuario_registro + "'))";
            return strSql;
        }
        public string CadsqlActualizar()
        {
            strSql = "update ADMIS_DATOS_PERSONALES set " +
                       " NUM_SEC_DATOS_PER=" + _num_sec_datos_personales +
                       ", PRIMER_APELLIDO= upper('" + _primer_apellido + "')" +
                       ", NOMBRES= upper('" + _nombres + "')" +
                       ", SEGUNDO_APELLIDO= upper('" + _segundo_apellido + "')" +
                       ", DOC_IDENTIDAD= upper('" + _documento_identidad + "')" +
                       ", TIPO_DOC=" + _tipo_doc +
                       ", GENERO=" + _genero +
                       ", GRUPO_SANGUINEO=" + _grupo_sangre +
                       ", ESTADO_CIVIL=" + _estado_civil +
                       ", TIPO_DISCAPACIDAD=" + _tipo_discapacidad +
                       ", AVENIDA_CALLE=  upper('" + _avenida_calle + "')" +
                       ", NUMERO= upper('" + _numero + "')" +
                       ", ZONA= upper('" + _zona + "')" +
                       ", EDIFICIO= upper('" + _edificio + "')" +
                       ", PISO= upper('" + _piso + "')" +
                       ", DEPTO= upper('" + _depto + "')" +
                       ", TELEFONO=" + _telefono +
                       ", CELULAR=  upper('" + _celular + "')" +
                       ", EMAIL= upper('" + _email + "')" +
                       ", VIVE_CON=" + _vive_con +
                       ", FECHA_NACIMIENTO= to_date('" + _fecha_nacimiento + "', 'dd/mm/yyyy')" +
                       ", NUM_SEC_LOCALIDAD_NACIMIENTO=" + _num_sec_localidad_nacimiento +
                       ", NUM_SEC_COLEGIO=" + _num_sec_colegio +
                       ", ANIO_EGRESO=" + _anio_egreso +
                       ", TIPO_COLEGIO=" + _tipo_colegio +
                       ", TURNO=" + _turno +
                       ", NUM_SEC_LOCALIDAD_BACHILLERATO=" + _num_sec_localidad_bachillerato +
                       ", AREA_BACHILLERATO=" + _area_bachillerato +
                       ", OBSERVACIONES= upper('" + _observaciones +"')"+
                       ", NUM_SEC_PERSONA=" + _num_sec_persona +
                       ", ESTADO =" + _estado +
                       ", NUM_SEC_SUBDEPARTAMENTO=" + _num_sec_subdepartamento +
                       ", NUM_SEC_SEMESTRE=" + _num_sec_semestre +
                       ", NUM_SEC_NACIONALIDAD=" + _num_sec_nacionalidad +
                       ", FECHA_REGISTRO=sysdate" +
                       ", USUARIO_REGISTRO=" + " upper('" + _usuario_registro + "')" +
                       " where num_sec_datos_per= " + _num_sec_datos_personales;
            return strSql;
        }
        public bool InsertarVarios(string[] listaSql, int intNumSqls)
        {
            bool blOperacionCorrecta = false;
            OracleBD.ListaSqls = listaSql;
            OracleBD.NumSqls = intNumSqls;
            OracleBD.StrConexion = _strconexion;
            OracleBD.EjecutarSqlsTrans();
            OracleBD.MostrarError = false;
            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible insertar los datos. " + _mensaje;
            return blOperacionCorrecta;
        }
        #endregion
    }
}