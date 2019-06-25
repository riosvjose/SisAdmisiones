<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Principal.Master" AutoEventWireup="true" CodeBehind="ADMIS_FormRegistro.aspx.cs" Inherits="SisAdmisiones.Forms.ADMIS_FormRegistro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
         <Triggers>
            <asp:PostBackTrigger ControlID="btnEnviar" />
        </Triggers>
        <ContentTemplate>

            <div class="row">
	            <div class="col-xs-12 col-md-6 pull-left">
		            <h1>Registro de estudiantes</h1>
	            </div>
                
            </div>
            <div class="row">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <div class="row">
                            <div class="col-xs-12">
                                <div class="fa-lg text-danger">
                                    <i class="fa fa-spinner fa-spin"></i> Procesando, un momento por favor ...
                                    <br /><br />
                                </div>
                            </div>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
            <br />
            <asp:Panel ID="pnDatosInscripcion" runat="server">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">
                        <h3> <strong><asp:Label ID="Label5" runat="server" Text="Datos de inscripcion"></asp:Label></strong></h3>
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                        <br/>
                        <div class="row mb-3">
                            <asp:Panel ID="pnTipoAdmision" runat="server" Visible="False">
                                <div class="col-xs-12 col-sm-4 col-md-3 col-lg-2">
                                        <div class="form-group">
                                            <div class="form-inline">
                                                <strong><asp:Label ID="lblTipoAdmision" runat="server" >Tipo admision:</asp:Label></strong>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                                        <div class="form-group">
                                            <div class="form-inline">
                                                <asp:DropDownList ID="ddlTipoAdmision" runat="server" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
                                            </div>
                                        </div>
                                      
                                    </div>
                                    
                            </asp:Panel>
                        </div>
                        <div class="row mb-3">
                            <asp:Panel ID="pnSemestres" runat="server" Visible="false">
                                <div class="col-xs-12 col-sm-4 col-md-3 col-lg-2">
                                        <div class="form-group">
                                            <div class="form-inline">
                                                <strong><asp:Label ID="lblSemestre" runat="server" >Semestre:</asp:Label></strong>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                                        <div class="form-group">
                                            <div class="form-inline">
                                                <asp:DropDownList ID="ddlSemestre" runat="server" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
                                            </div>
                                        </div>
                                      
                                    </div>
                                    
                            </asp:Panel>
                        </div>
                        <div class="row mb-3">
                            <asp:Panel ID="pnCarreras" runat="server" Visible="true">
                                <div class="col-xs-12 col-sm-4 col-md-3 col-lg-2">
                                        <div class="form-group">
                                            <div class="form-inline">
                                                <strong><asp:Label ID="lblCarrera" runat="server" >Carrera: </asp:Label></strong>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                                        <div class="form-group">
                                            <div class="form-inline">
                                                <asp:DropDownList ID="ddlCarreras" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlCarreras_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                        </div>
                                      
                                    </div>
                                    
                            </asp:Panel>
                        </div>
                        <div class="row mb-3">
                            <asp:Panel ID="pnPensums" runat="server" Visible="false">
                                <div class="col-xs-12 col-sm-4 col-md-3 col-lg-2">
                                        <div class="form-group">
                                            <div class="form-inline">
                                                <strong><asp:Label ID="lblPensumIngreso" runat="server" >Pensum ingreso: </asp:Label></strong>
                                            </div>
                                        </div>
                                    </div>
                                     <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                                        <div class="form-group">
                                            <div class="form-inline">
                                                <asp:DropDownList ID="ddlPensumIngreso" runat="server" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                            </asp:Panel>
                        </div>
                      </div>
                    <%--PIE DEL PANEL--%>	       
			   </div>
            </asp:Panel>
            <asp:Panel ID="pnDatosPer" runat="server">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">
                        <h3> <strong><asp:Label ID="Label1" runat="server" Text="Datos personales"></asp:Label></strong></h3>
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                        <br/>
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                <div class="col-xs-12">
                                      <asp:TextBox ID="tbPrimerApellido" runat="server" CssClass="form-control" MaxLength="40" AutoCompleteType="Disabled" ></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" BehaviorID="tbPrimerApellido_FilteredTextBoxExtender" TargetControlID="tbPrimerApellido" ValidChars="1234567890QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm-. " />
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lblPrimerAp" runat="server">Primer Apellido</asp:Label></strong>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbPrimerApellido" CssClass="text-danger" ErrorMessage="El campo 'Primer apellido' es obligatorio.">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                <div class="col-xs-12">
                                      <asp:TextBox ID="tbSegundoApellido" runat="server" CssClass="form-control" MaxLength="40" AutoCompleteType="Disabled" ></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" BehaviorID="tbSegundoApellido_FilteredTextBoxExtender" TargetControlID="tbSegundoApellido" ValidChars="1234567890QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm-. " />
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lblSegundoAp" runat="server">Segundo Apellido</asp:Label></strong>
                                    
                                </div>
                            </div>
                            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                <div class="col-xs-12">
                                      <asp:TextBox ID="tbNombres" runat="server" CssClass="form-control" MaxLength="50" AutoCompleteType="Disabled" ></asp:TextBox>
                                     <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" BehaviorID="tbNombres_FilteredTextBoxExtender" TargetControlID="tbNombres" ValidChars="1234567890QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm-. " />
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lblNombres" runat="server" >Nombres</asp:Label></strong>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbNombres" CssClass="text-danger" ErrorMessage="El campo 'Nombre' es obligatorio.">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                <div class="col-xs-12">
                                      <asp:TextBox ID="tbDocIdentidad" runat="server" CssClass="form-control" MaxLength="20" AutoCompleteType="Disabled" ></asp:TextBox>
                                      <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" BehaviorID="tbDocIdentidad_FilteredTextBoxExtender" TargetControlID="tbDocIdentidad" ValidChars="1234567890QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm-./\" />
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="Label8" runat="server">N° Documento de Identidad</asp:Label></strong>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbDocIdentidad" CssClass="text-danger" ErrorMessage="El campo 'N° Documento de identidad' es obligatorio.">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                <div class="col-xs-12">
                                      <asp:DropDownList ID="ddlTipoDocIdentidad" runat="server" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="Label9" runat="server">Tipo de documento de identidad</asp:Label></strong>
                                </div>
                            </div>
                            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                <div class="col-xs-12 text-center">
                                            <asp:DropDownList ID="ddlGrupoSangre" runat="server" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lblGrupoSangre" runat="server" >Grupo sanguíneo</asp:Label></strong>
                                </div>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                <div class="col-xs-12">
                                      <asp:DropDownList ID="ddlGenero" runat="server" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lblGenero" runat="server">Género</asp:Label></strong>
                                </div>
                            </div>
                            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                <div class="col-xs-12">
                                      <asp:DropDownList ID="ddlEstadoCivil" runat="server" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="Label12" runat="server" >Estado Civil</asp:Label></strong>
                                </div>
                            </div>
                            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                <div class="col-xs-12">
                                      <asp:DropDownList ID="ddlDiscapacidad" runat="server" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="Label3" runat="server" >Tiene alguna discapacidad</asp:Label></strong>
                                </div>
                            </div>
                        </div>
                        </div>
                    <%--PIE DEL PANEL--%>	       
			   </div>
            </asp:Panel>
            <asp:Panel ID="pnDatosNacimiento" runat="server">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">
                        <h3> <strong><asp:Label ID="lblTitulopnDatosNac" runat="server" Text="Datos de nacimiento"></asp:Label></strong></h3>
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                         <br/>
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                <div class="col-xs-12">
                                      <asp:TextBox ID="tbFechaNac" runat="server" TextMode="Date" max="2010-12-31" min="1940-01-01" MaxLength="10" CssClass="form-control" AutoCompleteType="Disabled" ></asp:TextBox>
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lblFechaNac" runat="server">Fecha de nacimiento</asp:Label></strong>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tbFechaNac" CssClass="text-danger" ErrorMessage="El campo 'Fecha de nacimiento' es obligatorio.">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                <div class="col-xs-12">
                                      <asp:DropDownList ID="ddlPaisNac" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlPaisNac_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lblPaisNac" runat="server">País de nacimiento</asp:Label></strong>
                                </div>
                            </div>
                            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                <div class="col-xs-12">
                                      <asp:DropDownList ID="ddlEstadoNac" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlEstadoNac_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lblEstadoNac" runat="server" >Estado/Departamento de nacimiento</asp:Label></strong>
                                </div>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                <div class="col-xs-12">
                                      <asp:DropDownList ID="ddlCiudadNac" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCiudadNac_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lblCiudadNac" runat="server">Ciudad de Nacimiento</asp:Label></strong>
                                </div>
                            </div>
                             <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                    <div class="col-xs-12">
                                        <asp:DropDownList ID="ddlAreaNacimiento" runat="server" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
                                    </div>
                                    <div class="col-xs-12 text-center">
                                        <strong><asp:Label ID="lblAreaNacimiento" runat="server">En el área</asp:Label></strong>
                                    </div>
                                </div>
                            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                <div class="col-xs-12">
                                      <asp:DropDownList ID="ddlNacionalidad" runat="server" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lblNacionalidad" runat="server">Nacionalidad</asp:Label></strong>
                                </div>
                            </div>
                        </div>
                       </div> 
                    <%--PIE DEL PANEL--%>	       
			   </div>
            </asp:Panel>
            <asp:Panel ID="pnDatosDomicilio" runat="server">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">
                        <h3> <strong><asp:Label ID="lblTitulopnDatosDom" runat="server" Text="Datos de domicilio"></asp:Label></strong></h3>
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                        <br/>
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-8 col-md-6 col-lg-6">
                                <div class="col-xs-12">
                                      <asp:TextBox ID="tbCalleAvenida" runat="server" CssClass="form-control" MaxLength="250" AutoCompleteType="Disabled" ></asp:TextBox>
                                      <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" BehaviorID="tbCalleAvenida_FilteredTextBoxExtender" TargetControlID="tbCalleAvenida" ValidChars="1234567890QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm-./\# " />
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lblCalleAvenida" runat="server">Calle o avenida</asp:Label></strong>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbCalleAvenida" CssClass="text-danger" ErrorMessage="El campo 'Calle o avenida' es obligatorio.">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-xs-12 col-sm-4 col-md-3 col-lg-3">
                                <div class="col-xs-12">
                                      <asp:TextBox ID="tbNumeroDom" runat="server" CssClass="form-control" MaxLength="20" AutoCompleteType="Disabled" ></asp:TextBox>
                                     <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" BehaviorID="tbNumeroDom_FilteredTextBoxExtender" TargetControlID="tbNumeroDom" ValidChars="1234567890QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm-/\ " />
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lblNumeroDom" runat="server">N°</asp:Label></strong>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="tbNumeroDom" CssClass="text-danger" ErrorMessage="El campo 'N°' es obligatorio.">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
                                <div class="col-xs-12">
                                      <asp:TextBox ID="tbZona" runat="server" CssClass="form-control" MaxLength="60" AutoCompleteType="Disabled" ></asp:TextBox>
                                      <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" BehaviorID="tbZona_FilteredTextBoxExtender" TargetControlID="tbZona" ValidChars="1234567890QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm-./\° " />
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lblZona" runat="server" >Zona</asp:Label></strong>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="tbZona" CssClass="text-danger" ErrorMessage="El campo 'Zona' es obligatorio.">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-7 col-md-6 col-lg-5">
                                <div class="col-xs-12">
                                      <asp:TextBox ID="tbNombreEdificio" runat="server" CssClass="form-control" MaxLength="60" AutoCompleteType="Disabled" ></asp:TextBox>
                                      <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" BehaviorID="tbNombreEdificio_FilteredTextBoxExtender" TargetControlID="tbNombreEdificio" ValidChars="1234567890QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm-.° " />
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lblNombreEdificio" runat="server">Nombre edificio</asp:Label></strong>
                                    
                                </div>
                            </div>
                            <div class="col-xs-12 col-sm-2 col-md-2 col-lg-2">
                                <div class="col-xs-12">
                                      <asp:TextBox ID="tbPiso" runat="server" CssClass="form-control" MaxLength="60" AutoCompleteType="Disabled" ></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" BehaviorID="tbPiso_FilteredTextBoxExtender" TargetControlID="tbPiso" ValidChars="1234567890QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm-° " />

                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lblPiso" runat="server">Piso</asp:Label></strong>
                                    
                                </div>
                            </div>
                           <div class="col-xs-12 col-sm-5 col-md-3 col-lg-2">
                                <div class="col-xs-12">
                                      <asp:TextBox ID="tbNumeroDepto" runat="server" CssClass="form-control" MaxLength="20" AutoCompleteType="Disabled" ></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" BehaviorID="tbNumeroDepto_FilteredTextBoxExtender" TargetControlID="tbNumeroDepto" ValidChars="1234567890QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm-° " />
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lblNumeroDepto" runat="server">N° de departamento</asp:Label></strong>
                                </div>
                            </div>
                            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
                                <div class="col-xs-12">
                                      <asp:DropDownList ID="ddlViveCon" runat="server" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lblViveCon" runat="server">Vive con</asp:Label></strong>
                                </div>
                            </div>
                            
                        </div>
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-4">
                                <div class="col-xs-12">
                                      <asp:TextBox ID="tbEmail" runat="server" CssClass="form-control" TextMode="Email" MaxLength="50" AutoCompleteType="Disabled" ></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" BehaviorID="tbEmail_FilteredTextBoxExtender" TargetControlID="tbEmail" ValidChars="1234567890QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm-._@ " />
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lblEmail" runat="server">Correo electrónico</asp:Label></strong>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="tbEmail" CssClass="text-danger" ErrorMessage="El campo 'Correo electrónico' es obligatorio.">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                           <div class="col-xs-12 col-sm-6 col-md-6 col-lg-4">
                                <div class="col-xs-12">
                                      <asp:TextBox ID="tbCelular" runat="server" CssClass="form-control"  MaxLength="9" AutoCompleteType="Disabled" ></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server" BehaviorID="tbCelular_FilteredTextBoxExtender" TargetControlID="tbCelular" ValidChars="1234567890+-" />
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="Label4" runat="server">Celular</asp:Label></strong>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="tbCelular" CssClass="text-danger" ErrorMessage="El campo 'Celular' es obligatorio.">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                <div class="col-xs-12">
                                      <asp:TextBox ID="tbTelefonoDomicilio" runat="server" CssClass="form-control" MaxLength="8" AutoCompleteType="Disabled" ></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" runat="server" BehaviorID="tbTelefonoDomicilio_FilteredTextBoxExtender" TargetControlID="tbTelefonoDomicilio" ValidChars="1234567890+-" />
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lblTelefonoDomicilio" runat="server" >Teléfono de domicilio</asp:Label></strong>
                                </div>
                            </div>
                        </div>
                      </div>
                    <%--PIE DEL PANEL--%>	       
			   </div>
            </asp:Panel>
           <asp:Panel ID="pnDatosBachillerato" runat="server">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">
                        <h3> <strong><asp:Label ID="lblTitulopnDatosBachillerato" runat="server" Text="Datos de bachillerato"></asp:Label></strong></h3>
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                         <br/>
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                <div class="col-xs-12">
                                      <asp:DropDownList ID="ddlPaisBach" runat="server" OnSelectedIndexChanged="ddlPaisBach_SelectedIndexChanged" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lblPaisBach" runat="server">País</asp:Label></strong>
                                </div>
                            </div>
                            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                <div class="col-xs-12">
                                      <asp:DropDownList ID="ddlEstadoBach" runat="server" OnSelectedIndexChanged="ddlEstadoBach_SelectedIndexChanged" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lblEstadoBach" runat="server" >Estado/Departamento</asp:Label></strong>
                                </div>
                            </div>
                            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                <div class="col-xs-12">
                                   <asp:DropDownList ID="ddlCiudadBach" runat="server" OnSelectedIndexChanged="ddlCiudadBach_SelectedIndexChanged" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lblCiudadBach" runat="server">Ciudad</asp:Label></strong>
                                </div>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                    <div class="col-xs-12">
                                        <asp:DropDownList ID="ddlAreaColegio" runat="server" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
                                    </div>
                                    <div class="col-xs-12 text-center">
                                        <strong><asp:Label ID="lblAreaColegio" runat="server">En el área</asp:Label></strong>
                                    </div>
                                </div>
                            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                    <div class="col-xs-12">
                                        <asp:DropDownList ID="ddlTipoColegio" runat="server" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
                                    </div>
                                    <div class="col-xs-12 text-center">
                                        <strong><asp:Label ID="lblTipoColegio" runat="server">Tipo de colegio</asp:Label></strong>
                                    </div>
                                </div>
                            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                    <div class="col-xs-12">
                                        <asp:DropDownList ID="ddlTurno" runat="server" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
                                    </div>
                                    <div class="col-xs-12 text-center">
                                        <strong><asp:Label ID="lblTurno" runat="server">Turno</asp:Label></strong>
                                    </div>
                                </div>
                            </div>
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                                <div class="col-xs-12">
                                      <asp:DropDownList ID="ddlColegio" runat="server" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lblColegio" runat="server">Colegio</asp:Label></strong>
                                </div>
                            </div>
                            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-3">
                                <div class="col-xs-12">
                                     <asp:DropDownList ID="ddlAnio" runat="server" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lblAnio" runat="server">Año</asp:Label></strong>
                                </div>
                            </div>
                            </div>
                       </div> 
                    <%--PIE DEL PANEL--%>	       
			   </div>
            </asp:Panel>
            <asp:Panel ID="pnDatosTutor" runat="server">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">
                        <h3> <strong><asp:Label ID="lblTituloDatosTutor" runat="server" Text="Datos del padre, madre, tutor/a u otro"></asp:Label></strong></h3>
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                        <div class="row mb-3">
                           <div class="col-xs-12 col-sm-5 col-md-5 col-lg-4">
                                <h3>Datos personales</h3>
                                    <br />
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-xs-12">
                                <div class="col-xs-12 col-sm-5 col-md-3 col-lg-2 text-center">
                                    <strong><asp:Label ID="lblParentescoTutor" runat="server">Parentesco</asp:Label></strong>
                                </div>
                                <div class="col-sm-5 col-md-4 col-lg-3">
                                       <asp:DropDownList ID="ddlParentesco" runat="server" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-sm-5 col-md-4 col-lg-3">
                                      <div class="col-xs-12 text-center">
                                        <asp:RadioButton id="rbSi" GroupName="Seguimiento" Text="Si" runat="server" Checked="true"/>
                                          <br />
                                        <asp:RadioButton id="rbNo" GroupName="Seguimiento" Text="No" runat="server"/>
                                    </div>
                                    <div class="col-xs-12 text-center">
                                        <strong><asp:Label ID="lblAutseguimiento" runat="server">Autorizar seguimiento</asp:Label></strong>
                                </div>
                                </div>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                <div class="col-xs-12">
                                      <asp:TextBox ID="tbPrimerApTutor" runat="server" CssClass="form-control" MaxLength="40" AutoCompleteType="Disabled" ></asp:TextBox>
                                      <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" runat="server" BehaviorID="tbPrimerApTutor_FilteredTextBoxExtender" TargetControlID="tbPrimerApTutor" ValidChars="1234567890QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm-._° "/>    
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lblPrimerApTutor" runat="server">Primer Apellido</asp:Label></strong>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="tbPrimerApTutor" CssClass="text-danger" ErrorMessage="El campo 'Primer apellido' en 'Datos tutor' es obligatorio.">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                <div class="col-xs-12">
                                      <asp:TextBox ID="tbSegundoApTutor" runat="server" CssClass="form-control" MaxLength="40" AutoCompleteType="Disabled" ></asp:TextBox>
                                      <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" runat="server" BehaviorID="tbSegundoApTutor_FilteredTextBoxExtender" TargetControlID="tbSegundoApTutor" ValidChars="1234567890QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm-._° "/>    
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lblSegundoApTutor" runat="server">Segundo Apellido</asp:Label></strong>
                                    
                                </div>
                            </div>
                            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                <div class="col-xs-12">
                                      <asp:TextBox ID="tbNombreTutor" runat="server" CssClass="form-control" MaxLength="50" AutoCompleteType="Disabled" ></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender16" runat="server" BehaviorID="tbNombreTutor_FilteredTextBoxExtender" TargetControlID="tbNombreTutor" ValidChars="1234567890QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm-._° "/>    
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lblNombreTutor" runat="server" >Nombres</asp:Label></strong>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="tbNombreTutor" CssClass="text-danger" ErrorMessage="El campo 'Nombre' en 'Datos tutor' es obligatorio.">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                <div class="col-xs-12">
                                      <asp:TextBox ID="tbDocIdentidadTutor" runat="server" CssClass="form-control" MaxLength="20" AutoCompleteType="Disabled" ></asp:TextBox>
                                      <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender17" runat="server" BehaviorID="tbDocIdentidadTutor_FilteredTextBoxExtender" TargetControlID="tbDocIdentidadTutor" ValidChars="1234567890QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm-._\/ "/>    
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lblDocIdentidadTutor" runat="server">N° Documento de Identidad</asp:Label></strong>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="tbDocIdentidadTutor" CssClass="text-danger" ErrorMessage="El campo 'N° Documento de identidad' en'Datos tutor' es obligatorio.">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                <div class="col-xs-12">
                                      <asp:DropDownList ID="ddlTipoDocIdentidadTutor" runat="server" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lblTipoDocIdentidadTutor" runat="server">Tipo de documento de identidad</asp:Label></strong>
                                </div>
                            </div>
                            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                <div class="col-xs-12">
                                      <asp:DropDownList ID="ddlGeneroTutor" runat="server" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lblGeneroTuror" runat="server" >Género</asp:Label></strong>
                                </div>
                            </div>
                        </div>
                       
                        <div class="row mb-3">
                           <div class="col-xs-12 col-sm-5 col-md-5 col-lg-4">
                                <h3>Datos de domicilio</h3>
                                    <br />
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-8 col-md-7 col-lg-5">
                                <div class="col-xs-12">
                                      <asp:TextBox ID="tbCalleAvenidaTutor" runat="server" CssClass="form-control" MaxLength="250" AutoCompleteType="Disabled" ></asp:TextBox>
                                      <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" runat="server" BehaviorID="tbCalleAvenidaTutor_FilteredTextBoxExtender" TargetControlID="tbCalleAvenidaTutor" ValidChars="1234567890QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm-._\/° "/>    
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lblCalleAvenidaTutor" runat="server">Calle o avenida</asp:Label></strong>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="tbCalleAvenidaTutor" CssClass="text-danger" ErrorMessage="El campo 'Calle o avenida' en 'Datos tutor' es obligatorio.">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-xs-12 col-sm-4 col-md-5 col-lg-3">
                                <div class="col-xs-12">
                                      <asp:TextBox ID="tbNumeroDomTutor" runat="server" CssClass="form-control" MaxLength="20" AutoCompleteType="Disabled" ></asp:TextBox>
                                      <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" runat="server" BehaviorID="tbNumeroDomTutor_FilteredTextBoxExtender" TargetControlID="tbNumeroDomTutor" ValidChars="1234567890QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm-._\/° "/>    
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lblNumeroDomTutor" runat="server">N°</asp:Label></strong>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="tbNumeroDomTutor" CssClass="text-danger" ErrorMessage="El campo 'N°' en 'Datos tutor' es obligatorio.">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                <div class="col-xs-12">
                                    <asp:TextBox ID="tbZonaTutor" runat="server" CssClass="form-control" MaxLength="60" AutoCompleteType="Disabled" ></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender20" runat="server" BehaviorID="tbZonaTutor_FilteredTextBoxExtender" TargetControlID="tbZonaTutor" ValidChars="1234567890QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm-._\/° "/>    
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lblZonaTutor" runat="server" >Zona</asp:Label></strong>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="tbZonaTutor" CssClass="text-danger" ErrorMessage="El campo 'Zona' en 'Datos tutor' es obligatorio.">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-8 col-md-7 col-lg-4">
                                <div class="col-xs-12">
                                      <asp:TextBox ID="tbEdificioTutor" runat="server" CssClass="form-control" MaxLength="60" AutoCompleteType="Disabled" ></asp:TextBox>
                                      <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender21" runat="server" BehaviorID="tbEdificioTutor_FilteredTextBoxExtender" TargetControlID="tbEdificioTutor" ValidChars="1234567890QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm-._\/° "/>    
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lblEdificioTutor" runat="server">Nombre edificio</asp:Label></strong>
                                    
                                </div>
                            </div>
                           <div class="col-xs-12 col-sm-4 col-md-5 col-lg-4">
                                <div class="col-xs-12">
                                      <asp:TextBox ID="tbDeptoTutor" runat="server" CssClass="form-control" MaxLength="20" AutoCompleteType="Disabled" ></asp:TextBox>
                                      <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender22" runat="server" BehaviorID="tbDeptoTutor_FilteredTextBoxExtender" TargetControlID="tbDeptoTutor" ValidChars="1234567890QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm-._\/° "/>    
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lblDeptoTutor" runat="server">N° de departamento</asp:Label></strong>
                                    
                                </div>
                            </div>
                            
                        </div>
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-7 col-md-7 col-lg-6">
                                <div class="col-xs-12">
                                      <asp:TextBox ID="tbEmailTutor" runat="server" CssClass="form-control" TextMode="Email" MaxLength="50" AutoCompleteType="Disabled" ></asp:TextBox>
                                      <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender23" runat="server" BehaviorID="tbEmailTutor_FilteredTextBoxExtender" TargetControlID="tbEmailTutor" ValidChars="1234567890QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm-._@ "/>  
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lblEmailTutor" runat="server">Correo electrónico</asp:Label></strong>
                                    
                                </div>
                            </div>
                           <div class="col-xs-12 col-sm-5 col-md-5 col-lg-3">
                                <div class="col-xs-12">
                                      <asp:TextBox ID="tbCelularTutor" runat="server" CssClass="form-control"  MaxLength="9" AutoCompleteType="Disabled" ></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender24" runat="server" BehaviorID="tbCelularTutor_FilteredTextBoxExtender" TargetControlID="tbCelularTutor" ValidChars="1234567890-+"/>  
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lblCelularTutor" runat="server">Celular</asp:Label></strong>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="tbCelularTutor" CssClass="text-danger" ErrorMessage="El campo 'Celular' en 'Datos tutor' es obligatorio.">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-xs-12 col-sm-5 col-md-5 col-lg-3">
                                <div class="col-xs-12">
                                      <asp:TextBox ID="tbTelefonoTutor" runat="server" CssClass="form-control" MaxLength="8" AutoCompleteType="Disabled" ></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender25" runat="server" BehaviorID="tbTelefonoTutor_FilteredTextBoxExtender" TargetControlID="tbTelefonoTutor" ValidChars="1234567890-+"/>  
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="Label17" runat="server" >Teléfono de domicilio</asp:Label></strong>
                                </div>
                            </div>
                        </div>
                        <div class="row mb-3">
                           <div class="col-xs-12 col-sm-5 col-md-5 col-lg-4">
                                <h3>Datos laborales</h3>
                                    <br />
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-12 col-md-5 col-lg-5">
                                <div class="col-xs-12">
                                      <asp:TextBox ID="tbInstitucionLaboralTutor" runat="server" CssClass="form-control" MaxLength="100" AutoCompleteType="Disabled" ></asp:TextBox>
                                      <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender26" runat="server" BehaviorID="tbInstitucionLaboralTutor_FilteredTextBoxExtender" TargetControlID="tbInstitucionLaboralTutor" ValidChars="1234567890QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm-._@ "/>  
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="Label2" runat="server">Institución en la que trabaja</asp:Label></strong>
                                    
                                </div>
                            </div>
                            <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4">
                                <div class="col-xs-12">
                                      <asp:TextBox ID="tbCargoTutor" runat="server" CssClass="form-control" MaxLength="100" AutoCompleteType="Disabled" ></asp:TextBox>
                                     <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender27" runat="server" BehaviorID="tbCargoTutor_FilteredTextBoxExtender" TargetControlID="tbCargoTutor" ValidChars="1234567890QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm-._@ "/>  
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lblCargoTutor" runat="server">Cargo</asp:Label></strong>

                                </div>
                            </div>
                            <div class="col-xs-12 col-sm-12 col-md-3 col-lg-3">
                                <div class="col-xs-12">
                                      <asp:TextBox ID="tbTelefonoOficina" runat="server" CssClass="form-control" MaxLength="9" AutoCompleteType="Disabled" ></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender28" runat="server" BehaviorID="tbTelefonoOficina_FilteredTextBoxExtender" TargetControlID="tbTelefonoOficina" ValidChars="1234567890-+"/>  
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lbltelefonoOficina" runat="server">Teléfono Oficina</asp:Label></strong>
                                </div>
                            </div>
                        </div>
                     </div>
                    <%--PIE DEL PANEL--%>	       
			   </div>
            </asp:Panel>
            <asp:Panel ID="pnContactoEmergen" runat="server">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">
                        <h3> <strong><asp:Label ID="lblContactoEmergen" runat="server" Text="Contacto de emergencia"></asp:Label></strong></h3>
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                        <br />
                        <div class="row mb-3">
                                <div class="col-sm-12 col-md-12 col-lg-12">
                                      <div class="col-xs-12">
                                         <strong><asp:Label ID="lblContactoEmergencia" runat="server">Definir tutor como contacto de emergencia: </asp:Label></strong>
                                        <asp:RadioButton id="rbContactoEmerTutorSi" GroupName="rbContactoEmerTutor" Text="Si" runat="server" AutoPostBack="true" OnCheckedChanged="rbContactoEmerTutorSi_CheckedChanged"/>
                                          
                                        <asp:RadioButton id="rbContactoEmerTutorNo" GroupName="rbContactoEmerTutor" Text="No" runat="server" AutoPostBack="true" OnCheckedChanged="rbContactoEmerTutorNo_CheckedChanged" Checked="true"/>
                                    </div>
                                    <div class="col-xs-12 text-center">
                                       
                                </div>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-12 col-md-10 col-lg-8">
                                <div class="col-xs-12">
                                      <asp:TextBox ID="tbNombreCompleto" runat="server" CssClass="form-control" MaxLength="150" AutoCompleteType="Disabled" ></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender29" runat="server" BehaviorID="tbNombreCompleto_FilteredTextBoxExtender" TargetControlID="tbNombreCompleto" ValidChars="1234567890QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm-._@ "/>  
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lblNombreCompleto" runat="server">Nombre completo</asp:Label></strong>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="tbNombreCompleto" CssClass="text-danger" ErrorMessage="El campo 'Nombre completo' es obligatorio.">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                           
                        </div>
                        <div class="row mb-3">
                            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                <div class="col-xs-12">
                                      <asp:TextBox ID="tbTelefonoContacto1" runat="server" CssClass="form-control" MaxLength="20" AutoCompleteType="Disabled" ></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender30" runat="server" BehaviorID="tbTelefonoContacto1_FilteredTextBoxExtender" TargetControlID="tbTelefonoContacto1" ValidChars="1234567890-+"/>  
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lblTelefonoContacto1" runat="server">Teléfono de referencia 1</asp:Label></strong>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="tbTelefonoContacto1" CssClass="text-danger" ErrorMessage="El campo 'Telefono de referencia 1' es obligatorio.">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                                 <div class="col-xs-12">
                                      <asp:TextBox ID="tbTelefonoContacto2" runat="server" CssClass="form-control" MaxLength="20" AutoCompleteType="Disabled" ></asp:TextBox>
                                     <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender31" runat="server" BehaviorID="tbTelefonoContacto2_FilteredTextBoxExtender" TargetControlID="tbTelefonoContacto2" ValidChars="1234567890-+"/>  
                                </div>
                                <div class="col-xs-12 text-center">
                                    <strong><asp:Label ID="lblTelefonoContacto2" runat="server">Teléfono de referencia 2</asp:Label></strong>
                                </div>
                            </div>
                        </div>
                     </div>
                    <%--PIE DEL PANEL--%>	       
			   </div>
            </asp:Panel>
            <asp:Panel ID="pnEnviar" runat="server" Visible="false">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                        <br/>
                        <div class="form-inline">
                            <div class="form-group">
                                <img alt="" src="../BuildCaptcha.aspx"/>
                                <div class="input-group">
                                  <span class="input-group-addon"><i class="fa fa-shield"></i></span>
                                  <asp:TextBox ID="tbCaptcha" CssClass="form-control" runat="server" MaxLength="7" placeholder="Ingrese el patrón" autocomplete="off"></asp:TextBox>
                                </div>
                                 <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender33" runat="server" BehaviorID="tbCaptcha_FilteredTextBoxExtender" TargetControlID="tbCaptcha" ValidChars="1234567890QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm-_"/>    
                                  <asp:RequiredFieldValidator ID="tbCaptcha_RequiredFieldValidator" runat="server" ErrorMessage="Debe ingresar el patrón de la imagen." ControlToValidate="tbCaptcha" CssClass="glyphicon glyphicon-remove text-danger" Text="."></asp:RequiredFieldValidator>
                                 </div>
                            </div>
                      </div>
                    <%--PIE DEL PANEL--%>	    
                    <div class="panel-footer">
                        <div class="btn-toolbar" role="toolbar">
                           <div class="btn-group center-block">
                               <asp:Button ID="btnCrear" runat="server" CssClass="btn btn-success btn-default btn-block" Text="Enviar formulario" OnClick="btnEnviar_Click" CausesValidation="true"  ForeColor="White" />
                            </div>
                          </div>
                        </div>
			   </div>
            </asp:Panel>
            <asp:Panel ID="pnObservaciones" runat="server" Visible="false">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">
                        <h3> <strong><asp:Label ID="lblTituloOpnObservaciones" runat="server" Text="Observaciones"></asp:Label></strong></h3>
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                        <br/>
                        <div class="row mb-3">
                            <div class="col-xs-12">
                                <strong><asp:Label ID="lblObservaciones" Text="Observaciones: " runat="server" ></asp:Label></strong>
                                <asp:TextBox ID="tbObservaciones" runat="server" CssClass="form-control" TextMode="MultiLine" AutoCompleteType="Disabled" ></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender32" runat="server" BehaviorID="tbObservaciones_FilteredTextBoxExtender" TargetControlID="tbObservaciones" ValidChars="1234567890QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm-._@ "/>  
                            </div>
                        </div>
                      </div>
                    <%--PIE DEL PANEL--%>	    
                    <div class="panel-footer">
                        <div class="btn-toolbar" role="toolbar">
                           <div class="btn-group center-block">
                               <asp:Button ID="btnEnviar" runat="server" CssClass="btn btn-success btn-default btn-block" Text="Enviar formulario" OnClick="btnEnviar_Click" CausesValidation="true"  ForeColor="White" />
                            </div>
                          </div>
                        </div>
			   </div>
            </asp:Panel>
            <%--MODAL ALUMNO EXISTENTE--%>
            <asp:UpdatePanel ID="upAlumnoExiste" runat="server" Visible="false">
                <ContentTemplate>
                    <div id="modalAlumnoExistente" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="modalLblAlumno" aria-hidden="true" >
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <center><h3 class="modal-title" id="modalLblAlumno">Alumno Existente</h3></center>
                                </div>
                                <div class="modal-body">
                                    <H3>Existen coincidencias con los datos del ESTUDIANTE. </H3>
                                    <H4>Elija si quiere usar un registro existente o registrar como nueva persona. </H4>
                                    <%--INICIO GridView de prueba--%>
                                    <asp:Panel ID="pnsugeridos" runat="server" Visible="false">
                                      <br />
                                     <div class="row">
                                        <div class="col-xs-12">
                                            <div class="row">
                                                    <div class="col-xs-12">
                                                        <div class="form-inline">
                                                            <div class="form-group">
                                                                <asp:GridView ID="gvEstudiantes" runat="server" CssClass="table table-striped table-bordered table-hover input-sm" AutoGenerateColumns="False" PageSize="15" OnRowCommand="gvEstudiantes_RowCommand" >
                                                                    <Columns>
                                                                        <asp:BoundField DataField="num_sec" HeaderText="ns"  Visible="false"/>
                                                                        <asp:BoundField DataField="cedula_identidad" HeaderText="Documento de identidad" />
                                                                        <asp:BoundField DataField="ap_paterno" HeaderText="Primer Apellido" />
                                                                        <asp:BoundField DataField="ap_materno" HeaderText="Segundo Apellido" />
                                                                        <asp:BoundField DataField="nombres" HeaderText="Nombre" />
                                                                        <asp:ButtonField HeaderText="" ButtonType="Button" CommandName="elegir" Text="Elegir" >
                                                                             <ControlStyle CssClass="btn btn-sm btn-success "/>
                                                                        </asp:ButtonField>
                                                                    </Columns>
                                                                    <PagerStyle CssClass="GridPager" Wrap="True" />
                                                                    <SelectedRowStyle BackColor="#008A8C" ForeColor="White" />
                                                                    <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                                                                </asp:GridView>
                                                               </div>
                                                            </div>
                                                    </div>
                                               </div>
                                            </div>
                                        </div>
                                     </asp:Panel>
                                    <%--FIN GridView de prueba--%>
                                </div>
                                <div class="modal-footer">
                                    <asp:Button ID="btnGuardarModalAlumno" runat="server" CssClass="btn btn-success" Text="Crear nuevo" CausesValidation="False" OnClick="btnGuardarModalAlumno_Click"/>
                                    <asp:Button ID="btnCancelarModalAlumno" runat="server" CssClass="btn btn-danger" Text="Cancelar" CausesValidation="False" OnClientClick="CancelarModalAlumno()" OnClick="btnCancelarModalAlumno_Click"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <%--MODAL FAMILIAR EXISTENTE--%>
            <asp:UpdatePanel ID="upFamiliarExiste" runat="server" Visible="false">
                <ContentTemplate>
                    <div id="modalFamiliarExistente" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="modalLblFamiliar" aria-hidden="true" >
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <center><h3 class="modal-title" id="modalLblFamiliar">Familiar Existente</h3></center>
                                </div>
                                <div class="modal-body">
                                    <H3>Existen coincidencias con los datos del TUTOR del estudiante. </H3>
                                    <H4>Elija si quiere usar un registro existente o registrar como nueva persona. </H4>
                                    <%--INICIO GridView de prueba--%>
                                    <asp:Panel ID="pnFamiliaresSugeridos" runat="server" Visible="false">
                                      <br />
                                     <div class="row">
                                        <div class="col-xs-12">
                                            <div class="row">
                                                    <div class="col-xs-12">
                                                        <div class="form-inline">
                                                            <div class="form-group">
                                                                <asp:GridView ID="gvTutores" runat="server" CssClass="table table-striped table-bordered table-hover input-sm" AutoGenerateColumns="False" PageSize="15" OnRowCommand="gvTutores_RowCommand" >
                                                                    <Columns>
                                                                        <asp:BoundField DataField="num_sec" HeaderText="ns"  Visible="false"/>
                                                                        <asp:BoundField DataField="cedula_identidad" HeaderText="Documento de identidad" />
                                                                        <asp:BoundField DataField="ap_paterno" HeaderText="Primer Apellido" />
                                                                        <asp:BoundField DataField="ap_materno" HeaderText="Segundo Apellido" />
                                                                        <asp:BoundField DataField="nombres" HeaderText="Nombre" />
                                                                        <asp:ButtonField HeaderText="" ButtonType="Button" CommandName="elegir" Text="Elegir" >
                                                                             <ControlStyle CssClass="btn btn-sm btn-success "/>
                                                                        </asp:ButtonField>
                                                                    </Columns>
                                                                    <PagerStyle CssClass="GridPager" Wrap="True" />
                                                                    <SelectedRowStyle BackColor="#008A8C" ForeColor="White" />
                                                                    <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                                                                </asp:GridView>
                                                               </div>
                                                            </div>
                                                    </div>
                                               </div>
                                            </div>
                                        </div>
                                     </asp:Panel>
                                    <%--FIN GridView de prueba--%>
                                </div>
                                <div class="modal-footer">
                                    <asp:Button ID="btnGuardarModalFamiliar" runat="server" CssClass="btn btn-success" Text="Crear nuevo" CausesValidation="False" OnClick="btnGuardarModalFamiliar_Click"/>
                                    <asp:Button ID="btnCancelarModalFamiliar" runat="server" CssClass="btn btn-danger" Text="Cancelar" CausesValidation="False" OnClientClick="CancelarModalFamiliar()" OnClick="btnCancelarModalFamiliar_Click"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
           <%--Mensajes de exito y error--%>
            <div class="row">
	            <div class="col-md-6">
	                <asp:Panel ID="pnMensajeError" runat="server" Visible="false">
		                <div class="alert alert-danger alert-dismissable">
			                <asp:Label ID="lblMensajeError" runat="server" Text=""></asp:Label><a href="#" class="alert-link"></a>.
		                </div>                        
	                </asp:Panel>
	                <asp:Panel ID="pnMensajeOK" runat="server" Visible="false">
		                <div class="alert alert-success alert-dismissable">
			                <asp:Label ID="lblMensajeOK" runat="server" Text=""></asp:Label><a href="#" class="alert-link"></a>.
		                </div>
	                </asp:Panel>
                    <%--Panel Final de la pagina--%>
                    <asp:Panel ID="pnFinal" runat="server" Visible="false">
                        <div class="alert alert-light">
			                <asp:Label ID="lblFinal" runat="server" Text=""></asp:Label><a href="#" class="alert-link"></a>
		                </div>
                    </asp:Panel> 
                    <%--Mensaje de Error AJAXValidator--%>
                    <%--<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="False" ShowSummary="True" CssClass="alert alert-danger" />                    --%>
	            </div>                
            </div>            
            <script type="text/javascript">
                function CancelarModalAlumno() {
                }
                function CancelarModalFamiliar() {

                }
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
