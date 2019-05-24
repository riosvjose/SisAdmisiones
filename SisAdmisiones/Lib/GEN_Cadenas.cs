using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Globalization;

namespace nsGEN_Cadenas
{
    // Creado por: Milco Cortez; Fecha: 17/03/2015
    // Ultima modificación: Milco Cortez;  Fecha:15/03/2018
    // Descripción: Permite diversas funciones sobre cadenas
    public class GEN_Cadenas
    {
        #region Variables Locales
        #endregion

        #region Atributos
        #endregion

        #region Constructores
        public GEN_Cadenas()
        { }
        #endregion

        #region Metodos
        public bool Texto_Contiene_Caracteres_Especiales(string strTexto, int axTipo, int axBD)
        {
            // axBD = 1:  no permitir comandos sql "select", "intert", "update", "delete", "alter"
            //string specialCharacters = @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=-" + "\"";

            string specialCharacters = @"&'|¬^¨°~" + "\"";
            char[] specialCharactersArray = specialCharacters.ToCharArray();
            int index = strTexto.IndexOfAny(specialCharactersArray);
            if (index > -1) return true;
            if (axTipo >= 1)
            {
                specialCharacters = @"%";
                specialCharactersArray = specialCharacters.ToCharArray();
                index = strTexto.IndexOfAny(specialCharactersArray);
                if (index > -1) return true;
            }
            if (axTipo >= 2)
            {
                specialCharacters = @"$#!?¿¡";
                specialCharactersArray = specialCharacters.ToCharArray();
                index = strTexto.IndexOfAny(specialCharactersArray);
                if (index > -1) return true;
            }
            if (axTipo >= 3)
            {
                specialCharacters = @"+/*\´@<>";
                specialCharactersArray = specialCharacters.ToCharArray();
                index = strTexto.IndexOfAny(specialCharactersArray);
                if (index > -1) return true;
            }
            if (axTipo >= 4)
            {
                specialCharacters = @"_-[]{}()";
                specialCharactersArray = specialCharacters.ToCharArray();
                index = strTexto.IndexOfAny(specialCharactersArray);
                if (index > -1) return true;
            }
            if (axTipo >= 5)
            {
                specialCharacters = @",.;:";
                specialCharactersArray = specialCharacters.ToCharArray();
                index = strTexto.IndexOfAny(specialCharactersArray);
                if (index > -1) return true;
            }
            if (axBD == 1)
            {
                if (strTexto.ToUpper().IndexOf("SELECT ", 0) >= 0) return true;
                if (strTexto.ToUpper().IndexOf("INSERT ", 0) >= 0) return true;
                if (strTexto.ToUpper().IndexOf("UPDATE ", 0) >= 0) return true;
                if (strTexto.ToUpper().IndexOf("DELETE ", 0) >= 0) return true;
                if (strTexto.ToUpper().IndexOf("ALTER ", 0) >= 0) return true;
            }
            return false;
        }

        public bool Texto_Cumple_Expresion(string strTexto, string strExpresion)
        {
            //RegexOptions.IgnoreCase
            Match match = Regex.Match(strTexto, strExpresion);
            if (match.Success)
                return true;
            else
                return false;
        }

        public bool Validar_Fecha_Hora(string strFecha, int intTipo)
        {
            // intTipo = 1:solo fecha; 2:fecha y hora; 3:fecha, hora y segundos

            bool blCumpleFormato = false;
            bool blCumpleTamanio = false;
            DateTime dtFecha1;
            string strFecha1 = string.Empty;
            string strHora1 = string.Empty;

            try
            {
                strFecha1 = strFecha.Trim();
                switch (intTipo)
                {
                    case 1:
                        string strDia = string.Empty;
                        string strMes = string.Empty;
                        string strAnio = string.Empty;
                        if (strFecha.Trim().Length < 10)
                        {
                            strDia = strFecha1.Trim().Substring(0, strFecha1.IndexOf("/"));
                            if (strDia.Length < 2)
                            {
                                strDia = strDia.PadLeft(2, '0');
                                strMes = strFecha1.Trim().Substring(2, strFecha1.Trim().Length - 2);
                                strAnio = strFecha1.Trim().Substring(strFecha1.IndexOf("/"), strFecha1.Trim().Length - 1);
                            }
                            else
                            {
                                strMes = strFecha1.Trim().Substring(3, strFecha1.Trim().Length - 3);
                                strAnio = strFecha1.Trim().Substring(strFecha1.IndexOf("/"), strFecha1.Trim().Length - 2);
                            }
                            strMes= strMes.Substring(0, strMes.IndexOf("/"));
                            if (strMes.Length < 2)
                            {
                                strMes = strMes.PadLeft(2, '0');
                                strAnio = strAnio.Trim().Substring(2, strAnio.Trim().Length - 2);
                            }
                            else
                            {
                                strAnio = strAnio.Trim().Substring(3, strAnio.Trim().Length - 3);
                            }
                            strAnio = strAnio.Trim().Substring(1, strAnio.Trim().Length - 1);
                            strFecha = strDia + "/" + strMes + "/" + strAnio;
                        }
                        strFecha1 = strFecha.Trim();
                        if (strFecha.Trim().Length == 10)
                        {
                            blCumpleTamanio = true;
                        }
                        break;
                    case 2:
                        if (strFecha.Trim().Length == 16)
                        {
                            blCumpleTamanio = true;
                            strHora1 = strFecha.Trim().Substring(11, 5);
                        }
                        break;
                    case 3:
                        if (strFecha.Trim().Length == 19)
                        {
                            blCumpleTamanio = true;
                            strHora1 = strFecha.Trim().Substring(11, 8);
                        }
                        break;
                    default:
                        break;
                }

                if (blCumpleTamanio && strFecha1.Length == 10)
                {
                    dtFecha1 = Convert.ToDateTime(strFecha1);

                    string strSeparadorF1 = strFecha1.Substring(2, 1).Trim();
                    string strSeparadorF2 = strFecha1.Substring(5, 1).Trim();
                    if (strSeparadorF1 == "/" && strSeparadorF2 == "/")
                    {
                        string strAnio = strFecha1.Substring(6, 4).Trim();
                        int intAnio = Convert.ToInt32(strAnio);
                        if (strAnio.Length == 4 && intAnio > 1900 && intAnio < 2200)
                        {
                            string strMes = strFecha1.Substring(3, 2).Trim();
                            int intMes = Convert.ToInt32(strMes);
                            if (strMes.Length == 2 && intMes > 0 && intMes < 13)
                            {
                                string strDia = strFecha1.Substring(0, 2).Trim();
                                int intDia = Convert.ToInt32(strDia);
                                if (strDia.Length == 2 && intDia > 0 && intDia <= 31)
                                {
                                    if (intTipo >= 2)
                                    {
                                        string strSeparadorH = strHora1.Substring(2, 1).Trim();
                                        if (strSeparadorH == ":")
                                        {
                                            string strHora = strHora1.Substring(0, 2).Trim();
                                            int intHora = Convert.ToInt32(strHora);
                                            if (strHora.Length == 2 && intHora >= 0 && intHora < 24)
                                            {
                                                string strMinutos = strHora1.Substring(3, 2).Trim();
                                                int intMinutos = Convert.ToInt32(strMinutos);
                                                if (strMinutos.Length == 2 && intMinutos >= 0 && intMinutos < 60)
                                                {
                                                    if (intTipo == 3)
                                                    {
                                                        string strSeparadorS = strHora1.Substring(5, 1).Trim();
                                                        if (strSeparadorS == ":")
                                                        {
                                                            string strSegundos = strHora1.Substring(6, 2).Trim();
                                                            int intSegundos = Convert.ToInt32(strSegundos);
                                                            if (strSegundos.Length == 2 && intSegundos >= 0 && intSegundos < 60)
                                                            {
                                                                blCumpleFormato = true;
                                                            }
                                                        }
                                                    }
                                                    else
                                                        blCumpleFormato = true;
                                                }
                                            }
                                        }
                                    }
                                    else
                                        blCumpleFormato = true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                blCumpleFormato = false;
            }

            return blCumpleFormato;
        }

        public bool Cadena_Es_Numero(string strCadena, int intTipo)
        {
            // intTipo = 1: integer;  2:decimal
            bool blEsNumero = false;

            switch (intTipo)
            {
                case 1:     // integer
                    int intResultado;
                    blEsNumero = int.TryParse(strCadena, out intResultado);
                    break;
                case 2:     // decimal
                    decimal decResultado;
                    blEsNumero = decimal.TryParse(strCadena, out decResultado);
                    break;
                default:
                    break;
            }
            return blEsNumero;
        }

        public bool Validar_Cadena_Numero(string strCadena, int intTipo, int intNumDecimales, ref int intValor, ref decimal decValor)
        {
            // intTipo = 1: integer;  2:decimal
            //CultureInfo culture = new CultureInfo("en-US");
            bool blEsNumero = false;
            intValor = 0;
            decValor = 0;

            switch (intTipo)
            {
                case 1:     // integer
                    int intResultado;
                    blEsNumero = int.TryParse(strCadena, out intResultado);
                    intValor = intResultado;
                    break;
                case 2:     // decimal
                    decimal decResultado;
                    blEsNumero = decimal.TryParse(strCadena, out decResultado);
                    decValor = decResultado;
                    if (strCadena.IndexOf(@",", 0) >= 0) blEsNumero = false;
                    if (blEsNumero)
                    {
                        decimal decParteDecimal = decResultado - Math.Truncate(decResultado);
                        if (decParteDecimal.ToString().Trim().Length > (intNumDecimales + 2)) blEsNumero = false;
                    }
                    break;
                default:
                    break;
            }
            return blEsNumero;
        }

        public string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        public int Comparar_Fechas(string strFecha1, string strFecha2)
        {
            // 0: fechas incorrectas
            // 1: f1 < f2
            // 2: f1 = f2
            // 3: f1 > f2
            int intResultado = 0;
            DateTime dtiFecha1 = DateTime.ParseExact(strFecha1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dtiFecha2 = DateTime.ParseExact(strFecha2, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            if (dtiFecha1 < dtiFecha2)
                intResultado = 1;
            else
            {
                if (dtiFecha1 == dtiFecha2)
                    intResultado = 2;
                else
                    intResultado = 3;
            }
            return intResultado;
        }

        #endregion

    }
}