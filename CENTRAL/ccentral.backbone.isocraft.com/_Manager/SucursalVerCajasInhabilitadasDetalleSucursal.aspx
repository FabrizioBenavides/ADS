<%@ Page CodeBehind="SucursalVerCajasInhabilitadasDetalleSucursal.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSucursalVerCajasInhabilitadasDetalleSucursal" codePage="1252" EnableSessionState="False" enableViewState="False"%>
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
  document.forms[0].elements["txtZonaId"].value = "<%= intZonaId %>";
  document.forms[0].elements["txtCompaniaId"].value = "<%= intCompaniaId %>";
  document.forms[0].elements["txtSucursalId"].value = "<%= intSucursalId %>";
<%= strLlenarSucursalComboBox() %>
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

function intTotalPorSucursal() {
  document.write("<%= intTotalPorSucursal %>");
}

function cmdBuscar_onclick() {
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
  window.location.href = "<%= "SucursalVerCajasInhabilitadasDetalleZona.aspx?strCmd=Consultar&intDireccionOperativaId=" & intDireccionId & "&intZonaOperativaId=" & intZonaId & "&txtFechaInicial=" & strFechaInicial & "&txtFechaFinal=" & strFechaFinal %>";
}

function cmdBuscar_onclick() {
  if (document.forms[0].elements["cboSucursal"].selectedIndex == 0) {
    alert("Por favor seleccione una sucursal.");
    document.forms[0].elements["cboSucursal"].focus();
    return(false);
  }
  return(true);
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
      <td width="770" class="tdtab">Est&aacute; en : <a href="Sucursal.htm">Sucursal</a> : Puntos de venta : Consultar cajas inhabilitadas  : Ver cajas inhabilitadas - Detalle sucursal </td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="tdgeneralcontent"><h1>Ver cajas inhabilitadas - Detalle sucursal </h1>
        <h2>Cajas inhabilitadas</h2>
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
            <td class="tdtexttablebold">Cajas inhabilitadas: </td>
            <td class="tdcontentableblue"><script language="javascript">intTotalPorSucursal()</script></td>
          </tr>
        </table>
        <br>
        <input name="cmdRegresar" type="button" class="button" id="cmdRegresar" value="Regresar" language=javascript onclick="return cmdRegresar_onclick()">
        <br>
        <br>
        <%= strPrintPOSDetails() %>
        <input name="cmdImprimir" type="button" class="button" id="cmdImprimir" value="Imprimir reporte" language=javascript onclick="return cmdImprimir_onclick()">
        <br>
        <br>
        <h2>Cajas inhabilitadas de otra sucursal</h2>
        <br>
        <p>Para ver el reporte detalle de otra sucursal, seleccione la sucursal y oprima &quot;Actualizar reporte&quot; </p>
        <table width="60%"  border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="14%" class="tdtexttablebold">Sucursal: </td>
            <td width="86%" class="tdpadleft5"><select name="cboSucursal" id="cboSucursal" class="field">
                <option value="0|0">Nombre sucursal</option selected>
              </select>
            </td>
          </tr>
        </table>
        <br>
        <input name="cmdBuscar" type="submit" class="button" value="Actualizar reporte" language=javascript onclick="return cmdBuscar_onclick()">
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
