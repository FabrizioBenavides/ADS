<%@ Page CodeBehind="SistemaTransmisionesPendientesDetalleSucursal.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSistemaTransmisionesPendientesDetalleSucursal" %>
<html>
<head>
<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<meta name="description" content="Javascript Menu">
<meta name="keywords" content="JavaScript menu, javascript, html, client side, netscape, explorer, IE, menu, DHTML, DOM, control">
<link href="css/menu.css" rel="stylesheet" type="text/css">
<link href="css/estilo.css" rel="stylesheet" type="text/css">
<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<script language="JavaScript" type="text/JavaScript">
<!-- hide from JavaScript-challenged browsers

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
  document.forms[0].action = "SistemaTransmisionesPendientesDetalleSucursal.aspx";
  <%= strJavascriptWindowOnLoadCommands %>
}

function strEncabezadoHTML() {
	document.write("<%= strEncabezadoHTML %>");
}

function strRecordBrowserHTML() {
	document.write("<%= strRecordBrowserHTML %>");
}

function cmdRetrasmitir_onClick() {
	theForm = document.forms[0];
	theForm.cboReporteId.value = <%= intReporteId %>;
	theForm.action += "?strCmd=RetransmitirTodo";
	theForm.submit();
	return true;
}

function cmdRegresar_onclick() {
  window.location.href = "SistemaTransmisionesPendientesDetalleZona.aspx?strCmd=Detalle&intReporteId=<%= intReporteId %>&intDireccionOperativaId=<%= intDireccionOperativaId %>";
}

// done hiding -->
</script>
</head>
<body language="javascript" onload="return window_onload()">
<form method="post" action="about:blank" name="frmMain" onSubmit="return blnFormValidator(this)">
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><script language="JavaScript">crearTablaHeader()</script></td>
  </tr>
</table>
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="10">&nbsp;</td>
    <td width="770" class="tdtab">Est&aacute; en : <a href="Sistema.htm">Sistema</a> : <a href="Transmisiones.htm">Trasmisiones</a> : <a href="ConsultarTransmisionesPendientes.htm">Consultar transmisiones pendientes</a> : Detalle sucursal </td>
  </tr>
</table>
<table width="780" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdgeneralcontent"><h1>Consultar transmisiones pendientes - Detalle sucursal </h1>
    <script language="javascript">strEncabezadoHTML();</script>
      <br>
      <input name="cmdRegresar" type="button" class="button" id="cmdRegresar" value="Regresar" language=javascript onclick="return cmdRegresar_onclick()">
      <br>
	  <script language="javascript">strRecordBrowserHTML();</script>
      <br>
      <input name="btnImprimir" type="button" class="button" value="Imprimir reporte" onclick="window.print();">
      <br>
      <br>
<!--      <br>
      <h2>Reconfigurar reporte </h2>
      <p>Si quiere ver el reporte detallado de otra zona, seleccione la nueva zona y oprima &quot;Actualizar reporte&quot;. Si quiere ver otro reporte para esta zona, seleccione primero el nuevo reporte. </p>
      <table width="50%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="17%" class="tdtexttablebold">Reporte:</td>
          <td width="83%" class="tdpadleft5"><select name="cboReporteId" id="cboReporteId" class="field">
			<option value="0" selected>Elija una opci&oacute;n</option>
			<option value="1" >P&oacute;lizas no transmitidas</option>
			<option value="2" >Ventas no transmitidas</option>
			<option value="3" >Tickets no transmitidos</option>
			</select>
		  </td>
        </tr>
        <tr>
          <td class="tdtexttablebold">Zona</td>
          <td class="tdpadleft5"><select name="cboZona" id="cboZona" class="field">
            </select></td>
        </tr>
      </table>
      <br>
      <input name="btncConsultar" type="button" class="button" value="Actualizar reporte" onclick="javascript: return cmdConsultar_onClick();">
      <br>
-->      
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
</form>
</body>
</html>