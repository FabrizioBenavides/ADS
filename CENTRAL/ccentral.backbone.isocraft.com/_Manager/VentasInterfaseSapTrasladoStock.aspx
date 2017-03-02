<%@ Page Language="vb" AutoEventWireup="false" Codebehind="VentasInterfaseSapTrasladoStock.aspx.vb" Inherits="com.isocraft.backbone.ccentral.VentasInterfaseSapTrasladoStock" %>
<HTML>
	<HEAD>
		<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
		<META http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="css/menu.css" type="text/css" rel="stylesheet">
			<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
				<script language="JavaScript" src="js/menu.js" type="text/JavaScript"></script>
				<script language="JavaScript" src="js/calendario.js" type="text/JavaScript"></script>
				<script language="JavaScript" src="js/cal_format00.js" type="text/JavaScript"></script>
				<script language="JavaScript" src="js/menu_items.js" type="text/JavaScript"></script>
				<script language="JavaScript" src="js/menu_tpl.js" type="text/JavaScript"></script>
				<script language="JavaScript" src="js/headerfooter.js" type="text/JavaScript"></script>
				<script language="JavaScript" src="../static/scripts/Tools.js" type="text/JavaScript"></script>
				<script language="JavaScript" src="js/tools.js" type="text/JavaScript"></script>
				<script language="javascript" id="clientEventHandlersJS">


strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
  document.forms[0].action = "<%= strThisPageName %>";
<%= strJavascriptWindowOnLoadCommands %>
<%= strLlenarDireccionComboBox() %>
<%= strLlenarZonaComboBox() %>
<%= strLlenarSucursalComboBox() %>
  if (document.forms[0].elements["cboSucursal"].selectedIndex == 0) {
    //document.forms[0].elements["cmdNavegadorRegistrosAgregar"].disabled = true;
  }
}

function cboDireccion_onchange() {
  document.forms[0].elements["cboZona"].selectedIndex = 0;
  document.forms[0].elements["cboSucursal"].selectedIndex = 0;
  document.forms[0].submit();
  return(true);
}

function cboZona_onchange() {
  document.forms[0].elements["cboSucursal"].selectedIndex = 0;
  document.forms[0].submit();
  return(true);
}

function cboSucursal_onchange() {
  document.forms[0].submit();
  
}

function cmdSolicitar_onclick() {			
	//document.forms[0].elements["accion1"].value == 1;
	document.forms[0].submit();
}

function cmdImprimir_onclick() {				
  window.print();
}

function cmdExportar_onclick() {			
	//document.forms[0].elements["accion1"].value == 1;
	//document.forms[0].submit();
	document.forms[0].action = "<%= strThisPageName %>?strCmd=Interfaz";
	document.forms[0].submit();	
}


function cmdConsultar_onclick() {
   //return Pop("VentasInterfaseSapVentaAgregada.aspx?strCmd=Consultar&intDireccionId=" + intDireccionId + "&intZonaId=" + intZonaId + "&intCompaniaId=" + intCompaniaId + "&intSucursalId=" + intSucursalId, "360", "440")
	document.forms[0].submit();
}

function cmdNavegadorRegistrosAgregar_onclick(intDireccionId, intZonaId, intCompaniaId, intSucursalId) {
  return Pop("VentasInterfaseSapVentaAgregada.aspx?strCmd=Solicitar&intDireccionId=" + intDireccionId + "&intZonaId=" + intZonaId + "&intCompaniaId=" + intCompaniaId + "&intSucursalId=" + intSucursalId, "360", "440")
    
}

				</script>
	</HEAD>
	<body onload="return window_onload()">
		<form name="frmVentasInterfaseSapVentaAgregada" action="about:blank" method="post">
			<table id="Table2" cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td>
						<script language="JavaScript">crearTablaHeader()</script>
					</td>
				</tr>
			</table>
			<table id="Table3" cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td width="10">&nbsp;</td>
					<td class="tdtab" width="770">Está en : Ventas : Interfase SAP : Traslado de Stock
					</td>
				</tr>
			</table>
			<table id="Table4" cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td class="tdgeneralcontent">
						<h1>Interfase SAP Traslado de Stock</h1>
						<h2>Criterio de Seleccion para obtener la Traslado de Stock</h2>
						<P>
							<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD class="tdtexttablebold" width="90">* Dirección:</TD>
									<TD class="tdpadleft5" width="190"><SELECT language="javascript" class="field" id="cboDireccion" onchange="return cboDireccion_onchange()"
											name="cboDireccion">
											<OPTION value="0" selected>--- Elija una dirección ---</OPTION>
											<OPTION value="-1">Todas las direcciones</OPTION>
											<OPTION>--------------------</OPTION>
										</SELECT>
									</TD>
									<TD width="89">&nbsp;</TD>
									<TD width="375">&nbsp;</TD>
								</TR>
								<TR>
									<TD class="tdtexttablebold">* Zona:</TD>
									<TD class="tdpadleft5"><SELECT class="field" id="cboZona" onchange="return cboZona_onchange()" name="cboZona">
											<OPTION value="0" selected>-- Elija una zona --</OPTION>
											<OPTION value="-1">Todas las zonas</OPTION>
											<OPTION>--------------------</OPTION>
										</SELECT>
									</TD>
									<TD width="89">&nbsp;</TD>
									<TD>&nbsp;</TD>
								</TR>
								<TR>
									<TD class="tdtexttablebold">* Sucursal:</TD>
									<TD class="tdpadleft5"><SELECT class="field" id="cboSucursal" onchange="return cboSucursal_onchange()" name="cboSucursal">
											<OPTION value="0" selected>-- Elija una sucursal --</OPTION>
											<OPTION value="-1">Todas las sucursales</OPTION>
											<OPTION>--------------------</OPTION>
										</SELECT>
									</TD>
									<TD width="89">&nbsp;</TD>
									<TD>&nbsp;</TD>
								</TR>
								<%
									dim f1 as string
									dim f2 as string
									rem f1=str(day(date()),2) & "/" & str(month(date()),2) & "/" & str(year(date()),2)
									rem f2=str(day(date()),2) & "/" & str(month(date()),2) & "/" & str(year(date()),2)									
									f1=Request.form("txtFInicio")
									f2=Request.form("txtFFinal")
									if Request.QueryString("strCmd")="PeticionTerminada"
										f1=Request.QueryString("txtFInicio")
										f2=Request.QueryString("txtFFinal")
									end if
									
									%>
								<TR>
									<TD class="tdtexttablebold">* Fecha Inicio:</TD>
									<TD class="tdpadleft5"><INPUT class="field" id="txtFInicio" type="text" maxLength="12" size="12" value="<%=f1%>"
											name="txtFInicio"> <A href="javascript:cal1.popup()"><IMG height="15" src="images/imgCalendarIcon.gif" width="16" align="absMiddle" border="0"></A>
									</TD>
									<TD class="tdtexttablebold" width="89">* Fecha Inicio:</TD>
									<TD class="tdpadleft5"><INPUT class="field" id="txtFFinal" type="text" maxLength="12" size="12" value="<%=f2%>"
											name="txtFFinal"> <A href="javascript:cal2.popup()"><IMG height="15" src="images/imgCalendarIcon.gif" width="16" align="absMiddle" border="0"></A></TD>
								</TR>
							</TABLE>
						</P>
						<P>&nbsp;&nbsp;&nbsp; <INPUT language="javascript" class="button" id="cmdImprimir" onclick="return cmdImprimir_onclick()"
								type="button" value="Imprimir" name="cmdImprimir">&nbsp; <INPUT language="javascript" class="button" id="cmdExportar" onclick="return cmdExportar_onclick()"
								type="button" value="Generacion Interfaz" name="cmdExportar">&nbsp;&nbsp;&nbsp;&nbsp;</P>
						<P>
							<TABLE id="Table6" height="22" cellSpacing="1" cellPadding="1" width="70%" border="0">
								<TR>
									<TD><%REM strRecordBrowserHTML()%></TD>
								</TR>
							</TABLE>
						</P>
					</td>
				</tr>
			</table>
			<table id="Table5" cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td>
						<script language="JavaScript">crearTablaFooterCentral()</script>
					</td>
				</tr>
			</table>
			&nbsp;&nbsp;&nbsp;
			<script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	//-->
			</script>
		</form>
		<script language="JavaScript">

var calendars = [];

// Constructor
function calendar (str_date, obj_control, str_min_date, str_max_date) {

	this.popup = cal_popup;

	this.id = calendars.length;
	calendars[this.id] = this;

	if (!obj_control)
		return alert("Form element specified can't be found in the document.");
	this.control_obj = obj_control;
	
	var dt_params = (str_date ? cal_parse_date(str_date) : cal_date_only());
	
	var re_num = /^\-?\d+$/;
	if (str_min_date != null)
		this.min_date = (re_num.exec(str_min_date)
			? new Date (dt_params.valueOf() - new Number(str_min_date * 864e5))
			: cal_parse_date(str_min_date)
		).valueOf();
	if (str_max_date != null)
		this.max_date = (re_num.exec(str_max_date)
			? new Date (dt_params.valueOf() + new Number(str_max_date * 864e5))
			: cal_parse_date(str_max_date)
		).valueOf();

	this.dt_current = dt_params;
}

function cal_popup (num_datetime, b_end) {

	if (num_datetime)
		this.dt_current = new Date(num_datetime);
	else if (this.control_obj.value)
		this.dt_current = cal_parse_date(this.control_obj.value);
	
	this.control_obj.value = cal_generate_date(this.dt_current);
	if (b_end) return;
		
	var obj_calwindow = window.open(
		'calendario.htm?datetime='
		+ this.dt_current.valueOf()
		+ '&id=' + this.id, 'Calendar',
		'width=200,height=196,status=no,resizable=no,top=200,'
		+'left=200,dependent=yes,alwaysRaised=yes'
	);
	obj_calwindow.opener = window;
	obj_calwindow.focus();
}

function cal_date_only (dt_datetime) {
	if (!dt_datetime)
		dt_datetime = new Date();
	dt_datetime.setHours(0);
	dt_datetime.setMinutes(0);
	dt_datetime.setSeconds(0);
	dt_datetime.setMilliseconds(0);
	return dt_datetime;
}
		</script>
		<script language="JavaScript">
		<!-- // create calendar object(s) just after form tag closed
		var cal1 = new calendar(null, document.forms[0].elements["txtFInicio"]);
		var cal2 = new calendar(null, document.forms[0].elements["txtFFinal"]);
		//-->
		</script>
	</body>
</HTML>
