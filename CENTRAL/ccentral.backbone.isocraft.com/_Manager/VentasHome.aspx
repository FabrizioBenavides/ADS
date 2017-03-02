<%@ Page CodeBehind="VentasHome.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsVentasHome" %>
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
				<style type="text/css"> <!-- .style1 {font-size: 10px}
	--></style>
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
				<td width="770" class="tdtab">Está en : Ventas</td>
			</tr>
		</table>
		<table width="780" border="0" cellpadding="0" cellspacing="0">
			<tr>
				<td class="tdgeneralcontent"><h1>Ventas</h1>
					<p>En esta parte usted puede realizar actividades relacionadas directamente con la 
						venta de productos. Cuenta con los siguientes apartados:</p>
					<table width="100%" border="0" cellspacing="0" cellpadding="0">
						<tr>
							<td width="358"><span class="txbluebold12"><a href="VentasCierres.aspx" class="txbluebold12">Cierres</a></span></td>
							<td width="43">&nbsp;</td>
							<td height="18"><span class="txbluebold12"><a href="VentasVentasEnCuotas.aspx" class="txbluebold12">Ventas 
										en cuotas </a>
								</span></td>
						</tr>
						<tr>
							<td width="358"><p>Actividades relacionadas con el cierre de operaciones.</p>
							</td>
							<td width="43">&nbsp;</td>
							<TD>
								<P>En esta parte usted puede administrar las promociones de ventas en cuotas.</P>
							</TD>
						</tr>
						<tr>
							<td><span class="txbluebold12"><a href="VentasTickets.aspx" class="txbluebold12">Tickets</a></span></td>
							<td>&nbsp;</td>
							<td><span class="txbluebold12"><a href="VentasPromocionesMonedero.aspx" class="txbluebold12">Promociones 
										Monedero</a></span></td>
						</tr>
						<tr>
							<td><p>Administración de políticas asignadas a los tickets utilizados por las 
									sucursales.</p>
							</td>
							<td>&nbsp;</td>
							<td><p>En esta parte se administran las promociones de monedero electrónico.</p>
							</td>
						</tr>
						<tr>
							<td><span class="txbluebold12"><a href="VentasOperacionesDEX.aspx" class="txbluebold12">Operaciones 
										DEX</a></span></td>
							<td>&nbsp;</td>
							<td><span class="txbluebold12"><a href="VentasFacturacionGlobal.aspx" class="txbluebold12">Facturacion 
										glóbal</a></span></td>
						</tr>
						<tr>
							<td><p>Consulta de envíos, pagos y devoluciones por concepto de Dinero Express</p>
							</td>
							<td>&nbsp;</td>
							<td><p>En esta parte se genera la facura global de las ventas de todas las sucursales.</p>
							</td>
						</tr>
						<tr>
							<td><span class="txbluebold12"><a href="VentasRecolecciones.aspx" class="txbluebold12">Recolecciones</a></span></td>
							<td>&nbsp;</td>
							<td><span class="txbluebold12"><a href="VentasInterfaseSAP1.aspx" class="txbluebold12">Interfases 
										SAP</a></span></td>
						</tr>
						<tr>
							<td><p>Consulta de recolecciones de tipo Normal y DEX realizadas en cada sucursal.</p>
							</td>
							<td>&nbsp;</td>
							<td><p>En esta parte usted puede realizar actividades relacionadas directamente con la 
									venta de productos.</p>
							</td>
						</tr>
						<tr>
							<td><span class="txbluebold12"><a href="VentasEntregaValores.aspx" class="txbluebold12">Entrega 
										de valores</a></span></td>
							<td>&nbsp;</td>
						</tr>
						<tr>
							<td><p>Consulta registros de entrega de valores a empresas recolectoras.</p>
							</td>
							<td>&nbsp;</td>
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
