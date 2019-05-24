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
using System.Web.UI.WebControls;

namespace nsBD_ACAD
{
    // Creado por: Willy Tenorio Palza; Fecha: 10/11/2015
    // Ultima modificación: 27/02/2017 (Willy Tenorio Palza)
    //                      Milco Cortes:  12/03/2018
    //                      Willy Tenorio: 19/04/2018
    //                      Willy Tenorio: 24/04/2018
    //                      Willy Tenorio: 30/08/2018
    //                      Willy Tenorio: 22/03/2019
    // Descripción: Clase referente a la tabla PARALELOS

    public class BD_Paralelos
    {
        #region Variables Locales

        GEN_OracleBD OracleBD = new GEN_OracleBD();
        GEN_Mensajes libMensajes = new GEN_Mensajes();
        GEN_Cadenas libCadenas = new GEN_Cadenas();
        SIS_GeneralesSistema Gen = new SIS_GeneralesSistema();
        private string strSql = string.Empty;

        #endregion

        #region Atributos

        // Campos de la tabla PARALELOS
        private long _num_sec = 0;
        private long _num_sec_carrera = 0;
        private long _num_sec_semestre = 0;
        private long _num_sec_materia = 0;
        private int _numero_paralelo = 0;
        private int _num_creditos = 0;
        private int _num_creditos_eco = 0;
        private long _num_sec_docente = 0;
        private long _num_sec_ayudante = 0;
        private int _cupo = 0;
        private int _num_alumnos_inscritos = 0;
        private int _operaciones_internet = 0;
        private int _cupo_aula = 0;
        private int _tipo = 0;
        private int _estado_reg_notas = 0;
        private int _pago_docente = 0;
        private long _num_sec_subdepartamento = 0;

        // Otras tablas

        private string _semestreresumido = string.Empty;
        private string _semestredescripcion = string.Empty;
        private string _materiasigla = string.Empty;
        private string _materianombre = string.Empty;
        private string _subdeptoresumido = string.Empty;
        private string _subdeptonombre = string.Empty;
        private string _fechacierresdt1 = string.Empty;
        private string _fechacierresdt2 = string.Empty;
        private int _diasvigenciasdt1 = 0;
        private int _diasvigenciasdt2 = 0;
        private int _tiposubdepto = 0;


        private bool _esusuariosisalumnos = false;
        private bool _pertencecienciasbasica = false;
        private bool _restringirnotassemestre = false;
        private bool _restringirnotassisdocentes = false;
        private int _numpersonasautextemp = 0;
        private long[] _nspersonasautextemp = new long[100000];


        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        // Definicion GET y SET de los campos de la tabla PARALELOS
        public long NumSec { get { return _num_sec; } set { _num_sec = value; } }
        public long NumSecCarrera { get { return _num_sec_carrera; } set { _num_sec_carrera = value; } }
        public long NumSecSemestre { get { return _num_sec_semestre; } set { _num_sec_semestre = value; } }
        public long NumSecMateria { get { return _num_sec_materia; } set { _num_sec_materia = value; } }
        public int NumeroParalelo { get { return _numero_paralelo; } set { _numero_paralelo = value; } }
        public int NumCreditos { get { return _num_creditos; } set { _num_creditos = value; } }
        public int NumCreditosEco { get { return _num_creditos_eco; } set { _num_creditos_eco = value; } }
        public long NumSecDocente { get { return _num_sec_docente; } set { _num_sec_docente = value; } }
        public long NumSecAyudante { get { return _num_sec_ayudante; } set { _num_sec_ayudante = value; } }
        public int Cupo { get { return _cupo; } set { _cupo = value; } }
        public int NumAlumnosInscritos { get { return _num_alumnos_inscritos; } set { _num_alumnos_inscritos = value; } }
        public int OperacionesInternet { get { return _operaciones_internet; } set { _operaciones_internet = value; } }
        public int CupoAula { get { return _cupo_aula; } set { _cupo_aula = value; } }
        public int Tipo { get { return _tipo; } set { _tipo = value; } }
        public int EstadoRegNotas { get { return _estado_reg_notas; } set { _estado_reg_notas = value; } }
        public int PagoDocente { get { return _pago_docente; } set { _pago_docente = value; } }
        public long NumSecSubdepartamento { get { return _num_sec_subdepartamento; } set { _num_sec_subdepartamento = value; } }


        // Otras tablas
        public string SemestreResumido { get { return _semestreresumido; } }
        public string SemestreDescripcion { get { return _semestredescripcion; } }
        public string MateriaSigla { get { return _materiasigla; } }
        public string MateriaNombre { get { return _materianombre; } }
        public string SubDeptoResumido { get { return _subdeptoresumido; } }
        public string SubDeptoNombre { get { return _subdeptonombre; } }

        public string FechaCierreSDT1 { get { return _fechacierresdt1; } }
        public string FechaCierreSDT2 { get { return _fechacierresdt2; } }
        public int DiasVigenciaSDT1 { get { return _diasvigenciasdt1; } }
        public int DiasVigenciaSDT2 { get { return _diasvigenciasdt2; } }
        public int TipoSubDepto { get { return _tiposubdepto; } }

        public bool EsUsuarioSISAlumnos { get { return _esusuariosisalumnos; } }
        public bool PertenceCienciasBasica { get { return _pertencecienciasbasica; } }
        public bool RestringirNotasSemestre { get { return _restringirnotassemestre; } }
        public bool RestringirNotasSisDocentes { get { return _restringirnotassisdocentes; } }
        public int NumPersonasAutExtemp { get { return _numpersonasautextemp; } }

        public long[] NSPersonasAutExtemp { get { return _nspersonasautextemp; } }


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

        // Definición del contructor de la clase PARALELOS
        public BD_Paralelos()
        {
            _num_sec = 0;
            _num_sec_carrera = 0;
            _num_sec_semestre = 0;
            _num_sec_materia = 0;
            _numero_paralelo = 0;
            _num_creditos = 0;
            _num_sec_docente = 0;
            _num_sec_ayudante = 0;
            _cupo = 0;
            _num_alumnos_inscritos = 0;
            _operaciones_internet = 0;
            _cupo_aula = 0;
            _tipo = 0;
            _estado_reg_notas = 0;
            _pago_docente = 0;
            _num_sec_subdepartamento = 0;

            _semestreresumido = string.Empty;
            _semestredescripcion = string.Empty;
            _materiasigla = string.Empty;
            _materianombre = string.Empty;
            _subdeptoresumido = string.Empty;
            _subdeptonombre = string.Empty;
            _fechacierresdt1 = string.Empty;
            _fechacierresdt2 = string.Empty;
            _diasvigenciasdt1 = 0;
            _diasvigenciasdt2 = 0;
            _tiposubdepto = 0;

            _esusuariosisalumnos = false;
            _pertencecienciasbasica = false;
            _restringirnotassemestre = false;
            _restringirnotassisdocentes = false;
            _numpersonasautextemp = 0;

            _mensaje = string.Empty;
            _strconexion = string.Empty;
        }

        #endregion

        #region Metodos iBD_Tablas

        // Método para insertar un dato en la tabla PARALELOS
        public bool Insertar()
        {
            bool blOperacionCorrecta = false;
            strSql = "insert into paralelos (  " +
                     "num_sec, " +
                     "num_sec_carrera, " +
                     "num_sec_semestre, " +
                     "num_sec_materia, " +
                     "numero_paralelo, " +
                     "num_creditos, " +
                     "num_creditos_eco, " +
                     "num_sec_docente, " +
                     "num_sec_ayudante, " +
                     "cupo, " +
                     "num_alumnos_inscritos, " +
                     "operaciones_internet, " +
                     "cupo_aula, " +
                     "tipo, " +
                     "estado_reg_notas, " +
                     "pago_docente, " +
                     "num_sec_subdepartamento " +
                     ") " +
                     "values " +
                     "( " +
                     _num_sec.ToString() + ", " +
                     _num_sec_carrera.ToString() + ", " +
                     _num_sec_semestre.ToString() + ", " +
                     _num_sec_materia.ToString() + ", " +
                     _numero_paralelo.ToString() + ", " +
                     _num_creditos.ToString() + ", " +
                     _num_creditos_eco.ToString() + ", " +
                     _num_sec_docente.ToString() + ", " +
                     _num_sec_ayudante.ToString() + ", " +
                     _cupo.ToString() + ", " +
                     _num_alumnos_inscritos.ToString() + ", " +
                     _operaciones_internet.ToString() + ", " +
                     Gen.IIf(_cupo_aula==0,"NULL",_cupo_aula.ToString()) + ", " +
                     _tipo.ToString() + ", " +
                     Gen.IIf(_estado_reg_notas==0,"NULL", _estado_reg_notas.ToString()) + ", " +
                     _pago_docente.ToString() + ", " +
                     _num_sec_subdepartamento.ToString() + " " +
                     ")";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();

            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible insertar el dato. Se encontró un error al insertar en la tabla PARALELOS. " + _mensaje;
            return blOperacionCorrecta;

        }

        // Método para generar el SQL insertar un dato en la tabla PARALELOS
        public string SQLInsertar()
        {
            strSql = "insert into paralelos (  " +
                     "num_sec, " +
                     "num_sec_carrera, " +
                     "num_sec_semestre, " +
                     "num_sec_materia, " +
                     "numero_paralelo, " +
                     "num_creditos, " +
                     "num_creditos_eco, " +
                     "num_sec_docente, " +
                     "num_sec_ayudante, " +
                     "cupo, " +
                     "num_alumnos_inscritos, " +
                     "operaciones_internet, " +
                     "cupo_aula, " +
                     "tipo, " +
                     "estado_reg_notas, " +
                     "pago_docente, " +
                     "num_sec_subdepartamento " +
                     ") " +
                     "values " +
                     "( " +
                     _num_sec.ToString().Trim() + ", " +
                     _num_sec_carrera.ToString().Trim() + ", " +
                     _num_sec_semestre.ToString().Trim() + ", " +
                     _num_sec_materia.ToString().Trim() + ", " +
                     _numero_paralelo.ToString().Trim() + ", " +
                     _num_creditos.ToString().Trim() + ", " +
                     _num_creditos_eco.ToString().Trim() + ", " +
                     _num_sec_docente.ToString().Trim() + ", " +
                     _num_sec_ayudante.ToString().Trim() + ", " +
                     _cupo.ToString().Trim() + ", " +
                     _num_alumnos_inscritos.ToString().Trim() + ", " +
                     _operaciones_internet.ToString().Trim() + ", " +
                     Gen.IIf(_cupo_aula == 0, "NULL", _cupo_aula.ToString()) + ", " +
                     _tipo.ToString() + ", " +
                     Gen.IIf(_estado_reg_notas == 0, "NULL", _estado_reg_notas.ToString()) + ", " +
                     _pago_docente.ToString() + ", " +
                     _num_sec_subdepartamento.ToString() + " " +
                     ")";
            return strSql;

        }

        // Método para MODIFICAR un dato en la tabla PARALELOS
        public bool Modificar()
        {
            bool blOperacionCorrecta = false;
            strSql = "update paralelos " +
                     "set " +
                     "num_sec_carrera = " + _num_sec_carrera.ToString() + ", " +
                     "num_sec_semestre = " + _num_sec_semestre.ToString() + ", " +
                     "num_sec_materia = " + _num_sec_materia.ToString() + ", " +
                     "numero_paralelo = " + _numero_paralelo.ToString() + ", " +
                     "num_creditos = " + _num_creditos.ToString() + ", " +
                     "num_creditos_eco = " + _num_creditos.ToString() + ", " +
                     "num_sec_docente = " + _num_sec_docente.ToString() + ", " +
                     "num_sec_ayudante = " + _num_sec_ayudante.ToString() + ", " +
                     "cupo = " + _cupo.ToString() + ", " +
                     "num_alumnos_inscritos = " + _num_alumnos_inscritos.ToString() + ", " +
                     "operaciones_internet = " + _operaciones_internet.ToString() + ", " +
                     "cupo_aula = " + _cupo_aula.ToString() + ", " +
                     "tipo = " + _tipo.ToString() + ", " +
                     "estado_reg_notas = " + _estado_reg_notas.ToString() + ", " +
                     "pago_docente = " + _pago_docente.ToString() + ", " +
                     "num_sec_subdepartamento = " + _num_sec_subdepartamento.ToString() + " " +
                     "where num_sec = " + _num_sec.ToString();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();

            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible actualizar el dato. Se encontró un error al actualizar en la tabla PARALELOS. " + _mensaje;
            return blOperacionCorrecta;
        }

        // Método para ELIMINAR un dato en la tabla PARALELOS
        public bool Borrar()
        {
            bool blOperacionCorrecta = false;
            strSql = "delete paralelos " +
                     "where num_sec = " + _num_sec.ToString();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();

            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible borrar el dato. Se encontró un error al eliminar en la tabla PARALELOS. " + _mensaje;
            return blOperacionCorrecta;
        }

        // Método para VER un dato en la tabla PARALELOS
        public bool Ver(string strNSSubunidad, string strNSParalelo, string strNSUsuario)
        {
            bool blEncontrado = false;
            if (!string.IsNullOrEmpty(strNSSubunidad) && !string.IsNullOrEmpty(strNSParalelo) && !string.IsNullOrEmpty(strNSUsuario))
            {
                DataTable dt = new DataTable();

                strSql = "select a.num_sec, a.num_sec_semestre, a.num_sec_subdepartamento, a.num_sec_carrera";
                strSql += " , a.num_sec_materia, a.numero_paralelo, a.num_creditos, nvl(a.num_creditos_eco,0) num_creditos_eco, a.num_sec_docente, a.num_sec_ayudante";
                strSql += " , a.cupo, a.num_alumnos_inscritos, a.operaciones_internet, a.cupo_aula, a.tipo";
                strSql += " , a.estado_reg_notas, nvl(a.estado_reg_notas,0) estado_rn";
                strSql += " , a.pago_docente, a.num_sec_subdepartamento";
                strSql += " , d.restringir_notas";
                strSql += " , decode(UPPER(c.nombre),'CIENCIAS EXACTAS', 1, decode(UPPER(c.nombre),'CIENCIAS BASICAS', 1, decode(UPPER(c.nombre),'CIENCIAS BÁSICAS', 1, 0))) ciencias_basicas";
                strSql += " , nvl(ps.sadoc_reg_notas,0) permitir_reg_notas_sd";
                strSql += " , d.resumido sem_resum, d.descripcion sem_descrip";
                strSql += " , c.resumido depto_resum, c.nombre depto_nombre, c.tipo tipo_subdepto, b.sigla, b.nombre materia ";
                strSql += " , u.*";
                strSql += " , fsdt1.valor f_cierre_sd_t1, fsdt2.valor f_cierre_sd_t2";
                strSql += " , decode(fsdt1.valor,null,-1,(to_date(fsdt1.valor,'dd/mm/rrrr')-trunc(sysdate)))  dias_vigencia_sdt1";
                strSql += " , decode(fsdt2.valor,null,-1,(to_date(fsdt2.valor,'dd/mm/rrrr')-trunc(sysdate)))  dias_vigencia_sdt2";
                strSql += " , nvl(nextemp.num_notas_extemp,0) num_notas_extemp";
                strSql += " from paralelos a, materias b, gen_subdepartamentos c, semestres d";
                strSql += " , semestres_internet ps";
                strSql += " , (select u.num_sec_usuario, u.num_sec_persona, u.login";
                strSql += "   , u.activo, u.fecha_vigencia-trunc(sysdate) dias_vigencia_usuario";
                strSql += "   , decode(u.login,'INSCRIPCIONES_INTERNET',1,decode(u.login,'INS_INTERNET_TJA',1,0)) usuario_sis_alumnos";
                strSql += "   from sam_usuarios u where u.num_sec_usuario = " + strNSUsuario;
                strSql += "   ) u";
                strSql += " , (select ps.num_sec_semestre, ps.num_sec_parametro, spm.codigo cod_parametro, ps.valor";
                strSql += "   from sam_modulos sm, sam_parametros_modulos spm, sam_parametros_semestres ps";
                strSql += "   where sm.num_sec_subunidad = " + strNSSubunidad;
                strSql += "   and sm.numero_modulo = 19";
                strSql += "   and spm.codigo = '19001'";
                strSql += "   and spm.num_sec_modulo = sm.num_sec_modulo";
                strSql += "   and ps.num_sec_semestre = (select num_sec_semestre from paralelos where num_sec = " + strNSParalelo + ")";
                strSql += "   and ps.num_sec_parametro = spm.num_sec_parametro";
                strSql += "   ) fsdt1";
                strSql += " , (select ps.num_sec_semestre, ps.num_sec_parametro, spm.codigo cod_parametro, ps.valor";
                strSql += "   from sam_modulos sm, sam_parametros_modulos spm, sam_parametros_semestres ps";
                strSql += "   where sm.num_sec_subunidad = " + strNSSubunidad;
                strSql += "   and sm.numero_modulo = 19";
                strSql += "   and spm.codigo = '19002'";
                strSql += "   and spm.num_sec_modulo = sm.num_sec_modulo";
                strSql += "   and ps.num_sec_semestre = (select num_sec_semestre from paralelos where num_sec = " + strNSParalelo + ")";
                strSql += "   and ps.num_sec_parametro = spm.num_sec_parametro";
                strSql += "   ) fsdt2";
                strSql += " , (select a.num_sec_paralelo, (0) num_notas_extemp";
                strSql += "   from notas_extemporaneas a";
                strSql += "   where a.num_sec_paralelo = " + strNSParalelo;
                strSql += "   and a.activo = 1";
                strSql += "   and a.fecha_inicio <= trunc(sysdate)";
                strSql += "   and a.fecha_fin >= trunc(sysdate)";
                strSql += "   group by a.num_sec_paralelo";
                strSql += "   ) nextemp";
                strSql += " where a.num_sec = " + strNSParalelo;
                strSql += " and a.num_sec_materia = b.num_sec";
                strSql += " and a.num_sec_subdepartamento = c.num_sec_subdepartamento";
                strSql += " and a.num_sec_semestre = d.num_sec";
                strSql += " and a.num_sec_semestre = ps.num_sec_semestre(+)";
                strSql += " and a.num_sec_semestre = fsdt1.num_sec_semestre(+)";
                strSql += " and a.num_sec_semestre = fsdt2.num_sec_semestre(+)";
                strSql += " and a.num_sec = nextemp.num_sec_paralelo(+)";

                OracleBD.MostrarError = false;
                OracleBD.StrConexion = _strconexion;
                OracleBD.Sql = strSql;
                OracleBD.sqlDataTable();
                dt = OracleBD.DataTable;
                if (dt.Rows.Count > 0)
                {
                    blEncontrado = true;
                    DataRow dr = dt.Rows[0];
                    _num_sec = Convert.ToInt64(dr["num_sec"].ToString());
                    _num_sec_carrera = Convert.ToInt64(dr["num_sec_carrera"].ToString());
                    _num_sec_semestre = Convert.ToInt64(dr["num_sec_semestre"].ToString());
                    _num_sec_materia = Convert.ToInt64(dr["num_sec_materia"].ToString());
                    _numero_paralelo = Convert.ToInt16(dr["numero_paralelo"].ToString());
                    _num_creditos = Convert.ToInt16(dr["num_creditos"].ToString());
                    if (dr["num_creditos_eco"].ToString().Trim() == "")
                        _num_creditos_eco = 0;
                    else
                        _num_creditos_eco = Convert.ToInt16(dr["num_creditos_eco"].ToString());
                    _num_sec_docente = Convert.ToInt64(dr["num_sec_docente"].ToString());
                    if (dr["num_sec_ayudante"] is DBNull)
                        _num_sec_ayudante = 0;
                    else
                        _num_sec_ayudante = Convert.ToInt64(dr["num_sec_ayudante"].ToString());
                    _cupo = Convert.ToInt32(dr["cupo"].ToString());
                    _num_alumnos_inscritos = Convert.ToInt32(dr["num_alumnos_inscritos"].ToString());
                    _operaciones_internet = Convert.ToInt16(dr["operaciones_internet"].ToString());
                    if (dr["cupo_aula"] is DBNull)
                        _cupo_aula = 0;
                    else
                        _cupo_aula = Convert.ToInt16(dr["cupo_aula"].ToString());
                    _tipo = Convert.ToInt16(dr["tipo"].ToString());
                    if (dr["estado_reg_notas"] is DBNull)
                        _estado_reg_notas = 0;
                    else
                        _estado_reg_notas = Convert.ToInt16(dr["estado_reg_notas"].ToString());

                    _pago_docente = Convert.ToInt16(dr["pago_docente"].ToString());
                    _num_sec_subdepartamento = Convert.ToInt64(dr["num_sec_subdepartamento"].ToString());

                    _semestreresumido = dr["sem_resum"].ToString().Trim();
                    _semestredescripcion = dr["sem_descrip"].ToString().Trim();
                    _subdeptoresumido = dr["depto_resum"].ToString().Trim();
                    _subdeptonombre = dr["depto_nombre"].ToString().Trim();
                    _materiasigla = dr["sigla"].ToString().Trim();
                    _materianombre = dr["materia"].ToString().Trim();
                    _fechacierresdt1 = dr["f_cierre_sd_t1"].ToString().Trim();
                    _fechacierresdt2 = dr["f_cierre_sd_t2"].ToString().Trim();
                    _diasvigenciasdt1 = Convert.ToInt32(dr["dias_vigencia_sdt1"].ToString());
                    if (dr["dias_vigencia_sdt2"] is DBNull)
                        _diasvigenciasdt2 = 0;
                    else
                        _diasvigenciasdt2 = Convert.ToInt32(dr["dias_vigencia_sdt2"].ToString());

                    _tiposubdepto = Convert.ToInt16(dr["tipo_subdepto"].ToString());

                    if (Convert.ToInt16(dr["usuario_sis_alumnos"].ToString()) == 1)
                        _esusuariosisalumnos = true;
                    else
                        _esusuariosisalumnos = false;

                    if (Convert.ToInt16(dr["ciencias_basicas"].ToString()) == 1)
                        _pertencecienciasbasica = true;
                    else
                        _pertencecienciasbasica = false;

                    if (Convert.ToInt16(dr["restringir_notas"].ToString()) == 1)
                        _restringirnotassemestre = true;
                    else
                        _restringirnotassemestre = false;

                    if (Convert.ToInt16(dr["permitir_reg_notas_sd"].ToString()) == 1)
                        _restringirnotassisdocentes = true;
                    else
                        _restringirnotassisdocentes = false;

                    _numpersonasautextemp = 0;      //Convert.ToInt32(dr["notas_num_alus_extemp"].ToString());
                }
                dt.Dispose();
            }
            if (!blEncontrado)
            {
                _num_sec = 0;
                _num_sec_carrera = 0;
                _num_sec_semestre = 0;
                _num_sec_materia = 0;
                _numero_paralelo = 0;
                _num_creditos = 0;
                _num_creditos_eco = 0;
                _num_sec_docente = 0;
                _num_sec_ayudante = 0;
                _cupo = 0;
                _num_alumnos_inscritos = 0;
                _operaciones_internet = 0;
                _cupo_aula = 0;
                _tipo = 0;
                _estado_reg_notas = 0;
                _pago_docente = 0;
                _num_sec_subdepartamento = 0;

                _semestreresumido = string.Empty;
                _semestredescripcion = string.Empty;
                _materiasigla = string.Empty;
                _materianombre = string.Empty;
                _subdeptoresumido = string.Empty;
                _subdeptonombre = string.Empty;
                _fechacierresdt1 = string.Empty;
                _fechacierresdt2 = string.Empty;
                _diasvigenciasdt1 = 0;
                _diasvigenciasdt2 = 0;
                _tiposubdepto = 0;

                _esusuariosisalumnos = false;
                _pertencecienciasbasica = false;
                _restringirnotassemestre = false;
                _restringirnotassisdocentes = false;
                _numpersonasautextemp = 0;
            }
            return blEncontrado;
        }

        #endregion

        #region Metodos Publicos

        public DataTable DTDatosParalelo()
        {
            strSql = "select p.num_sec_semestre, s.descripcion semestre, sd.num_sec_subdepartamento, sd.nombre subdepartamento,  " +
                     "p.num_sec_materia, m.sigla||' '||m.nombre materia, p.num_sec num_sec_paralelo, p.numero_paralelo, " +
                     "to_char(s.fecha_inicio,'yyyy') anio_sem, sd.tipo " +
                     "from paralelos p, semestres s, materias m, gen_subdepartamentos sd " +
                     "where p.num_sec = " + _num_sec.ToString().Trim() + " " +
                     "and p.num_sec_semestre = s.num_sec " +
                     "and p.num_sec_materia = m.num_sec " +
                     "and p.num_sec_subdepartamento = sd.num_sec_subdepartamento";
            OracleBD.Sql = strSql;
            OracleBD.StrConexion = StrConexion;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }

        public DataTable DTListadoParalelosSemestreMateriaNoAsignados(bool ConVacio)
        {
            strSql = "";
            if (ConVacio)
            {
                strSql = "select 0 num_sec_paralelo, 'Ninguno' numero_paralelo, '-' materia_origen " +
                        "from dual " +
                        "union ";
            }
            strSql += "select p.num_sec num_sec_paralelo, to_char(p.numero_paralelo) numero_paralelo, '-' materia_origen  " +
                    "from paralelos p, materias m  " +
                    "where p.num_sec_semestre = " + _num_sec_semestre.ToString().Trim() + " " +
                    "and p.num_sec_subdepartamento = " + _num_sec_subdepartamento.ToString().Trim() + " " +
                    "and p.num_sec_materia = " + _num_sec_materia.ToString().Trim() + " " +
                    "and p.tipo in (1,5) " +
                    "and p.num_sec not in " +
                    "( " +
                    "  select a.num_sec_paralelo_origen " +
                    "  from acad_paralelos_asignados a, paralelos p " +
                    "  where a.estado = 1 " +
                    "  and p.num_sec_semestre = " + _num_sec_semestre.ToString().Trim() + " " +
                    "  and a.num_sec_paralelo_origen = p.num_sec " +
                    ")   " +
                    "and p.num_sec_materia = m.num_sec  " +
                    "order by numero_paralelo";
            OracleBD.Sql = strSql;
            OracleBD.StrConexion = StrConexion;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }


        public DataTable ParalelosMateria(string NSMateria, string NSSemestre, string nsSubDepto, string ModoAcademicoSACAD)
        {
            strSql = "select p.num_sec, p.numero_paralelo par, p.cupo-nvl(a.inscritos,0) espacios, dom.descripcion str_oper_internet, p.operaciones_internet,  " +
                     "per.ap_paterno||' '||per.ap_materno||' '||per.nombres docente  " +
                     "from paralelos p, personas per, dominios dom, gen_subdepartamentos c,  " +
                     "(  " +
                     "   select p.num_sec, count(ap.num_sec_persona) inscritos  " +
                     "   from paralelos p, alumnos_paralelos ap, gen_subdepartamentos c  " +
                     "   where p.num_sec_materia = " + NSMateria + " " +
                     "   and p.num_sec_semestre = " + NSSemestre + " " +
                     "   and p.num_sec_subdepartamento = " + nsSubDepto + " " +
                     "   and p.tipo in (1,5) " +
                     "   and ap.activo = 1  " +
                     "   and ap.estado in (1,4,5,6,7)  " +
                     "   and ap.num_sec_paralelo = p.num_sec  " +
                     "   and p.num_sec_subdepartamento = c.num_sec_subdepartamento  " +
                     "   group by p.num_sec  " +
                     ")a  " +
                     "where p.num_sec_materia = " + NSMateria + " " +
                     "and p.num_sec_semestre = " + NSSemestre + " " +
                     "and p.num_sec_subdepartamento = " + nsSubDepto + " ";
            if (ModoAcademicoSACAD == "2")
                strSql += "and p.operaciones_internet in (1,2,3,4,5,6) ";
            else
                strSql += "and p.operaciones_internet in (1,2,3,5,6) ";
            strSql += "and p.cupo > 0  " +
                      "and p.tipo in (1,5)  " +
                      "and dom.dominio = 'OPER_INTERNET'  " +
                      "and p.num_sec_subdepartamento = c.num_sec_subdepartamento  " +
                      "and dom.valor = p.operaciones_internet  " +
                      "and p.num_sec = a.num_sec(+)  " +
                      "and p.num_sec_docente = per.num_sec  " +
                      "order by p.numero_paralelo";
            OracleBD.Sql = strSql;
            OracleBD.StrConexion = StrConexion;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }

        public DataTable HorariosParalelo()
        {
            strSql = "select distinct ad.num_sec_asignacion, dom.valor, ad.hora_inicio, upper(dom.descripcion) dia, " +
                     "lpad(to_char(trunc(ad.hora_inicio/60)),2,'0')||':'||lpad(to_char(((ad.hora_inicio/60)-trunc(ad.hora_inicio/60))*60),2,'0')||' - '||lpad(to_char(trunc(ad.hora_fin/60)),2,'0')||':'||lpad(to_char(((ad.hora_fin/60)-trunc(ad.hora_fin/60))*60),2,'0') periodo,  " +
                     "au.codigo_aula aula, au.bloque, au.capacidad " +
                     "from sau_asignaciones a, sau_asignaciones_detalles ad, sau_aulas au, dominios dom  " +
                     "where a.num_sec_paralelo = " + _num_sec.ToString().Trim() + " " +
                     "and a.tipo_asignacion = 2  " +
                     "and a.estado_asignacion = 1  " +
                     "and dom.dominio = 'DIA_ORACLE'  " +
                     "and to_char(dom.valor) = to_char(ad.fecha,'D')  " +
                     "and a.num_sec_asignacion = ad.num_sec_asignacion  " +
                     "and ad.num_sec_aula = au.num_sec_aula  " +
                     "order by dom.valor, ad.hora_inicio";
            OracleBD.Sql = strSql;
            OracleBD.StrConexion = StrConexion;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }

        public DataTable HorariosParaleloPrgAcad()
        {
            strSql = "select distinct ad.num_sec_asignacion, au.num_sec_aula, dom.valor dia, ad.hora_inicio, ad.hora_fin, upper(dom.descripcion) dia_str, " +
                     "lpad(to_char(trunc(ad.hora_inicio/60)),2,'0')||':'||lpad(to_char(((ad.hora_inicio/60)-trunc(ad.hora_inicio/60))*60),2,'0')||' - '||lpad(to_char(trunc(ad.hora_fin/60)),2,'0')||':'||lpad(to_char(((ad.hora_fin/60)-trunc(ad.hora_fin/60))*60),2,'0') periodo,  " +
                     "au.codigo_aula aula, 0 secuencia " +
                     "from sau_asignaciones a, sau_asignaciones_detalles ad, sau_aulas au, dominios dom  " +
                     "where a.num_sec_paralelo = " + _num_sec.ToString().Trim() + " " +
                     "and a.tipo_asignacion = 2  " +
                     "and a.estado_asignacion = 1  " +
                     "and dom.dominio = 'DIA_ORACLE'  " +
                     "and to_char(dom.valor) = to_char(ad.fecha,'D')  " +
                     "and a.num_sec_asignacion = ad.num_sec_asignacion  " +
                     "and ad.num_sec_aula = au.num_sec_aula  " +
                     "order by dom.valor, ad.hora_inicio";
            OracleBD.Sql = strSql;
            OracleBD.StrConexion = StrConexion;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }

        public string CreditosParaleloMateria(string NSMateria, string NSSemestre)
        {
            string strCreditos;
            int i;
            strCreditos = "";
            strSql = "select distinct num_creditos " +
                    "from paralelos " +
                    "where num_sec_materia = " + NSMateria + " " +
                    "and num_sec_semestre = " + NSSemestre;
            OracleBD.Sql = strSql;
            OracleBD.StrConexion = StrConexion;
            OracleBD.sqlDataTable();

            for (i = 0; i <= OracleBD.DataTable.Rows.Count - 1; i++)
            {
                if (strCreditos == "")
                {
                    strCreditos += OracleBD.DataTable.Rows[i][0].ToString();
                }
                else
                {
                    strCreditos += "; " + OracleBD.DataTable.Rows[i][0].ToString();
                }
            }
            return strCreditos;
        }

        public string DocenteParalelo()
        {
            strSql = "select per.ap_paterno||' '||per.ap_materno||' '||per.nombres " +
                    "from paralelos p, personas per " +
                    "where p.num_sec = " + _num_sec + " " +
                    "and p.num_sec_docente = per.num_sec";
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            if (OracleBD.DataTable.Rows.Count == 0)
                return "";
            else
                return OracleBD.DataTable.Rows[0][0].ToString();
        }

        public string OperacionesInternetParalelo()
        {
            strSql = "select operaciones_internet " +
                    "from paralelos p " +
                    "where p.num_sec = " + _num_sec;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            if (OracleBD.DataTable.Rows.Count == 0)
                return "";
            else
                return OracleBD.DataTable.Rows[0][0].ToString();
        }

        public string ModificarEstadoRegNotas()
        {
            strSql = "update paralelos " +
                     "set estado_reg_notas = " + _estado_reg_notas.ToString().Trim() + " " +
                     "where num_sec = " + _num_sec.ToString().Trim();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSql();
            return OracleBD.Mensaje;
        }

        public string SQLListaSemestresDocente()
        {
            strSql = "select p.num_sec_semestre, s.descripcion, s.activo, s.fecha_inicio " +
                    "from paralelos p, semestres s, gen_subdepartamentos c " +
                    "where num_sec_docente = " + _num_sec_docente.ToString().Trim() + " " +
                    "and p.cupo > 0 " +
                    "and p.num_alumnos_inscritos > 0 " +
                    "and p.operaciones_internet <> 4 " +
                    "and c.tipo <> 6 " +
                    "and p.num_sec_semestre = s.num_sec " +
                    "and p.num_sec_subdepartamento = c.num_sec_subdepartamento " +
                    "group by p.num_sec_semestre, s.descripcion, s.activo, s.fecha_inicio " +
                    "order by s.activo, s.fecha_inicio desc";
            return strSql;
        }

        public string SQLListaMateriasDocente()
        {
            strSql = "select p.num_sec, m.sigla||' '||m.nombre||' Paralelo ('||p.numero_paralelo||')' materia " +
                    "from paralelos p, materias m, gen_subdepartamentos c " +
                    "where p.num_sec_semestre = " + _num_sec_semestre.ToString().Trim() + " " +
                    "and p.num_sec_docente = " + _num_sec_docente.ToString().Trim() + " " +
                    "and p.cupo > 0 " +
                    "and p.num_alumnos_inscritos > 0 " +
                    "and p.operaciones_internet <> 4 " +
                    "and c.tipo <> 6 " +
                    "and p.num_sec_materia = m.num_sec " +
                    "and p.num_sec_subdepartamento = c.num_sec_subdepartamento";
            return strSql;
        }

        public bool VerificarDocenteTieneMaterias()
        {
            strSql = "select count(0) " +
                    "from paralelos p, gen_subdepartamentos c " +
                    "where num_sec_docente = " + _num_sec_docente.ToString().Trim() + " " +
                    "and c.tipo <> 6 " +
                    "and p.cupo > 0 " +
                    "and p.operaciones_internet <> 4 " +
                    "and p.num_alumnos_inscritos > 0 " +
                    "and p.num_sec_subdepartamento = c.num_sec_subdepartamento";
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            if (OracleBD.DataTable.Rows[0][0].ToString().Trim() == "0")
                return false;
            else
                return true;
        }

        public DataTable DTListadoParalelos()
        {
            strSql = "select a.num_sec, a.numero_paralelo, b.ap_paterno||' '||b.ap_materno||' '||b.nombres docente, " +
                     "a.num_creditos, a.cupo, c.descripcion tipo_desc, d.descripcion oper_desc " +
                     "from paralelos a, personas b, dominios c, dominios d " +
                     "where a.num_sec_semestre = " + _num_sec_semestre.ToString().Trim() + " " +
                     "and a.num_sec_subdepartamento = " + _num_sec_subdepartamento.ToString().Trim() + " " +
                     "and a.num_sec_materia = " + _num_sec_materia.ToString().Trim() + " " +
                     "and a.num_sec_docente = b.num_sec " +
                     "and c.dominio = 'TIPO_PARALELO' " +
                     "and c.valor = a.tipo " +
                     "and d.dominio = 'OPER_INTERNET' " +
                     "and d.valor = a.operaciones_internet " +
                     "order by numero_paralelo";
            OracleBD.Sql = strSql;
            OracleBD.StrConexion = StrConexion;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }

        public DataTable DTListadoMateriasParalelos()
        {
            strSql = "select a.num_sec, e.sigla, e.nombre materia, a.numero_paralelo, b.ap_paterno||' '||b.ap_materno||' '||b.nombres docente, " +
                    "a.num_creditos, a.cupo, nvl(f.inscritos, 0) inscritos, nvl(g.reservados,0) reservados, c.descripcion tipo_desc, d.descripcion oper_desc " +
                    "from paralelos a, personas b, dominios c, dominios d, materias e, " +
                    "( " +
                    "	select p.num_sec num_sec_paralelo, count(0) inscritos " +
                    "	from alumnos_paralelos ap, paralelos p " +
                    "	where ap.activo = 1 " +
                    "	and ap.estado = 1 " +
                    "	and p.num_sec_semestre = " + _num_sec_semestre.ToString().Trim() + " " +
                    "	and p.num_sec_subdepartamento = " + _num_sec_subdepartamento.ToString() + " " +
                    "	and p.num_sec = ap.num_sec_paralelo " +
                    "	group by p.num_sec " +
                    ")f, " +
                    "( " +
                    "	select p.num_sec num_sec_paralelo, count(0) reservados " +
                    "	from alumnos_paralelos ap, paralelos p " +
                    "	where ap.activo = 1 " +
                    "	and ap.estado = 2 " +
                    "	and p.num_sec_semestre = " + _num_sec_semestre.ToString().Trim() + " " +
                    "	and p.num_sec_subdepartamento = " + _num_sec_subdepartamento.ToString() + " " +
                    "	and p.num_sec = ap.num_sec_paralelo " +
                    "	group by p.num_sec " +
                    ")g " +
                    "where a.num_sec_semestre = " + _num_sec_semestre.ToString().Trim() + " " +
                    "and a.num_sec_subdepartamento = " + _num_sec_subdepartamento.ToString() + " " +
                    "and c.dominio = 'TIPO_PARALELO' " +
                    "and d.dominio = 'OPER_INTERNET' " +
                    "and e.num_sec = a.num_sec_materia " +
                    "and a.num_sec_docente = b.num_sec " +
                    "and c.valor = a.tipo " +
                    "and d.valor = a.operaciones_internet " +
                    "and a.num_sec = f.num_sec_paralelo(+) " +
                    "and a.num_sec = g.num_sec_paralelo(+) " +
                    "order by e.sigla, e.nombre, numero_paralelo";

            OracleBD.Sql = strSql;
            OracleBD.StrConexion = StrConexion;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }

        public string RecuperarNSSemestre()
        {
            strSql = "select num_sec_semestre " +
                     "from paralelos " +
                     "where num_sec = " + _num_sec.ToString().Trim();
            OracleBD.Sql = strSql;
            OracleBD.StrConexion = StrConexion;
            OracleBD.sqlDataTable();
            if (OracleBD.DataTable.Rows.Count == 0)
                return "0";
            else
                return OracleBD.DataTable.Rows[0]["num_sec_semestre"].ToString().Trim();
        }

        public string CreditosMateria(string strNSSubDepartamento, string strNSSemestre, string strNSMateria)
        {
            strSql = "select pensums.*, pensums_materias.*, fecha_inicio, decode(carr_sem.num_sec_pensum, pensums.num_sec, 1, 2) car_sem " +
                     "from pensums, pensums_materias, semestres, " +
                     "( " +
                     "        select * from carreras_semestres " +
                     "        where num_sec_subdepartamento = " + strNSSubDepartamento + " " +
                     "        and num_sec_semestre = " + strNSSemestre + " " +
                     ")carr_sem " +
                     "where pensums.num_sec_subdepartamento = " + strNSSubDepartamento + " " +
                     "and num_sec_materia = " + strNSMateria + " " +
                     "and pensums.num_sec_semestre_creacion = semestres.num_sec " +
                     "and pensums_materias.num_sec_pensum = pensums.num_sec " +
                     "and pensums.num_sec_subdepartamento = carr_sem.num_sec_subdepartamento(+) " +
                     "order by car_sem, pensums.activo, fecha_inicio desc";
            OracleBD.Sql = strSql;
            OracleBD.StrConexion = StrConexion;
            OracleBD.sqlDataTable();
            if (OracleBD.DataTable.Rows.Count == 0)
                return "0";
            else
                return OracleBD.DataTable.Rows[0]["num_creditos_actual"].ToString().Trim();
        }

        public string NumeroParaleloSiguiente(string strNSSubDepartamento, string strNSSemestre, string strNSMateria)
        {
            strSql = "select nvl(max(numero_paralelo),0)+1 numero_maximo " +
                     "from paralelos " +
                     "where num_sec_materia = " + strNSMateria + " " +
                     "and num_sec_subdepartamento = " + strNSSubDepartamento + " " +
                     "and num_sec_semestre = " + strNSSemestre;
            OracleBD.Sql = strSql;
            OracleBD.StrConexion = StrConexion;
            OracleBD.sqlDataTable();
            if (OracleBD.DataTable.Rows.Count == 0)
                return "1";
            else
                return OracleBD.DataTable.Rows[0]["numero_maximo"].ToString().Trim();
        }

        public string CerrarParalelos(string strNSDocenteVacio, string strUsuarioReg, string strNSUsuarioReg, string strCodigoUsuario, GridView gvParalelos, ref long[] ListaEstudiantes)
        {
            int i, j;
            string msj = string.Empty;
            string[] ListaSqls = new string[0];
            ListaEstudiantes = new long[0];
            int NumSqls = 0;
            int NumEstudiantes = 0;
            DataTable dtInscritos;

            OracleBD.StrConexion = StrConexion;

            for (i = 0; i < gvParalelos.Rows.Count; i++)
            {
                // Verifica si el paralelo está tiqueado
                if (((CheckBox)gvParalelos.Rows[i].Cells[0].Controls[1]).Checked)
                {
                    // Desactivar Paralelos
                    strSql = " Update paralelos" +
                             " Set cupo = 0" +
                             " , num_alumnos_inscritos = 0" +
                             " , tipo = 7" +
                             " , operaciones_internet = 4" +
                             " , num_sec_docente = " + strNSDocenteVacio +
                             " Where num_sec = " + gvParalelos.Rows[i].Cells[1].Text;
                    Array.Resize<string>(ref ListaSqls, NumSqls + 1);
                    ListaSqls[NumSqls] = strSql;
                    NumSqls += 1;

                    // Retirar alumnos inscritos y reservados
                    strSql = " select num_sec_persona, num_sec_paralelo from alumnos_paralelos" +
                             " where num_sec_paralelo = " + gvParalelos.Rows[i].Cells[1].Text +
                             " and estado <> 3" +
                             " and activo = 1";
                    OracleBD.Sql = strSql;
                    OracleBD.sqlDataTable();
                    dtInscritos = OracleBD.DataTable;

                    for (j = 0; j < dtInscritos.Rows.Count; j++)
                    {
                        // Desactivar registro de inscripcion
                        strSql = " update alumnos_paralelos" +
                                " set activo=2" +
                                " where num_sec_persona = " + dtInscritos.Rows[j][0].ToString().Trim() +
                                " and activo = 1" +
                                " and num_sec_paralelo in " +
                                " (select num_sec " +
                                " from paralelos a" +
                                " , (select num_sec_semestre, num_sec_materia from paralelos where num_sec = " + gvParalelos.Rows[i].Cells[1].Text + ") b" +
                                " where a.num_sec_semestre = b.num_sec_semestre" +
                                " and a.num_sec_materia = b.num_sec_materia )";
                        Array.Resize<string>(ref ListaSqls, NumSqls + 1);
                        ListaSqls[NumSqls] = strSql;
                        NumSqls += 1;

                        // Insertar registro de retiro
                        strSql = " insert into alumnos_paralelos (num_sec_persona, num_sec_paralelo, fecha_registro" +
                                " , estado, actual, activo, deuda, salto_prereq" +
                                " , num_sec_tramite, num_documento" +
                                " , observacion, condiciones_insc, codigo_usuario, usuario_registro, num_sec_usuario_reg) values" +
                                " (" + dtInscritos.Rows[j][0].ToString().Trim() +
                                " , " + gvParalelos.Rows[i].Cells[1].Text +
                                " , sysdate" +
                                " , 3" +
                                " , 1, 1" +
                                " , 0" +
                                " , 0" +
                                " , NULL" +
                                " , NULL" +
                                " , 'CIERRE DE PARALELO'" +
                                " , NULL" +
                                " , '" + strCodigoUsuario + "'" +
                                " , '" + strUsuarioReg + "'" +
                                " , " + strNSUsuarioReg +
                                ")";
                        Array.Resize<string>(ref ListaSqls, NumSqls + 1);
                        ListaSqls[NumSqls] = strSql;
                        NumSqls += 1;

                        // Adionar a una lista los estudiantes afectados para actualizar su deuda posteriormente
                        Array.Resize<long>(ref ListaEstudiantes, NumEstudiantes + 1);
                        ListaEstudiantes[NumEstudiantes] = Convert.ToInt64(dtInscritos.Rows[j][0]);
                        NumEstudiantes += 1;

                    }

                    // Eliminar horarios de la materia

                    strSql = "update sau_asignaciones_detalles " +
                             "set estado = 4 " +
                             "where num_sec_asignacion in " +
                             "( " +
                             "	select num_sec_asignacion " +
                             "	from sau_asignaciones " +
                             "	where num_sec_paralelo = " + gvParalelos.Rows[i].Cells[1].Text + " " +
                             ")";
                    Array.Resize<string>(ref ListaSqls, NumSqls + 1);
                    ListaSqls[NumSqls] = strSql;
                    NumSqls += 1;

                    strSql = "update sau_asignaciones " +
                             "set estado_asignacion = 2 " +
                             "where num_sec_paralelo = " + gvParalelos.Rows[i].Cells[1].Text;
                    Array.Resize<string>(ref ListaSqls, NumSqls + 1);
                    ListaSqls[NumSqls] = strSql;
                    NumSqls += 1;
                }
            }

            OracleBD.ListaSqls = ListaSqls;
            OracleBD.NumSqls = NumSqls;
            OracleBD.EjecutarSqlsTrans();

            if (OracleBD.Error)
            {
                msj = OracleBD.Mensaje;
            }

            return msj;
        }

        public string SQLParalelosMaterias(string NSSubDepartamento, string NSMateria, bool semestre_activo)
        {
            strSql = " select p.num_sec, p.numero_paralelo " +
                     " from paralelos p, semestres s, materias m " +
                     " where p.num_sec_subdepartamento = " + NSSubDepartamento + " " +
                     " and m.num_sec = " + NSMateria + " " +
                     " and p.num_sec_semestre = s.num_sec " +
                     " and p.num_sec_materia = m.num_sec ";

            if (semestre_activo)
            {
                strSql += " and s.activo = 1 ";
            }

            strSql += " order by p.numero_paralelo";
            return strSql;
        }

        /// <summary>
        /// Consulta que genera las materias de un determinado semestre de un subdepartamento.
        /// Debe llenarse obligatoriamente los campos NumSecSemestre y NumSecSubDepartamento
        /// </summary>
        /// <returns></returns>
        public string SQLMateriasSemestre()
        {
            strSql = "select p.num_sec_materia, m.sigla||' '||m.nombre materia " +
                    "from paralelos p, materias m " +
                    "where p.num_sec_semestre = " + _num_sec_semestre.ToString().Trim() + " " +
                    "and p.num_sec_subdepartamento = " + _num_sec_subdepartamento.ToString().Trim() + " " +
                    "and p.tipo in (1,5) " +
                    "and p.num_sec_materia = m.num_sec " +
                    "group by p.num_sec_materia, m.sigla, m.nombre " +
                    "order by m.sigla";
            return strSql;
        }

        public string RevisarParaleloRepetido(int Modo)
        {
            strSql = " select * from paralelos ";
            if (Modo == 2)
            {
                strSql += " where num_sec_semestre = " + _num_sec_semestre.ToString().Trim() + " " +
                        " and num_sec_subdepartamento = " + _num_sec_subdepartamento.ToString().Trim() + " " +
                        " and num_sec_materia = " + _num_sec_materia.ToString().Trim() + " " +
                        " and num_sec <> " + _num_sec.ToString().Trim() + " " +
                        " and numero_paralelo = " + _numero_paralelo.ToString().Trim() + " ";
            }
            else
            {
                strSql += " where num_sec_semestre = " + _num_sec_semestre.ToString().Trim() + " " +
                        " and num_sec_subdepartamento = " + _num_sec_subdepartamento.ToString().Trim() + " " +
                        " and num_sec_materia = " + _num_sec_materia.ToString().Trim() + " " +
                        " and numero_paralelo = " + _numero_paralelo.ToString().Trim() + " ";
            }
            OracleBD.MostrarError = false;
            OracleBD.Sql = strSql;
            OracleBD.StrConexion = StrConexion;
            OracleBD.sqlDataTable();

            if (OracleBD.DataTable.Rows.Count > 0)
                return "El número de paralelo está repetido.";
            else
                return "";
        }
        
        public string InsertarParalelo(string strModoAcademico, string strNSSubDepartamento, string strNSSubUnidad, string strFechaMenor, string strFechaFin, GridView gvAulas)
        {
            string msj = string.Empty;
            string strNSParalelo = string.Empty;
            string strNSAsignacion = string.Empty;
            DateTime axFechaIni, axFechaFin, axFecha;
            int intDiaSemana;

            int intNroSqls = 0;
            string[] ListaSqls = new string[100];

            OracleBD.StrConexion = _strconexion;
            // Query para insertar paralelo
            strNSParalelo = OracleBD.Generar_NumSec("PARALELOS_SEC").ToString().Trim();
            
            strSql = "insert into paralelos " +
                     "( " +
                     "num_sec, " +
                     "num_sec_carrera, " +
                     "num_sec_semestre, " +
                     "num_sec_materia, " +
                     "numero_paralelo, " +
                     "num_creditos, " +
                     "num_creditos_eco, " +
                     "num_sec_docente, " +
                     "num_sec_ayudante, " +
                     "cupo, " +
                     "num_alumnos_inscritos, " +
                     "operaciones_internet, " +
                     "cupo_aula, " +
                     "tipo, " +
                     "estado_reg_notas, " +
                     "pago_docente, " +
                     "num_sec_subdepartamento " +
                     ") " +
                     "values " +
                     "( " +
                     strNSParalelo + ", " +
                     "0, " +
                     _num_sec_semestre.ToString() + ", " +
                     _num_sec_materia.ToString() + ", " +
                     _numero_paralelo.ToString() + ", " +
                     _num_creditos.ToString() + ", " +
                     _num_creditos_eco.ToString() + ", " +
                     _num_sec_docente.ToString() + ", " +
                     "0, " +
                     _cupo.ToString() + ", " +
                     "0, " +
                     _operaciones_internet.ToString() + ", " +
                     "null, " +
                     _tipo.ToString() + ", " +
                     _estado_reg_notas.ToString() + ", " +
                     "1, " +
                     _num_sec_subdepartamento.ToString() + " " +
                     ")";
            ListaSqls[intNroSqls] = strSql;
            intNroSqls += 1;

            // Query para insertar las evaluaciones
            if (strModoAcademico == "2") // Postgrado
            {
                strSql = "insert into evaluaciones " +
                         "(num_sec_paralelo, num_evaluacion, ponderacion, registrada) " +
                         "values " +
                         "(" + strNSParalelo + ", 1, 100, 2)";
                ListaSqls[intNroSqls] = strSql;
                intNroSqls += 1;
            }
            else
            {
                // Pregrado
                strSql = "insert into evaluaciones " +
                         "(num_sec_paralelo, num_evaluacion, ponderacion, registrada) " +
                         "values " +
                         "(" + strNSParalelo + ", 1, 50, 2)";
                ListaSqls[intNroSqls] = strSql;
                intNroSqls += 1;

                strSql = "insert into evaluaciones " +
                         "(num_sec_paralelo, num_evaluacion, ponderacion, registrada) " +
                         "values " +
                         "(" + strNSParalelo + ", 2, 50, 2)";
                ListaSqls[intNroSqls] = strSql;
                intNroSqls += 1;
            }


            // Query para insertar las aulas asignadas

            strNSAsignacion = OracleBD.Generar_NumSec("SAU_ASIGNACIONES_SEC").ToString().Trim();
            strSql = "insert into sau_asignaciones " +
                     "(num_sec_asignacion, tipo_asignacion, num_sec_paralelo, " +
                     "num_sec_carrera, motivo, numero_boleta, " +
                     "num_sec_responsable, estado_asignacion, referencia, " +
                     "num_sec_evento_asignacion, num_sec_subunidad, " +
                     "num_sec_departamento, num_sec_subdepartamento) " +
                     "values " +
                     "(" + strNSAsignacion + ", 2, " + strNSParalelo + ", " +
                     "0, 'CLASE REGULAR DE SEMESTRE', 0, " +
                     "0, 1, null, " +
                     "0, " + strNSSubUnidad + ", " +
                     "null, " + _num_sec_subdepartamento.ToString().Trim() + ")";
            ListaSqls[intNroSqls] = strSql;
            intNroSqls += 1;

            for (int i = 0; i < gvAulas.Rows.Count; i++)
            {
                axFechaIni = Convert.ToDateTime(strFechaMenor);
                axFechaFin = Convert.ToDateTime(strFechaFin);
                axFecha = axFechaIni;
                // Revisar si el aula sigue libre.
                while (axFecha <= axFechaFin)
                {
                    intDiaSemana = Convert.ToInt16(axFecha.DayOfWeek + 1);
                    if (intDiaSemana == Convert.ToInt16(gvAulas.Rows[i].Cells[2].Text))
                    {
                        // Verificar si el aula esta libre
                        strSql = "insert into sau_asignaciones_detalles " +
                                 "(num_sec_asignacion, num_sec_aula, " +
                                 "fecha, hora_inicio, hora_fin, observaciones, estado, " +
                                 "fecha_registro, fecha_asigna, usuario, usuario_asigna) " +
                                 "values " +
                                 "(" + strNSAsignacion + ", " + gvAulas.Rows[i].Cells[1].Text + ", " +
                                 "to_date('" + axFecha.ToShortDateString() + "', 'dd/mm/yyyy') , " + gvAulas.Rows[i].Cells[3].Text + ", " + gvAulas.Rows[i].Cells[4].Text + ", null, 1, " +
                                 "sysdate, sysdate, user, user)";
                        ListaSqls[intNroSqls] = strSql;
                        intNroSqls += 1;
                    }
                    axFecha = axFecha.AddDays(1);
                }
            }
            OracleBD.ListaSqls = ListaSqls;
            OracleBD.NumSqls = intNroSqls;
            OracleBD.EjecutarSqlsTrans();
            if (OracleBD.Error)
                msj = OracleBD.Mensaje;
            return msj;
        }

        public string ModificarParalelo(string strModoAcademico, string strNSParalelo, bool bReasignarAulas, string strNSAsignacion, string strNSSubDepartamento, string strNSSubUnidad, string strFechaMenor, string strFechaFin, GridView gvAulas)
        {
            string msj = string.Empty;
            DateTime axFechaIni, axFechaFin, axFecha;
            int intDiaSemana;

            int intNroSqls = 0;
            string[] ListaSqls = new string[100];

            OracleBD.StrConexion = _strconexion;
            // Query para modificar paralelo
            strSql = "Update paralelos set" +
                    " numero_paralelo = " + _numero_paralelo.ToString() +
                    " , num_creditos = " + _num_creditos.ToString() +
                    " , num_creditos_eco = " + _num_creditos_eco.ToString() +
                    " , cupo = " + _cupo.ToString() +
                    " , num_sec_docente = " + _num_sec_docente.ToString() +
                    " , operaciones_internet = " + _operaciones_internet.ToString() +
                    " , tipo = " + _tipo.ToString() +
                    " , estado_reg_notas = " + _estado_reg_notas.ToString() +
                    " where num_sec = " + _num_sec.ToString() +
                    " and (numero_paralelo <> " + strNSParalelo +
                    " or num_creditos <> " + _numero_paralelo.ToString() +
                    " or cupo <> " + _cupo.ToString() +
                    " or cupo is null" +
                    " or num_sec_docente <> " + _num_sec_docente.ToString() +
                    " or operaciones_internet <> " + _operaciones_internet.ToString() +
                    " or operaciones_internet is null" +
                    " or tipo <> " + _tipo.ToString() +
                    " or estado_reg_notas <> " + _estado_reg_notas.ToString() +
                    " or estado_reg_notas is null)";
            ListaSqls[intNroSqls] = strSql;
            intNroSqls += 1;

            // Query para insertar las aulas asignadas
            if (bReasignarAulas)
            {
                if (strNSAsignacion == "0")
                {
                    strNSAsignacion = OracleBD.Generar_NumSec("SAU_ASIGNACIONES_SEC").ToString().Trim();
                    strSql = "insert into sau_asignaciones " +
                             "(num_sec_asignacion, tipo_asignacion, num_sec_paralelo, " +
                             "num_sec_carrera, motivo, numero_boleta, " +
                             "num_sec_responsable, estado_asignacion, referencia, " +
                             "num_sec_evento_asignacion, num_sec_subunidad, " +
                             "num_sec_departamento, num_sec_subdepartamento) " +
                             "values " +
                             "(" + strNSAsignacion + ", 2, " + strNSParalelo + ", " +
                             "0, 'CLASE REGULAR DE SEMESTRE', 0, " +
                             "0, 1, null, " +
                             "0, " + strNSSubUnidad + ", " +
                             "null, " + _num_sec_subdepartamento.ToString().Trim() + ")";
                    ListaSqls[intNroSqls] = strSql;
                    intNroSqls += 1;
                }
                else
                {
                    strSql = "update sau_asignaciones set " +
                             " estado_asignacion = 2 " +
                             " where num_sec_asignacion = " + strNSAsignacion;
                    ListaSqls[intNroSqls] = strSql;
                    intNroSqls += 1;

                    strSql = "update sau_asignaciones_detalles set " +
                             " estado = 2 " +
                             " where num_sec_asignacion = " + strNSAsignacion;
                    ListaSqls[intNroSqls] = strSql;
                    intNroSqls += 1;

                    strNSAsignacion = OracleBD.Generar_NumSec("SAU_ASIGNACIONES_SEC").ToString().Trim();
                    strSql = "insert into sau_asignaciones " +
                             "(num_sec_asignacion, tipo_asignacion, num_sec_paralelo, " +
                             "num_sec_carrera, motivo, numero_boleta, " +
                             "num_sec_responsable, estado_asignacion, referencia, " +
                             "num_sec_evento_asignacion, num_sec_subunidad, " +
                             "num_sec_departamento, num_sec_subdepartamento) " +
                             "values " +
                             "(" + strNSAsignacion + ", 2, " + strNSParalelo + ", " +
                             "0, 'CLASE REGULAR DE SEMESTRE', 0, " +
                             "0, 1, null, " +
                             "0, " + strNSSubUnidad + ", " +
                             "null, " + _num_sec_subdepartamento.ToString().Trim() + ")";
                    ListaSqls[intNroSqls] = strSql;
                    intNroSqls += 1;
                }
                
                for (int i = 0; i < gvAulas.Rows.Count; i++)
                {
                    axFechaIni = Convert.ToDateTime(strFechaMenor);
                    axFechaFin = Convert.ToDateTime(strFechaFin);
                    axFecha = axFechaIni;
                    // Revisar si el aula sigue libre.
                    while (axFecha <= axFechaFin)
                    {
                        intDiaSemana = Convert.ToInt16(axFecha.DayOfWeek + 1);
                        if (intDiaSemana == Convert.ToInt16(gvAulas.Rows[i].Cells[2].Text))
                        {
                            // Verificar si el aula esta libre
                            strSql = "insert into sau_asignaciones_detalles " +
                                     "(num_sec_asignacion, num_sec_aula, " +
                                     "fecha, hora_inicio, hora_fin, observaciones, estado, " +
                                     "fecha_registro, fecha_asigna, usuario, usuario_asigna) " +
                                     "values " +
                                     "(" + strNSAsignacion + ", " + gvAulas.Rows[i].Cells[1].Text + ", " +
                                     "to_date('" + axFecha.ToShortDateString() + "', 'dd/mm/yyyy') , " + gvAulas.Rows[i].Cells[3].Text + ", " + gvAulas.Rows[i].Cells[4].Text + ", null, 1, " +
                                     "sysdate, sysdate, user, user)";
                            ListaSqls[intNroSqls] = strSql;
                            intNroSqls += 1;
                        }
                        axFecha = axFecha.AddDays(1);
                    }
                }
            }
            
            OracleBD.ListaSqls = ListaSqls;
            OracleBD.NumSqls = intNroSqls;
            OracleBD.EjecutarSqlsTrans();
            if (OracleBD.Error)
                msj = OracleBD.Mensaje;
            return msj;
        }

        public string BorrarParalelo()
        {
            string msj = string.Empty;
            int intNroSqls = 0;
            string[] ListaSqls = new string[100];

            strSql = "select * " +
                    "from alumnos_paralelos " +
                    "where num_sec_paralelo = " + _num_sec.ToString().Trim();

            OracleBD.MostrarError = false;
            OracleBD.Sql = strSql;
            OracleBD.StrConexion = StrConexion;
            OracleBD.sqlDataTable();
            if (OracleBD.DataTable.Rows.Count > 0)
            {
                msj = "No es posible borrar un paralelo, existen alumnos inscritos y/o retirados.";
            }
            else
            {
                // Query para eliminar paralelo
                strSql = "delete sau_asignaciones_detalles " +
                        "where num_sec_asignacion in " +
                        "(" +
                        "select num_sec_asignacion from sau_asignaciones where num_sec_paralelo = " + _num_sec.ToString().Trim() + " " +
                        ")";
                ListaSqls[intNroSqls] = strSql;
                intNroSqls += 1;

                // Query para eliminar paralelo
                strSql = "delete sau_asignaciones " +
                        "where num_sec_paralelo = " + _num_sec.ToString().Trim();
                ListaSqls[intNroSqls] = strSql;
                intNroSqls += 1;

                // Query para eliminar paralelo
                strSql = "delete evaluaciones " +
                        "where num_sec_paralelo = " + _num_sec.ToString().Trim();
                ListaSqls[intNroSqls] = strSql;
                intNroSqls += 1;


                // Query para eliminar paralelo
                strSql = "delete paralelos " +
                        "where num_sec = " + _num_sec.ToString().Trim();
                ListaSqls[intNroSqls] = strSql;
                intNroSqls += 1;
                
                OracleBD.ListaSqls = ListaSqls;
                OracleBD.NumSqls = intNroSqls;
                OracleBD.EjecutarSqlsTrans();
                if (OracleBD.Error)
                    msj = OracleBD.Mensaje;
            }
            
            return msj;
        }

        public bool VerificarDocenteDictaMateriasSemestreVigente()
        {
            strSql = "select count(0) " +
                     "from paralelos p, gen_subdepartamentos c " +
                     "where num_sec_docente = " + _num_sec_docente.ToString().Trim() + " " +
                     "and c.tipo <> 6 " +
                     "and p.cupo > 0 " +
                     "and p.operaciones_internet <> 4 " +
                     "and p.num_alumnos_inscritos > 0 " +
                     "and p.num_sec_semestre in " +
                     "( " +
                     "	select num_sec " +
                     "	from semestres " +
                     "	where trunc(sysdate) >= trunc(fecha_inicio) " +
                     "	and trunc(sysdate) <= trunc(fecha_fin) " +
                     ") " +
                     "and p.num_sec_subdepartamento = c.num_sec_subdepartamento";
            OracleBD.MostrarError = false;
            OracleBD.Sql = strSql;
            OracleBD.StrConexion = StrConexion;
            OracleBD.sqlDataTable();
            if (OracleBD.DataTable.Rows[0][0].ToString().Trim() == "0")
            {
                // No tiene materias asignadas en el semestre vigente
                return false;
            }
            else
            {
                // Tiene Materias en el semestre vigente
                return true;
            }
        }

        public DataTable DTParalelosDocente()
        {
            strSql = "select distinct a.num_sec_paralelo, c.resumido depto, d.sigla,  " +
                    "d.nombre materia, b.numero_paralelo par, b.num_creditos  " +
                    "from alumnos_paralelos a, paralelos b, gen_subdepartamentos c,  " +
                    "materias d, personas e, dominios f  " +
                    "where b.num_sec_docente = " + _num_sec_docente.ToString().Trim() + "  " +
                    "and b.num_sec_semestre = " + _num_sec_semestre.ToString().Trim() + " " +
                    "and b.tipo in (1,5)  " +
                    "and c.tipo in (4 ,5) " +
                    "and b.num_sec_subdepartamento = c.num_sec_subdepartamento " +
                    "and a.num_sec_paralelo = b.num_sec  " +
                    "and a.activo = 1  " +
                    "and a.estado in (1,2)  " +
                    "and b.num_sec_materia = d.num_sec  " +
                    "and b.num_sec_docente = e.num_sec  " +
                    "and f.dominio = 'ESTADO_ALU_PAR'  " +
                    "and f.valor = a.estado  " +
                    "order by depto, sigla, par";
            OracleBD.MostrarError = false;
            OracleBD.Sql = strSql;
            OracleBD.StrConexion = StrConexion;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }

        public DataTable DTParalelosPorSemestreRegistroNotas()
        {
            strSql = "select p.num_sec num_sec_paralelo, m.sigla, m.nombre materia, p.numero_paralelo paralelo,   " +
                    "per.ap_paterno||' '||per.ap_materno||' '||per.nombres docente, i.inscritos,  " +
                    "p.estado_reg_notas, '' descripcion  " +
                    "from gen_subdepartamentos c, paralelos p, materias m, personas per,  " +
                    "(  " +
                        "select ap.num_sec_paralelo, count(ap.num_sec_persona) inscritos  " +
                    "	from paralelos p, alumnos_paralelos ap  " +
                    "	where ap.activo = 1  " +
                    "	and ap.estado in (1,6)  " +
                    "	and p.num_sec_semestre = " + _num_sec_semestre.ToString().Trim() + " " +
                    "	and p.cupo > 0  " +
                    "	and p.num_alumnos_inscritos > 0  " +
                    "	and ap.num_sec_paralelo = p.num_sec  " +
                    "	group by ap.num_sec_paralelo  " +
                    ") i  " +
                    "where c.tipo in (4,5) " +
                    "and p.cupo > 0  " +
                    "and p.num_alumnos_inscritos > 0  " +
                    "and p.num_sec_semestre = " + _num_sec_semestre.ToString().Trim() + " " +
                    "and c.num_sec_subdepartamento = " + _num_sec_subdepartamento.ToString().Trim() + " " +
                    "and p.num_sec_subdepartamento = c.num_sec_subdepartamento " +
                    "and p.num_sec_materia = m.num_sec  " +
                    "and p.num_sec_docente = per.num_sec  " +
                    "and i.num_sec_paralelo = p.num_sec  " +
                    "order by m.sigla, m.nombre, p.numero_paralelo";
            OracleBD.MostrarError = false;
            OracleBD.Sql = strSql;
            OracleBD.StrConexion = StrConexion;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }

        public DataTable DTParalelosEvaluacionContinua()
        {
            strSql = "select p.num_sec num_sec_paralelo, m.sigla, m.nombre materia, p.numero_paralelo paralelo,   " +
                    "per.ap_paterno||' '||per.ap_materno||' '||per.nombres docente, i.inscritos,  " +
                    "0 num_eval1, '' p1, 0 num_eval2, '' p2, 0 num_eval3, '' p3, 0 num_eval4, '' p4,  " +
                    "0 num_eval5, '' p5, 0 num_eval6, '' p6, 0 num_eval7, '' p7, 0 num_eval8, '' p8  " +
                    "from gen_subdepartamentos c, paralelos p, materias m, personas per,  " +
                    "(  " +
                        "select ap.num_sec_paralelo, count(ap.num_sec_persona) inscritos  " +
                    "	from paralelos p, alumnos_paralelos ap  " +
                    "	where ap.activo = 1  " +
                    "	and ap.estado in (1,6)  " +
                    "	and p.num_sec_semestre = " + _num_sec_semestre.ToString().Trim() + " " +
                    "	and p.cupo > 0  " +
                    "	and p.num_alumnos_inscritos > 0  " +
                    "	and ap.num_sec_paralelo = p.num_sec  " +
                    "	group by ap.num_sec_paralelo  " +
                    ")i  " +
                    "where c.tipo in (4,5)  " +
                    "and p.cupo > 0  " +
                    "and p.num_alumnos_inscritos > 0  " +
                    "and p.num_sec_semestre = " + _num_sec_semestre.ToString().Trim() + " " +
                    "and c.num_sec_subdepartamento = " + _num_sec_subdepartamento.ToString().Trim() + " " +
                    "and p.num_sec_subdepartamento = c.num_sec_subdepartamento " +
                    "and p.num_sec_materia = m.num_sec  " +
                    "and p.num_sec_docente = per.num_sec  " +
                    "and i.num_sec_paralelo = p.num_sec  " +
                    "order by m.sigla, m.nombre, p.numero_paralelo";
            OracleBD.MostrarError = false;
            OracleBD.Sql = strSql;
            OracleBD.StrConexion = StrConexion;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }

        public DataTable DTListadoMateriasSubDepartamentoSemestre(string strNSSemestre, string strNSSubDepartamento, string strCon)
        {
            strSql = "select a.num_sec_materia, count(a.numero_paralelo) nro_paralelos, Round(Avg(cupo),0) cupo " +
                    "from paralelos a, gen_subdepartamentos b " +
                    "where b.num_sec_subdepartamento = " + strNSSubDepartamento + " " +
                    "and a.num_sec_semestre = " + strNSSemestre + "  " +
                    "and a.cupo > 0 " +
                    "and a.tipo in (1,5) " +
                    "and a.num_sec_subdepartamento = b.num_sec_subdepartamento " +
                    "group by a.num_sec_materia";
            OracleBD.MostrarError = false;
            OracleBD.Sql = strSql;
            OracleBD.StrConexion = StrConexion;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }

        public DataTable DTListadoParalelosSemestreMateria(bool ConVacio)
        {
            strSql = "";
            if (ConVacio)
            {
                strSql = "select 0 num_sec_paralelo, 'Ninguno' numero_paralelo, '-' materia_origen " +
                        "from dual " +
                        "union ";
            }
            strSql += "select p.num_sec num_sec_paralelo, to_char(p.numero_paralelo) numero_paralelo, '-' materia_origen " +
                    "from paralelos p, materias m " +
                    "where p.num_sec_semestre = " + _num_sec_semestre.ToString().Trim() + " " +
                    "and p.num_sec_subdepartamento = " + _num_sec_subdepartamento.ToString().Trim() + " " +
                    "and p.num_sec_materia = " + _num_sec_materia.ToString().Trim() + " " +
                    "and p.tipo in (1,5) " +
                    "and p.num_sec_materia = m.num_sec " +
                    "order by numero_paralelo";
            OracleBD.Sql = strSql;
            OracleBD.StrConexion = StrConexion;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }

        public DataTable DTListadoParalelosSemestreMateriaAulas()
        {
            strSql = "select p.num_sec num_sec_paralelo, p.numero_paralelo, p.num_sec_docente, " +
                    "per.ap_paterno||' '||per.ap_materno||' '||per.nombres docente, " +
                    "0 num_sec_aula, 0 hora_inicio, 0 hora_fin, '' horario,  " +
                    "p.operaciones_internet, dom1.descripcion tipo_paralelo, '-' asignado " +
                    "from paralelos p, materias m, personas per, dominios dom1 " +
                    "where p.num_sec_semestre = " + _num_sec_semestre.ToString().Trim() + " " +
                    "and p.num_sec_subdepartamento = " + _num_sec_subdepartamento.ToString().Trim() + " " +
                    "and p.num_sec_materia = " + _num_sec_materia.ToString().Trim() + " " +
                    "and p.tipo in (1,5) " +
                    "and p.cupo > 0 " +
                    "and p.operaciones_internet <> 4 " +
                    "and dom1.dominio = 'OPER_INTERNET' " +
                    "and dom1.valor = p.operaciones_internet " +
                    "and p.num_sec_materia = m.num_sec " +
                    "and per.num_sec = p.num_sec_docente " +
                    "order by p.numero_paralelo";
            OracleBD.Sql = strSql;
            OracleBD.StrConexion = StrConexion;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }

        #endregion
    }
}


