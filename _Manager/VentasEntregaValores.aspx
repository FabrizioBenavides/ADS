<%@ Page CodeBehind="VentasEntregaValores.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsVentasEntregaValores" codePage="1252" EnableSessionState="False" enableViewState="False"%>
<HTML>
	<HEAD>
		<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<link href="css/menu.css" rel="stylesheet" type="text/css">
		<link href="css/estilo.css" rel="stylesheet" type="text/css">
		<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
		<script language="JavaScript" src="js/calendario.js"></script>
		<script language="JavaScript" src="js/cal_format00.js"></script>
		<script id="clientEventHandlersJS" language="javascript">
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
  var intDireccionOperativaId = <%= intDireccionOperativaId %>;  
  document.forms[0].action = "<%= strFormAction %>";
  
  document.forms[0].elements["txtFechaInicial"].value = "<%= strFechaInicial %>";
  
  document.forms[0].elements["txtFechaFinal"].value = "<%= strFechaFinal %>";
    
  if (intDireccionOperativaId == "-1") {
    document.forms[0].elements["cboDireccion"].options[1].selected = true;
    document.forms[0].elements["cboZona"].disabled = true;
  }
  
<%= strLlenarOperacionComboBox() %>
<%= strLlenarRecolectoraComboBox() %>
<%= strLlenarDireccionComboBox() %>
<%= strLlenarZonaComboBox() %>
<%= strJavascriptWindowOnLoadCommands %>
}

function cboDireccion_onchange() {
  if (document.forms[0].elements["cboDireccion"].selectedIndex > 0) {
    document.forms[0].elements["cboZona"].selectedIndex = 0;
    document.forms[0].submit();
  }
  return(true);
}

function cmdImprimir_onclick() {
  window.print();
}

function cmdExportar_onclick() {
  var strFormAction = document.forms[0].action;
  
  document.forms[0].action += "?strCmd=Exportar";
  document.forms[0].submit();  
  document.forms[0].action = strFormAction;
}

//-->
		</script>
	</HEAD>
	<body language="javascript" onLoad="return window_onload()">
		<form name="frmMain" action="about:blank" method="post">
			<table width="780" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td><script language="JavaScript">crearTablaHeader()</script>
					</td>
				</tr>
			</table>
			<table width="780" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td width="10">&nbsp;</td>
					<td width="770" class="tdtab">Está en : <a href="VentasHome.aspx">Ventas</a> : 
						Entrega de Valores
					</td>
				</tr>
			</table>
			<table width="780" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="tdgeneralcontent"><h1>Entrega de Valores
						</h1>
						<p>En esta parte usted puede realizar consultas de las entregas de valores 
							realizadas a las empresas recolectoras.</p>
						<h2>Cofigurar reporte
						</h2>
						<table width="60%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td width="17%" class="tdtexttablebold">Operación:
								</td>
								<td width="83%" class="tdpadleft5"><select name="cboOperacion" class="field" id="cboOperacion">
										<option value="0" selected>--- Elija una operación ---</option>
									</select>
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold">Recolectora:</td>
								<td class="tdpadleft5"><select name="cboRecolectora" class="field" id="cboRecolectora">
										<option value="0" selected>--- Elija una empresa ---</option>
									</select>
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold">Fecha:</td>
								<td valign="top" class="tdpadleft5"><span class="txaccionbold">Desde:</span> <input name="txtFechaInicial" id="txtFechaInicial" class="field" size="12" maxlength="12"
										type="text" readonly> <a href="javascript:cal1.popup()" >
										<img src="images/imgCalendarIcon.gif" width="16" height="15" border="0" align="absMiddle"></a><span class="txaccionbold">
										&nbsp;&nbsp;Hasta:</span> <input name="txtFechaFinal" id="txtFechaFinal" class="field" size="12" maxlength="12" type="text"
										readonly> <a href="javascript:cal2.popup()" ><img src="images/imgCalendarIcon.gif" width="16" height="15" border="0" align="absMiddle"></a></td>
							</tr>
							<tr>
								<td class="tdtexttablebold">Dirección:</td>
								<td class="tdpadleft5"><select name="cboDireccion" class="field" id="cboDireccion" language="javascript" onChange="return cboDireccion_onchange()">
										<option value="0" selected>--- Elija una dirección ---</option>
										<option value="-1">Todas las direcciones</option>
									</select>
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold">Zona:</td>
								<td class="tdpadleft5"><select name="cboZona" class="field" id="cboZona">
										<option value="0" selected>--- Elija una zona ---</option>
										<option value="-1">Todas las zonas</option>
									</select>
								</td>
							</tr>
							<tr>
								<td colspan="2"><img src="images/pixel.gif" width="1" height="10"></td>
							</tr>
						</table>
						<input name="cmdBuscar" type="submit" class="button" id="cmdBuscar" value="Ejecutar consulta">
						<br>
						<br>
						<%= strObtenerSucursalesPorZonaElegida() %>
						<br>
						<input name="cmdImprimir" type="button" class="button" id="cmdImprimir" value="Imprimir"
							language="javascript" onclick="return cmdImprimir_onclick()"> &nbsp; <input name="cmdExportar" type="button" class="button" id="cmdExportar" value="Exportar"
							language="javascript" onclick="return cmdExportar_onclick()">
						<br>
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
			<script language="JavaScript">
<!-- // create calendar object(s) just after form tag closed
var cal1 = new calendar(null, document.forms['frmMain'].elements["txtFechaInicial"]);
var cal2 = new calendar(null, document.forms['frmMain'].elements["txtFechaFinal"]);
//-->
</script>
		</form>
	</body>
</HTML>
