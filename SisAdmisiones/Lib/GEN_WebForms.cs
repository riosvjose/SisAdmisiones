using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI.WebControls;
using nsGEN_OracleBD;
using nsGEN_Listas;
//using nsGEN_Java1;

namespace nsGEN_WebForms
{
    public class GEN_WebForms
    {
        GEN_OracleBD OracleBD = new GEN_OracleBD();
        GEN_Listas Listas = new GEN_Listas();

        public GEN_WebForms()
        { }

        public string Determinar_Path_App()
        {
            string appPath = HttpContext.Current.Request.ApplicationPath;
            string physicalPath = HttpContext.Current.Request.MapPath(appPath);

            if (physicalPath.Substring(physicalPath.Length - 1, 1) != @"\")
                physicalPath += @"\";

            return physicalPath;
        }

        public int Llenar_GridView(string strConexion, string strSql, int intNumColsInvisibles, int[] intColsInvisibles, int intNumColUbicar, long lngValorUbicar, ref GridView gvTarget)
        {
            // intNumColUbicar = -1:  si no requiere que el puntero del grid sea ubicado

            int intNumFilasGrid = 0;

            // Cargar DataTable
            DataTable dt = new DataTable();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = strConexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            if (!OracleBD.Error)
                intNumFilasGrid = dt.Rows.Count;

            // Cargar GridView con DataTable
            for (int axConta = 0; axConta < intNumColsInvisibles; axConta++)
            {
                gvTarget.Columns[intColsInvisibles[axConta]].Visible = true;
            }
            gvTarget.DataSource = dt;
            gvTarget.DataBind();
            
            for (int axConta = 0; axConta < intNumColsInvisibles; axConta++)
            {
                gvTarget.Columns[intColsInvisibles[axConta]].Visible = false;
            }

            // Ubicar valor en GridView
            if (intNumFilasGrid > 0 && intNumColUbicar >= 0)
            {
                List<DataRow> lista = dt.AsEnumerable().ToList();
                Listas.ListaRow = lista;
                Listas.intColumna = intNumColUbicar;
                Listas.strValor = lngValorUbicar.ToString();
                Listas.Buscar_Lista_Row();
                if (Listas.intIndice >= 0) gvTarget.SelectedIndex = Listas.intIndice;
            }

            dt.Dispose();
            return intNumFilasGrid;
        }

        public int Llenar_Repeater(string strConexion, string strSql, ref Repeater rpTarget)
        {
            int intNumFilasRepeater = 0;

            // Cargar DataTable
            DataTable dt = new DataTable();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = strConexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            if (!OracleBD.Error)
                intNumFilasRepeater = dt.Rows.Count;

            rpTarget.DataSource = dt;
            rpTarget.DataBind();
            
            dt.Dispose();
            return intNumFilasRepeater;
        }

        public int Llenar_CheckBoxList(string strConexion, string strSql, string strValor, string strDescripcion, ref CheckBoxList cblTarget)
        {
            int intNumFilasRepeater = 0;

            // Cargar DataTable
            DataTable dt = new DataTable();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = strConexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            if (!OracleBD.Error)
                intNumFilasRepeater = dt.Rows.Count;

            cblTarget.DataSource = dt;
            cblTarget.DataValueField = strValor;
            cblTarget.DataTextField = strDescripcion;
            cblTarget.DataBind();

            for (int i = 0; i < cblTarget.Items.Count; i++)
            {
                cblTarget.Items[i].Text = "<span class='mx-2'>" + cblTarget.Items[i].Text + "</span>";
            }

            dt.Dispose();
            return intNumFilasRepeater;
        }

        public int Llenar_DropDownList(string strConexion, string strSql, string strCampoTexto, string strCampoValor, int intNumColUbicar, long lngValorUbicar, ref DropDownList ddlTarget)
        {
            // intNumColUbicar = -1:  si no requiere que el puntero del grid sea ubicado

            int intNumFilasLista = 0;

            // Cargar DataTable
            DataTable dt = new DataTable();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = strConexion;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            if (!OracleBD.Error)
                intNumFilasLista = dt.Rows.Count;

            // Cargar DorpDownList con DataTable
            ddlTarget.DataSource = dt;
            ddlTarget.DataTextField = strCampoTexto;
            ddlTarget.DataValueField = strCampoValor;
            ddlTarget.DataBind();

            // Ubicar valor en GridView
            if (intNumFilasLista > 0 && intNumColUbicar>=0 )
            {
                List<DataRow> lista = dt.AsEnumerable().ToList();
                Listas.ListaRow = lista;
                Listas.intColumna = intNumColUbicar;
                Listas.strValor = lngValorUbicar.ToString();
                Listas.Buscar_Lista_Row();
                if (Listas.intIndice >= 0) ddlTarget.SelectedIndex = Listas.intIndice;
            }

            dt.Dispose();
            return intNumFilasLista;
        }

        public void Llenar_TextBox_GridView(int[] intColValor, string strNombreTextBox, ref GridView gvTarget)
        {
            TextBox tbTextBox = new TextBox();
            string strValor = string.Empty;
            int intIndice = 0;
            foreach (GridViewRow row in gvTarget.Rows)
            {
                tbTextBox = (TextBox)(row.FindControl(strNombreTextBox));
                strValor = row.Cells[intColValor[intIndice]].Text;
                tbTextBox.Text = strValor;
                intIndice++;
            }
        }

        public int CargarGridView(string strConexion, string query, ref GridView gvTarget)
        {
            int intNumFilasGrid = 0;

            // Cargar DataTable
            DataTable dt = new DataTable();
            OracleBD.MostrarError = false;
            OracleBD.StrConexion = strConexion;
            OracleBD.Sql = query;
            OracleBD.sqlDataTable();
            dt = OracleBD.DataTable;
            if (!OracleBD.Error)
                intNumFilasGrid = dt.Rows.Count;

            gvTarget.DataSource = dt;
            gvTarget.DataBind();
            
            dt.Dispose();
            return intNumFilasGrid;
        }

        public void Cargar_GenDominio(string tabla, string atributo, string con, ref DropDownList ddl)
        {
            string strSql;
            strSql = "select valor, upper(texto) texto " +
                    "from gen_dominios " +
                    "where tabla = '" + tabla + "' " +
                    "and atributo = '" + atributo + "' " +
                    "order by valor";
            OracleBD.StrConexion = con;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            ddl.DataSource = OracleBD.DataTable;
            ddl.DataTextField = "texto";
            ddl.DataValueField = "valor";
            ddl.DataBind();
        }

        public void Cargar_Dominio(string dominio, string con, ref DropDownList ddl)
        {
            string strSql;
            strSql = "select valor, upper(descripcion) descripcion " +
                    "from dominios " +
                    "where dominio = '" + dominio + "' " +
                    "order by valor";
            OracleBD.StrConexion = con;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            ddl.DataSource = OracleBD.DataTable;
            ddl.DataTextField = "descripcion";
            ddl.DataValueField = "valor";
            ddl.DataBind();
        }

        public void Cargar_Dominio_Todos(string dominio, string con, ref DropDownList ddl)
        {
            string strSql;
            strSql = "select 0 valor, '[TODOS]' descripcion, 1 orden from dual " +
                    "union " +
                    "select valor, upper(descripcion) descripcion, 2 orden " +
                    "from dominios " +
                    "where dominio = '" + dominio + "' " +
                    "order by valor";
            OracleBD.StrConexion = con;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            ddl.DataSource = OracleBD.DataTable;
            ddl.DataTextField = "descripcion";
            ddl.DataValueField = "valor";
            ddl.DataBind();
        }

        public void Cargar_DominioValor(string tabla, string campo, string dominio, string valor_buscado, string valor_eliminado, bool incluir_todos, string con, ref DropDownList ddl)
        {
            string strSql;
            strSql = "select valor, upper(descripcion) descripcion " +
                    "from dominios " +
                    "where dominio = '" + dominio + "' " +
                    "and tabla = '" + tabla + "' " +
                    "and campo = '" + campo + "' " +
                    "and valor not in (" + valor_eliminado + ")";
            if (incluir_todos)
            {
                strSql += "union select -1, 'TODOS' from dual ";
            }
            strSql += "order by valor";
            OracleBD.StrConexion = con;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            ddl.DataSource = OracleBD.DataTable;
            ddl.DataTextField = "descripcion";
            ddl.DataValueField = "valor";
            ddl.DataBind();
            ddl.SelectedValue = valor_buscado;
        }

        public DataTable Cargar_Dominio_DataTable(string tabla, string campo, string dominio, string con)
        {
            string strSql;
            strSql = "select valor, upper(descripcion) descripcion " +
                    "from dominios " +
                    "where dominio = '" + dominio + "' " +
                    "and tabla = '" + tabla + "' " +
                    "and campo = '" + campo + "' " +
                    "order by valor";
            OracleBD.StrConexion = con;
            OracleBD.Sql = strSql;
            OracleBD.sqlDataTable();
            return OracleBD.DataTable;
        }
    }
}