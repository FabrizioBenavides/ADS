<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SucursalAdministrarTESMedicamentos.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalAdministrarTESMedicamentos" CodePage="1252" EnableSessionState="False" EnableViewState="False" %>

<html>
<head>
    <title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
    <link href="css/menu.css" rel="stylesheet" type="text/css">
    <link href="css/estilo.css" rel="stylesheet" type="text/css">
    <script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
    <script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
    <script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
    <script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>

    <script id="clientEventHandlersJS" language="javascript">

        strUsuarioNombre = "<%= strUsuarioNombre %>";
        strFechaHora = "<%= strHTMLFechaHora %>";

        function window_onload() {

        }

        new menu(MENU_ITEMS, MENU_POS);
    </script>
</head>
<body onload="return window_onload()">
    <form method="POST" action="about:blank" id="form1">
        <table width="780" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <script language="JavaScript">crearTablaHeader()</script>
                </td>
            </tr>
        </table>
        <table width="780" border="0" cellspacing="0" cellpadding="0">
            <tr> 
              <td width="10">&nbsp;</td>
              <td width="770" class="tdtab">Est&aacute; en : <a href="../_Manager/SucursalHome.aspx">Sucursal</a> 
                : Mercancía : TES para Controlados </td>
            </tr>
        </table>
        <table width="780" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <script language="JavaScript">crearTablaFooterCentral()</script>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>