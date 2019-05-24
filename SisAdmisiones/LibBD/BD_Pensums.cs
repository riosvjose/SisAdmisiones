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
    // Descripción: Clase referente a la tabla PENSUMS

    public class BD_Pensums : iBD_Tablas
    {
        #region Variables Locales

        GEN_OracleBD OracleBD = new GEN_OracleBD();
        GEN_Mensajes libMensajes = new GEN_Mensajes();
        GEN_Cadenas libCadenas = new GEN_Cadenas();
        private string strSql = string.Empty;

        #endregion

        #region Atributos

        // Campos de la tabla PENSUMS
        private long _num_sec = 0;
        private long _num_sec_carrera = 0;
        private long _num_sec_subdepartamento = 0;
        private string _descripcion = string.Empty;
        private string _resumido = string.Empty;
        private long _num_sec_semestre_creacion = 0;
        private short _activo = 0;
        private short _num_mats_obligadas = 0;
        private short _num_mats_complementarias = 0;

        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        // Definicion GET y SET de los campos de la tabla PENSUMS
        public long NumSec { get { return _num_sec; } set { _num_sec = value; } }
        public long NumSecCarrera { get { return _num_sec_carrera; } set { _num_sec_carrera = value; } }
        public string Descripcion { get { return _descripcion; } set { _descripcion = value; } }
        public string Resumido { get { return _resumido; } set { _resumido = value; } }
        public long NumSecSemestreCreacion { get { return _num_sec_semestre_creacion; } set { _num_sec_semestre_creacion = value; } }
        public short Activo { get { return _activo; } set { _activo = value; } }
        public short NumMatsObligadas { get { return _num_mats_obligadas; } set { _num_mats_obligadas = value; } }
        public short NumMatsComplementarias { get { return _num_mats_complementarias; } set { _num_mats_complementarias = value; } }
        public long NumSecSubDepartamento { get { return _num_sec_subdepartamento; } set { _num_sec_subdepartamento = value; } }

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

        // Definición del contructor de la clase PENSUMS
        public BD_Pensums()
        {
            _num_sec = 0;
            _num_sec_carrera = 0;
            _descripcion = string.Empty;
            _resumido = string.Empty;
            _num_sec_semestre_creacion = 0;
            _activo = 0;
            _num_mats_obligadas = 0;
            _num_mats_complementarias = 0;
            _num_sec_subdepartamento = 0;

            _mensaje = string.Empty;
            _strconexion = string.Empty;
        }

        #endregion

        #region Metodos iBD_Tablas

        // Método para insertar un dato en la tabla PENSUMS
        public bool Insertar()
        {
            bool OperacionCorrecta = false;
            return OperacionCorrecta;
        }

        // Método para MODIFICAR un dato en la tabla PENSUMS
        public bool Modificar()
        {
            bool OperacionCorrecta = false;
            return OperacionCorrecta;
        }

        // Método para ELIMINAR un dato en la tabla PENSUMS
        public bool Borrar()
        {
            bool OperacionCorrecta = false;
            return OperacionCorrecta;
        }

        // Método para VER un dato en la tabla PENSUMS
        public bool Ver()
        {
            bool OperacionCorrecta = false;
            return OperacionCorrecta;
        }

        #endregion

        #region Otros Métodos
        public string Query_DropDownList1(string strNSSubdepto)
        {
            string strSql = string.Empty;
            strSql = "select a.num_sec, decode(a.activo, 1, a.resumido||' [ACTIVO]', a.resumido) pensum, b.fecha_inicio ";
            strSql += " from pensums a, semestres b ";
            strSql += " where a.num_sec_subdepartamento = " + strNSSubdepto;
            strSql += " and a.num_sec_semestre_creacion = b.num_sec ";
            strSql += " order by fecha_inicio desc, pensum";
            return strSql;
        }

        #endregion

        #region Procedimientos y Funciones Publicos

        public string PensumActivoCarrera(string NSCarrera)
        {
            strSql = "select num_sec " +
                    "from pensums " +
                    "where activo = 1 " +
                    "and num_sec_carrera = " + NSCarrera;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            if (OracleBD.DataTable.Rows.Count == 0)
            {
                return "0";
            }
            else
            {
                return OracleBD.DataTable.Rows[0][0].ToString();
            }
        }

        public DataTable DTListadoPensumsCarrera()
        {
            strSql = "select p.num_sec, p.descripcion " +
                     "from pensums p, semestres s " +
                     "where p.num_sec_subdepartamento = " + _num_sec_subdepartamento.ToString().Trim() + " " +
                     "and p.num_sec_semestre_creacion = s.num_sec " +
                     "order by s.fecha_inicio desc";
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }

        public Int64 VerPensumMateria(string NSCarrera, string NSSemestre, string NSMateria, string strCon, ref int NumCreditos)
        {
            strSql = " select distinct a.num_sec, a.activo, a.num_sec_carrera, c.num_creditos_actual, c.ciclo, c.nivel, " +
                    " decode(b.num_sec_pensum, a.num_sec, 1, 2) car_sem, d.fecha_inicio" +
                    " from pensums a, pensums_materias c, semestres d, " +
                    " (select * from carreras_semestres" +
                    " Where num_sec_carrera = " + NSCarrera +
                    " and num_sec_semestre = " + NSSemestre + " ) b" +
                    " Where a.num_sec_carrera = " + NSCarrera +
                    " and a.num_sec_carrera = b.num_sec_carrera(+)" +
                    " and c.num_sec_materia = " + NSMateria +
                    " and c.activo = 1" +
                    " and c.tipo_materia in (1,2)" +
                    " and c.num_sec_pensum = a.num_sec " +
                    " and a.num_sec_semestre_creacion = d.num_sec" +
                    " order by car_sem, activo, d.fecha_inicio desc";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();

            if (OracleBD.DataTable.Rows.Count == 0)
            {
                NumCreditos = 0;
                return 0;
            }
            else
            {
                NumCreditos = Convert.ToInt16(OracleBD.DataTable.Rows[0]["num_creditos_actual"]);
                return Convert.ToInt64(OracleBD.DataTable.Rows[0]["num_sec"]);
            }
        }

        public string VerPrereqMateria(string NSCarrera, string NSMateria, string NSPensum, string strCon, string CaracterSeparacion)
        {
            int i;
            string PreReq = "";
            strSql = "select a.num_sec_materia_prereq, c.sigla||' '||c.nombre materia" +
                    " from prerequisitos a, pensums b, materias c" +
                    " where ";
            if (NSPensum == "0")
            {
                strSql += " b.ACTIVO = 1";
            }
            else
            {
                strSql += " b.num_sec = " + NSPensum;
            }
            strSql += " and b.num_sec_carrera = " + NSCarrera +
                    " and a.num_sec_materia = " + NSMateria +
                    " and b.num_sec = a.num_sec_pensum" +
                    " and a.num_sec_materia_prereq = c.num_sec" +
                    " order by nombre";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();

            if (OracleBD.DataTable.Rows.Count == 0)
            {
                return "";
            }
            else
            {
                for (i = 0; i < OracleBD.DataTable.Rows.Count; i++)
                {
                    if (PreReq != "")
                    {
                        PreReq += CaracterSeparacion;
                    }
                    PreReq += OracleBD.DataTable.Rows[i]["materia"].ToString().Trim();
                }
            }
            return PreReq;
        }

        public DataTable DTMateriasPensum(string strNSPensum, string strNSPersona, string strNotaAPR, string strCon)
        {
            DataTable dtMateriasCursadas;
            strSql = "select a.ciclo, a.nivel, a.num_sec_materia, a.materia, a.num_sec_materia_equivalente,  " +
                    "b.semestre, b.materia_cursada, b.num_creditos, b.nota nota_final, b.num_sec_materia num_sec_materia_cursada  " +
                    "from   " +
                    "(  " +
                        "select pm.ciclo, pm.nivel, pm.num_sec_materia, m.nombre||' ('||m.sigla||')' materia,   " +
                    "	nvl(me.num_sec_materia_equivalente,0) num_sec_materia_equivalente  " +
                    "	from pensums_materias pm, materias m,  " +
                    "	(  " +
                            "select e.num_sec_materia, e.num_sec_materia_equivalente  " +
                    "		from equivalencias e  " +
                    "		where e.num_sec_pensum = " + strNSPensum + " " +
                    "	) me  " +
                    "	where pm.num_sec_pensum = " + strNSPensum + " " +
                    "	and pm.activo = 1  " +
                    "	and pm.nivel <> 99  " +
                    "	and pm.num_sec_materia = m.num_sec  " +
                    "	and pm.num_sec_materia = me.num_sec_materia(+)  " +
                    ")a,  " +
                    "(  " +
                        "select s.resumido semestre, p.num_sec_materia, m.nombre||' ('||m.sigla||')' materia_cursada, p.num_creditos, nf.nota  " +
                    "	from paralelos p, gen_subdepartamentos c, materias m, semestres s, alumnos_paralelos ap, notas_finales nf  " +
                    "	where ap.activo = 1  " +
                    "	and ap.estado = 1  " +
                    "	and ap.num_sec_persona = " + strNSPersona + " " +
                    "	and p.tipo not in (6,7,8)  " +
                    "	and (nf.nota >= " + strNotaAPR + " and nf.nota <= 101)  " +
                    "	and nf.activo = 1  " +
                    "	and c.tipo in (4,5)  " +
                    "	and p.num_sec_subdepartamento = c.num_sec_subdepartamento " +
                    "	and p.num_sec_materia = m.num_sec  " +
                    "	and p.num_sec_semestre = s.num_sec  " +
                    "	and ap.num_sec_paralelo = p.num_sec  " +
                    "	and nf.num_sec_paralelo = ap.num_sec_paralelo  " +
                    "	and nf.num_sec_persona = ap.num_sec_persona  " +
                    ") b  " +
                    "where a.num_sec_materia = b.num_sec_materia(+)  " +
                    "order by a.ciclo, a.nivel, a.materia";
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dtMateriasCursadas = OracleBD.DataTable;
            BorrarMateriasDuplicadas(ref dtMateriasCursadas);
            VerificarEquivalencias(strNSPersona, strNotaAPR, ref dtMateriasCursadas);
            VerificarConvalidacionesHomologaciones(strNSPersona, strNotaAPR, ref dtMateriasCursadas);
            VerificarOtrasRegionales(strNSPersona, strNotaAPR, ref dtMateriasCursadas);
            EliminarMateriasVacias(ref dtMateriasCursadas);
            return dtMateriasCursadas;
        }

        public DataTable DTMateriasReligiosas(string strNSPersona)
        {
            strSql = "select s.resumido semestre, p.num_sec_materia, m.nombre||' ('||m.sigla||')' materia_cursada, p.num_creditos,  " +
                    "nf.nota nota_final  " +
                    "from paralelos p, gen_subdepartamentos c, materias m, semestres s, alumnos_paralelos ap, notas_finales nf,  " +
                    "(  " +
                        "select pm.num_sec_materia  " +
                    "	from pensums p, carreras c, pensums_materias pm  " +
                    "	where c.resumido = 'REL'  " +
                    "	and c.num_sec = p.num_sec_carrera  " +
                    "	and pm.num_sec_pensum = p.num_sec  " +
                    "	union  " +
                    "	select num_sec nom_sec_materia  " +
                    "	from materias  " +
                    "	where sigla like 'REL%'  " +
                    "	or sigla like 'TEO%'  " +
                    ") rel  " +
                    "where ap.activo = 1  " +
                    "and ap.estado = 1  " +
                    "and ap.num_sec_persona = " + strNSPersona + " " +
                    "and p.tipo in (1,5)  " +
                    "and (nf.nota >= 51 and nf.nota <= 101)  " +
                    "and nf.activo = 1  " +
                    "and c.tipo in (4 ,5) " +
                    "and p.num_sec_materia = rel.num_sec_materia  " +
                    "and p.num_sec_subdepartamento = c.num_sec_subdepartamento " +
                    "and p.num_sec_materia = m.num_sec  " +
                    "and p.num_sec_semestre = s.num_sec  " +
                    "and ap.num_sec_paralelo = p.num_sec  " +
                    "and nf.num_sec_paralelo = ap.num_sec_paralelo  " +
                    "and nf.num_sec_persona = ap.num_sec_persona  " +
                    "union  " +
                    "select s.resumido semestre, num_sec_materia, nombre_mc||' ('||sigla_mc||')' materia_cursada, num_creditos, 0 nota_final  " +
                    "from convalidaciones c, semestres s  " +
                    "where num_sec_persona = " + strNSPersona + " " +
                    "and c.num_sec_semestre = s.num_sec  " +
                    "and num_sec_materia in  " +
                    "(  " +
                        "select pm.num_sec_materia  " +
                    "	from pensums p, gen_subdepartamentos c, pensums_materias pm  " +
                    "	where c.resumido = 'REL'  " +
                    "	and c.num_sec_subdepartamento = p.num_sec_subdepartamento " +
                    "	and pm.num_sec_pensum = p.num_sec  " +
                    "	union  " +
                    "	select num_sec nom_sec_materia  " +
                    "	from materias  " +
                    "	where sigla like 'REL%'  " +
                    "	or sigla like 'TEO%'  " +
                    ")  " +
                    "union  " +
                    "select s.resumido semestre, num_sec_materia_conv num_sec_materia, nombre_materia||' ('||sigla_materia materia_cursada, num_creditos, 0 nota_final  " +
                    "from notas_regionales nr, semestres s  " +
                    "where num_sec_persona = " + strNSPersona + " " +
                    "and nr.num_sec_semestre = s.num_sec  " +
                    "and num_sec_materia_conv in  " +
                    "(  " +
                        "select pm.num_sec_materia  " +
                    "	from pensums p, gen_subdepartamentos c, pensums_materias pm  " +
                    "	where c.resumido = 'REL'  " +
                    "	and c.num_sec_subdepartamento = p.num_sec_subdepartamento " +
                    "	and pm.num_sec_pensum = p.num_sec  " +
                    "	union  " +
                    "	select num_sec nom_sec_materia  " +
                    "	from materias  " +
                    "	where sigla like 'REL%'  " +
                    "	or sigla like 'TEO%'  " +
                    ")";
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }

        public DataTable DTMateriasIdiomas(string strNSPersona, string strNotaAPR, string strCon)
        {
            strSql = "select s.resumido semestre, p.num_sec_materia, m.nombre||' ('||m.sigla||')' materia_cursada, p.num_creditos, nf.nota nota_final  " +
                    "from paralelos p, gen_subdepartamentos c, materias m, semestres s, alumnos_paralelos ap, notas_finales nf  " +
                    "where ap.activo = 1  " +
                    "and ap.estado = 1  " +
                    "and ap.num_sec_persona = " + strNSPersona + " " +
                    "and p.tipo = 2  " +
                    "and (nf.nota >= " + strNotaAPR + " and nf.nota <= 101)  " +
                    "and nf.activo = 1  " +
                    "and c.tipo in (4,5) " +
                    "and p.num_sec_subdepartamento = c.num_sec_subdepartamento " +
                    "and p.num_sec_materia = m.num_sec  " +
                    "and p.num_sec_semestre = s.num_sec  " +
                    "and ap.num_sec_paralelo = p.num_sec  " +
                    "and nf.num_sec_paralelo = ap.num_sec_paralelo  " +
                    "and nf.num_sec_persona = ap.num_sec_persona  " +
                    "union  " +
                    "select s.resumido semestre, p.num_sec_materia, m.nombre||' ('||m.sigla||')' materia_cursada, p.num_creditos, nf.nota nota_final  " +
                    "from paralelos p, gen_subdepartamentos c, materias m, semestres s, alumnos_paralelos ap, notas_finales nf  " +
                    "where ap.activo = 1  " +
                    "and ap.estado = 1  " +
                    "and ap.num_sec_persona = " + strNSPersona + " " +
                    "and p.tipo in (1,5)  " +
                    "and (nf.nota >= " + strNotaAPR + " and nf.nota <= 101)  " +
                    "and nf.activo = 1  " +
                    "and c.tipo in (4 ,5) " +
                    "and (m.sigla like 'IDM%' or m.nombre like '%IDIOMA%')  " +
                    "and p.num_sec_subdepartamento = c.num_sec_subdepartamento " +
                    "and p.num_sec_materia = m.num_sec  " +
                    "and p.num_sec_semestre = s.num_sec  " +
                    "and ap.num_sec_paralelo = p.num_sec  " +
                    "and nf.num_sec_paralelo = ap.num_sec_paralelo  " +
                    "and nf.num_sec_persona = ap.num_sec_persona  " +
                    "union  " +
                    "select s.resumido semestre, num_sec_materia, nombre_mc||' ('||sigla_mc||')' materia_cursada, num_creditos, 0 nota_final  " +
                    "from convalidaciones c, semestres s  " +
                    "where num_sec_persona = " + strNSPersona + " " +
                    "and c.num_sec_semestre = s.num_sec  " +
                    "and num_sec_materia in  " +
                    "(  " +
                        "select num_sec  " +
                    "	from materias  " +
                    "	where (sigla like 'IDM%' or nombre like '%IDIOMA%')  " +
                    ")  " +
                    "union  " +
                    "select s.resumido semestre, num_sec_materia_conv num_sec_materia, nombre_materia||' ('||sigla_materia materia_cursada, num_creditos, 0 nota_final  " +
                    "from notas_regionales nr, semestres s  " +
                    "where num_sec_persona = " + strNSPersona + " " +
                    "and nr.num_sec_semestre = s.num_sec  " +
                    "and num_sec_materia_conv in  " +
                    "(  " +
                        "select num_sec  " +
                    "	from materias  " +
                    "	where (sigla like 'IDM%' or nombre like '%IDIOMA%')  " +
                    ")";
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }

        #endregion

        #region Procedimientos y Funciones Privados

        private void BorrarMateriasDuplicadas(ref DataTable dtDatos)
        {
            for (int i = 0; i < dtDatos.Rows.Count - 1; i++)
            {
                if (dtDatos.Rows[i][2].ToString().Trim() == dtDatos.Rows[i + 1][2].ToString().Trim())
                {
                    if (dtDatos.Rows[i][5] != null)
                    {
                        dtDatos.Rows[i].Delete();
                    }
                }
            }
            dtDatos.AcceptChanges();
        }

        private void VerificarEquivalencias(string strNSPersona, string strNotaAPR, ref DataTable dtDatos)
        {
            for (int i = 0; i < dtDatos.Rows.Count; i++)
            {
                if (dtDatos.Rows[i][5] == null)
                {
                    strSql = "select s.resumido semestre, p.num_sec_materia, m.nombre||' ('||m.sigla||')' materia_cursada, p.num_creditos, nf.nota  " +
                            "from paralelos p, gen_subdepartamentos c, materias m, semestres s, alumnos_paralelos ap, notas_finales nf  " +
                            "where m.num_sec = " + dtDatos.Rows[i][4].ToString().Trim() + " " +
                            "and ap.activo = 1  " +
                            "and ap.estado = 1  " +
                            "and ap.num_sec_persona = " + strNSPersona + " " +
                            "and p.tipo in (1,5)  " +
                            "and (nf.nota >= " + strNotaAPR + " and nf.nota <= 101)  " +
                            "and nf.activo = 1  " +
                            "and c.tipo in (4,5) " +
                            "and p.num_sec_subdepartamento = c.num_sec_subdepartamento " +
                            "and p.num_sec_materia = m.num_sec  " +
                            "and p.num_sec_semestre = s.num_sec  " +
                            "and ap.num_sec_paralelo = p.num_sec  " +
                            "and nf.num_sec_paralelo = ap.num_sec_paralelo  " +
                            "and nf.num_sec_persona = ap.num_sec_persona";
                    OracleBD.StrConexion = _strconexion;
                    OracleBD.Sql = strSql;
                    OracleBD.sqlDataTable();
                    if (OracleBD.DataTable.Rows.Count > 0)
                    {
                        dtDatos.Rows[i][5] = OracleBD.DataTable.Rows[0][0];
                        dtDatos.Rows[i][2] = OracleBD.DataTable.Rows[0][1];
                        dtDatos.Rows[i][6] = OracleBD.DataTable.Rows[0][2];
                        dtDatos.Rows[i][7] = OracleBD.DataTable.Rows[0][3];
                        dtDatos.Rows[i][8] = OracleBD.DataTable.Rows[0][4];
                    }
                }
            }
        }

        private void VerificarConvalidacionesHomologaciones(string strNSPersona, string strNotaAPR, ref DataTable dtDatos)
        {
            DataTable dt;
            for (int i = 0; i < dtDatos.Rows.Count; i++)
            {
                if (dtDatos.Rows[i][5] == null)
                {
                    strSql = "select c.num_sec_materia, s.resumido, m.nombre||' ('||m.sigla||')' materia, c.num_creditos,  c.num_sec_materia_mc " +
                            "from convalidaciones c, semestres s, materias m " +
                            "where c.num_sec_persona = " + strNSPersona + " " +
                            "and c.num_sec_materia in (" + dtDatos.Rows[i][2].ToString().Trim() + ", " + dtDatos.Rows[i][4].ToString().Trim() + ") " +
                            "and c.num_sec_semestre = s.num_sec " +
                            "and m.num_sec = c.num_sec_materia_mc";
                    OracleBD.StrConexion = _strconexion;
                    OracleBD.Sql = strSql;
                    OracleBD.sqlDataTable();
                    dt = OracleBD.DataTable;
                    if (dt.Rows.Count > 0)
                    {
                        dtDatos.Rows[i][5] = dt.Rows[0][1];
                        dtDatos.Rows[i][2] = dt.Rows[0][0];
                        dtDatos.Rows[i][6] = dt.Rows[0][2];
                        dtDatos.Rows[i][7] = dt.Rows[0][3];
                        if (dt.Rows[0][4] == null)
                        {
                            strSql = "select s.resumido semestre, p.num_sec_materia, m.nombre||' ('||m.sigla||')' materia_cursada, p.num_creditos, nf.nota  " +
                                    "from paralelos p, gen_subdepartamentos c, materias m, semestres s, alumnos_paralelos ap, notas_finales nf  " +
                                    "where ap.activo = 1  " +
                                    "and ap.estado = 1  " +
                                    "and ap.num_sec_persona = " + strNSPersona + " " +
                                    "and p.tipo in (1,5)  " +
                                    "and (nf.nota >= " + strNotaAPR + " and nf.nota <= 101)  " +
                                    "and nf.activo = 1  " +
                                    "and c.tipo in (4 ,5) " +
                                    "and m.num_sec = " + dt.Rows[0][4].ToString().Trim() + " " +
                                    "and p.num_sec_subdepartamento = c.num_sec_subdepartamento " +
                                    "and p.num_sec_materia = m.num_sec  " +
                                    "and p.num_sec_semestre = s.num_sec  " +
                                    "and ap.num_sec_paralelo = p.num_sec  " +
                                    "and nf.num_sec_paralelo = ap.num_sec_paralelo " +
                                    "and nf.num_sec_persona = ap.num_sec_persona";
                            OracleBD.StrConexion = _strconexion;
                            OracleBD.Sql = strSql;
                            OracleBD.sqlDataTable();
                            if (OracleBD.DataTable.Rows.Count > 0)
                            {
                                dtDatos.Rows[i][8] = OracleBD.DataTable.Rows[0][4];
                            }
                        }
                    }
                }
            }
        }

        private void VerificarOtrasRegionales(string strNSPersona, string strNotaAPR, ref DataTable dtDatos)
        {
            for (int i = 0; i < dtDatos.Rows.Count; i++)
            {
                if (dtDatos.Rows[i][5] == null)
                {
                    strSql = "select num_sec_materia_conv, num_sec_semestre, nombre_materia||' ('||sigla_materia||')' materia, " +
                            "nr.num_creditos, nr.nota " +
                            "from notas_regionales nr " +
                            "where num_sec_persona = " + strNSPersona + " " +
                            "and num_sec_materia_conv in (" + dtDatos.Rows[i][2].ToString().Trim() + ", " + dtDatos.Rows[i][4].ToString().Trim() + ")";
                    OracleBD.StrConexion = _strconexion;
                    OracleBD.Sql = strSql;
                    OracleBD.sqlDataTable();
                    if (OracleBD.DataTable.Rows.Count > 0)
                    {
                        dtDatos.Rows[i][5] = OracleBD.DataTable.Rows[0][1];
                        dtDatos.Rows[i][6] = OracleBD.DataTable.Rows[0][2];
                        dtDatos.Rows[i][7] = OracleBD.DataTable.Rows[0][3];
                        dtDatos.Rows[i][8] = OracleBD.DataTable.Rows[0][4];
                    }
                }
            }
        }

        private void EliminarMateriasVacias(ref DataTable dtDatos)
        {
            for (int i = 1; i < dtDatos.Rows.Count - 1; i++)
            {
                if (dtDatos.Rows[i][5] == null)
                {
                    if (dtDatos.Rows[i][2].ToString().Trim() == dtDatos.Rows[i - 1][2].ToString().Trim())
                    {
                        dtDatos.Rows[i][6] = "-1";
                    }
                    else
                    {
                        if (dtDatos.Rows[i][2].ToString().Trim() == dtDatos.Rows[i + 1][2].ToString().Trim())
                        {
                            dtDatos.Rows[i][6] = "-1";
                        }
                    }
                }
            }
            for (int i = 0; i < dtDatos.Rows.Count - 1; i++)
            {
                if (dtDatos.Rows[i][5] != null)
                {
                    if (dtDatos.Rows[i][5].ToString().Trim() == dtDatos.Rows[i + 1][5].ToString().Trim() &&
                        dtDatos.Rows[i][6].ToString().Trim() == dtDatos.Rows[i + 1][6].ToString().Trim() &&
                        dtDatos.Rows[i][7].ToString().Trim() == dtDatos.Rows[i + 1][7].ToString().Trim() &&
                        dtDatos.Rows[i][8].ToString().Trim() == dtDatos.Rows[i + 1][8].ToString().Trim())
                    {
                        dtDatos.Rows[i][6] = "-1";
                    }
                }
            }
            for (int i = 0; i < dtDatos.Rows.Count; i++)
            {
                if (dtDatos.Rows[i][6].ToString().Trim() == "-1")
                {
                    dtDatos.Rows[i].Delete();
                }
            }
            dtDatos.AcceptChanges();
        }
        public DataTable DTPensumsCarreras()
        {
            strSql= "SELECT p.num_sec AS num_sec_pensum, p.descripcion||' '||Decode(p.activo,1,'(Activo)','') as descripcion, s.fecha_inicio "+
                " FROM pensums p, semestres s "+
                " WHERE p.num_sec_semestre_creacion = s.num_sec" +
                " AND p.num_sec_subdepartamento =" +_num_sec_subdepartamento+
                " ORDER BY s.fecha_inicio desc";
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }
    }
        #endregion
}