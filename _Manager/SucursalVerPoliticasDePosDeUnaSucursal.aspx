<%@ Page CodeBehind="SucursalVerPoliticasDePosDeUnaSucursal.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSucursalVerPoliticasDePosDeUnaSucursal" codePage="1252" EnableSessionState="False" enableViewState="False"%>
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

function strDireccionOperativaNombre() {
  document.write("<%= strDireccionOperativaNombre %>");
}

function strZonaOperativaNombre() {
  document.write("<%= strZonaOperativaNombre() %>");
}

function strSucursalNombre() {
  document.write("<%= strSucursalNombre() %>");
}

function cmdRegresar_onclick() {
  window.location.href = "SucursalAdministrarPoliticasDePOS.aspx?intDireccionId=<%= intDireccionId %>&intZonaId=<%= intZonaId %>";
}

function window_onload() {
  document.forms[0].action = "<%= strThisPageName & "?intDireccionId=" & intDireccionId & "&intZonaId=" & intZonaId & "&intCompaniaId=" & intCompaniaId & "&intSucursalId=" & intSucursalId %>";
<%= strLlenarPoliticasComboBox() %>
<%= strLlenarCajaComboBox() %>
  if (document.forms[0].elements["cboPoliticas"].length == 1 || document.forms[0].elements["cboCaja"].length == 1) {
  document.forms[0].elements["cmdNavegadorRegistrosAgregar"].disabled = true;
  }
}

function cboPoliticas_onchange() {
  document.forms[0].submit();
}

function cboCaja_onchange() {
  document.forms[0].submit();
}

function cmdPrint_onclick() {
  window.print();
}

-->
</script>
</head>
<body language=javascript onload="return window_onload()">
<form method="POST" action="about:blank" name="frmMain">
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><script language="JavaScript">crearTablaHeader()</script></td>
  </tr>
</table>
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="10">&nbsp;</td>
    <td width="770" class="tdtab">Est&aacute; en : Sucursal : Puntos de venta  : Ver pol&iacute;ticas de POS de una sucursal </td>
  </tr>
</table>
<table width="780" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdgeneralcontent"><h1>Ver pol&iacute;ticas de POS de una sucursal </h1>
      <table width="60%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="16%" class="tdtexttablebold">Direcci&oacute;n: </td>
          <td width="84%" class="tdcontentableblue"><script language="javascript">strDireccionOperativaNombre()</script></td>
        </tr>
        <tr>
          <td class="tdtexttablebold">Zona: </td>
          <td class="tdcontentableblue"><script language="javascript">strZonaOperativaNombre()</script></td>
        </tr>
        <tr>
          <td class="tdtexttablebold">Sucursal:</td>
          <td class="tdcontentableblue"><script language="javascript">strSucursalNombre()</script></td>
        </tr>
      </table>
      <br>
      <input name="cmdRegresar" type="button" class="button" id="cmdRegresar" value="Regresar" onClick="return cmdRegresar_onclick()">
      <br>
      <br>
      <h2>Elecci&oacute;n de pol&iacute;ticas de POS asignadas a la sucursal elegida </h2>
      <table width="60%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="29%" class="tdtexttablebold">Pol&iacute;ticas a desplegar : </td>
          <td width="71%" class="tdpadleft5"><select name="cboPoliticas" class="field" id="cboPoliticas" language=javascript onchange="return cboPoliticas_onchange()">
              <option value="0">Todas las pol&iacute;ticas</option selected>
            </select></td>
        </tr>
        <tr>
          <td class="tdtexttablebold">&iquest;De cu&aacute;l caja?</td>
          <td class="tdpadleft5"><select name="cboCaja" class="field" id="cboCaja" language=javascript onchange="return cboCaja_onchange()">
              <option value="0">Todas las cajas</option selected>
            </select></td>
        </tr>
      </table>
      <%= strRecordBrowserHTML() %>
      <br>
      <input name="cmdPrint" type="button" class="button" value="Imprimir pol&iacute;ticas" language=javascript onclick="return cmdPrint_onclick()"></td>
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
