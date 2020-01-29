using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using nsGEN_OracleBD;

namespace nsBD_GEN
{
    public class BD_GEN_Subunidades_Ubicaciones
    {
        #region Variables Locales
        GEN_OracleBD OracleBD = new GEN_OracleBD();
        #endregion

        #region Atributos
        //atributos de la tabla gen_subunidades_ubicaciones
        private long _num_sec_ubicacion = 0;
        private string _nombre = string.Empty;
        private int _tipo = 0;
        private long _num_sec_subunidad = 0;
        private string _usuario_registro = "";
        private string _fecha_registro = "";
        private long _num_sec_usuario_reg = 0;


        // Otras propiedades
        private string _mensaje = string.Empty;
        private string _strconexion = string.Empty;

        public long NumSecUbicacion
        {
            get { return _num_sec_ubicacion; }
            set { _num_sec_ubicacion = value; }
        }
        public long NumSecSubunidad
        {
            get { return _num_sec_subunidad; }
            set { _num_sec_subunidad = value; }
        }
        public int Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string UsuarioRegistro
        {
            get { return _usuario_registro; }
            set { _usuario_registro = value; }
        }
        public string FechaRegistro
        {
            get { return _fecha_registro; }
            set { _fecha_registro = value; }
        }
        public long NumSecUsuarioReg
        {
            get { return _num_sec_usuario_reg; }
            set { _num_sec_usuario_reg = value; }
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
        public BD_GEN_Subunidades_Ubicaciones()
        {
            _num_sec_ubicacion = 0;
            _num_sec_subunidad = 0;
            _tipo = 0;
            _nombre = string.Empty;
            _num_sec_usuario_reg = 0;
            _fecha_registro = string.Empty;

            _usuario_registro = string.Empty;
            _mensaje = string.Empty;
            _strconexion = string.Empty;
        }

        #endregion

        #region Metodos
        public void ver()
        {
            string strSql = "select * " +
                            "from gen_subunidades_ubicaciones " +
                            "where num_sec_ubicacion = "+_num_sec_ubicacion;
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            if (OracleBD.Error)
            {
                _mensaje = OracleBD.Mensaje;
            }
            if (OracleBD.DataTable.Rows.Count>0)
            {
                DataRow dr = OracleBD.DataTable.Rows[0];
                _num_sec_ubicacion = Convert.ToInt64(dr["num_sec_ubicacion"].ToString().Trim());
                _num_sec_subunidad = Convert.ToInt64(dr["num_sec_subunidad"].ToString().Trim());
                _tipo = Convert.ToInt32(dr["tipo"].ToString().Trim());
                _nombre = dr["nombre"].ToString().Trim();
                _num_sec_usuario_reg = Convert.ToInt64(dr["num_sec_usuario_reg"].ToString().Trim());
                _fecha_registro = dr["fecha_registro"].ToString().Trim();
                _usuario_registro = dr["usuario_registro"].ToString().Trim();
            }
            else
            {
                _num_sec_ubicacion = 0;
                _num_sec_subunidad = 0;
                _tipo = 0;
                _nombre = string.Empty;
                _num_sec_usuario_reg = 0;
                _fecha_registro = string.Empty;

                _usuario_registro = string.Empty;
                _mensaje = string.Empty;
                _strconexion = string.Empty;
            }


        }
        public string Query_Lista_Ubicaciones(string strNSSubunidad, string strTipo, bool blIncluirOpcionTodas)
        {
            string strSql = string.Empty;

            if (blIncluirOpcionTodas)
            {
                strSql = "select 0 num_sec_ubicacion, '[TODAS]' nombre, 'Todos' tipo_str from dual";
                strSql += " UNION";
            }

            strSql += " select ub.num_sec_ubicacion, ub.nombre, d1.descripcion tipo_str ";
            strSql += " from gen_subunidades_ubicaciones ub, dominios d1";
            strSql += " where ub.num_sec_subunidad = " + strNSSubunidad;
            strSql += " and ub.tipo = d1.valor";
            strSql += " and d1.dominio = 'GEN_TIPO_UBICACION'";

            if (strTipo.Trim().Length > 0)
                strSql += " and ub.tipo in (" + strTipo + ")";
            strSql += " order by num_sec_ubicacion";

            return strSql;
        }

        public DataTable DTUbicaciones(string strNSSubunidad, string strTipo, bool blIncluirOpcionTodas)
        {
            OracleBD.StrConexion = _strconexion;
            OracleBD.Sql = Query_Lista_Ubicaciones(strNSSubunidad, strTipo, blIncluirOpcionTodas);
            OracleBD.sqlDataTable();
            if (OracleBD.Error)
            {
                _mensaje = OracleBD.Mensaje;
            }
            return OracleBD.DataTable;
        }
        #endregion


    }
}