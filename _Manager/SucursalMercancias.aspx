<%@ Page CodeBehind="SucursalMercancias.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSucursalMercancias" %>
<HTML>
	<HEAD>
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
				<td width="770" class="tdtab">Está en : Sucursal : Mercancías</td>
			</tr>
		</table>
		<table width="780" border="0" cellpadding="0" cellspacing="0">
			<tr>
				<td class="tdgeneralcontent"><h1>Mercancías</h1>
					<p>En esta parte usted puede realizar consultas y administrar diferentes folios; en 
						concreto podrá administrar brincos en folios contables y administrar folios de 
						mercancías.</p>
					<table width="100%" border="0" cellspacing="0" cellpadding="0">
						<tr>
							<td width="358"><span class="txbluebold12"><a href="SucursalConsultarBrincosContables.aspx" class="txbluebold12">Consultar 
										brincos en folios contables</a></span></td>
							<td width="43">&nbsp;</td>
							<td width="358"><span class="txbluebold12"><a href="SucursalAdministrarFoliosDeMercancias.aspx" class="txbluebold12">Administrar 
										folios de mercancías</a></span></td>
						</tr>
						<tr>
							<td width="358"><p>Consultar el detalle de diferentes tipos de folios con base en una 
									fecha específica.</p>
							</td>
							<td width="43">&nbsp;</td>
							<td><p>Asignar valores a folios determinados de una sucursal.</p>
							</td>
						</tr>
						<tr>
							<td width="358"><span class="txbluebold12"><a href="SucursalMercanciasProveedores.aspx" class="txbluebold12">Proveedores</a></span></td>
							<td width="43">&nbsp;</td>
							<td width="358">&nbsp;</td>
						</tr>
						<tr>
							<td width="358"><p>En esta parte se puede realizar consultas y administrar articulos y 
									sucursales asignados a proveedores para la captura de mercancías.</p>
							</td>
							<td width="43">&nbsp;</td>
							<td>&nbsp;
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
