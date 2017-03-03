<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SistemaAdministrarClienteOtrasIdentificaciones.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SistemaAdministrarClienteOtrasIdentificaciones" CodePage="28592" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">

<html>
<head>
    <title>Benavides : Consulta Cliente Otras Identificaciones</title>
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="css/menu.css" rel="stylesheet" type="text/css" />
    <link href="css/estilo.css" rel="stylesheet" type="text/css" />
    <script type="text/JavaScript" src="js/menu.js"></script>
    <script type="text/JavaScript" src="js/menu_items.js"></script>
    <script type="text/JavaScript" src="js/menu_tpl.js"></script>
    <script type="text/JavaScript" src="js/headerfooter.js"></script>
    <script type="text/javascript">

        strUsuarioNombre = "<%= strUsuarioNombre %>";
        strFechaHora = "<%= strHTMLFechaHora %>";

        function window_onload() {
            <%= strJavascriptWindowOnLoadCommands %>;
        }

        new menu(MENU_ITEMS, MENU_POS);
    </script>
</head>
<body onload="return window_onload()">
    <form id="frmPrincipal" action="about:blank" method="post">
        <table cellspacing="0" cellpadding="0" width="780" border="0">
            <tr>
                <td>
                    <script language="JavaScript">crearTablaHeader()</script>
                </td>
            </tr>
        </table>
        <table width="780" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="10">&nbsp;</td>
                <td width="780" class="tdtab">Est&aacute; en : 
                    <a href="../_Manager/.aspx">Sistema</a> : Consulta Cliente Otras Identificaciones
                </td>
            </tr>
        </table>
        <table width="780" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td class="tdgeneralcontent">
                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                        <tr>
                            <td>
                                <h1>Consulta Cliente Otras Identificaciones</h1>
                                <p>
                                    En esta parte se puede consultar
                                </p>
                                <h2>Criterio de Busqueda</h2>
                            </td>
                        </tr>
                    </table>
                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                        <tr>
                            <td class="tdTituloAzul" valign="top" width="25%">Sucursales</td>
                            <td>&nbsp;&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" valign="top">
                                <input type="radio" value="0" name="optArticulo">Todos
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" valign="top">
                                <input type="radio" value="1" name="optArticulo">Sin Sucursales Asignadas
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" valign="top">
                                <input type="radio" value="2" name="optArticulo">Con Sucursales Asignadas
                            </td>
                        </tr>
                    </table>
                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                        <tr>
                            <td class="tdtexttablebold" width="15%">Cliente ABF:</td>
                            <td class="tdpadleft5" valign="top">
                                <input class="field" id="txtClienteAbf" type="text" autocomplete="off" maxlength="20" size="40">
                            </td>
                        </tr>
                    </table>
                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                        <tr>
                            <td>
                                <input class="boton" id="btnConsultar" type="button" value="Consultar" name="btnConsultar"
							        onclick="return btnConsultar_onclick()"> 
                                <input class="boton" id="btnAgregar" type="button" value="Agregar" name="btnAgregar"
							        onclick="return btnAgregar_onclick()">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%= strConsultarClientes%>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table width="780" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <script type="text/javascript">crearTablaFooterCentral()</script>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
