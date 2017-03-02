<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalServiciosVirtuales.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalServiciosVirtuales" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HEAD>
	<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
	<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
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

function window_onload() {
    document.forms[0].elements["txtTipoServicioVirtualDescripcion"].value = "<%= strTipoServicioVirtualDescripcion %>";
    <%= strJavascriptWindowOnLoadCommands %>
}

function cmdAgregar_onclick() {
	document.forms[0].action = "SucursalServiciosVirtualesAgregarEditar.aspx?strCmd=Agregar&intTipoServicioId=" + "<%= intTipoServicioVirtualId %>"
    document.forms[0].submit(); 
   
}

function cmdCancelar_onclick() {
   window.location.href = "SucursalTipoServicioVirtual.aspx";
}

//-->
	</script>
</HEAD>
<body language="javascript" onload="return window_onload()">
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
				<td class="tdtab" width="770">Está en : <A href="SucursalHome.aspx">Sucursal</A> : 
					<A href="SucursalTipoServicioVirtual.aspx">Tipo de Servicios</A> : Administrar&nbsp;Servicios Virtuales</td>
			</tr>
		</table>
		<table cellSpacing="0" cellPadding="0" width="780" border="0">
			<tr>
				<td class="tdgeneralcontent">
					<h1>Administrar&nbsp;Servicios Virtuales</h1>
					<p>Aquí podrá dar de alta o modificar&nbsp;servicios virtuales.</p>
					<br>
					<table cellSpacing="0" cellPadding="0" width="75%" border="0">
						<tr>
							<td class="tdtexttablebold" width="140" height="46"><label for="txtEmpresaNombre">Tipo 
									de Servicio Virtual:</label>
							</td>
							<td class="tdpadleft5"><input class="field" id="txtTipoServicioVirtualDescripcion" type="text" maxLength="50"
									size="80" name="txtTipoServicioVirtualDescripcion" readOnly>
							</td>
						</tr>
						<TR>
							<td width="10">&nbsp;</td>
						<tr>
						</tr>
						<tr>
							<td class="tdtexttablebold" vAlign="top" align="right" colSpan="2"><input language="javascript" class="button" id="cmdAgregar" type="button" value="Agregar"
									name="cmdAgregar" onclick="return cmdAgregar_onclick()">
							</td>
						</tr>
					</table>
					<table cellSpacing="0" cellPadding="0" width="75%" border="0">
						<tr>
							<td>
								<%= strGetRecordBrowserHTML() %>
							</td>
						</tr>
						<tr>
							<td>&nbsp;</td>
						</tr>
						<tr>
							<td class="tdtexttablebold" vAlign="top" colSpan="2"><input language="javascript" class="button" id="cmdCancelar" onclick="return cmdCancelar_onclick()"
									type="button" value="Regresar" name="cmdCancelar">
							</td>
						</tr>
					</table>
				</td>
			</tr>
						
		</table>
		<table cellSpacing="0" cellPadding="0" width="780" border="0">
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
