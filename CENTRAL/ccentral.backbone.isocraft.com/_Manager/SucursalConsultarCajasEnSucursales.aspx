<%@ Page CodeBehind="SucursalConsultarCajasEnSucursales.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSucursalConsultarCajasEnSucursales" %>
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
<%= strJavascriptWindowOnLoadCommands %>
<%= strLlenarDireccionComboBox() %>
<%= strLlenarZonaComboBox() %>
  if (document.forms[0].elements["cmdImportar"] != null) {
    if (document.forms[0].elements["cboZona"].selectedIndex > 0) {
      document.forms[0].elements["cmdImportar"].disabled = false;
    } else {
      document.forms[0].elements["cmdImportar"].disabled = true;
    }
  }
}

function cmdImportar_onclick() {
  window.location.href = "SucursalAsignarCuentasEnLote.aspx?intDestinoDireccionId=" + document.forms[0].elements["cboDireccion"].options[document.forms[0].elements["cboDireccion"].selectedIndex].value + "&intDestinoZonaId=" + document.forms[0].elements["cboZona"].options[document.forms[0].elements["cboZona"].selectedIndex].value;
}

function cboDireccion_onchange() {
  document.forms[0].submit();
  return(true);
}

function cboZona_onchange() {
  if (document.forms[0].elements["cmdImportar"] != null) {
    if (document.forms[0].elements["cboZona"].selectedIndex > 0) {
      document.forms[0].elements["cmdImportar"].disabled = false;
    } else {
      document.forms[0].elements["cmdImportar"].disabled = true;
    }
  }
  document.forms[0].submit();
  return(true);
}

//-->
</script>
</head>
<body onload="return window_onload()">
<form method="POST" action="about:blank" name="frmMain">
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><script language="JavaScript">crearTablaHeader()</script></td>
  </tr>
</table>
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="10">&nbsp;</td>
    <td width="770" class="tdtab">Est&aacute; en : Sucursal : Puntos de venta : Consultar cajas en sucursales </td>
  </tr>
</table>
<table width="780" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdgeneralcontent"><h1>Consultar cajas en sucursales </h1>
      <h2>Configurar consulta de sucursales </h2>
      <table width="50%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="20%" class="tdtexttablebold">Direcci&oacute;n:</td>
          <td width="80%" class="tdpadleft5"><select name="cboDireccion" id="cboDireccion" class="field" onchange="return cboDireccion_onchange()">
              <option value="0">Elija una direcci&oacute;n</option selected>
            </select>
          </td>
        </tr>
        <tr>
          <td class="tdtexttablebold">Zona:</td>
          <td class="tdpadleft5"><select name="cboZona" id="cboZona" class="field" onchange="return cboZona_onchange()">
              <option value="0">Elija una zona</option selected>
            </select></td>
        </tr>
      </table>
      <%= strRecordBrowserHTML() %>
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
