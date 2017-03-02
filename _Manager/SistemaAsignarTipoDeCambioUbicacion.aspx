<%@ Page CodeBehind="SistemaAsignarTipoDeCambioUbicacion.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.SistemaAsignarTipoDeCambioUbicacion" Explicit="True" Trace="False" Strict="True" codePage="1252" EnableSessionState="False" enableViewState="False"%>
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
   <%= strJavascriptWindowOnLoadCommands %>
   <%= strLlenarMonedaComboBox() %>
      
   var intMonedaCambioId = "<%= intMonedaCambioId %>";
   var intUbicacionSucursalId = <%= intUbicacionSucursalId %>;
   var dblTipoDeCambioMonedaValor = <%= dblTipoDeCambioMonedaValor %>;
   
   if (intMonedaCambioId>=0) {
     document.forms[0].elements["cboMoneda"].value = intMonedaCambioId;
   }
   
   if(intUbicacionSucursalId >= 0) {
     document.forms[0].elements["optUbicacion"][intUbicacionSucursalId].checked = true; 
   }
   
   if(dblTipoDeCambioMonedaValor >= 0) {
       document.forms[0].elements["txtTipoDeCambioMonedaValor"].value = dblTipoDeCambioMonedaValor;   
   }
   
}

function blnFormValidator(theForm) {
   var blnReturn = false;
   
   // Validación del campo txtTipoDeCambioMonedaValor
   if (theForm.elements["txtTipoDeCambioMonedaValor"] != null) {
       blnReturn = blnValidarCampo(theForm.elements["txtTipoDeCambioMonedaValor"], true, "Tipo de cambio", cintTipoCampoCadenaDefinida, 10, 1, "0123456789.");
   }   
   else {
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

function cmdConsultar_onclick() {

    document.forms[0].action += "?strCmd=Consultar";
    document.forms[0].submit();    
}

function cmdAplicar_onclick() {
  if ( blnFormValidator(document.forms[0]) == true ) {
    document.forms[0].action += "?strCmd=Aplicar";
    document.forms[0].submit();
  }
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
					<td width="770" class="tdtab">Está en : Sistema : Asignar tipo de cambio por 
						Ubicación
					</td>
				</tr>
			</table>
			<table width="780" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="tdgeneralcontent"><h1>Asignar tipo de cambio
						</h1>
						<p>Para Asignar seleccione la moneda, marque la ubicación (F)rontera o (I)nterior, 
							capture el tipo de cambio y Aplicarlo.
						</p>
						<br>
						<table width="80%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td width="101" class="tdtexttablebold">Moneda:</td>
								<td width="310" class="tdpadleft5"><select name="cboMoneda" class="field" id="cboMoneda">
										<option value="0" selected>Elija una moneda</option>
									</select>
								</td>
								<td width="204">&nbsp;</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" width="101">Ubicación:</td>
								<td class="tdtexttablereg" width="310"><input name="optUbicacion" type="radio" value="0">
									Interior &nbsp;&nbsp;&nbsp;&nbsp; <input name="optUbicacion" type="radio" value="1">
									Frontera</td>
								<td width="204">&nbsp;</td>
							</tr>
							<tr>
								<td width="101" class="tdtexttablebold">
									Tipo de cambio:
								</td>
								<td width="310" class="tdpadleft5">
									<input name="txtTipoDeCambioMonedaValor" type="text" class="field" id="txtTipoDeCambioMonedaValor"
										size="25" maxlength="25" value="0.0">
								</td>
								<td width="204" align="center">
									<input name="cmdConsultar" type="button" class="button" id="cmdConsultar" value="Consultar"
										onclick="return cmdConsultar_onclick()">&nbsp;&nbsp; &nbsp; <input name="cmdAplicar" type="button" class="button" id="cmdAplicar" value="Aplicar" onclick="return cmdAplicar_onclick()">
								</td>
							</tr>
						</table>
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
