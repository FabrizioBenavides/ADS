<%@ Page CodeBehind="SucursalCrearCuenta.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSucursalCrearCuenta" Explicit="True" Trace="False" Strict="True" codePage="1252" EnableSessionState="False" enableViewState="False"%>

<html>
<head>
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<link href="css/menu.css" rel="stylesheet" type="text/css">
<link href="css/estilo.css" rel="stylesheet" type="text/css">
<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" type="text/JavaScript">
<!-- hide from JavaScript-challenged browsers


strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";


function window_onload() {
  var strTipoCuenta;
  var intTipoReferencia = <%=intTipoReferenciaId%>;
  var blnEsCredito = <%=blnEsCredito%>;
  var blnEsPorcentaje = <%=blnComisionEsPorcentaje%>;
  var cuentaPadre= <%=intCuentaPadreId%>;
  
  // Se asigna accion a la forma
  document.forms[0].action = "<%= strThisPageName %>";
  
  // Asignamos valores a los elementos de la forma
  document.forms[0].elements["txtCuentaId"].value = <%=intCuentaId%>;
  document.forms[0].elements["txtCuentaNombre"].value = "<%=strNombreCuenta%>";
  document.forms[0].elements["txtCuentaNombreId"].value = "<%=strNombreIdCuenta%>";
  document.forms[0].elements["txtDescripcion"].value = "<%=strDescripcionCuenta%>";
  document.forms[0].elements["txtCuentaNumero"].value = "<%=strNumeroBaan%>";
  document.forms[0].elements["txtCuentaComision"].value = <%=fltCuentaComision%>;

  // Especificamos el tipo de referencia establecida  
  document.forms[0].elements["cboTipoReferencia"].selectedIndex = intTipoReferencia;
  
  // Asignamos valores a los combobox
  <%= strLlenarTipoCuentaComboBox() %>
  <%= strLlenarCuentaPadreComboBox() %>
  <%= strLlenarDetalleReferenciaComboBox() %>
  <%= strLlenarUbicacionBancariaComboBox() %>
  
  // Asignamos valor al campo que sirve como referencia para identificar el tipo de cuenta  	
  strTipoCuenta = document.forms[0].elements["cboTipoCuenta"].options[document.forms[0].elements["cboTipoCuenta"].selectedIndex].text;
  
  // Ocultamos los combobox dependiendo de las opciones seleccionadas
  if (strTipoCuenta == "Cuenta Bancaria") {
	document.all.trCuentaPadre.style.display = "none";
	document.all.trTipoReferencia.style.display = "none";
	document.all.trDetalleReferencia.style.display = "none";
  }
  
  if (strTipoCuenta == "Cuenta Contable" ){
	  document.all.trTipoReferencia.style.display = "none";
	  document.all.trDetalleReferencia.style.display = "none";
  }
  
  if(document.forms[0].elements["cboTipoCuenta"].selectedIndex == 0){
     document.all.trCuentaPadre.style.display = "none";
     document.all.trTipoReferencia.style.display = "none";
	 document.all.trDetalleReferencia.style.display = "none";
  }
  
  if (document.forms[0].elements["cboTipoReferencia"].selectedIndex != 2){
	document.all.trUbicacionBancaria.style.display = "none";
  }
  
  document.forms[0].elements["txtTipoCuentaSeleccionada"].value = strTipoCuenta;
  
}

function cboTipoCuenta_OnChange(){

	var strTipoCuenta;
	
	strTipoCuenta = document.forms[0].elements["cboTipoCuenta"].options[document.forms[0].elements["cboTipoCuenta"].selectedIndex].text;
	document.forms[0].elements["txtTipoCuentaSeleccionada"].value = strTipoCuenta;
	document.forms[0].action += "?strCmd=Agregar";
	frmSucursalCrearCuenta.submit(); 
	
}

function cboTipoReferencia_OnChange(){
	document.forms[0].action += "?strCmd=Agregar";
  	frmSucursalCrearCuenta.submit(); 
}

function strCuentaId() {
  var intCuentaId = <%= intCuentaId %>;
  
  if (intCuentaId > 0){
	document.write(intCuentaId);
  }
  else{
	document.write("Cuenta Nueva");
  }
}

function blnFormValidator(theForm) {
  
  var blnReturn = false;
  
  /* Validación del campo "txtCuentaNombre" */
  if (blnValidarCampo(theForm.elements["txtCuentaNombre"], true, "Nombre de la Cuenta", cintTipoCampoAlfanumerico, 50, 1, "") == true) {
  
    /* Validación del campo "txtCuentaNombreId" */
    if (blnValidarCampo(theForm.elements["txtCuentaNombreId"], true, "Identificador de la cuenta", cintTipoCampoAlfanumerico, 50, 1, "")){
    
        /* Validación del campo "txtDescripcion" */
		if (blnValidarCampo(theForm.elements["txtDescripcion"], true, "Descripción de la cuenta", cintTipoCampoAlfanumerico, 255, 1, "")){
         
         /* Validación del campo "txtCuentaNumero" */
		 if (blnValidarCampo(theForm.elements["txtCuentaNumero"], true, "Número Baan", cintTipoCampoEntero, 11, 1, "")){
	
			/* Validación del campo "txtCuentaComision" */
            blnReturn = blnValidarCampo(theForm.elements["txtCuentaComision"], true, "Comisión", cintTipoCampoReal, 21, 1, "");
    
		 } 		  
	    }	
      }
    } 

  return (blnReturn);
}

function cmdSalvar_onclick() {
  document.forms[0].action += "?strCmd=<%= strCmd %>";
  return(true);
}


// done hiding -->
</script>
</head>
<body onload="return window_onload();">
<form method="POST" action="about:blank" name="frmSucursalCrearCuenta" onSubmit="return blnFormValidator(this)">
<input type="hidden" name="txtTipoCuentaSeleccionada" value="">
<input type="hidden" name="txtCuentaId">
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><script language="JavaScript">crearTablaHeader()</script></td>
  </tr>
</table>
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="10">&nbsp;</td>
    <td width="770" class="tdtab">Est&aacute; en : <a href="Sistema.htm">Sistema</a> : Cuentas : Crear cuenta </td>
  </tr>
</table>
<table width="780" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdgeneralcontent"><h1>Crear / Editar cuenta </h1>
      <table width="60%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td class="tdtexttablebold">Est&aacute; editando la cuenta </td>
          <td class="tdcontentableblue"><script language="javascript">strCuentaId()</script></td>
        </tr>
        <tr>
          <td width="33%" class="tdtexttablebold">Nombre de la cuenta: </td>
          <td width="67%" class="tdpadleft5"><input name="txtCuentaNombre" type="text" class="field" size="35" maxlength="50"></td>
        </tr>
        <tr>
          <td class="tdtexttablebold">Nombre ID de la cuenta:</td>
          <td class="tdpadleft5"><input name="txtCuentaNombreId" type="text" class="field" size="35" maxlength="50"></td>
        </tr>
        <tr>
          <td class="tdtexttablebold">Tipo de cuenta </td>
          <td class="tdpadleft5"><select name="cboTipoCuenta" class="field" onchange="cboTipoCuenta_OnChange();">
            <option value="0" selected>Elija un tipo de cuenta</option>
            </select>
          </td>
        </tr>
        <tr id="trCuentaPadre">
          <td class="tdtexttablebold">Cuenta padre </td>
          <td class="tdpadleft5"><select name="cboCuentaPadre" class="field">
            <option value="0">Elija una cuenta padre</option>
          </select></td>
        </tr>
        <tr id="trTipoReferencia">
          <td class="tdtexttablebold">Tipo de referencia</td>
          <td class="tdpadleft5"><select name="cboTipoReferencia" class="field" onchange="cboTipoReferencia_OnChange();">
            <option value="0" selected>Elija un tipo de referencia</option>
            <option value="1">Ninguno</option>
            <option value="2">Por forma de pago</option>
            <option value="3">Por tipo de ticket</option>
			<option value="4">Por departamento</option>
            <option value="5">Devoluciones</option>
          </select></td>
        </tr>
        <tr id="trDetalleReferencia">
          <td class="tdtexttablebold">Detalle de referencia </td>
          <td class="tdpadleft5"><select name="cboDetalleReferencia" class="field">
            <option value="0">Elija una opción</option>
          </select></td>
        </tr>
        <tr id="trUbicacionBancaria">
          <td class="tdtexttablebold">Ubicación Bancaria </td>
          <td class="tdpadleft5"><select name="cboUbicacionBancaria" class="field">
            <option value="0">Elija una opción</option>
          </select></td>
        </tr>
        <tr>
          <td valign="top" class="tdtexttablebold">Descripci&oacute;n:</td>
          <td class="tdpadleft5"><textarea name="txtDescripcion" cols="37" rows="5" class="fieldcomment"></textarea></td>
        </tr>
        <tr>
          <td class="tdtexttablebold">N&uacute;mero BAAN </td>
          <td class="tdpadleft5"><input name="txtCuentaNumero" type="text" class="field" size="35" maxlength="50"></td>
        </tr>
        <tr>
          <td class="tdtexttablebold">&nbsp;</td>
          <td class="tdtexttablereg"><input type="checkbox" name="chkEsCredito" value="1">Es cuenta de cr&eacute;dito </td>
        </tr>
        <tr>
          <td class="tdtexttablebold">Comisi&oacute;n que cobra </td>
          <td class="tdpadleft5"><input name="txtCuentaComision" type="text" class="field" size="35" maxlength="35" value="0.00"></td>
        </tr>
        <tr>
          <td class="tdtexttablebold">&nbsp;</td>
          <td class="tdtexttablereg"><input type="checkbox" name="chkComisionEsPorcentaje" value="1">
            &iquest;La comisi&oacute;n es en porcentaje? </td>
        </tr>
        <tr>
          <td height="10" colspan="2" valign="top"><img src="images/pixel.gif" width="1" height="10"></td>
        </tr>
        <tr>
          <td valign="top" class="tdtexttablebold">&nbsp;</td>
          <td class="tdpadleft5"><input type="button" name="cmdCancelar" value="Cancelar" class="button" onclick="window.location='SucursalAdministrarCuentas.aspx'">
          &nbsp;&nbsp;
          <input type="submit" name="cmdSalvar" value="Guardar cuenta" class="button" onclick="cmdSalvar_onclick();"></td>
        </tr>
      </table>
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
</html>

