<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SistemaTransmisionesPendientesDetalleRed.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsSistemaTransmisionesPendientesDetalleRed"%>
<HTML>
<HEAD>
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<link href="css/menu.css" rel="stylesheet" type="text/css">
<link href="css/estilo.css" rel="stylesheet" type="text/css">
<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/tools.js"></script>
<script language="JavaScript" src="js/calendario.js"></script>
<script language="JavaScript" src="js/cal_format00.js"></script>
<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
<script id="clientEventHandlersJS" language="javascript">
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
  document.forms[0].action = "SistemaTransmisionesPendientesDetalleRed.aspx";
  document.forms[0].elements['cboReporteId'].value = <%= intReporteId %>;
}

function cmdRegresar_onclick() {
  document.forms[0].submit();
}

function strEncabezadoHTML() {
	document.write("<%= strEncabezadoHTML %>");
}

function strRecordBrowserHTML() {
	document.write("<%= strRecordBrowserHTML %>");
}

function cmdConsultar_onClick() {

	theForm = document.forms[0];
	
	if (theForm.cboReporteId.value == 0) {
		alert("Favor de seleccionar un tipo de reporte");
		theForm.cboReporteId.focus();
		return false;
	}
	
	theForm.action += "?strCmd=Detalle";
	theForm.submit();
	return true;
}

function cmdRegresar_onclick() {
  window.location.href = "SistemaConsultarTransmisionesPendientes.aspx";
}
// done hiding -->
</script>
</HEAD>
<body language="javascript" onload="return window_onload()">
<form method="post" action="about:blank" name="frmMain" onSubmit="return blnFormValidator(this)">
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Est� en : Sistema : Transmisiones : Transmisiones pendientes - Detalle Red </td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="tdgeneralcontent"><h1>Transmisiones pendientes - Detalle Red </h1>
        <script language="javascript">strEncabezadoHTML();</script>
        <br>
		<input name="cmdRegresar" type="button" class="button" id="cmdRegresar" value="Regresar" language=javascript onclick="return cmdRegresar_onclick()">
        <br>
        <script language="javascript">strRecordBrowserHTML();</script>
        <br>
        <input name="btnImprimir" type="button" class="button" value="Imprimir reporte" onclick="window.print();">
        <br>
        <br>
        <br>
        <h2>Reconfigurar reporte </h2>
        <p>Si quiere ver otro reporte para esta zona, seleccione el nuevo reporte y luego oprima "Actualizar reporte". </p>
        <table width="50%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="17%" class="tdtexttablebold">Reporte:</td>
            <td width="83%" class="tdpadleft5"><select name="cboReporteId" id="cboReporteId" class="field">
                <option value="0" selected>Elija una opci�n</option>
                <option value="1">P�lizas no transmitidas</option>
                <option value="2">Ventas no transmitidas</option>
                <option value="3">Tickets no transmitidos</option>
              </select>
            </td>
          </tr>
        </table>
        <br>
        <input name="btncConsultar" type="button" class="button" value="Actualizar reporte" onclick="javascript: return cmdConsultar_onClick();">
        <br>
      </td>
    </tr>
  </table>
  <br>
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
</HTML>
