<%@ Page CodeBehind="SistemaConsultarActualizacionesPendientes.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSistemaConsultarActualizacionesPendientes" codePage="1252" EnableSessionState="False" enableViewState="False"%>
<html>
<head>
<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
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

function cmdImprimir_onclick() {
  window.print();
}

// done hiding -->
</script>
</head>
<body>
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><script language="JavaScript">crearTablaHeader()</script></td>
  </tr>
</table>
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="10">&nbsp;</td>
    <td width="770" class="tdtab">Est&aacute; en : Sistema : Trasmisiones : Consultar actualizaciones pendientes</td>
  </tr>
</table>
<table width="780" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdgeneralcontent"><h1>Consultar actualizaciones pendientes </h1>
      <h2>Puntos de venta que no recibieron actualizaciones </h2>
      <table width="60%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="13%" class="tdtexttablebold">Alcance:</td>
          <td width="87%" class="tdcontentableblue">Toda la red </td>
        </tr>
        <tr>
          <td class="tdtexttablebold">Reporte:</td>
          <td class="tdcontentableblue">Lista de precios y ofertas </td>
        </tr>
      </table>
      <%= strRecordBrowserHTML() %>
      <br>
      <br>      <input name="cmdImprimir" type="button" class="button" id="cmdImprimir" value="Imprimir reporte" onclick="return cmdImprimir_onclick()">
    </td>
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
</body>
</html>
