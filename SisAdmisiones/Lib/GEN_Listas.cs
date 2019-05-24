using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace nsGEN_Listas
{
    // Creado por: Milco Cortez; Fecha: 17/03/2015
    // Ultima modificación: Milco Cortez;  Fecha:26/03/2015
    // Descripción: Habilita diferentes métodos para manipular variables C# de tipo Lista. 

    public class GEN_Listas
    {

        private List<DataRow> listarow;
        public List<DataRow> ListaRow
        {
            get { return listarow; }
            set { listarow = value; }
        }

        private int intcolumna = 0;
        public int intColumna
        {
            get { return intcolumna; }
            set { intcolumna = value; }
        }

        private string strvalor = string.Empty;
        public string strValor
        {
            get { return strvalor; }
            set { strvalor = value; }
        }

        private int intindice = -1;
        public int intIndice
        {
            get { return intindice; }
        }

        public GEN_Listas()
        { }

        public void Buscar_Lista_Row()
        {
            int axTamano = listarow.Count();
            intindice = -1;
            for (int axConta = 0; axConta < axTamano; axConta++)
            {
                if (listarow[axConta][intcolumna].ToString() == strValor)
                    intindice = axConta;
            }
        }

    }
}