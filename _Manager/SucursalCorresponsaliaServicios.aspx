<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalCorresponsaliaServicios.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalCorresponsaliaServicios"%>
<HTML>
	<HEAD>
		<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<meta content="Javascript Menu" name="description">
		<meta content="JavaScript menu, javascript, html, client side, netscape, explorer, IE, menu, DHTML, DOM, control"
			name="keywords">
		<LINK href="css/menu.css" type="text/css" rel="stylesheet">
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
		<script id="clientEventHandlersJS" language="javascript">
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";
function goToURL(where) 
	{
	top.location = where; 
	}
	
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
				<td width="770" class="tdtab">Está en : Sucursal : Corresponsalía
				</td>
			</tr>
		</table>
		<table width="780" border="0" cellpadding="0" cellspacing="0">
			<tr>
				<td class="tdgeneralcontent"><h1>
						Corresponsalia Bancomer</h1>
					<p>En este apartado usted podrá configurar la información de los tickets de 
						corresponsalía Bancomer así
						<br>
						como administrar los montos mínimos y máximos de acuerdo al tipo de servicio.</p>
					<table width="100%" border="0" cellspacing="0" cellpadding="0">
						<tr>
							<td width="358"><span class="txbluebold12"><a href="SucursalCorresponsaliaConfigurarTickets.aspx" class="txbluebold12">Configurar 
										Tickets</a></span></td>
							<td width="43">&nbsp;</td>
							<td width="358"><span class="txbluebold12"><a href="SucursalCorresponsaliaConfigurarMontos.aspx" class="txbluebold12">Configurar 
										Montos</a></span></td>
						</tr>
						<tr>
							<td width="358"><p>Configura la información de los tickets de acuerdo al tipo de 
									servicio.</p>
							</td>
							<td width="43">&nbsp;</td>
							<td><p>Asigna montos mínimos y maximos. Configura los montos para Cash Back.</p>
							</td>
						</tr>
					</table>
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
