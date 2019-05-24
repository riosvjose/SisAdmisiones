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
    // Creado por: Ignacio Rios; Fecha: 08/05/2019
    // Ultima modificación: 
    // Descripción: Clase referente a la tabla carreras_estudiantes

    public class BD_Carreras_Estudiantes : iBD_Tablas
    {
        #region Variables Locales

        GEN_OracleBD OracleBD = new GEN_OracleBD();
        GEN_Mensajes libMensajes = new GEN_Mensajes();
        GEN_Cadenas libCadenas = new GEN_Cadenas();
        private string strSql = string.Empty;

        #endregion

        #region Atributos

        // Campos de la tabla carreras_estudiantes
        private long _num_sec = 0;
        private long _num_sec_persona = 0;
        private long _num_sec_semestre = 0;
        private long _num_sec_subdepartamento = 0;
        private long _num_sec_carrera = 0;
        private short _adicionar = 0;
        private short _retirar = 0;
        private short _estado = 0;
        private short _tipo_admision = 0;
        private long _num_sec_pensum_ingreso = 0;
        private string _usuario_registro = string.Empty;
        private string _fecha_registro = string.Empty;
        private string _fecha_ingreso_carr = string.Empty;
        private string _observaciones = "Desde sistema de Admisiones";
        


        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        // Definicion GET y SET de los campos de la tabla carreras_estudiantes
        public long NumSecPersona
        {
            get { return _num_sec_persona; }
            set { _num_sec_persona = value; }
        }
        public long NumSec
        {
            get { return _num_sec; }
            set { _num_sec = value; }
        }
        public long NumSecCarrera
        {
            get { return _num_sec_carrera; }
            set { _num_sec_carrera = value; }
        }
        public string FechaRegistro
        {
            get { return _fecha_registro; }
            set { _fecha_registro = value; }
        }
        public string FechaIngresoCarrera
        {
            get { return _fecha_ingreso_carr; }
            set { _fecha_ingreso_carr = value; }
        }
        public short Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        public short Adicionar
        {
            get { return _adicionar; }
            set { _adicionar = value; }
        }
        public short Retirar
        {
            get { return _retirar; }
            set { _retirar = value; }
        }
        public string UsuarioRegistro
        {
            get { return _usuario_registro; }
            set { _usuario_registro = value; }
        }
        public long NumSecSemestre
        {
            get { return _num_sec_semestre; }
            set { _num_sec_semestre = value; }
        }
        public long NumSecPensumIngreso
        {
            get { return _num_sec_pensum_ingreso; }
            set { _num_sec_pensum_ingreso = value; }
        } 
        public short TipoAdmision
        {
            get { return _tipo_admision; }
            set { _tipo_admision = value; }
        }
        public long NumSecSubdepto
        {
            get { return _num_sec_subdepartamento; }
            set { _num_sec_subdepartamento = value; }
        }
        public string Observacion
        {
            get { return _observaciones; }
            set { _observaciones = value; }
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

        // Definición del contructor de la clase carreras_estudiantes
        public BD_Carreras_Estudiantes()
        {
            _num_sec = 0;
            _num_sec_persona = 0;
            _num_sec_semestre = 0;
            _num_sec_subdepartamento = 0;
            _num_sec_carrera = 0;
            _adicionar = 0;
            _retirar = 0;
            _estado = 0;
            _tipo_admision = 0;
            _num_sec_pensum_ingreso = 0;
            _usuario_registro = string.Empty;
            _fecha_registro = string.Empty;
            _fecha_ingreso_carr = string.Empty;
            _observaciones = "Desde sistema de Admisiones";

            _mensaje = string.Empty;
            _strconexion = string.Empty;
        }

        #endregion

        #region Metodos iBD_Tablas

        // Método para insertar un dato en la tabla carreras_estudiantes
        public bool Insertar()
        {
            bool OperacionCorrecta = false;

            strSql = cadSqlInsertar();
            
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.EjecutarSqlTrans();

            _mensaje = OracleBD.Mensaje;
            OperacionCorrecta = !OracleBD.Error;

            if (OracleBD.Error)
                _mensaje = "No fue posible insertar el dato. Se encontró un error al insertar en la tabla ACAD_CARRERAS_ESTUDIANTES. " + _mensaje;

            return OperacionCorrecta;
        }

        // Método para MODIFICAR un dato en la tabla carreras_estudiantes
        public bool Modificar()
        {
            bool OperacionCorrecta = false;
            return OperacionCorrecta;
        }

        // Método para ELIMINAR un dato en la tabla carreras_estudiantes
        public bool Borrar()
        {
            bool OperacionCorrecta = false;
            return OperacionCorrecta;
        }

        // Método para VER un dato en la tabla carreras_estudiantes
        public bool Ver()
        {
            bool Encontrado = false;
            return Encontrado;
        }

        #endregion

        #region Procedimientos y Funciones Publicos

       public string cadSqlInsertar()
        {
            strSql = "insert into acad_carreras_estudiantes" +
                    " (num_sec, num_sec_persona, num_sec_semestre, num_sec_pensum_ingreso, num_sec_subdepartamento, num_sec_carrera, adicionar, retirar, estado, tipo_admision" +
                    ", fecha_ingreso_carr, observaciones, fecha_registro, usuario_registro)" +
                    " values (acad_carreras_estudiantes_sec.nextval," + _num_sec_persona + "," + _num_sec_semestre + "," + _num_sec_pensum_ingreso + "," +
                    _num_sec_subdepartamento + "," +_num_sec_carrera+","+ _adicionar + "," + _retirar + "," + _estado + "," + _tipo_admision + "," + "trunc(sysdate)" + ",'" + _observaciones + "'," + "sysdate,'" + _usuario_registro + "')";
            return strSql;
        }
        #endregion
    }
}