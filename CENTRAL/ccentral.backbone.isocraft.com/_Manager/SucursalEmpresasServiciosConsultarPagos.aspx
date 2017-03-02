<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalEmpresasServiciosConsultarPagos.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalEmpresasServiciosConsultarPagos"%>
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
  
  document.forms[0].elements["txtEmpresas"].value = "<%= strEmpresaIds %>"; 
  document.forms[0].elements["txtEmpresaServicioIdsOculto"].value = "<%= strEmpresaServicioIdsOculto %>"; 
  document.forms[0].elements["txtFormaPagoIdOculto"].value = "<%= intFormaPagoIdOculto %>"; 
  document.forms[0].elements["txtFormaPagoIndexOculto"].value = "<%= intFormaPagoIndexOculto %>";
  
    
  document.forms[0].elements["optTodasEmpresas"].checked = "<%= optTodasEmpresas %>";
  document.forms[0].elements["optBuscarEmpresas"].checked = "<%= optBuscarEmpresas %>";
    
  document.forms[0].action = "<%= strThisPageName %>";
  
  document.forms[0].elements["txtFechaInicial"].value = "<%= strFechaInicial %>";
  document.forms[0].elements["txtFechaFinal"].value = "<%= strFechaFinal %>";
  
  if(document.forms[0].elements["txtEmpresas"].value == 0 && document.forms[0].elements["txtEmpresaServicioIdsOculto"].value == 0 )
  {
	document.forms[0].elements["optTodasEmpresas"].checked = true;  
  } 
  else
  {
	document.forms[0].elements["optBuscarEmpresas"].checked = true;
	document.forms[0].elements["cmdBuscarEmpresas"].disabled = false;
  }
  
  <%= strJavascriptWindowOnLoadCommands %>
  <%= strLlenarFormaPagoComboBox() %>
  
  /*Asignación del Index del Combo al txtFormaPagoIndexOculto*/
  document.forms[0].elements["cboFormaPago"].selectedIndex = document.forms[0].elements["txtFormaPagoIndexOculto"].value;
  
}

function optSeleccionEmpresas_onclick(){
  if(document.forms[0].elements["optBuscarEmpresas"].checked == true)
   {
		document.forms[0].elements["cmdBuscarEmpresas"].disabled = false;
   }
   else
   {
		document.forms[0].elements["cmdBuscarEmpresas"].disabled= true;
		document.forms[0].elements["txtEmpresas"].value = "";
		document.forms[0].elements["txtEmpresaServicioIdsOculto"].value = "";
   }
}

function cmdConsultar_onclick() {
  /*Recuperacion de la forma de pago*/ 
  document.forms[0].elements["txtFormaPagoIndexOculto"].value = document.forms[0].elements["cboFormaPago"].selectedIndex;
   
  /* Validación del campo "txtFechaInicial" */
  if (blnValidarCampo(document.forms[0].elements["txtFechaInicial"], true, "Desde", cintTipoCampoFecha, 10, 1, "") == true) {
  
    /* Validación del campo "txtFechaFinal" */
    if (blnValidarCampo(document.forms[0].elements["txtFechaFinal"], true, "Hasta", cintTipoCampoFecha, 10, 1, "") == true) {
      document.forms[0].elements["txtEmpresaServicioIdsOculto"].value == 0;
      document.forms[0].action += "?strCmd=Consultar";
      return(true);
    }
  
  } 
  return(false);
}

function AutoSubmit() {
  if (cmdEjecutar_onclick() == true) {
    document.forms[0].submit();
  }
}

function cmdEjecutar_onclick() {
   /*Recuperacion de la forma de pago*/ 
  document.forms[0].elements["txtFormaPagoIndexOculto"].value = document.forms[0].elements["cboFormaPago"].selectedIndex;
  document.forms[0].action = "SucursalEmpresasServiciosConsultarPagos.aspx?strCmd=Consultar";
  
  return(true);
}

function  cmdCambiarPagina_onclick(){
  document.forms[0].action += "?strCmd=Ver";
  return(true);
}

function cmdExportar_onclick(){
  document.forms[0].action += "?strCmd=Exportar";
  return(true);
}

function cmdImprimir_onclick() {
  window.print();
}

function cmdCancelar_onclick() {
window.location.href = "SucursalEmpresasServiciosHome.aspx";
}

function cmdBuscarEmpresas_onclick() {
  /*Recuperacion de la forma de pago*/ 
  document.forms[0].elements["txtFormaPagoIndexOculto"].value = document.forms[0].elements["cboFormaPago"].selectedIndex;
  
  /*Abrir la ventana Pop*/
  Pop('popEmpresasServiciosElegirEmpresa.aspx?', '360', '520');
}

//-->
		</script>
	</HEAD>
	<body language="javascript" onload="return window_onload()">
		<form name="frmMain" action="about:blank" method="post">
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
									<td class="tdtexttablebold" width="20%"><input language="javascript" id="optBuscarEmpresas" onclick="return optSeleccionEmpresas_onclick()"
											type="radio" value="0" name="optEmpresa"> Buscar empresas</td>
									<td class="tdtexttablebold" width="8%"><input language="javascript" class="button" id="cmdBuscarEmpresas" disabled onclick="return cmdBuscarEmpresas_onclick()"
											type="button" value="Buscar..." name="cmdBuscarEmpresas"></td>
									<td class="tdpadleft5"><input class="campotablaresultado" id="txtEmpresas" readOnly type="text" maxLength="80"
											size="80" name="txtEmpresas">
									</td>
								</tr>
								<tr>
									<td class="tdtexttablebold" width="14%" colSpan="2"><input language="javascript" id="optTodasEmpresas" onclick="return optSeleccionEmpresas_onclick()"
											type="radio" value="1" name="optEmpresa"> Todas las empresas de servicios</td>
								</tr>
							</TBODY>
						</table>
						<br>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="tdtexttablebold" vAlign="middle" width="100">Desde:</td>
								<td class="tdpadleft5"><input class="field" id="txtFechaInicial" readOnly type="text" maxLength="12" size="12"
										name="txtFechaInicial"> <A href="javascript:cal1.popup()"><IMG height="15" src="images/imgCalendarIcon.gif" width="16" align="absMiddle" border="0"></A></td>
							</tr>
							<tr>
								<td class="tdtexttablebold" vAlign="middle" width="100">Hasta :</td>
								<td class="tdpadleft5"><input class="field" id="txtFechaFinal" readOnly type="text" maxLength="12" size="12" name="txtFechaFinal">
									<A href="javascript:cal2.popup()"><IMG height="15" src="images/imgCalendarIcon.gif" width="16" align="absMiddle" border="0"></A></td>
							</tr>
							<tr>
								<td class="tdtexttablebold"><label for="cboFormaPago">Forma de Pago:</label></td>
								<td class="tdpadleft5"><select language="javascript" class="field" id="cboFormaPago" name="cboFormaPago">
										<option value="0" selected>-Todas-</option>
										<option value="Efectivo">Efectivo</option>
										<option value="TarjetaCredito">Tarjeta de Crédito</option>
									</select></td>
							</tr>
							<tr>
								<td colSpan="2" height="10"><IMG height="10" src="images/pixel.gif" width="1"></td>
							</tr>
						</table>
						<input language="javascript" class="button" id="cmdEjecutar" onclick="return cmdEjecutar_onclick()"
							type="submit" value="Ejecutar consulta" name="cmdEjecutar">
						<br>
						<br>
						<%= strGetRecordBrowserHTML() %>
						<br>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td align="right" width="90%"><input language="javascript" class="button" id="cmdRegresar" onclick="return cmdCancelar_onclick()"
										type="button" value="Regresar" name="cmdRegresar">
								</td>
								<td align="right" width="5%"><input language="javascript" class="button" id="cmdImprimir" onclick="return cmdImprimir_onclick()"
										type="button" value="Imprimir" name="cmdImprimir">
								</td>
								<td align="right" width="5%"><input language="javascript" class="button" id="cmdExportar" onclick="return cmdExportar_onclick()"
										type="submit" value="Exportar Todo" name="cmdExportar">
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
			<input type="hidden" name="txtFormaPagoIndexOculto"> <input type="hidden" name="txtEmpresaServicioIdsOculto">
			<input type="hidden" name="txtFormaPagoIdOculto">
			<script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	//-->
			</script>
			<script language="JavaScript">
	<!-- // create calendar object(s) just after form tag closed
		var cal1 = new calendar(null, document.forms[0].elements["txtFechaInicial"]);
		var cal2 = new calendar(null, document.forms[0].elements["txtFechaFinal"]);
	//-->
			</script>
		</form>
	</body>
</HTML>
