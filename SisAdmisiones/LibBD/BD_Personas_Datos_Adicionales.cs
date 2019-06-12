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

namespace nsBD_GEN
{
    // Creado por: Willy Tenorio Palza; Fecha: 10/11/2015
    // Ultima modificación: 
    // Descripción: Clase referente a la tabla PERSONAS_DATOS_ADICIONALES

    public class BD_Personas_Datos_Adicionales : iBD_Tablas
    {
        #region Variables Locales

        GEN_OracleBD OracleBD = new GEN_OracleBD();
        GEN_Mensajes libMensajes = new GEN_Mensajes();
        GEN_Cadenas libCadenas = new GEN_Cadenas();
        SIS_GeneralesSistema GeneralesSistema = new SIS_GeneralesSistema();
        private string strSql = string.Empty;

        #endregion

        #region Atributos

        // Campos de la tabla PERSONAS_DATOS_ADICIONALES
        private long _num_sec_persona = 0;            
        private string _email = string.Empty;         
        private long _num_sec_semestre = 0;   
        private long _telefono = 0;                  
        private string _celular = string.Empty;       
        private long _casilla = 0;                    
        private short _titulo_bachiller = 0;          
        private string _email_ucb = string.Empty;     
        private string _email_pass = string.Empty;    
        private short _email_activo = 0;              
        private string _avenida_calle = string.Empty; 
        private string _numero = string.Empty;        
        private string _zona = string.Empty;          
        private string _barrio = string.Empty;        
        private string _edificio = string.Empty;      
        private string _piso = string.Empty;          
        private string _depto = string.Empty;         
        private short _codigo_regional = 0;           
        private short _cambiar = 0;                   
        private short _permitir_acceso_padres = 0;    
        private short _tipo_lugar_nacimiento = 0;
        private short _interno_ucb = 0;

        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        // Definicion GET y SET de los campos de la tabla PERSONAS_DATOS_ADICIONALES
        public long NumSecPersona { get { return _num_sec_persona; } set { _num_sec_persona = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public long NumSecSemestreIngreso { get { return _num_sec_semestre; } set { _num_sec_semestre = value; } }
        public long Telefono { get { return _telefono; } set { _telefono = value; } }
        public string Celular { get { return _celular; } set { _celular = value; } }
        public long Casilla { get { return _casilla; } set { _casilla = value; } }
        public short TituloBachiller { get { return _titulo_bachiller; } set { _titulo_bachiller = value; } }
        public string EmailUcb { get { return _email_ucb; } set { _email_ucb = value; } }
        public string EmailPass { get { return _email_pass; } set { _email_pass = value; } }
        public short EmailActivo { get { return _email_activo; } set { _email_activo = value; } }
        public string AvenidaCalle { get { return _avenida_calle; } set { _avenida_calle = value; } }
        public string Numero { get { return _numero; } set { _numero = value; } }
        public string Zona { get { return _zona; } set { _zona = value; } }
        public string Barrio { get { return _barrio; } set { _barrio = value; } }
        public string Edificio { get { return _edificio; } set { _edificio = value; } }
        public string Piso { get { return _piso; } set { _piso = value; } }
        public string Depto { get { return _depto; } set { _depto = value; } }
        public short CodigoRegional { get { return _codigo_regional; } set { _codigo_regional = value; } }
        public short Cambiar { get { return _cambiar; } set { _cambiar = value; } }
        public short PermitirAccesoPadres { get { return _permitir_acceso_padres; } set { _permitir_acceso_padres = value; } }
        public short TipoLugarNacimiento { get { return _tipo_lugar_nacimiento; } set { _tipo_lugar_nacimiento = value; } }
        public short InternoUCB { get { return _interno_ucb; } set { _interno_ucb = value; } }

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

        // Definición del contructor de la clase PERSONAS_DATOS_ADICIONALES
        public BD_Personas_Datos_Adicionales()
        {
            _num_sec_persona = 0;          
            _email = string.Empty;         
            _num_sec_semestre = 0; 
            _telefono = 0;                 
            _celular = string.Empty;       
            _casilla = 0;                  
            _titulo_bachiller = 0;         
            _email_ucb = string.Empty;     
            _email_pass = string.Empty;    
            _email_activo = 0;             
            _avenida_calle = string.Empty; 
            _numero = string.Empty;        
            _zona = string.Empty;          
            _barrio = string.Empty;        
            _edificio = string.Empty;      
            _piso = string.Empty;          
            _depto = string.Empty;         
            _codigo_regional = 0;          
            _cambiar = 0;                  
            _permitir_acceso_padres = 0;   
            _tipo_lugar_nacimiento = 0;
            _interno_ucb = 0;

            _mensaje = string.Empty;
            _strconexion = string.Empty;
        }

        #endregion

        #region Metodos iBD_Tablas

        // Método para insertar un dato en la tabla PERSONAS_DATOS_ADICIONALES
        public bool Insertar()
        {
            bool blOperacionCorrecta = true;
            if (blOperacionCorrecta)
            {
                strSql = "insert into personas_datos_adicionales " +
                        "(num_sec_persona, zona, barrio, avenida_calle, numero, edificio, piso, depto, " +
                        "telefono, celular, email, email_ucb, interno_ucb, permitir_acceso_padres) " +
                        "values " +
                        "(" + _num_sec_persona.ToString() + ", " +
                        GeneralesSistema.IIf(_zona.Trim() == "", "NULL", "'" + _zona + "'") + ", " +
                        GeneralesSistema.IIf(_barrio.Trim() == "", "NULL", "'" + _barrio + "'") + ", " +
                        GeneralesSistema.IIf(_avenida_calle.Trim() == "", "NULL", "'" + _avenida_calle + "'") + ", " +
                        GeneralesSistema.IIf(_numero.Trim() == "", "NULL", "'" + _numero + "'") + ", " +
                        GeneralesSistema.IIf(_edificio.Trim() == "", "NULL", "'" + _edificio + "'") + ", " +
                        GeneralesSistema.IIf(_piso.Trim() == "", "NULL", "'" + _piso + "'") + ", " +
                        GeneralesSistema.IIf(_depto.Trim() == "", "NULL", "'" + _depto + "'") + ", " +
                        GeneralesSistema.IIf(_telefono == 0, "NULL", _telefono.ToString().Trim()).ToString() + ", " +
                        GeneralesSistema.IIf(_celular.Trim() == "", "NULL", "'" + _celular + "'") + ", " +
                        GeneralesSistema.IIf(_email.Trim() == "", "NULL", "'" + _email + "'") + ", " +
                        GeneralesSistema.IIf(_email_ucb.Trim() == "", "NULL", "'" + _email_ucb + "'") + ", " +
                        GeneralesSistema.IIf(_interno_ucb == 0, "NULL", _interno_ucb.ToString().Trim()) + ", " +
                        GeneralesSistema.IIf(_interno_ucb == 0, "NULL", _permitir_acceso_padres.ToString().Trim()) + ")";

                OracleBD.MostrarError = false;
                OracleBD.StrConexion = _strconexion;
                OracleBD.Sql = strSql;
                OracleBD.EjecutarSqlTrans();

                _mensaje = OracleBD.Mensaje;
                blOperacionCorrecta = !OracleBD.Error;
                if (OracleBD.Error)
                    _mensaje = "No fue posible insertar el dato. Se encontró un error al insertar en la tabla PERSONAS_DATOS_ADICIONALES. " + _mensaje;
            }
            return blOperacionCorrecta;
        }

        // Método para MODIFICAR un dato en la tabla PERSONAS_DATOS_ADICIONALES
        public bool Modificar()
        {
            bool blOperacionCorrecta = true;
            if (blOperacionCorrecta)
            {
                strSql = "update personas_datos_adicionales " +
                         "set zona = " + GeneralesSistema.IIf(_zona.Trim()=="","NULL", "'" + _zona + "'") + ", " +
                         "barrio = " + GeneralesSistema.IIf(_barrio.Trim() == "", "NULL", "'" + _barrio + "'") + ", " +
                         "avenida_calle = " + GeneralesSistema.IIf(_avenida_calle.Trim() == "", "NULL", "'" + _avenida_calle + "'")  + ", " +
                         "numero = " + GeneralesSistema.IIf(_numero.Trim() == "", "NULL", "'" + _numero + "'")  + ", " +
                         "edificio = " + GeneralesSistema.IIf(_edificio.Trim() == "", "NULL", "'" + _edificio + "'") + ", " +
                         "piso = " + GeneralesSistema.IIf(_piso.Trim() == "", "NULL", "'" + _piso + "'")  + ", " +
                         "depto = " + GeneralesSistema.IIf(_depto.Trim() == "", "NULL", "'" + _depto + "'")  + ", " +
                         "telefono = " + GeneralesSistema.IIf(_telefono == 0, "NULL", _telefono.ToString().Trim()) + ", " +
                         "celular = " + GeneralesSistema.IIf(_celular.Trim() == "", "NULL", "'" + _celular + "'")  + ", " +
                         "email = " + GeneralesSistema.IIf(_email.Trim() == "", "NULL", "'" + _email + "'") + ", " +
                         "email_ucb = " + GeneralesSistema.IIf(_email_ucb.Trim() == "", "NULL", "'" + _email_ucb + "'") + ", " +
                         "interno_ucb = " + GeneralesSistema.IIf(_interno_ucb == 0, "NULL", _interno_ucb.ToString().Trim()) + ", " +
                         "permitir_acceso_padres = " + GeneralesSistema.IIf(_permitir_acceso_padres == 0, "NULL", _permitir_acceso_padres.ToString().Trim()) + " " +
                         "where num_sec_persona = " + _num_sec_persona.ToString();

                OracleBD.MostrarError = false;
                OracleBD.StrConexion = _strconexion;
                OracleBD.Sql = strSql;
                OracleBD.EjecutarSqlTrans();

                _mensaje = OracleBD.Mensaje;
                blOperacionCorrecta = !OracleBD.Error;
                if (OracleBD.Error)
                    _mensaje = "No fue posible modificar el dato. Se encontró un error al modificar en la tabla PERSONAS_DATOS_ADICIONALES. " + _mensaje;
            }
            return blOperacionCorrecta;
        }

        // Método para ELIMINAR un dato en la tabla PERSONAS_DATOS_ADICIONALES
        public bool Borrar()
        {
            bool blOperacionCorrecta = true;
            if (blOperacionCorrecta)
            {
                strSql = "delete personas_datos_adicionales " +
                        "where num_sec_persona = " + _num_sec_persona.ToString();

                OracleBD.MostrarError = false;
                OracleBD.StrConexion = _strconexion;
                OracleBD.Sql = strSql;
                OracleBD.EjecutarSqlTrans();

                _mensaje = OracleBD.Mensaje;
                blOperacionCorrecta = !OracleBD.Error;
                if (OracleBD.Error)
                    _mensaje = "No fue posible modificar el dato. Se encontró un error al modificar en la tabla PERSONAS_DATOS_ADICIONALES. " + _mensaje;
            }
            return blOperacionCorrecta;
        }

        // Método para VER un dato en la tabla PERSONAS_DATOS_ADICIONALES
        public bool Ver()
        {
            bool blEncontrado = false;
            string strSql = string.Empty;
            if (!string.IsNullOrEmpty(_num_sec_persona.ToString()))
            {
                strSql = "select num_sec_persona,email,num_sec_semestre,telefono,celular, nvl(casilla,0) casilla,nvl(titulo_bachiller,0) titulo_bachiller, " +
                         "email_ucb,email_pass,nvl(email_activo,0) email_activo,avenida_calle,numero,zona,barrio,edificio,piso,depto, " +
                         "nvl(codigo_regional,0) codigo_regional,nvl(cambiar,0) cambiar,nvl(permitir_acceso_padres,0) permitir_acceso_padres,nvl(tipo_lugar_nacimiento,0) tipo_lugar_nacimiento, nvl(interno_ucb,0) interno_ucb " +
                         "from personas_datos_adicionales  " +
                         "where num_sec_persona = " + _num_sec_persona;
                OracleBD.MostrarError = false;
                OracleBD.StrConexion = _strconexion;
                OracleBD.Sql = strSql;
                OracleBD.sqlDataTable();
                if (OracleBD.DataTable.Rows.Count > 0)
                {
                    blEncontrado = true;
                    _num_sec_persona = Convert.ToInt64(OracleBD.DataTable.Rows[0]["num_sec_persona"].ToString());
                    _email = OracleBD.DataTable.Rows[0]["email"].ToString();
                    if (OracleBD.DataTable.Rows[0]["num_sec_semestre"].ToString().Trim() == "")
                        _num_sec_semestre = 0;
                    else
                        _num_sec_semestre = Convert.ToInt64(OracleBD.DataTable.Rows[0]["num_sec_semestre"].ToString());
                    if (OracleBD.DataTable.Rows[0]["telefono"].ToString().Trim() == "")
                        _telefono = 0;
                    else
                        _telefono = Convert.ToInt64(OracleBD.DataTable.Rows[0]["telefono"].ToString());
                    _celular = OracleBD.DataTable.Rows[0]["celular"].ToString();
                    if (OracleBD.DataTable.Rows[0]["casilla"].ToString().Trim() == "")
                        _casilla = 0;
                    else
                        _casilla = Convert.ToInt64(OracleBD.DataTable.Rows[0]["casilla"].ToString());
                    _titulo_bachiller = Convert.ToInt16(OracleBD.DataTable.Rows[0]["titulo_bachiller"].ToString());
                    _email_ucb = OracleBD.DataTable.Rows[0]["email_ucb"].ToString();
                    _email_pass = OracleBD.DataTable.Rows[0]["email_pass"].ToString();
                    _email_activo = Convert.ToInt16(OracleBD.DataTable.Rows[0]["email_activo"].ToString());
                    _avenida_calle = OracleBD.DataTable.Rows[0]["avenida_calle"].ToString();
                    _numero = OracleBD.DataTable.Rows[0]["numero"].ToString();
                    _zona = OracleBD.DataTable.Rows[0]["zona"].ToString();
                    _barrio = OracleBD.DataTable.Rows[0]["barrio"].ToString();
                    _edificio = OracleBD.DataTable.Rows[0]["edificio"].ToString();
                    _piso = OracleBD.DataTable.Rows[0]["piso"].ToString();
                    _depto = OracleBD.DataTable.Rows[0]["depto"].ToString();
                    _interno_ucb = Convert.ToInt16(OracleBD.DataTable.Rows[0]["interno_ucb"].ToString());
                    _codigo_regional = Convert.ToInt16(OracleBD.DataTable.Rows[0]["codigo_regional"].ToString());
                    if (OracleBD.DataTable.Rows[0]["cambiar"].ToString().Trim() == "")
                        _cambiar = 0;
                    else
                        _cambiar = Convert.ToInt16(OracleBD.DataTable.Rows[0]["cambiar"].ToString());
                    if (OracleBD.DataTable.Rows[0]["permitir_acceso_padres"].ToString().Trim() == "")
                        _permitir_acceso_padres = 0;
                    else
                        _permitir_acceso_padres = Convert.ToInt16(OracleBD.DataTable.Rows[0]["permitir_acceso_padres"].ToString());
                    if (OracleBD.DataTable.Rows[0]["tipo_lugar_nacimiento"].ToString().Trim() == "")
                        _tipo_lugar_nacimiento = 0;
                    else
                        _tipo_lugar_nacimiento = Convert.ToInt16(OracleBD.DataTable.Rows[0]["tipo_lugar_nacimiento"].ToString());
                }
            }
            if (!blEncontrado)
            {
                _num_sec_persona = 0;
                _email = string.Empty;
                _num_sec_semestre = 0;
                _telefono = 0;
                _celular = string.Empty;
                _casilla = 0;
                _titulo_bachiller = 0;
                _email_ucb = string.Empty;
                _email_pass = string.Empty;
                _email_activo = 0;
                _avenida_calle = string.Empty;
                _numero = string.Empty;
                _zona = string.Empty;
                _barrio = string.Empty;
                _edificio = string.Empty;
                _piso = string.Empty;
                _depto = string.Empty;
                _codigo_regional = 0;
                _cambiar = 0;
                _permitir_acceso_padres = 0;
                _tipo_lugar_nacimiento = 0;
                _interno_ucb = 0;
            }
            return blEncontrado;
        }

        public string SQLModificarCambiar()
        {
            strSql = "update personas_datos_adicionales set cambiar = " + _cambiar.ToString() + " " +
                     "where num_sec_persona = " + _num_sec_persona.ToString();
            return strSql;
        }

        public bool ModificarCambiar()
        {
            bool blOperacionCorrecta = true;
            if (blOperacionCorrecta)
            {
                strSql = "update personas_datos_adicionales set cambiar = " + _cambiar.ToString() + " " +
                     "where num_sec_persona = " + _num_sec_persona.ToString();
                OracleBD.MostrarError = false;
                OracleBD.StrConexion = _strconexion;
                OracleBD.Sql = strSql;
                OracleBD.EjecutarSqlTrans();

                _mensaje = OracleBD.Mensaje;
                blOperacionCorrecta = !OracleBD.Error;
                if (OracleBD.Error)
                    _mensaje = "No fue posible modificar el dato. Se encontró un error al modificar en la tabla PERSONAS_DATOS_ADICIONALES. " + _mensaje;
            }
            return blOperacionCorrecta;
        }

        public bool ModificarTipoLugarNac()
        {
            strSql = "update personas_datos_adicionales set tipo_lugar_nacimiento = " + _tipo_lugar_nacimiento.ToString() + " " +
                     "where num_sec_persona = " + _num_sec_persona.ToString();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();

            _mensaje = OracleBD.Mensaje;
            if (OracleBD.Error)
                _mensaje = "No fue posible modificar el dato. Se encontró un error al modificar en la tabla PERSONAS_DATOS_ADICIONALES. " + _mensaje;
            return !OracleBD.Error;
        }

        public bool InsertarTipoLugarNac()
        {
            strSql = "insert into personas_datos_adicionales " +
                    "(num_sec_persona, tipo_lugar_nacimiento) " +
                    "values " +
                    "(" + _num_sec_persona.ToString() + ", " + _tipo_lugar_nacimiento.ToString().Trim() + ")";
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();

            _mensaje = OracleBD.Mensaje;
            if (OracleBD.Error)
                _mensaje = "No fue posible insertar el dato. Se encontró un error al insertar en la tabla PERSONAS_DATOS_ADICIONALES. " + _mensaje;
            return !OracleBD.Error;
        }

        public bool CopiarDatosAdicionalesBaseExterna(string strConExterna, string strNSPersonaExterna)
        {
            bool sw = true;
            strSql = "select * " +
                     "from personas_datos_adicionales " +
                     "where num_sec_persona = " + _num_sec_persona.ToString().Trim();
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            if (OracleBD.Error)
            {
                sw = false;
                _mensaje = OracleBD.Mensaje;
            }
            else
            {
                if (OracleBD.DataTable.Rows.Count == 0)
                {
                    // No hay registro en la base de datos Interna por lo tanto vemos si hay datos en la base de datos externa
                    strSql = "select * " +
                            "from personas_datos_adicionales " +
                            "where num_sec_persona = " + strNSPersonaExterna;
                    OracleBD.StrConexion = strConExterna;
                    OracleBD.Sql = strSql;
                    OracleBD.sqlDataTable();
                    if (OracleBD.Error)
                    {
                        sw = false;
                        _mensaje = OracleBD.Mensaje;
                    }
                    else
                    {
                        if (OracleBD.DataTable.Rows.Count > 0)
                        {
                            // la base externa tiene datos, por lo tanto copiamos los datos a la interna
                            strSql = "insert into personas_datos_adicionales " +
                                    "(num_sec_persona, zona, barrio, avenida_calle, numero, edificio, piso, depto, " +
                                    "telefono, celular, email, email_ucb) " +
                                    "values " +
                                    "(" + _num_sec_persona.ToString().Trim() + ", " +
                                    GeneralesSistema.IIf(OracleBD.DataTable.Rows[0]["zona"].ToString().Trim() == "", "NULL", "'" + OracleBD.DataTable.Rows[0]["zona"].ToString().Trim() + "'") + ", " +
                                    GeneralesSistema.IIf(OracleBD.DataTable.Rows[0]["barrio"].ToString().Trim() == "", "NULL", "'" + OracleBD.DataTable.Rows[0]["barrio"].ToString().Trim() + "'") + ", " +
                                    GeneralesSistema.IIf(OracleBD.DataTable.Rows[0]["avenida_calle"].ToString().Trim() == "", "NULL", "'" + OracleBD.DataTable.Rows[0]["avenida_calle"].ToString().Trim() + "'") + ", " +
                                    GeneralesSistema.IIf(OracleBD.DataTable.Rows[0]["numero"].ToString().Trim() == "", "NULL", "'" + OracleBD.DataTable.Rows[0]["numero"].ToString().Trim() + "'") + ", " +
                                    GeneralesSistema.IIf(OracleBD.DataTable.Rows[0]["edificio"].ToString().Trim() == "", "NULL", "'" + OracleBD.DataTable.Rows[0]["edificio"].ToString().Trim() + "'") + ", " +
                                    GeneralesSistema.IIf(OracleBD.DataTable.Rows[0]["piso"].ToString().Trim() == "", "NULL", "'" + OracleBD.DataTable.Rows[0]["piso"].ToString().Trim() + "'") + ", " +
                                    GeneralesSistema.IIf(OracleBD.DataTable.Rows[0]["depto"].ToString().Trim() == "", "NULL", "'" + OracleBD.DataTable.Rows[0]["depto"].ToString().Trim() + "'") + ", " +
                                    GeneralesSistema.IIf(OracleBD.DataTable.Rows[0]["telefono"].ToString().Trim() == "", "NULL", OracleBD.DataTable.Rows[0]["telefono"].ToString().Trim()) + ", " +
                                    GeneralesSistema.IIf(OracleBD.DataTable.Rows[0]["celular"].ToString().Trim() == "", "NULL", "'" + OracleBD.DataTable.Rows[0]["celular"].ToString().Trim() + "'") + ", " +
                                    GeneralesSistema.IIf(OracleBD.DataTable.Rows[0]["email"].ToString().Trim() == "", "NULL", "'" + OracleBD.DataTable.Rows[0]["email"].ToString().Trim() + "'") + ", " +
                                    GeneralesSistema.IIf(OracleBD.DataTable.Rows[0]["email_ucb"].ToString().Trim() == "", "NULL", "'" + OracleBD.DataTable.Rows[0]["email_ucb"].ToString().Trim() + "'") +
                                    ")";
                            OracleBD.StrConexion = _strconexion;
                            OracleBD.Sql = strSql;
                            OracleBD.EjecutarSqlTrans();
                            if (OracleBD.Error)
                            {
                                sw = false;
                                _mensaje = OracleBD.Mensaje;
                            }
                        }
                    }
                }
            }
            return sw;
        }

        public string cadSqlInsertar()
        {
            strSql = "insert into personas_datos_adicionales " +
                        "(num_sec_persona, zona, barrio, avenida_calle, numero, edificio, piso, depto, " +
                        "telefono, celular, email, email_ucb, interno_ucb, permitir_acceso_padres) " +
                        "values " +
                        "(" + _num_sec_persona.ToString() + ", " +
                        GeneralesSistema.IIf(_zona.Trim() == "", "NULL", "'" + _zona + "'") + ", " +
                        GeneralesSistema.IIf(_barrio.Trim() == "", "NULL", "'" + _barrio + "'") + ", " +
                        GeneralesSistema.IIf(_avenida_calle.Trim() == "", "NULL", "'" + _avenida_calle + "'") + ", " +
                        GeneralesSistema.IIf(_numero.Trim() == "", "NULL", "'" + _numero + "'") + ", " +
                        GeneralesSistema.IIf(_edificio.Trim() == "", "NULL", "'" + _edificio + "'") + ", " +
                        GeneralesSistema.IIf(_piso.Trim() == "", "NULL", "'" + _piso + "'") + ", " +
                        GeneralesSistema.IIf(_depto.Trim() == "", "NULL", "'" + _depto + "'") + ", " +
                        GeneralesSistema.IIf(_telefono == 0, "NULL", _telefono.ToString().Trim()).ToString() + ", " +
                        GeneralesSistema.IIf(_celular.Trim() == "", "NULL", "'" + _celular + "'") + ", " +
                        GeneralesSistema.IIf(_email.Trim() == "", "NULL", "'" + _email + "'") + ", " +
                        GeneralesSistema.IIf(_email_ucb.Trim() == "", "NULL", "'" + _email_ucb + "'") + ", " +
                        GeneralesSistema.IIf(string.IsNullOrEmpty(_interno_ucb.ToString()), "0", _interno_ucb.ToString().Trim()) + ", " +
                        _permitir_acceso_padres.ToString().Trim() + ")";
            return strSql;
        }
        #endregion

        #region Procedimientos y Funciones Locales

        public string ListadoEmailCurso(string NSPersona, string NSSemestre, string NSParalelo)
        {
            strSql = "select rownum nro, estudiante, email " +
                    "from " +
                    "( " +
                    "	select per.ap_paterno||' '||per.ap_materno||' '||per.nombres estudiante, " +
                    "          nvl('<a href=\"mailto:'||a.correo||'\">'||a.correo||'</a>','')||'; '||nvl('<a href=\"mailto:'||pda.email||'\">'||a.correo||'</a>','') email " +
                    "	from paralelos p, alumnos_paralelos ap, personas per, personas_datos_adicionales pda, " +
                    "	( " +
                    "		select su.num_sec_persona, su.cuenta||s.dominio correo " +
                    "		from gen_servicios_it_usuarios  su, gen_servicios_it s " +
                    "		where s.num_sec_servicio_it = 11 " +
                    "		and su.num_sec_servicio_it = s.num_sec_servicio_it " +
                    "	) a " +
                    "	where p.num_sec_semestre = " + NSSemestre + " " +
                    "	and ap.num_sec_paralelo = " + NSParalelo + " " +
                    "	and ap.num_sec_persona <> " + NSPersona + " " +
                    "	and ap.activo = 1 " +
                    "	and ap.estado in (1,6) " +
                    "	and per.num_sec = a.num_sec_persona(+) " +
                    "	and per.num_sec = pda.num_sec_persona(+) " +
                    "	and p.num_sec = ap.num_sec_paralelo " +
                    "	and per.num_sec = ap.num_sec_persona " +
                    "	order by per.ap_paterno||' '||per.ap_materno||' '||per.nombres " +
                    ")";
            return strSql;
        }

        public DataTable DTDatosPersona()
        {
            strSql = "select a.num_sec, to_char(a.fecha_nacimiento,'dd/mm/yyyy') f_nac, e.nacionalidad, b.email, b.email_ucb, b.telefono, b.celular,  " +
                     "b.zona||' '||b.barrio||' '||b.avenida_calle||' '||b.numero||' '||decode(b.edificio,null,'','Edificio:'||b.edificio||' Piso:'||b.piso||' Depto:'||b.depto) direccion, " +
                     "decode(permitir_acceso_padres,1,'Esta permitido el acceso de los padres.','No esta permitido el acceso de los padres.') acceso_padres, " +
                     "c.ci_fam, c.nombre_fam, c.tipo_fam, decode(d.num_sec_persona,null,0,1) presento_titulo_bachiller " +
                     "from personas a, personas_datos_adicionales b, paises e, " +
                     "( " +
                     "	select a.num_sec_persona, b.cedula_identidad ci_fam, b.ap_paterno||' '||b.ap_materno||' '||b.nombres nombre_fam, c.descripcion tipo_fam " +
                     "	from familiares a, personas b, dominios c " +
                     "	where a.num_sec_persona = " + _num_sec_persona.ToString().Trim() + " " +
                     "	and a.num_sec_familiar = b.num_sec " +
                     "	and c.dominio = 'TIPO_FAMILIAR' " +
                     "	and c.valor = a.tipo " +
                     ") c, " +
                     "( " +
                     "	select num_sec_persona " +
                     "	from kx_documentos_personas " +
                     "	where num_sec_persona = " + _num_sec_persona.ToString().Trim() + " " +
                     "	and num_sec_documento = 2 " +
                     "	and estado = 1 " +
                     ") d " +
                     "where a.num_sec = " + _num_sec_persona.ToString().Trim() + " " +
                     "and a.num_sec = b.num_sec_persona(+) " +
                     "and a.num_sec = c.num_sec_persona(+) " +
                     "and a.num_sec = d.num_sec_persona(+) " +
                     "and a.num_sec_nacionalidad = e.num_sec(+)";
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }
        
        public string sqlCadActualizar()
        {
            strSql = "update personas_datos_adicionales " +
                        "set zona = " + GeneralesSistema.IIf(_zona.Trim() == "", "NULL", "'" + _zona + "'") + ", " +
                        "barrio = " + GeneralesSistema.IIf(_barrio.Trim() == "", "NULL", "'" + _barrio + "'") + ", " +
                        "avenida_calle = " + GeneralesSistema.IIf(_avenida_calle.Trim() == "", "NULL", "'" + _avenida_calle + "'") + ", " +
                        "numero = " + GeneralesSistema.IIf(_numero.Trim() == "", "NULL", "'" + _numero + "'") + ", " +
                        "edificio = " + GeneralesSistema.IIf(_edificio.Trim() == "", "NULL", "'" + _edificio + "'") + ", " +
                        "piso = " + GeneralesSistema.IIf(_piso.Trim() == "", "NULL", "'" + _piso + "'") + ", " +
                        "depto = " + GeneralesSistema.IIf(_depto.Trim() == "", "NULL", "'" + _depto + "'") + ", " +
                        "telefono = " + GeneralesSistema.IIf(_telefono == 0, "NULL", _telefono.ToString().Trim()) + ", " +
                        "celular = " + GeneralesSistema.IIf(_celular.Trim() == "", "NULL", "'" + _celular + "'") + ", " +
                        "email = " + GeneralesSistema.IIf(_email.Trim() == "", "NULL", "'" + _email + "'") + ", " +
                        "email_ucb = " + GeneralesSistema.IIf(_email_ucb.Trim() == "", "NULL", "'" + _email_ucb + "'") + ", " +
                        "interno_ucb = " + GeneralesSistema.IIf(_interno_ucb == 0, "NULL", _interno_ucb.ToString().Trim()) + ", " +
                        "permitir_acceso_padres = " + GeneralesSistema.IIf(_permitir_acceso_padres == 0, "NULL", _permitir_acceso_padres.ToString().Trim()) + " " +
                        "where num_sec_persona = " + _num_sec_persona.ToString();
            return strSql;
        }

        public string sqlCadInsertar()
        {
            strSql = "insert into personas_datos_adicionales " +
                      "(num_sec_persona, zona, barrio, avenida_calle, numero, edificio, piso, depto, " +
                      "telefono, celular, email, email_ucb, interno_ucb, permitir_acceso_padres) " +
                      "values " +
                      "(" + _num_sec_persona.ToString() + ", " +
                      GeneralesSistema.IIf(_zona.Trim() == "", "NULL", "'" + _zona + "'") + ", " +
                      GeneralesSistema.IIf(_barrio.Trim() == "", "NULL", "'" + _barrio + "'") + ", " +
                      GeneralesSistema.IIf(_avenida_calle.Trim() == "", "NULL", "'" + _avenida_calle + "'") + ", " +
                      GeneralesSistema.IIf(_numero.Trim() == "", "NULL", "'" + _numero + "'") + ", " +
                      GeneralesSistema.IIf(_edificio.Trim() == "", "NULL", "'" + _edificio + "'") + ", " +
                      GeneralesSistema.IIf(_piso.Trim() == "", "NULL", "'" + _piso + "'") + ", " +
                      GeneralesSistema.IIf(_depto.Trim() == "", "NULL", "'" + _depto + "'") + ", " +
                      GeneralesSistema.IIf(_telefono == 0, "NULL", _telefono.ToString().Trim()).ToString() + ", " +
                      GeneralesSistema.IIf(_celular.Trim() == "", "NULL", "'" + _celular + "'") + ", " +
                      GeneralesSistema.IIf(_email.Trim() == "", "NULL", "'" + _email + "'") + ", " +
                      GeneralesSistema.IIf(_email_ucb.Trim() == "", "NULL", "'" + _email_ucb + "'") + ", " +
                      GeneralesSistema.IIf(_interno_ucb == 0, "NULL", _interno_ucb.ToString().Trim()) + ", " +
                      GeneralesSistema.IIf(_interno_ucb == 0, "NULL", _permitir_acceso_padres.ToString().Trim()) + ")";
            return strSql;
        }
        #endregion
    }
}