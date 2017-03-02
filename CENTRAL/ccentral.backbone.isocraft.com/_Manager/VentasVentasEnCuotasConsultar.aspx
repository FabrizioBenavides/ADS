<%@ Page CodeBehind="VentasVentasEnCuotasConsultar.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsVentasVentasEnCuotasConsultar" codePage="1252" EnableSessionState="False" enableViewState="False"%>
<html>
<head>
<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<link href="css/menu.css" rel="stylesheet" type="text/css">
<link href="css/estilo.css" rel="stylesheet" type="text/css">
<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<script language="JavaScript" src="js/calendario.js"></script>
<script language="JavaScript" src="js/cal_format00.js"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
  document.forms[0].action = "<%= strFormAction %>";
  document.frmMain.optSeleccionPromocion["<%= stroptSeleccionPromocion %>"].checked = true;
  if(document.frmMain.optSeleccionPromocion[0].checked == true){
	document.forms[0].elements["txtFechaInicial"].value = "<%= strFechaInicial %>";
	document.forms[0].elements["txtFechaFinal"].value = "<%= strFechaFinal %>";
  }
  <%= strJavascriptWindowOnLoadCommands %>
}

function fecha_onclick(){
  document.frmMain.optSeleccionPromocion[0].checked = true;
}

function cmdEjecutar_onclick() {
  /*Validar que no se dejen fechas vacias*/
  var vacio;
  if(document.frmMain.optSeleccionPromocion[0].checked == true){ 
	if(document.forms[0].elements["txtFechaInicial"].value == ""){
	  vacio = true;
	}
	if(document.forms[0].elements["txtFechaFinal"].value == ""){
	  vacio = true;
	}
	if(vacio==true){
	  alert("Por favor Seleccione las fechas inicial (\"Desde:\") y final (\"Hasta:\")");
	  return(false);
	}else{
	  return(true);
	}
  }else{
	return(true);
  }
}

function optSeleccionPromocion_onclick() {
  if(document.frmMain.optSeleccionPromocion[1].checked == true){ 
	document.forms[0].elements["txtFechaInicial"].value = "";
	document.forms[0].elements["txtFechaFinal"].value = "";
  }
}

//-->
</script>
</head>
<body language=javascript onload="return window_onload()">
<form name="frmMain" action="about:blank" method="post">
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><script language="JavaScript">crearTablaHeader()</script></td>
  </tr>
</table>
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="10">&nbsp;</td>
    <td width="770" class="tdtab">Est&aacute; en : <a href="VentasHome.aspx">Ventas</a> : <a href="VentasVentasEnCuotas.aspx">Ventas en cuotas </a> : Consultar promociones de ventas en cuotas </td>
  </tr>
</table>
<table width="780" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdgeneralcontent"><h1>Consultar promociones de ventas en cuotas </h1>
      <p>En esta parte usted puede consultar las promociones de ventas en cuotas existentes en el sistema. </p>
	  <h2>B&uacute;squeda de promoci&oacute;n de venta en cuotas </h2>
      <table width="70%"  border="0" cellspacing="0" cellpadding="0">

        <tr>
          <td width="143" valign="top" class="tdtexttablebold"><input name="optSeleccionPromocion" type="radio" value="0" onclick="return optSeleccionPromocion_onclick()">
            Vigencia:</td>
          <td width="167" valign="top" class="tdpadleft5"><span class="txaccionbold">Desde:</span>
            <input name="txtFechaInicial" id="txtFechaInicial" class="field" size="12" maxlength="12" type="text" readonly>
            <a href="javascript:cal1.popup()" onclick="return fecha_onclick()"><img src="images/imgCalendarIcon.gif" width="16" height="15" border="0" align="absmiddle"></a></td>
          <td width="221" valign="top" class="tdpadleft5"><span class="txaccionbold">Hasta:</span>
            <input name="txtFechaFinal" id="txtFechaFinal" class="field" size="12" maxlength="12" type="text" readonly>
            <a href="javascript:cal2.popup()" onclick="return fecha_onclick()"><img src="images/imgCalendarIcon.gif" width="16" height="15" border="0" align="absmiddle"></a></td>
        </tr>
        <tr>
          <td colspan="3" valign="top" class="tdtexttablebold"><input name="optSeleccionPromocion" type="radio" value="1" language=javascript onclick="return optSeleccionPromocion_onclick()">
            Todas las promociones de venta en cuotas</td>
        </tr>
        <tr>
          <td height="10" colspan="3" ><img src="images/pixel.gif" width="1" height="10"></td>
        </tr>
      </table>      
      <p>
        <input name="cmdEjecutar" type="submit" class="button" id="cmdEjecutar" value="Ejecutar consulta" language=javascript onclick="return cmdEjecutar_onclick()">      
        <br>
        </p>
      <p><%= strObtenerPromocionesDeVentasEnCuotas()%> <br>
          </p></td>
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
<script language="JavaScript">
<!-- // create calendar object(s) just after form tag closed
var cal1 = new calendar(null, document.forms['frmMain'].elements["txtFechaInicial"]);
var cal2 = new calendar(null, document.forms['frmMain'].elements["txtFechaFinal"]);
//-->
</script>
</form>
</body>
</html>
