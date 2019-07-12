<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SisAdmisiones.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no" />
    <meta name="description" content="Admisiones " />
    <meta name="author" content="Centro de Sistemas - UCB" />
    <link rel="icon" type="image/png" href="Img/faviconUCB.png" />
    <title>ADMISIONES</title>
    <link href="Styles/bootstrap.min.css" rel="stylesheet" />
    <link href="Styles/font-awesome.min.css" rel="stylesheet" />
    <link href="Styles/ucb_lpz.css" rel="stylesheet" />
</head>
<body>
    <div class="container">
        <div class="row">
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 ">
                <br /><br />        
                <div id="authBody" class="loginPageBody">

                    <%--CABECERA--%>
                    <div id="authHeader">
                        <div class="row">
                            <div class="form-horizontal"><br />
                                 <div class="col-xs-3 text-left">
                                    <div class="logo">
                                        <a id="logo-link" href="Default.aspx"></a>
                                    </div>
                                </div>
                                <div class="col-xs-8 text-right">
                                    <div class="hidden-xs hidden-sm">
                                        <h1>Universidad Cat&oacute;lica Boliviana "San Pablo"<br />
                                            Unidad Académica La Paz
                                        </h1>
                                    </div>
                                    <div class="visible-sm">
                                        <h3>Universidad Cat&oacute;lica Boliviana "San Pablo"<br />
                                            Unidad Académica La Paz
                                        </h3>
                                    </div>
                                    <div class="visible-xs">
                                        <h5>Universidad Cat&oacute;lica Boliviana "San Pablo"<br />
                                            Unidad Académica La Paz
                                        </h5>
                                    </div>
                                        <div class="col-xs-12 text-right">
                                            <a id="A1" runat="server" href="~/Forms/ADMIS_FormRegistro.aspx" visible="true" ><h3 style ="color:#0e0e38; ">Registrar nuevo</h3></a>
                                        </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <%--CUERPO--%>
                    <div id="authContent" class="pageContent">
                        <div id="signupBody">
                            <div class="text-center">
                                <div class="hidden-xs">
                                    <h3>Bienvenido al<br />SISTEMA DE ADMISIONES</h3>
                                </div>
                                <div class="visible-xs">
                                    <h4>SISTEMA DE ADMISIONES</h4>
                                </div>
                            </div>                            
                            <br />
                            <div class="col-md-offset-4 col-md-4">
                                <form id="form1" class="form-horizontal" runat="server">
                                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <fieldset>
                                                <div class="form-group">
                                                    <label>Usuario</label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon"><i class="fa fa-user fa-fw"></i></span>
                                                        <asp:TextBox ID="tbUsuario" CssClass="form-control" placeholder="Ingrese su usuario ..." runat="server" MaxLength="20" AutoCompleteType="Disabled"></asp:TextBox>
                                                    </div>
                                                    <asp:RequiredFieldValidator ID="tbCI_RequiredFieldValidator" ControlToValidate="tbUsuario" runat="server" ErrorMessage="Debe ingresar su usuario." Text="*" CssClass="text-warning"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="form-group">
                                                    <label>Contraseña</label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon"><i class="fa fa-key fa-fw"></i></span>
                                                        <asp:TextBox ID="tbPassword" CssClass="form-control" placeholder="Ingrese su contraseña ..." runat="server" TextMode="Password" MaxLength="32" AutoCompleteType="Disabled"></asp:TextBox>
                                                    </div>
                                                    <asp:RequiredFieldValidator ID="tbPassword_RequiredFieldValidator" ControlToValidate="tbPassword" runat="server" ErrorMessage="Debe ingresar su contraseña." Text="*" CssClass="text-warning"></asp:RequiredFieldValidator>
                                                </div>
                                                <asp:Button ID="btnIngresar" CssClass="btn btn-success" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
                                                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                                    <ProgressTemplate>
                                                        <asp:Image ID="imgProcesando" runat="server" ImageUrl="data:image/gif;base64,R0lGODlhEAAQAPIAAP///wAAAMLCwkJCQgAAAGJiYoKCgpKSkiH/C05FVFNDQVBFMi4wAwEAAAAh/hpDcmVhdGVkIHdpdGggYWpheGxvYWQuaW5mbwAh+QQJCgAAACwAAAAAEAAQAAADMwi63P4wyklrE2MIOggZnAdOmGYJRbExwroUmcG2LmDEwnHQLVsYOd2mBzkYDAdKa+dIAAAh+QQJCgAAACwAAAAAEAAQAAADNAi63P5OjCEgG4QMu7DmikRxQlFUYDEZIGBMRVsaqHwctXXf7WEYB4Ag1xjihkMZsiUkKhIAIfkECQoAAAAsAAAAABAAEAAAAzYIujIjK8pByJDMlFYvBoVjHA70GU7xSUJhmKtwHPAKzLO9HMaoKwJZ7Rf8AYPDDzKpZBqfvwQAIfkECQoAAAAsAAAAABAAEAAAAzMIumIlK8oyhpHsnFZfhYumCYUhDAQxRIdhHBGqRoKw0R8DYlJd8z0fMDgsGo/IpHI5TAAAIfkECQoAAAAsAAAAABAAEAAAAzIIunInK0rnZBTwGPNMgQwmdsNgXGJUlIWEuR5oWUIpz8pAEAMe6TwfwyYsGo/IpFKSAAAh+QQJCgAAACwAAAAAEAAQAAADMwi6IMKQORfjdOe82p4wGccc4CEuQradylesojEMBgsUc2G7sDX3lQGBMLAJibufbSlKAAAh+QQJCgAAACwAAAAAEAAQAAADMgi63P7wCRHZnFVdmgHu2nFwlWCI3WGc3TSWhUFGxTAUkGCbtgENBMJAEJsxgMLWzpEAACH5BAkKAAAALAAAAAAQABAAAAMyCLrc/jDKSatlQtScKdceCAjDII7HcQ4EMTCpyrCuUBjCYRgHVtqlAiB1YhiCnlsRkAAAOwAAAAAAAAAAAA==" />
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </fieldset>
                                            <br />
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="False" ShowSummary="True" CssClass="alert alert-danger"/>
                                                <asp:Label ID="lblMensaje" runat="server" Text="" Visible="false" CssClass="alert alert-danger" Height="80px"></asp:Label>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </form>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-offset-3 col-md-4">
                                <script type="text/javascript" src="https://seal.thawte.com/getthawteseal?host_name=www.ucb.edu.bo&amp;size=S&amp;lang=es"></script>
                            </div>
                        </div>
                    </div>

                    <%--PIE--%>
                    <div id="authFooter">
                        <div class="row">
                            <div class="col-xs-12">
                                <div class="text-right">
                                    <br />
                                    <asp:Label ID="Label1" runat="server" Text="Version 2019.04" CssClass="text-info small"></asp:Label><br />
                                    <asp:Label ID="Label2" runat="server" Text="Fecha Publicacion: 10/07/2019" CssClass="text-info small"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="Scripts/jquery-3.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/bootstrap.min.js" type="text/javascript"></script>
</body>
</html>
