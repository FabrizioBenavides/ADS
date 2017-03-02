<%@ Page CodeBehind="VentasCortesEnCeroDetalleCaja.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsVentasCortesEnCeroDetalleCaja" %>
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
  document.forms[0].elements["txtZonaId"].value = "<%= intZonaId %>";
  document.forms[0].elements["txtCompaniaId"].value = "<%= intCompaniaId %>";
  document.forms[0].elements["txtSucursalId"].value = "<%= intSucursalId %>";
<%= strLlenarCajaComboBox() %>
}

function strDireccionOperativaNombre() {
  document.write("<%= strDireccionOperativaNombre %>");
}

function strZonaOperativaNombre() {
  document.write("<%= strZonaOperativaNombre() %>");
}

function strSucursalNombre() {
  document.write("<%= strSucursalNombre() %>");
}

function strRangoDeFechas() {
  document.write("<%= strRangoDeFechas %>");
}

function strCajaNombre() {
  document.write("<%= strCajaNombre %>");
}

function cmdBuscar_onclick() {
  if (document.forms[0].elements["cboCaja"].selectedIndex == 0) {
    alert("Por favor seleccione una caja.");
    document.forms[0].elements["cboCaja"].focus();
    return(false);
  }
  return(true);
}

function cmdImprimir_onclick() {
  window.print();
}

function cmdRegresar_onclick() {
  window.location.href = "<%= "VentasCortesEnCeroDetalleSucursal.aspx?strCmd=Consultar&intDireccionOperativaId=" & intDireccionId & "&intZonaOperativaId=" & intZonaId & "&intCompaniaId=" & intCompaniaId & "&intSucursalId=" & intSucursalId & "&txtFechaInicial=" & strFechaInicial & "&txtFechaFinal=" & strFechaFinal %>";
}

// done hiding -->
</script>
</head>
<body language=javascript onload="return window_onload()">
<form method="POST" action="about:blank" name="frmMain">
  <input type="hidden" name="txtFechaInicial">
  <input type="hidden" name="txtFechaFinal">
  <input type="hidden" name="txtDireccionId">
  <input type="hidden" name="txtZonaId">
  <input type="hidden" name="txtCompaniaId">
  <input type="hidden" name="txtSucursalId">
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Est&aacute; en : Ventas : Cierres : Consultar cortes en cero : Detalle caja </td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="tdgeneralcontent"><h1>Cortes en cero - Detalle caja</h1>
        <table width="60%"  border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="27%" class="tdtexttablebold">Direcci&oacute;n:</td>
            <td width="73%" class="tdcontentableblue"><script language="javascript">strDireccionOperativaNombre()</script></td>
          </tr>
          <tr>
            <td class="tdtexttablebold">Zona:</td>
            <td class="tdcontentableblue"><script language="javascript">strZonaOperativaNombre()</script></td>
          </tr>
          <tr>
            <td class="tdtexttablebold">Sucursal:</td>
            <td class="tdcontentableblue"><script language="javascript">strSucursalNombre()</script></td>
          </tr>
          <tr>
            <td class="tdtexttablebold">Rango:</td>
            <td class="tdcontentableblue"><script language="javascript">strRangoDeFechas()</script></td>
          </tr>
          <tr>
            <td class="tdtexttablebold">Caja: </td>
            <td class="tdcontentableblue"><script language="javascript">strCajaNombre()</script></td>
          </tr>
        </table>
        <br>
        <input name="cmdRegresar" type="button" class="button" id="cmdRegresar" value="Regresar" language=javascript onclick="return cmdRegresar_onclick()">
        <br>
        <%= strRecordBrowserHTML() %>
        <br>
<input name="cmdImprimir" type="button" class="button" id="cmdImprimir" value="Imprimir reporte" language=javascript onclick="return cmdImprimir_onclick()">
        <br>
        <br>
        <h2>Cortes en cero de otra caja </h2>
        <p>Para ver el reporte detallado de otra caja, seleccione la direci&oacute;n y oprima &quot;Actualizar reporte&quot; </p>
        <table width="60%"  border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="9%" class="tdtexttablebold">Caja: </td>
            <td width="91%" class="tdpadleft5"><select name="cboCaja" class="field">
                <option value="0">Elija una caja</option>
              </select>
            </td>
          </tr>
        </table>
        <br>
        <input name="cmdBuscar" type="submit" class="button" value="Actualizar reporte" language=javascript onclick="return cmdBuscar_onclick()"></td>
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
