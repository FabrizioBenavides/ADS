<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalEmpresasServiciosConsultarPagosDetalle.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalEmpresasServiciosConsultarPagosDetalle"%>
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
		<script language="JavaScript" src="js/calendario.js"></script>
		<script language="JavaScript" src="js/cal_format00.js"></script>
		<script language="JavaScript" src="../static/scripts/Tools.js" type="text/JavaScript"></script>
		<script language="javascript" id="clientEventHandlersJS">
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function isEnterKey(evt) {
  if (!evt) {
    // grab IE event object
    evt = window.event
  } else if (!evt.keyCode) {
    // grab NN4 event info
    evt.keyCode = evt.which
  }
  return (evt.keyCode == 13)
}
function window_onload() {

	 document.forms[0].action = "<%= strFormAction %>";
	 	 	
	 document.forms[0].elements["txtEmpresaServicioId"].value = "<%= intEmpresaServicioId %>";
	 
	 document.forms[0].elements["txtDireccionIdOculto"].value = "<%= intDireccionOperativaId %>";
	 
	 document.forms[0].elements["txtZonaIdOculto"].value = "<%= intZonaOperativaId %>";
	 	 
	 document.forms[0].elements["txtEmpresaEncontrada"].value = "<%= strEmpresaServicioNombreId %>";
	 
	 document.forms[0].elements["txtSucursalIdOculto"].value = "<%= intSucursalId %>";
	 
	 document.forms[0].elements["txtCompaniaIdOculto"].value = "<%= intCompaniaId %>";
	 
	 document.forms[0].elements["txtNivel"].value = "<%= strNivel %>";
	 
	 document.forms[0].elements["txtFechaInicial"].value = "<%= strFechaInicial %>";
	 
	 document.forms[0].elements["txtFechaFinal"].value = "<%= strFechaFinal %>";
	 
	 document.forms[0].elements["txtEmpresaServicioNombreId"].value = "<%= strEmpresaServicioNombreIdAnterior %>";
	 
	 document.forms[0].elements["txtFormaPagoIndexOculto"].value = "<%= intFormaPagoId %>";
	 
	
	 	 
	<%= strJavascriptWindowOnLoadCommands %>
}

function cmdImprimir_onclick() {
  window.print();
}

function cmdRegresar_onclick(){
	history.go(-1);
	
  }

//-->
		</script>
	</HEAD>
	<body language="javascript" onload="return window_onload()">
		<form name="frmMain" action="about:blank" method="post">
			<input type="hidden" value="0" name="txtEmpresaServicioId"> <input type="hidden" name="txtFormaPagoIndexOculto">
			<input type="hidden" name="txtNivel"> <input type="hidden" name="txtFormaPagoIndexOculto">
			<input type="hidden" name="txtDireccionIdOculto"> <input type="hidden" name="txtFormaPagoIndexOculto">
			<input type="hidden" name="txtZonaIdOculto"> <input type="hidden" name="txtCompaniaIdOculto">
			<input type="hidden" name="txtSucursalIdOculto">
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
					<td class="tdtab" width="770">Está en : <A href="SucursalHome.aspx">Sucursal</A> : <A href="SucursalEmpresasServiciosHome.aspx">
							Empresas de Servicios</A> : Consultar Pagos
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td class="tdgeneralcontent">
						<h1>Consulta de Pagos
						</h1>
						<p>En esta parte usted puede consultar los pagos de servicios efectuados en 
							sucursales.</p>
						<h2>Buscar pagos
						</h2>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TBODY>
								<tr>
									<td class="tdtexttablebold" width="83">Empresa:</td>
									<td class="tdpadleft5" vAlign="middle" width="536"><input language="javascript" class="field" id="txtEmpresaServicioNombreId" type="hidden"
											maxLength="50" size="50" name="txtEmpresaServicioNombreId"> <input class="campotablaresultado" id="txtEmpresaEncontrada" readOnly type="text" size="40"
											border="0" name="txtEmpresaEncontrada"></td>
								</tr>
							</TBODY>
						</table>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="tdtexttablebold" vAlign="middle" width="100">Desde:</td>
								<td class="tdpadleft5"><input class="field" id="txtFechaInicial" readOnly type="text" maxLength="12" size="12"
										name="txtFechaInicial">
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" vAlign="middle" width="100">Hasta :</td>
								<td class="tdpadleft5"><input class="field" id="txtFechaFinal" readOnly type="text" maxLength="12" size="12" name="txtFechaFinal">
								</td>
							</tr>
							<tr>
								<td colSpan="2" height="10"><IMG height="10" src="images/pixel.gif" width="1"></td>
							</tr>
						</table>
						<%= strGetRecordBrowserHTML() %>
						<br>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td align="right" width="90%"><input language="javascript" class="button" id="cmdRegresar" onclick="return cmdRegresar_onclick()"
										type="button" value="Regresar" name="cmdRegresar">
								</td>
								<td align="right" width="5%"><input language="javascript" class="button" id="cmdImprimir" onclick="return cmdImprimir_onclick()"
										type="button" value="Imprimir" name="cmdImprimir">
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
</HTML>
