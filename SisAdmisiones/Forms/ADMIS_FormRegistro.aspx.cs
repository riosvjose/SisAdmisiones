﻿using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using nsGEN_VarSession;
using nsGEN_Java;
using nsGEN_WebForms;
using System.Data;
using nsGEN;
using nsBD_GEN;
using nsGEN_ReCaptcha;
using nsGEN_Cadenas;
using Microsoft.Reporting.WebForms;
using System.IO;
using nsBD_ACAD;
using nsGEN_AutenticacionBD;
using System.Text.RegularExpressions;

namespace SisAdmisiones.Forms
{
    public partial class ADMIS_FormRegistro : System.Web.UI.Page
    {
        #region "Librerias Externas"
        GEN_VarSession axVarSes = new GEN_VarSession();
        GEN_Java libJava = new GEN_Java();
        GEN_WebForms webForms = new GEN_WebForms();
        SIS_GeneralesSistema Generales = new SIS_GeneralesSistema();
        #endregion

        #region "Clase de tablas de la Base de Datos"
        BD_ADMIS_DatosPersonales libDatos = new BD_ADMIS_DatosPersonales(); //´Prueba
        #endregion

        #region "Funciones y procedimientos"
        private void CargarDatosIniciales(string strCon)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "$('#modalAlumnoExistente').hide();$('.modal-backdrop').hide();", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "$('#modalFamiliarExistente').hide();$('.modal-backdrop').hide();", true);
            if (!string.IsNullOrEmpty(strCon.Trim()))
            {
                pnMensajeOK.Visible = false;
                pnMensajeError.Visible = false;
                CargarDdlPaisBach();
                ddlPaisBach.SelectedValue = "1";// por defecto carga bolivia
                CargarDdlEstadosBach(ddlPaisBach.SelectedValue);
                //ddlEstadoBach.SelectedValue = "1";// por defecto carga la paz
                CargarDdlLocalidadesBach(ddlEstadoBach.SelectedValue);
                //ddlCiudadBach.SelectedValue = "1";// por defecto carga la paz
                CargarDdlPaisNac();
                ddlPaisNac.SelectedValue = "1"; //por defecto carga bolivia
                CargarDdlEstadosNac(ddlPaisNac.SelectedValue);
                //ddlEstadoNac.SelectedValue = "1"; // por defecto carga la paz
                CargarDdlLocalidadesNac(ddlEstadoNac.SelectedValue);
                //ddlCiudadNac.SelectedValue = "1"; // por defecto carga la paz
                CargarDdlNacionalidad();
                ddlNacionalidad.SelectedValue = "1";// por defecto carga boliviana
                CargarDdlColegios();
                CargarDdlViveCon();
                CargarDdlParentesco();
                CargarDdlGenero();
                CargarDdlGeneroTutor();
                CargarDdlSangre();
                CargarDdlTipoColegio();
                CargarDdlTurnoColegio();
                CargarDdlAreaColegio();
                CargarDdlParentesco();
                CargarDdlEstadoCivil();
                CargarDdlSubdeptoAcad();
                CargarDdlPensums();
                CargarDdlSemestres();
                CargarDdlDiscapacidad();
                CargarDdlTipoDocTutor();
                CargarDdlTipoDoc();
                CargarDdlAnios();
                CargarDdlTipoAdmision();
                CargarDdlAreaNac();
                CargarDdlLocalidadZona();
                CargarDdlLugarInscripcion();

                if (!string.IsNullOrEmpty(axVarSes.Lee<string>("strMensajeExito")))
                {
                    pnMensajeOK.Visible = true;
                    pnMensajeOK.Focus();
                    lblMensajeOK.Text = axVarSes.Lee<string>("strMensajeExito");
                    axVarSes.Escribe("strMensajeExito", string.Empty);
                }
                if (axVarSes.Lee<string>("strRol").Equals("1"))
                {
                    pnObservaciones.Visible = true;
                    pnEnviar.Visible = false;
                    pnPensums.Visible = true;
                    pnSemestres.Visible = true;
                }
                else
                {
                    pnObservaciones.Visible = false;
                    pnEnviar.Visible = true;
                }
                evaluarLlenado();
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        public void CargarDdlTipoAdmision()
        {
            BD_Dominios libDominios = new BD_Dominios();
            libDominios.Dominio = "TIPO_ADMISION";
            ddlTipoAdmision.DataSource = libDominios.DTDominiosAbr("", axVarSes.Lee<string>("strConexion"));
            ddlTipoAdmision.DataTextField = "DESCRIPCION";
            ddlTipoAdmision.DataValueField = "VALOR";
            ddlTipoAdmision.DataBind();
            ddlTipoAdmision.SelectedValue = "1";
        }
        public void CargarDdlLugarInscripcion()
        {
            BD_GEN_Subunidades_Ubicaciones Ubicaciones = new BD_GEN_Subunidades_Ubicaciones();
            Ubicaciones.StrConexion = axVarSes.Lee<string>("strConexion");
            ddlLugarInscripcion.DataSource = Ubicaciones.DTUbicaciones(axVarSes.Lee<string>("strNsSubunidad"),"1",false);
            ddlLugarInscripcion.DataTextField = "nombre";
            ddlLugarInscripcion.DataValueField = "num_sec_ubicacion";
            ddlLugarInscripcion.DataBind();
            ddlLugarInscripcion.SelectedValue = "1";
        }
        public void CargarDdlLocalidadZona()
        {
            BD_Localidades libLocalidades = new BD_Localidades();
            libLocalidades.StrConexion = axVarSes.Lee<string>("strConexion");
            DataTable dt = libLocalidades.ListaLocalidadesBuscadas("1");
            if (dt.Rows.Count > 0)
            {
                ddlLocalidadZona.DataSource = dt;
                ddlLocalidadZona.DataTextField = "nombre";
                ddlLocalidadZona.DataValueField = "num_sec";
                ddlLocalidadZona.SelectedValue = "1";
                ddlLocalidadZona.DataBind();
            }
        }
        public void CargarDdlAnios()
        {
            BD_ADMIS_DatosPersonales libDatos = new BD_ADMIS_DatosPersonales();
            libDatos.StrConexion = axVarSes.Lee<string>("strConexion");
            ddlAnio.DataSource = libDatos.dtAnios();
            ddlAnio.DataTextField = "anio";
            ddlAnio.DataValueField = "anio";
            ddlAnio.DataBind();
        }
        public void CargarDdlSemestres()
        {
            BD_Semestres libSemestres = new BD_Semestres();
            libSemestres.StrConexion = axVarSes.Lee<string>("strConexion");
            ddlSemestre.DataSource = libSemestres.dtSemestres();
            ddlSemestre.DataTextField = "sem";
            ddlSemestre.DataValueField = "num_sec";
            ddlSemestre.DataBind();
        }
        public void CargarDdlSubdeptoAcad()
        {
            BD_GEN_SubDepartamentos libSubdepto = new BD_GEN_SubDepartamentos();
            libSubdepto.StrConexion = axVarSes.Lee<string>("strConexion");
            ddlCarreras.DataSource = libSubdepto.dtCarrerasInscripciones();
            ddlCarreras.DataTextField = "carrera";
            ddlCarreras.DataValueField = "num_sec_subdepartamento";
            ddlCarreras.DataBind();
        }
        public void CargarDdlPensums()
        {
            if (ddlCarreras.SelectedValue != string.Empty)
            {
                BD_Pensums libPensum = new BD_Pensums();
                libPensum.StrConexion = axVarSes.Lee<string>("strConexion");
                libPensum.NumSecSubDepartamento = Convert.ToInt64(ddlCarreras.SelectedValue);
                ddlPensumIngreso.DataSource = libPensum.DTPensumsCarreras();
                ddlPensumIngreso.DataTextField = "descripcion";
                ddlPensumIngreso.DataValueField = "num_sec_pensum";
                ddlPensumIngreso.DataBind();
            }
            else
            {
                ddlPensumIngreso.Items.Clear();
            }
        }
        public void CargarDdlEstadoCivil()
        {
            BD_Dominios libDominios = new BD_Dominios();
            libDominios.Dominio = "ESTADO_CIVIL";
            ddlEstadoCivil.DataSource = libDominios.DTDominiosAbr("", axVarSes.Lee<string>("strConexion"));
            ddlEstadoCivil.DataTextField = "DESCRIPCION";
            ddlEstadoCivil.DataValueField = "VALOR";
            ddlEstadoCivil.DataBind();
        }
        public void CargarDdlDiscapacidad()
        {
            BD_Dominios libDominios = new BD_Dominios();
            libDominios.Dominio = "TIPO_DISCAPACIDAD";
            ddlDiscapacidad.DataSource = libDominios.DTDominiosAlfa("", axVarSes.Lee<string>("strConexion"));
            ddlDiscapacidad.DataTextField = "DESCRIPCION";
            ddlDiscapacidad.DataValueField = "VALOR";
            ddlDiscapacidad.DataBind();
            ddlDiscapacidad.SelectedValue = "0";
        }
        public void CargarDdlTipoColegio()
        {
            BD_Dominios libDominios = new BD_Dominios();
            libDominios.Dominio = "TIPO_COLEGIO";
            ddlTipoColegio.DataSource = libDominios.DTDominiosAbr("", axVarSes.Lee<string>("strConexion"));
            ddlTipoColegio.DataTextField = "DESCRIPCION";
            ddlTipoColegio.DataValueField = "VALOR";
            ddlTipoColegio.DataBind();
        }
        public void CargarDdlTurnoColegio()
        {
            BD_Dominios libDominios = new BD_Dominios();
            libDominios.Dominio = "TURNO_COLEGIO";
            ddlTurno.DataSource = libDominios.DTDominiosAbr("", axVarSes.Lee<string>("strConexion"));
            ddlTurno.DataTextField = "DESCRIPCION";
            ddlTurno.DataValueField = "VALOR";
            ddlTurno.DataBind();
        }
        public void CargarDdlAreaColegio()
        {
            BD_Dominios libDominios = new BD_Dominios();
            libDominios.Dominio = "TIPO_LUGAR";
            ddlAreaColegio.DataSource = libDominios.DTDominiosAbr("0", axVarSes.Lee<string>("strConexion"));
            ddlAreaColegio.DataTextField = "DESCRIPCION";
            ddlAreaColegio.DataValueField = "VALOR";
            ddlAreaColegio.DataBind();
        }
        public void CargarDdlColegios()
        {
            if (ddlCiudadBach.SelectedValue != string.Empty)
            {
                BD_Colegios libColegios = new BD_Colegios();
                libColegios.StrConexion = axVarSes.Lee<string>("strConexion");
                libColegios.NumSecLocalidad = Convert.ToInt64(ddlCiudadBach.SelectedValue);
                ddlColegio.DataSource = libColegios.dtColegiosLocalidad();
                ddlColegio.DataTextField = "colegio";
                ddlColegio.DataValueField = "NUM_SEC_COLEGIO";
                ddlColegio.DataBind();
            }
            else
            {
                ddlColegio.Items.Clear();
            }
        }

        public void CargarDdlSangre()
        {
            BD_Dominios libDominios = new BD_Dominios();
            libDominios.Dominio = "TIPO_SANGRE";
            ddlGrupoSangre.DataSource = libDominios.DTDominiosAbr( "", axVarSes.Lee<string>("strConexion"));
            ddlGrupoSangre.DataTextField = "DESCRIPCION";
            ddlGrupoSangre.DataValueField = "VALOR";
            ddlGrupoSangre.DataBind();
        }
        public void CargarDdlGenero()
        {
            BD_Dominios libDominios = new BD_Dominios();
            libDominios.Dominio = "SEXO";
            ddlGenero.DataSource = libDominios.DTDominiosAbr("", axVarSes.Lee<string>("strConexion"));
            ddlGenero.DataTextField = "DESCRIPCION";
            ddlGenero.DataValueField = "VALOR";
            ddlGenero.DataBind();
        }
        public void CargarDdlGeneroTutor()
        {
            BD_Dominios libDominios = new BD_Dominios();
            libDominios.Dominio = "SEXO";
            ddlGeneroTutor.DataSource = libDominios.DTDominiosAbr("", axVarSes.Lee<string>("strConexion"));
            ddlGeneroTutor.DataTextField = "DESCRIPCION";
            ddlGeneroTutor.DataValueField = "VALOR";
            ddlGeneroTutor.DataBind();
        }
        public void CargarDdlAreaNac()
        {
            BD_Dominios libDominios = new BD_Dominios();
            libDominios.Dominio = "TIPO_LUGAR";
            ddlAreaNacimiento.DataSource = libDominios.DTDominiosAbr("0", axVarSes.Lee<string>("strConexion"));
            ddlAreaNacimiento.DataTextField = "DESCRIPCION";
            ddlAreaNacimiento.DataValueField = "VALOR";
            ddlAreaNacimiento.DataBind();
        }
        public void CargarDdlPaisNac()
        {
            BD_Paises libPaises = new BD_Paises();
            libPaises.StrConexion = axVarSes.Lee<string>("strConexion");
            ddlPaisNac.DataSource = libPaises.ListaPaises();
            ddlPaisNac.DataTextField = "nombre";
            ddlPaisNac.DataValueField = "num_sec";
            ddlPaisNac.DataBind();
        }
        public void CargarDdlEstadosNac(string pais)
        {
            if (ddlPaisNac.SelectedValue != string.Empty)
            {
                BD_Estados libEstados = new BD_Estados();
                libEstados.StrConexion = axVarSes.Lee<string>("strConexion");
                ddlEstadoNac.DataSource = libEstados.ListaEstados(pais);
                ddlEstadoNac.DataTextField = "nombre";
                ddlEstadoNac.DataValueField = "num_sec";
                ddlEstadoNac.DataBind();
            }
            else
            {
                ddlEstadoNac.Items.Clear();
            }
        }
        public void CargarDdlLocalidadesNac(string estado)
        {
            if (ddlEstadoNac.SelectedValue != string.Empty)
            {
                BD_Localidades libLocalidades = new BD_Localidades();
                libLocalidades.StrConexion = axVarSes.Lee<string>("strConexion");
                DataTable dt = libLocalidades.ListaLocalidades(estado);
                if (dt.Rows.Count>0)
                {
                    ddlCiudadNac.DataSource = dt;
                    ddlCiudadNac.DataTextField = "nombre";
                    ddlCiudadNac.DataValueField = "num_sec";
                    //ddlCiudadNac.SelectedIndex = 0;
                    ddlCiudadNac.DataBind();
                }
                
            }
            else
            {
                ddlCiudadNac.Items.Clear();
            }
        }
        public void CargarDdlNacionalidad()
        {
            BD_Paises libPaises = new BD_Paises();
            libPaises.StrConexion = axVarSes.Lee<string>("strConexion");
            ddlNacionalidad.DataSource = libPaises.ListaPaises();
            ddlNacionalidad.DataTextField = "nacionalidad";
            ddlNacionalidad.DataValueField = "num_sec";
            ddlNacionalidad.DataBind();
        }
        public void CargarDdlPaisBach()
        {
            BD_Paises libPaises = new BD_Paises();
            libPaises.StrConexion = axVarSes.Lee<string>("strConexion");
            ddlPaisBach.DataSource = libPaises.ListaPaises();
            ddlPaisBach.DataTextField = "nombre";
            ddlPaisBach.DataValueField = "num_sec";
            ddlPaisBach.DataBind();
        }
        public void CargarDdlEstadosBach(string pais)
        {
            if (ddlPaisBach.SelectedValue != string.Empty)
            {
                BD_Estados libEstados = new BD_Estados();
                libEstados.StrConexion = axVarSes.Lee<string>("strConexion");
                ddlEstadoBach.DataSource = libEstados.ListaEstados(pais);
                ddlEstadoBach.DataTextField = "nombre";
                ddlEstadoBach.DataValueField = "num_sec";
                ddlEstadoBach.DataBind();
                
            }
            else
            {
                ddlEstadoBach.Items.Clear();
            }
        }
        public void CargarDdlLocalidadesBach(string estado)
        {
            if (ddlEstadoBach.SelectedValue != string.Empty)
            {
                BD_Localidades libLocalidades = new BD_Localidades();
                libLocalidades.StrConexion = axVarSes.Lee<string>("strConexion");
                ddlCiudadBach.DataSource = libLocalidades.ListaLocalidades(estado);
                ddlCiudadBach.DataTextField = "nombre";
                ddlCiudadBach.DataValueField = "num_sec";
                ddlCiudadBach.DataBind();
                if (!string.IsNullOrEmpty(ddlCiudadBach.SelectedValue))
                {
                    CargarDdlColegios();
                }

            }
            else
            {
                ddlCiudadBach.Items.Clear();
            }
        }
        public void CargarDdlParentesco()
        {
            BD_Dominios libDominios = new BD_Dominios();
            libDominios.Dominio = "TIPO_FAMILIAR";
            ddlParentesco.DataSource = libDominios.DTDominiosAlfa("", axVarSes.Lee<string>("strConexion"));
            ddlParentesco.DataTextField = "DESCRIPCION";
            ddlParentesco.DataValueField = "VALOR";
            ddlParentesco.DataBind();
        }
        public void CargarDdlViveCon()
        {
            BD_Dominios libDominios = new BD_Dominios();
            libDominios.Dominio = "VIVE_CON";
            ddlViveCon.DataSource = libDominios.DTDominiosAlfa("", axVarSes.Lee<string>("strConexion"));
            ddlViveCon.DataTextField = "DESCRIPCION";
            ddlViveCon.DataValueField = "VALOR";
            ddlViveCon.DataBind();
        }
        public void CargarDdlTipoDoc()
        {
            BD_Dominios libDominios = new BD_Dominios();
            libDominios.Dominio = "TIPO_DOC";
            ddlTipoDocIdentidad.DataSource = libDominios.DTDominiosAlfa("2", axVarSes.Lee<string>("strConexion"));
            ddlTipoDocIdentidad.DataTextField = "DESCRIPCION";
            ddlTipoDocIdentidad.DataValueField = "VALOR";
            ddlTipoDocIdentidad.DataBind();
            ddlTipoDocIdentidad.SelectedValue = "1";
        }
        public void CargarDdlTipoDocTutor()
        {
            BD_Dominios libDominios = new BD_Dominios();
            libDominios.Dominio = "TIPO_DOC";
            ddlTipoDocIdentidadTutor.DataSource = libDominios.DTDominiosAlfa("2", axVarSes.Lee<string>("strConexion"));
            ddlTipoDocIdentidadTutor.DataTextField = "DESCRIPCION";
            ddlTipoDocIdentidadTutor.DataValueField = "VALOR";
            ddlTipoDocIdentidadTutor.DataBind();
            ddlTipoDocIdentidadTutor.SelectedValue = "1";
        }

        public void EliminarEspaciosExtras()
        {
            tbNombreCompleto.Text= Regex.Replace(tbNombreCompleto.Text, @"\s+", " ");
            tbNombres.Text = Regex.Replace(tbNombres.Text, @"\s+", " ");
            tbNombreTutor.Text = Regex.Replace(tbNombreTutor.Text, @"\s+", " ");
            tbPrimerApellido.Text = Regex.Replace(tbPrimerApellido.Text, @"\s+", " ");
            tbPrimerApTutor.Text = Regex.Replace(tbPrimerApTutor.Text, @"\s+", " ");
            tbSegundoApellido.Text = Regex.Replace(tbSegundoApellido.Text, @"\s+", " ");
            tbSegundoApTutor.Text = Regex.Replace(tbSegundoApTutor.Text, @"\s+", " ");
        }

        protected void evaluarLlenado()
        {
            long aux = 0;
            Match me = Regex.Match(axVarSes.Lee<string>("strPersonaRegistrar"), "(\\d+)");
            if (me.Success)
            {
                aux += Convert.ToInt64(me.Value);
            }
            if ((!string.IsNullOrEmpty(axVarSes.Lee<string>("strPersonaRegistrar")))&&(aux>0)&&(axVarSes.Lee<string>("strOperacion").Equals("1")))
            {
                BD_ADMIS_DatosPersonales libDatosPer = new BD_ADMIS_DatosPersonales();
                libDatosPer.StrConexion = axVarSes.Lee<string>("strConexion");
                libDatosPer.NumSecDatosPer = Convert.ToInt64(axVarSes.Lee<string>("strPersonaRegistrar"));
                libDatosPer.Ver();
                tbPrimerApellido.Text = libDatosPer.PrimerApellido;
                tbSegundoApellido.Text = libDatosPer.SegundoApellido;
                ddlLocalidadZona.SelectedValue = libDatosPer.NumSecLocalidadDomicilio.ToString();
                ddlLugarInscripcion.SelectedValue = libDatosPer.NumSecUbicacionInscripcion.ToString();
                tbNombres.Text= libDatosPer.Nombres;
                tbDocIdentidad.Text = libDatosPer.DocIdentidad;
                ddlTipoDocIdentidad.SelectedValue = libDatosPer.TipoDocIdentidad.ToString();
                ddlGenero.SelectedValue = libDatosPer.Genero.ToString();
                ddlGrupoSangre.SelectedValue = libDatosPer.GrupoSangre.ToString();
                ddlEstadoCivil.SelectedValue = libDatosPer.EstadoCivil.ToString();
                ddlDiscapacidad.SelectedValue = libDatosPer.TipoDiscapacidad.ToString();
                tbCalleAvenida.Text = libDatosPer.AvenidaCalle;
                tbNumeroDom.Text = libDatosPer.Numero;
                tbZona.Text = libDatosPer.Zona;
                tbNombreEdificio.Text = libDatosPer.Edificio;
                tbPiso.Text=libDatosPer.Piso;
                tbNumeroDepto.Text = libDatosPer.Depto;
                tbTelefonoDomicilio.Text = libDatosPer.Telefono.ToString();
                tbCelular.Text = libDatosPer.Celular.ToString();
                libDatosPer.Celular = tbCelular.Text;
                tbEmail.Text = libDatosPer.Email;
                ddlViveCon.SelectedValue = libDatosPer.ViveCon.ToString();
                tbFechaNac.Text = libDatosPer.FechaNacimiento;
                ddlAreaNacimiento.SelectedValue = libDatosPer.AreaNacimiento.ToString();
                BD_Localidades liblocalidades = new BD_Localidades();
                liblocalidades.StrConexion = axVarSes.Lee<string>("strConexion");
                liblocalidades.NumSec = libDatosPer.NumSecLocalidadNac;
                string auxestado = liblocalidades.EstadoLocalidad();
                BD_Estados libestados = new BD_Estados();
                libestados.StrConexion = axVarSes.Lee<string>("strConexion");
                libestados.NumSec = Convert.ToInt64(auxestado);
                ddlPaisNac.SelectedValue = libestados.PaisEstado();
                CargarDdlEstadosNac(ddlPaisNac.SelectedValue);
                if (ddlEstadoNac.Items.Count>0)
                {
                    ddlEstadoNac.SelectedValue = auxestado;
                }
                CargarDdlLocalidadesNac(ddlEstadoNac.SelectedValue);
                if (ddlCiudadNac.Items.Count > 0)
                {
                    ddlCiudadNac.SelectedValue = libDatosPer.NumSecLocalidadNac.ToString();
                }
                ddlNacionalidad.SelectedValue = libDatosPer.NumSecNacionalidad.ToString();
                tbObservaciones.Text = libDatosPer.Observaciones;
                liblocalidades.NumSec = libDatosPer.NumSecLocalidadBachillerato;
                auxestado = liblocalidades.EstadoLocalidad();
                libestados.NumSec = Convert.ToInt64(auxestado);
                ddlPaisBach.SelectedValue = libestados.PaisEstado();
                CargarDdlEstadosBach(ddlPaisBach.SelectedValue);
                if (ddlEstadoBach.Items.Count > 0)
                {
                    ddlEstadoBach.SelectedValue = auxestado;
                }
                CargarDdlLocalidadesBach(ddlEstadoBach.SelectedValue);
                if (ddlCiudadBach.Items.Count > 0)
                {
                    ddlCiudadBach.SelectedValue = libDatosPer.NumSecLocalidadBachillerato.ToString();
                }
                CargarDdlColegios();
                if (ddlColegio.Items.Count > 0)
                {
                    ddlColegio.SelectedValue = libDatosPer.NumSecColegio.ToString();
                }
                ddlAnio.SelectedValue = libDatosPer.AnioBachillerato.ToString();
                ddlTipoColegio.SelectedValue = libDatosPer.TipoColegio.ToString();
                ddlAreaColegio.SelectedValue = libDatosPer.AreaColegio.ToString();
                ddlTurno.SelectedValue = libDatosPer.Turno.ToString();
                ddlCarreras.SelectedValue = libDatosPer.NumSecSubdepartamento.ToString();

                BD_ADMIS_DatosTutor libtutor = new BD_ADMIS_DatosTutor();
                libtutor.StrConexion = axVarSes.Lee<string>("strConexion");
                libtutor.NumSecDatosPer = libDatosPer.NumSecDatosPer;
                libtutor.Ver();
                ddlParentesco.SelectedValue = libtutor.TipoTutor.ToString();
                tbPrimerApTutor.Text = libtutor.PrimerApellido;
                tbSegundoApTutor.Text = libtutor.SegundoApellido;
                tbNombreTutor.Text = libtutor.Nombres;
                tbDocIdentidadTutor.Text = libtutor.DocIdentidad;
                ddlTipoDocIdentidadTutor.SelectedValue = libtutor.TipoDocIdentidad.ToString();
                ddlGeneroTutor.SelectedValue = libtutor.Genero.ToString();
                tbCalleAvenidaTutor.Text = libtutor.AvenidaCalle;
                tbNumeroDomTutor.Text = libtutor.Numero;
                tbZonaTutor.Text = libtutor.Zona;
                tbTelefonoTutor.Text = libtutor.Telefono.ToString();
                tbCelularTutor.Text = libtutor.Celular;
                tbEmailTutor.Text = libtutor.Email;
                tbInstitucionLaboralTutor.Text = libtutor.InstitucionTrabajo;
                tbCargoTutor.Text = libtutor.Cargo;
                tbTelefonoOficina.Text = libtutor.TelefonoTrabajo;
                tbEdificioTutor.Text =libtutor.Edificio;
                tbDeptoTutor.Text = libtutor.Depto;
                if (libtutor.AutSeguimiento == 1)
                {
                    rbSi.Checked = true;
                }
                if (libtutor.AutSeguimiento == 0 )
                {
                    rbNo.Checked = true;
                }
                BD_ADMIS_ContactoEmergencia libContacto = new BD_ADMIS_ContactoEmergencia();
                libContacto.StrConexion = axVarSes.Lee<string>("strConexion");
                libContacto.NumSecDatosPer = libDatosPer.NumSecDatosPer;
                libContacto.Ver();
                tbNombreCompleto.Text = libContacto.NombreCompleto;
                tbTelefonoContacto1.Text = libContacto.TelefonoContacto1;
                tbTelefonoContacto2.Text = libContacto.TelefonoContacto2;
                CargarDdlPensums();
            }
            else
            {
                CargarDdlEstadosBach(ddlPaisBach.SelectedValue);
                ddlEstadoBach.SelectedValue = "1";// por defecto carga la paz
                CargarDdlLocalidadesBach(ddlEstadoBach.SelectedValue);
                ddlCiudadBach.SelectedValue = "1";// por defecto carga la paz
                CargarDdlColegios();
                CargarDdlEstadosNac(ddlPaisNac.SelectedValue);
                ddlEstadoNac.SelectedValue = "1"; // por defecto carga la paz
                CargarDdlLocalidadesNac(ddlEstadoNac.SelectedValue);
                ddlCiudadNac.SelectedValue = "1"; // por defecto carga la paz
            }
        }

        public void GenerarREP(DataTable dtDatos)
        {
            dtDatos.Columns.Add("Semestre", Type.GetType("System.String"));
            dtDatos.Columns.Add("Carrera", Type.GetType("System.String"));
            dtDatos.Columns.Add("PrimerApellido", Type.GetType("System.String"));
            dtDatos.Columns.Add("SegundoApellido", Type.GetType("System.String"));
            dtDatos.Columns.Add("Nombres", Type.GetType("System.String"));
            dtDatos.Columns.Add("DocIdentidad", Type.GetType("System.String"));
            dtDatos.Columns.Add("TipoDoc", Type.GetType("System.String"));
            dtDatos.Columns.Add("Genero", Type.GetType("System.String"));
            dtDatos.Columns.Add("FechaNac", Type.GetType("System.String"));
            dtDatos.Columns.Add("Edad", Type.GetType("System.String"));
            dtDatos.Columns.Add("PaisNac", Type.GetType("System.String"));
            dtDatos.Columns.Add("Nacionalidad", Type.GetType("System.String"));
            dtDatos.Columns.Add("CalleAvenida", Type.GetType("System.String"));
            dtDatos.Columns.Add("Numero", Type.GetType("System.String"));
            dtDatos.Columns.Add("Zona", Type.GetType("System.String"));
            dtDatos.Columns.Add("Edificio", Type.GetType("System.String"));
            dtDatos.Columns.Add("Depto", Type.GetType("System.String"));
            dtDatos.Columns.Add("TelfDomicilio", Type.GetType("System.String"));
            dtDatos.Columns.Add("Celular", Type.GetType("System.String"));
            dtDatos.Columns.Add("CorreoElectronico", Type.GetType("System.String"));
            dtDatos.Columns.Add("ViveCon", Type.GetType("System.String"));
            dtDatos.Columns.Add("ColegioEgreso", Type.GetType("System.String"));
            dtDatos.Columns.Add("AnioEgreso", Type.GetType("System.String"));
            dtDatos.Columns.Add("TipoColegio", Type.GetType("System.String"));
            dtDatos.Columns.Add("TurnoColegio", Type.GetType("System.String"));
            dtDatos.Columns.Add("PaisBach", Type.GetType("System.String"));
            dtDatos.Columns.Add("CiudadBach", Type.GetType("System.String"));
            dtDatos.Columns.Add("Discapacidad", Type.GetType("System.String"));
            dtDatos.Columns.Add("AutorizaSeguimientoSi", Type.GetType("System.String"));
            dtDatos.Columns.Add("TipoTutor", Type.GetType("System.String"));
            dtDatos.Columns.Add("TutorDocIdentidad", Type.GetType("System.String"));
            dtDatos.Columns.Add("TutorPrimerAp", Type.GetType("System.String"));
            dtDatos.Columns.Add("TutorSegundoAp", Type.GetType("System.String"));
            dtDatos.Columns.Add("TutorNombres", Type.GetType("System.String"));
            dtDatos.Columns.Add("TutorDireccion", Type.GetType("System.String"));
            dtDatos.Columns.Add("TutorZona", Type.GetType("System.String"));
            dtDatos.Columns.Add("TutorTelfDom", Type.GetType("System.String"));
            dtDatos.Columns.Add("TutorCelular", Type.GetType("System.String"));
            dtDatos.Columns.Add("TutorCorreoElectronico", Type.GetType("System.String"));
            dtDatos.Columns.Add("TutorInstitucionLaboral", Type.GetType("System.String"));
            dtDatos.Columns.Add("TutorCargo", Type.GetType("System.String"));
            dtDatos.Columns.Add("TutorTelfTrabajo", Type.GetType("System.String"));
            dtDatos.Columns.Add("Observaciones", Type.GetType("System.String"));
            dtDatos.Columns.Add("TipoSangre", Type.GetType("System.String"));
            dtDatos.Columns.Add("EstadoCivil", Type.GetType("System.String"));
            dtDatos.Columns.Add("CiudadNac", Type.GetType("System.String"));
            dtDatos.Columns.Add("Areabach", Type.GetType("System.String"));
            dtDatos.Columns.Add("AutorizaSeguimientoNo", Type.GetType("System.String"));
            dtDatos.Columns.Add("FechaEmision", Type.GetType("System.String"));
            dtDatos.Columns.Add("Localidad_Domicilio", Type.GetType("System.String"));
            dtDatos.Columns.Add("Ubicacion_Inscripcion", Type.GetType("System.String"));

            DataRow rwFila;
            rwFila = dtDatos.NewRow();
            SIS_GeneralesSistema Generales = new SIS_GeneralesSistema();
            Generales.StrConexion = axVarSes.Lee<string>("strConexion");
            rwFila["FechaEmision"] = Generales.FechaActual(3);
            rwFila["Edad"] = Generales.EdadPersona(Convert.ToDateTime(tbFechaNac.Text.Trim()).ToString("dd/MM/yyyy"))+" años.";
            rwFila["Semestre"] = ddlSemestre.SelectedItem.ToString();
            rwFila["Carrera"] = ddlCarreras.SelectedItem;
            rwFila["PrimerApellido"] = tbPrimerApellido.Text.ToUpper();
            rwFila["SegundoApellido"] = tbSegundoApellido.Text.ToUpper();
            rwFila["Nombres"] = tbNombres.Text.ToUpper();
            rwFila["DocIdentidad"] = tbDocIdentidad.Text;
            rwFila["TipoDoc"] = ddlTipoDocIdentidad.SelectedItem;
            rwFila["Genero"] = ddlGenero.SelectedItem;
            rwFila["FechaNac"] = Convert.ToDateTime(tbFechaNac.Text.Trim()).ToString("dd/MM/yyyy");
            rwFila["PaisNac"] = ddlPaisNac.SelectedItem;
            rwFila["Nacionalidad"] = ddlNacionalidad.SelectedItem;
            rwFila["CalleAvenida"] = tbCalleAvenida.Text;
            rwFila["Numero"] = tbNumeroDom.Text;
            rwFila["Zona"] = tbZona.Text;
            rwFila["Edificio"] = tbNombreEdificio.Text;
            rwFila["Depto"] = tbNumeroDepto.Text;
            rwFila["TelfDomicilio"] = tbTelefonoDomicilio.Text;
            rwFila["Celular"] = tbCelular.Text;
            rwFila["CorreoElectronico"] = tbEmail.Text;
            rwFila["ViveCon"] = ddlViveCon.SelectedItem;
            rwFila["ColegioEgreso"] = ddlColegio.SelectedItem;
            rwFila["AnioEgreso"] = ddlAnio.SelectedItem;
            rwFila["TipoColegio"] = ddlTipoColegio.SelectedItem;
            rwFila["TurnoColegio"] = ddlTurno.SelectedItem;
            rwFila["PaisBach"] = ddlPaisBach.SelectedItem;
            rwFila["CiudadBach"] = ddlCiudadBach.SelectedItem;
            rwFila["Discapacidad"] = ddlDiscapacidad.SelectedItem;
            rwFila["Localidad_Domicilio"] = ddlLocalidadZona.SelectedItem;
            rwFila["Ubicacion_Inscripcion"] = ddlLugarInscripcion.SelectedItem;

            rwFila["TipoTutor"] = ddlParentesco.SelectedItem;
            rwFila["TutorDocIdentidad"] = tbDocIdentidadTutor.Text;
            rwFila["TutorPrimerAp"] = tbPrimerApTutor.Text.ToUpper();
            rwFila["TutorSegundoAp"] = tbSegundoApTutor.Text.ToUpper();
            rwFila["TutorNombres"] = tbNombreTutor.Text.ToUpper();
            rwFila["TutorDireccion"] = tbCalleAvenidaTutor.Text+" N° "+tbNumeroDomTutor.Text;
            rwFila["TutorZona"] = tbZonaTutor.Text;
            rwFila["TutorTelfDom"] = tbTelefonoTutor.Text;
            rwFila["TutorCelular"] = tbCelularTutor.Text;
            rwFila["TutorCorreoElectronico"] =tbEmailTutor.Text;
            rwFila["TutorInstitucionLaboral"] = tbInstitucionLaboralTutor.Text;
            rwFila["TutorCargo"] = tbCargoTutor.Text;
            rwFila["TutorTelfTrabajo"] = tbTelefonoOficina.Text;
            rwFila["Observaciones"] = tbObservaciones.Text;
            rwFila["TipoSangre"] = ddlGrupoSangre.SelectedItem;
            rwFila["EstadoCivil"] = ddlEstadoCivil.SelectedItem;
            rwFila["CiudadNac"] = ddlCiudadNac.SelectedItem;
            rwFila["Areabach"] = ddlAreaColegio.SelectedItem;
            if (rbSi.Checked) {
                rwFila["AutorizaSeguimientoNo"] = "";
                rwFila["AutorizaSeguimientoSi"] = "x";
            }
            else if(rbNo.Checked)
            {
                rwFila["AutorizaSeguimientoNo"] = "x";
                rwFila["AutorizaSeguimientoSi"] = "";
            }           
            dtDatos.Rows.Add(rwFila);
            VaciarBoxes();
            pnObservaciones.Visible = false;
        }
        protected void Exportar_Reporte1(string nombre)
        {
            DataTable DtDatos = new DataTable();
            GenerarREP(DtDatos);
            if (DtDatos.Rows.Count > 0)
            {
                try
                {
                    ReportViewer reportviewer = new ReportViewer();
                    ReportDataSource datasource = new ReportDataSource();
                    datasource.Name = "DsDatos";
                    datasource.Value = DtDatos;
                    string _path = string.Empty;
                    _path = axVarSes.Lee<string>("Path");
                    reportviewer.LocalReport.DataSources.Clear();
                    reportviewer.LocalReport.ReportPath = _path + "Reports\\FormInscripcion.rdlc";// "\\Reports\\FormInscripcion.rdlc";
                    reportviewer.LocalReport.DataSources.Add(datasource);
                    Warning[] warnings;
                    string[] streamids;
                    string mimeType;
                    string encoding;
                    string extension;
                    byte[] bytes;
                    
                    bytes = reportviewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamids, out warnings);
                    MemoryStream ms = new MemoryStream(bytes);
                    Response.ContentType = "Application/pdf";
                    //Response.Charset = "UTF-8"; 
                    Response.AppendHeader("Content-Disposition", "attachment; filename="+ nombre + "-FormularioInscripcion.pdf");
                    Response.BinaryWrite(ms.ToArray());
                    Response.Flush();
                    //Response.Close();
                }
                catch(Exception ex)
                {
                    MostrarError("Se produjo un error al emitir el formulario. " + ex.ToString());
                }

            }
            else
            {
                MostrarError("No existen datos para desplegar el reporte.");
            }
        }
        private void MostrarError(string mensaje)
        {
            pnMensajeOK.Visible = false;
            pnMensajeError.Visible = true;
            lblMensajeError.Text = mensaje;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "goBottom();", true);
        }
        private bool ValidarPersonaEstudiante(BD_ADMIS_DatosPersonales DatosPer)
        {
            BD_Personas Personas = new BD_Personas();
            Personas.StrConexion = axVarSes.Lee<string>("strConexion");
            bool correcto = false;
            if (!(Personas.Revisar_Existe_Persona(DatosPer.DocIdentidad, DatosPer.PrimerApellido, DatosPer.SegundoApellido, DatosPer.Nombres, "")) || !string.IsNullOrEmpty(axVarSes.Lee<string>("strCrearNuevoAlumno")))
            {
                correcto = true;
            }
            else
            {
                gvEstudiantes.Visible = true;
                gvEstudiantes.Columns[0].Visible = true;
                gvEstudiantes.DataSource = Personas.dtObtenerCoincidencias(DatosPer.DocIdentidad, DatosPer.PrimerApellido, DatosPer.SegundoApellido, DatosPer.Nombres, "");
                gvEstudiantes.DataBind();
                gvEstudiantes.Columns[0].Visible = false;
                bool blIgual = false;
                for (int i = 0; i < gvEstudiantes.Rows.Count; i++)
                {
                    string carnet = gvEstudiantes.Rows[i].Cells[1].Text;
                    string primer_ap = gvEstudiantes.Rows[i].Cells[2].Text;
                    string segundo_ap = gvEstudiantes.Rows[i].Cells[3].Text;
                    string nombre = gvEstudiantes.Rows[i].Cells[4].Text;
                    if ((carnet.Equals(tbDocIdentidad.Text)) && (primer_ap.Equals(tbPrimerApellido.Text.ToUpper())) && (segundo_ap.Equals(tbSegundoApellido.Text.ToUpper())) && (nombre.Equals(tbNombres.Text.ToUpper())))
                    {
                        axVarSes.Escribe("strNSAlumno", gvEstudiantes.Rows[i].Cells[0].Text);
                        axVarSes.Escribe("strCrearNuevoAlumno", "no");
                        blIgual = true;
                        i = gvEstudiantes.Rows.Count;
                    }
                }
                if (blIgual)
                {
                    correcto = true;
                }
                else
                {
                    correcto = false;
                }
            }

            return correcto;
        }

        private bool ValidarPersonaFamiliar(BD_ADMIS_DatosTutor Tutor)
        {
            BD_Personas Personas = new BD_Personas();
            Personas.StrConexion = axVarSes.Lee<string>("strConexion");
            bool correcto = false;
            if (!Personas.Revisar_Existe_Persona(Tutor.DocIdentidad, Tutor.PrimerApellido, Tutor.SegundoApellido, Tutor.Nombres, "") || !string.IsNullOrEmpty(axVarSes.Lee<string>("strCrearNuevoFamiliar")))
            {
                correcto = true;
            }
            else
            {
                gvTutores.Visible = true;
                gvTutores.Columns[0].Visible = true;
                gvTutores.DataSource = Personas.dtObtenerCoincidencias(Tutor.DocIdentidad, Tutor.PrimerApellido, Tutor.SegundoApellido, Tutor.Nombres, "");
                gvTutores.DataBind();
                gvTutores.Columns[0].Visible = false;
                bool blIgual = false;
                for (int i = 0; i < gvTutores.Rows.Count; i++)
                {
                    string carnet = gvTutores.Rows[i].Cells[1].Text;
                    string primer_ap = gvTutores.Rows[i].Cells[2].Text;
                    string segundo_ap = gvTutores.Rows[i].Cells[3].Text;
                    string nombre = gvTutores.Rows[i].Cells[4].Text;
                    if ((carnet.Equals(tbDocIdentidadTutor.Text)) && (primer_ap.Equals(tbPrimerApTutor.Text.ToUpper())) && (segundo_ap.Equals(tbSegundoApTutor.Text.ToUpper())) && (nombre.Equals(tbNombreTutor.Text.ToUpper())))
                    {
                        axVarSes.Escribe("strNSFamiliar", gvTutores.Rows[i].Cells[0].Text);
                        axVarSes.Escribe("strCrearNuevoFamiliar", "no");
                        blIgual = true;
                        i = gvTutores.Rows.Count;
                    }
                }
                if (blIgual)
                {
                    correcto = true;
                }
                else
                {
                    correcto = false;
                }
            }

            return correcto;
        }
        #endregion

        #region "Eventos"
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { 
                if (!string.IsNullOrEmpty(axVarSes.Lee<string>("strConexion").Trim()))
                {
                    CargarDatosIniciales(axVarSes.Lee<string>("strConexion"));
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }            
        }
        protected void ddlPaisNac_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPaisNac.SelectedValue != string.Empty)
            {
                CargarDdlEstadosNac(ddlPaisNac.SelectedValue);
                CargarDdlLocalidadesNac(ddlEstadoNac.SelectedValue);
            }
            else
            {
                ddlEstadoNac.Items.Clear();
            }
        }

        protected void ddlEstadoNac_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEstadoNac.SelectedValue != string.Empty)
            {
                CargarDdlLocalidadesNac(ddlEstadoNac.SelectedValue);
            }
            else
            {
                ddlCiudadNac.Items.Clear();
            }
        }

        protected void ddlCiudadNac_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlPaisBach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPaisBach.SelectedValue != string.Empty)
            {
                CargarDdlEstadosBach(ddlPaisBach.SelectedValue);
                CargarDdlLocalidadesBach(ddlEstadoBach.SelectedValue);
            }
            else
            {
                ddlEstadoBach.Items.Clear();
            }
        }

        protected void ddlEstadoBach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEstadoBach.SelectedValue != string.Empty)
            {
                CargarDdlLocalidadesBach(ddlEstadoBach.SelectedValue);
            }
            else
            {
                ddlCiudadBach.Items.Clear();
            }
        }

        protected void ddlCiudadBach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCiudadBach.SelectedValue != string.Empty)
            {
                CargarDdlColegios();
            }
            else
            {
                ddlCiudadBach.Items.Clear();
            }
        }
        protected void ddlCarreras_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDdlPensums();
        }
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            pnMensajeError.Visible = false;
            pnMensajeOK.Visible = false;
            if (!axVarSes.Lee<string>("strConsolidado").Equals("1"))
            {
                if (((axVarSes.Lee<string>("strRol").Equals("1")) && (tbObservaciones.Text.Length < 500)) || (axVarSes.Lee<string>("strRol").Equals("0")))
                {
                    EliminarEspaciosExtras();
                    if (!tbTelefonoContacto1.Text.Equals(tbTelefonoContacto2.Text))
                    {
                        GEN_Cadenas Cadenas = new GEN_Cadenas();
                        if (Cadenas.Texto_Contiene_Caracteres_Especiales(tbCaptcha.Text, 1, 1))
                        {
                            axVarSes.Escribe("ContadorIngresos", axVarSes.Lee<int>("ContadorIngresos") + 1);
                            MostrarError("NO debe ingresar caracteres especiales en el patrón.");
                        }
                        else if ((axVarSes.Lee<string>("strOperacion").Equals("1")) && (string.IsNullOrEmpty(axVarSes.Lee<string>("strPersonaRegistrar"))))
                        {
                            MostrarError("NO existen valores para consolidar.");
                            VaciarBoxes();
                            axVarSes.Escribe("strOperacion", "0");
                        }
                        else
                        {

                            BD_ADMIS_DatosPersonales libDatosPer = new BD_ADMIS_DatosPersonales();
                            libDatosPer.StrConexion = axVarSes.Lee<string>("strConexion");
                            if (axVarSes.Lee<string>("strOperacion").Equals("0"))
                            {
                                libDatosPer.GenerarNS();
                            }
                            else
                            {
                                libDatosPer.NumSecDatosPer = Convert.ToInt64(axVarSes.Lee<string>("strPersonaRegistrar"));
                            }
                            libDatosPer.PrimerApellido = tbPrimerApellido.Text.ToUpper();
                            libDatosPer.SegundoApellido = tbSegundoApellido.Text.ToUpper();
                            libDatosPer.Nombres = tbNombres.Text.ToUpper();
                            libDatosPer.DocIdentidad = tbDocIdentidad.Text;
                            libDatosPer.TipoDocIdentidad = Convert.ToInt16(ddlTipoDocIdentidad.SelectedValue);
                            libDatosPer.Genero = Convert.ToInt16(ddlGenero.SelectedValue);
                            libDatosPer.GrupoSangre = Convert.ToInt16(ddlGrupoSangre.SelectedValue);
                            libDatosPer.EstadoCivil = Convert.ToInt16(ddlEstadoCivil.SelectedValue);
                            libDatosPer.TipoDiscapacidad = Convert.ToInt16(ddlDiscapacidad.SelectedValue);
                            libDatosPer.AvenidaCalle = tbCalleAvenida.Text;
                            libDatosPer.Numero = tbNumeroDom.Text;
                            libDatosPer.Zona = tbZona.Text;
                            libDatosPer.Edificio = tbNombreEdificio.Text;
                            libDatosPer.Piso = tbPiso.Text;
                            libDatosPer.Depto = tbNumeroDepto.Text;
                            libDatosPer.AreaNacimiento = Convert.ToInt16(ddlAreaNacimiento.SelectedValue);
                            libDatosPer.NumSecLocalidadDomicilio = Convert.ToInt64(ddlLocalidadZona.SelectedValue);
                            libDatosPer.NumSecUbicacionInscripcion = Convert.ToInt64(ddlLugarInscripcion.SelectedValue);
                            Match me = Regex.Match(tbTelefonoDomicilio.Text, "(\\d+)");
                            if (me.Success)
                            {
                                libDatosPer.Telefono = Convert.ToInt32(me.Value);
                            }
                            if (!string.IsNullOrEmpty(tbCelular.Text))
                            {
                                libDatosPer.Celular = tbCelular.Text;
                            }

                            libDatosPer.Email = tbEmail.Text;
                            libDatosPer.ViveCon = Convert.ToInt16(ddlViveCon.SelectedValue);
                            libDatosPer.FechaNacimiento = Convert.ToDateTime(tbFechaNac.Text.Trim()).ToString("dd/MM/yyyy");
                            libDatosPer.NumSecNacionalidad = Convert.ToInt64(ddlNacionalidad.SelectedValue);
                            libDatosPer.Observaciones = tbObservaciones.Text;

                            libDatosPer.NumSecLocalidadNac = Convert.ToInt64(ddlCiudadNac.SelectedValue);
                            libDatosPer.NumSecLocalidadBachillerato = Convert.ToInt64(ddlCiudadBach.SelectedValue);
                            libDatosPer.NumSecColegio = Convert.ToInt64(ddlColegio.SelectedValue);
                            libDatosPer.AnioBachillerato = Convert.ToInt32(ddlAnio.SelectedValue);
                            libDatosPer.TipoColegio = Convert.ToInt16(ddlTipoColegio.SelectedValue);
                            libDatosPer.AreaColegio = Convert.ToInt16(ddlAreaColegio.SelectedValue);
                            libDatosPer.Turno = Convert.ToInt16(ddlTurno.SelectedValue);

                            libDatosPer.NumSecSubdepartamento = Convert.ToInt64(ddlCarreras.SelectedValue);
                            libDatosPer.NumSecSemestre = 0;
                            libDatosPer.NumSecPersona = 0;
                            libDatosPer.UsuarioRegistro = axVarSes.Lee<string>("UsuarioLogin");

                            BD_ADMIS_DatosTutor libtutor = new BD_ADMIS_DatosTutor();
                            libtutor.StrConexion = axVarSes.Lee<string>("strConexion");
                            libtutor.TipoTutor = Convert.ToInt16(ddlParentesco.SelectedValue);
                            libtutor.NumSecDatosPer = libDatosPer.NumSecDatosPer;
                            libtutor.PrimerApellido = tbPrimerApTutor.Text;
                            libtutor.SegundoApellido = tbSegundoApTutor.Text;
                            libtutor.Nombres = tbNombreTutor.Text;
                            libtutor.DocIdentidad = tbDocIdentidadTutor.Text;
                            libtutor.TipoDocIdentidad = Convert.ToInt16(ddlTipoDocIdentidadTutor.SelectedValue);
                            libtutor.Genero = Convert.ToInt16(ddlGeneroTutor.SelectedValue);
                            libtutor.AvenidaCalle = tbCalleAvenidaTutor.Text;
                            libtutor.Numero = tbNumeroDomTutor.Text;
                            libtutor.Zona = tbZonaTutor.Text;
                            libtutor.Edificio = tbEdificioTutor.Text;
                            libtutor.Depto = tbDeptoTutor.Text;
                            me = Regex.Match(tbTelefonoTutor.Text, "(\\d+)");
                            if (me.Success)
                            {
                                libtutor.Telefono = Convert.ToInt32(me.Value);
                            }
                            if (!string.IsNullOrEmpty(tbCelularTutor.Text))
                            {
                                libtutor.Celular = tbCelularTutor.Text;
                            }
                            libtutor.Email = tbEmailTutor.Text;
                            libtutor.InstitucionTrabajo = tbInstitucionLaboralTutor.Text;
                            libtutor.Cargo = tbCargoTutor.Text;
                            libtutor.TelefonoTrabajo = tbTelefonoOficina.Text;
                            if (rbSi.Checked)
                            {
                                libtutor.AutSeguimiento = 1;
                            }
                            if (rbNo.Checked)
                            {
                                libtutor.AutSeguimiento = 0;
                            }
                            libtutor.NumSecPersona = 0;
                            libtutor.UsuarioRegistro = axVarSes.Lee<string>("UsuarioLogin");

                            BD_ADMIS_ContactoEmergencia libContacto = new BD_ADMIS_ContactoEmergencia();
                            libContacto.StrConexion = axVarSes.Lee<string>("strConexion");
                            libContacto.NumSecDatosPer = libDatosPer.NumSecDatosPer;
                            libContacto.NombreCompleto = tbNombreCompleto.Text;
                            if (!string.IsNullOrEmpty(tbTelefonoContacto1.Text))
                            {
                                libContacto.TelefonoContacto1 = tbTelefonoContacto1.Text;
                            }
                            if (!string.IsNullOrEmpty(tbTelefonoContacto2.Text))
                            {
                                libContacto.TelefonoContacto2 = tbTelefonoContacto2.Text;
                            }

                            libContacto.UsuarioRegistro = axVarSes.Lee<string>("UsuarioLogin");
                            string[] sqls = new string[10];
                            int numsqls = 0;
                            if (axVarSes.Lee<string>("strRol").Equals("1"))
                            {
                                if (axVarSes.Lee<string>("strOperacion").Equals("0"))
                                {
                                    libDatosPer.Estado = 1;//Registrado
                                    sqls[0] = libDatosPer.CadsqlInsert();
                                    numsqls++;
                                    sqls[1] = libtutor.cadSqlInsertar();
                                    numsqls++;
                                    sqls[2] = libContacto.cadSqlInsertar();
                                    numsqls++;
                                }
                                else
                                {
                                    if (axVarSes.Lee<string>("strOperacion").Equals("1"))
                                    {
                                        libDatosPer.Estado = 1;//Registrado
                                        libDatosPer.NumSecSemestre = Convert.ToInt64(ddlSemestre.SelectedValue);
                                        sqls[0] = libDatosPer.CadsqlActualizar();
                                        numsqls++;
                                        sqls[1] = libtutor.cadSqlActualizar();
                                        numsqls++;
                                        sqls[2] = libContacto.cadSqlActualizar();
                                        numsqls++;
                                    }
                                }
                                if (libDatosPer.InsertarVarios(sqls, numsqls))
                                {
                                    consolidar(libDatosPer, libContacto, libtutor);
                                }
                                else
                                {
                                    MostrarError("No se pudo almacenar el formulario. " + libDatosPer.Mensaje);
                                }
                            }
                            else
                            {
                                try
                                {
                                    if (tbCaptcha.Text.ToString().ToUpper() == axVarSes.Lee<string>("captchastr").ToString().ToUpper())
                                    {
                                        if (axVarSes.Lee<string>("strOperacion").Equals("0"))
                                        {
                                            libDatosPer.Estado = 1;//enviado
                                            sqls[0] = libDatosPer.CadsqlInsert();
                                            numsqls++;
                                            sqls[1] = libtutor.cadSqlInsertar();
                                            numsqls++;
                                            sqls[2] = libContacto.cadSqlInsertar();
                                            numsqls++;
                                            if (libDatosPer.InsertarVarios(sqls, numsqls))
                                            {
                                                axVarSes.Escribe("strMensajeExito", "Registro exitoso.");
                                                Response.Redirect("ADMIS_FormRegistro.aspx");
                                            }
                                            else
                                            {
                                                MostrarError("No se pudo almacenar el formulario. " + libDatosPer.Mensaje);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MostrarError("El patrón de la imagen no coincide con el texto ingresado.");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MostrarError("Se produjo un error, por favor recargue la página y vuelva a intentarlo. "+ex.Message);
                                }
                            }

                        }
                    }
                    else
                    {
                        MostrarError("Debe proporcionar dos teléfonos de contacto distintos.");
                    }
                }
                else
                {
                    MostrarError("El cuadro de observaciones debe contener máximo 500 caracteres.");
                }
            }
            else
            {
                MostrarError("Los datos ya fueron consolidados.");
            }
        }
        #endregion

        protected void rbContactoEmerTutorSi_CheckedChanged(object sender, EventArgs e)
        {
            tbNombreCompleto.Text= tbNombreTutor.Text.Trim() + " " + tbPrimerApTutor.Text.Trim() + " " + tbSegundoApTutor.Text.Trim();
            tbTelefonoContacto2.Text = tbTelefonoTutor.Text;
            tbTelefonoContacto1.Text = tbCelularTutor.Text;
        }

        protected void rbContactoEmerTutorNo_CheckedChanged(object sender, EventArgs e)
        {
            tbNombreCompleto.Text = string.Empty;
            tbTelefonoContacto1.Text = string.Empty;
            tbTelefonoContacto2.Text = string.Empty;
        }

        public void consolidar(BD_ADMIS_DatosPersonales DatosPer, BD_ADMIS_ContactoEmergencia Contacto, BD_ADMIS_DatosTutor Tutor)
        {
            bool blError = false;
            bool AlumnoExiste = false;
            bool FamiliarExiste = false;
            string[] CadSqls = new string[15];
            int numSqls = 0;
            BD_Personas Personas = new BD_Personas();
            BD_Personas Familiar = new BD_Personas();
            BD_Personas_Datos_Adicionales DatosAdicionales = new BD_Personas_Datos_Adicionales();
            BD_Personas_Datos_Adicionales DatosAdicionalesFamiliares = new BD_Personas_Datos_Adicionales();
            BD_Carreras_Estudiantes Estudiantes = new BD_Carreras_Estudiantes();
            BD_GEN_SubDepartamentos Subdepartamentos = new BD_GEN_SubDepartamentos();
            BD_Bachilleres Bachilleres = new BD_Bachilleres();
            Bachilleres.StrConexion = axVarSes.Lee<string>("strConexion");
            Subdepartamentos.StrConexion = axVarSes.Lee<string>("strConexion");
            Estudiantes.StrConexion = axVarSes.Lee<string>("strConexion");
            Familiar.StrConexion = axVarSes.Lee<string>("strConexion");
            Personas.StrConexion = axVarSes.Lee<string>("strConexion");
            DatosAdicionales.StrConexion = axVarSes.Lee<string>("strConexion");
            DatosAdicionalesFamiliares.StrConexion = axVarSes.Lee<string>("strConexion");

            Personas.CedulaIdentidad = DatosPer.DocIdentidad;
            Match m = Regex.Match(DatosPer.DocIdentidad, "(\\d+)");
            if (m.Success)
            {
                Personas.DocIdentidad = Convert.ToInt64(m.Value);
            }
            Personas.TipoDoc = DatosPer.TipoDocIdentidad;
            Personas.ApPaterno = DatosPer.PrimerApellido.ToUpper();
            Personas.ApMaterno = DatosPer.SegundoApellido.ToUpper();
            Personas.Nombres = DatosPer.Nombres.ToUpper();
            Personas.Sexo = DatosPer.Genero;
            Personas.EstadoCivil = DatosPer.EstadoCivil;
            Personas.TipoSangre = DatosPer.GrupoSangre;
            Personas.NumSecLocalidadNac = DatosPer.NumSecLocalidadNac;
            Personas.FechaNacimiento = DatosPer.FechaNacimiento;
            Personas.NumSecNacionalidad = DatosPer.NumSecNacionalidad;
            Personas.Tipo = 2; //define estudiante segun dominios

            
            


            Familiar.CedulaIdentidad = Tutor.DocIdentidad;
            Match me = Regex.Match(Tutor.DocIdentidad, "(\\d+)");
            if (me.Success)
            {
                Familiar.DocIdentidad = Convert.ToInt64(me.Value);
            }
            Familiar.TipoDoc = Tutor.TipoDocIdentidad;
            Familiar.ApPaterno = Tutor.PrimerApellido.ToUpper();
            Familiar.ApMaterno = Tutor.SegundoApellido.ToUpper();
            Familiar.Nombres = Tutor.Nombres.ToUpper();
            Familiar.Sexo = Tutor.Genero;
            Familiar.Tipo = 32; //define familiar segun dominio
        

            if (rbSi.Checked)
            {
                DatosAdicionales.PermitirAccesoPadres = 1;
            }
            //if (!(Personas.Revisar_Existe_Persona(DatosPer.DocIdentidad, DatosPer.PrimerApellido, DatosPer.SegundoApellido, DatosPer.Nombres, "")) || !string.IsNullOrEmpty(axVarSes.Lee<string>("strCrearNuevoAlumno")))
            if(ValidarPersonaEstudiante(DatosPer))
            {
                //if (!Familiar.Revisar_Existe_Persona(Tutor.DocIdentidad, Tutor.PrimerApellido, Tutor.SegundoApellido, Tutor.Nombres, "") || !string.IsNullOrEmpty(axVarSes.Lee<string>("strCrearNuevoFamiliar")))
                if(ValidarPersonaFamiliar(Tutor))
                {
                    if (!Personas.Revisar_Existe_Persona(DatosPer.DocIdentidad, DatosPer.PrimerApellido, DatosPer.SegundoApellido, DatosPer.Nombres, "") || axVarSes.Lee<string>("strCrearNuevoAlumno").Equals("si"))
                    {
                        if (!Personas.GenerarNS())
                        {
                            blError = true;
                        }
                        CadSqls[numSqls] = Personas.sqlCadInsertar();
                        numSqls++;
                        DatosPer.NumSecPersona = Personas.NumSec;
                        CadSqls[numSqls] = DatosPer.CadsqlActualizar();
                        numSqls++;
                        DatosAdicionales.NumSecPersona = Personas.NumSec;
                        DatosAdicionales.Email = DatosPer.Email;
                        DatosAdicionales.NumSecSemestreIngreso = DatosPer.NumSecSemestre;
                        DatosAdicionales.Telefono = DatosPer.Telefono;
                        DatosAdicionales.Celular = DatosPer.Celular;
                        DatosAdicionales.AvenidaCalle = DatosPer.AvenidaCalle;
                        DatosAdicionales.Numero = DatosPer.Numero;
                        DatosAdicionales.Zona = DatosPer.Zona;
                        DatosAdicionales.Barrio = DatosPer.Zona;
                        DatosAdicionales.Edificio = DatosPer.Edificio;
                        DatosAdicionales.Depto = DatosPer.Depto;
                        DatosAdicionales.Piso = DatosPer.Piso;
                        DatosAdicionales.TipoLugarNacimiento = DatosPer.AreaNacimiento;
                        DatosAdicionales.NumSecUbicacion = DatosPer.NumSecUbicacionInscripcion;
                        DatosAdicionales.NumSecLocalidadDomicilio = DatosPer.NumSecLocalidadDomicilio;
                        CadSqls[numSqls] = DatosAdicionales.cadSqlInsertar();
                        numSqls++;
                        Bachilleres.NumSecPersona = Personas.NumSec;
                        Bachilleres.Tipo = Convert.ToInt16(ddlTipoColegio.SelectedValue);
                        Bachilleres.NumSecColegio = Convert.ToInt64(ddlColegio.SelectedValue);
                        Bachilleres.TipoLugarBachiller = Convert.ToInt16(ddlAreaColegio.SelectedValue);
                        Bachilleres.TurnoColegio = Convert.ToInt16(ddlTurno.SelectedValue);
                        Bachilleres.AnioEgreso = Convert.ToInt16(ddlAnio.SelectedValue);
                        CadSqls[numSqls] = Bachilleres.sqlCadInsertar();//*****
                        numSqls++;//***
                    }
                    else if (axVarSes.Lee<string>("strCrearNuevoAlumno").Equals("no"))
                    {
                        DatosPer.NumSecPersona = Convert.ToInt64(axVarSes.Lee<string>("strNSAlumno"));
                        BD_Personas PersonaAux = new BD_Personas();
                        PersonaAux.StrConexion = axVarSes.Lee<string>("strConexion");
                        PersonaAux.NumSec = DatosPer.NumSecPersona;
                        Personas.NumSec = DatosPer.NumSecPersona;
                        PersonaAux.Ver();
                        GEN_AutenticacionBD aut = new GEN_AutenticacionBD();
                        if (!aut.CumpleTipoPermitido(PersonaAux.Tipo, 1))
                        {
                            Personas.Tipo = Convert.ToInt16(PersonaAux.Tipo + 2);
                        }
                        else
                        {
                            Personas.Tipo = PersonaAux.Tipo;
                        }
                        CadSqls[numSqls] = DatosPer.CadsqlActualizar();
                        numSqls++;
                        DatosAdicionales.NumSecPersona = Personas.NumSec;
                        DatosAdicionales.Ver();
                        DatosAdicionales.Email = DatosPer.Email;
                        DatosAdicionales.NumSecSemestreIngreso = DatosPer.NumSecSemestre;
                        DatosAdicionales.Telefono = DatosPer.Telefono;
                        DatosAdicionales.Celular = DatosPer.Celular;
                        DatosAdicionales.AvenidaCalle = DatosPer.AvenidaCalle;
                        DatosAdicionales.Numero = DatosPer.Numero;
                        DatosAdicionales.Zona = DatosPer.Zona;
                        DatosAdicionales.Barrio = DatosPer.Zona;
                        DatosAdicionales.Edificio = DatosPer.Edificio;
                        DatosAdicionales.Depto = DatosPer.Depto;
                        DatosAdicionales.Piso = DatosPer.Piso;
                        DatosAdicionales.TipoLugarNacimiento = DatosPer.AreaNacimiento;
                        DatosAdicionales.NumSecUbicacion = DatosPer.NumSecUbicacionInscripcion;
                        DatosAdicionales.NumSecLocalidadDomicilio = DatosPer.NumSecLocalidadDomicilio;
                        CadSqls[numSqls] = DatosAdicionales.sqlCadActualizar();
                        numSqls++;
                        CadSqls[numSqls] = Personas.sqlCadActualizarTipoPersona();
                        numSqls++;
                        long aux = Personas.NumSec; //se usa en caso de que no exista registro en bachilleres porque la busqueda vacia los datos
                        Bachilleres.NumSecPersona = Personas.NumSec;
                        if (!Bachilleres.Ver())
                        {
                            Bachilleres.NumSecPersona = aux;
                            Bachilleres.Tipo = Convert.ToInt16(ddlTipoColegio.SelectedValue);
                            Bachilleres.NumSecColegio = Convert.ToInt64(ddlColegio.SelectedValue);
                            Bachilleres.TipoLugarBachiller = Convert.ToInt16(ddlAreaColegio.SelectedValue);
                            Bachilleres.TurnoColegio = Convert.ToInt16(ddlTurno.SelectedValue);
                            Bachilleres.AnioEgreso = Convert.ToInt16(ddlAnio.SelectedValue);
                            CadSqls[numSqls] = Bachilleres.sqlCadInsertar();
                            numSqls++;
                        }
                    }
                    else
                    {
                        blError = true;
                        MostrarError("Error en validacion de Registro de estudiante");
                    }
                    if (!Familiar.Revisar_Existe_Persona(Tutor.DocIdentidad, Tutor.PrimerApellido, Tutor.SegundoApellido, Tutor.Nombres, "") || axVarSes.Lee<string>("strCrearNuevoFamiliar").Equals("si"))
                    {

                        if (!Familiar.GenerarNS())
                        {
                            blError = true;
                        }
                        CadSqls[numSqls] = Familiar.sqlCadInsertar();
                        numSqls++;
                        Tutor.NumSecPersona = Familiar.NumSec;
                        CadSqls[numSqls] = Tutor.cadSqlActualizar();
                        numSqls++;
                        DatosAdicionalesFamiliares.NumSecPersona = Familiar.NumSec;
                        DatosAdicionalesFamiliares.Email = Tutor.Email;
                        DatosAdicionalesFamiliares.Telefono = Tutor.Telefono;
                        DatosAdicionalesFamiliares.Celular = Tutor.Celular;
                        DatosAdicionalesFamiliares.AvenidaCalle = Tutor.AvenidaCalle;
                        DatosAdicionalesFamiliares.Numero = Tutor.Numero;
                        DatosAdicionalesFamiliares.Zona = Tutor.Zona;
                        DatosAdicionalesFamiliares.Barrio = Tutor.Zona;
                        CadSqls[numSqls] = DatosAdicionalesFamiliares.cadSqlInsertar();
                        numSqls++;
                    }
                    else if (axVarSes.Lee<string>("strCrearNuevoFamiliar").Equals("no"))
                    {
                        Tutor.NumSecPersona = Convert.ToInt64(axVarSes.Lee<string>("strNSFamiliar"));
                        Familiar.NumSec = Tutor.NumSecPersona;
                        BD_Personas PersonaAux = new BD_Personas();
                        PersonaAux.StrConexion = axVarSes.Lee<string>("strConexion");
                        PersonaAux.NumSec = Familiar.NumSec;
                        PersonaAux.Ver();
                        GEN_AutenticacionBD aut = new GEN_AutenticacionBD();
                        if (!aut.CumpleTipoPermitido(PersonaAux.Tipo, 5))
                        {
                            Familiar.Tipo = Convert.ToInt16(PersonaAux.Tipo + 32);
                        }
                        else
                        {
                            Familiar.Tipo = PersonaAux.Tipo;
                        }
                        CadSqls[numSqls] = Tutor.cadSqlActualizar();
                        numSqls++;
                        DatosAdicionalesFamiliares.NumSecPersona = Familiar.NumSec;
                        DatosAdicionalesFamiliares.Ver();
                        DatosAdicionalesFamiliares.Email = Tutor.Email;
                        DatosAdicionalesFamiliares.Telefono = Tutor.Telefono;
                        DatosAdicionalesFamiliares.Celular = Tutor.Celular;
                        DatosAdicionalesFamiliares.AvenidaCalle = Tutor.AvenidaCalle;
                        DatosAdicionalesFamiliares.Numero = Tutor.Numero;
                        DatosAdicionalesFamiliares.Zona = Tutor.Zona;
                        DatosAdicionalesFamiliares.Barrio = Tutor.Zona;
                        CadSqls[numSqls] = DatosAdicionalesFamiliares.sqlCadActualizar();
                        numSqls++;
                        CadSqls[numSqls] = Familiar.sqlCadActualizarTipoPersona();
                        numSqls++;
                    }
                    else
                    {
                        MostrarError("Error en validacion de Registro de familiar");
                    }
                    BD_Familiares Relacion = new BD_Familiares();
                    Relacion.StrConexion = axVarSes.Lee<string>("strConexion");
                    Relacion.NumSecFamiliar = Familiar.NumSec;
                    Relacion.NumSecPersona = Personas.NumSec;
                    if (!Relacion.RevisarSiExisteFamiliar())
                    {
                        Relacion.NumSecPersona = Personas.NumSec;
                        Relacion.NumSecFamiliar = Familiar.NumSec;
                        Relacion.Tipo = Convert.ToInt16(ddlParentesco.SelectedValue);
                        CadSqls[numSqls] = Relacion.cadsqInsertar();
                        numSqls++;
                    }
                    Subdepartamentos.NumSecSubDepartamento = Convert.ToInt64(ddlCarreras.SelectedValue);
                    Estudiantes.NumSecCarrera = Convert.ToInt64(Subdepartamentos.strCarrerasSubdepto());
                    Estudiantes.NumSecPensumIngreso = Convert.ToInt64(ddlPensumIngreso.SelectedValue);
                    Estudiantes.NumSecPersona = Personas.NumSec;
                    Estudiantes.NumSecSemestre = Convert.ToInt64(ddlSemestre.SelectedValue);
                    Estudiantes.NumSecSubdepto = Convert.ToInt64(ddlCarreras.SelectedValue);
                    Estudiantes.UsuarioRegistro = axVarSes.Lee<string>("UsuarioLogin");
                    Estudiantes.Adicionar = 1;
                    Estudiantes.Retirar = 0;
                    Estudiantes.Estado = 1;
                    
                    if (!Estudiantes.RevisarSiExiste())
                    {
                        Estudiantes.TipoAdmision = Convert.ToInt16(ddlTipoAdmision.SelectedValue);
                        CadSqls[numSqls] = Estudiantes.cadSqlInsertar();
                        numSqls++;
                        CadSqls[numSqls] = Estudiantes.strSqlInsertarCarrerasSubdepto();
                        numSqls++;
                    }
                    DatosPer.Estado = 0;//consolidado
                    DatosPer.NumSecSemestre = Convert.ToInt64(ddlSemestre.SelectedValue);
                    CadSqls[numSqls] = DatosPer.CadsqlActualizar();
                    numSqls++;
                    
                    if (!blError && !AlumnoExiste && !FamiliarExiste)
                    {
                        btnEnviar.Visible = false;
                        
                        if (DatosPer.InsertarVarios(CadSqls, numSqls))
                        {
                            pnMensajeOK.Visible = true;
                            lblMensajeOK.Text = "Se almacenaron correctamente los datos.";
                            pnMensajeOK.Focus();
                            pnObservaciones.Visible = false;
                            axVarSes.Escribe("strConsolidado", "1");
                            Exportar_Reporte1(DatosPer.PrimerApellido+" "+DatosPer.SegundoApellido+" "+DatosPer.Nombres);
                            VaciarBoxes();
                            axVarSes.Escribe("strMensajeExito", "Registro exitoso.");
                            //axVarSes.Escribe("strOperacion", "0");
                            axVarSes.Escribe("strPersonaRegistrar", string.Empty);
                            axVarSes.Escribe("strCrearNuevoFamiliar", string.Empty);
                            axVarSes.Escribe("strCrearNuevoAlumno", string.Empty);
                            axVarSes.Escribe("strNSAlumno", string.Empty);
                            axVarSes.Escribe("strNSFamiliar", string.Empty);
                            Response.Redirect("ADMIS_FormRegistro.aspx");
                        }
                        else
                        {
                            if (DatosPer.MarcarComoNoConsolidado())
                            {
                                MostrarError("Se almacenó el formulario pero no se pudo crear a la persona. Los datos no fueron consolidados. " + DatosPer.Mensaje);
                            }
                            else
                            {
                                MostrarError("Se almacenó el formulario pero no se pudo crear a la persona. Los datos no fueron consolidados. " + DatosPer.Mensaje);
                            }
                        }
                        
                        
                    }
                }
                else
                {
                    upFamiliarExiste.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modalFamiliarExistente').modal('show');", true);
                    pnMensajeError.Visible = false;
                    pnMensajeOK.Visible = false;
                    pnFamiliaresSugeridos.Visible = true;
                    gvTutores.Visible = true;
                    gvTutores.Columns[0].Visible = true;
                    gvTutores.DataSource = Familiar.dtObtenerCoincidencias(Tutor.DocIdentidad, Tutor.PrimerApellido, Tutor.SegundoApellido, Tutor.Nombres, "");
                    gvTutores.DataBind();
                    gvTutores.Columns[0].Visible = false;
                }
            }
            else
            {
                pnMensajeError.Visible = false;
                pnMensajeOK.Visible = false;
                pnsugeridos.Visible = true;
                gvEstudiantes.Visible = true;
                gvEstudiantes.Columns[0].Visible = true;
                gvEstudiantes.DataSource = Personas.dtObtenerCoincidencias(DatosPer.DocIdentidad, DatosPer.PrimerApellido, DatosPer.SegundoApellido, DatosPer.Nombres, "");
                gvEstudiantes.DataBind();
                gvEstudiantes.Columns[0].Visible = false;
                upAlumnoExiste.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modalAlumnoExistente').modal('show');", true);               
            }
        }
        public void VaciarBoxes()
        {
            CargarDdlPaisBach();
            ddlPaisBach.SelectedValue = "1";// por defecto carga bolivia
            CargarDdlEstadosBach(ddlPaisBach.SelectedValue);
            ddlEstadoBach.SelectedValue = "1";// por defecto carga la paz
            CargarDdlLocalidadesBach(ddlEstadoBach.SelectedValue);
            ddlCiudadBach.SelectedValue = "1";// por defecto carga la paz
            CargarDdlPaisNac();
            ddlPaisNac.SelectedValue = "1"; //por defecto carga bolivia
            CargarDdlEstadosNac(ddlPaisNac.SelectedValue);
            ddlEstadoNac.SelectedValue = "1"; // por defecto carga la paz
            CargarDdlLocalidadesNac(ddlEstadoNac.SelectedValue);
            ddlCiudadNac.SelectedValue = "1"; // por defecto carga la paz
            CargarDdlNacionalidad();
            ddlNacionalidad.SelectedValue = "1";// por defecto carga boliviana
            CargarDdlColegios();
            CargarDdlViveCon();
            CargarDdlParentesco();
            CargarDdlGenero();
            CargarDdlGeneroTutor();
            CargarDdlSangre();
            CargarDdlTipoColegio();
            CargarDdlTurnoColegio();
            CargarDdlAreaColegio();
            CargarDdlParentesco();
            CargarDdlEstadoCivil();
            CargarDdlSubdeptoAcad();
            CargarDdlDiscapacidad();
            CargarDdlTipoDocTutor();
            CargarDdlTipoDoc();
            CargarDdlAnios();
            tbCalleAvenida.Text = string.Empty;
            tbCalleAvenidaTutor.Text = string.Empty;
            tbCaptcha.Text = string.Empty;
            tbCargoTutor.Text = string.Empty;
            tbCelular.Text = string.Empty;
            tbCelularTutor.Text = string.Empty;
            tbDeptoTutor.Text = string.Empty;
            tbDocIdentidad.Text = string.Empty;
            tbDocIdentidadTutor.Text = string.Empty;
            tbEdificioTutor.Text = string.Empty;
            tbEmail.Text = string.Empty;
            tbEmailTutor.Text = string.Empty;
            tbFechaNac.Text = string.Empty;
            tbInstitucionLaboralTutor.Text = string.Empty;
            tbNombreCompleto.Text = string.Empty;
            tbNombreEdificio.Text = string.Empty;
            tbNombres.Text = string.Empty;
            tbNombreTutor.Text = string.Empty;
            tbNumeroDepto.Text = string.Empty;
            tbNumeroDom.Text = string.Empty;
            tbNumeroDomTutor.Text = string.Empty;
            tbObservaciones.Text = string.Empty;
            tbPiso.Text = string.Empty;
            tbPrimerApellido.Text = string.Empty;
            tbPrimerApTutor.Text = string.Empty;
            tbSegundoApellido.Text = string.Empty;
            tbSegundoApTutor.Text = string.Empty;
            tbTelefonoContacto1.Text = string.Empty;
            tbTelefonoContacto2.Text = string.Empty;
            tbTelefonoDomicilio.Text = string.Empty;
            tbTelefonoOficina.Text = string.Empty;
            tbTelefonoTutor.Text = string.Empty;
            tbZona.Text = string.Empty;
            tbZonaTutor.Text = string.Empty;

        }
        // Botones de los Modals
        protected void cerrarModals()
        {
            upAlumnoExiste.Visible = false;    //Modal Alumno existente
            // upFamiliarExistente.Visible = false;       //Modal Familiar Existente
        }
        protected void btnGuardarModalAlumno_Click(object sender, EventArgs e)
        {
            
            axVarSes.Escribe("strCrearNuevoAlumno", "si");
            upAlumnoExiste.Visible = false;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "$('#modalAlumnoExistente').hide();$('.modal-backdrop').hide();", true);
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "Script", "btnEnviarClick();", true);
            
        }

        protected void btnCancelarModalAlumno_Click(object sender, EventArgs e)
        {
            try
            {
                upAlumnoExiste.Visible = false;
                axVarSes.Escribe("strCrearNuevoAlumno", "");
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "$('#modalAlumnoExistente').hide();$('.modal-backdrop').hide();document.getElementById('modalAlumnoExistente').classList.remove('modal-open');", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "$('#modalAlumnoExistente').hide();$('.modal-backdrop').hide();", true);
            }
            catch (Exception ex)
            {
                MostrarError("Error al cerrar la ventana" + ex.Message);
            }
        }

        protected void btnGuardarModalFamiliar_Click(object sender, EventArgs e)
        {
            axVarSes.Escribe("strCrearNuevoFamiliar", "si");
            upFamiliarExiste.Visible = false;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "$('#modalFamiliarExistente').hide();$('.modal-backdrop').hide();", true);
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "Script", "btnEnviarClick();", true);
            
        }

        protected void btnCancelarModalFamiliar_Click(object sender, EventArgs e)
        {
            try
            {
                axVarSes.Escribe("strCrearNuevoFamiliar", "");
                upFamiliarExiste.Visible = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "$('#modalFamiliarExistente').hide();$('.modal-backdrop').hide();", true);
            }
            catch (Exception ex)
            {
                MostrarError("Error al cerrar la ventana" + ex.Message);
            }
}

        protected void gvEstudiantes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int indice = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "elegir")
            {
                axVarSes.Escribe("strNSAlumno", gvEstudiantes.Rows[indice].Cells[0].Text);
                axVarSes.Escribe("strCrearNuevoAlumno", "no");
                upAlumnoExiste.Visible = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "$('#modalAlumnoExistente').hide();$('.modal-backdrop').hide();", true);
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Script", "btnEnviarClick();", true);
            }
        }

        protected void gvTutores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int indice = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "elegir")
            {
                axVarSes.Escribe("strNSFamiliar", gvTutores.Rows[indice].Cells[0].Text);
                axVarSes.Escribe("strCrearNuevoFamiliar", "no");
                upFamiliarExiste.Visible = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "$('#modalFamiliarExistente').hide();$('.modal-backdrop').hide();", true);
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "Script", "btnEnviarClick();", true);
            }
        }

        protected void rbCopiarDatosDomicilioSi_CheckedChanged(object sender, EventArgs e)
        {
            tbCalleAvenidaTutor.Text = tbCalleAvenida.Text;
            tbDeptoTutor.Text = tbNumeroDepto.Text;
            tbEdificioTutor.Text = tbNombreEdificio.Text;
            tbNumeroDomTutor.Text = tbNumeroDom.Text;
            tbTelefonoTutor.Text = tbTelefonoDomicilio.Text;
            tbZonaTutor.Text = tbZona.Text;
        }

        protected void rbCopiarDatosDomicilioNo_CheckedChanged(object sender, EventArgs e)
        {
            tbCalleAvenidaTutor.Text = "";
            tbDeptoTutor.Text = "";
            tbEdificioTutor.Text = "";
            tbNumeroDomTutor.Text = "";
            tbTelefonoTutor.Text = "";
            tbZonaTutor.Text = "";
        }
    }
}