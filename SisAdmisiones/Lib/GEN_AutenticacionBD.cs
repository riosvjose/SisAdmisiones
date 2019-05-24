using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using nsGEN_VarSession;
using nsGEN_OracleBD;
using nsGEN_Java;

namespace nsGEN_AutenticacionBD
{
    // Creado por: Milco Cortes; Fecha: 17/03/2015
    // Ultima modificación: Milco Cortes;  Fecha:22/09/2015
    // Descripción: Permite autenticar a un usuario de base de datos Oracle
    public class GEN_AutenticacionBD
    {
        #region Variables Locales
        GEN_VarSession axVarSes = new GEN_VarSession();
        GEN_Java libJava1 = new GEN_Java();
        GEN_OracleBD OracleBD = new GEN_OracleBD();
        private string strSql = string.Empty;
        #endregion

        #region Atributos
        private string _login = string.Empty;
        private string _password = string.Empty;
        private string _servidor = string.Empty;
        private int _tipopermitido = 0;
        private System.Web.UI.Page _pagina;
        private bool _mostrarerror = true;
        private bool _autenticado = false;
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;
        private long _numsec = 0;
        private string _usuario = string.Empty;
        private string _codigo_usuario = string.Empty;
        private bool _cambiopwd = false;
        private long _persona_numsec = 0;
        private string _persona_nombre = string.Empty;
        private string _persona_ci = string.Empty;
        private int _persona_sexo = 0;
        private int _persona_grupo = 0;
        private int _persona_tipo = 0;

        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string Servidor
        {
            get { return _servidor; }
            set { _servidor = value; }
        }
        public int TipoPermitido
        {
            get { return _tipopermitido; }
            set { _tipopermitido = value; }
        }
        public System.Web.UI.Page Pagina
        {
            get { return _pagina; }
            set { _pagina = value; }
        }
        public bool MostrarError
        {
            get { return _mostrarerror; }
            set { _mostrarerror = value; }
        }

        public bool Autenticado
        {
            get { return _autenticado; }
            set { _mostrarerror = value; }
        }
        public string Mensaje
        {
            get { return _mensaje; }
        }
        public string StrConexion
        {
            get { return _strconexion; }
        }
        public long NumSec
        {
            get { return _numsec; }
            set { _numsec = value; }
        }
        public string Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
        public string CodigoUsuario
        {
            get { return _codigo_usuario; }
            set { _codigo_usuario = value; }
        }
        public bool CambioPwd
        {
            get { return _cambiopwd; }
            set { _cambiopwd = value; }
        }
        public long Persona_NumSec
        {
            get { return _persona_numsec; }
        }
        public string Persona_Nombre
        {
            get { return _persona_nombre; }
        }
        public string Persona_CI
        {
            get { return _persona_ci; }
        }
        public int Persona_Sexo
        {
            get { return _persona_sexo; }
        }
        public int Persona_Grupo
        {
            get { return _persona_grupo; }
        }
        public int Persona_Tipo
        {
            get { return _persona_tipo; }
        }
        #endregion

        #region Constructores
        public GEN_AutenticacionBD()
        { 
            strSql = string.Empty;

            _login = string.Empty;
            _password = string.Empty;
            _servidor = string.Empty;
            _tipopermitido = 0;
            _mostrarerror = true;
            _autenticado = false;
            _mensaje = string.Empty;
            _strconexion = string.Empty;
            _numsec = 0;
            _usuario = string.Empty;
            _cambiopwd = false;
            _persona_numsec = 0;
            _persona_nombre = string.Empty;
            _persona_ci = string.Empty;
            _persona_sexo = 0;
            _persona_grupo = 0;
            _persona_tipo = 0;
        }
        #endregion

        #region Metodos
        public void AutenticarSAM()
        {
            bool blError = true;
            if (DatosCompletos())
            {
                if (UsuarioAutenticadoSAM())
                {
                    blError = false;
                }
            }
            if (!blError)
            {
                _autenticado = true;
                _mensaje = string.Empty;
            }
            else
            {
                _autenticado = false;
                _strconexion = string.Empty;
                _numsec = 0;
                _usuario = string.Empty;
                _cambiopwd = false;
                _persona_numsec = 0;
                _persona_nombre = string.Empty;
                _persona_ci = string.Empty;
                _persona_grupo = 0;
                _persona_tipo = 0;
                if (_mostrarerror && _mensaje != string.Empty) MostrarVentanaError();
            }
        }

        public void AutenticarADMSINF()
        {
            bool blError = true;
            if (DatosCompletos())
            {
                if (UsuarioAutenticadoADMSINF())
                {
                    blError = false;
                }
            }
            if (!blError)
            {
                _autenticado = true;
                _mensaje = string.Empty;
            }
            else
            {
                _autenticado = false;
                _strconexion = string.Empty;
                _numsec = 0;
                _usuario = string.Empty;
                _cambiopwd = false;
                _persona_numsec = 0;
                _persona_nombre = string.Empty;
                _persona_ci = string.Empty;
                _persona_grupo = 0;
                _persona_tipo = 0;
                if (_mostrarerror && _mensaje != string.Empty) MostrarVentanaError();
            }
        }

        public bool CumpleTipoPermitido(int intTipoPersona, int intTipoPermitido)
        {
            bool blCumpleTipo = false;

            if (intTipoPermitido > 0)
            {
                if (((2 ^ intTipoPermitido) & intTipoPersona) == (2 ^ intTipoPermitido))
                    blCumpleTipo = true;
            }
            else
                blCumpleTipo = true;

            return blCumpleTipo;
        }


        public void RevisarPermisosObjeto(string strConexion, string strNSUsuario, string strNSModulo, string strNombreObjeto, ref int[] intPermisos)
        {
            intPermisos[0] = 0; // acceso
            intPermisos[1] = 0; // adicionar
            intPermisos[2] = 0; // editar
            intPermisos[3] = 0; // eliminar
            if (!string.IsNullOrEmpty(strConexion) && !string.IsNullOrEmpty(strNSUsuario) && !string.IsNullOrEmpty(strNSModulo) && !string.IsNullOrEmpty(strNombreObjeto))
            {
                strSql = "select e.num_sec_objeto, sum(e.acceso) acceso, sum(e.adicionar) adicionar";
                strSql += " , sum(e.editar) editar, sum(e.eliminar) eliminar";
                strSql += " from sam_objetos a, sam_funciones b, sam_usuarios_funciones c, sam_accesos e";
                strSql += " where a.num_sec_modulo = " + strNSModulo;
                strSql += " and a.nombre = '" + strNombreObjeto + "'";
                strSql += " and b.num_sec_modulo = " + strNSModulo;
                strSql += " and c.num_sec_usuario = " + strNSUsuario;
                strSql += " and c.num_sec_funcion = b.num_sec_funcion";
                strSql += " and e.num_sec_funcion = b.num_sec_funcion";
                strSql += " and e.num_sec_objeto = a.num_sec_objeto";
                strSql += " group by e.num_sec_objeto";

                DataTable dt = new DataTable();
                OracleBD.MostrarError = false;
                OracleBD.StrConexion = strConexion;
                OracleBD.Sql = strSql;
                OracleBD.sqlDataTable();
                dt = OracleBD.DataTable;
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    intPermisos[0] = Convert.ToInt16(dr["acceso"].ToString());
                    intPermisos[1] = Convert.ToInt16(dr["adicionar"].ToString());
                    intPermisos[2] = Convert.ToInt16(dr["editar"].ToString());
                    intPermisos[3] = Convert.ToInt16(dr["eliminar"].ToString());
                }
                dt.Dispose();
            }
        }

        #endregion

        #region Procedimientos y Funciones Locales
        private bool DatosCompletos()
        {
            bool blDatosCompletos = true;
            try
            {
                _login = _login.Trim().ToUpper();
                _password = _password.Trim();
                _servidor = _servidor.Trim();

                if (_login.Length <= 0)
                {
                    _mensaje = "Debe ingresar el usuario.";
                    throw new MyException();
                }
                if (_password.Length <= 0)
                {
                    _mensaje = "Debe ingresar la constraseña.";
                    throw new MyException();
                }
                if (_servidor.Length <= 0)
                {
                    _mensaje = "Debe ingresar el servidor.";
                    throw new MyException();
                }
            }
            catch (MyException)
            {
                blDatosCompletos = false;
            }
            return blDatosCompletos;
        }

        private bool UsuarioAutenticadoSAM()
        {
            bool blUsuarioAutenticado = true;
            DataTable dt = new DataTable();
            try
            {
                _strconexion = "Data Source= " + _servidor + ";Password=" + _password + ";User ID=" + _login + ";";
                //_strconexion = OracleBD.Armar_String_Conexion(_servidor, _login, _password);

                strSql = " select a.num_sec_usuario, a.usuario, a.login, a.activo, a.num_sec_persona";
                strSql += " , trunc(a.fecha_vigencia)-trunc(sysdate) dias_acceso";
                strSql += " , b.cedula_identidad, b.tipo, b.sexo";
                strSql += " , b.nombres||' '||b.ap_paterno||' '||b.ap_materno persona";
                strSql += " , decode(TO_CHAR(b.fecha_nacimiento,'DD-MM'),TO_CHAR(SYSDATE,'DD-MM'),'SI','NO') cumple";
                strSql += " , decode(nvl(c.num_regs_cambiopwd,0),0,0,1) cambiopwd";
                strSql += " from ucbadmin.sam_usuarios a, ucbadmin.personas b";
                strSql += " , (select num_sec_usuario, count(0) num_regs_cambiopwd";
                strSql += "    from ucbadmin.sam_usuarios_cambiospwd";
                strSql += "    where fecha_cambio is null ";
                strSql += "    group by num_sec_usuario) c";
                strSql += " where a.usuario = '" + _login + "'";
                strSql += " and a.num_sec_persona = b.num_sec";
                strSql += " and a.num_sec_persona = b.num_sec";
                strSql += " and a.num_sec_usuario = c.num_sec_usuario(+)";

                OracleBD.Pagina = _pagina;
                OracleBD.StrConexion = _strconexion;
                OracleBD.Sql = strSql;
                OracleBD.sqlDataTable();

                if (!OracleBD.Error)
                {
                    dt = OracleBD.DataTable;
                    if (dt.Rows.Count == 1)
                    {
                        DataRow dr = dt.Rows[0];
                        if (dr["activo"].ToString() == "1")
                        {
                            if (Convert.ToInt64(dr["dias_acceso"].ToString()) >= 0)
                            {
                                _persona_tipo = Convert.ToInt16(dr["tipo"].ToString());
                                if (CumpleTipoPermitido(_persona_tipo, _tipopermitido))
                                {
                                    _autenticado = true;
                                    _mensaje = string.Empty;
                                    _numsec = Convert.ToInt64(dr["num_sec_usuario"].ToString());
                                    _usuario = dr["persona"].ToString();
                                    //_cambiopwd = Convert.ToBoolean(Convert.ToInt16(dr["cambiopwd"].ToString()));
                                    if (dr["cambiopwd"].ToString() == "1")
                                        _cambiopwd = true;
                                    else
                                        _cambiopwd = false;

                                    _persona_numsec = Convert.ToInt64(dr["num_sec_persona"].ToString());
                                    _persona_nombre = dr["persona"].ToString();
                                    _persona_ci = dr["cedula_identidad"].ToString();
                                    _persona_sexo = Convert.ToInt16(dr["sexo"].ToString());
                                    //_persona_grupo = Definir_Grupo_Persona(_strconexion, dr["num_sec_persona"].ToString(), "");
                                }
                                else
                                {
                                    _mensaje = "Usted no cumple el tipo de persona requerido para acceder a este sistema.";
                                    throw new MyException();
                                }
                            }
                            else
                            {
                                _mensaje = "Su usuario no está vigente. Debe consultar con el Administrador del Sistema.";
                                throw new MyException();
                            }
                        }
                        else
                        {
                            _mensaje = "Su usuario no está activado. Debe consultar con el Administrador del Sistema.";
                            throw new MyException();
                        }
                    }
                    else
                    {
                        _mensaje = "No se pudo identificar al usuario en el Sistema Académico. Por favor verifique sus datos o consultar con el Administrador del Sistema.";
                        throw new MyException();
                    }
                }
                else
                {
                    
                    _mensaje = "Datos de acceso incorrectos. " + OracleBD.Mensaje;
                    throw new MyException();
                }

            }
            catch (MyException)
            {
                blUsuarioAutenticado = false;
                _strconexion = string.Empty;
                _persona_tipo = 0;
            }
            finally
            {
                dt.Dispose();
            }
            return blUsuarioAutenticado;
        }

        private bool UsuarioAutenticadoADMSINF()
        {
            bool blUsuarioAutenticadoADMSINF = true;
            DataTable dt = new DataTable();

            try
            {
                _strconexion = "Data Source= " + _servidor + ";Password=" + _password + ";User ID=" + _login + ";";
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.Append("select a.estado, b.num_sec, b.cedula_identidad, b.tipo, b.sexo, nvl(a.cambiopwd,0) cambiopwd, ");
                strBuilder.Append("a.codigo, a.login, a.rol, a.estado, a.num_sec_persona, a.num_sec_perfil, ");
                strBuilder.Append("nvl(a.num_sec_carrera,0) num_sec_carrera, ");
                strBuilder.Append("nvl(a.num_sec_facultad,0) num_sec_facultad ");
                strBuilder.Append(", b.AP_PATERNO||' '||b.AP_MATERNO||' '||b.NOMBRES persona ");
                strBuilder.Append("from ucbadmin.usuarios a, ucbadmin.personas b ");
                strBuilder.Append("where upper(a.login) = '");
                strBuilder.Append(_login);
                strBuilder.Append("' ");
                strBuilder.Append("and a.num_sec_persona = b.num_sec");

                strSql = strBuilder.ToString();

                OracleBD.Pagina = _pagina;
                OracleBD.StrConexion = _strconexion;
                OracleBD.Sql = strSql;
                OracleBD.sqlDataTable();
                dt = OracleBD.DataTable;

                if (dt.Rows.Count == 1)
                {
                    DataRow dr = dt.Rows[0];
                    if (dr["estado"].ToString() == "1")
                    {
                        _persona_tipo = Convert.ToInt16(dr["tipo"].ToString());
                        if (CumpleTipoPermitido(_persona_tipo, _tipopermitido))
                        {
                            _autenticado = true;
                            _mensaje = string.Empty;
                            _numsec = Convert.ToInt64(dr["num_sec"].ToString());
                            _codigo_usuario = dr["codigo"].ToString();

                            if (dr["cambiopwd"].ToString() == "1")
                                _cambiopwd = true;
                            else
                                _cambiopwd = false;

                            _persona_numsec = Convert.ToInt64(dr["num_sec"].ToString());
                            _persona_nombre = dr["persona"].ToString();
                            _persona_ci = dr["cedula_identidad"].ToString();
                            _persona_sexo = Convert.ToInt16(dr["sexo"].ToString());

                            strBuilder.Clear();
                            strBuilder.Append("ALTER SESSION SET NLS_TERRITORY='AMERICA'");
                            strSql = strBuilder.ToString();


                            OracleBD.Sql = strSql;
                            OracleBD.EjecutarSql();
                        }
                        else
                        {
                            _mensaje = "Usted no cumple el tipo de persona requerido para acceder a este sistema.";
                            throw new MyException();
                        }
                    }
                    else
                    {
                        _mensaje = "Su usuario no está activado. Debe consultar con el Centro de Sistemas.";
                        throw new MyException();
                    }
                }
                else
                {
                    _mensaje = "No se pudo identificar al usuario. Por favor verifique sus datos o consulte con el Centro de Sistemas.";
                    throw new MyException();
                }

            }
            catch (MyException)
            {
                blUsuarioAutenticadoADMSINF = false;
                _strconexion = string.Empty;
                _persona_tipo = 0;
            }
            finally
            {
                dt.Dispose();
            }
            return blUsuarioAutenticadoADMSINF;
        }

        private void MostrarVentanaError()
        {
            libJava1.Desplegar_Mensage_Java(_pagina, _mensaje, 1);
        }
        #endregion
    }

    class MyException : ApplicationException
    {
        public MyException()
        {
        }
    }





}