<%@ Page CodeBehind="SistemaConsultarTransmisionesDetalleZona.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSistemaConsultarTransmisionesDetalleZona" codePage="1252" EnableSessionState="False" enableViewState="False"%>
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

function window_onload() {
  document.forms[0].action = "<%= strThisPageName %>";
  document.forms[0].elements["txtFechaInicial"].value = "<%= strFechaInicial %>";
  document.forms[0].elements["txtFechaFinal"].value = "<%= strFechaFinal %>";
  document.forms[0].elements["txtDireccionId"].value = "<%= intDireccionId %>";
<%= strLlenarCategoriaRegistroEventoComboBox() %>
<%= strLlenarZonaComboBox() %>
}

function strDireccionOperativaNombre() {
  document.write("<%= strDireccionOperativaNombre %>");
}

function strZonaOperativaNombre() {
  document.write("<%= strZonaOperativaNombre() %>");
}

function strCategoriaRegistroEventoNombre() {
  document.write("<%= strCategoriaRegistroEventoNombre %>");
}

function strRangoDeFechas() {
  document.write("<%= strRangoDeFechas %>");
}

function cmdBuscar_onclick() {
  if (document.forms[0].elements["cboCategoriaRegistroEvento"].selectedIndex == 0) {
    alert("Por favor seleccione un reporte.");
    document.forms[0].elements["cboCategoriaRegistroEvento"].focus();
    return(false);
  }
  if (document.forms[0].elements["cboZona"].selectedIndex == 0) {
    alert("Por favor seleccione una zona.");
    document.forms[0].elements["cboZona"].focus();
    return(false);
  }
  return(true);
}

function cmdImprimir_onclick() {
  window.print();
}

function cmdRegresar_onclick() {
  window.location.href = "<%= "SistemaConsultarTransmisionesDetalleDireccion.aspx?strCmd=Consultar&intDireccionOperativaId=" & intDireccionId & "&intCategoriaRegistroEventoId=" & intCategoriaRegistroEventoId & "&txtFechaInicial=" & strFechaInicial & "&txtFechaFinal=" & strFechaFinal %>";
}

// done hiding -->
</script>
</head>
<body language=javascript onload="return window_onload()">
<form method="POST" action="about:blank" name="frmMain">
  <input type="hidden" name="txtFechaInicial">
  <input type="hidden" name="txtFechaFinal">
  <input type="hidden" name="txtDireccionId">
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Est&aacute; en : Sistema : Trasmisiones : Consultar transmisiones : Detalle zona </td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="tdgeneralcontent"><h1>Consultar transmisiones - detalle zona </h1>
        <table width="60%"  border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="15%" class="tdtexttablebold">Direcci&oacute;n:</td>
            <td width="85%" class="tdcontentableblue"><script language="javascript">strDireccionOperativaNombre()</script></td>
          </tr>
          <tr>
            <td class="tdtexttablebold">Zona:</td>
            <td class="tdcontentableblue"><script language="javascript">strZonaOperativaNombre()</script></td>
          </tr>
          <tr>
            <td class="tdtexttablebold">Rango:</td>
            <td class="tdcontentableblue"><script language="javascript">strRangoDeFechas()</script></td>
          </tr>
        </table>
        <br>
        <input name="cmdRegresar" type="button" class="button" id="cmdRegresar" value="Regresar" language=javascript onclick="return cmdRegresar_onclick()">
        <br>
        <%= strRecordBrowserHTML() %><br>
        <input name="cmdImprimir" type="button" class="button" id="cmdImprimir" value="Imprimir reporte" language=javascript onclick="return cmdImprimir_onclick()">
        <br>
        <br>
        <h2>Reconfigurar reporte </h2>
        <p>Si quiere ver el reporte detallado de otra zona, seleccione la nueva zona y oprima &quot;Actualizar reporte&quot;. Si quiere ver otro reporte para esta zona, seleccione primero el nuevo reporte. </p>
        <table width="50%"  border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="17%" class="tdtexttablebold">Reporte:</td>
            <td width="83%" class="tdpadleft5"><select name="cboCategoriaRegistroEvento" id="cboCategoriaRegistroEvento" class="field">
                <option value="0">Elija una opci&oacute;n</option>
              </select>
            </td>
          </tr>
          <tr>
            <td class="tdtexttablebold">Zona:</td>
            <td class="tdpadleft5"><select name="cboZona" class="field" id="cboZona">
                <option value="0">Nombre zona</option selected>
              </select></td>
          </tr>
        </table>
        <br>
        <input name="cmdBuscar" type="submit" class="button" id="cmdBuscar" value="Actualizar reporte" language=javascript onclick="return cmdBuscar_onclick()">
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
