<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalAsignacionDeArticuloHome.aspx.vb" Inherits="com.isocraft.backbone.ccentral.AsignacionDeArticuloHome" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta name="description" content="Javascript Menu">
		<meta name="keywords" content="JavaScript menu, javascript, html, client side, netscape, explorer, IE, menu, DHTML, DOM, control">
		<LINK rel="stylesheet" type="text/css" href="css/menu.css">
		<LINK rel="stylesheet" type="text/css" href="css/estilo.css">
		<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
		<script id="clientEventHandlersJS" language="javascript">
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

// done hiding -->
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
				<td width="770" class="tdtab">Está en : Asignación de artículo</td>
			</tr>
		</table>
		<table width="780" border="0" cellpadding="0" cellspacing="0">
			<tr>
				<td class="tdgeneralcontent"><h1>Asignación de Artículo</h1>
					<p>En esta parte usted puede realizar actividades de administración para asignación 
						de artículos para DP. Cuenta con los siguientes apartados:</p>
					<table width="100%" border="0" cellspacing="0" cellpadding="0">
						<tr>
							<td width="358"><span class="txbluebold12"><a href="SucursalAsignacionDeArticuloEmpresasServicios.aspx" class="txbluebold12">Empresas 
										de Servicio</a></span></td>
							<td width="43">&nbsp;</td>
							<td width="358"><span class="txbluebold12"><a href="SucursalAsignacionDeArticuloTipoServiciosVirtuales.aspx" class="txbluebold12">Servicios 
										Virtuales</a></span></td>
						</tr>
						<tr>
							<td width="358"><p>Asignación de artículo para promociones de empresas de servicios.</p>
							</td>
							<td width="43">&nbsp;</td>
							<td><p>Asignación de artículo para promociones de servicios virtuales .</p>
							</td>
						</tr>
						<tr>
							<td width="358"><span class="txbluebold12"> <a href="SucursalAsignacionDeArticuloDineroExpress.aspx" class="txbluebold12">
										Transferencia De Dinero</a></span></td>
							<td width="43">&nbsp;</td>
							<td width="358"><span class="txbluebold12"><a href="SucursalAsignacionDeArticuloTarjetaRegalo.aspx" class="txbluebold12">Tarjetas De Regalo</a></span></td>
						</tr>
						<tr>
							<td width="358"><p>Asignación de artículo para los tipos de transferencia de dinero.</p>
							</td>
							<td width="43">&nbsp;</td>
							<td><p>Asignación de artículo para promociones para las tarjetas de regalo</p>
							</td>
						</tr>
					</table>
					<p>&nbsp;</p>
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
