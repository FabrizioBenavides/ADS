<%@ Page CodeBehind="SucursalVerDetalleCaja.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSucursalVerDetalleCaja" codePage="1252" EnableSessionState="False" enableViewState="False" %>
<html>
<head>
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
<%= strLlenarCajaComboBox() %>
document.forms[0].elements["cboCaja"].options["<%= intCajaId %>"].selected = true;
}

function strSucursalNombre() {
  document.write("<%= strSucursalNombre() %>");
}

function strUbicacion() {
  document.write("<%= strUbicacion() %>");
}

function strEstado() {
  document.write("<%= strEstado() %>");
}

function strCajaNombre() {
  document.write("<%= strCajaNombre() %>");
}

function strCajaNombreId() {
  document.write("<%= strCajaNombreId() %>");
}

function strCajaRazonCambio() {
  document.write("<%= strCajaRazonCambio() %>");
}

function strCajaUltimaModificacion() {
  document.write("<%= strCajaUltimaModificacion() %>");
}

function strCajaDireccionIp() {
  document.write("<%= strCajaDireccionIp() %>");
}

function cmdRecuperarDatos_onclick() {
window.location= "SucursalVerDetalleCaja.aspx?strCmd=Ver&intCompaniaId=<%= intCompaniaId%>&intSucursalId=<%= intSucursalId%>&cboCaja="+document.forms[0].elements["cboCaja"].value;
}

function boton23232323_onclick() {
window.print();
}

//-->
</script>
</head>
<body onload="return window_onload()">
<form method="POST" action="about:blank" name="frmVentasAdministrarPoliticasDeTickets">
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><script language="JavaScript">crearTablaHeader()</script></td>
  </tr>
</table>
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="10">&nbsp;</td>
    <td width="770" class="tdtab">Est&aacute; en : Sucursal : Puntos de venta : Consultar cajas en sucursales : Ver detalle de cajas </td>
  </tr>
</table>
<table width="780" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdgeneralcontent"><h1>Ver detalle de cajas </h1>
      <p>La sucursal <script language="javascript">strSucursalNombre()</script> tiene <script language="javascript">  </script> cajas. Elija la caja cuyos datos quiere ver </p>
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
      <input name="cmdRecuperarDatos" type="button" class="button" value="Recuperar datos" onclick="return cmdRecuperarDatos_onclick()">
      <br>
      <br>
      <h2>Informaci&oacute;n de la caja </h2>
      <table width="60%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="28%" class="tdtexttablebold">Sucursal:</td>
          <td width="72%" class="tdcontentableblue"><script language="javascript">strSucursalNombre()</script></td>
        </tr>
        <tr>
          <td class="tdtexttablebold">Ubicaci&oacute;n:</td>
          <td class="tdcontentableblue"><script language="javascript">strUbicacion()</script></td>
        </tr>
        <tr>
          <td class="tdtexttablebold">Estado:</td>
          <td class="tdcontentableblue"><script language="javascript">strEstado()</script></td>
        </tr>
        <tr>
          <td class="tdtexttablebold">Nombre: </td>
          <td class="tdcontentableblue"><script language="javascript">strCajaNombre()</script></td>
        </tr>
        <tr>
          <td class="tdtexttablebold">Identificador: </td>
          <td class="tdcontentableblue"><script language="javascript">strCajaNombreId()</script></td>
        </tr>
        <tr>
          <td class="tdtexttablebold">Raz&oacute;n &uacute;ltimo cambio: </td>
          <td class="tdcontentableblue"><script language="javascript">strCajaRazonCambio()</script></td>
        </tr>
        <tr>
          <td class="tdtexttablebold">Fecha &uacute;ltimo cambio: </td>
          <td class="tdcontentableblue"><script language="javascript">strCajaUltimaModificacion()</script></td>
        </tr>
        <tr>
          <td class="tdtexttablebold">Direcci&oacute;n IP : </td>
          <td class="tdcontentableblue"><script language="javascript">strCajaDireccionIp()</script></td>
        </tr>
      </table>
  <br>
      <input name="boton23232323" type="button" class="button" value="Imprimir reporte" onclick="return boton23232323_onclick()">
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

