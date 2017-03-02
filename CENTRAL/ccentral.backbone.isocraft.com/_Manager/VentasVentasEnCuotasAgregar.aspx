<%@ Page CodeBehind="VentasVentasEnCuotasAgregar.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsVentasVentasEnCuotasAgregar" codePage="1252" EnableSessionState="False" enableViewState="False"%>
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
<script language="JavaScript" type="text/JavaScript" src="js/calendario.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/cal_format00.js"></script>
<script language="JavaScript" src="../static/scripts/Tools.js" type="text/JavaScript"></script>
<script id="clientEventHandlersJS" language="javascript">
<!--
strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
  var intPromocionCuotasId = "<%=intPromocionVentaCuotasId%>";
  document.forms[0].action = "<%= strFormAction %>";	
  if(intPromocionCuotasId==0){
	DeactivateRow("tableModulos");
  }
  else{
	document.forms[0].elements["txtArticuloEncontrado"].value = "<%= strtxtArticuloEncontrado%>";
    document.forms[0].optAsignar["<%= intAsignar %>"].checked = true;
    document.forms[0].elements["txtArticuloDescripcion"].value = "<%= strtxtArticuloDescripcion %>";
    <%= strLlenarCategoriaComboBox() %>
  }
  document.forms[0].elements["txtTipoPagoDescripcion"].value = "<%= strtxtTipoPagoDescripcion %>";
  document.forms[0].elements["txtPlazo"].value = "<%= strtxtPlazo %>";
  document.forms[0].elements["txtMontoMinimo"].value = "<%= strtxtMontoMinimo %>";
  document.forms[0].elements["txtFechaInicial"].value = "<%= strFechaInicial %>";
  document.forms[0].elements["txtFechaFinal"].value = "<%= strFechaFinal %>";
  document.forms[0].elements["intClick"].value = "<%= intClick%>";
  document.forms[0].elements["intPromocionVentaCuotasId"].value="<%=intPromocionVentaCuotasId%>";
  document.forms[0].elements["intArticuloId"].value="<%= intArticuloId%>";
  document.forms[0].elements["intActiva"].value = "<%=intActiva%>";
  if (document.forms[0].elements["intActiva"].value == 0){
	document.forms[0].elements["chkPromocionInactiva"].checked = true;
  }
  else{
	document.forms[0].elements["chkPromocionInactiva"].checked = false;
  }
<%= strJavascriptWindowOnLoadCommands %>
}

//Valida que se ingresen solo numeros con dos decimales maximo
function checkDecimals(fieldName, fieldValue, campo) {

  decallowed = 2;  // Que tantos decimales son permitidos?

  if (isNaN(fieldValue) || fieldValue == "") {
	alert("Por favor introduce un valor numérico en el campo \"" + campo + "\".");
	fieldName.select();
	fieldName.focus();
	return(false)
  }
  else {
    if (fieldValue.indexOf('.') == -1) fieldValue += ".";
    dectext = fieldValue.substring(fieldValue.indexOf('.')+1, fieldValue.length);
	if (dectext.length > decallowed)
	{
	  alert("El valor del campo \"" + campo + "\", debe tener a lo más " + decallowed + " decimales.");
	  fieldName.select();
	  fieldName.focus();
	  return(false);
    }
	else {
	  return(true);
    }
  }
}

function blnValidarMinMax(value,campo,minimo,maximo){
  // Minimo debe ser menor que maximo
  if (value < minimo || value > maximo){
    if (value < minimo){
      alert("Por favor introduzca un valor mayor o igual a " + minimo + " en el campo \"" + campo + "\".");
      return(false);
    }else{
      alert("Por favor introduzca un valor menor o igual a " + maximo + " en el campo \"" + campo + "\".");
      return(false);
    }
  }else{
    return(true);
  }
}

function ConsultarArticulo() {
  if (blnValidarCampo(document.forms[0].elements["txtArticuloDescripcion"], true, "Articulo", cintTipoCampoAlfanumerico, 255, 1, "") == true) {
    window.open("../_ScriptLibrary/PopArticulo.aspx?blnSucursal=False&strArticuloIdNombre=" + document.forms[0].elements["txtArticuloDescripcion"].value + "&strArticulo=txtArticuloDescripcion&strArticuloNombreId=txtArticuloEncontrado&strEvalJs=opener.AutoSubmit()", "Pop", "width=500,height=540,left=280,top=168,resizable=no,scrollbars=yes,menubar=no,status=no");
  }
}

function optAsignar0_onfocus(){
  document.forms[0].elements["cboSeleccionarCategoria"].focus();
  document.forms[0].elements["txtArticuloDescripcion"].value="";
}

function optAsignar1_onfocus(){
  document.forms[0].elements["txtBuscar"].focus();
  document.forms[0].elements["cboSeleccionarCategoria"].value = 0;
  document.forms[0].elements["txtArticuloDescripcion"].value="";
}

function optAsignar_onfocus(){
  document.forms[0].elements["txtArticuloDescripcion"].focus();
  document.forms[0].elements["cboSeleccionarCategoria"].value = 0;
}

function cboSeleccionarCategoria_onfocus(){
  document.forms[0].optAsignar[0].checked = true;
  document.forms[0].elements["txtArticuloDescripcion"].value="";
}

function txtBuscar_onclick(){
  document.forms[0].optAsignar[1].checked = true;
  document.forms[0].elements["txtArticuloDescripcion"].value="";
}

function txtBuscar_onfocus(){
  document.forms[0].optAsignar[1].checked = true;
  document.forms[0].elements["txtArticuloDescripcion"].value="";
}

function txtArticuloDescripcion_onfocus() {
  document.forms[0].optAsignar[2].checked = true;
  document.forms[0].elements["cboSeleccionarCategoria"].value = 0;
}

function cmdAsignarCategoria_onclick(){
  if(document.forms[0].optAsignar[0].checked == true)
    if(document.forms[0].elements["cboSeleccionarCategoria"].value != 0){
	  document.forms[0].action += "?strCmd=AgregarCategoria";
	  return(true);
	}
	else {
	  alert("Debe seleccionar una opcion de \"Asignar por categoría de artículo:\"");
	  document.forms[0].elements["cboSeleccionarCategoria"].focus();
	  return(false);
	}
  else return(false);
}

function cmdAgregar_onclick(){
 if (document.forms[0].elements["txtBuscar"].value.length < 1) {
    alert("Por favor especifique un valor para el campo \"Archivo\".");
    document.forms[0].elements["txtBuscar"].focus();
    return(false);
  }
  document.forms[0].action += "?strCmd=AgregarArchivo";
  return(true);
}

function cmdAgregarArticulo_onclick() {
  if (document.forms[0].optAsignar[2].checked == true)
    if (document.forms[0].elements["txtArticuloDescripcion"].value != "") {
      document.forms[0].action = "<%= strFormAction %>?strCmd=AgregarArticulo";
      document.forms[0].submit();
    } else {
      alert("Debe seleccionar un articulo de \"Asignar un artículo:\"");
    }
  return(false);
}

function cmdAgregarNuevo_onclick() {
  window.location.href = "<%= "VentasVentasEnCuotasAgregar.aspx" %>";
  return(true);
}

function cmdConsultarPagos_onclick() {
  window.location.href = "<%= "VentasVentasEnCuotasConsultar.aspx" %>";
  return(true);
}

function cmdReemplazar_onclick() {
  if (document.forms[0].elements["txtBuscar"].value.length < 1) {
    alert("Por favor especifique un valor para el campo \"Archivo\".");
    document.forms[0].elements["txtBuscar"].focus();
    return(false);
  }
  document.forms[0].action += "?strCmd=Reemplazar";
  return(true);
}

function cmdRegistrar_onclick() {
var strCmd = "<%= strCmd%>";
  if(document.forms[0].elements["chkPromocionInactiva"].checked == true){
    document.forms[0].elements["intActiva"].value = 0;
  }else{
    document.forms[0].elements["intActiva"].value = 1;
  }
  if(document.forms[0].elements["txtTipoPagoDescripcion"].value == ""){
	alert("Debe agregar el nombre de la promocion");
	return(false);
  }else{
    if(blnValidarCampo(document.forms[0].elements["txtTipoPagoDescripcion"], true, "Nombre", cintTipoCampoAlfanumerico, 100, 1, "")==false){
      document.forms[0].elements["txtTipoPagoDescripcion"].focus();
      return(false);
    }else{
	  if(document.forms[0].elements["txtPlazo"].value == ""){
	    alert("Debe agregar el plazo");
	    return(false);
      }else{ 
	    if(document.forms[0].elements["txtPlazo"].value != "") {
		  if (blnValidarCampo(document.forms[0].elements["txtPlazo"], true, "Plazo", cintTipoCampoEntero, 10, 1, "") == false || blnValidarMinMax(document.forms[0].elements["txtPlazo"].value,"Plazo",2,48)==false) {
		    document.forms[0].elements["txtPlazo"].focus();
		    return(false);
		  }else if(blnValidarCampo(document.forms[0].elements["txtPlazo"], true, "Plazo", cintTipoCampoEntero, 10, 1, "") == true) { 
		    if(document.forms[0].elements["txtMontoMinimo"].value == ""){
		      alert("Debe agregar el monto minimo");
		      return(false);
		    }else{ 
		      if(document.forms[0].elements["txtMontoMinimo"].value != "") {
		        if (checkDecimals(document.forms[0].elements["txtMontoMinimo"],document.forms[0].elements["txtMontoMinimo"].value,"Monto Minimo")== false) {
			      document.forms[0].elements["txtMontoMinimo"].focus();
				  return(false);
			    }else{
				  if(document.forms[0].elements["txtFechaInicial"].value > document.forms[0].elements["txtFechaFinal"].value){
				    alert("La fecha inicial \"Desde:\" debe ser menor que la fecha final \"Hasta:\"");
				    return(false);
				  }else{
				    if(strCmd=="Editar"){
				      document.forms[0].action += "?strCmd=Actualizar";
		            }
		            if(strCmd=="Agregar"||strCmd==""||strCmd=="Registrar"){
		              document.forms[0].action += "?strCmd=Registrar";
		            }
		            if(strCmd=="Actualizar"){
		              document.forms[0].action += "?strCmd=Actualizar";
		            }
		            document.forms[0].elements["intClick"].value = 1;
			        return(true);			      
			      }
			    }
			  }
			}
		  }
		}	
	  }  
	}	
  }
}
  
function tieneDatos(Valor) { 
 for (var i=0; i<Valor.length; i++) { 
   if ((" \t\n\r").indexOf(Valor.charAt(i))==-1) return true; 
   } 
 return false; 
}
 
function esNumerico(Valor) { 
 return (isNaN(Valor)); 
}
 
function esFecha(Valor) { 
 if (!tieneDatos(Valor)) return true; 
 var DatosFecha = Valor.split('/'); 
 var Fecha = new Date(); 
 Fecha.setFullYear(DatosFecha[2],DatosFecha[1]-1,DatosFecha[0]); 
 return (Fecha.getMonth()==DatosFecha[1]-1); 
}

function ActivateRow(tableName) {
  var intClick = "<%= intClick %>"
  if (intClick != 0){
	var table = document.all? eval('document.all.' + tableName) : document.getElementById(tableName);

    for  (var rowIndex = 0; rowIndex < table.rows.length; rowIndex = rowIndex+1) {
      table.rows[rowIndex].style.display = '';
    }
  
    document.forms[0].elements["txtArticuloEncontrado"].value = "<%= strtxtArticuloEncontrado%>";
    document.forms[0].optAsignar["<%= intAsignar %>"].checked = true;
    document.forms[0].elements["txtArticuloDescripcion"].value = "<%= strtxtArticuloDescripcion %>";
    <%= strLlenarCategoriaComboBox() %>
  }
}

function DeactivateRow(tableName) {
  var table = document.all? eval('document.all.' + tableName) : document.getElementById(tableName);

  for  (var rowIndex = 0; rowIndex < table.rows.length; rowIndex = rowIndex+1) {
      table.rows[rowIndex].style.display = 'none';
  }
}

function Titulo(){
  var intClick = "<%= intClick %>"
  if (intClick != 0){
    document.write("<h2>Asignar artículos</h2>");
  }
}

function cmdRegresar_onclick() {
  window.location.href = "<%= "VentasVentasEnCuotasConsultar.aspx" %>";
  return(true);
}
		
function ImprimirBotonesNavegacion() {
  var intClick = "<%= intClick %>"
  if (intClick != 0){
	var strCmd = "<%= strCmd %>";
	if (strCmd == "Agregar"||strCmd=="Editar") {
		document.write("<input name=\"cmdRegresar\" type=\"button\" class=\"button\" id=\"cmdRegresar\" value=\"Regresar\"language=\"javascript\" onclick=\"return cmdRegresar_onclick()\">");
	} else {
		document.write("<input name=\"cmdConsultarPagos\" type=\"button\" class=\"button\" id=\"cmdConsultarPagos\" value=\"Consultar promociones\" language=\"javascript\" onclick=\"return cmdConsultarPagos_onclick()\">");
	}
	document.write("&nbsp; <input name=\"cmdAgregarNuevo\" type=\"button\" class=\"button\" id=\"cmdAgregarNuevo\" value=\"Agregar nuevo\" language=\"javascript\" onclick=\"return cmdAgregarNuevo_onclick()\"> </td>");
  }
}

function txtArticuloDescripcion_onkeydown(objEvent) {
  if (isEnterKey(objEvent)) {
    ConsultarArticulo();
    return(false);
  }
}

function AutoSubmit() {
  cmdAgregarArticulo_onclick();
}

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

//-->
</script>
</HEAD>
<body language="javascript" onLoad="return window_onload()">
<form name="frmMain" action="about:blank" method="post" runat=server>
  <input type="hidden" value="0" name="intArticuloId">
  <input type="hidden" value="0" name="intPromocionVentaCuotasId">
  <input type="hidden" value="0" name="intActiva">
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;
        <input name="intClick" type="hidden" id="intClick" value="0"></td>
      <td width="770" class="tdtab">Está en : <a href="Ventas.htm">Ventas</a> : <a href="VentasVentasEnCuotas.aspx"> Ventas en cuotas </a>: Agregar promoción de venta en cuotas </td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="tdgeneralcontent"><h1>Agregar promoción de venta en cuotas</h1>
        <p>En esta parte usted puede agregar promociones de venta en cuotas y posteriormente asignarles artículos. </p>
        <h2>Datos de promoción </h2>
        <table width="70%" border="0" cellspacing="0" cellpadding="0">
          <TBODY>
            <tr>
              <td valign="top" class="tdtexttablebold">Nombre:</td>
              <td valign="top" class="tdpadleft5">&nbsp;
                <input name="txtTipoPagoDescripcion" type="text" class="field" id="txtTipoPagoDescripcion"
												size="30" maxlength="30"></td>
              <td valign="top" class="tdpadleft5">&nbsp;</td>
            </tr>
            <tr>
              <td valign="top" class="tdtexttablebold">Plazo:</td>
              <td colspan="2" valign="top" class="tdpadleft5">&nbsp;
                <input name="txtPlazo" type="text" class="field" id="txtPlazo" size="10" maxlength="10">
                <span class="txaccionbold">meses</span> </td>
            </tr>
            <tr>
              <td valign="top" class="tdtexttablebold">Monto mínimo: </td>
              <td valign="top" class="tdpadleft5"><span class="txaccionbold">$</span>
                <input name="txtMontoMinimo" type="text" class="field" id="txtMontoMinimo" size="30" maxlength="30"></td>
              <td valign="top" class="tdpadleft5">&nbsp;</td>
            </tr>
            <tr>
              <td width="91" valign="top" class="tdtexttablebold">Vigencia:</td>
              <td width="182" valign="top" class="tdpadleft5"><span class="txaccionbold">&nbsp;&nbsp;&nbsp;&nbsp;Desde:</span>
                <input name="txtFechaInicial" id="txtFechaInicial" class="field" size="12" maxlength="12"
												type="text"  readonly>
                <a href="javascript:cal1.popup()"><img src="images/imgCalendarIcon.gif" width="16" height="15" border="0" align="absMiddle"></a></td>
              <td width="258" valign="top" class="tdpadleft5"><span class="txaccionbold">Hasta:</span>
                <input name="txtFechaFinal" id="txtFechaFinal" class="field" size="12" maxlength="12" type="text" language=javascript readonly>
                <a href="javascript:cal2.popup()"><img src="images/imgCalendarIcon.gif" width="16" height="15" border="0" align="absMiddle"></a></td>
            </tr>
            <tr>
              <td colspan="3" valign="top" class="tdtexttablebold"><input name="chkPromocionInactiva" type="checkbox" id="chkPromocionInactiva" value="0">
                Promoción inactiva </td>
            </tr>
            <tr>
              <td height="10" colspan="3"><img src="images/pixel.gif" width="1" height="10"></td>
            </tr>
        </table>
        <a onClick="return ActivateRow('tableModulos');" href="javascript:;">
        <input name="cmdRegistrar" type="submit" class="button" id="cmdRegistrar" value="Registrar"
							language="javascript" onClick="return cmdRegistrar_onclick()">
        </a> <br>
        <br>
        <script language="JavaScript">Titulo()</script>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" id="tableModulos">
          <tr>
            <td class="tdtexttablebold"><input name="optAsignar" type="radio" value="0" onFocus="return optAsignar0_onfocus()">
              Asignar por categoría de artículo: </td>
            <td width="71%" class="tdpadleft5"><select name="cboSeleccionarCategoria" class="field" id="cboSeleccionarCategoria" onFocus="return cboSeleccionarCategoria_onfocus()">
                <option value="0">Seleccionar categoría</option selected>
              </select>
              &nbsp;
              <input name="cmdAsignar2" type="submit" class="button" id="cmdAsignar2" value="Asignar" language="javascript" onClick="return cmdAsignarCategoria_onclick()">
            </td>
          </tr>
          <tr>
            <td width="29%" class="tdtexttablebold"><input name="optAsignar" type="radio" value="1" onFocus="return optAsignar1_onfocus()">
              Asignar por archivo: </td>
            <td class="tdpadleft5"><input name='txtBuscar' id='txtBuscar' type='file' class='field' size='55' maxlength='55' onclick='return txtBuscar_onclick()' onfocus='return txtBuscar_onfocus()' runat=server>
              <br>
            </td>
          </tr>
          <tr>
            <td height="10" colspan="2"><img src="images/pixel.gif" width="1" height="10"> </td>
          </tr>
          <tr>
            <td height="10"><span class="tdpadleft5"> </span> </td>
            <td height="10"><span class="tdpadleft5">
              <input name="cmdAgregar" type="submit" class="button" id="cmdAgregar" value="Agregar" language="javascript"onclick="return cmdAgregar_onclick()">
              &nbsp;
              <input name="cmdReemplazar" type="submit" class="button" id="cmdReemplazar" value="Reemplazar" language="javascript" onClick="return cmdReemplazar_onclick()">
              </span> </td>
          </tr>
          <tr>
            <td height="10" colspan="2"><img src="images/pixel.gif" width="1" height="10"> </td>
          </tr>
          <tr>
            <td height="10" class="tdtexttablebold"><input name="optAsignar" type="radio" value="2" onFocus="return optAsignar_onfocus()">
              Asignar un art&iacute;culo: </td>
            <td height="10" class="tdpadleft5"><input name="txtArticuloDescripcion" type="text" class="field" id="txtArticuloDescripcion" size="30" maxlength="30" onFocus="return txtArticuloDescripcion_onfocus()" language=javascript onkeydown="return txtArticuloDescripcion_onkeydown(event)">
              <A href="javascript:ConsultarArticulo()"><img src="../static/images/icono_lupa.gif" width="17" height="17" align="absMiddle" border="0"></A>
              <input class="campotablaresultado" id="txtArticuloEncontrado" readOnly type="text" size="40" border="0" name="txtArticuloEncontrado">
            </td>
          </tr>
          <tr>
            <td height="10" colspan="2"><img src="images/pixel.gif" width="1" height="10"> </td>
          </tr>
          <tr>
            <td height="10"><span class="tdpadleft5"> </span> </td>
            <td height="10"><span class="tdpadleft5">
              <input name="cmdAsignar" type="button" class="button" id="cmdAsignar" value="Asignar" language="javascript" onClick="return cmdAgregarArticulo_onclick()">
              </span> </td>
          </tr>
        </table>
        <%= strObtenerArticulosIncluidos() %> <br>
        <script language="JavaScript">ImprimirBotonesNavegacion()</script>
    </tr>
    </TBODY>
    
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
var cal1 = new calendar(null, document.forms[0].elements["txtFechaInicial"]);
var cal2 = new calendar(null, document.forms[0].elements["txtFechaFinal"]);
//-->
  </script>
</form>
</body>
</HTML>
