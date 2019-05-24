using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

using nsiBD_Interfaces;
using nsGEN_OracleBD;
using nsGEN;

namespace nsBD_PER
{

    // Creado por: Willy Tenorio Palza; Fecha: 19/04/2018
    // Ultima modificación:
    // Descripción: Clase referente a la tabla ASIGNACIONES

    public class BD_Asignaciones : iBD_Tablas
    {

        #region Librerias Externas

        SIS_GeneralesSistema Generales = new SIS_GeneralesSistema();

        #endregion

        #region Variables Locales

        GEN_OracleBD OracleBD = new GEN_OracleBD();
        private string strSql = string.Empty;

        #endregion

        #region Atributos

        // Campos de la tabla ASIGNACIONES
        private long _num_sec = 0;
        private long _num_sec_cargo = 0;
        private long _num_sec_persona = 0;
        private string _fecha_registro = string.Empty;
        private short _carga_horaria = 0;
        private string _fecha_asignacion = string.Empty;
        private short _documento = 0;
        private string _numero_contrato = string.Empty;
        private short _tipo_control_asistencia = 0;
        private short _moneda_salario = 0;
        private string _codigo_usuario = string.Empty;
        private short _tipo_retiro = 0;
        private string _fecha_retiro = string.Empty;
        private string _observacion = string.Empty;
        private long _num_sec_planilla = 0;
        private short _tipo_antiguedad = 0;
        private short _antiguedad_acumulada = 0;
        private short _nro_sueldos_anuales = 0;
        private string _aguinaldo = string.Empty;
        private short _bono = 0;
        private short _prioridad = 0;
        private short _categoria = 0;


        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        // Definicion GET y SET de los campos de la tabla ASIGNACIONES
        public long NumSec { get { return _num_sec; } set { _num_sec = value; } }
        public long NumSecCargo { get { return _num_sec_cargo; } set { _num_sec_cargo = value; } }
        public long NumSecPersona { get { return _num_sec_persona; } set { _num_sec_persona = value; } }
        public string FechaRegistro { get { return _fecha_registro; } set { _fecha_registro = value; } }
        public short CargaHoraria { get { return _carga_horaria; } set { _carga_horaria = value; } }
        public string FechaAsignacion { get { return _fecha_asignacion; } set { _fecha_asignacion = value; } }
        public short Documento { get { return _documento; } set { _documento = value; } }
        public string NumeroContrato { get { return _numero_contrato; } set { _numero_contrato = value; } }
        public short TipoControlAsistencia { get { return _tipo_control_asistencia; } set { _tipo_control_asistencia = value; } }
        public short MonedaSalario { get { return _moneda_salario; } set { _moneda_salario = value; } }
        public string CodigoUsuario { get { return _codigo_usuario; } set { _codigo_usuario = value; } }
        public short TipoRetiro { get { return _tipo_retiro; } set { _tipo_retiro = value; } }
        public string FechaRetiro { get { return _fecha_retiro; } set { _fecha_retiro = value; } }
        public string Observacion { get { return _observacion; } set { _observacion = value; } }
        public long NumSecPlanilla { get { return _num_sec_planilla; } set { _num_sec_planilla = value; } }
        public short TipoAntiguedad { get { return _tipo_antiguedad; } set { _tipo_antiguedad = value; } }
        public short AntiguedadAcumulada { get { return _antiguedad_acumulada; } set { _antiguedad_acumulada = value; } }
        public short NroSueldosAnuales { get { return _nro_sueldos_anuales; } set { _nro_sueldos_anuales = value; } }
        public string Aguinaldo { get { return _aguinaldo; } set { _aguinaldo = value; } }
        public short Bono { get { return _bono; } set { _bono = value; } }
        public short Prioridad { get { return _prioridad; } set { _prioridad = value; } }
        public short Categoria { get { return _categoria; } set { _categoria = value; } }

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

        // Definición del contructor de la clase ASIGNACIONES
        public BD_Asignaciones()
        {
            _num_sec = 0;
            _num_sec_cargo = 0;
            _num_sec_persona = 0;
            _fecha_registro = string.Empty;
            _carga_horaria = 0;
            _fecha_asignacion = string.Empty;
            _documento = 0;
            _numero_contrato = string.Empty;
            _tipo_control_asistencia = 0;
            _moneda_salario = 0;
            _codigo_usuario = string.Empty;
            _tipo_retiro = 0;
            _fecha_retiro = string.Empty;
            _observacion = string.Empty;
            _num_sec_planilla = 0;
            _tipo_antiguedad = 0;
            _antiguedad_acumulada = 0;
            _nro_sueldos_anuales = 0;
            _aguinaldo = string.Empty;
            _bono = 0;
            _prioridad = 0;
            _categoria = 0;

            _mensaje = string.Empty;
            _strconexion = string.Empty;
        }

        #endregion

        #region Metodos iBD_Tablas y Públicos

        // Método para insertar un dato en la tabla ASIGNACIONES
        public bool Insertar()
        {
            bool blOperacionCorrecta = false;
            strSql = "insert into ASIGNACIONES (  " +
                     "num_sec, " +
                     "num_sec_cargo, " +
                     "num_sec_persona, " +
                     "fecha_registro, " +
                     "carga_horaria, " +
                     "fecha_asignacion, " +
                     "documento, " +
                     "numero_contrato, " +
                     "tipo_control_asistencia, " +
                     "moneda_salario, " +
                     "codigo_usuario, " +
                     "tipo_retiro, " +
                     "fecha_retiro, " +
                     "observacion, " +
                     "num_sec_planilla, " +
                     "tipo_antiguedad, " +
                     "antiguedad_acumulada, " +
                     "nro_sueldos_anuales, " +
                     "aguinaldo, " +
                     "bono, " +
                     "prioridad, " +
                     "categoria " +
                     ") " +
                     "values " +
                     "( asignaciones_sec.nextval " +
                     _num_sec_cargo.ToString() + ", " +
                     _num_sec_persona.ToString() + ", " +
                     "'" + _fecha_registro + "', " +
                     _carga_horaria.ToString() + ", " +
                     "'" + _fecha_asignacion + "', " +
                     _documento.ToString() + ", " +
                     "'" + _numero_contrato + "', " +
                     _tipo_control_asistencia.ToString() + ", " +
                     _moneda_salario.ToString() + ", " +
                     "'" + _codigo_usuario + "', " +
                     _tipo_retiro.ToString() + ", " +
                     "'" + _fecha_retiro + "', " +
                     "'" + _observacion + "', " +
                     _num_sec_planilla.ToString() + ", " +
                     _tipo_antiguedad.ToString() + ", " +
                     _antiguedad_acumulada.ToString() + ", " +
                     _nro_sueldos_anuales.ToString() + ", " +
                     "'" + _aguinaldo + "', " +
                     _bono.ToString() + ", " +
                     _prioridad.ToString() + ", " +
                     _categoria.ToString() + " " +
                     ")";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();

            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible insertar el dato. Se encontró un error al insertar en la tabla ASIGNACIONES. " + _mensaje;
            return blOperacionCorrecta;
        }

        // Método para MODIFICAR un dato en la tabla ASIGNACIONES
        public bool Modificar()
        {
            bool blOperacionCorrecta = false;
            strSql = "update ASIGNACIONES " +
                     "set " +
                     "num_sec_cargo = " + _num_sec_cargo.ToString() + ", " +
                     "num_sec_persona = " + _num_sec_persona.ToString() + ", " +
                     "fecha_registro = '" + _fecha_registro + "', " +
                     "carga_horaria = " + _carga_horaria.ToString() + ", " +
                     "fecha_asignacion = '" + _fecha_asignacion + "', " +
                     "documento = " + _documento.ToString() + ", " +
                     "numero_contrato = '" + _numero_contrato + "', " +
                     "tipo_control_asistencia = " + _tipo_control_asistencia.ToString() + ", " +
                     "moneda_salario = " + _moneda_salario.ToString() + ", " +
                     "codigo_usuario = '" + _codigo_usuario + "', " +
                     "tipo_retiro = " + _tipo_retiro.ToString() + ", " +
                     "fecha_retiro = '" + _fecha_retiro + "', " +
                     "observacion = '" + _observacion + "', " +
                     "num_sec_planilla = " + _num_sec_planilla.ToString() + ", " +
                     "tipo_antiguedad = " + _tipo_antiguedad.ToString() + ", " +
                     "antiguedad_acumulada = " + _antiguedad_acumulada.ToString() + ", " +
                     "nro_sueldos_anuales = " + _nro_sueldos_anuales.ToString() + ", " +
                     "aguinaldo = '" + _aguinaldo + "', " +
                     "bono = " + _bono.ToString() + ", " +
                     "prioridad = " + _prioridad.ToString() + ", " +
                     "categoria = " + _categoria.ToString() + " " +
                     "where num_sec = " + _num_sec.ToString();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();

            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible actualizar el dato. Se encontró un error al actualizar en la tabla ASIGNACIONES. " + _mensaje;
            return blOperacionCorrecta;
        }

        // Método para ELIMINAR un dato en la tabla ASIGNACIONES
        public bool Borrar()
        {
            bool blOperacionCorrecta = false;
            strSql = "delete ASIGNACIONES " +
                     "where num_sec = " + _num_sec.ToString();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();

            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible borrar el dato. Se encontró un error al eliminar en la tabla ASIGNACIONES. " + _mensaje;
            return blOperacionCorrecta;
        }

        // Método para VER un dato en la tabla ASIGNACIONES
        public bool Ver()
        {
            bool Encontrado = false;
            if (!string.IsNullOrEmpty(_num_sec.ToString()))
            {
                DataTable dt = new DataTable();
                strSql = "select " +
                         "num_sec_autoriza_inscripcion, " +
                         "num_sec_semestre, " +
                         "num_sec_persona_autoriza, " +
                         "num_sec_estudiante, " +
                         "to_char(fecha_inscripcion, 'dd/mm/yyyy') fecha_inscripcion, " +
                         "referencia, " +
                         "estado, " +
                         "to_char(fecha_registro, 'dd/mm/yyyy') fecha_registro, " +
                         "usuario_registro, " +
                         "ip_registro " +
                         "from ASIGNACIONES " +
                         "where num_sec = " + _num_sec.ToString();
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
                    _num_sec_cargo = Convert.ToInt64(dr["num_sec_cargo"].ToString());
                    _num_sec_persona = Convert.ToInt64(dr["num_sec_persona"].ToString());
                    _fecha_registro = dr["fecha_registro"].ToString();
                    _carga_horaria = Convert.ToInt16(dr["carga_horaria"].ToString());
                    _fecha_asignacion = dr["fecha_asignacion"].ToString();
                    _documento = Convert.ToInt16(dr["documento"].ToString());
                    _numero_contrato = dr["numero_contrato"].ToString();
                    _tipo_control_asistencia = Convert.ToInt16(dr["tipo_control_asistencia"].ToString());
                    _moneda_salario = Convert.ToInt16(dr["moneda_salario"].ToString());
                    _codigo_usuario = dr["codigo_usuario"].ToString();
                    _tipo_retiro = Convert.ToInt16(dr["tipo_retiro"].ToString());
                    _fecha_retiro = dr["fecha_retiro"].ToString();
                    _observacion = dr["observacion"].ToString();
                    _num_sec_planilla = Convert.ToInt64(dr["num_sec_planilla"].ToString());
                    _tipo_antiguedad = Convert.ToInt16(dr["tipo_antiguedad"].ToString());
                    _antiguedad_acumulada = Convert.ToInt16(dr["antiguedad_acumulada"].ToString());
                    _nro_sueldos_anuales = Convert.ToInt16(dr["nro_sueldos_anuales"].ToString());
                    _aguinaldo = dr["aguinaldo"].ToString();
                    _bono = Convert.ToInt16(dr["bono"].ToString());
                    _prioridad = Convert.ToInt16(dr["prioridad"].ToString());
                    _categoria = Convert.ToInt16(dr["categoria"].ToString());
                }
                dt.Dispose();
            }
            if (!Encontrado)
            {
                _num_sec = 0;
                _num_sec_cargo = 0;
                _num_sec_persona = 0;
                _fecha_registro = string.Empty;
                _carga_horaria = 0;
                _fecha_asignacion = string.Empty;
                _documento = 0;
                _numero_contrato = string.Empty;
                _tipo_control_asistencia = 0;
                _moneda_salario = 0;
                _codigo_usuario = string.Empty;
                _tipo_retiro = 0;
                _fecha_retiro = string.Empty;
                _observacion = string.Empty;
                _num_sec_planilla = 0;
                _tipo_antiguedad = 0;
                _antiguedad_acumulada = 0;
                _nro_sueldos_anuales = 0;
                _aguinaldo = string.Empty;
                _bono = 0;
                _prioridad = 0;
                _categoria = 0;
            }
            return Encontrado;
        }

        #endregion

        #region Procedimientos y Funciones Locales


        #endregion

        #region Procedimientos y Funciones Públicos

        public void RevisarAsignacionRRHH(string strFecha, ref long lgNSAsignacion, ref int intTipoAsignacion,ref int intCargaHoraria,ref string strDescripcionAsignacion)
        {
            strSql = " select a.num_sec, b.tipo, a.carga_horaria, a.tipo_retiro, c.descripcion||' - '||b.nombre desc_asigna" +
                     " from ucbadmin.asignaciones a, ucbadmin.cargos_rrhh b, ucbadmin.departamentos_ucb c" +
                     " where a.num_sec_persona = " + _num_sec_persona.ToString().Trim() +
                     " and (a.fecha_retiro is null";
            if (strFecha == "")
                strSql += " or trunc(a.fecha_retiro)>=trunc(sysdate))" +
                          " and trunc(a.fecha_asignacion)<=trunc(sysdate)";
            else
                strSql += " or trunc(a.fecha_retiro)>=trunc(to_date('" + strFecha + "','dd/mm/yyyy hh24:mi:ss')))" +
                          " and trunc(a.fecha_asignacion)<=trunc(to_date('" + strFecha + "','dd/mm/yyyy hh24:mi:ss'))";
            strSql += " and a.num_sec_cargo = b.num_sec" +
                      " and b.num_sec_departamento = c.num_sec_departamento" +
                      " order by b.tipo, a.carga_horaria";
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            if (OracleBD.Error)
            {
                lgNSAsignacion = 0;
                intTipoAsignacion = 0;
                intCargaHoraria = 0;
                strDescripcionAsignacion = "";
            }
            else
            {
                if (OracleBD.DataTable.Rows.Count == 0)
                {
                    lgNSAsignacion = 0;
                    intTipoAsignacion = 0;
                    intCargaHoraria = 0;
                    strDescripcionAsignacion = "";
                }
                else
                {
                    lgNSAsignacion = Convert.ToInt64(OracleBD.DataTable.Rows[0][0]);
                    intTipoAsignacion = Convert.ToInt16(OracleBD.DataTable.Rows[0][1]);
                    intCargaHoraria = Convert.ToInt16(OracleBD.DataTable.Rows[0][2]);
                    strDescripcionAsignacion = OracleBD.DataTable.Rows[0][4].ToString().Trim();
                }
            }
        }

        #endregion

    }
}