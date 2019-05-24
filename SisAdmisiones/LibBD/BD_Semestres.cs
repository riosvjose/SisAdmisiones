using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using nsGEN_OracleBD;
using nsGEN_Cadenas;

namespace nsBD_GEN
{
    // Creado por: Milco Cortes; Fecha: 18/05/2015
    // Ultima modificación: Milco Cortes;  Fecha:02/04/2018
    //                      Willy Tenorio; Fecha:24/04/2018
    //                      Willy Tenorio; Fecha:22/03/2019
    // Descripción: Clase referente a la tabla SEMESTRES
    public class BD_Semestres
    {
        #region Variables Locales

        GEN_Cadenas libCadenas = new GEN_Cadenas();
        GEN_OracleBD OracleBD = new GEN_OracleBD();
        private string strSql = string.Empty;
        #endregion

        #region Atributos

        // Campos de la tabla SEMESTRES
        private long _num_sec = 0;
        private string _descripcion = string.Empty;
        private string _fecha_inicio = string.Empty;
        private string _fecha_fin = string.Empty;
        private string _resumido = string.Empty;
        private int _activo = 0;
        private int _tipo = 0;
        private int _restringir_notas = 0;
        private string _fecha_retiro_adicion = string.Empty;
        private string _fecha_vencimiento_visa = string.Empty;
        private int _ingreso_planificacion = 0;
        private long _num_sec_subunidad = 0;

        // Campos de la tabla SAU_GRUPOS_SEMESTRES
        private long _num_sec_grupo = 0;

        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        // Definicion GET y SET de los campos de la tabla PENSUMS_MATERIAS
        public long NumSec { get { return _num_sec; } set { _num_sec = value; } }
        public string Descripcion { get { return _descripcion; } set { _descripcion = value; } }
        public string FechaInicio { get { return _fecha_inicio; } set { _fecha_inicio = value; } }
        public string FechaFin { get { return _fecha_fin; } set { _fecha_fin = value; } }
        public string Resumido { get { return _resumido; } set { _resumido = value; } }
        public int Activo { get { return _activo; } set { _activo = value; } }
        public int Tipo { get { return _tipo; } set { _tipo = value; } }
        public int RestringirNotas { get { return _restringir_notas; } set { _restringir_notas = value; } }
        public string FechaRetiroAdicion { get { return _fecha_retiro_adicion; } set { _fecha_retiro_adicion = value; } }
        public string FechaVencimientoVisa { get { return _fecha_vencimiento_visa; } set { _fecha_vencimiento_visa = value; } }
        public int IngresoPlanificacion { get { return _ingreso_planificacion; } set { _ingreso_planificacion = value; } }
        public long NumSecSubunidad { get { return _num_sec_subunidad; } set { _num_sec_subunidad = value; } }

        public long NumSecGrupo { get { return _num_sec_grupo; } set { _num_sec_grupo = value; } }

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
        public BD_Semestres()
        {
            _num_sec = 0;
            _descripcion = string.Empty;
            _fecha_inicio = string.Empty;
            _fecha_fin = string.Empty;
            _resumido = string.Empty;
            _activo = 0;
            _tipo = 0;
            _restringir_notas = 0;
            _fecha_retiro_adicion = string.Empty;
            _fecha_vencimiento_visa = string.Empty;
            _ingreso_planificacion = 0;
            _num_sec_subunidad = 0;

            _num_sec_grupo = 0;

            _mensaje = string.Empty;
            _strconexion = string.Empty;

        }
        #endregion

        #region Metodos

        public bool Insertar()
        {
            bool blOperacionCorrecta = false;
            blOperacionCorrecta = Validar_Campos(1);
            if (blOperacionCorrecta)
            {
                int intNumSqls = 0;
                string[] strSqls = new string[5];

                OracleBD.MostrarError = false;
                OracleBD.StrConexion = _strconexion;

                long lngNSSemestre = OracleBD.Generar_NumSec("semestres_sec");
                blOperacionCorrecta = !OracleBD.Error;

                if (blOperacionCorrecta && lngNSSemestre > 0)
                {
                    if (_activo == 1)
                    {
                        strSqls[intNumSqls] = SQL_Inactivar_Semestres(lngNSSemestre);
                        intNumSqls++;
                    }

                    strSqls[intNumSqls] = SQL_Insertar_Semestre(lngNSSemestre);
                    intNumSqls++;

                    strSqls[intNumSqls] = SQL_Insertar_SAU_Grupos_Semestres(lngNSSemestre.ToString(), _num_sec_grupo.ToString());
                    intNumSqls++;

                    OracleBD.NumSqls = intNumSqls;
                    OracleBD.ListaSqls = strSqls;
                    OracleBD.EjecutarSqlsTrans();
                    _mensaje = OracleBD.Mensaje;
                    blOperacionCorrecta = !OracleBD.Error;
                }
                else
                {
                    blOperacionCorrecta = false;
                    _mensaje = "No fue posible generar un identificador para el semestre. " + OracleBD.Mensaje;
                }

                if (!blOperacionCorrecta)
                    _mensaje = "No fue posible insertar el dato. " + _mensaje;
            }
            return blOperacionCorrecta;
        }

        // Método para MODIFICAR un dato en la tabla CONVALIDACIONES
        public bool Modificar()
        {
            // intModalidadRegistro:  1: convalidación,  2: homologación
            bool blOperacionCorrecta = false;
            blOperacionCorrecta = Validar_Campos(2);
            if (blOperacionCorrecta)
            {
                int intNumSqls = 0;
                string[] strSqls = new string[5];

                OracleBD.MostrarError = false;
                OracleBD.StrConexion = _strconexion;

                if (_activo == 1)
                {
                    strSqls[intNumSqls] = SQL_Inactivar_Semestres(_num_sec);
                    intNumSqls++;
                }

                strSqls[intNumSqls] = SQL_Actualizar_Semestre(_num_sec);
                intNumSqls++;

                strSqls[intNumSqls] = SQL_Actualizar_SAU_Grupos_Semestres(_num_sec.ToString(), _num_sec_grupo.ToString());
                intNumSqls++;

                OracleBD.NumSqls = intNumSqls;
                OracleBD.ListaSqls = strSqls;
                OracleBD.EjecutarSqlsTrans();
                _mensaje = OracleBD.Mensaje;
                blOperacionCorrecta = !OracleBD.Error;
                if (!blOperacionCorrecta)
                    _mensaje = "No fue posible actualizar el dato. " + _mensaje;
            }
            return blOperacionCorrecta;
        }

        // Método para ELIMINAR un dato en la tabla CONVALIDACIONES
        public bool Borrar()
        {
            bool blOperacionCorrecta = false;
            int intNumSqls = 0;
            string[] strSqls = new string[5];

            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;

            strSqls[intNumSqls] = "delete sau_grupos_semestres where num_sec_semestre = " + _num_sec.ToString();
            intNumSqls++;

            strSqls[intNumSqls] = "delete semestres where num_sec = " + _num_sec.ToString();
            intNumSqls++;

            OracleBD.NumSqls = intNumSqls;
            OracleBD.ListaSqls = strSqls;
            OracleBD.EjecutarSqlsTrans();
            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (!blOperacionCorrecta)
                _mensaje = "No fue posible borrar el dato. " + _mensaje;
            return blOperacionCorrecta;
        }

        public bool Ver()
        {
            bool Encontrado = false;
            if (!string.IsNullOrEmpty(_num_sec.ToString()))
            {
                DataTable dt = new DataTable();
                strSql = "select s.*, g.num_sec_grupo" +
                        " , to_char(s.fecha_inicio,'dd/mm/rrrr') f_ini" +
                        " , to_char(s.fecha_fin,'dd/mm/rrrr') f_fin" +
                        " , to_char(s.fecha_retiro_adicion,'dd/mm/rrrr') f_ret_ad" +
                        " , to_char(s.fecha_vencimiento_visa,'dd/mm/rrrr') f_v_visa" +
                        " from semestres s, sau_grupos_semestres g" +
                        " where s.num_sec = " + _num_sec.ToString() +
                        " and s.num_sec = g.num_sec_semestre(+)";
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
                    _descripcion = dr["descripcion"].ToString();
                    _fecha_inicio = dr["f_ini"].ToString();
                    _fecha_fin = dr["f_fin"].ToString();
                    _resumido = dr["resumido"].ToString();
                    _activo = Convert.ToInt16(dr["activo"].ToString());
                    _tipo = Convert.ToInt16(dr["tipo"].ToString());
                    _restringir_notas = Convert.ToInt16(dr["restringir_notas"].ToString());
                    _fecha_retiro_adicion = dr["f_ret_ad"].ToString();
                    _fecha_vencimiento_visa = dr["f_v_visa"].ToString();
                    _ingreso_planificacion = Convert.ToInt16(dr["ingreso_planificacion"].ToString());

                    _num_sec_subunidad = Convert.ToInt64(dr["num_sec_subunidad"].ToString());
                    if (string.IsNullOrEmpty(dr["num_sec_grupo"].ToString()))
                        _num_sec_grupo = 0;
                    else
                        _num_sec_grupo = Convert.ToInt64(dr["num_sec_grupo"].ToString());

                }
                dt.Dispose();
            }
            if (!Encontrado)
            {
                _num_sec = 0;
                _descripcion = string.Empty;
                _fecha_inicio = string.Empty;
                _fecha_fin = string.Empty;
                _resumido = string.Empty;
                _activo = 0;
                _tipo = 0;
                _restringir_notas = 0;
                _fecha_retiro_adicion = string.Empty;
                _fecha_vencimiento_visa = string.Empty;
                _ingreso_planificacion = 0;
                _num_sec_subunidad = 0;
                _num_sec_grupo = 0;
            }
            return Encontrado;
        }

        #endregion

        #region Procedimientos y Funciones Locales

        private string SQL_Insertar_Semestre(long lngNSSemestre)
        {
            string strSql = string.Empty;

            strSql = "insert into semestres (num_sec, num_sec_subunidad, resumido, descripcion";
            strSql += " , fecha_inicio, fecha_fin, tipo, activo";
            strSql += " , restringir_notas, fecha_retiro_adicion, fecha_vencimiento_visa, ingreso_planificacion) values (";
            if (lngNSSemestre > 0)
                strSql += lngNSSemestre.ToString();
            else
                strSql += " semestres_sec.nextval";
            strSql += " , " + _num_sec_subunidad.ToString();
            strSql += " , '" + _resumido.Trim() +"'";
            strSql += " , '" + _descripcion.Trim() + "'";
            strSql += " , to_date('" + _fecha_inicio.Trim() + "','dd/mm/rrrr')";
            strSql += " , to_date('" + _fecha_fin.Trim() + "','dd/mm/rrrr')";
            strSql += " , " + _tipo.ToString();
            strSql += " , " + _activo.ToString();
            strSql += " , " + _restringir_notas.ToString(); ;
            strSql += " , to_date('" + _fecha_retiro_adicion.Trim() + "','dd/mm/rrrr')";
            strSql += " , to_date('" + _fecha_vencimiento_visa.Trim() + "','dd/mm/rrrr')";
            strSql += " , " + _ingreso_planificacion.ToString();
            strSql += " )";

            return strSql;
        }

        private string SQL_Actualizar_Semestre(long lngNSSemestre)
        {
            string strSql = string.Empty;

            strSql = "update semestres set ";
            strSql += " num_sec_subunidad = " + _num_sec_subunidad.ToString();
            strSql += " , resumido = '" + _resumido.Trim() + "'";
            strSql += " , descripcion = '" + _descripcion.Trim() + "'";
            strSql += " , fecha_inicio = to_date('" + _fecha_inicio.Trim() + "','dd/mm/rrrr')";
            strSql += " , fecha_fin = to_date('" + _fecha_fin.Trim() + "','dd/mm/rrrr')";
            strSql += " , tipo = " + _tipo.ToString();
            strSql += " , activo = " + _activo.ToString();
            strSql += " , restringir_notas = " + _restringir_notas.ToString(); ;
            strSql += " , fecha_retiro_adicion = to_date('" + _fecha_retiro_adicion.Trim() + "','dd/mm/rrrr')";
            strSql += " , fecha_vencimiento_visa = to_date('" + _fecha_vencimiento_visa.Trim() + "','dd/mm/rrrr')";
            strSql += " , ingreso_planificacion = " + _ingreso_planificacion.ToString();

            strSql += " where num_sec = " + lngNSSemestre;

            strSql += " and (num_sec_subunidad <> " + _num_sec_subunidad.ToString();
            strSql += " or resumido <> '" + _resumido.Trim() + "'";
            strSql += " or descripcion <> '" + _descripcion.Trim() + "'";
            strSql += " or fecha_inicio <> to_date('" + _fecha_inicio.Trim() + "','dd/mm/rrrr')";
            strSql += " or fecha_fin <> to_date('" + _fecha_fin.Trim() + "','dd/mm/rrrr')";
            strSql += " or tipo <> " + _tipo.ToString();
            strSql += " or activo <> " + _activo.ToString();
            strSql += " or restringir_notas <> " + _restringir_notas.ToString(); ;
            strSql += " or fecha_retiro_adicion <> to_date('" + _fecha_retiro_adicion.Trim() + "','dd/mm/rrrr')";
            strSql += " or fecha_vencimiento_visa <> to_date('" + _fecha_vencimiento_visa.Trim() + "','dd/mm/rrrr')";
            strSql += " or ingreso_planificacion <> " + _ingreso_planificacion.ToString();

            strSql += " )";

            return strSql;
        }

        private string SQL_Inactivar_Semestres(long lngNSSemestre)
        {
            string strSql = string.Empty;
            strSql = "update semestres set activo = 2 where activo = 1 and num_sec <> " + lngNSSemestre.ToString();
            return strSql;
        }

        private string SQL_Insertar_SAU_Grupos_Semestres(string strNSSem, string strNSGrupoAulas)
        {
            string strSql = string.Empty;
            strSql = "insert into sau_grupos_semestres (num_sec_semestre, num_sec_grupo) values (";
            strSql += strNSSem;
            strSql += " , " + strNSGrupoAulas + ")";
            return strSql;
        }

        private string SQL_Actualizar_SAU_Grupos_Semestres(string strNSSem, string strNSGrupoAulas)
        {
            string strSql = string.Empty;
            strSql = "update sau_grupos_semestres set num_sec_grupo = " + strNSGrupoAulas;
            strSql += " where num_sec_semestre = " + strNSSem;
            strSql += " and num_sec_grupo <> " + strNSGrupoAulas;
            return strSql;
        }

        private bool Validar_Campos(int axTipoPantalla)
        {
            if (axTipoPantalla == 2)
            {
                if (_num_sec <= 0)
                {
                    _mensaje = "El registro no fue seleccionado correctamente.";
                    return false;
                }
            }
            if (_num_sec_subunidad <= 0)
            {
                _mensaje = "La subunidad no fue seleccionada correctamente.";
                return false;
            }
            if (_num_sec_grupo <= 0)
            {
                _mensaje = "El grupo de aulas no fue seleccionado correctamente.";
                return false;
            }

            if (_tipo < 1 || _tipo > 3)
            {
                _mensaje = "El tipo debe estar entre 1 y 3.";
                return false;
            }
            if (_activo < 1 || _activo > 2)
            {
                _mensaje = "El campo activo debe estar entre 1 y 2.";
                return false;
            }
            if (_restringir_notas < 1 || _restringir_notas > 2)
            {
                _mensaje = "El campo restringir notas debe estar entre 1 y 2.";
                return false;
            }
            if (_ingreso_planificacion < 0 || _ingreso_planificacion > 2)
            {
                _mensaje = "El campo ingreso planificación (programación académica) debe estar entre 0 y 2.";
                return false;
            }

            if (_resumido.Trim().Length < 1 || _resumido.Trim().Length > 7)
            {
                _mensaje = "El resumido debe contener entre 1 y 7 caracteres.";
                return false;
            }
            if (libCadenas.Texto_Contiene_Caracteres_Especiales(_resumido.Trim(), 3, 1))
            {
                _mensaje = "El resumido no debe contener caracteres epeciales.";
                return false;
            }
            if (_descripcion.Trim().Length < 1 || _descripcion.Trim().Length > 30)
            {
                _mensaje = "La descripción debe contener entre 1 y 30 caracteres.";
                return false;
            }
            if (libCadenas.Texto_Contiene_Caracteres_Especiales(_descripcion.Trim(), 3, 1))
            {
                _mensaje = "La descripción no debe contener caracteres epeciales.";
                return false;
            }

            if (!libCadenas.Validar_Fecha_Hora(_fecha_inicio.Trim(), 1))
            {
                _mensaje = "La fecha inicio debe tener el formato DD/MM/AAAA.";
                return false;
            }
            if (!libCadenas.Validar_Fecha_Hora(_fecha_fin.Trim(), 1))
            {
                _mensaje = "La fecha fin debe tener el formato DD/MM/AAAA.";
                return false;
            }
            if (!libCadenas.Validar_Fecha_Hora(_fecha_retiro_adicion.Trim(), 1))
            {
                _mensaje = "La fecha de retiros y adiciones debe tener el formato DD/MM/AAAA.";
                return false;
            }
            if (!libCadenas.Validar_Fecha_Hora(_fecha_vencimiento_visa.Trim(), 1))
            {
                _mensaje = "La fecha de vencimiento de visa debe tener el formato DD/MM/AAAA.";
                return false;
            }

            bool blFechasCorrectas = true;
            int intComparaFechas = 0;
            intComparaFechas = libCadenas.Comparar_Fechas(_fecha_inicio, _fecha_fin);
            switch (intComparaFechas)
            {
                case 1:     //f1 < f2
                    blFechasCorrectas = true;
                    break;
                case 2:     //f1 = f2
                    blFechasCorrectas = false;
                    _mensaje = "La fecha fin debe ser mayor a la fecha inicio.";
                    break;
                case 3:     //f1 > f2
                    blFechasCorrectas = false;
                    _mensaje = "La fecha fin debe ser mayor a la fecha inicio.";
                    break;
                default:    //fechas incorrectas
                    blFechasCorrectas = false;
                    _mensaje = "La fecha inicio y/o la fecha fin son incorrectas.";
                    break;
            }
            if (!blFechasCorrectas)
                return false;

            intComparaFechas = libCadenas.Comparar_Fechas(_fecha_inicio, _fecha_vencimiento_visa);
            switch (intComparaFechas)
            {
                case 1:     //f1 < f2
                    blFechasCorrectas = true;
                    break;
                case 2:     //f1 = f2
                    blFechasCorrectas = true;
                    break;
                case 3:     //f1 > f2
                    blFechasCorrectas = false;
                    _mensaje = "La fecha de control de vencimiento de visa debe ser mayor o igual a la fecha inicio.";
                    break;
                default:    //fechas incorrectas
                    blFechasCorrectas = false;
                    _mensaje = "La fecha inicio y/o la fecha de control de vencimiento de visa son incorrectas.";
                    break;
            }
            if (!blFechasCorrectas)
                return false;

            intComparaFechas = libCadenas.Comparar_Fechas(_fecha_vencimiento_visa, _fecha_fin );
            switch (intComparaFechas)
            {
                case 1:     //f1 < f2
                    blFechasCorrectas = true;
                    break;
                case 2:     //f1 = f2
                    blFechasCorrectas = true;
                    break;
                case 3:     //f1 > f2
                    blFechasCorrectas = false;
                    _mensaje = "La fecha de control de vencimiento de visa debe ser menor o igual a la fecha fin.";
                    break;
                default:    //fechas incorrectas
                    blFechasCorrectas = false;
                    _mensaje = "La fecha fin y/o la fecha de control de vencimiento de visa son incorrectas.";
                    break;
            }
            if (!blFechasCorrectas)
                return false;

            intComparaFechas = libCadenas.Comparar_Fechas(_fecha_inicio, _fecha_retiro_adicion);
            switch (intComparaFechas)
            {
                case 1:     //f1 < f2
                    blFechasCorrectas = true;
                    break;
                case 2:     //f1 = f2
                    blFechasCorrectas = true;
                    break;
                case 3:     //f1 > f2
                    blFechasCorrectas = false;
                    _mensaje = "La fecha de retiros y adiciones debe ser mayor o igual a la fecha inicio.";
                    break;
                default:    //fechas incorrectas
                    blFechasCorrectas = false;
                    _mensaje = "La fecha inicio y/o la fecha de retiros y adiciones son incorrectas.";
                    break;
            }
            if (!blFechasCorrectas)
                return false;

            if (!Revisar_Repetido(axTipoPantalla))
            {
                return false;
            }
            return true;
        }

        private bool Revisar_Repetido(int intModoPantalla)
        {
            strSql = "select num_sec";
            strSql += " from semestres";
            strSql += " where num_sec_subunidad = " + _num_sec_subunidad.ToString();
            strSql += " and (UPPER(resumido) = " + _resumido.Trim().ToUpper();
            strSql += " or UPPER(rescripcion) = " + _descripcion.Trim().ToUpper() + ")";
            if (intModoPantalla == 2)
            {
                strSql += " and num_sec <> " + _num_sec.ToString();
            }

            DataTable dt = new DataTable();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            if (dt.Rows.Count > 0)
            {
                dt.Dispose();
                _mensaje = "El dato que requiere insertar se encuentra repetido";
                return false;
            }
            else
            {
                dt.Dispose();
                return true;
            }
        }

        #endregion

        #region Procedimientos y Funciones Publicas

        public string Query_DropDownList1(bool blIncluirSemNulo)
        {
            string strSql = string.Empty;
            strSql = " select num_sec, resumido, descripcion, fecha_inicio";
            strSql += " from semestres ";
            if (!blIncluirSemNulo)
                strSql += " where num_sec > 0";
            strSql += " order by fecha_inicio desc";
            return strSql;
        }

        public string Query_DropDownList2(string strNSSubunidad, int intIncluirTodos_Nulo, string strAnioInicial, string strAnioFinal, int intOrden)
        {
            // intIncluirTodos_Nulo: 0:no incluir, 1:incluir TODOS, 2:incluir NULO
            // intOrden: 1: descendente, 2: activo descendente, 3:ascendente
            string strSql = string.Empty;
            string strSqlCondiciones = string.Empty;

            if (intIncluirTodos_Nulo > 0)
            {
                string strResumidoSem = string.Empty;
                if (intIncluirTodos_Nulo == 2)
                    strResumidoSem = "'[NINGUNO]'";
                else
                    strResumidoSem = "'[TODOS]'";

                strSql += " select 0 num_sec, " + strResumidoSem + " resumido, " + strResumidoSem + " descripcion";
                strSql += ", to_date('01/01/2050','dd/mm/rrrr') fecha_inicio, to_date('01/01/2050','dd/mm/rrrr') f_ini, to_date('01/01/2050','dd/mm/rrrr') f_fin, " + strResumidoSem + " nombre_semestre";
                strSql += " from dual";
                strSql += " UNION";
            }


            strSql += " select num_sec, resumido, descripcion, fecha_inicio, to_char(fecha_inicio,'dd/mm/rrrr') f_ini, to_char(fecha_fin,'dd/mm/rrrr') f_fin";
            if (intOrden == 2)
                strSql += " , resumido||decode(activo,1,' [ACTIVO]','') nombre_semestre";
            else
                strSql += " , resumido nombre_semestre";

            strSql += " from semestres ";
            strSql += " where num_sec_subunidad = " + strNSSubunidad;
            strSqlCondiciones += " and num_sec > 0";

            if (!string.IsNullOrEmpty(strAnioInicial))
                strSqlCondiciones += " and to_char(fecha_inicio,'rrrr') >= " + strAnioInicial;
            if (!string.IsNullOrEmpty(strAnioFinal))
                strSqlCondiciones += " and to_char(fecha_inicio,'rrrr') <= " + strAnioFinal;

            strSql += strSqlCondiciones;
            if (intOrden == 3)
                strSql += " order by fecha_inicio";
            else
                if (intOrden == 2)
                strSql += " order by activo, fecha_inicio desc";
            else
                strSql += " order by fecha_inicio desc";

            return strSql;
        }

        public string Query_Grid_ABM1(string strNSSubunidad)
        {
            string strSql = string.Empty;

            strSql = " select a.num_sec, a.resumido, a.descripcion, a.tipo, a.activo, ";
            strSql += " a.fecha_inicio, a.fecha_fin, ";
            strSql += " to_char(a.fecha_inicio,'dd/mm/rrrr') f_inicio,";
            strSql += " to_char(a.fecha_fin,'dd/mm/rrrr') f_fin,";
            strSql += " b.descripcion tipo_str,";
            strSql += " decode(a.activo, 1, 'Si','No') activo_str";
            strSql += " , 'Seleccionar' seleccionar";
            strSql += " from semestres a, dominios b";
            strSql += " where a.num_sec > 0 ";
            strSql += " and a.num_sec_subunidad = " + strNSSubunidad;
            strSql += " and b.dominio = 'TIPO_SEMESTRE'";
            strSql += " and b.valor = a.tipo";
            strSql += " order by a.activo, a.fecha_inicio desc, a.fecha_fin desc";

            return strSql;
        }

        public string Query_Anios_Semestres(string strAnioInicial, string strAnioFinal, int intOrden)
        {
            // intOrden: 1: descendente, 2:ascendente
            string strSql = string.Empty;
            strSql = "select to_char(fecha_inicio,'rrrr') anio";
            strSql += " from semestres";
            strSql += " where tipo = 1";
            if (!string.IsNullOrEmpty(strAnioInicial))
                strSql += " and to_char(fecha_inicio,'rrrr') >= " + strAnioInicial;
            if (!string.IsNullOrEmpty(strAnioFinal))
                strSql += " and to_char(fecha_inicio,'rrrr') <= " + strAnioFinal;
            strSql += " group by to_char(fecha_inicio,'rrrr')";
            if (intOrden == 2)
                strSql += " order by anio";
            else
                strSql += " order by anio desc";

            return strSql;
        }

        public string SemestresCursados(string NSPersona)
        {
            strSql = "select distinct b.num_sec_semestre, c.resumido||' - '||c.descripcion semestre, c.fecha_inicio " +
                    "from alumnos_paralelos a, paralelos b, semestres c " +
                    "where a.num_sec_persona = " + NSPersona + " " +
                    "and a.activo=1  " +
                    "and a.estado=1  " +
                    "and a.num_sec_paralelo = b.num_sec  " +
                    "and b.num_sec_semestre = c.num_sec  " +
                    "order by c.fecha_inicio desc";
            return strSql;
        }

        public string SemestresCursadosParametros2(string NSPersona, string Parametro)
        {
            strSql = "select distinct b.num_sec_semestre, c.resumido||' - '||c.descripcion semestre, c.fecha_inicio " +
                    "from alumnos_paralelos a, paralelos b, semestres c, semestres_internet si " +
                    "where a.num_sec_persona = " + NSPersona + " " +
                    "and a.activo = 1  " +
                    "and a.estado = 1  " +
                    "and c.num_sec = si.num_sec_semestre ";
            if (Parametro.Trim() != "")
                strSql += "and si." + Parametro + " = 1 ";
            strSql += "and a.num_sec_paralelo = b.num_sec  " +
                    "and b.num_sec_semestre = c.num_sec  " +
                    "union " +
                    "select distinct b.num_sec_semestre, c.resumido||' - '||c.descripcion semestre, c.fecha_inicio  " +
                    "from alumnos_paralelos a, paralelos b, semestres c " +
                    "where a.num_sec_persona = " + NSPersona + "  " +
                    "and a.activo = 1   " +
                    "and a.estado = 1   " +
                    "and c.fecha_fin <= to_date('31/12/1997', 'dd/mm/yyyy') " +
                    "and a.num_sec_paralelo = b.num_sec   " +
                    "and b.num_sec_semestre = c.num_sec   " +
                    "order by fecha_inicio desc";
            return strSql;
        }


        public string SemestresCursadosFechasControl(string strNSSubunidad, string strNSPersona, string strCodigoFecha)
        {
            strSql = "select distinct b.num_sec_semestre, c.resumido||' - '||c.descripcion semestre, c.fecha_inicio";
            strSql += " from alumnos_paralelos a, paralelos b, semestres c";
            if (strCodigoFecha.Length > 0)
            {
                strSql += " , (select distinct p.num_sec, f.num_sec_fecha, f.tipo, s.fecha fsem, e.fecha fusr";
                strSql += "   , CASE WHEN f.control = 1 AND sysdate>=s.fecha THEN 1";
                strSql += "     ELSE";
                strSql += "       CASE WHEN f.control = 2 AND sysdate<=s.fecha THEN 1";
                strSql += "       ELSE 0";
                strSql += "       END";
                strSql += "     END as f_permitida";
                strSql += "   from gen_fechas f, gen_fechas_semestres s";
                strSql += "   , paralelos p, semestres s";
                strSql += "   where s.num_sec_subunidad = " + strNSSubunidad;
                strSql += "   and f.num_sec_subunidad = " + strNSSubunidad;
                strSql += "   and f.codigo = " + strCodigoFecha;
                strSql += "   and p.num_sec_semestre = s.num_sec";
                strSql += "   and f.num_sec_subunidad = s.num_sec_subunidad";
                strSql += "   and s.num_sec_semestre = p.num_sec_semestre";
                strSql += "   and s.num_sec_fecha = f.num_sec_fecha";
                strSql += "   ) fctrl";
            }
            strSql += " where a.num_sec_persona = " + strNSPersona;
            strSql += " and a.activo = 1";
            strSql += " and a.estado = 1";
            strSql += " and a.num_sec_paralelo = b.num_sec";
            strSql += " and b.num_sec_semestre = c.num_sec";
            strSql += " and c.num_sec_subunidad = " + strNSSubunidad;
            if (strCodigoFecha.Length > 0)
            {
                strSql += " and b.num_sec = fctrl.num_sec";
                strSql += " and fctrl.f_permitida = 1";
            }
            strSql += " union";
            strSql += " select distinct b.num_sec_semestre, c.resumido||' - '||c.descripcion semestre, c.fecha_inicio";
            strSql += " from alumnos_paralelos a, paralelos b, semestres c";
            strSql += " where a.num_sec_persona = " + strNSPersona;
            strSql += " and a.activo = 1";
            strSql += " and a.estado = 1";
            strSql += " and c.num_sec_subunidad = " + strNSSubunidad;
            strSql += " and c.fecha_fin <= to_date('31/12/1997', 'dd/mm/yyyy')";
            strSql += " and a.num_sec_paralelo = b.num_sec";
            strSql += " and b.num_sec_semestre = c.num_sec";
            strSql += " order by fecha_inicio desc";
            return strSql;
        }


        public string SemestreActivoProgramacionAcad(string strNSSubunidad, string axFechaSem)
        {
            //strSql = "select a.num_sec num_sec_semestre, a.resumido||' - '||a.descripcion semestre, a.fecha_inicio, a.tipo " +
            //        "from semestres a, semestres_internet b  " +
            //        "where a.fecha_inicio <= to_date('" + axFechaSem + "','dd/mm/yyyy') " +
            //        "and a.fecha_fin >= to_date('" + axFechaSem + "','dd/mm/yyyy') " +
            //        "and a.num_sec = b.num_sec_semestre " +
            //        "and b.permitir_ver_prog_acad = 1 " +
            //        "order by a.fecha_inicio desc";

            strSql = "select distinct a.num_sec num_sec_semestre, a.resumido||' - '||a.descripcion semestre, a.fecha_inicio, a.tipoc";
            strSql += " from semestres a";
            strSql += " , (select distinct s.num_sec, f.num_sec_fecha, f.tipo, s.fecha fsem, e.fecha fusr";
            strSql += "   , CASE WHEN f.control = 1 AND (sysdate>=s.fecha OR sysdate>=e.fecha) THEN 1";
            strSql += "     ELSE ";
            strSql += "       CASE WHEN f.control = 2 AND (sysdate<=s.fecha OR sysdate<=e.fecha) THEN 1";
            strSql += "       ELSE 0";
            strSql += "       END";
            strSql += "     END as f_permitida";
            strSql += "   from gen_fechas f, gen_fechas_semestres s, gen_fechas_sem_extemp e";
            strSql += "   , paralelos p, semestres s";
            strSql += "   where s.num_sec_subunidad = " + strNSSubunidad;
            strSql += "   and p.num_sec_semestre = s.num_sec";
            strSql += "   and f.num_sec_subunidad = " + strNSSubunidad;
            strSql += "   and f.num_sec_subunidad = s.num_sec_subunidad";
            strSql += "   and f.codigo = 3302000100";
            strSql += "   and s.num_sec_semestre = p.num_sec_semestre";
            strSql += "   and s.num_sec_fecha = f.num_sec_fecha";
            strSql += "   and s.num_sec_semestre = e.num_sec_semestre(+)";
            strSql += "   and s.num_sec_fecha = e.num_sec_fecha(+)";
            strSql += "   and e.num_sec_usuario(+) = 0";
            strSql += "   ) fctrl";
            strSql += " where a.num_sec_subunidad = " + strNSSubunidad;
            strSql += " and a.fecha_inicio >= to_date('01/01/2018','dd/mm/yyyy')";
            strSql += " and a.num_sec = fctrl.num_sec";
            strSql += " and fctrl.f_permitida = 1";
            strSql += " order by a.fecha_inicio desc";

            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            if (OracleBD.DataTable.Rows.Count == 1)
                return OracleBD.DataTable.Rows[0][0].ToString().Trim();
            else
                return "0";

        }

        public string SQLHorasSemestre()
        {
            strSql = "select distinct a.num_sec_grupo, c.num_sec_hora, " +
                     "c.hora_inicio, c.hora_fin, c.secuencia, to_char(trunc(c.hora_inicio/60),'00')||':'||ltrim(to_char(((c.hora_inicio/60)-trunc(c.hora_inicio/60))*60,'00')) hini, " +
                     "to_char(trunc(c.hora_fin/60),'00')||':'||ltrim(to_char(((c.hora_fin/60)-trunc(c.hora_fin/60))*60,'00')) hfin, " +
                     "trunc(c.hora_inicio/60) hinih, ((c.hora_inicio/60)-trunc(c.hora_inicio/60))*60 hinim, trunc(c.hora_fin/60) hfinh, " +
                     "((c.hora_fin/60)-trunc(c.hora_fin/60))*60 hfinm " +
                     "from sau_grupos a, sau_grupos_semestres b, sau_horas c " +
                     "where a.tipo_grupo = 2 " +
                     "and a.estado_grupo = 1 " +
                     "and b.num_sec_semestre = " + _num_sec.ToString().Trim() + " " +
                     "and a.num_sec_grupo = b.num_sec_grupo " +
                     "and a.num_sec_grupo = c.num_sec_grupo";
            return strSql;
        }

        /// <summary>
        /// Listado de estudiantes que cursaron un determinado semestre
        /// </summary>
        /// <param name="NSPersona">Campo NUM_SEC_PERSONA</param>
        /// <param name="NSCarrera">campo NUM_SEC_CARRERA</param>
        /// <param name="Tipo">PRE=Pregrado;  POST=Postgrado</param>
        /// <returns></returns>
        public DataTable ListaSemestresCursadosEstudiante(string NSPersona, string NSCarrera, string Tipo)
        {
            strSql = "select distinct p.num_sec_semestre, s.descripcion semestre, s.fecha_inicio " +
                    "from paralelos p, alumnos_paralelos ap, semestres s, carreras c " +
                    "where ap.activo = 1 " +
                    "and ap.estado in (1,4,5) " +
                    "and p.tipo in (1,2,3,4,5,8) ";
            if (Tipo == "POST")
            {
                strSql += "and c.interna = 4 " +
                          "and c.num_sec = " + NSCarrera + " ";
            }
            else
                strSql += "and c.interna <> 4 ";
            strSql += "and ap.num_sec_persona = " + NSPersona + " " +
                    "and p.num_sec = ap.num_sec_paralelo " +
                    "and p.num_sec_semestre = s.num_sec " +
                    "and p.num_sec_carrera = c.num_sec " +
                    "order by s.fecha_inicio asc";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }

        public int TipoSemestre()
        {
            strSql = "select tipo " +
                    "from semestres " +
                    "where num_sec = " + _num_sec;
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            if (OracleBD.DataTable.Rows.Count == 0)
                return 0;
            else
                return Convert.ToInt16(OracleBD.DataTable.Rows[0][0].ToString());
        }

        public bool VerificarTransicionSemestreNotas()
        {
            strSql = "select count(0) total " +
                    "from semestres " +
                    "where num_sec = '" + _num_sec + "' " +
                    "and fecha_inicio >= to_date('01/01/1998','dd/mm/yyyy')";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            if (OracleBD.DataTable.Rows[0][0].ToString().Trim() == "0")
                return false;
            else
                return true;
        }

        public DataTable ListadoSemestres(string strNSSubunidad)
        {
            strSql = "select distinct a.num_sec, a.resumido res_nom, a.fecha_inicio, a.descripcion " +
                     "from semestres a ";
            if (_num_sec != 0)
            {
                strSql += "where a.num_sec = " + _num_sec.ToString().Trim() + " ";
            }
            else
            {
                strSql += "where a.num_sec > 0 ";
            }
            strSql += " and num_sec_subunidad = " + strNSSubunidad;
            strSql += " order by a.fecha_inicio desc";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }

        public string Determinar_Semestre_Preseleccionado(string strNSSubunidades, byte axTipo)
        {
            //strSql = "select a.num_sec, b.SAADM_INSCRIPCIONES, b.SAADM_F_INICIO_INSC, b.SADOC_REG_NOTAS, b.PERMITIR_VER_HORARIOS " +
            //         "from semestres a, semestres_internet b " +
            //         "where a.num_sec > 0 " +
            //         "and a.num_sec = b.num_sec_semestre(+) ";

            strSql = "select a.num_sec, f1.SAADM_INSCRIPCIONES, f1.SAADM_F_INICIO_INSC, f2.SADOC_REG_NOTAS, f3.PERMITIR_VER_HORARIOS";
            strSql += " from semestres a";

            strSql += " , (select s.num_sec_semestre, f.codigo, s.fecha SAADM_F_INICIO_INSC";
            strSql += "   , CASE WHEN sysdate>=s.fecha THEN 1 ELSE 0 END as SAADM_INSCRIPCIONES";
            strSql += "   from gen_fechas f, gen_fechas_semestres s";
            strSql += "   where f.num_sec_subunidad = " + strNSSubunidades;
            strSql += "   and f.codigo = 803000210";
            strSql += "   and f.num_sec_fecha = s.num_sec_fecha) f1";

            strSql += " , (select s.num_sec_semestre, f.codigo, s.fecha f_ini_reg_notas";
            strSql += "   , CASE WHEN sysdate>=s.fecha THEN 1 ELSE 0 END as SADOC_REG_NOTAS";
            strSql += "   from gen_fechas f, gen_fechas_semestres s";
            strSql += "   where f.num_sec_subunidad = " + strNSSubunidades;
            strSql += "   and f.codigo = 804000100";
            strSql += "   and f.num_sec_fecha = s.num_sec_fecha) f2";

            strSql += " , (select s.num_sec_semestre, f.codigo, s.fecha";
            strSql += "   , CASE WHEN sysdate>=s.fecha THEN 1 ELSE 0 END as PERMITIR_VER_HORARIOS";
            strSql += "   from gen_fechas f, gen_fechas_semestres s";
            strSql += "   where f.num_sec_subunidad = " + strNSSubunidades;
            strSql += "   and f.codigo = 3302000100";
            strSql += "   and f.num_sec_fecha = s.num_sec_fecha) f3";

            strSql += " where a.num_sec_subunidad = " + strNSSubunidades;
            strSql += " and a.num_sec > 0";
            strSql += " and a.num_sec = f1.num_sec_semestre(+)";
            strSql += " and a.num_sec = f2.num_sec_semestre(+)";
            strSql += " and a.num_sec = f3.num_sec_semestre(+)";


            switch (axTipo)
            {
                case 1: // Programacion academica
                    strSql += "order by nvl(b.PERMITIR_VER_HORARIOS,0) desc, a.fecha_inicio desc ";
                    break;
                case 2: // Inscripciones
                    strSql += "order by nvl(b.SAADM_INSCRIPCIONES,0) desc, nvl(SAADM_F_INICIO_INSC,to_date('01/01/1950','dd/mm/yyyy')) desc, a.fecha_inicio desc ";
                    break;
                case 3: // Semestre en curso
                    strSql += "order by nvl(b.SADOC_REG_NOTAS,0) desc, a.fecha_inicio desc ";
                    break;
                default: // Orden de fecha de inicio
                    strSql += "order by a.fecha_inicio desc ";
                    break;
            }
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            if (OracleBD.DataTable.Rows.Count > 0)
                return OracleBD.DataTable.Rows[0]["num_sec"].ToString().Trim();
            else
                return "0";
        }

        public string SQLListadoSemestresPostgrados(string strNSSubDepto)
        {
            strSql = "select distinct a.num_sec, a.resumido, a.descripcion, a.fecha_inicio " +
                     "from semestres a, semestres_internet b, paralelos c " +
                     "where a.fecha_inicio >= to_date('01/01/1998','dd/mm/yyyy') " +
                     "and a.num_sec > 0 " +
                     "and c.num_sec_subdepartamento = " + strNSSubDepto + " " +
                     "and a.num_sec = b.num_sec_semestre " +
                     "and c.num_sec_semestre = a.num_sec " +
                     "order by fecha_inicio desc";
            return strSql;
        }

        public string SQLBuscarAulasLibres(bool VerPlantillaAcad, bool VerSAUUsuarios, string strLogin, string strNSCarrera, string strNSSemestre, int intDia, string strDia, string strNSGrupo, string strHoraInicio, string strHoraFin, string strFechaInicio, string strFechaFin, int intCupo, bool bCambioCupo, string strNSAsignacionActual, string strCaracteristicas)
        {
            strSql = " SELECT distinct C.NUM_SEC_AULA, D.CODIGO_AULA||' - Cap.'||D.CAPACIDAD AULA " +
                     " FROM SAU_AULAS_GRUPOS A, SAU_AULAS D " +
                     " , (" +
                     " select a.num_sec_aula" +
                     " from SAU_AULAS a ";
            if (VerPlantillaAcad)
            {
                strSql += ", ( " +
                        "select a.num_sec_aula, count(distinct a.NUM_SEC_HORA) num_horas " +
                        "FROM SAU_PLANTILLAS_PROGRAMACION a, sau_horas b " +
                        "WHERE a.NUM_SEC_CARRERA = " + strNSCarrera + " " +
                        "AND a.DIA = " + intDia.ToString().Trim() + " " +
                        "AND a.NUM_SEC_SEMESTRE = " + strNSSemestre + " " +
                        "and b.NUM_SEC_GRUPO = " + strNSGrupo + " " +
                        "AND b.HORA_INICIO >= " + strHoraInicio + " " +
                        "AND b.HORA_FIN <= " + strHoraFin + " " +
                        "and a.num_sec_hora = b.num_sec_hora " +
                        "group by a.num_sec_aula " +
                        "having count(distinct a.NUM_SEC_HORA) = " +
                        "(SELECT count(distinct NUM_SEC_HORA) num_horas_requeridas " +
                        "FROM SAU_HORAS " +
                        "WHERE NUM_SEC_GRUPO = " + strNSGrupo + " " +
                        "AND HORA_INICIO >= " + strHoraInicio + " " +
                        "AND HORA_FIN <= " + strHoraFin + ") " +
                        ") b ";
            }
            if (VerSAUUsuarios)
            {
                strSql += ", (SELECT NUM_SEC_AULA FROM SAU_USUARIOS_AULAS " +
                          "WHERE USUARIO = '" + strLogin + "') c ";
            }
            strSql += " WHERE a.ESTADO_AULA = 1 ";
            if (intCupo > 0)
            {
                strSql += "AND a.CAPACIDAD >= " + intCupo.ToString().Trim() + " ";
            }
            if (VerPlantillaAcad)
            {
                strSql += "AND a.NUM_SEC_AULA = b.NUM_SEC_AULA ";
            }
            if (VerSAUUsuarios)
            {
                strSql += "AND a.NUM_SEC_AULA = c.NUM_SEC_AULA ";
            }
            strSql += " MINUS" +
                    " SELECT /* UCBADMIN.IX_SAU_ASIGNACIONES_DET_2 */  /* UCBADMIN.IX_SAU_ASIGNACIONE_1 */ " +
                    " distinct A.NUM_SEC_AULA" +
                    " FROM SAU_ASIGNACIONES_DETALLES A, SAU_ASIGNACIONES B ";
            switch (intDia)
            {
                case 0: // De lunes a viernes
                    strSql += " WHERE LOWER(TRIM(TO_CHAR(A.FECHA,'DAY','NLS_DATE_LANGUAGE=SPANISH'))) not in ('sábado','sabado','domingo') ";
                    break;
                case 10: // De lunes a sábado 
                    strSql += " WHERE LOWER(TRIM(TO_CHAR(A.FECHA,'DAY','NLS_DATE_LANGUAGE=SPANISH'))) <> 'domingo' ";
                    break;
                default:
                    strSql += " WHERE LOWER(TRIM(TO_CHAR(A.FECHA,'DAY','NLS_DATE_LANGUAGE=SPANISH'))) like '" + strDia.ToLower().Replace("é", "%").Replace("á", "%") + "' ";
                    break;
            }
            strSql += " AND A.FECHA >= TO_DATE('" + strFechaInicio + "','DD/MM/RRRR')" +
                    " AND A.FECHA <= TO_DATE('" + strFechaFin + "','DD/MM/RRRR') " +
                    " AND ((A.HORA_INICIO >= " + strHoraInicio + " And A.HORA_FIN <= " + strHoraFin + ") " +
                    " OR (A.HORA_INICIO <= " + strHoraInicio + " AND A.HORA_FIN >= " + strHoraFin + ") " +
                    " OR (A.HORA_INICIO < " + strHoraFin + " AND A.HORA_FIN > " + strHoraInicio + "))" +
                    " AND B.ESTADO_ASIGNACION in (1,3) " +
                    " AND A.ESTADO IN (1,2) ";
            if (bCambioCupo)
            {
                strSql += " AND B.NUM_SEC_ASIGNACION <> " + strNSAsignacionActual + " ";
            }
            strSql += " AND B.NUM_SEC_ASIGNACION = A.NUM_SEC_ASIGNACION" +
                    " ) C" +
                    " , (" +
                    " select c.num_sec_grupo, c.num_sec_aula " +
                    " from sau_aulas a, sau_grupos b, sau_aulas_grupos c, " +
                    " (select num_sec_aula, max(fecha) fecha_max " +
                    " from sau_aulas_grupos where fecha <= to_date('" + strFechaInicio + "','dd/mm/rrrr') " +
                    " group by num_sec_aula) d " +
                    " where b.estado_grupo = 1" +
                    " and b.num_sec_grupo = c.num_sec_grupo " +
                    " and a.num_sec_aula = c.num_sec_aula " +
                    " and c.num_sec_aula = d.num_sec_aula " +
                    " and c.fecha = d.fecha_max " +
                    " ) grupo_actual " +
                    " WHERE C.NUM_SEC_AULA = A.NUM_SEC_AULA  " +
                    " AND A.NUM_SEC_GRUPO = " + strNSGrupo + " " +
                    " and grupo_actual.num_sec_aula = a.num_sec_aula " +
                    " and grupo_actual.num_sec_grupo = a.num_sec_grupo" +
                    " AND C.NUM_SEC_AULA = D.NUM_SEC_AULA ";
            if (strCaracteristicas == "Ninguna")
            {
                strSql += " ORDER BY AULA";
            }
            return strSql;
        }

        public DataTable DTDatosAsignacionAulas(string strNSSemestre, string strNSSubDepartamento, string strNSMateria)
        {
            strSql = "select b.resumido sem, c.nombre depto, d.sigla||'  '||d.nombre materia " +
                    ", to_char(b.fecha_inicio,'dd/mm/yyyy') f_sem_ini " +
                    ", to_char(b.fecha_fin,'dd/mm/yyyy') f_sem_fin " +
                    ", decode(trunc(sysdate) - trunc(b.fecha_inicio),abs(trunc(sysdate) - trunc(b.fecha_inicio)) " +
                    ", to_char(sysdate,'dd/mm/yyyy') " +
                    ", to_char(b.fecha_inicio,'dd/mm/yyyy')) fecha_menor " +
                    ", 3 estado " +
                    "from semestres b, gen_subdepartamentos c, materias d " +
                    "where b.num_sec = " + strNSSemestre + " " +
                    "and c.num_sec_subdepartamento = " + strNSSubDepartamento + " " +
                    "and d.num_sec = " + strNSMateria;
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }

        public string SemestresDictadosDocente(string NSPersona)
        {
            strSql = "select s.num_sec num_sec_semestre, s.descripcion semestre, s.fecha_inicio " +
                     "from paralelos p, semestres s, semestres_internet si  " +
                     "where p.num_sec_docente = " + NSPersona + " " +
                     "and si.permitir_ver_horarios_doc = 1  " +
                     "and s.fecha_inicio > to_date('31/12/1997', 'dd/mm/yyyy')  " +
                     "and p.num_sec_semestre = s.num_sec  " +
                     "and s.num_sec = si.num_sec_semestre  " +
                     "group by s.num_sec, s.descripcion, s.fecha_inicio " +
                     "order by s.fecha_inicio desc";
            return strSql;
        }

        public DataTable DTSemestreAnterior(string strNSSem)
        {
            strSql = " select num_sec, resumido, descripcion";
            strSql += " from semestres";
            strSql += " where fecha_inicio < (select fecha_inicio from semestres where num_sec = " + strNSSem + ")";
            strSql += " and num_sec_subunidad = (select num_sec_subunidad from semestres where num_sec = " + strNSSem + ")";
            strSql += " and tipo = 1";
            strSql += " order by fecha_inicio desc ";
            DataTable dt = new DataTable();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }

        public long Ver_Semestre_Anterior(string strCon, string strNSSem)
        {
            long lngNSSemAnterior = 0;
            strSql = " select num_sec, resumido, descripcion";
            strSql += " from semestres";
            strSql += " where fecha_inicio < (select fecha_inicio from semestres where num_sec = " + strNSSem + ")";
            strSql += " and num_sec_subunidad = (select num_sec_subunidad from semestres where num_sec = " + strNSSem + ")";
            strSql += " and tipo = 1";
            strSql += " order by fecha_inicio desc ";
            DataTable dt = new DataTable();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            if (dt.Rows.Count > 0)
            {
                DataRow dr0 = dt.Rows[0];
                lngNSSemAnterior = Convert.ToInt64(dr0["num_sec"].ToString());
            }
            dt.Dispose();
            return lngNSSemAnterior;
        }

        public string Determinar_Semestre_Activo()
        {
            strSql = "select a.num_sec " +
                     "from semestres a " +
                     "where a.activo = 1 " +
                     "and a.num_sec_subunidad = " + _num_sec_subunidad;

            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            if (OracleBD.DataTable.Rows.Count > 0)
                return OracleBD.DataTable.Rows[0]["num_sec"].ToString().Trim();
            else
                return "0";
        }

        public DataTable Determinar_Fechas_Semestre()
        {
            strSql = "select to_char(a.fecha_inicio,'dd/mm/rrrr') f_ini, to_char(a.fecha_fin,'dd/mm/rrrr') f_fin " +
                     "from semestres a " +
                     "where a.num_sec_subunidad = " + _num_sec_subunidad;

            if(_num_sec > 0)
            {
                strSql += "and a.num_sec = " + _num_sec;
            }   
            else
            {
                strSql += "and a.activo = 1 ";
            } 
            
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }
        
        public string SQLListaSemestres(string strNSSubunidad)
        {
            strSql = "select num_sec, descripcion, resumido  " +
                     "from semestres  " +
                     "where num_sec <> 0  " +
                     "and num_sec_subunidad = " + strNSSubunidad + " " +
                     "order by activo, fecha_inicio desc";
            return strSql;
        }

        public void DeterminarFechasListaSemestre(string strListaSem, string strNSSubUnidad, ref string strFechaInicio, ref string strFechaFin)
        {
            strSql = "select to_char(min(fecha_inicio), 'dd/mm/yyyy'), to_char(max(fecha_fin), 'dd/mm/yyyy') " +
                     "from semestres  " +
                     "where num_sec in (" + strListaSem + ") " +
                     "and num_sec_subunidad = " + strNSSubUnidad;

            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();

            if (OracleBD.DataTable.Rows.Count == 0)
            {
                strFechaInicio = "01/01/1900";
                strFechaFin = "01/01/1900";
            }
            else
            {
                strFechaInicio = OracleBD.DataTable.Rows[0][0].ToString();
                strFechaFin = OracleBD.DataTable.Rows[0][1].ToString();
            }
        }

        public string SQLListaSemestresPorCarrera(string strNSSubDepartamento)
        {
            strSql = "select s.num_sec, s.descripcion semestre, s.fecha_inicio " +
                    "from gen_subdepartamentos c, paralelos p, semestres s " +
                    "where c.tipo in (4,5) " +
                    "and trunc(s.fecha_inicio) >= to_date('01/01/2000', 'dd/mm/yyyy') " +
                    "and p.cupo > 0 " +
                    "and c.num_sec_subdepartamento = " + strNSSubDepartamento + " " +
                    "and p.num_alumnos_inscritos > 0 " +
                    "and p.num_sec_subdepartamento = c.num_sec_subdepartamento " +
                    "and p.num_sec_semestre = s.num_sec " +
                    "group by s.num_sec, s.descripcion, s.fecha_inicio " +
                    "order by s.fecha_inicio desc";
            return strSql;
        }

        public DataTable DTPorcentajeAvanceSemestre()
        {
            strSql = "select round(nvl(fecha_fin,sysdate)-nvl(fecha_inicio,sysdate),2) dias_academicos, round(trunc(sysdate)-nvl(fecha_inicio,sysdate),2) dias_transcurridos " +
                     "from semestres " +
                     "where num_sec = " + _num_sec.ToString().Trim();

            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }

        public string SemesteIngresoPregrado(string strNSPersona)
        {
            strSql = "select '('||s.resumido||') '||s.descripcion semestre " +
                     "from acad_ingresos_pregrado ip, semestres s " +
                     "where ip.num_sec_persona = " + strNSPersona + " " +
                     "and ip.activo = 1 " +
                     "and ip.num_sec_semestre = s.num_sec";

            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            if (OracleBD.DataTable.Rows.Count > 0)
                return OracleBD.DataTable.Rows[0]["semestre"].ToString().Trim();
            else
                return "-";
        }

        public string SQLListadoSemestresMenosEnviado(string strNSSemestreEnviado, string strNSSubUnidad)
        {
            strSql = "select num_sec, resumido, descripcion " +
                    "from semestres " +
                    "where num_sec <> " + strNSSemestreEnviado + " " +
                    "and num_sec_subunidad = " + strNSSubUnidad + " " +
                    "and trunc(fecha_inicio) >= to_date('01/01/2000', 'dd/mm/yyyy') " +
                    "and (tipo, substr(resumido,1,1)) in " +
                    "( " +
                      "select tipo, substr(resumido,1,1) " +
                    "  from semestres " +
                    "  where num_sec = " + strNSSemestreEnviado + " " +
                    ") " +
                    "order by fecha_inicio desc";
            return strSql;
        }

        public DataTable dtSemestres()
        {
            strSql="select s.num_sec, s.fecha_inicio, s.resumido sem "+
                    "from semestres s "+
                    ", (select distinct s.num_sec_semestre, f.num_sec_fecha, f.tipo, s.fecha fsem, e.fecha fusr "+
                    "   , CASE WHEN f.control = 1 AND(sysdate >= s.fecha OR sysdate >= e.fecha) THEN 1 "+
                    "     ELSE "+
                    "       CASE WHEN f.control = 2 AND(sysdate <= s.fecha OR sysdate <= e.fecha) THEN 1 "+
                    "       ELSE 0 "+
                    "      END "+
                    "     END as f_permitida "+
                    "   from gen_fechas f, gen_fechas_semestres s, gen_fechas_sem_extemp e "+
                    "   where f.num_sec_subunidad = 11 "+
                    "   and f.codigo = 803000100 "+
                    "   and s.num_sec_fecha = f.num_sec_fecha "+
                    "   and s.num_sec_semestre = e.num_sec_semestre(+) "+
                    "   and s.num_sec_fecha = e.num_sec_fecha(+) "+
                    "   and e.num_sec_usuario(+) = 0 "+
                    "  ) fi "+
                    ", (select distinct s.num_sec_semestre, f.num_sec_fecha, f.tipo, s.fecha fsem, e.fecha fusr "+
                    "   , CASE WHEN f.control = 1 AND(sysdate >= s.fecha OR sysdate >= e.fecha) THEN 1 "+
                    "     ELSE "+
                    "       CASE WHEN f.control = 2 AND(sysdate <= s.fecha OR sysdate <= e.fecha) THEN 1 "+
                    "       ELSE 0 "+
                    "       END "+
                    "     END as f_permitida "+
                    "   from gen_fechas f, gen_fechas_semestres s, gen_fechas_sem_extemp e "+
                    "   where f.num_sec_subunidad = 11 "+
                    "   and f.codigo = 803000105 "+
                    "   and s.num_sec_fecha = f.num_sec_fecha "+
                    "   and s.num_sec_semestre = e.num_sec_semestre(+) "+
                    "   and s.num_sec_fecha = e.num_sec_fecha(+) "+
                    "   and e.num_sec_usuario(+) = 0 "+
                    "  ) ff "+
                    "where s.num_sec_subunidad = 11 "+
                    "and s.num_sec = fi.num_sec_semestre "+
                    "and s.num_sec = ff.num_sec_semestre "+
                    "and fi.f_permitida = 1 "+
                    "and ff.f_permitida = 1 "+
                    "order by s.fecha_inicio ";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }
        #endregion

    }
}