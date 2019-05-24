using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Oracle.DataAccess.Client;
using nsGEN_Java;

namespace nsGEN_OracleBD
{
    // Creado por: Milco Cortes; Fecha: 17/03/2015
    // Ultima modificación: Milco Cortes;  Fecha:18/01/2016
    // Descripción: Permite interactuar con una base de datos Oracle. 
                // Ejecutar querys y obtener el resultado en un data table o un data set
                // Ejecutar uno o varios sqls usando una transacción o de forma directa sin tranacción

    public class GEN_OracleBD
    {
        #region Variables Locales
        GEN_Java libJava1 = new GEN_Java();
        #endregion

        #region Atributos
        private string _strconexion = string.Empty;
        public string StrConexion
        {
            get { return _strconexion; }
            set { _strconexion = value; }
        }

        private string _sql = string.Empty;
        public string Sql
        {
            get { return _sql; }
            set { _sql = value; }
        }

        private string[] _listasqls;
        public string[] ListaSqls
        {
            get { return _listasqls; }
            set { _listasqls = value; }
        }

        private int _numsqls = 0;
        public int NumSqls
        {
            get { return _numsqls; }
            set { _numsqls = value; }
        }


        private int _numsqlblob = 0;
        public int NumSqlBlob
        {
            get { return _numsqlblob; }
            set { _numsqlblob = value; }
        }

        private int _numblobs = 0;
        public int NumBlobs
        {
            get { return _numblobs; }
            set { _numblobs = value; }
        }

        private byte[] _blobdata1;
        public byte[] BlobData1
        {
            get { return _blobdata1; }
            set { _blobdata1 = value; }
        }


        private string _nombretabladataset = string.Empty;
        public string NombreTablaDataSet
        {
            get { return _nombretabladataset; }
            set { _nombretabladataset = value; }
        }

        private System.Web.UI.Page _pagina;
        public System.Web.UI.Page Pagina
        {
            get { return _pagina; }
            set { _pagina = value; }
        }

        private bool _mostrarerror = false;
        public bool MostrarError
        {
            get { return _mostrarerror; }
            set { _mostrarerror = value; }
        }

        private string _mensaje = string.Empty;
        public string Mensaje
        {
            get { return _mensaje; }
        }

        private bool _error = false;
        public bool Error
        {
            get { return _error; }
        }

        private DataSet _dataset = new DataSet();
        public DataSet DataSet
        {
            get { return _dataset; }
        }

        private DataTable _datatable = new DataTable();
        public DataTable DataTable 
        {
            get { return _datatable; }
        }
        #endregion

        #region Constructores
        public GEN_OracleBD()
        { 
            _strconexion = string.Empty;
            _sql = string.Empty;
            _numsqls = 0;
            _nombretabladataset = string.Empty;
            _mostrarerror = false;
            _mensaje = string.Empty;
            _error = false;
        }
        #endregion

        #region Metodos
        public void sqlDataSet()
        {
            DataSet ds = new DataSet();
            _error = false;
            if ((_strconexion != string.Empty) && (_sql != string.Empty))
            {
                OracleConnection con = new OracleConnection(_strconexion);
                OracleDataAdapter da = new OracleDataAdapter(_sql, con);
                
                try
                {
                    da.Fill(ds, _nombretabladataset);
                }
                catch (OracleException ex1)
                {
                    _error = true;
                    _mensaje = ex1.ErrorCode.ToString() + " - " + ex1.Message;
                }
                catch (Exception ex2)
                {
                    _error = true;
                    _mensaje = ex2.Message;
                }
                finally
                {
                    con.Close();
                    da.Dispose();
                }
            }
            else
            {
                _error = true;
                _mensaje = "No fue posible ejecutar el sql.";
            }
            _dataset = ds;
            if (_error && _mostrarerror) MostrarVentanaError();
        }
        public void sqlDataTable()
        {
            DataTable dt = new DataTable();
            _error = false;
            if ((_strconexion != string.Empty) && (_sql != string.Empty))
            {
                OracleConnection con = new OracleConnection(_strconexion);
                OracleDataAdapter da = new OracleDataAdapter(_sql, con);

                try
                {
                    da.Fill(dt);
                }
                catch (OracleException ex1)
                {
                    _error = true;
                    _mensaje = ex1.ErrorCode.ToString() + " - " + ex1.Message;
                }
                catch (Exception ex2)
                {
                    _error = true;
                    _mensaje = ex2.Message;
                }
                finally
                {
                    con.Close();
                    da.Dispose();
                }
            }
            else
            {
                _error = true;
                _mensaje = "No fue posible ejecutar el sql.";
            }
            _datatable = dt;
            if (_error && _mostrarerror) MostrarVentanaError();
        }
        public void EjecutarSql()
        {
            _error = false;

            if ((_strconexion != string.Empty) && (_sql != string.Empty))
            {
                OracleConnection con = new OracleConnection(_strconexion);
                OracleCommand com1 = new OracleCommand();
                try
                {
                    com1.Connection = con;
                    con.Open();

                    com1.CommandText = _sql;
                    com1.ExecuteNonQuery();
                }
                catch (OracleException ex1)
                {
                    _error = true;
                    _mensaje = ex1.ErrorCode.ToString() + " - " + ex1.Message;
                }
                catch (Exception ex2)
                {
                    _error = true;
                    _mensaje = ex2.Message;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    com1.Dispose();
                }
            }
            else
            {
                _error = true;
                _mensaje = "No fue posible ejecutar el sql.";
            }
            if (_error && _mostrarerror) MostrarVentanaError();
        }
        public void EjecutarSqls()
        {
            _error = false;

            OracleConnection con = new OracleConnection(_strconexion);
            OracleCommand com1 = new OracleCommand();

            if ((_strconexion != string.Empty) && (_numsqls > 0))
            {
                try
                {
                    com1.Connection = con;
                    con.Open();

                    for (int axConta = 0; axConta < _numsqls; axConta++)
                    {
                        if (_listasqls[axConta] != string.Empty)
                        {
                            com1.CommandText = _listasqls[axConta];
                            com1.ExecuteNonQuery();
                        }
                    }

                }
                catch (OracleException ex1)
                {
                    _error = true;
                    _mensaje = ex1.ErrorCode.ToString() + " - " + ex1.Message;
                }
                catch (Exception ex2)
                {
                    _error = true;
                    _mensaje = ex2.Message;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    com1.Dispose();
                }
            }
            else
            {
                _error = true;
                _mensaje = "No fue posible ejecutar el sql.";
            }
            if (_error && _mostrarerror) MostrarVentanaError();
        }
        public void EjecutarSqlTrans()
        {
            _error = false;

            if ((_strconexion != string.Empty) && (_sql != string.Empty))
            {
                //_mensaje = "No se pudo eliminar el dato. Se encontró un error en la tabla GEN_UNIDADES. Por favor contactarse con el Centro de Sistemas.";
                OracleConnection con = new OracleConnection(_strconexion);
                con.Open();
                OracleCommand myCommand = con.CreateCommand();
                OracleTransaction myTrans;
                myTrans = con.BeginTransaction(IsolationLevel.ReadCommitted);
                myCommand.Transaction = myTrans;
                try
                {
                    myCommand.CommandText = _sql;
                    myCommand.ExecuteNonQuery();
                    _mensaje = string.Empty;
                    myTrans.Commit();
                }
                catch (OracleException ex1)
                {
                    _error = true;
                    myTrans.Rollback();
                    _mensaje += " - " + ex1.ErrorCode.ToString() + " - " + ex1.Message;
                }
                catch (Exception ex2)
                {
                    _error = true;
                    myTrans.Rollback();
                    _mensaje += " - " + ex2.Message;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    myCommand.Dispose();
                }
            }
            else
            {
                _error = true;
                _mensaje = "No fue posible ejecutar el sql.";
            }
            if (_error && _mostrarerror) MostrarVentanaError();
        }
        public void EjecutarSqlsTrans()
        {
            _error = false;

            if ((_strconexion != string.Empty) && (_numsqls > 0))
            {
                //_mensaje = "No se pudo eliminar el dato. Se encontró un error en la tabla GEN_UNIDADES. Por favor contactarse con el Centro de Sistemas.";
                OracleConnection con = new OracleConnection(_strconexion);
                con.Open();
                OracleCommand myCommand = con.CreateCommand();
                OracleTransaction myTrans;
                myTrans = con.BeginTransaction(IsolationLevel.ReadCommitted);
                myCommand.Transaction = myTrans;
                try
                {
                    for (int axConta = 0; axConta < _numsqls; axConta++)
                    {
                        if (_listasqls[axConta] != string.Empty)
                        {
                            myCommand.CommandText = _listasqls[axConta];
                            myCommand.ExecuteNonQuery();
                        }
                    }
                    _mensaje = string.Empty;
                    myTrans.Commit();
                }
                catch (OracleException ex1)
                {
                    _error = true;
                    myTrans.Rollback();
                    _mensaje += " - " + ex1.ErrorCode.ToString() + " - " + ex1.Message;
                }
                catch (Exception ex2)
                {
                    _error = true;
                    myTrans.Rollback();
                    _mensaje += " - " + ex2.Message;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    myCommand.Dispose();
                }
            }
            else
            {
                _error = true;
                _mensaje = "No fue posible ejecutar las lista de sqls.";
            }
            if (_error && _mostrarerror) MostrarVentanaError();
        }
        public void EjecutarSqlsTransParamsBlobs()
        {
            _error = false;

            OracleParameter[] axOraParam = new OracleParameter[100];
            string strNumParam = string.Empty;

            if ((_strconexion != string.Empty) && (_numsqls > 0))
            {
                //_mensaje = "No se pudo eliminar el dato. Se encontró un error en la tabla GEN_UNIDADES. Por favor contactarse con el Centro de Sistemas.";
                OracleConnection con = new OracleConnection(_strconexion);
                con.Open();
                OracleCommand myCommand = con.CreateCommand();
                OracleTransaction myTrans;
                myTrans = con.BeginTransaction(IsolationLevel.ReadCommitted);
                myCommand.Transaction = myTrans;
                try
                {
                    for (int axConta = 0; axConta < _numsqls; axConta++)
                    {
                        if (_listasqls[axConta] != string.Empty)
                        {
                            myCommand.CommandText = _listasqls[axConta];
                            if (axConta == _numsqlblob)
                            {
                                _numblobs = 1;
                                for (int axContap = 0; axContap < _numblobs; axContap++)
                                {
                                    strNumParam = ":" + Convert.ToString(axContap + 1).Trim();
                                    axOraParam[axContap] = myCommand.Parameters.Add(strNumParam, OracleDbType.Blob);
                                    axOraParam[axContap].Direction = ParameterDirection.Input;
                                    axOraParam[axContap].Value = _blobdata1;
                                }
                            }
                            else
                            {
                                myCommand.Parameters.Clear();
                            }
                            myCommand.ExecuteNonQuery();
                        }
                    }
                    _mensaje = string.Empty;
                    myTrans.Commit();
                }
                catch (OracleException ex1)
                {
                    _error = true;
                    myTrans.Rollback();
                    _mensaje += " - " + ex1.ErrorCode.ToString() + " - " + ex1.Message;
                }
                catch (Exception ex2)
                {
                    _error = true;
                    myTrans.Rollback();
                    _mensaje += " - " + ex2.Message;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    myCommand.Dispose();
                }
            }
            else
            {
                _error = true;
                _mensaje = "No fue posible ejecutar las lista de sqls.";
            }
            if (_error && _mostrarerror) MostrarVentanaError();
        }
        public bool EjecutarStoreProcedure(string strNombreStoreProcedure, int intNumParms, string[] strNombreParams, byte[] btTipoParams, byte[] btDireccionParms, ref long[] lngValorParams, ref decimal[] dcValorParams, ref string[] strValorParams)
        {
            // btTipoParams[] : 1: Input, 2:Output, 3:Input/Output
            _error = false;
            OracleParameter[] axOraParam = new OracleParameter[100];
            int[] intParamsSalida = new int[100];
            int intNumParamsSalida = 0;

            if ((_strconexion != string.Empty) && (strNombreStoreProcedure.Trim().Length > 0))
            {
                OracleConnection con = new OracleConnection(_strconexion);
                OracleCommand myCommand = con.CreateCommand();
                //myCommand.CommandText = "UCBADMIN.VER_RESTANTES_IV";
                myCommand.CommandText = strNombreStoreProcedure;
                myCommand.CommandType = CommandType.StoredProcedure;

                OracleDbType dbTipoDato = new OracleDbType();

                for (int intContaP = 0; intContaP < intNumParms; intContaP++)
                {
                    switch (btTipoParams[intContaP])
                    {
                        case 1:     // numero entero
                            dbTipoDato = OracleDbType.Int64;
                            axOraParam[intContaP] = myCommand.Parameters.Add(strNombreParams[intContaP], dbTipoDato);
                            axOraParam[intContaP].Value = lngValorParams[intContaP];
                            break;
                        case 2:     // numero decimal
                            dbTipoDato = OracleDbType.Decimal;
                            axOraParam[intContaP] = myCommand.Parameters.Add(strNombreParams[intContaP], dbTipoDato);
                            axOraParam[intContaP].Value = dcValorParams[intContaP];
                            break;
                        case 3:     // varchar2
                            dbTipoDato = OracleDbType.Varchar2;
                            axOraParam[intContaP] = myCommand.Parameters.Add(strNombreParams[intContaP], dbTipoDato);
                            axOraParam[intContaP].Value = strValorParams[intContaP];
                            break;
                        default:
                            _error = true;
                            break;
                    }
                    if (!_error)
                    {
                        if (btDireccionParms[intContaP] == 2)
                        {
                            axOraParam[intContaP].Direction = ParameterDirection.Output;
                            intParamsSalida[intNumParamsSalida] = intContaP;
                            intNumParamsSalida++;
                        }
                        else
                            if (btDireccionParms[intContaP] == 3)
                            {
                                axOraParam[intContaP].Direction = ParameterDirection.InputOutput;
                                intParamsSalida[intNumParamsSalida] = intContaP;
                                intNumParamsSalida++;
                            }
                            else
                                axOraParam[intContaP].Direction = ParameterDirection.Input;
                    }
                    else
                        break;
                }

                if (!_error)
                {
                    try
                    {
                        con.Open();
                        myCommand.ExecuteNonQuery();
                        int intPuntero = 0;
                        for (int intContaPS = 0; intContaPS < intNumParamsSalida; intContaPS++)
                        {
                            intPuntero = intParamsSalida[intContaPS];
                            switch (btTipoParams[intPuntero])
                            {
                                case 1:     // numero entero
                                    lngValorParams[intPuntero] = Convert.ToInt64(axOraParam[intPuntero].Value.ToString());
                                    break;
                                case 2:     // numero decimal
                                    dcValorParams[intPuntero] = Convert.ToDecimal(axOraParam[intPuntero].Value.ToString());
                                    break;
                                case 3:     // varchar2
                                    strValorParams[intPuntero] = axOraParam[intPuntero].Value.ToString();
                                    break;
                                default:
                                    _error = true;
                                    break;
                            }
                        }
                    }
                    catch (OracleException ex1)
                    {
                        _error = true;
                        _mensaje += " - " + ex1.ErrorCode.ToString() + " - " + ex1.Message;
                    }
                    catch (Exception ex2)
                    {
                        _error = true;
                        _mensaje += " - " + ex2.Message;
                    }
                    finally
                    {
                        con.Close();
                        con.Dispose();
                        myCommand.Dispose();
                    }
                }
                else
                {
                    con.Dispose();
                    myCommand.Dispose();
                }

            }
            else
            {
                _error = true;
                _mensaje = "No fue posible ejecutar el Store Procedure.";
            }

            if (_error && _mostrarerror) MostrarVentanaError();
            return !_error;
        }
        public long Generar_NumSec(string strSecuencia)
        {
            long lngNumSec = 0;

            if (!string.IsNullOrEmpty(_strconexion) && !string.IsNullOrEmpty(strSecuencia))
            {
                _sql = "select " + strSecuencia + ".nextval num_sec from dual";
                sqlDataTable();
                if (_datatable.Rows.Count > 0)
                {
                    lngNumSec = Convert.ToInt64(_datatable.Rows[0]["num_sec"].ToString());
                }
            }
            return lngNumSec;
        }
        public string Armar_String_Conexion(string strServidor, string strUsuario, string strPwd)
        {
            string strConexion = string.Empty;
            if (!string.IsNullOrEmpty(strServidor.Trim()) && !string.IsNullOrEmpty(strUsuario.Trim()) && !string.IsNullOrEmpty(strPwd.Trim()))
            {
                strConexion = "Data Source= " + strServidor.Trim() + ";Password=" + strPwd.Trim() + ";User ID=" + strUsuario.Trim() + ";";
            }


            return strConexion;
        }        
        public string Revisar_Fecha_Servidor()
        {
            string strFServ = string.Empty;
            if (!string.IsNullOrEmpty(_strconexion))
            {
                _sql = "select to_char(sysdate,'dd/mm/rrrr hh24:mi:ss') f_serv from dual";
                sqlDataTable();
                if (_datatable.Rows.Count > 0)
                {
                    strFServ = _datatable.Rows[0]["f_serv"].ToString();
                }
            }
            return strFServ;
        }
        public bool Revisar_Fecha_Servidor_Entre_Fechas(string strFIni, string strFFin, int intTipo)
        {
            // intTipo:    1: solo fecha, 2:fecha, hora y minutos
            bool blFechaEnIntervalo = false;
            int intTamanioCadenas = 10;
            string strFormatoFecha = "dd/mm/rrrr";
            if (intTipo == 2)
            {
                intTamanioCadenas = 16;
                strFormatoFecha = "dd/mm/rrrr hh24:mi";
            }

            if (!string.IsNullOrEmpty(_strconexion) && strFIni.Length == intTamanioCadenas && strFFin.Length == intTamanioCadenas)
            {
                _sql = "select sysdate f_serv from dual";
                _sql += " where sysdate between to_date('" + strFIni + "','" + strFormatoFecha + "')";
                _sql += "   and to_date('" + strFFin + "','" + strFormatoFecha + "')";
                sqlDataTable();
                if (_datatable.Rows.Count > 0)
                {
                    blFechaEnIntervalo = true;
                }
            }
            return blFechaEnIntervalo;
        }
        public long NEXTVAL_Secuencia(string strNombreSecuencia)
        {
            string msj = "";
            try
            {
                _sql = "select " + strNombreSecuencia + ".nextval from dual";
                sqlDataTable();
                return Convert.ToInt64(_datatable.Rows[0][0]);
            }
            catch (InvalidCastException e)
            {
                msj = e.Message;
                return 0;
            }
        }
        public string ObtieneDiaSemana(string fecha)
        {
            string dia = string.Empty;
            _sql = "select trim(to_char(to_date('" + fecha + "','dd/mm/rrrr'),'DAY','NLS_DATE_LANGUAGE=SPANISH')) dia from dual";
            sqlDataTable();
            if(_datatable.Rows.Count > 0)
            {
                dia = _datatable.Rows[0][0].ToString();
            }
            return dia;
        }
        public decimal Revisar_Diferencia_Fechas(string strFecha1, string strFecha2, int intTipo)
        {
            // intTipo:    1: solo fecha, 2:fecha, hora y minutos
            decimal decDif = 0;
            if (!string.IsNullOrEmpty(_strconexion))
            {
                if (intTipo == 2)
                {
                    _sql = "select to_date('" + strFecha1 + "','dd/mm/rrrr hh24:mi:ss')";
                    _sql += " -to_date('" + strFecha2 + "','dd/mm/rrrr hh24:mi:ss') diferencia";
                }
                else
                {
                    _sql = "select to_date('" + strFecha1 + "','dd/mm/rrrr')";
                    _sql += " -to_date('" + strFecha2 + "','dd/mm/rrrr') diferencia";
                }
                _sql += " from dual";

                sqlDataTable();
                if (_datatable.Rows.Count > 0)
                {
                    decDif = Convert.ToDecimal(_datatable.Rows[0]["diferencia"].ToString());
                }
            }
            return decDif;
        }
        #endregion

        #region Procedimientos y Funciones Locales
        private void MostrarVentanaError()
        {
            libJava1.Desplegar_Mensage_Java(_pagina, _mensaje, 1);
        }
        #endregion

    }
}