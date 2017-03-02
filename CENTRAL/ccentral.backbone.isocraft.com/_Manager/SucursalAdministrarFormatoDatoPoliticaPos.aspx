<%@ Page CodeBehind="SucursalAdministrarFormatoDatoPoliticaPos.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSucursalAdministrarFormatoDatoPoliticaPos" Explicit="True" Trace="False" Strict="True" codePage="1252" EnableSessionState="False" enableViewState="False"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<link href="css/menu.css" rel="stylesheet" type="text/css">
<link href="css/estilo.css" rel="stylesheet" type="text/css">
<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
<script id=clientEventHandlersJS language=javascript>
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
	document.forms[0].action = "<%= strThisPageName %>";
	<%= strJavascriptWindowOnLoadCommands %>

	var strCmmnd = "<%=strCmd%>";
	var intFlagBorrado = <%=intFlagBorrado%>;

	if (strCmmnd == "Borrar") {
		if (intFlagBorrado == 0) {
			alert("El formato seleccionado está siendo usado por una política\r\nde POS aplicada en por lo menos un punto de venta, por lo\r\nque no puede ser borrado. Si desea borrarlo, tiene que\r\nasignar a esos puntos de venta políticas de POS que usen\r\notros formatos de datos.");
		} else {
			if (intFlagBorrado == 1){
				alert("El formato fue eliminado exitosamente.");
			} else {
				alert("Ocurrió un error al eliminar el formato.");
			}
		}
	}
}


//-->
</script>
</head>
<body onload="return window_onload()">
<form method="POST" action="about:blank" name="frmSucursalAdministrarFormatoDatoPoliticaPos">
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Est&aacute; en : Sucursal: Puntos de venta : Administrar formatos de datos de políticas POS</td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="tdgeneralcontent"><h1>Administrar formatos de datos de pol&iacute;ticas de POS </h1>
        
        <%= strRecordBrowserHTML() %> </td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaFooterCentral()</script></td>
    </tr>
  </table>
  <script language="JavaScript">
<!--
new menu (MENU_ITEMS, MENU_POS);
//-->
</script>
</form>
</body>
</html>
