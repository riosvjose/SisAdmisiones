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
    // Descripción: Clase referente a la tabla ALUMNOS_PARALELOS

    public class BD_Alumnos_Paralelos : iBD_Tablas
    {
        #region Variables Locales

        GEN_OracleBD OracleBD = new GEN_OracleBD();
        GEN_Mensajes libMensajes = new GEN_Mensajes();
        GEN_Cadenas libCadenas = new GEN_Cadenas();
        private string strSql = string.Empty;

        #endregion

        #region Atributos

        // Campos de la tabla ALUMNOS_PARALELOS
        private long _num_sec_persona = 0;  
        private long _num_sec_paralelo = 0; 
        private string _fecha_registro = string.Empty;   
        private short _estado = 0;           
        private short _actual = 0;           
        private short _activo = 0;           
        private string _codigo_usuario = string.Empty;   
        private long _num_sec_tramite = 0;  
        private short _deuda = 0;            
        private short _salto_prereq = 0;     
        private long _num_documento = 0;    
        private string _observacion = string.Empty;      
        private string _condiciones_insc = string.Empty;
        private decimal _axNumSeg = 0;
        private string _auxDeuda = string.Empty;


        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        // Definicion GET y SET de los campos de la tabla ALUMNOS_PARALELOS
        public long NumSecPersona
        {
            get { return _num_sec_persona; }
            set { _num_sec_persona = value; }
        }
        public long NumSecParalelo
        {
            get { return _num_sec_paralelo; }
            set { _num_sec_paralelo = value; }
        }
        public string FechaRegistro
        {
            get { return _fecha_registro; }
            set { _fecha_registro = value; }
        }
        public short Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        public short Actual
        {
            get { return _actual; }
            set { _actual = value; }
        }
        public short Activo
        {
            get { return _activo; }
            set { _activo = value; }
        }
        public string CodigoUsuario
        {
            get { return _codigo_usuario; }
            set { _codigo_usuario = value; }
        }
        public long NumSecTramite
        {
            get { return _num_sec_tramite; }
            set { _num_sec_tramite = value; }
        }
        public short Deuda
        {
            get { return _deuda; }
            set { _deuda = value; }
        }
        public short SaltoPrereq
        {
            get { return _salto_prereq; }
            set { _salto_prereq = value; }
        }
        public long NumDocumento
        {
            get { return _num_documento; }
            set { _num_documento = value; }
        }
        public string Observacion
        {
            get { return _observacion; }
            set { _observacion = value; }
        }
        public string CondicionesInsc
        {
            get { return _condiciones_insc; }
            set { _condiciones_insc = value; }
        }

        public decimal AxNumSeg
        {
            get { return _axNumSeg; }
            set { _axNumSeg = value; }
        }
        public string auxDeuda
        {
            get { return _auxDeuda; }
            set { _auxDeuda = value; }
        }
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

        // Definición del contructor de la clase ALUMNOS_PARALELOS
        public BD_Alumnos_Paralelos()
        {
            _num_sec_persona = 0;  
            _num_sec_paralelo = 0; 
            _fecha_registro = string.Empty;   
            _estado = 0;           
            _actual = 0;           
            _activo = 0;           
            _codigo_usuario = string.Empty;   
            _num_sec_tramite = 0;  
            _deuda = 0;            
            _salto_prereq = 0;     
            _num_documento = 0;    
            _observacion = string.Empty;      
            _condiciones_insc = string.Empty; 

            _mensaje = string.Empty;
            _strconexion = string.Empty;
        }

        #endregion

        #region Metodos iBD_Tablas

        // Método para insertar un dato en la tabla ALUMNOS_PARALELOS
        public bool Insertar()
        {
            bool OperacionCorrecta = false;

            strSql = "insert into alumnos_paralelos";
            strSql += " (num_sec_persona, num_sec_paralelo, fecha_registro,";
            strSql += " estado, actual, activo,";
            strSql += " codigo_usuario, num_sec_tramite, salto_prereq, num_documento, deuda, condiciones_insc, observacion)";
            strSql += " Values";
            strSql += " (" + _num_sec_persona + ", ";
            strSql += _num_sec_paralelo;
            strSql += ", sysdate+" + _axNumSeg;
            strSql += "," + _estado + ", 1, 1, ";
            strSql += "'" + _codigo_usuario + "', ";

            if (_num_sec_tramite > 0)
            {
                strSql += _num_sec_tramite + ", ";
            }
            else
            {
                strSql += "null, ";
            }
            strSql += _salto_prereq + ", ";
            strSql += _num_documento + ",";

            if (string.IsNullOrEmpty(_auxDeuda))
            {
                strSql += " null ,";
            }
            else
            {
                if (Convert.ToDecimal(_auxDeuda) > 0)
                {
                    strSql += _auxDeuda + " ,";
                }
                else
                {
                    strSql += " null,";
                }
            }

            if (_condiciones_insc.Trim().Length > 0)
            {
                strSql += "'" + _condiciones_insc + "', ";
            }
            else
            {
                strSql += " null, ";
            }

            if (_observacion.Trim().Length > 0)
            {
                strSql += "'" + _observacion + "' )";
            }
            else
            {
                strSql += " null )";
            }

            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();

            _mensaje = OracleBD.Mensaje;
            OperacionCorrecta = !OracleBD.Error;

            if (OracleBD.Error)
                _mensaje = "No fue posible insertar el dato. Se encontró un error al insertar en la tabla TRAMITES. " + _mensaje;

            return OperacionCorrecta;
        }

        // Método para MODIFICAR un dato en la tabla ALUMNOS_PARALELOS
        public bool Modificar()
        {
            bool OperacionCorrecta = false;
            return OperacionCorrecta;
        }

        // Método para ELIMINAR un dato en la tabla ALUMNOS_PARALELOS
        public bool Borrar()
        {
            bool OperacionCorrecta = false;
            return OperacionCorrecta;
        }

        // Método para VER un dato en la tabla ALUMNOS_PARALELOS
        public bool Ver()
        {
            bool Encontrado = false;
            return Encontrado;
        }

        #endregion

        #region Procedimientos y Funciones Publicos

        public decimal RevisaNumMateriasInscritoSem(string NSPersona, string NSSemestre)
        {
            strSql = "select count(0) num_mats " +
                     "from alumnos_paralelos a, paralelos b, gen_subdepartamentos c " +
                     "where b.num_sec_semestre = " + NSSemestre + " " +
                     "and b.tipo in (1,5) " +
                     "and c.tipo in (4, 5) " +
                     "and a.num_sec_persona = " + NSPersona + " " +
                     "and a.activo = 1 " +
                     "and a.estado = 1 " +
                     "and a.num_sec_paralelo = b.num_sec  " +
                     "and c.num_sec_subdepartamento = b.num_sec_subdepartamento";

            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            if (OracleBD.DataTable.Rows.Count == 0)
            {
                return 0;
            }
            else
            {
                return (decimal)OracleBD.DataTable.Rows[0][0];
            }
        }
        public string Revisar_Suspension_Activa(string NSPersona, string NSSemestre, string strSemestre)
        {
            string strMensaje = "";
            strSql = "select distinct c.resumido, c.fecha_inicio " +
                    "from alumnos_paralelos a, paralelos b, semestres c " +
                    "where a.num_sec_persona = " + NSPersona + " " +
                    "and b.num_sec_semestre = " + NSSemestre + " " +
                    "and a.activo = 1 " +
                    "and a.estado = 6 " +
                    "and a.num_sec_paralelo = b.num_sec " +
                    "and b.num_sec_semestre = c.num_sec " +
                    "order by c.fecha_inicio desc";
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            if (OracleBD.DataTable.Rows.Count != 0)
            {
                strMensaje += strSemestre;
                strMensaje = "Tu inscripción en el semestre " + strMensaje +
                            " se encuentra suspendida en aplicación de las Condiciones generales para los estudiantes de la UCB. " +
                            "Para mayor información comunicarse con las oficinas de Tesorería a los teléfonos 2785152 – 2782818 – 2782222 internos 2196 y 2113.<br>";
            }
            else
            {
                strMensaje = "";
            }
            return strMensaje;
        }
        public DataTable ParalelosEvaluacionDocente(string NSSemestre, string NSPersona, string NSPLEncuesta)
        {
            strSql = "select p.num_sec, m.sigla||' - '||m.nombre materia " +
                    "from paralelos p, alumnos_paralelos ap, carreras c, materias m " +
                    "where ap.activo = 1 " +
                    "and ap.estado in (1,6) " +
                    "and c.interna <> 4 " +
                    "and p.tipo in (1,5) " +
                    "and p.num_sec_semestre = " + NSSemestre + " " +
                    "and ap.num_sec_persona = " + NSPersona + " " +
                    "and p.num_sec not in " +
                    "( " +
                    "	select num_sec_paralelo " +
                    "	from ed_tabulacion_encuestas " +
                    "	where num_sec_persona = " + NSPersona +" " +
                    "	and num_sec_plencuesta = " + NSPLEncuesta +" " +
                    "	and estado in (1,2) " +
                    ") " +
                    "and p.num_sec not in " +
                    "( " +
                    "   select num_sec_paralelo " +
                    "   from ed_paralelos_restringidos " +
                    "   where num_sec_plencuesta = " + NSPLEncuesta +" " +
                    "   and estado = 1 " +
                    ") " +
                    "and ap.num_sec_paralelo = p.num_sec " +
                    "and p.num_sec_carrera = c.num_sec " +
                    "and p.num_sec_materia = m.num_sec " +
                    "order by m.sigla, m.nombre";
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }
        public bool VerificarInscripcionParalelo(string NSPersona, string NSParalelo)
        {
            strSql = "select count(0) " +
                    "from paralelos p, alumnos_paralelos ap, semestres s, carreras c " +
                    "where ap.num_sec_persona = " + NSPersona + " " +
                    "and ap.num_sec_paralelo = " + NSParalelo + " " +
                    "and ap.activo = 1 " +
                    "and ap.estado in (1,6) " +
                    "and c.interna <> 4 " +
                    "and p.num_sec_semestre = s.num_sec " +
                    "and p.num_sec_carrera = c.num_sec " +
                    "and ap.num_sec_paralelo = p.num_sec";
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            if (Convert.ToInt16(OracleBD.DataTable.Rows[0][0]) == 0)
                return false;
            else
                return true;
        }
        public DataTable DatosParalelo(string NSParalelo)
        {
            strSql = "select m.sigla, m.nombre materia, per.ap_paterno||' '||per.ap_materno||' '||per.nombres docente, " +
                    "p.num_creditos " +
                    "from paralelos p, materias m, personas per " +
                    "where p.num_sec = " + NSParalelo + " " +
                    "and p.num_sec_materia = m.num_sec " +
                    "and p.num_sec_docente = per.num_sec";
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }
        public DataTable ParalelosInscritosSemestre(string NSSemestre)
        {
            string strSql;
            strSql = "select a.num_sec_paralelo, c.resumido depto, d.sigla, " +
                    "d.nombre materia, b.numero_paralelo par, b.num_creditos, " +
                    "e.ap_paterno||' '||e.ap_materno||' '||e.nombres docente, " +
                    "f.descripcion estado_str " +
                    "from alumnos_paralelos a, paralelos b, carreras c, " +
                    "materias d, personas e, dominios f " +
                    "where b.num_sec_semestre = " + NSSemestre + " " +
                    "and b.tipo in (1,5) " +
                    "and c.interna <> 4 " +
                    "and b.num_sec_carrera = c.num_sec " +
                    "and a.num_sec_persona = " + _num_sec_persona + "  " +
                    "and a.num_sec_paralelo = b.num_sec " +
                    "and a.activo = 1 " +
                    "and a.estado in (1,2) " +
                    "and b.num_sec_materia = d.num_sec " +
                    "and b.num_sec_docente = e.num_sec " +
                    "and f.dominio = 'ESTADO_ALU_PAR' " +
                    "and f.valor = a.estado " +
                    "order by depto, sigla, par";
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }

        /// <summary>
        /// Verifica si una determinada materia en un semestre esta inscrito para un determinado estudiante
        /// </summary>
        /// <param name="NSSemestre">NUM_SEC_SEMESTRE</param>
        /// <param name="NSMateria">NUM_SEC_MATERIA</param>
        /// <returns></returns>
        public bool VerificarMateriaInscritaSemestre(string NSSemestre, string NSMateria, string ModoAcademicoSACAD)
        {
            string strSql;
            strSql = "select a.num_sec_paralelo, c.resumido depto, d.sigla, " +
                    "d.nombre materia, b.numero_paralelo par, b.num_creditos, " +
                    "e.ap_paterno||' '||e.ap_materno||' '||e.nombres docente, " +
                    "f.descripcion estado_str " +
                    "from alumnos_paralelos a, paralelos b, carreras c, " +
                    "materias d, personas e, dominios f " +
                    "where b.num_sec_semestre = " + NSSemestre + " " +
                    "and a.num_sec_persona = " + _num_sec_persona.ToString() + " " +
                    "and d.num_sec = " + NSMateria + " " +
                    "and b.tipo in (1,5) ";
            if (ModoAcademicoSACAD == "2")
                strSql += "and c.interna = 4 ";
            else
                strSql += "and c.interna <> 4 ";
            strSql += "and a.activo = 1 " +
                      "and a.estado in (1,2) " +
                      "and f.dominio = 'ESTADO_ALU_PAR' " +
                      "and b.num_sec_carrera = c.num_sec " +
                      "and a.num_sec_paralelo = b.num_sec " +
                      "and b.num_sec_materia = d.num_sec " +
                      "and b.num_sec_docente = e.num_sec " +
                      "and f.valor = a.estado " +
                      "order by depto, sigla, par";
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            if (OracleBD.DataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public decimal CuotaInscripciones(string NSSemestre)
        {
            strSql = "select nvl(sum(b.valor/5),0) " +
                     "from caja_definiciones_alumnos a, " +
                     "caja_tarifarios b, " +
                     "(select nvl(sum(b.num_creditos),0)  total " +
                     "from alumnos_paralelos a, paralelos b " +
                     "where a.num_sec_persona = " + _num_sec_persona + " " +
                     "and a.estado = 1 " +
                     "and a.activo = 1 " +
                     "and b.num_sec = a.num_sec_paralelo " +
                     "and b.num_sec_semestre = " + NSSemestre + ") c " +
                     "where a.num_sec_analitico = " + _num_sec_persona + " " +
                     "and a.num_sec_semestre =" + NSSemestre + " " +
                     "and b.num_sec_def_cred = a.num_sec_def_cred " +
                     "and b.num_sec_semestre = a.num_sec_semestre " +
                     "and b.num_creditos = c.total ";
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            if (OracleBD.DataTable.Rows.Count == 0)
                return 0;
            else
            {
                if (OracleBD.DataTable.Rows[0][0].ToString().Trim() == "")
                    return 0;
                else
                    return Convert.ToDecimal(OracleBD.DataTable.Rows[0][0]);
            }
        }
        public string VerEstadoParalelo()
        {
            strSql = "select ap.estado, dom1.descripcion str_estado " +
                    "from alumnos_paralelos ap, dominios dom1 " +
                    "where ap.num_sec_paralelo = " + _num_sec_paralelo.ToString() + " " +
                    "and ap.num_sec_persona = " + _num_sec_persona.ToString() + " " +
                    "and ap.actual = 1 " +
                    "and ap.activo = 1 " +
                    "and dom1.dominio = 'ESTADO_ALU_PAR' " +
                    "and dom1.valor = ap.estado";
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            if (OracleBD.DataTable.Rows.Count == 0)
                return "";
            else
            {
                if (OracleBD.DataTable.Rows[0][0].ToString().Trim() == "")
                    return "";
                else
                    return OracleBD.DataTable.Rows[0][1].ToString();
            }
        }
        public string VerificarSemestreEnCursoSuspendido()
        {
            string msj = string.Empty;
            strSql = "select distinct a.num_sec_paralelo, c.resumido sem " +
                     "from alumnos_paralelos a, paralelos b, semestres c " +
                     "where a.num_sec_persona = " + _num_sec_persona.ToString() + " " +
                     "and a.activo = 1 " +
                     "and a.estado in (6,7) " +
                     "and b.num_sec_semestre in " +
                     "( " +
                     "	select a.num_sec from semestres a  " +
                     "	where trunc(a.fecha_inicio)<=trunc(sysdate) " +
                     "	and trunc(a.fecha_fin)>=trunc(sysdate) " +
                     ") " +
                     "and a.num_sec_paralelo = b.num_sec " +
                     "and b.num_sec_semestre = c.num_sec";
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            if (OracleBD.DataTable.Rows.Count == 0)
                msj = "";
            else
            {
                msj = "Su inscripci&oacute;n del semestre " + OracleBD.DataTable.Rows[0][1].ToString() + " fue suspendida. Para mayor informaci&oacute;n comunicarse con Tesorer&iacute;a.";
            }
            return msj;
        }
        public bool RevisarEstudiantePostgrado()
        {
            strSql = "select count(0) num_mats " +
                     "from alumnos_paralelos a, paralelos b, gen_subdepartamentos c " +
                     "where a.num_sec_persona = " + _num_sec_persona.ToString().Trim() + " " +
                     "and a.activo = 1 " +
                     "and a.estado = 1 " +
                     "and c.tipo in (6) " +
                     "and a.num_sec_paralelo = b.num_sec " +
                     "and b.num_sec_subdepartamento = c.num_sec_subdepartamento";
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            if (OracleBD.DataTable.Rows.Count > 0)
            {
                if (OracleBD.DataTable.Rows[0][0].ToString().Trim() == "0")
                    return false;
                else
                    return true;
            }
            else
            {
                return false;
            }
        }

        public bool RevisarEstudiantePregrado()
        {
            strSql = "select count(0) num_mats " +
                     "from alumnos_paralelos a, paralelos b, gen_subdepartamentos c " +
                     "where a.num_sec_persona = " + _num_sec_persona.ToString().Trim() + " " +
                     "and a.activo = 1 " +
                     "and c.tipo in (4,5) " +
                     "and a.num_sec_paralelo = b.num_sec " +
                     "and b.num_sec_subdepartamento = c.num_sec_subdepartamento";
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            if (OracleBD.DataTable.Rows.Count > 0)
                if (OracleBD.DataTable.Rows[0][0].ToString().Trim() == "0")
                    return false;
                else
                    return true;
            else
                return false;
        }

        public bool RevisarEstudianteNuevoUltimosSemestres()
        {
            strSql = "select count(0) num_sems " +
                     "from semestres a " +
                     "where a.tipo = 1  " +
                     "and num_sec <> 0 " +
                     "and a.fecha_inicio >=  " +
                     "( " +
                     "	select min(d.fecha_inicio) " +
                     "	from alumnos_paralelos a, paralelos b, carreras c, semestres d  " +
                     "	where a.num_sec_persona = " + _num_sec_persona.ToString().Trim() + " " +
                     "	and a.activo = 1 " +
                     "	and a.estado in (1,4,5,6,7) " +
                     "	and a.num_sec_paralelo = b.num_sec " +
                     "	and c.interna <> 4 " +
                     "	and b.num_sec_carrera = c.num_sec " +
                     "	and b.num_sec_semestre = d.num_sec " +
                     ") " +
                     "and a.fecha_inicio <=  " +
                     "( " +
                     "	select fecha_inicio from semestres  " +
                     "	where activo = 1 " +
                     ") " +
                     "order by a.fecha_inicio desc";
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            if (OracleBD.DataTable.Rows.Count > 0)
            {
                if (Convert.ToInt16(OracleBD.DataTable.Rows[0][0].ToString().Trim()) > 2)
                    return false;
                else
                    return true;
            }
            else
            {
                return true;
            }
        }

        public int NumeroAlumnosInscritosParalelo()
        {
            strSql = "select count(0) inscritos " +
                     "from paralelos p, alumnos_paralelos ap " +
                     "where p.num_sec = " + _num_sec_paralelo.ToString().Trim() + " " +
                     "and ap.estado = 1 " +
                     "and ap.activo = 1 " +
                     "and ap.num_sec_paralelo = p.num_sec";
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            if (OracleBD.DataTable.Rows.Count > 0)
            {
                return Convert.ToInt16(OracleBD.DataTable.Rows[0][0].ToString().Trim());
            }
            else
            {
                return 0;
            }
        }

        public string VerEstadoInscripcion()
        {
            strSql = "select estado " +
                    "from alumnos_paralelos " +
                    "where num_sec_persona = " + _num_sec_persona.ToString().Trim() + " " +
                    "and num_sec_paralelo = " + _num_sec_paralelo.ToString().Trim() + " " +
                    "and activo = 1";
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable.Rows[0][0].ToString().Trim();
        }

        public DataTable ListadoParalelosPersona(string ModoAcad)
        {
            strSql = "select b.num_sec_semestre, b.num_sec_materia, e.resumido sem, c.resumido depto, d.sigla, d.nombre materia, b.numero_paralelo par  " +
                     "from   alumnos_paralelos a, paralelos b, gen_subdepartamentos c, materias d, semestres e  " +
                     "where  a.num_sec_persona = " + _num_sec_persona.ToString().Trim() + "  " +
                     "       and a.activo = 1  " +
                     "       and a.estado = 1  ";
            if (ModoAcad == "1")
                strSql += "       and c.tipo in (4,5) ";
            else
                strSql += "       and c.tipo in (6) ";
            strSql += "       and b.num_sec_subdepartamento = c.num_sec_subdepartamento " +
                     "       and a.num_sec_paralelo = b.num_sec  " +
                     "       and b.num_sec_materia = d.num_sec  " +
                     "       and b.num_sec_semestre = e.num_sec  " +
                     "order  by e.fecha_inicio, depto, sigla, par";
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }

        public DataTable DTListadoMatAPRCargaHoraria(string strNSPensum, string strTitulo, string strFirma, string strPie, string strFecha, string strCarrera, string strNombreEstudiante, string strCedulaIdentidad)
        {
            strSql = "select distinct '" + strTitulo + "' titulo, '" + strNombreEstudiante + "' estudiante, '" + strCedulaIdentidad + "' cedula_identidad,  " +
                    "'" + strCarrera + "' carrera, 'La Paz, " + strFecha + "' fecha, '" + strFirma + "' firma,  " +
                    "'" + strPie + "' pie, paralelos.num_sec_materia, alumnos_paralelos.num_sec_paralelo, semestres.fecha_inicio, gen_subdepartamentos.resumido depto,  " +
                    "gen_subdepartamentos.nombre departamento, sigla, materias.nombre materia,  " +
                    "decode(substr(semestres.resumido,1,1),'3','IN-'||substr(semestres.resumido,3),decode(substr(semestres.resumido,1,1),'4','V-'||substr(semestres.resumido,3),semestres.resumido)) sem,   " +
                    "semestres.descripcion semestre, paralelos.numero_paralelo paralelo, paralelos.tipo tipo_par, alumnos_paralelos.estado,  " +
                    "paralelos.num_creditos creditos, (paralelos.num_creditos-1) horas, semestres.tipo tipo_semestre,  " +
                    "decode(semestres.tipo, 1, paralelos.num_creditos-1, (paralelos.num_creditos-1)*5) horas_mes,  " +
                    "decode(semestres.tipo, 1, (paralelos.num_creditos-1)*4, ((paralelos.num_creditos-1)*5)*4) horas_mes1,  " +
                    "decode(semestres.tipo, 1, (paralelos.num_creditos-1), (paralelos.num_creditos-1)*5) horas_semana,  " +
                    "decode(semestres.tipo, 1, ((paralelos.num_creditos-1)*20), ((paralelos.num_creditos-1)*5)*4) horas_semestre,  " +
                    "nvl(notas_finales.nota, 0) nf, materias.sigla, 0 sw  " +
                    "from gen_subdepartamentos, paralelos, materias, semestres, alumnos_paralelos,   " +
                    "    (select notas.* , resumido resumido_periodo , numero_paralelo_efinal   " +
                    "    from notas_finales notas , paralelos_efinal , periodos_efinal  " +
                    "    where notas.num_sec_persona = " + _num_sec_persona.ToString().Trim() + " " +
                    "    and notas.activo in (1, 3)  " +
                    "    and (notas.nota >=51 and notas.nota<=100)  " +
                    "    and notas.num_sec_paralelo_ef = paralelos_efinal.num_sec  " +
                    "    and paralelos_efinal.num_sec_periodo_ef = periodos_efinal.num_sec  " +
                    "    ) notas_finales  " +
                    "where gen_subdepartamentos.num_sec_subdepartamento = paralelos.num_sec_subdepartamento " +
                    "and gen_subdepartamentos.tipo in (4,5) " +
                    "and materias.certificada = 1  " +
                    "and alumnos_paralelos.num_sec_persona = " + _num_sec_persona.ToString().Trim() + " " +
                    "and alumnos_paralelos.activo = 1  " +
                    "and alumnos_paralelos.estado = 1  " +
                    "and paralelos.num_creditos > 0  ";
            if (strNSPensum != "0")
            {
                strSql += "and paralelos.num_sec_materia in " +
                        "( " +
                        "	select num_sec_materia " +
                        "	from pensums_materias " +
                        "	where num_sec_pensum = " + strNSPensum + " " +
                        "	and activo = 1 " +
                        "	and nivel <> 99 " +
                        "	union " +
                        "	select num_sec_materia_equivalente " +
                        "	from equivalencias " +
                        "	where num_Sec_pensum = " + strNSPensum + " " +
                        "	union " +
                        "	select distinct pm.num_sec_materia  " +
                        "	from pensums p, carreras c, pensums_materias pm  " +
                        "	where c.resumido = 'REL'  " +
                        "	and c.num_sec = p.num_sec_carrera  " +
                        "	and pm.num_sec_pensum = p.num_sec  " +
                        "	union  " +
                        "	select distinct num_sec nom_sec_materia  " +
                        "	from materias  " +
                        "	where sigla like 'REL%'  " +
                        "	or sigla like 'TEO%' " +
                        "	union " +
                        "	select distinct num_sec " +
                        "	from materias " +
                        "	where (sigla like 'IDM%' or nombre like '%IDIOMA%') " +
                        ") ";
            }
            strSql += "and paralelos.num_sec_materia = materias.num_sec  " +
                    "and paralelos.num_sec_semestre = semestres.num_sec  " +
                    "and paralelos.num_sec = alumnos_paralelos.num_sec_paralelo  " +
                    "and alumnos_paralelos.num_sec_persona = notas_finales.num_sec_persona  " +
                    "and alumnos_paralelos.num_sec_paralelo = notas_finales.num_sec_paralelo  " +
                    "order by semestres.fecha_inicio, gen_subdepartamentos.nombre, materias.nombre";
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }      

        public string MateriasCursadosSuspendidas(string strEstados)
        {
            strSql = "select count(0) total " +
                    "from alumnos_paralelos ap, paralelos p, gen_subdepartamentos c " +
                    "where ap.num_sec_persona = " + _num_sec_persona.ToString().Trim() + " " +
                    "and ap.activo = 1 " +
                    "and estado in (" + strEstados + ") " +
                    "and c.tipo in (4,5) " +
                    "and p.num_sec_subdepartamento = c.num_sec_subdepartamento " +
                    "and p.num_sec = ap.num_sec_paralelo";
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            if (OracleBD.DataTable.Rows.Count == 0)
                return "0";
            else
                return OracleBD.DataTable.Rows[0][0].ToString().Trim();
        }

        public string ActualizarIngresoPregrado()
        {
            strSql = "update acad_ingresos_pregrado " +
                     "set activo = 2, usuario = user, fecha_registro = sysdate " +
                     "where num_sec_persona = " + _num_sec_persona.ToString().Trim() + " " +
                     "and activo = 1";
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSql();
            return OracleBD.Mensaje;
        }

        #endregion
    }
}