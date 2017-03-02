<%@ Page CodeBehind="VentasCortesEnCeroDetalleZona.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsVentasCortesEnCeroDetalleZona" codePage="1252"%>
<HTML>
	<HEAD>
		<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
		<meta name="vs_snapToGrid" content="False">
		<meta name="vs_showGrid" content="False">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<link href="css/menu.css" rel="stylesheet" type="text/css">
		<link href="css/estilo.css" rel="stylesheet" type="text/css">
		<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
		<script id="clientEventHandlersJS" language="javascript">
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";
	
function window_onload() {
  document.forms[0].action = "<%= strThisPageName %>";
  document.forms[0].elements["txtFechaInicial"].value = "<%= strFechaInicial %>";
  document.forms[0].elements["txtFechaFinal"].value = "<%= strFechaFinal %>";
  document.forms[0].elements["txtDireccionId"].value = "<%= intDireccionId %>";
<%= strLlenarZonaComboBox() %>
}

function strDireccionOperativaNombre() {
  document.write("<%= strDireccionOperativaNombre %>");
}

function strZonaOperativaNombre() {
  document.write("<%= strZonaOperativaNombre() %>");
}

function strRangoDeFechas() {
  document.write("<%= strRangoDeFechas %>");
}

function cmdBuscar_onclick() {
  if (document.forms[0].elements["cboZona"].selectedIndex == 0) {
    alert("Por favor seleccione una zona.");
    document.forms[0].elements["cboZona"].focus();
    return(false);
  }
  return(true);
}

function cmdImprimir_onclick() {
  window.print();
}

function cmdRegresar_onclick() {
  window.location.href = "<%= "VentasCortesEnCeroDetalleDireccion.aspx?strCmd=Consultar&intDireccionOperativaId=" & intDireccionId & "&txtFechaInicial=" & strFechaInicial & "&txtFechaFinal=" & strFechaFinal %>";
}

// done hiding -->
		</script>
	</HEAD>
	<body language="javascript" onload="return window_onload()">
		<form method="post" action="about:blank" name="frmMain">
			<input type="hidden" name="txtFechaInicial"> <input type="hidden" name="txtFechaFinal">
			<input type="hidden" name="txtDireccionId">
			<table width="780" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td><script language="JavaScript">crearTablaHeader()</script></td>
				</tr>
			</table>
			<table width="780" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td width="10">&nbsp;</td>
					<td width="770" class="tdtab">Está en : Ventas : Cierres : Consultar cortes en cero 
						: Detalle zona
					</td>
				</tr>
			</table>
			<table width="780" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="tdgeneralcontent"><h1>Cortes en cero - Detalle zona
						</h1>
						<table width="60%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td width="15%" class="tdtexttablebold">Dirección:</td>
								<td width="85%" class="tdcontentableblue"><script language="javascript">strDireccionOperativaNombre()</script></td>
							</tr>
							<tr>
								<td class="tdtexttablebold">Zona:</td>
								<td class="tdcontentableblue"><script language="javascript">strZonaOperativaNombre()</script></td>
							</tr>
							<tr>
								<td class="tdtexttablebold">Rango:</td>
								<td class="tdcontentableblue"><script language="javascript">strRangoDeFechas()</script></td>
							</tr>
						</table>
						<br>
						<input name="cmdRegresar" type="button" class="button" id="cmdRegresar" value="Regresar"
							language="javascript" onclick="return cmdRegresar_onclick()">
						<br>
						<%= strRecordBrowserHTML() %>
						<br>
						<input name="cmdImprimir" type="button" class="button" id="cmdImprimir" value="Imprimir reporte"
							language="javascript" onclick="return cmdImprimir_onclick()">
						<br>
						<br>
						<h2>Cortes en cero de otra zona
						</h2>
						<p>Para ver el reporte detallado de otra zona, seleccione la direción y oprima 
							"Actualizar reporte"
						</p>
						<table width="60%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td width="14%" class="tdtexttablebold">Zona:
								</td>
								<td width="86%" class="tdpadleft5"><select name="cboZona" class="field" id="cboZona">
										<option value="0" selected>Nombre zona</option>
									</select>
								</td>
							</tr>
						</table>
						<br>
						<input name="cmdBuscar" type="submit" class="button" id="cmdBuscar" value="Actualizar reporte"
							language="javascript" onclick="return cmdBuscar_onclick()"></td>
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
</HTML>
