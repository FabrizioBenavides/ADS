<%@ Page CodeBehind="SistemaAsignarMonedas.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSistemaAsignarMonedas" Explicit="True" Trace="False" Strict="True" codePage="1252" EnableSessionState="False" enableViewState="False"%>
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
<script language="JavaScript" type="text/JavaScript" src="js/tools.js"></script>
<script id=clientEventHandlersJS language=javascript>

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
  document.forms[0].action = "<%= strThisPageName %>";
<%= strJavascriptWindowOnLoadCommands %>
<%= strLlenarDireccionComboBox() %>
<%= strLlenarZonaComboBox() %>
<%= strLlenarSucursalComboBox() %>
  if (document.forms[0].elements["cboSucursal"].selectedIndex == 0) {
    document.forms[0].elements["cmdNavegadorRegistrosAgregar"].disabled = true;
  }
}

function cboDireccion_onchange() {
  document.forms[0].elements["cboZona"].selectedIndex = 0;
  document.forms[0].elements["cboSucursal"].selectedIndex = 0;
  document.forms[0].submit();
  return(true);
}

function cboZona_onchange() {
  document.forms[0].elements["cboSucursal"].selectedIndex = 0;
  document.forms[0].submit();
  return(true);
}

function cboSucursal_onchange() {
  document.forms[0].submit();
}

function cmdNavegadorRegistrosAgregar_onclick(intDireccionId, intZonaId, intCompaniaId, intSucursalId) {
  return Pop("popSucursalElegirMonedas.aspx?intDireccionId=" + intDireccionId + "&intZonaId=" + intZonaId + "&intCompaniaId=" + intCompaniaId + "&intSucursalId=" + intSucursalId, "360", "440")
}

</script>
</head>
<body onload="return window_onload()">
<form method="POST" action="about:blank" name="frmSistemaAsignarMoneda">
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><script language="JavaScript">crearTablaHeader()</script></td>
  </tr>
</table>
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="10">&nbsp;</td>
    <td width="770" class="tdtab">Est&aacute; en : Sistema : Asignar monedas a sucursal </td>
  </tr>
</table>
<table width="780" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdgeneralcontent"><h1>Asignar monedas a sucursal</h1>
      <h2>Definir sucursal blanco de la asignaci&oacute;n</h2>
      <table width="50%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="20%" class="tdtexttablebold">* Direcci&oacute;n:</td>
          <td width="80%" class="tdpadleft5"><select name="cboDireccion" class="field" id="cboDireccion" onchange="return cboDireccion_onchange()">
              <option value="0">Elija una direcci&oacute;n</option>
            </select>
          </td>
        </tr>
        <tr>
          <td class="tdtexttablebold">* Zona:</td>
          <td class="tdpadleft5"><select name="cboZona" class="field" id="cboZona" onchange="return cboZona_onchange()">
              <option value="0">Elija una zona</option>
            </select></td>
        </tr>
        <tr>
          <td class="tdtexttablebold">* Sucursal:</td>
          <td class="tdpadleft5"><select name="cboSucursal" class="field" id="cboSucursal" onchange="return cboSucursal_onchange()">
              <option value="0|0">Elija una sucursal</option>
            </select></td>
        </tr>
      </table>
      <%= strObtenerHTMLNavegadorDeRegistros() %>
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
