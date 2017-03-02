<%@ Page CodeBehind="MostrarDetalleParaInventariosRotativos.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsMostrarDetalleParaInventariosRotativos" Explicit="True" Trace="False" Strict="True" codePage="1252" EnableSessionState="true" enableViewState="False" %>

<HTML>
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
		<script language="JavaScript" src="../static/scripts/InvRotUtils.js" type="text/JavaScript"></script>
		<script language="javascript" id="clientEventHandlersJS">

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function doSubmit()
{
    args = doSubmit.arguments;
    var action = args[0];
	var params = ""
	for (i=1; i < (args.length-1); i +=2)
	{
		params+= "&" + args[i] + "=" + args[i+1]
	}
	
	document.forms[0].action = "MostrarDetalleParaInventariosRotativos.aspx?strCmd=" + action + params
	document.forms[0].submit();  
}


//-->
		</script>
	</HEAD>
	<body>
		<form name="frmSistemaAdministrarTiendas" id="Form1" action="" method="post">
			<input type="hidden" name="intListadoId" value="<%= intListadoId %>" >
			<input type="hidden" name="intCompaniaId" value="<%= intCompaniaId %>" >
			<input type="hidden" name="intSucursalId" value="<%= intSucursalId %>" >
			<input type="hidden" name="dtmArticuloListadoFechaTomaInventario" value="<%= dtmFechaTomaInventario.toString("dd/MM/yyyy") %>" >
			<input type="hidden" name="dtmArticuloListadoUltimaModificacion" value="<%= dtmUltimaModificacion %>" >
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td class="tdgeneralcontent">
						<h1>Detalle de Listado para Inventarios Rotativos</h1>
						<p>
							<table width='100%' border='0' cellpadding='2' cellspacing='2'>
								<tr>
									<td width="10%" align="right" class="tdtexttablebold">Compañía:</td>
									<td width="10%" class="tdtexttablereg"><%= intCompaniaId %></td>
									<td width="10%" align="right" class="tdtexttablebold">Sucursal:</td>
									<td width="10%" class="tdtexttablereg"><%= intSucursalId %></td>
									<td width="30%" align="right" class="tdtexttablebold">Fecha de Toma Inventario:</td>
									<td width="30%" class="tdtexttablereg"><%= dtmFechaTomaInventario.toString("dd/MM/yyyy") %></td>
								</tr>
							</table>
						</p>
						<%= strRecordBrowserHTML() %>
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td>
						<script language="JavaScript">crearTablaFooter()</script>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
