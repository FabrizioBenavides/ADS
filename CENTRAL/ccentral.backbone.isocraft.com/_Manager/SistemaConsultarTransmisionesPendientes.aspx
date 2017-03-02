<%@ Page CodeBehind="SistemaConsultarTransmisionesPendientes.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSistemaConsultarTransmisionesPendientes" EnableSessionState="False" enableViewState="False"%>
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

function cmdBuscar_onclick() {
  	document.forms[0].action += "?strCmd=Consultar";
	return(true);
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
      <td width="770" class="tdtab">Est&aacute; en : Sistema : Trasmisiones : Consultar transmisiones pendientes </td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="tdgeneralcontent"><h1>Consultar transmisiones pendientes </h1>
        <%= strRecordBrowserHTML() %> <br>
        <input name="btnImpimir" type="button" class="button" value="Imprimir reporte" onclick="window.print()">
        <br>
        <br>
		<br>
        <h2>Reconfigurar reporte</h2>
        <p>Si quiere ver el reporte detallado de otra sucursal, seleccione la nueva sucursal y oprima &quot;Actualizar reporte&quot;. Si quiere ver otro reporte para esta sucursal, seleccione primero el nuevo reporte. </p>
        <table width="60%"  border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="14%" class="tdtexttablebold">Direcci&oacute;n: </td>
            <td width="86%" class="tdpadleft5"><select name="cboDireccion" class="field" id="cboDireccion">
                <option value="0">Todas las direcciones</option>
              </select>
            </td>
          </tr>
        </table>
        <br>
        <input name="cmdBuscar" type="submit" class="button" id="cmdBuscar" value="Actualizar reporte" language=javascript onclick="return cmdBuscar_onclick()">
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
