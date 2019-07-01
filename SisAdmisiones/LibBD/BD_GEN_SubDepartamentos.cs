using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using nsiBD_Interfaces;
using nsGEN_OracleBD;
using nsGEN_Mensajes;
using nsGEN_Cadenas;

namespace nsBD_GEN
{
    // Creado por: Milco Cortez; Fecha: 11/05/2015
    // Ultima modificación: Ignacio Rios;  Fecha:29/04/2019
    // Descripción: Clase referente a la tabla GEN_SUBDEPARTAMENTOS
    public class BD_GEN_SubDepartamentos
    {
        #region Variables Locales
        GEN_OracleBD OracleBD = new GEN_OracleBD();
        GEN_Mensajes libMensajes = new GEN_Mensajes();
        GEN_Cadenas libCadenas = new GEN_Cadenas();

        private string strSql = string.Empty;
        #endregion

        #region Atributos
        // Campos de la tabla GEN_SUBDEPARTAMENTOS
        private long _numsecsubdepartamento = 0;
        private long _numsecdepartamento = 0;
        private string _nombre = string.Empty;
        private string _resumido = string.Empty;
        private int _tipo = 0;
        private int _activo = 0;
        private string _fechacreacion = string.Empty;
        private long _numsecdefcred = 0;
        private string _codigocuenta = string.Empty;
        private long _numsecanaliticocc = 0;
        private int _ordenplanestrategico = 0;
        private string _fecharegistro = string.Empty;
        private string _usuarioregistro = string.Empty;
        private long _numsecusuarioregistroapp = 0;
        private string _nombredefcrednuevo = string.Empty;

        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        public long NumSecSubDepartamento
        {
            get { return _numsecsubdepartamento; }
            set { _numsecsubdepartamento = value; }
        }
        public long NumSecDepartamento
        {
            get { return _numsecdepartamento; }
            set { _numsecdepartamento = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string Resumido
        {
            get { return _resumido; }
            set { _resumido = value; }
        }
        public int Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
        public int Activo
        {
            get { return _activo; }
            set { _activo = value; }
        }
        public string FechaCreacion
        {
            get { return _fechacreacion; }
            set { _fechacreacion = value; }
        }
        public long NumSecDefCred
        {
            get { return _numsecdefcred; }
            set { _numsecdefcred = value; }
        }
        public string CodigoCuenta
        {
            get { return _codigocuenta; }
            set { _codigocuenta = value; }
        }
        public long NumSecAnaliticoCC
        {
            get { return _numsecanaliticocc; }
            set { _numsecanaliticocc = value; }
        }
        public int OrdenPlanEstrategico
        {
            get { return _ordenplanestrategico; }
            set { _ordenplanestrategico = value; }
        }

        public string FechaRegistro
        {
            get { return _fecharegistro; }
        }
        public string UsuarioRegistro
        {
            get { return _usuarioregistro; }
        }
        public long NumSecUsuarioRegistroApp
        {
            get { return _numsecusuarioregistroapp; }
            set { _numsecusuarioregistroapp = value; }
        }
       
        public string NombreDefCredNuevo
        {
            get { return _nombredefcrednuevo; }
            set { _nombredefcrednuevo = value; }
        }


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
        public BD_GEN_SubDepartamentos()
        {
            _numsecsubdepartamento = 0;
            _numsecdepartamento = 0;
            _nombre = string.Empty;
            _resumido = string.Empty;
            _tipo = 0;
            _activo = 0;
            _fechacreacion = string.Empty;
            _numsecdefcred = 0;
            _codigocuenta = string.Empty;
            _numsecanaliticocc = 0;
            _ordenplanestrategico = 0;
            _fecharegistro = string.Empty;
            _usuarioregistro = string.Empty;
            _numsecusuarioregistroapp = 0;

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
                int intNumSqls = 1;
                string[] strSqls = {"",""};

                OracleBD.MostrarError = false;
                OracleBD.StrConexion = _strconexion;
                if (_numsecdefcred <= 0)
                { 
                    // crear nuevo def cred
                    intNumSqls = 2;
                    _numsecdefcred = OracleBD.Generar_NumSec("caja_definiciones_creditos_sec");
                    //strSqls[0] = bdCAJA_Definiciones_Creditos.Sql_Insertar(_numsecdefcred.ToString(), _nombredefcrednuevo, "2");
                }

                strSql = " insert into gen_subdepartamentos (num_sec_subdepartamento, num_sec_departamento, nombre, resumido";
                strSql += " , tipo, activo, fecha_creacion, codigo_cuenta, orden_plan_estrategico, num_sec_def_cred, num_sec_analitico_cc";
                strSql += " , num_sec_usuario_reg) values";
                strSql += " ( gen_subdepartamentos_sec.nextval";
                strSql += " , " + _numsecdepartamento.ToString();
                strSql += " , '" + _nombre.Trim() + "'";
                strSql += " , '" + _resumido.Trim() + "'";
                strSql += " , " + _tipo.ToString();
                strSql += " , " + _activo.ToString();
                strSql += " , to_date('" + _fechacreacion.Trim() + "','dd/mm/rrrr')";
                strSql += " , '" + _codigocuenta.Trim() + "'";
                strSql += " , " + _ordenplanestrategico.ToString();
                strSql += " , " + _numsecdefcred.ToString();
                strSql += " , " + _numsecanaliticocc.ToString();
                strSql += ", " + _numsecusuarioregistroapp.ToString();
                strSql += " )";

                strSqls[intNumSqls-1] = strSql;

                OracleBD.NumSqls = intNumSqls;
                OracleBD.ListaSqls = strSqls;
                OracleBD.EjecutarSqlsTrans();

                _mensaje = OracleBD.Mensaje;
                blOperacionCorrecta = !OracleBD.Error;
                if (OracleBD.Error)
                    _mensaje = "No fue posible insertar el dato. Se encontró un error al insertar en la tabla GEN_SUBDEPARTAMENTOS. " + _mensaje;
            }
            return blOperacionCorrecta;
        }

        public bool Modificar()
        {
            bool blOperacionCorrecta = false;
            blOperacionCorrecta = Validar_Campos(2);
            if (blOperacionCorrecta)
            {
                strSql = " update gen_subdepartamentos set";
                strSql += " num_sec_departamento = " + _numsecdepartamento.ToString();
                strSql += " , nombre = '" + _nombre.Trim() + "'";
                strSql += " , resumido = '" + _resumido.Trim() + "'";
                strSql += " , tipo = " + _tipo.ToString();
                strSql += " , activo = " + _activo.ToString();
                strSql += " , fecha_creacion = to_date('" + _fechacreacion.Trim() + "','dd/mm/rrrr')";
                strSql += " , codigo_cuenta = '" + _codigocuenta.Trim() + "'";
                strSql += " , orden_plan_estrategico = " + _ordenplanestrategico.ToString();
                strSql += " , num_sec_def_cred = " + _numsecdefcred.ToString();
                strSql += " , num_sec_analitico_cc = " + _numsecanaliticocc.ToString();
                strSql += " , usuario_registro = user";
                strSql += " , fecha_registro = sysdate";
                strSql += " , num_sec_usuario_reg = " + _numsecusuarioregistroapp.ToString();
                strSql += " where num_sec_subdepartamento = " + _numsecsubdepartamento.ToString();
                strSql += " and (num_sec_departamento <> " + _numsecdepartamento.ToString();
                strSql += " or nombre <> '" + _nombre.Trim() + "'";
                strSql += " or resumido <> '" + _resumido.Trim() + "'";
                strSql += " or tipo <> " + _tipo.ToString();
                strSql += " or activo <> " + _activo.ToString();
                strSql += " or fecha_creacion <> to_date('" + _fechacreacion.Trim() + "','dd/mm/rrrr')";
                strSql += " or codigo_cuenta <> '" + _codigocuenta.Trim() + "'";
                strSql += " or orden_plan_estrategico <> " + _ordenplanestrategico.ToString();
                strSql += " or num_sec_def_cred <> " + _numsecdefcred.ToString();
                strSql += " or num_sec_analitico_cc <> " + _numsecanaliticocc.ToString();
                strSql += " )";

                OracleBD.MostrarError = false;
                OracleBD.StrConexion = _strconexion;
                OracleBD.Sql = strSql;
                OracleBD.EjecutarSqlTrans();

                _mensaje = OracleBD.Mensaje;
                blOperacionCorrecta = !OracleBD.Error;
                if (OracleBD.Error)
                    _mensaje = "No fue posible actualizar el dato. Se encontró un error al actualizar en la tabla GEN_SUBDEPARTAMENTOS. " + _mensaje;
            }
            return blOperacionCorrecta;
        }

        public bool Borrar()
        {
            bool blOperacionCorrecta = false;
            strSql = " delete gen_subdepartamentos ";
            strSql += " where num_sec_subdepartamento = " + _numsecsubdepartamento.ToString();

            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();

            _mensaje = OracleBD.Mensaje;
            blOperacionCorrecta = !OracleBD.Error;
            if (OracleBD.Error)
                _mensaje = "No fue posible borrar el dato. Se encontró un error al eliminar en la tabla GEN_SUBDEPARTAMENTOS. " + _mensaje;
            return blOperacionCorrecta;
        }

        public bool Ver()
        {
            bool blEncontrado = false;
            string strSql = string.Empty;
            if (!string.IsNullOrEmpty(_numsecsubdepartamento.ToString()))
            {
                strSql = "select num_sec_subdepartamento, num_sec_departamento, nombre, resumido, tipo, activo, " +
                         "fecha_creacion, codigo_cuenta, orden_plan_estrategico, num_sec_def_cred, num_sec_analitico_cc, " +
                         "num_sec_usuario_reg, fecha_registro, usuario_registro " +
                         "from gen_subdepartamentos " +
                         "where num_sec_subdepartamento = " + _numsecsubdepartamento.ToString();

                DataTable dt = new DataTable();
                OracleBD.MostrarError = false;
                OracleBD.StrConexion = _strconexion;
                OracleBD.Sql = strSql;
                OracleBD.sqlDataTable();
                dt = OracleBD.DataTable;
                if (dt.Rows.Count > 0)
                {
                    blEncontrado = true;
                    DataRow dr = dt.Rows[0];
                    _numsecsubdepartamento = Convert.ToInt64(dr["num_sec_subdepartamento"].ToString());
                    _numsecdepartamento = Convert.ToInt64(dr["num_sec_departamento"].ToString());
                    _nombre = dr["nombre"].ToString();
                    _resumido = dr["resumido"].ToString();
                    _tipo = Convert.ToInt16(dr["tipo"].ToString());
                    _activo = Convert.ToInt16(dr["activo"].ToString());
                    _fechacreacion = dr["fecha_creacion"].ToString();
                    _numsecdefcred = Convert.ToInt64(dr["num_sec_def_cred"].ToString());
                    _codigocuenta = dr["codigo_cuenta"].ToString(); ;
                    _numsecanaliticocc = Convert.ToInt64(dr["num_sec_analitico_cc"].ToString());
                    _ordenplanestrategico = Convert.ToInt16(dr["orden_plan_estrategico"].ToString()); ;
                    _fecharegistro = dr["fecha_registro"].ToString();
                    _usuarioregistro = dr["usuario_registro"].ToString();
                    _numsecusuarioregistroapp = Convert.ToInt64(dr["num_sec_usuario_reg"].ToString());
                }
                dt.Dispose();
            }
            if (!blEncontrado)
            {
                _numsecsubdepartamento = 0;
                _numsecdepartamento = 0;
                _nombre = string.Empty;
                _resumido = string.Empty;
                _tipo = 0;
                _activo = 0;
                _fechacreacion = string.Empty;
                _numsecdefcred = 0;
                _codigocuenta = string.Empty;
                _numsecanaliticocc = 0;
                _ordenplanestrategico = 0;
                _fecharegistro = string.Empty;
                _usuarioregistro = string.Empty;
                _numsecusuarioregistroapp = 0;
            }
            return blEncontrado;
        }

        public string Query_Grid_ABM1(string strNSDepartamento)
        {
            string strSql = string.Empty;
            strSql = " select a.num_sec_subdepartamento, a.resumido, a.nombre, b.descripcion tipo_str";
            strSql += " , decode(a.activo,1,'Si','No') activo_str";
            strSql += " , 'Seleccionar' seleccionar ";
            strSql += " from gen_subdepartamentos a, dominios b";
            strSql += " where a.num_sec_departamento = " + strNSDepartamento;
            strSql += " and b.dominio = 'SAM_TIPO_SUBDEPTO'";
            strSql += " and b.valor = a.tipo";
            strSql += " order by nombre";
            return strSql;
        }

        public string Query_DropDownList1(string strNSDepartamento, bool blSoloActivos)
        {
            string strSql = string.Empty;
            strSql = " select num_sec_subdepartamento, nombre";
            strSql += " from gen_subdepartamentos where num_sec_departamento = " + strNSDepartamento;
            if (blSoloActivos)
                strSql += " and activo = 1";
            strSql += " order by nombre";
            return strSql;
        }

        public string Query_DropDownList2(string strNSSubUnidad, string strTipos, bool blSoloActivos, bool blIncluirNulo)
        {
            string strSql = string.Empty;

            if (blIncluirNulo)
            {
                strSql = "select num_sec_subdepartamento, nombre, '-' tipo_str, '---' nombre_str, 1 orden";
                strSql += " from gen_subdepartamentos where num_sec_subdepartamento = 0";
                strSql += " UNION";
            }
            strSql += " select a.num_sec_subdepartamento, a.nombre, d.descripcion tipo_str";
            strSql += " , a.nombre||' ['||d.descripcion||']' nombre_str,2 orden";
            strSql += " from gen_subdepartamentos a, gen_departamentos b, gen_facultades c, dominios d";
            strSql += " where c.num_sec_subunidad = " + strNSSubUnidad;
            strSql += " and b.num_sec_facultad = c.num_sec_facultad";
            strSql += " and a.num_sec_departamento = b.num_sec_departamento";
            if (!string.IsNullOrEmpty(strTipos))
                strSql += " and a.tipo in (" + strTipos + ")";
            else
                strSql += " and a.tipo in (1,2,3,4,5,6)";
            if (blSoloActivos)
                strSql += " and a.activo = 1";
            strSql += " and d.dominio = 'SAM_TIPO_SUBDEPTO'";
            strSql += " and a.tipo = d.valor";
            strSql += " order by orden, nombre";

            return strSql;
        }

        //public string Query_DropDownList3(string strNSSubUnidad, string strTipos, bool blSoloActivos, bool blIncluirNulo, string strNSUsuario, bool blAccesoTodosDeptos)


        public string Query_DropDownList3(string strNSSubUnidad, string strTipos, bool blSoloActivos, int intIncluirTodos_Nulo, string strNSUsuario, bool blAccesoTodosDeptos, long lngNSSemestre)
        {
            // lista de subdepartamentos con control de usuario
            // intIncluirTodos_Nulo:  0:no incluir, 1:incluir TODOS, 2:incluir NULO

            string strSql = string.Empty;

            if (intIncluirTodos_Nulo > 0)
            {
                if (intIncluirTodos_Nulo == 2)
                    strSql = "select num_sec_subdepartamento, nombre, '-' tipo_str, '---' nombre_str, 1 orden";
                else
                    strSql = "select num_sec_subdepartamento, '[TODOS]' nombre, '-' tipo_str, '[TODOS]' nombre_str, 1 orden";

                strSql += " from gen_subdepartamentos where num_sec_subdepartamento = 0";
                strSql += " UNION";
            }
            strSql += " select a.num_sec_subdepartamento, UPPER(a.nombre) nombre, d.descripcion tipo_str";
            strSql += " , a.nombre||' ['||d.descripcion||']' nombre_str,2 orden";
            strSql += " from gen_subdepartamentos a, gen_departamentos b, gen_facultades c, dominios d";
            if (lngNSSemestre > 0)
            {
                strSql += " , (";
                strSql += " select distinct a.num_sec_subdepartamento";
                strSql += " from paralelos a";
                strSql += " where a.num_sec_semestre = " + lngNSSemestre.ToString();
                strSql += " ) p";
            }
            if (!blAccesoTodosDeptos)
            {
                strSql += " , (select a.num_sec_subdepartamento";
                strSql += "   from sam_usuarios_subdeptos a";
                strSql += "   where a.num_sec_usuario = " + strNSUsuario;
                strSql += "   ) usd";
            }

            strSql += " where c.num_sec_subunidad = " + strNSSubUnidad;
            strSql += " and b.num_sec_facultad = c.num_sec_facultad";
            strSql += " and a.num_sec_departamento = b.num_sec_departamento";
            if (!string.IsNullOrEmpty(strTipos))
                strSql += " and a.tipo in (" + strTipos + ")";
            else
                strSql += " and a.tipo in (1,2,3,4,5,6)";
            if (blSoloActivos)
                strSql += " and a.activo = 1";
            strSql += " and d.dominio = 'SAM_TIPO_SUBDEPTO'";
            strSql += " and a.tipo = d.valor";

            if (lngNSSemestre > 0)
                strSql += " and a.num_sec_subdepartamento = p.num_sec_subdepartamento";
            if (!blAccesoTodosDeptos)
                strSql += " and a.num_sec_subdepartamento = usd.num_sec_subdepartamento";

            strSql += " order by orden, nombre";

            return strSql;
        }

        public string Query_Carreras_Postgrados_DeptosAcad(string strNSSubUnidad, string strTipos, bool blSoloActivos, int intIncluirTodos_Nulo, string strNSUsuario, bool blAccesoTodosDeptos, int intModoSACAD, long lngNSSemestre)
        {
            // lista de subdepartamentos con control de usuario
            // intIncluirTodos_Nulo:  0:no incluir, 1:incluir TODOS, 2:incluir NULO

            string strSql = string.Empty;

            if (intIncluirTodos_Nulo > 0)
            {
                if (intIncluirTodos_Nulo == 2)
                    strSql = "select num_sec_subdepartamento, nombre, '-' tipo_str, '---' nombre_str, 1 orden";
                else
                    strSql = "select num_sec_subdepartamento, '[TODOS]' nombre, '-' tipo_str, '[TODOS]' nombre_str, 1 orden";

                strSql += " from gen_subdepartamentos where num_sec_subdepartamento = 0";
                strSql += " UNION";
            }
            strSql += " select a.num_sec_subdepartamento, UPPER(a.nombre) nombre, d.descripcion tipo_str";
            strSql += " , a.nombre||' ['||d.descripcion||']' nombre_str,2 orden";
            strSql += " from gen_subdepartamentos a, gen_departamentos b, gen_facultades c, dominios d";
            if (!blAccesoTodosDeptos)
            {
                strSql += " , (select a.num_sec_subdepartamento";
                strSql += "   from sam_usuarios_subdeptos a";
                strSql += "   where a.num_sec_usuario = " + strNSUsuario;
                strSql += "   ) usd";
            }

            if (lngNSSemestre > 0)
            {
                strSql += " , (";
                strSql += " select distinct a.num_sec_subdepartamento";
                strSql += " from paralelos a, alumnos_paralelos b";
                strSql += " where a.num_sec_semestre = " + lngNSSemestre.ToString();
                strSql += " and b.activo = 1";
                strSql += " and b.estado in (1,4,5,6,7)";
                strSql += " and a.num_sec = b.num_sec_paralelo ";
                strSql += " ) p";
            }

            strSql += " where c.num_sec_subunidad = " + strNSSubUnidad;
            strSql += " and b.num_sec_facultad = c.num_sec_facultad";
            strSql += " and a.num_sec_departamento = b.num_sec_departamento";
            if (!string.IsNullOrEmpty(strTipos))
                strSql += " and a.tipo in (" + strTipos + ")";
            else
                strSql += " and a.tipo in (1,2,3,4,5,6)";
            if (blSoloActivos)
                strSql += " and a.activo = 1";
            strSql += " and d.dominio = 'SAM_TIPO_SUBDEPTO'";
            strSql += " and a.tipo = d.valor";
            if (lngNSSemestre > 0)
                strSql += " and a.num_sec_subdepartamento = p.num_sec_subdepartamento";

            if (!blAccesoTodosDeptos)
                strSql += " and a.num_sec_subdepartamento = usd.num_sec_subdepartamento";

            strSql += " order by orden, nombre";

            return strSql;
        }

        #endregion

        #region Procedimientos y Funciones Locales

        private bool Validar_Campos(int axModoPantalla)
        {
            if (_numsecdepartamento <= 0)
            {
                _mensaje = "El num_sec_departamento debe ser mayor a 0.";
                return false;
            }

            if (_nombre.Trim().Length < 3 || _nombre.Trim().Length > 100)
            {
                _mensaje = "El nombre del subdepartamento debe contener entre 3 y 100 caracteres.";
                return false;
            }
            if (libCadenas.Texto_Contiene_Caracteres_Especiales(_nombre.Trim(), 3, 1))
            {
                _mensaje = "El nombre del subdepartamento no debe contener caracteres epeciales.";
                return false;
            }

            if (_resumido.Trim().Length < 3 || _resumido.Trim().Length > 10)
            {
                _mensaje = "El resumido del subdepartamento debe contener entre 3 y 10 caracteres.";
                return false;
            }
            if (libCadenas.Texto_Contiene_Caracteres_Especiales(_resumido.Trim(), 3, 1))
            {
                _mensaje = "El resumido del subdepartamento no debe contener caracteres epeciales.";
                return false;
            }

            if (_tipo < 0)
            {
                _mensaje = "El tipo debe ser un valor mayor o igual a 0.";
                return false;
            }

            if (!(_activo == 0 || _activo == 1))
            {
                _mensaje = "El activo debe ser 0 o 1.";
                return false;
            }

            if (_fechacreacion.Trim().Length > 0)
            {
                if (!libCadenas.Validar_Fecha_Hora(_fechacreacion.Trim(), 1))
                {
                    _mensaje = "La fecha de creación debe tener el formato DD/MM/AAAA.";
                    return false;
                }
            }

            if (_codigocuenta.Trim().Length < 1 || _codigocuenta.Trim().Length > 6)
            {
                _mensaje = "El código de cuenta debe contener entre 1 y 6 caracteres.";
                return false;
            }
            if (!libCadenas.Texto_Cumple_Expresion(_codigocuenta.Trim(), @"([0-9]+)$"))
            {
                _mensaje = "El código de cuenta no debe contener caracteres epeciales.";
                return false;
            }

            if (_numsecdefcred <= 0)
            {
                _mensaje = "El num_sec_def_cred debe ser un valor mayor a 0.";
                return false;
            }

            if (_numsecanaliticocc <= 0)
            {
                if (string.IsNullOrEmpty(_nombredefcrednuevo) || axModoPantalla==2)
                { 
                    _mensaje = "El num_sec_analitico_cc debe ser un valor mayor a 0.";
                    return false;
                }
            }

            if (_ordenplanestrategico <= 0)
            {
                _mensaje = "El orden_plan_estrategico debe ser un valor mayor a 0.";
                return false;
            }



            if (!Revisar_Repetido(axModoPantalla))
            {
                return false;
            }
            return true;
        }

        private bool Revisar_Repetido(int axModoPantalla)
        {
            strSql = " select * from gen_subdepartamentos";
            strSql += " where num_sec_departamento = " + _numsecdepartamento.ToString();
            if (axModoPantalla == 2)
            {
                strSql += " and num_sec_subdepartamento <> " + _numsecsubdepartamento.ToString();
                strSql += " and nombre = '" + _nombre + "')";
            }
            else
            {
                strSql += " and nombre = '" + _nombre + "')";
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
                if (axModoPantalla == 1)
                    _mensaje = "El dato que requiere insertar se encuentra repetido";
                else
                    _mensaje = "El dato que requiere modificar se encuentra repetido";

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

        /// <summary>
        /// Método para desplegar listado de subdepartamentos de acuerdo al la subunidad seleccionada y un tipo seleccionado
        /// </summary>
        /// <param name="NSSubUnidad">NUM_SEC_SUBUNIDAD</param>
        /// <param name="NSDepartamento">NUM_SEC_DEPARTAMENTO="0" TODOS</param>
        /// <param name="tipo">TIPO="" TODOS</param>
        /// <returns></returns>
        public DataTable ListaSubDepartamentosPorSubUnidad(string NSSubUnidad, string NSDepartamento, bool permitir_todos, string tipo)
        {
            strSql = "select sd.num_sec_subdepartamento, sd.nombre, " +
                    "dom.valor tipo_valor, dom.descripcion tipo_texto, sd.resumido " +
                    "from gen_subdepartamentos sd, gen_departamentos d, gen_facultades f, " +
                    "dominios dom " +
                    "where f.num_sec_subunidad = " + NSSubUnidad + " " +
                    "and sd.activo = 1 " +
                    "and d.activo = 1 ";
            if (NSDepartamento != "0")
                strSql += "and d.num_sec_departamento in (" + NSDepartamento + ") ";
            if (tipo != "")
                strSql += "and dom.valor in (" + tipo + ") ";
            strSql += "and dom.dominio = 'SAM_TIPO_SUBDEPTO' " +
                    "and f.num_sec_facultad = d.num_sec_facultad " +
                    "and d.num_sec_departamento = sd.num_sec_departamento " +
                    "and sd.tipo = dom.valor ";
            if (permitir_todos)
            {
                strSql += "union select -1, ' TODOS ' nombre, 0, '-', '-' from dual ";
            }
            strSql += "order by nombre";
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }

        public string SQLListadoSubDepartamentosPregrado(string NSSubUnidad, int strPermitirTodos, string strCarrerasUsuario, string strCon)
        {
            strSql = "select a.num_sec_subdepartamento, upper(a.nombre) subdepartamento " +
                    "from gen_subdepartamentos a, gen_departamentos b, gen_facultades c, gen_subunidades d " +
                    "where d.num_sec_subunidad = " + NSSubUnidad + " " +
                    "and a.tipo in (4,5) ";
            if (strPermitirTodos != 1)
            {
                strSql += "and a.num_sec_subdepartamento in (" + strCarrerasUsuario + ") ";
            }
            strSql += "and a.num_sec_departamento = b.num_sec_departamento " +
                    "and b.num_sec_facultad = c.num_sec_facultad " +
                    "and c.num_sec_subunidad = d.num_sec_subunidad " +
                    "order by a.nombre";
            return strSql;
        }

        public string SQLCarrerasProgramacionAcad(string NSSemestre, string CarrerasUsuario, int PermitirTodosDeptos)
        {
            strSql = "select distinct a.num_sec_subdepartamento, a.resumido||' - '||a.nombre carrera, a.nombre " +
                     "from gen_subdepartamentos a, paralelos b  " +
                     "where b.num_sec_semestre = " + NSSemestre + " " +
                     " and b.tipo in (1,5) " +
                     "and b.cupo > 0 " +
                     "and a.tipo in (4, 5) " +
                     "and a.activo = 1 ";
            if (PermitirTodosDeptos != 1)
            {
                strSql += "and a.num_sec_subdepartamento in (" + CarrerasUsuario + ") ";
            }
            strSql += "and b.num_sec_subdepartamento = a.num_sec_subdepartamento " +
                      "order by upper(a.nombre)";
            return strSql;
        }
        public DataTable DTCarrerasProgramacionAcad(string NSSemestre, string CarrerasUsuario, int PermitirTodosDeptos)
        {
            strSql = SQLCarrerasProgramacionAcad(NSSemestre, CarrerasUsuario, PermitirTodosDeptos);
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }
        public string CarrerasProgramacionAcad(string NSSemestre, string ModoAcademicoSACAD)
        {
            strSql = "select distinct a.num_sec_subdepartamento num_sec_carrera, a.resumido||' - '||a.nombre carrera, a.nombre " +
                     "from gen_subdepartamentos a, paralelos b " +
                     "where b.num_sec_semestre = " + NSSemestre + " " +
                     "and b.tipo in (1,5) " +
                     "and b.cupo > 0 ";
            if (ModoAcademicoSACAD == "2")
            {
                strSql += "and a.num_sec_subdepartamento = " + _numsecsubdepartamento.ToString().Trim() + " ";
            }
            else
            {
                strSql += "and b.operaciones_internet <> 4 ";
            }
            strSql += "and b.num_sec_subdepartamento = a.num_sec_subdepartamento " +
                      "order by a.nombre";
            return strSql;
        }

        public DataTable DTCarrerasProgramacionAcad(string NSSemestre, string ModoAcademicoSACAD)
        {
            strSql = CarrerasProgramacionAcad(NSSemestre, ModoAcademicoSACAD);
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }

        public string SQLSubDepartamentosPorSubUnidad(string NSSubUnidad, string NSDepartamento, bool permitir_todos, string tipo, bool carrera_general)
        {
            strSql = string.Empty;
            if (carrera_general)
            {
                strSql = " select sd.num_sec_subdepartamento, sd.nombre, 0, '-', '-', 2 orden " +
                         " from gen_subdepartamentos sd, gen_departamentos d, gen_facultades f " +
                         " where f.num_sec_subunidad = " + NSSubUnidad + " " +
                         " and sd.tipo = 9 " +
                         " and sd.nombre = 'CARRERA GENERAL' " +
                         " and sd.activo = 1" +
                         " and f.num_sec_facultad = d.num_sec_facultad " +
                         " and d.num_sec_departamento = sd.num_sec_departamento " +
                         " union ";
            }
            strSql += "select sd.num_sec_subdepartamento, sd.nombre, " +
                      "dom.valor tipo_valor, dom.descripcion tipo_texto, sd.resumido, 1 orden " +
                      "from gen_subdepartamentos sd, gen_departamentos d, gen_facultades f, " +
                      "dominios dom " +
                      "where f.num_sec_subunidad = " + NSSubUnidad + " " +
                      "and sd.activo = 1 " +
                      "and d.activo = 1 ";
            if (NSDepartamento != "0")
                strSql += "and d.num_sec_departamento = " + NSDepartamento + " ";
            if (tipo != "")
                strSql += "and dom.valor in (" + tipo + ") ";
            strSql += "and dom.dominio = 'SAM_TIPO_SUBDEPTO' " +
                    "and f.num_sec_facultad = d.num_sec_facultad " +
                    "and d.num_sec_departamento = sd.num_sec_departamento " +
                    "and sd.tipo = dom.valor ";
            if (permitir_todos)
            {
                strSql += "union select -1, ' TODOS ' nombre, 0, '-', '-', 3 orden from dual ";
            }
            strSql += "order by orden, nombre";
          
            return strSql;
        }
        public DataTable dtCarrerasInscripciones()
        {
            strSql = "select distinct a.num_sec_subdepartamento, a.resumido||' - '||a.nombre carrera, a.nombre " +
                     "from gen_subdepartamentos a, gen_departamentos b, gen_facultades c " +
                     " where a.tipo = 5" +
                     " and a.activo=1"+
                     " and c.num_sec_subunidad=11" +
                     " and c.num_sec_facultad = b.num_sec_facultad" +
                     " and b.num_sec_departamento = a.num_sec_departamento" +
                     " order by a.nombre";
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }

        public string strCarrerasSubdepto()
        {
            strSql = "SELECT num_sec FROM carreras WHERE num_sec_subdepartamento="+ _numsecsubdepartamento;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            string carrera = string.Empty;
            if (OracleBD.DataTable.Rows.Count>0)
            {
                carrera = OracleBD.DataTable.Rows[0][0].ToString();
            }
            return carrera;
        }
       
        #endregion
    }
}