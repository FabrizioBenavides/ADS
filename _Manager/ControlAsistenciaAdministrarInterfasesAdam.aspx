<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ControlAsistenciaAdministrarInterfasesAdam.aspx.vb" Inherits="com.isocraft.backbone.ccentral.ControlAsistenciaAdministrarInterfasesAdam" EnableSessionState="true" EnableViewState="true"  %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Benavides : Administrar Interfaces Adam</title>
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
        }

        new menu(MENU_ITEMS, MENU_POS);
    </script>
</head>
<body onload="return window_onload()">
    <form id="frmPrincipal" runat="server">
        <table width="780" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <script type="text/javascript">crearTablaHeader()</script>
                </td>
            </tr>
        </table>
        <table width="780" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="10">&nbsp;</td>
                <td width="770" class="tdtab">Est&aacute; en : 
                    <a href="../_Manager/SucursalHome.aspx">Sucursal</a> : 
                    Control de Asistencias
                    : Administrar Interfaces Adam
                </td>
            </tr>
        </table>
        <table width="780" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td class="tdgeneralcontent">
                    <h1>Administrar Interfaces Adam</h1>
                    <h2>Agregar calendario de nómina</h2>
                    <table>
                        <tr>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold">Archivo:</td>
                            <td>
                                <input name="txtArchivo" id="txtArchivo" type="file" class="field" size="55" maxlength="55" runat="server"  />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <input name="btnAgregarArchivo" type="submit" class="button" runat="server"
                                    id="btnAgregarArchivo" value="Agregar" onserverclick="btnAgregarArchivo_ServerClick" />
                            </td>
                        </tr>
                        <tr style="height:50px;">

                        </tr>
                        <tr>
                             <td colspan="2"><%= strObtenerCalendarioNomina()%> </td>
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