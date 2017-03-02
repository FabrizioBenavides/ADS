<%@ Page CodeBehind="SucursalHome.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSucursalHome" codePage="1252" EnableSessionState="False" enableViewState="False"%>
<HTML>
	<HEAD>
		<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
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
				<td><script language="JavaScript">crearTablaHeader()</script>
				</td>
			</tr>
		</table>
		<table width="780" border="0" cellspacing="0" cellpadding="0">
			<tr>
				<td width="10">&nbsp;</td>
				<td width="770" class="tdtab">Está en : Sucursal
				</td>
			</tr>
		</table>
		<table width="780" border="0" cellpadding="0" cellspacing="0">
			<tr>
				<td class="tdgeneralcontent"><h1>Sucursal</h1>
					<p>En esta parte usted puede realizar actividades relacionadas con la operación de 
						una sucursal. Cuenta con los siguientes apartados:</p>
					<table width="100%" border="0" cellspacing="0" cellpadding="0">
						<tr>
							<td width="358"><span class="txbluebold12"><a href="SucursalAsignacionDeCuotas.aspx" class="txbluebold12">Asignación 
										de cuotas</a></span></td>
							<td width="43">&nbsp;</td>
							<td width="358"><span class="txbluebold12"><a href="SucursalCuentas.aspx" class="txbluebold12">Cuentas</a></span></td>
						</tr>
						<tr>
							<td width="358"><p>Administración de diferentes cuotas y márgenes de compra.</p>
							</td>
							<td width="43">&nbsp;</td>
							<td><p>Asignaciones de diferentes tipos de cuentas a sucursales.</p>
							</td>
						</tr>
						<tr>
							<td><span class="txbluebold12"><a href="SucursalMercancias.aspx" class="txbluebold12">Mercancías</a></span></td>
							<td>&nbsp;</td>
							<td><span class="txbluebold12"><a href="SucursalPuntosDeVenta.aspx" class="txbluebold12">Puntos 
										de venta</a></span></td>
						</tr>
						<tr>
							<td><p>Consulta y administración de diferentes tipos de folios.</p>
							</td>
							<td>&nbsp;</td>
							<td><p>Administración de políticas y cajas de los puntos de venta.</p>
							</td>
						</tr>
						<tr>
							<td><span class="txbluebold12"><a href="SucursalInventarioRotativoHome.aspx" class="txbluebold12">Inventario 
										Rotativo</a></span></td>
							<td>&nbsp;</td>
							<td><span class="txbluebold12"><a href="SucursalEmpresasServiciosHome.aspx" class="txbluebold12">Empresas 
										de Servicios</a></span></td>
						</tr>
						<tr>
							<td><p>Administración de Inventarios Rotativos.</p>
							</td>
							<td>&nbsp;</td>
							<td><p>Administración de Empresas de Servicios.</p>
							</td>
						</tr>
						<tr>
							<td><span class="txbluebold12"><a href="SucursalEncuestasHome.aspx" class="txbluebold12">Encuestas</a></span></td>
							<td>&nbsp;</td>
							<td><span class="txbluebold12"><a href="SucursalCorresponsaliaServicios.aspx" class="txbluebold12">Corresponsalia</a></span></td>
						</tr>
						<tr>
							<td><p>Administración de Encuestas de Sucursales.</p>
							</td>
							<td>&nbsp;</td>
							<td><p>Administración se servicios de Corresponsalia.</p>
							</td>
						<tr>
							<td><span class="txbluebold12"><a href="SucursalSenalizacion.aspx" class="txbluebold12">Señalización</a></span></td>
							<td>&nbsp;</td>
							<td><span class="txbluebold12"><a href="SucursalTipoServicioVirtual.aspx" class="txbluebold12">Tipos 
										de Servicios Virtuales </a></span>
							</td>
						</tr>
						<tr>
							<td><p>Administración de señalización de Sucursales.</p>
							</td>
							<td>&nbsp;</td>
							<td><p>Administración de los tipos de servicios virtuales.
								</p>
							</td>
						</tr>
						<tr>
							<td><span class="txbluebold12"><A class="txbluebold12" href="SucursalAsignacionDeArticuloHome.aspx">Promoción 
										de Servicios</A></span></td>
							<td>&nbsp;</td>
							<td>&nbsp;</td>
							<td><span class="txbluebold12"><a class="txbluebold12"></a></span></td>
						</tr>
						<tr>
							<td>
								<p>Asignación de artículos para servicios virtuales.</p>
							</td>
							<td>&nbsp;
							</td>
							<td>&nbsp;</td>
							<td>
								<p></p>
							</td>
						</tr>
						<tr>
							<td>&nbsp;</td>
							<td>&nbsp;</td>
							<td><span class="txbluebold12"><a class="txbluebold12"> </a></span>
							</td>
						</tr>
						<tr>
							<td>&nbsp;
							</td>
							<td>&nbsp;</td>
							<td><p>
								</p>
							</td>
						</tr>
					</table>
					<table width="780" border="0" cellspacing="0" cellpadding="0">
						<tr>
							<td><script language="JavaScript">crearTablaFooterCentral()</script>
							</td>
						</tr>
					</table>
					<script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	//-->
					</script>
			</tr>
		</table>
	</body>
</HTML>
