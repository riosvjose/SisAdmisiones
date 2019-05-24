<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Principal.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SisAdmisiones.Forms.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="refresh" content="300"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row">
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
    </div>
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Inicio</h1>
        </div>
    </div>
</asp:Content>
