<%@ Page CodeBehind="VentasAsignarPoliticasDeTicketAUnaSucursal.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsVentasVerPoliticasDeTicketAUnaSucursal" codePage="1252" EnableSessionState="False" enableViewState="False"%>
<HTML>
	<HEAD>
		<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<meta name="description" content="Javascript Menu">
		<meta name="keywords" content="JavaScript menu, javascript, html, client side, netscape, explorer, IE, menu, DHTML, DOM, control">
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
  window.location.href = "VentasAdministrarPoliticasDeTickets.aspx?intDireccionId=<%= intDireccionId %>&intZonaId=<%= intZonaId %>";
}

-->
		</script>
	</HEAD>
	<body>
		<table width="780" border="0" cellspacing="0" cellpadding="0">
			<tr>
				<td><script language="JavaScript">crearTablaHeader()</script></td>
			</tr>
		</table>
		<table width="780" border="0" cellspacing="0" cellpadding="0">
			<tr>
				<td width="10">&nbsp;</td>
				<td width="770" class="tdtab">Está en : <a href="Ventas.htm">Ventas</a> : Tickets : 
					Administrar políticas de tickets : Ver políticas de tickets&nbsp;de una 
					sucursal
				</td>
			</tr>
		</table>
		<table width="780" border="0" cellpadding="0" cellspacing="0">
			<tr>
				<td class="tdgeneralcontent"><h1>Ver políticas de tickets&nbsp;de una sucursal
					</h1>
					<h2>Datos de la sucursal</h2>
					<table width="50%" border="0" cellspacing="0" cellpadding="0">
						<tr>
							<td width="20%" class="tdtexttablebold">Dirección:
							</td>
							<td width="80%" class="tdcontentableblue"><script language="javascript">strDireccionOperativaNombre()</script></td>
						</tr>
						<tr>
							<td class="tdtexttablebold">Zona:
							</td>
							<td class="tdcontentableblue"><script language="javascript">strZonaOperativaNombre()</script></td>
						</tr>
						<tr>
							<td class="tdtexttablebold">Sucursal</td>
							<td class="tdcontentableblue"><script language="javascript">strSucursalNombre()</script></td>
						</tr>
					</table>
					<span class="tdtexttablebold">
						<br>
						<input name="cmdRegresar" type="button" class="button" id="cmdRegresar" value="Regresar"
							onClick="return cmdRegresar_onclick()"> </span>
					<br>
					<%= strRecordBrowserHTML() %>
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
	</body>
</HTML>
