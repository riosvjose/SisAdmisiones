using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using nsGEN_OracleBD;
using nsBD_PER;
using nsBD_ACAD;
using nsGEN;

namespace nsBD_GEN
{
    // Creado por: Milco Cortes; Fecha: 23/03/2015
    // Ultima modificación: Willy Tenorio;  Fecha:10/11/2015
    //                      Willy Tenorio;  Fecha:09/04/2018
    //                      Willy Tenorio;  Fecha:20/04/2018
    //                      Claudia Loayza;  Fecha:16/05/2018
    // Descripción: Clase referente a la tabla PERSONAS
    public class BD_Personas
    {
        #region Variables Locales
        GEN_OracleBD OracleBD = new GEN_OracleBD();
        SIS_GeneralesSistema GeneralesSistema = new SIS_GeneralesSistema();
        private string strSql = string.Empty;
        #endregion

        #region "Clase de tablas de la Base de Datos"

        BD_Asignaciones Asignaciones = new BD_Asignaciones();
        BD_Paralelos Paralelos = new BD_Paralelos();
        BD_Alumnos_Paralelos AlumnosParalelos = new BD_Alumnos_Paralelos();
        BD_Titulos Titulos = new BD_Titulos();
        BD_Familiares Familiares = new BD_Familiares();

        #endregion

        #region Atributos
        // Campos de la tabla PERSONAS
        private long _num_sec = 0;
        private short _tipo = 0;
        private long _doc_identidad = 0;
        private short _tipo_doc = 0;
        private string _ap_paterno = string.Empty;
        private string _ap_materno = string.Empty;
        private string _nombres = string.Empty;
        private short _sexo = 0;
        private short _estado_civil = 0;
        private short _tipo_sangre = 0;
        private long _num_sec_localidad_nac = 0;
        private string _fecha_nacimiento = string.Empty;
        private long _num_sec_nacionalidad = 0;
        private long _lugar_expedicion_ci = 0;
        private string _apellido_casada = string.Empty;
        private string _cedula_identidad = string.Empty;
        private string _edad = string.Empty;

        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;


        public long NumSec { get { return _num_sec; } set { _num_sec = value; } }
        public short Tipo { get { return _tipo; } set { _tipo = value; } }
        public long DocIdentidad { get { return _doc_identidad; } set { _doc_identidad = value; } }
        public short TipoDoc { get { return _tipo_doc; } set { _tipo_doc = value; } }
        public string ApPaterno { get { return _ap_paterno; } set { _ap_paterno = value; } }
        public string ApMaterno { get { return _ap_materno; } set { _ap_materno = value; } }
        public string Nombres { get { return _nombres; } set { _nombres = value; } }
        public short Sexo { get { return _sexo; } set { _sexo = value; } }
        public short EstadoCivil { get { return _estado_civil; } set { _estado_civil = value; } }
        public short TipoSangre { get { return _tipo_sangre; } set { _tipo_sangre = value; } }
        public long NumSecLocalidadNac { get { return _num_sec_localidad_nac; } set { _num_sec_localidad_nac = value; } }
        public string FechaNacimiento { get { return _fecha_nacimiento; } set { _fecha_nacimiento = value; } }
        public long NumSecNacionalidad { get { return _num_sec_nacionalidad; } set { _num_sec_nacionalidad = value; } }
        public long LugarExpedicionCi { get { return _lugar_expedicion_ci; } set { _lugar_expedicion_ci = value; } }
        public string ApellidoCasada { get { return _apellido_casada; } set { _apellido_casada = value; } }
        public string CedulaIdentidad { get { return _cedula_identidad; } set { _cedula_identidad = value; } }
        public string Edad { get { return _edad; } set { _edad = value; } }

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

        #region Constructores
        public BD_Personas()
        {
            _num_sec = 0;
            _tipo = 0;
            _doc_identidad = 0;
            _tipo_doc = 0;
            _ap_paterno = string.Empty;
            _ap_materno = string.Empty;
            _nombres = string.Empty;
            _sexo = 0;
            _estado_civil = 0;
            _tipo_sangre = 0;
            _num_sec_localidad_nac = 0;
            _fecha_nacimiento = string.Empty;
            _num_sec_nacionalidad = 0;
            _lugar_expedicion_ci = 0;
            _apellido_casada = string.Empty;
            _cedula_identidad = string.Empty;

            // Otras propiedades
            _mensaje = string.Empty;
            _strconexion = string.Empty;
        }
        #endregion

        #region Metodos

        public bool Ver()
        {
            bool Encontrado = false;
            if (!string.IsNullOrEmpty(_num_sec.ToString()))
            {
                DataTable dt = new DataTable();
                strSql = "select cedula_identidad, apellido_casada, lugar_expedicion_ci, parametro2, parametro1, num_sec_nacionalidad,  " +
                        "to_char(fecha_nacimiento, 'dd/mm/yyyy') fecha_nacimiento, num_sec_localidad_nacimiento, nvl(tipo_sangre,0) tipo_sangre, nvl(estado_civil,0) estado_civil, sexo, nombres,  " +
                        "ap_materno, ap_paterno, tipo_doc, tipo, num_sec,  " +
                        "trunc(MONTHS_BETWEEN(sysdate, fecha_nacimiento)/12) edad " +
                        "from personas  " +
                        "where num_sec = " + _num_sec;
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
                    _cedula_identidad = dr["cedula_identidad"].ToString();
                    _ap_paterno = dr["ap_paterno"].ToString();
                    _ap_materno = dr["ap_materno"].ToString();
                    _nombres = dr["nombres"].ToString();
                    _fecha_nacimiento = dr["fecha_nacimiento"].ToString();
                    if (dr["sexo"].ToString().Trim() == "")
                        _sexo = 0;
                    else
                        _sexo = Convert.ToInt16(dr["sexo"].ToString());
                    if (dr["tipo"].ToString().Trim() == "")
                        _tipo = 0;
                    else
                        _tipo = Convert.ToInt16(dr["tipo"].ToString());
                    if (dr["tipo_doc"].ToString().Trim() == "")
                        _tipo_doc = 0;
                    else
                        _tipo_doc = Convert.ToInt16(dr["tipo_doc"].ToString());
                    if (dr["estado_civil"].ToString().Trim() == "")
                        _estado_civil = 0;
                    else
                        _estado_civil = Convert.ToInt16(dr["estado_civil"].ToString());
                    if (dr["tipo_sangre"].ToString().Trim() == "")
                        _tipo_sangre = 0;
                    else
                        _tipo_sangre = Convert.ToInt16(dr["tipo_sangre"].ToString());
                    if (dr["num_sec_nacionalidad"].ToString().Trim() == "")
                        _num_sec_nacionalidad = 0;
                    else
                        _num_sec_nacionalidad = Convert.ToInt64(dr["num_sec_nacionalidad"].ToString());
                    if (dr["num_sec_localidad_nacimiento"].ToString().Trim() == "")
                        _num_sec_localidad_nac = 0;
                    else
                        _num_sec_localidad_nac = Convert.ToInt64(dr["num_sec_localidad_nacimiento"].ToString());
                    _apellido_casada = dr["apellido_casada"].ToString();
                    if (dr["lugar_expedicion_ci"].ToString().Trim() == "")
                        _lugar_expedicion_ci = 0;
                    else
                        _lugar_expedicion_ci = Convert.ToInt16(dr["lugar_expedicion_ci"].ToString());

                    if (dr["edad"].ToString().Trim() == "")
                        _edad = "0";
                    else
                        _edad = dr["edad"].ToString();
                }
                dt.Dispose();
            }
            if (!Encontrado)
            {
                _num_sec = 0;
                _cedula_identidad = string.Empty;
                _ap_paterno = string.Empty;
                _ap_materno = string.Empty;
                _nombres = string.Empty;
                _fecha_nacimiento = string.Empty;
                _sexo = 0;
                _tipo = 0;
                _tipo_doc = 0;
                _estado_civil = 0;
                _tipo_sangre = 0;
                _num_sec_nacionalidad = 0;
                _num_sec_localidad_nac = 0;
                _apellido_casada = string.Empty;
                _lugar_expedicion_ci = 0;

            }
            return Encontrado;
        }

        // Método para insertar un dato en la tabla PERSONAS
        public bool Insertar()
        {
            bool blOperacionCorrecta = false;
            strSql = "insert into personas " +
                    "(num_sec, tipo, doc_identidad, cedula_identidad, tipo_doc, " +
                    "ap_paterno, ap_materno, nombres, apellido_casada, sexo, estado_civil, " +
                    "tipo_sangre, num_sec_localidad_nacimiento, fecha_nacimiento, " +
                    "num_sec_nacionalidad, lugar_expedicion_ci) " +
                    "values " +
                    "(" + _num_sec.ToString().Trim() + ", " + _tipo.ToString() + ", " + _doc_identidad.ToString() + ", '" + _cedula_identidad + "', " + _tipo_doc + ", " +
                    "'" + _ap_paterno.ToUpper().Trim() + "', '" + _ap_materno.ToUpper().Trim() + "', '" + _nombres.ToUpper().Trim() + "', " +
                    "'" + _apellido_casada.ToUpper().Trim() + "', " + _sexo.ToString() + ", " + _estado_civil.ToString() + ", " +
                    _tipo_sangre.ToString() + ", " + _num_sec_localidad_nac.ToString() + ", to_date('" + _fecha_nacimiento.ToString() + "','dd/mm/yyyy'), " +
                    _num_sec_nacionalidad.ToString() + ", " + _lugar_expedicion_ci.ToString() + ")";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();

            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible insertar el dato. Se encontró un error al insertar en la tabla PERSONAS. " + _mensaje;
            return blOperacionCorrecta;
        }

        // Método para MODIFICAR un dato en la tabla PERSONAS
        public bool Modificar()
        {
            bool blOperacionCorrecta = false;
            strSql = "update personas " +
                    "set tipo = " + _tipo.ToString() + ", " +
                    "cedula_identidad = '" + _cedula_identidad + "', " +
                    "doc_identidad = " + _doc_identidad.ToString() + ", " +
                    "tipo_doc = " + _tipo_doc.ToString() + ", " +
                    "ap_paterno = '" + _ap_paterno.ToUpper().Trim() + "', " +
                    "ap_materno = '" + _ap_materno.ToUpper().Trim() + "', " +
                    "nombres = '" + _nombres.ToUpper().Trim() + "', " +
                    "sexo = " + _sexo.ToString() + ", " +
                    "estado_civil = " + _estado_civil.ToString() + ", " +
                    "tipo_sangre = " + _tipo_sangre.ToString() + ", " +
                    "num_sec_localidad_nacimiento = " + _num_sec_localidad_nac.ToString() + ", " +
                    "fecha_nacimiento = to_date('" + _fecha_nacimiento.ToUpper().Trim() + "','dd/mm/yyyy'), " +
                    "num_sec_nacionalidad = " + _num_sec_nacionalidad.ToString() + ", " +
                    "lugar_expedicion_ci = " + _lugar_expedicion_ci.ToString() + ", " +
                    "apellido_casada = '" + _apellido_casada.ToUpper().Trim() + "' " +
                    "where num_sec = " + _num_sec.ToString();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();

            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible actualizar el dato. Se encontró un error al actualizar en la tabla PERSONAS. " + _mensaje;
            return blOperacionCorrecta;
        }

        // Método para ELIMINAR un dato en la tabla PERSONAS
        public bool Borrar()
        {
            string[] listaSqls = new string[0];
            int intNumSqls = 0;

            strSql = "delete personas_datos_adicionales " +
                     "where num_sec_persona = " + _num_sec.ToString().Trim();
            Array.Resize<string>(ref listaSqls, intNumSqls + 1);
            listaSqls[intNumSqls] = strSql;
            intNumSqls += 1;

            strSql = "delete personas_fotos " +
                     "where num_sec_persona = " + _num_sec.ToString().Trim();
            Array.Resize<string>(ref listaSqls, intNumSqls + 1);
            listaSqls[intNumSqls] = strSql;
            intNumSqls += 1;

            strSql = "delete personas " +
                     "where num_sec = " + _num_sec.ToString().Trim();
            Array.Resize<string>(ref listaSqls, intNumSqls + 1);
            listaSqls[intNumSqls] = strSql;
            intNumSqls += 1;

            OracleBD.StrConexion = _strconexion;
            OracleBD.ListaSqls = listaSqls;
            OracleBD.NumSqls = intNumSqls;
            OracleBD.EjecutarSqlsTrans();
            if (OracleBD.Error)
            {
                _mensaje = OracleBD.Mensaje;
                return false;
            }
            else
            {
                return true;
            }

        }

        #endregion

        #region Procedimientos y Funciones Públicos

        /// <summary>
        /// Buscador de persona
        /// </summary>
        /// <param name="strCriterioBusqueda">Criterio de búsqueda</param>
        /// <param name="intTipoBusqueda">intTipoBusqueda=0:buscar automaticamente; intTipoBusqueda=1:buscar por Cedula de identidad; =2:buscar por primer apellido</param>
        /// <returns></returns>
        public DataTable ListadoBuscador(string strCriterioBusqueda, int intTipoBusqueda)
        {
            // intTipoBusqueda=1:buscar por num_sec; =2:buscar por cedula id y nombre
            string strSql = string.Empty;
            strSql = "select per.num_sec, per.cedula_identidad, per.ap_paterno, per.ap_materno, per.nombres, per.tipo, per.ap_paterno||' '||per.ap_materno||' '||per.nombres persona " +
                    "from personas per ";
            if (!string.IsNullOrEmpty(strCriterioBusqueda))
            {
                switch (intTipoBusqueda)
                {
                    case 0: // Automatico
                        strSql += "where cedula_identidad like '%" + strCriterioBusqueda.Trim() + "%' " +
                                 "or ap_paterno||' '||ap_materno||' '||nombres like '%" + strCriterioBusqueda.ToUpper().Trim().Replace(" ", "%") + "%' " +
                                 "order by ap_paterno, ap_materno, nombres";
                        break;
                    case 1: // Cedula Identidad
                        strSql += "where cedula_identidad like '%" + strCriterioBusqueda.ToUpper().Trim() + "%' order by cedula_identidad";
                        break;
                    case 2: // Primer Apellido
                        strSql += "where ap_paterno like '%" + strCriterioBusqueda.ToUpper().Trim().Replace(" ", "%") + "%' order by ap_paterno, ap_materno, nombres";
                        break;
                    case 3: // Segundo Apellido
                        strSql += "where ap_materno like '%" + strCriterioBusqueda.ToUpper().Trim().Replace(" ", "%") + "%' order by ap_materno, ap_paterno, nombres";
                        break;
                    case 4: // Nombres
                        strSql += "where nombres like '%" + strCriterioBusqueda.ToUpper().Trim().Replace(" ", "%") + "%' order by nombres, ap_paterno, ap_materno";
                        break;
                    default:
                        strSql += "where 1=0";
                        break;
                }
            }
            else
                strSql += "where 1=0";
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }

        public bool VerPorCedulaIdentidad()
        {
            bool Encontrado = false;
            if (!string.IsNullOrEmpty(_cedula_identidad.ToString()))
            {
                DataTable dt = new DataTable();
                strSql = "select cedula_identidad, apellido_casada, lugar_expedicion_ci, parametro2, parametro1, num_sec_nacionalidad,  " +
                        "to_char(fecha_nacimiento, 'dd/mm/yyyy') fecha_nacimiento, num_sec_localidad_nacimiento, nvl(tipo_sangre,0) tipo_sangre, nvl(estado_civil,0) estado_civil, sexo, nombres,  " +
                        "ap_materno, ap_paterno, tipo_doc, tipo, num_sec  " +
                        "from personas  " +
                        "where cedula_identidad = '" + _cedula_identidad + "'";
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
                    _cedula_identidad = dr["cedula_identidad"].ToString();
                    _ap_paterno = dr["ap_paterno"].ToString();
                    _ap_materno = dr["ap_materno"].ToString();
                    _nombres = dr["nombres"].ToString();
                    _fecha_nacimiento = dr["fecha_nacimiento"].ToString();
                    if (dr["sexo"].ToString().Trim() == "")
                        _sexo = 0;
                    else
                        _sexo = Convert.ToInt16(dr["sexo"].ToString());
                    if (dr["tipo"].ToString().Trim() == "")
                        _tipo = 0;
                    else
                        _tipo = Convert.ToInt16(dr["tipo"].ToString());
                    if (dr["estado_civil"].ToString().Trim() == "")
                        _estado_civil = 0;
                    else
                        _estado_civil = Convert.ToInt16(dr["estado_civil"].ToString());
                    if (dr["tipo_sangre"].ToString().Trim() == "")
                        _tipo_sangre = 0;
                    else
                        _tipo_sangre = Convert.ToInt16(dr["tipo_sangre"].ToString());
                    if (dr["num_sec_nacionalidad"].ToString().Trim() == "")
                        _num_sec_nacionalidad = 0;
                    else
                        _num_sec_nacionalidad = Convert.ToInt64(dr["num_sec_nacionalidad"].ToString());
                    if (dr["num_sec_localidad_nacimiento"].ToString().Trim() == "")
                        _num_sec_localidad_nac = 0;
                    else
                        _num_sec_localidad_nac = Convert.ToInt64(dr["num_sec_localidad_nacimiento"].ToString());
                    _apellido_casada = dr["apellido_casada"].ToString();
                    if (dr["lugar_expedicion_ci"].ToString().Trim() == "")
                        _lugar_expedicion_ci = 0;
                    else
                        _lugar_expedicion_ci = Convert.ToInt16(dr["lugar_expedicion_ci"].ToString());
                }
                dt.Dispose();
            }
            if (!Encontrado)
            {
                _num_sec = 0;
                _cedula_identidad = string.Empty;
                _ap_paterno = string.Empty;
                _ap_materno = string.Empty;
                _nombres = string.Empty;
                _sexo = 0;
                _tipo = 0;
                _estado_civil = 0;
                _tipo_sangre = 0;
                _num_sec_nacionalidad = 0;
                _num_sec_localidad_nac = 0;
                _apellido_casada = string.Empty;
                _lugar_expedicion_ci = 0;
            }
            return Encontrado;
        }

        public string Query_Grid_Buscador1(string strCriterioBusqueda, int intTipoBusqueda)
        {
            // intTipoBusqueda=1: buscar por num_sec; =2: buscar por cedula id y nombre
            string strSql = string.Empty;
            strSql = "select b.num_sec, b.cedula_identidad, b.ap_paterno, b.ap_materno, b.nombres, b.tipo";
            strSql += " , b.ap_paterno||' '||b.ap_materno||' '||b.nombres persona";
            strSql += " , 'Seleccionar' accion, 1 codigo_accion";
            strSql += " from personas b";
            if (!string.IsNullOrEmpty(strCriterioBusqueda))
            {
                switch (intTipoBusqueda)
                {
                    case 1:
                        strSql += " where b.num_sec = " + strCriterioBusqueda;
                        break;
                    case 2:
                        strSql += " where (b.cedula_identidad like '" + strCriterioBusqueda + "'";
                        strSql += " or b.ap_paterno||' '||b.ap_materno||' '||b.nombres like '" + strCriterioBusqueda + "')";
                        break;
                    default:
                        strSql += " where 1=0";
                        break;
                }
            }
            else
                strSql += " where 1=0";
            strSql += " order by persona";
            return strSql;
        }

        public string Query_Grid_Sugeridos_Similares1(string strCI, string strPrimerAp, string strSegundoAp, string strNombres)
        {
            string strSql = string.Empty;

            if (!string.IsNullOrEmpty(strCI.Trim()) && !string.IsNullOrEmpty(strPrimerAp.Trim()) && !string.IsNullOrEmpty(strSegundoAp.Trim()) && !string.IsNullOrEmpty(strNombres.Trim()))
            {
                string strPrimerApCortado, strSegundoApCortado, strNombresCortado = string.Empty;

                if (strPrimerAp.Trim().Length >= 3)
                    strPrimerApCortado = strPrimerAp.Trim().Substring(0, 3);
                else
                    strPrimerApCortado = strPrimerAp.Trim();

                if (strSegundoAp.Trim().Length >= 3)
                    strSegundoApCortado = strSegundoAp.Trim().Substring(0, 3);
                else
                    strSegundoApCortado = strSegundoAp.Trim();

                if (strNombres.Trim().Length >= 3)
                    strNombresCortado = strNombres.Trim().Substring(0, 3);
                else
                    strNombresCortado = strNombres.Trim();

                strSql = "select a.num_sec, a.cedula_identidad";
                strSql += " , a.ap_paterno, a.ap_materno, a.nombres, a.tipo";
                strSql += " , a.ap_paterno||' '||a.ap_materno||' '||a.nombres persona";
                strSql += " , 'Seleccionar' accion, 1 codigo_accion";
                strSql += " from personas a";
                strSql += " where a.ap_paterno||' '||a.ap_materno||' '||a.nombres like ";
                strSql += " '" + strPrimerApCortado + "%'||'" + strSegundoApCortado + "%'||'" + strNombresCortado + "%'";
                //strSql += "   (select SUBSTR(a.ap_paterno,0,3)||'%'||SUBSTR(a.ap_materno,0,3)||'%'||SUBSTR(a.nombres,0,3)||'%' patron";
                //strSql += "   from personas a";
                //strSql += "   where a.num_sec = " + strNSPersona;
                //strSql += "   )";

                strSql += " or a.ap_paterno||' '||a.ap_materno like '" + strPrimerAp.Trim() + "%'||'" + strNombres.Trim() + "%'";

                //strSql += "   (select a.ap_paterno||'%'||a.ap_materno||'%' patron";
                //strSql += "   from personas a";
                //strSql += "   where a.num_sec = " + strNSPersona;
                //strSql += "   )";

                strSql += " or a.cedula_identidad like '" + strCI.Trim() + "%'";
                //strSql += "   (select a.cedula_identidad||'%' patron";
                //strSql += "   from personas a";
                //strSql += "   where a.num_sec = " + strNSPersona;
                //strSql += "   )";

                strSql += " order by persona, cedula_identidad";
            }
            else
                strSql = "select sysdate from dual where 1=0";

            return strSql;
        }

        public bool Validar_Datos_Persona_Nueva(string strCedulaIdentidad, int intTipoDoc, string strPrimerAp, string strSegundoAp, string strNombres, ref string strMensaje0)
        {
            bool blDatosCorrectos = true;
            string strMensaje1 = string.Empty;

            if (string.IsNullOrEmpty(strCedulaIdentidad.Trim()))
            {
                blDatosCorrectos = false;
                strMensaje1 = "Debe ingresar el Documento de Identidad. ";
            }
            if (intTipoDoc <= 0)
            {
                blDatosCorrectos = false;
                strMensaje1 += "Debe ingresar el tipo de documento de identidad. ";
            }
            if (string.IsNullOrEmpty(strPrimerAp.Trim()))
            {
                blDatosCorrectos = false;
                strMensaje1 += "Debe ingresar el Primer Apellido. ";
            }
            if (string.IsNullOrEmpty(strSegundoAp.Trim()))
            {
                //blDatosCorrectos = false;
                //strMensaje1 += "Debe ingresar el Segundo Apellido. ";
            }
            if (string.IsNullOrEmpty(strNombres.Trim()))
            {
                blDatosCorrectos = false;
                strMensaje1 += "Debe ingresar los Nombres. ";
            }

            strMensaje0 = strMensaje1;
            return blDatosCorrectos;
        }

        public bool Revisar_Existe_Persona(string strCedulaIdentidad, string strPrimerAp, string strSegundoAp, string strNombres, string strNSPersona)
        {
            strSql = " select num_sec, cedula_identidad, ap_paterno||' '||ap_materno||' '||nombres persona";
            strSql += " from personas ";
            strSql += " where (cedula_identidad = '" + strCedulaIdentidad.Trim().ToUpper() + "'";
            strSql += " or (ap_paterno = '" + strPrimerAp.Trim().ToUpper() + "'";
            if (string.IsNullOrEmpty(strSegundoAp.Trim()))
                strSql += " and ap_materno is null";
            else
                strSql += " and ap_materno = '" + strSegundoAp.Trim().ToUpper() + "'";
            strSql += " and nombres = '" + strNombres.Trim().ToUpper() + "'))";

            if (string.IsNullOrEmpty(strNSPersona.Trim()))
                strSql += " and num_sec > 0";
            else
                strSql += " and num_sec <> " + strNSPersona.Trim();

            DataTable dt = new DataTable();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            if (dt.Rows.Count > 0)
            {
                DataRow rw = dt.Rows[0];
                _mensaje = "La persona ingresada ya se encuentra registrada en el sistema. ";
                _mensaje += "[" + rw["cedula_identidad"].ToString() + "]";
                _mensaje += " " + rw["persona"].ToString();
                _num_sec = Convert.ToInt64(rw["num_sec"]);
                dt.Dispose();
                return true;
            }
            else
            {
                dt.Dispose();
                return false;
            }
        }

        public int RevisarTipoEstudiante()
        {
            string strNSSemestre = string.Empty;
            int intTipoAlumno = 0;

            strSql = "select num_sec " +
                     "from semestres " +
                     "where trunc(sysdate) >= trunc(fecha_inicio) " +
                     "and trunc(sysdate) <= trunc(fecha_fin)";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            if (OracleBD.DataTable.Rows.Count == 0)
                strNSSemestre = "0";
            else
                strNSSemestre = OracleBD.DataTable.Rows[0][0].ToString().Trim();
            AlumnosParalelos.StrConexion = _strconexion;
            AlumnosParalelos.NumSecPersona = _num_sec;
            if (AlumnosParalelos.RevisaNumMateriasInscritoSem(_num_sec.ToString().Trim(), strNSSemestre) > 0)
            {
                // Está inscrito en al menos una materia del semestre vigente
                intTipoAlumno = 1;
            }
            else
            {
                // Verificar Si el estudiante está titulado
                Titulos.StrConexion = _strconexion;
                Titulos.NumSecPersona = _num_sec;
                if (Titulos.RevisarAlumnoTitulado())
                    intTipoAlumno = 2;

                // Verificar si es exalumno
                if (AlumnosParalelos.RevisarEstudiantePostgrado())
                    intTipoAlumno = 3;
                else
                    intTipoAlumno = 4;
            }
            return intTipoAlumno;
        }

        public void DefinirGrupoPersona(string strFecha, ref int intGrupoPersona, ref string strDescripcionPersona)
        {
            long lgNSASignacion = 0;
            int intTipoAsignacion = 0;
            int intCargaHoraria = 0;
            string strDescripcionAsignacion = string.Empty;

            intGrupoPersona = 0;
            strDescripcionPersona = "";

            // Revisar Asignacion del Sistema de Personal
            Asignaciones.StrConexion = _strconexion;
            Asignaciones.NumSecPersona = _num_sec;
            Asignaciones.RevisarAsignacionRRHH(strFecha, ref lgNSASignacion, ref intTipoAsignacion, ref intCargaHoraria, ref strDescripcionAsignacion);
            switch (intTipoAsignacion)
            {
                case 0: // No tiene una asignacion vigente
                    break;
                case 1: // Autoridad
                    intGrupoPersona = 1;
                    strDescripcionPersona = "Autoridad (" + strDescripcionAsignacion + ")";
                    break;
                case 2: // Administrativo
                    intGrupoPersona = 2;
                    strDescripcionPersona = "Administrativo (" + strDescripcionAsignacion + ")";

                    // Revisa si tambien docente dicta una o mas materias en el semestre actual
                    Paralelos.StrConexion = _strconexion;
                    Paralelos.NumSecDocente = _num_sec;
                    if (Paralelos.VerificarDocenteDictaMateriasSemestreVigente())
                    {
                        strDescripcionPersona += "<br />Docente Tiempo Horario (en semestre vigente)";
                    }
                    break;
                case 3: // Docente
                    switch (intCargaHoraria)
                    {
                        case 1: // Docente Tiempo Completo
                            intGrupoPersona = 3;
                            strDescripcionPersona = "Docente Tiempo Completo (" + strDescripcionAsignacion + ")";
                            break;
                        case 2: // Docente Medio Tiempo 
                            intGrupoPersona = 3;
                            strDescripcionPersona = "Docente Medio Completo (" + strDescripcionAsignacion + ")";
                            break;
                        default: // Docente Tiempo Horario
                            intGrupoPersona = 3;
                            strDescripcionPersona = "Docente Tiempo Horario";
                            break;
                    }
                    // Revisa si el docente dicta una o mas materias en el semestre actual
                    Paralelos.StrConexion = _strconexion;
                    Paralelos.NumSecDocente = _num_sec;
                    if (Paralelos.VerificarDocenteDictaMateriasSemestreVigente())
                    {
                        strDescripcionPersona += " (en semestre vigente)";
                    }
                    break;
                default: // Otros
                    break;
            }

            // Revisa tipo de alumno
            switch (RevisarTipoEstudiante())
            {
                case 1: // Estudiante Regular
                    strDescripcionPersona += "<br />Estudiante regular";
                    break;
                case 2: // Estudiante Titulado
                    strDescripcionPersona += "<br />Estudiante titulado";
                    break;
                case 3: // Exalumno
                    strDescripcionPersona += "<br />Estudiante antiguo";
                    break;
                default: // Externo
                    strDescripcionPersona += "<br />Externo";
                    break;

            }

            // Revisa si es familiar
            Familiares.StrConexion = _strconexion;
            Familiares.NumSecFamiliar = _num_sec;
            if (Familiares.RevisarSiEsFamiliar())
                strDescripcionPersona += "<br />Familiar";
        }

        public bool GenerarNS()
        {
            bool Encontrado = false;
            if (!string.IsNullOrEmpty(_num_sec.ToString()))
            {
                DataTable dt = new DataTable();
                strSql = "select personas_sec.nextval as num_sec from dual";
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
                }
                dt.Dispose();
            }

            return Encontrado;
        }
        public string sqlCadInsertar()
        {
            strSql = "insert into personas " +
                    "(num_sec, tipo, doc_identidad, cedula_identidad, tipo_doc, " +
                    "ap_paterno, ap_materno, nombres, apellido_casada, sexo, estado_civil, " +
                    "tipo_sangre, num_sec_localidad_nacimiento, fecha_nacimiento, " +
                    "num_sec_nacionalidad, lugar_expedicion_ci) " +
                    "values " +
                    "(" + _num_sec.ToString().Trim() + ", " + GeneralesSistema.IIf(_tipo.ToString().Trim() == "", "NULL", _tipo.ToString()) + ", " + GeneralesSistema.IIf(_doc_identidad.ToString().Trim() == "", "0", _doc_identidad) +
                    ", " + GeneralesSistema.IIf(_cedula_identidad.ToString().Trim() == "", "NULL", "'" + _cedula_identidad.ToUpper() + "'") + ", " + GeneralesSistema.IIf(_tipo_doc.ToString().Trim() == "", "NULL",  _tipo_doc )  + ", " +
                    "'" + _ap_paterno.ToUpper().Trim() + "', '" + _ap_materno.ToUpper().Trim() + "', '" + _nombres.ToUpper().Trim() + "', " +
                    "'" + _apellido_casada.ToUpper().Trim() + "', " + GeneralesSistema.IIf(_sexo.ToString().Trim() == "0", "NULL", _sexo.ToString()) + ", " + GeneralesSistema.IIf(_estado_civil.ToString().Trim() == "0", "NULL", _estado_civil) + ", " +
                    GeneralesSistema.IIf(_tipo_sangre.ToString().Trim() == "0", "NULL", _tipo_sangre) + ", " + GeneralesSistema.IIf(_num_sec_localidad_nac.ToString().Trim() == "0", "NULL", _num_sec_localidad_nac) + ", "+ GeneralesSistema.IIf(_fecha_nacimiento.ToString().Trim() == "", "NULL", "to_date('" + _fecha_nacimiento.ToUpper().Trim() + "','dd/mm/yyyy')")+", " +
                    GeneralesSistema.IIf(_num_sec_nacionalidad.ToString().Trim() == "0", "NULL", _num_sec_nacionalidad) + ", " + GeneralesSistema.IIf(_lugar_expedicion_ci.ToString().Trim() == "0", "NULL", _lugar_expedicion_ci) + ")";
            return strSql;
        }
        public string sqlCadActualizar()
        {
            strSql = "update personas " +
                    "set tipo = " + GeneralesSistema.IIf(_tipo.ToString().Trim() == "", "NULL",  _tipo ) + ", " +
                    "cedula_identidad = " + GeneralesSistema.IIf(_cedula_identidad.ToString().Trim() == "", "NULL", "'" + _cedula_identidad + "'") + ", " +
                    "doc_identidad = " + GeneralesSistema.IIf(_doc_identidad.ToString().Trim() == "", "NULL", _doc_identidad ) + ", " +
                    "tipo_doc = " + GeneralesSistema.IIf(_tipo_doc.ToString().Trim() == "", "NULL", _tipo_doc) + ", " +
                    "ap_paterno = " + GeneralesSistema.IIf(_ap_paterno.ToString().Trim() == "", "NULL", "'" + _ap_paterno.ToUpper() + "'") + ", " +
                    "ap_materno = " + GeneralesSistema.IIf(_ap_materno.ToString().Trim() == "", "NULL", "'" + _ap_materno.ToUpper() + "'") + ", " +
                    "nombres = " + GeneralesSistema.IIf(_nombres.ToString().Trim() == "", "NULL", "'" + _nombres.ToUpper() + "'") + ", " +
                    "sexo = " + GeneralesSistema.IIf(_sexo.ToString().Trim() == "", "NULL", _sexo ) + ", " +
                    "estado_civil = " + GeneralesSistema.IIf(_estado_civil.ToString().Trim() == "", "NULL", _estado_civil) + ", " +
                    "tipo_sangre = " + GeneralesSistema.IIf(_tipo_sangre.ToString().Trim() == "", "NULL", _tipo_sangre) + ", " +
                    "num_sec_localidad_nacimiento = " + GeneralesSistema.IIf(_num_sec_localidad_nac.ToString().Trim() == "0", "NULL", _num_sec_localidad_nac) + ", " +
                    "fecha_nacimiento = " + GeneralesSistema.IIf(_fecha_nacimiento.ToString().Trim() == "", "NULL", "to_date('" + _fecha_nacimiento.ToUpper().Trim() + "','dd/mm/yyyy')");
            if ((_num_sec_nacionalidad != 0) && (!string.IsNullOrEmpty(_num_sec_nacionalidad.ToString().Trim()))){
                strSql += ", num_sec_nacionalidad = " + _num_sec_nacionalidad.ToString() ;
            }
            strSql="where num_sec = " + _num_sec.ToString();
            return strSql;
        }

        public string sqlCadActualizarSiFamiliar()
        {
            strSql = "update personas " +
                    "set tipo = " + GeneralesSistema.IIf(_tipo.ToString().Trim() == "", "NULL", "'" + _tipo + "'") + ", " +
                    "cedula_identidad = " + GeneralesSistema.IIf(_cedula_identidad.ToString().Trim() == "", "NULL", "'" + _cedula_identidad + "'") + ", " +
                    "doc_identidad = " + GeneralesSistema.IIf(_doc_identidad.ToString().Trim() == "", "NULL", "'" + _doc_identidad + "'")  + ", " +
                    "tipo_doc = " + GeneralesSistema.IIf(_tipo_doc.ToString().Trim() == "", "NULL", "'" + _tipo_doc + "'")     .ToString() + ", " +
                    "ap_paterno = '" + GeneralesSistema.IIf(_ap_paterno.ToString().Trim() == "", "NULL", "'" + _ap_paterno + "'")  + "', " +
                    "ap_materno = '" + GeneralesSistema.IIf(_ap_materno.ToString().Trim() == "", "NULL", "'" + _ap_materno + "'") + "', " +
                    "nombres = '" + GeneralesSistema.IIf(_nombres.ToString().Trim() == "", "NULL", "'" + _nombres + "'") + "', " +
                    "sexo = " + GeneralesSistema.IIf(_sexo.ToString().Trim() == "", "NULL", "'" + _sexo + "'")  + ", " +
                    "estado_civil = " + GeneralesSistema.IIf(_estado_civil.ToString().Trim() == "", "NULL", "'" + _estado_civil + "'")  + ", " +
                    "where num_sec = " + _num_sec.ToString();
            return strSql;
        }

        public bool VerificarRolPersona()
        {
            bool blTieneRol = false;

            return blTieneRol;
        }

        public DataTable dtObtenerCoincidencias(string strCedulaIdentidad, string strPrimerAp, string strSegundoAp, string strNombres, string strNSPersona)
        {
            strSql = " select num_sec, cedula_identidad, ap_paterno, ap_materno,nombres";
            strSql += " from personas ";
            strSql += " where (cedula_identidad = '" + strCedulaIdentidad.Trim().ToUpper() + "'";
            strSql += " or (ap_paterno = '" + strPrimerAp.Trim().ToUpper() + "'";
            if (string.IsNullOrEmpty(strSegundoAp.Trim()))
                strSql += " and ap_materno is null";
            else
                strSql += " and ap_materno = '" + strSegundoAp.Trim().ToUpper() + "'";
            strSql += " and nombres = '" + strNombres.Trim().ToUpper() + "'))";

            if (string.IsNullOrEmpty(strNSPersona.Trim()))
                strSql += " and num_sec > 0";
            else
                strSql += " and num_sec <> " + strNSPersona.Trim();

            DataTable dt = new DataTable();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            return dt;
        }
        #endregion

    }
}