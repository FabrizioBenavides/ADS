<%@ Page CodeBehind="SucursalVerDetalleDeCajas.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSucursalVerDetalleDeCajas" codePage="1252" EnableSessionState="False" enableViewState="False" %>
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

function strTipoCaja() {
  document.write("<%= strTipoCajaNombre() %>");
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
  if (document.forms[0].elements["cboCaja"].value == 0){
    alert("Seleccione un caja")}    
  else{
    window.location= "SucursalVerDetalleDeCajas.aspx?strCmd=Ver&intCompaniaId=<%= intCompaniaId%>&intSucursalId=<%= intSucursalId%>&cboCaja="+document.forms[0].elements["cboCaja"].value;}
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
      <p>La sucursal <script language="javascript">strSucursalNombre()</script> tiene <script language="javascript"> document.write("<%= intTotalCajas()%>"); </script> cajas. Elija la caja cuyos datos quiere ver </p>
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
      <%= strHTML()%>
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

