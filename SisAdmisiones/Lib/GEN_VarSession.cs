using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nsGEN_VarSession
{
    // Creado por: Milco Cortez; Fecha: 17/03/2015
    // Ultima modificación: Milco Cortez;  Fecha:26/03/2015
    // Descripción: Habilita diferentes métodos para manipular variables de sesion para aplicaciones web forms. 

    public class GEN_VarSession
    {
        //Constantes de variables de sesión
        public const string CONTADORVAR = "Contador";
        public const string TEXTOVAR = "Texto";

        public GEN_VarSession()
        { 

        }

        public T Lee<T>(string variable)
        {
            object valor = HttpContext.Current.Session[variable];
            if (valor == null)
                return default(T);
            else
                return ((T)valor);
        }

        public void Escribe(string variable, object valor)
        {
            HttpContext.Current.Session[variable] = valor;
        }

        public int Contador

        {
            get
            {
                return Lee<int>(CONTADORVAR);
            }
            set
            {
                Escribe(CONTADORVAR, value);
            }
        }

        public string Texto
        {
            get
            {
                return Lee<string>(TEXTOVAR);
            }
            set
            {
                Escribe(TEXTOVAR, value);
            }
        }

    }
}