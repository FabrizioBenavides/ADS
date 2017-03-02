<%@ Page CodeBehind="SistemaActualizacionesPendientesDetalleDireccion.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSistemaActualizacionesPendientesDetalleDireccion" codePage="1252" EnableSessionState="False" enableViewState="False"%>
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
<%= strLlenarDireccionComboBox() %>
}

function strDireccionOperativaNombre() {
  document.write("<%= strDireccionOperativaNombre %>");
}

function cmdBuscar_onclick() {
  if (document.forms[0].elements["cboDireccion"].selectedIndex == 0) {
    alert("Por favor seleccione una dirección.");
    document.forms[0].elements["cboDireccion"].focus();
    return(false);
  }
  return(true);
}

function cmdImprimir_onclick() {
  window.print();
}

function cmdRegresar_onclick() {
  window.location.href = "SistemaConsultarActualizacionesPendientes.aspx";
}

// done hiding -->
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
      <td width="770" class="tdtab">Est&aacute; en : Sistema : Trasmisiones : Consultar actualizaciones pendientes : Detalle direcci&oacute;n </td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="tdgeneralcontent"><h1>Actualizaciones pendientes - Detalle direcci&oacute;n </h1>
        <h2>Puntos de venta que no recibieron actualizaciones </h2>
        <table width="60%"  border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="13%" class="tdtexttablebold">Alcance:</td>
            <td width="87%" class="tdcontentableblue"><script language="javascript">strDireccionOperativaNombre()</script></td>
          </tr>
          <tr>
            <td class="tdtexttablebold">Reporte:</td>
            <td class="tdcontentableblue">Lista de precios y ofertas </td>
          </tr>
          <tr>
            <td class="tdtexttablebold">Total:</td>
            <td class="tdcontentableblue"><span id="intTotalElementos">&nbsp;</span>
              actualizaciones </td>
          </tr>
        </table>
        <br>
        <input name="cmdRegresar" type="button" class="button" id="cmdRegresar" value="Regresar" language=javascript onclick="return cmdRegresar_onclick()">
        <br>
        <%= strRecordBrowserHTML() %> <br>
        <input name="cmdImprimir" type="button" class="button" id="cmdImprimir" value="Imprimir reporte" language=javascript onclick="return cmdImprimir_onclick()">
        <br>
        <br>
        <h2>Reconfigurar reporte</h2>
        <table width="50%"  border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="23%" class="tdtexttablebold">Direcci&oacute;n:</td>
            <td width="77%" class="tdpadleft5"><select name="cboDireccion" class="field" id="cboDireccion">
                <option value="0">Nombre direcci&oacute;n</option>
              </select>
            </td>
          </tr>
        </table>
        <br>
        <input name="cmdBuscar" type="submit" class="button" id="cmdBuscar" value="Actualizar reporte" language=javascript onclick="return cmdBuscar_onclick()">
        <br>
        <br>
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
