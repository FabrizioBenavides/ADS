<%@ Page CodeBehind="SistemaTransmisionesPendientesDetalleDireccion.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSistemaTransmisionesPendientesDetalleDireccion" codePage="1252" EnableSessionState="False" enableViewState="False"%>
<html>
<head>
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
	
function window_onLoad(){
	document.forms[0].action = "<%= strThisPageName %>";
	<%= strLlenarDireccionComboBox() %>
	document.forms[0].elements['cboReporteId'].value = <%= intReporteId %>;
}

function strEncabezadoHTML() {
	document.write("<%= strEncabezadoHTML %>");
}

function cmdConsultar_onClick() {

	theForm = document.forms[0];
	
	if (theForm.cboReporteId.value == 0) {
		alert("Favor de seleccionar un tipo de reporte");
		theForm.cboReporteId.focus();
		return false;
	}
	
	if (theForm.cboDireccion.value == 0) {
		alert("Favor de seleccionar una dirección");
		theForm.cboDireccion.focus();
		return false;
	}
	
	theForm.action += "?strCmd=Detalle";
	theForm.submit();
	return true;
}

function cmdRegresar_onclick() {
  window.location.href = "SistemaTransmisionesPendientesDetalleRed.aspx?strCmd=Detalle&intReporteId=<%= intReporteId %>";
}

// done hiding -->
</script>
</head>
<body language=javascript onload="window_onLoad()">
<form method="POST" action="about:blank" name="frmMain">
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Est&aacute; en : Sistema : Trasmisiones : Consultar transmisiones pendientes : Detalle direcci&oacute;n </td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="tdgeneralcontent"><h1>Consultar transmisiones pendientes - Detalle direcci&oacute;n </h1>
        <script language="javascript">strEncabezadoHTML();</script>
        <br>
        <input name="cmdRegresar" type="button" class="button" id="cmdRegresar" value="Regresar" language=javascript onclick="return cmdRegresar_onclick()">
        <br>
        <%= strRecordBrowserHTML() %>
        <br>
        <input name="btnImprimir" type="button" class="button" value="Imprimir reporte" onclick="window.print();">
        <br>
        <br>
        <br>
        <h2>Reconfigurar reporte </h2>
        <p>Si quiere ver el reporte detallado de otra direcci&oacute;n, seleccione la nueva direcci&oacute;n y oprima &quot;Actualizar reporte&quot;. Si quiere ver otro reporte para esta direcci&oacute;n, seleccione primero el nuevo reporte. </p>
        <table width="50%"  border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="17%" class="tdtexttablebold">Reporte:</td>
            <td width="83%" class="tdpadleft5"><select name="cboReporteId" class="field" id="cboReporteId">
                <option selected value="0">Elija una opci&oacute;n</option>
                <option value="1">P&oacute;lizas no transmitidas</option>
                <option value="2">Ventas no transmitidas</option>
                <option value="3">Tickets no transmitidos</option>
              </select>
            </td>
          </tr>
          <tr>
            <td class="tdtexttablebold">Direcci&oacute;n</td>
            <td class="tdpadleft5"><select name="cboDireccion" class="field" id="cboDireccion">
              </select>
            </td>
          </tr>
        </table>
        <br>
        <input name="cmdConsultar" type="button" class="button" value="Actualizar reporte" onclick="return cmdConsultar_onClick();">
        <br>
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
