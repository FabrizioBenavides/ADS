<%@ Page CodeBehind="SucursalEmpresasServiciosHome.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.SucursalEmpresasServiciosHome" codePage="1252" EnableSessionState="False" enableViewState="False"%>
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
				<td width="770" class="tdtab">Está en : <a href="SucursalHome.aspx"> Sucursal </a> : Empresas de Servicios
				</td>
			</tr>
		</table>
		<table width="780" border="0" cellpadding="0" cellspacing="0">
			<tr>
				<td class="tdgeneralcontent"><h1>Empresas de Servicios</h1>
					<p>En esta parte usted puede realizar actividades relacionadas con la 
						administración y configuración de las empresas de servicios. Cuenta con los 
						siguientes apartados:</p>
					<table width="100%" border="0" cellspacing="0" cellpadding="0">
						<tr>
							<td width="358"><span class="txbluebold12"><a href="SucursalEmpresasServiciosAdministrarEmpresas.aspx" class="txbluebold12">Empresas</a></span></td>
							<td width="43">&nbsp;</td>
							<td width="358"><span class="txbluebold12"><a href="SucursalEmpresasServiciosConsultarPagos.aspx" class="txbluebold12">Consulta 
										de Pagos</a></span></td>
						</tr>
						<tr>
							<td width="358"><p>Aquí podrá dar de alta o modificar las empresas de servicios. 
									Asignar empresas a sucursales y editar el formato de lectura.</p>
							</td>
							<td width="43">&nbsp;</td>
							<td><p>Aquí podrá consultar los pagos de servicios realizados en sucursal.</p>
							</td>
						</tr>
					</table>
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
	</body>
</HTML>
