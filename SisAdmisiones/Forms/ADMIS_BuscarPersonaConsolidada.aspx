<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Principal.Master" AutoEventWireup="true" CodeBehind="ADMIS_BuscarPersonaConsolidada.aspx.cs" Inherits="SisAdmisiones.Forms.ADMIS_BuscarPersonaConsolidada" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
	            <div class="col-xs-12">
		            <h1>Buscar persona</h1>
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
             <%--panel administar ususarios--%>
            <asp:Panel ID="pnAdmUsuarios" runat="server" Visible="true">
		        <div class="panel panel-info">
                    <%--ENCABEZADO DEL PANEL--%>
			        <div class="panel-heading">
                        <h3> <strong><asp:Label ID="lblAdmUsuarios" runat="server" Text="Administrar usuarios"></asp:Label></strong></h3>
			        </div>
                    <%--CUERPO DEL PANEL--%>
			        <div class="panel-body">
                     <br />
                        <div class="row">
                            <div class="col-xs-12">
                                 <div class="form-inline">
                                       <strong><asp:Label ID="lblusuario" runat="server" Text="Búsqueda:"></asp:Label></strong>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbusuario" CssClass="text-danger" ErrorMessage="El campo usuario es obligatorio.">*</asp:RequiredFieldValidator>
                                       <asp:TextBox ID="tbusuario" runat="server" CssClass="form-control" MaxLength="100" AutoCompleteType="Disabled"></asp:TextBox>
                                       <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender29" runat="server" BehaviorID="tbusuario_FilteredTextBoxExtender" TargetControlID="tbusuario" ValidChars=".1234567890QWERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnm_- " />
                                       <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-info" Text="Buscar" CausesValidation="true" OnClick="btnBuscar_Click" />
                                 </div>
                             </div>
                         </div>
                    <asp:Panel ID="pnsugeridos" runat="server" Visible="false">
                          <br />
                         <div class="row">
                            <div class="col-xs-12">
                                <div class="row">
                                        <div class="col-xs-12">
                                            <div class="form-inline">
                                                <div class="form-group">
                                                    <asp:GridView ID="gvUsuarios" runat="server" CssClass="table table-striped table-bordered table-hover input-sm" AutoGenerateColumns="False" PageSize="15" OnRowCommand="gvDatos1_RowCommand" >
                                                        <Columns>
                                                            <asp:BoundField DataField="num_sec_datos_per" HeaderText="ns"  Visible="false"/>
                                                            <asp:BoundField DataField="doc_identidad" HeaderText="Documento de identidad" />
                                                            <asp:BoundField DataField="primer_apellido" HeaderText="Primer Apellido" />
                                                            <asp:BoundField DataField="segundo_apellido" HeaderText="Segundo Apellido" />
                                                            <asp:BoundField DataField="nombres" HeaderText="Nombre" />
                                                            <asp:ButtonField HeaderText="" ButtonType="Button" CommandName="ver" Text="Ver" >
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
                    </div>
                    <%--PIE DEL PANEL--%>
		        </div>
            </asp:Panel>    
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
                    <asp:Panel ID="pnVacio" runat="server" Visible="false">
	                </asp:Panel>
                    <%--Mensaje de Error AJAXValidator--%>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="False" ShowSummary="True" CssClass="alert alert-danger" />
	            </div>
            </div>  
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
