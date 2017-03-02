<%@ Page CodeBehind="VentasVentasEnCuotas.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsVentasVentasEnCuotas" codePage="1252" EnableSessionState="False" enableViewState="False"%>
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
		<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
		<script id="clientEventHandlersJS" language="javascript">
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

// done hiding -->
		</script>
	</HEAD>
	<body>
		<form name="frmMain" action="about:blank" method="post">
			<table width="780" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td><script language="JavaScript">crearTablaHeader()</script></td>
				</tr>
			</table>
			<table width="780" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td width="10">&nbsp;</td>
					<td width="770" class="tdtab">Está en : <a href="VentasHome.aspx">Ventas</a> : Ventas en 
						cuotas
					</td>
				</tr>
			</table>
			<table width="780" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="tdgeneralcontent"><h1>Ventas en cuotas
						</h1>
						<p>En esta parte usted puede administrar las promociones de ventas en cuotas.</p>
						<table width="100%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td width="358"><a href="VentasVentasEnCuotasConsultar.aspx" class="txbluebold12">Consultar 
										promociones de ventas en cuotas</a></td>
								<td width="43">&nbsp;</td>
								<td width="358"><a href="VentasVentasEnCuotasAgregar.aspx" class="txbluebold12">Agregar 
										promociones de ventas en cuotas </a>
								</td>
							</tr>
							<tr>
								<td width="358"><p>Consulta de diferentes promociones de ventas en cuotas existentes en el sistema.</p>
								</td>
								<td width="43">&nbsp;</td>
								<td><p>Alta de promociones de ventas en cuotas ya sea de manera individual o por 
										archivo.</p>
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
		</form>
	</body>
</HTML>
