<%@ Page CodeBehind="SucursalConsultarCajas.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSucursalConsultarCajas" codePage="1252" EnableSessionState="False" enableViewState="False" %>
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
<form method="POST" action="about:blank" name="frmSucursalConsultarCajas">
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
          <td width="80%" class="tdpadleft5"><select name="cboDireccion" class="field" onchange="cboDireccion_onchange();">
              <option value="0">Elija una direcci&oacute;n</option>
            </select>
          </td>
        </tr>
        <tr>
          <td class="tdtexttablebold">Zona:</td>
          <td class="tdpadleft5"><select name="cboZona" class="field" onchange="cboZona_onchange();">
              <option value="0">Elija una zona</option>
            </select></td>
        </tr>
      </table>
      <%= strRecordBrowserHTML() %>
      
    </td>
  </tr>
</table>
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><script language="JavaScript">crearTablaFooter()</script></td>
  </tr>
</table>
<script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	//-->
</script>
</body>
</html>
