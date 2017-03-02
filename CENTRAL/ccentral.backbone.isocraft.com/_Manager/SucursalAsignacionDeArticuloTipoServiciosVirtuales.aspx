<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalAsignacionDeArticuloTipoServiciosVirtuales.aspx.vb" Inherits="com.isocraft.backbone.ccentral.AsignacionDeArticuloTipoServiciosVirtuales" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta content="text/html; charset=iso-8859-1" http-equiv="Content-Type">
		<LINK rel="stylesheet" type="text/css" href="css/menu.css">
		<LINK rel="stylesheet" type="text/css" href="css/estilo.css">
		<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
		<script id="clientEventHandlersJS" language="javascript">


strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
<%= strJavascriptWindowOnLoadCommands %>
}

function cmdCancelar_onclick() {
   window.location.href = "SucursalAsignacionDeArticuloHome.aspx";
}

 
		</script>
	</HEAD>
	<body language="javascript" onload="return window_onload()">
		<form method="post" name="frmPage" action="about:blank">
			<table border="0" cellSpacing="0" cellPadding="0" width="780">
				<tr>
					<td>
						<script language="JavaScript">crearTablaHeader()</script>
					</td>
				</tr>
			</table>
			<table border="0" cellSpacing="0" cellPadding="0" width="780">
				<tr>
					<td width="10">&nbsp;</td>
					<td class="tdtab" width="770">Está en : <A href="SucursalHome.aspx">Sucursal</A> :&nbsp;Promoción 
						de Servicios&nbsp;: Administrar&nbsp;Promociones de Servicios Virtuales</td>
				</tr>
			</table>
			<table border="0" cellSpacing="0" cellPadding="0" width="780">
				<tr>
					<td class="tdgeneralcontent">
						<h1>Administrar&nbsp;Promociones de Servicios Virtuales</h1>
						<p>Aquí podrá dar de alta o modificar&nbsp;promociones de&nbsp;servicios virtuales.</p>
						<br>
					
						<table border="0" cellSpacing="0" cellPadding="0" width="75%">
							<tr>
								<td>
									<%= strGetRecordBrowserHTML() %>
								</td>
							</tr>
							<tr>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" vAlign="top" colSpan="2"><input id="cmdCancelar" language="javascript" class="button" onclick="return cmdCancelar_onclick()"
										value="Regresar" type="button" name="cmdCancelar">
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<table border="0" cellSpacing="0" cellPadding="0" width="780">
				<tr>
					<td>
						<script language="JavaScript">crearTablaFooterCentral()</script>
					</td>
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
