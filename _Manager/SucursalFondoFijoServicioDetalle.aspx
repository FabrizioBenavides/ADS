<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalFondoFijoServicioDetalle.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalFondoFijoServicioDetalle" EnableSessionState="False" enableViewState="False"%>
<HTML>
	<HEAD>
		<title>ADS CENTRAL</title>
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

   

    document.forms[0].action = "<%= strFormAction %>";
    document.forms[0].elements["intCompaniaId"].value = "<%= intCompaniaId %>";
    document.forms[0].elements["intSucursalId"].value = "<%= intSucursalId %>";
    document.forms[0].elements["intMes"].value = "<%= intMes %>";
    document.forms[0].elements["intAnio"].value = "<%= intAnio %>";
    

    
}
function cmdCancelar_onclick() {
    window.location.href = "SucursalFondoFijoServicio.aspx?intDireccionId=<%= intDireccionId %>&intZonaId=<%= intZonaId %>&intMes=<%= intMes %>&intAnio=<%= intAnio %>"
}


function strImprimirNombreSucursal() {
    document.write("<%= strNombreSucursal %>");
}

function strImprimirFechaAsignacion() {
    document.write("<%= intMes %> " + "/ " + "<%= intAnio %>");
}

//-->
		</script>
	</HEAD>
	<body language="javascript" onload="return window_onload()">
		<form id="frmMain" action="about:blank" method="post">
			<input type="hidden" name="strCmd"> <input type="hidden" name="intCompaniaId"> <input type="hidden" name="intSucursalId">
			<input type="hidden" name="intDireccionId"> <input type="hidden" name="intZonaId">
			<input type="hidden" name="intMes"> <input type="hidden" name="intAnio"> <input type="hidden" name="intFondoFijoPresupuestadoId">
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
						Consulta de fondo fijo : Detalle de gastos de sucursal
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td class="tdgeneralcontent">
						<h1>Detalle de gastos de sucursal
						</h1>
						<p>En esta página puede consultar el detalle del pago de servicios con fondo fijo.
						</p>
						<h2>Gastos de sucursal
						</h2>
						<table cellSpacing="0" cellPadding="0" width="90%" border="0">
							<tr>
								<td class="tdtexttablebold" width="14%">
									<table cellSpacing="0" cellPadding="0" border="0">
										<tr>
											<td bgColor="#525698" colSpan="4" height="1"><IMG height="1" src="../static/images/pixel.gif" width="1"></td>
										</tr>
										<tr>
											<td style="HEIGHT: 23px" width="1" bgColor="#525698"><IMG height="1" src="../static/images/pixel.gif" width="1"></td>
											<td class="tdceleste" width="166"><b>Sucursal:</b></td>
											<td class="tdceleste" width="247">
												<script language="JavaScript" type="text/javascript">strImprimirNombreSucursal()</script>
											</td>
											<td style="HEIGHT: 23px" width="1" bgColor="#525698"><IMG height="1" src="../static/images/pixel.gif" width="1"></td>
										</tr>
										<tr>
											<td style="HEIGHT: 23px" width="1" bgColor="#525698"><IMG height="1" src="../static/images/pixel.gif" width="1"></td>
											<td class="tdceleste"><b>Fecha:</b></td>
											<td class="tdceleste">
												<script language="JavaScript" type="text/javascript">strImprimirFechaAsignacion()</script>
											</td>
											<td style="HEIGHT: 23px" width="1" bgColor="#525698"><IMG height="1" src="../static/images/pixel.gif" width="1"></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold"><IMG height="1" src="../static/images/pixel.gif" width="1"></td>
							</tr>
						</table>
						<table cellSpacing="0" cellPadding="0" width="90%" border="0">
							<tr>
								<td width="100%">
									<table cellSpacing="0" cellPadding="0" width="90%" border="0">
										<%= strGetRecordBrowserHTML %>
									</table>
									<table cellSpacing="0" cellPadding="0" width="90%" border="0">
										<tr>
											<td bgColor="#525698" colSpan="2" height="1"><IMG height="1" alt="" src="images/pixel.gif" width="1"></td>
										</tr>
										<tr>
											<td colSpan="2" height="8"><IMG height="8" alt="" src="images/pixel.gif" width="1"></td>
										</tr>
										<tr>
											<td class="txgreybold" vAlign="middle" align="right" width="80%">TOTAL:</td>
											<td class="txblueregular" vAlign="middle" align="center" >&nbsp;<%= strTotalImporte %></td>
										</tr>
										<tr>
											<td colSpan="2" height="8"><IMG height="8" alt="" src="images/pixel.gif" width="1"></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
                         <br>	
						<input language="javascript" class="button" id="cmdCancelar" onclick="return cmdCancelar_onclick()"
							type="button" value="Regresar" name="cmdCancelar"> &nbsp;												
						<br>
						<br>
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
