<%@ Page CodeBehind="SucursalVerCuentaAsignada.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSucursalVerCuentaAsignada" codePage="1252" EnableSessionState="False" enableViewState="False"%>
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
  document.forms[0].elements["txtDireccionId"].value="<%= intDireccionId %>";
  document.forms[0].elements["txtZonaId"].value="<%= intZonaId %>";
  document.forms[0].elements["txtCompaniaId"].value="<%= intCompaniaId %>";
  document.forms[0].elements["txtSucursalId"].value="<%= intSucursalId %>";
  <%= strJavascriptWindowOnLoadCommands %>
  <%= strLlenarTipoCuentaComboBox() %>  
}

function cboTipoCuenta_onchange(){
    document.forms[0].submit();
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
  
function cmdNavegadorRegistrosAgregar_onclick(intDireccionId, intZonaId, intCompaniaId, intSucursalId){
    window.location = "SucursalAsignarCuentasEnLote.aspx?intDestinoDireccionId=" + intDireccionId + "&intDestinoZonaId=" + intZonaId;
}

function cmdImprimir_OnClick(){
    window.print(); 
}

//-->
</script>
</head>
<body onload="return window_onload()">
<form method="POST" action="about:blank" name="frmSucursalVerCuentaAsignada">
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
    <td width="770" class="tdtab">Est&aacute; en : Sucursal : Asignar cuentas a sucursales : Ver cuentas asignadas </td>
  </tr>
</table>
<table width="780" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdgeneralcontent"><h1>Ver cuentas asignadas </h1>
      <p>En esta parte del sistema usted administrar&aacute; las cuentas (pseudocuentas, contables, bancarias) que maneja el sistema. </p>
      <table width="60%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="29%" class="tdtexttablebold">Direcci&oacute;n: </td>
          <td width="71%" class="tdcontentableblue"><script language="javascript">strDireccionOperativaNombre()</script></td>
        </tr>
        <tr>
          <td class="tdtexttablebold">Zona: </td>
          <td class="tdcontentableblue"><script language="javascript">strZonaOperativaNombre()</script></td>
        </tr>
        <tr>
          <td class="tdtexttablebold">Sucursal</td>
          <td class="tdcontentableblue"><script language="javascript">strSucursalNombre()</script></td>
        </tr>
        <tr>
          <td class="tdtexttablebold">Tipo de cuenta a ver: </td>
          <td class="tdpadleft5"><select name="cboTipoCuenta" class="field" onchange="cboTipoCuenta_onchange();">
              <option value="0">Elija un tipo de cuenta</option>
            </select>
          </td>
        </tr>
      </table>
      <br>
      <br>
      <!-- AQUI VA EL RECORD BROWSER -->
      <%= strRecordBrowserHTML() %>
      <br>
      <input name="cmdImprimir" type="button" class="button" value="Imprimir cuentas" onclick="cmdImprimir_OnClick();"></td>
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

