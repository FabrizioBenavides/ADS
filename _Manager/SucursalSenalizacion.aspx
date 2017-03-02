<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalSenalizacion.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalSenalizaci�n"%>
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
				<td width="770" class="tdtab">Est� en : Sucursal : Se�alizaci�n
				</td>
			</tr>
		</table>
		<table width="780" border="0" cellpadding="0" cellspacing="0">
			<tr>
				<td class="tdgeneralcontent"><h1>
						Se�alizaci�n</h1>
					<p>En este apartado usted podr� administrar las diferentes opciones para se�alizaci�n en sucursales.
					</p>
					<table width="100%" border="0" cellspacing="0" cellpadding="0">
						<tr>
							<td width="358"><span class="txbluebold12"><a href="SucursalSenalizacionAdministracionMarcaPropia.aspx" class="txbluebold12">Administraci�n  
										Marca Propia</a></span></td>
							<td width="43">&nbsp;</td>
							<td width="358"><span class="txbluebold12"><a href=SucursalSenalizacionAdministracionMarcaPropiaArchivo.aspx class="txbluebold12">Administraci�n
							            Marca Propia Archivo</a></span></td>
						</tr>
						<tr>
							<td width="358"><p>Administraci�n de las parejas de productos marca propia vs. marcas l�deres.</p>
							</td>
							<td width="43">&nbsp;</td>
							<td><p>Administraci�n de las parejas de productos marca propia vs. marcas l�deres con asistencia v�a archivo.</p>
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
