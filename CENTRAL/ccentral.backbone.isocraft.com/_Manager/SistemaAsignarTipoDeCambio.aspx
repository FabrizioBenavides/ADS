<%@ Page CodeBehind="SistemaAsignarTipoDeCambio.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSistemaAsignarTipoDeCambio" Explicit="True" Trace="False" Strict="True" codePage="1252" EnableSessionState="False" enableViewState="False"%>
<HTML>
	<HEAD>
		<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
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

function window_onload() {
  document.forms[0].action = "<%= strThisPageName %>";
  document.forms[0].elements["txtSucursales"].value = "<%= strSucursales %>";
<%= strJavascriptWindowOnLoadCommands %>
<%= strLlenarMonedaComboBox() %>
<%= strLlenarDireccionComboBox() %>
<%= strLlenarZonaComboBox() %>
  cboMoneda_onchange();
  cboZona_onchange();
}

function cmdAsignar_onclick() {
  if ( blnFormValidator(document.forms[0]) == true ) {
    document.forms[0].action += "?strCmd=Asignar";
    document.forms[0].submit();
  }
}

function blnFormValidator(theForm) {
  var blnReturn = false;

  /* Validación del campo "txtTipoDeCambioMonedaValor" */
  if (theForm.elements["txtTipoDeCambioMonedaValor"] != null) {
      blnReturn = blnValidarCampo(theForm.elements["txtTipoDeCambioMonedaValor"], true, "Tipo de cambio", cintTipoCampoCadenaDefinida, 10, 1, "0123456789.");
  } else {
    blnReturn = true;
  }

  return (blnReturn);
}

function cboMoneda_onchange() {
  var strMonedaNombre = document.forms[0].elements["cboMoneda"].options[document.forms[0].elements["cboMoneda"].selectedIndex].text;
  if (document.forms[0].elements["cboMoneda"].selectedIndex == 0) {
    strMonedaNombre = "";
  }
  if (document.forms[0].elements["txtMonedaNombre"] != null) {
    document.forms[0].elements["txtMonedaNombre"].value = strMonedaNombre;
  }
  return(true);
}

function cboDireccion_onchange() {
  document.forms[0].submit();
  return(true);
}

function cboZona_onchange() {
  if (document.forms[0].elements["cboZona"].selectedIndex > 0) {
    document.forms[0].elements["cmdElegirSucursales"].disabled = false;
  } else {
    document.forms[0].elements["cmdElegirSucursales"].disabled = true;
  }
  return(true);
}

function cmdElegirSucursales_onclick() {
  var intMonedaId = document.forms[0].elements["cboMoneda"].options[document.forms[0].elements["cboMoneda"].selectedIndex].value;
  var intDireccionId = document.forms[0].elements["cboDireccion"].options[document.forms[0].elements["cboDireccion"].selectedIndex].value;
  var intZonaId = document.forms[0].elements["cboZona"].options[document.forms[0].elements["cboZona"].selectedIndex].value;
  return Pop("popSucursalElegirSucursales.aspx?intMonedaId=" + intMonedaId + "&intDireccionId=" + intDireccionId + "&intZonaId=" + intZonaId,"360","548")
}

//-->
				</script>
	</HEAD>
	<body onload="return window_onload()">
		<form method="post" action="about:blank" name="frmSucursalAsignarTipoDeCambio">
			<input type="hidden" name="txtSucursales">
			<table width="780" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td><script language="JavaScript">crearTablaHeader()</script></td>
				</tr>
			</table>
			<table width="780" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td width="10">&nbsp;</td>
					<td width="770" class="tdtab">Está en : Sistema : Asignar tipo de cambio
					</td>
				</tr>
			</table>
			<table width="780" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="tdgeneralcontent"><h1>Asignar tipo de cambio
						</h1>
						<p>Para asignar un tipo de cambio, seleccione la moneda y luego la zona a cuyas 
							sucursales asignará un tipo de cambio.
						</p>
						<h2>Moneda y zona de las sucursales
						</h2>
						<table width="50%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td width="14%" class="tdtexttablebold">Moneda:</td>
								<td width="86%" class="tdpadleft5"><select name="cboMoneda" class="field" id="cboMoneda">
										<option value="0" selected>Elija una moneda</option>
									</select>
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold">Dirección:</td>
								<td class="tdpadleft5"><select name="cboDireccion" class="field" id="cboDireccion" onchange="return cboDireccion_onchange()">
										<option value="0" selected>Elija una dirección</option>
									</select>
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold">Zona:</td>
								<td class="tdpadleft5"><select name="cboZona" class="field" id="cboZona" onchange="return cboZona_onchange()">
										<option value="0" selected>Elija una zona</option>
									</select>
								</td>
							</tr>
						</table>
						<br>
						<input name="cmdElegirSucursales" type="button" class="button" id="cmdElegirSucursales"
							value="Elegir sucursales" onclick="return cmdElegirSucursales_onclick()">
						<br>
						<br>
						<%= strRecordBrowserHTML() %>
						<br>
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
		</form>
	</body>
</HTML>
