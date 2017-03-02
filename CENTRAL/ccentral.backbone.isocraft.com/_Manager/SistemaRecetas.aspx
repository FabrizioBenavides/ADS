<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SistemaRecetas.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SistemaRecetas"%>
<HTML>
	<HEAD>
		<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
		<LINK href="css/menu.css" type="text/css" rel="stylesheet">
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="js/menu.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="js/menu_items.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="js/menu_tpl.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="js/headerfooter.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="../static/scripts/Tools.js" type="text/JavaScript"></script>
		<script language="javascript" id="clientEventHandlersJS">
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

//-->
		</script>
	</HEAD>
	<body>
		<form name="frmPage" action="about:blank" method="post">
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td>
						<script language="JavaScript">crearTablaHeader()</script>
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td width="10">&nbsp;</td>
					<td class="tdtab" width="770">Está en : <A href="Sistema.aspx">Sistema</A> : 
						Clientes especiales:Recetas</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td class="tdgeneralcontent">
						<h1>Recetas
						</h1>
						<p>En esta parte usted podrá revisar las recetas&nbsp;y autorizaciones de&nbsp;las 
							ventas a clientes de credito.</p>
						<table cellSpacing="0" cellPadding="0" width="98%" border="0">
							<tr>
								<td><span class="txbluebold12"><A class="txbluebold12" href="SistemaRevisarRecetas.aspx">Revisar 
											Recetas</A></span></td>
								<td>&nbsp;</td>
								<td><A class="txbluebold12" href="SistemaRevisarAutorizacionRecetas.aspx">Revisar 
										Autorizaciones de Recetas</A></td>
							</tr>
							<tr>
								<td>
									<p>Aquí podrá buscar y modificar las recetas que fueron dadas de alta por los 
										puntos de venta.</p>
								</td>
								<td>&nbsp;</td>
								<td>
									<p>Aquí podrá consultar quien autorizo la venta por recetas en los puntos de venta.</p>
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
