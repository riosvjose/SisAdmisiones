using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nsGEN_OracleBD;
using System.Data;

namespace nsBD_GEN
{
    // Creado por: Milco Cortez; Fecha: 01/04/2015
    // Ultima modificación: Milco Cortez;  Fecha:01/04/2015
    // Descripción: Clase referente a la tabla DOMINIOS
    public class BD_Dominios
    {
        GEN_OracleBD OracleBD = new GEN_OracleBD();
        private string strSql = string.Empty;

        // Campos de la tabla PERSONAS
        private string _dominio = string.Empty;
        private int _valor = 0;
        private string _descripcion = string.Empty;
        private string _abreviacion = string.Empty;

        private string _strConexion = string.Empty;

        public string Dominio
        {
            get { return _dominio; }
            set { _dominio = value; }
        }
        public int Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public string Abreviacion
        {
            get { return _abreviacion; }
            set { _abreviacion = value; }
        }
        public string StrConexion
        {
            get { return _strConexion; }
            set { _strConexion = value; }
        }
        public BD_Dominios()
        { }

        public void Ver()
        {
            strSql = "select descripcion, abreviacion " +
                    "from dominios " +
                    "where dominio = '" + _dominio + "' " +
                    "and valor = " + _valor.ToString();
            OracleBD.StrConexion = _strConexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            if (OracleBD.DataTable.Rows.Count == 0)
            {
                _descripcion = string.Empty;
                _abreviacion = string.Empty;
            }
            else
            {
                _descripcion = OracleBD.DataTable.Rows[0][0].ToString().Trim();
                _abreviacion = OracleBD.DataTable.Rows[0][1].ToString().Trim();
            }
        }

        public string Query_DropDownList1(string strDominio, string strCamposOrden)
        {
            string strSql = string.Empty;
            strSql = " select dominio, valor, descripcion, abreviacion ";
            strSql += " from dominios where dominio = '" + strDominio + "'";
            if (string.IsNullOrEmpty(strCamposOrden))
                strSql += " order by numero ";
            else
                strSql += " order by " + strCamposOrden;
            return strSql;
        }

        public string Query_DropDownList2(string strDominio, string strCamposOrden, bool blIncluirTodos, int intOrdenTodos, string strValoresIncluidos)
        {
            // intOrdenTodos:    0:al inicio;  1:al final
            string strSql = string.Empty;
            if (blIncluirTodos)
            {
                strSql = " select '" + strDominio + "' dominio, 0 valor, '[TODOS]' descripcion, 'T' abreviacion";
                if (intOrdenTodos != 1)
                {
                    strSql += " , 3 orden";
                }
                else
                {
                    strSql += " , 1 orden";
                }
                strSql += " from dual";
                strSql += " UNION";
            }
            strSql += " select dominio, valor, descripcion, abreviacion, 2 orden ";
            strSql += " from dominios where dominio = '" + strDominio + "'";

            if (!string.IsNullOrEmpty(strValoresIncluidos))
                strSql += " and valor in (" + strValoresIncluidos + ")";

            if (string.IsNullOrEmpty(strCamposOrden))
                strSql += " order by orden, valor ";
            else
                strSql += " order by orden, " + strCamposOrden;
            return strSql;
        }

        public DataTable DTDominios(string ValoresExcluidos, string strConexion)
        {
            strSql = "select valor,initcap(descripcion) descripcion " +
                    "from dominios " +
                    "where dominio = '" + _dominio + "' ";
            if (ValoresExcluidos != "")
                strSql += "and valor not in (" + ValoresExcluidos + ") ";
            strSql += "order by valor";
            OracleBD.StrConexion = strConexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }

        public DataTable DTDominiosAbr(string ValoresExcluidos, string strConexion)
        {
            strSql = "select valor, descripcion, abreviacion " +
                    "from dominios " +
                    "where dominio = '" + _dominio + "' ";
            if (ValoresExcluidos != "")
                strSql += "and valor not in (" + ValoresExcluidos + ") ";
            strSql += "order by valor";
            OracleBD.StrConexion = strConexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }

        public DataTable DTDominiosAlfa(string ValoresExcluidos, string strConexion)
        {
            strSql = "select valor, descripcion, abreviacion " +
                    "from dominios " +
                    "where dominio = '" + _dominio + "' ";
            if (ValoresExcluidos != "")
                strSql += "and valor not in (" + ValoresExcluidos + ") ";
            strSql += "order by descripcion";
            OracleBD.StrConexion = strConexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }

    }
}