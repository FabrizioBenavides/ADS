<%@ Page Language="vb" AutoEventWireup="false" Codebehind="popEmpresasServiciosAsignarSucursalesAEmpresa.aspx.vb" Inherits="com.isocraft.backbone.ccentral.popEmpresasServiciosAsignarSucursalesAEmpresa" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HEAD>
	<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
</HEAD>
<BODY language="javascript" onload="return window_onload()">
	<link href="css/estilo.css" rel="stylesheet" type="text/css">
		<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/tools.js"></script>
		<script language="JavaScript" src="../static/scripts/Tools.js"></script>
		<script id="clientEventHandlersJS" language="javascript">
<!--

function window_onload() {
        
   document.forms[0].action = "<%= strFormAction %>";
   
   var intDireccionId = "<%= intDireccionId %>";
   var intZonaId = "<%= intZonaId %>";
   
   document.forms[0].elements["txtEmpresaServicioId"].value = "<%= intEmpresaServicioId %>";   
   document.forms[0].elements["txtEmpresaServicioIdOculto"].value = "<%= intEmpresaServicioIdOculto %>";
   document.forms[0].elements["txtComisionOculto"].value = "<%= fltComision %>";
        
   <%= strJavascriptWindowOnLoadCommands %>
   <%= strLlenarDireccionComboBox() %>
   <%= strLlenarZonaComboBox() %>
   <%= strLlenarSucursalComboBox() %>
   <%= strLlenarFormaPagoComboBox() %>   
   
   /* Deshabilitamos las zonas, si se han seleccionado todas las direcciones */
   if (intDireccionId == "-1") {
       document.forms[0].elements["cboDireccion"].options[1].selected = true;
       document.forms[0].elements["cboZona"].disabled = true;
   }
   
   if (intZonaId == "-1") {
       document.forms[0].elements["cboZona"].options[1].selected = true;
   }
   
   /* Deshabilitamos la opción de seleccionar todas las sucursales y el botón asignar,
      si no hay sucursales */
  if (document.forms[0].elements["cboSucursales"].length == 0) {
    document.forms[0].elements["chkSeleccionarTodasSucursales"].disabled = true;
    document.forms[0].elements["cmdAsignar"].disabled = true;
  }

}

function cboDireccion_onchange() {
  if (document.forms[0].elements["cboDireccion"].selectedIndex > 0) {
    document.forms[0].elements["cboZona"].selectedIndex = 0;
    document.forms[0].submit();
  }
  return(true);
}

function cboZona_onchange() {
  if (document.forms[0].elements["cboZona"].selectedIndex > 0) {
    document.forms[0].submit();
  }
}

function chkSeleccionarTodasSucursales_onclick() {
  SelectAllComboBoxElements(document.forms[0].elements["cboSucursales"], document.forms[0].elements["chkSeleccionarTodasSucursales"].checked);
}

function cmdCancelar_onclick() {
  window.close();
}

function cmdAsignar_onclick() {
  var MontoMaximo = 0
  MontoMaximo = parseFloat(document.forms[0].txtMontoMaximo.value);
  
   /*Validación del campo "txtMontoMaximo" */
   if(blnValidarCampo(document.forms[0].elements["txtMontoMaximo"], true, "Monto Máximo", cintTipoCampoAlfanumerico, 50, 1, "") == false) 
   {
    document.forms[0].elements["txtMontoMaximo"].focus();
    return(false);
   }  
   
   /*Validar decimales campo txtMontoMaximo*/
   if (checkDecimals(document.forms[0].elements["txtMontoMaximo"],document.forms[0].elements["txtMontoMaximo"].value,"Monto Máximo")== false) 
   {
    document.forms[0].elements["txtMontoMaximo"].focus();
    return(false);
   }
   
   if (blnComboBoxHasAnElementSelected(document.forms[0].elements["cboSucursales"]) == false) 
   {
    alert("Por favor seleccione al menos una sucursal.");
    document.forms[0].elements["cboSucursales"].focus();
    return(false);
   }
  
   if (document.forms[0].cboFormaPago[0].selected)
   {
    alert("Por favor seleccione una forma de pago.");
    document.forms[0].elements["cboFormaPago"].focus();
    return(false);
   } 
  
  document.forms[0].action += "?strCmd=Asignar";
  return(true);
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

//-->
		</script>
		<form method="post" action="about:blank" name="frmPage">
			<table width="360" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td><script language="JavaScript">crearTablaHeaderPop()</script>
					</td>
				</tr>
			</table>
			<table width="360" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td class="tdgeneralcontentpop"><h2>Asignar sucursales
						</h2>
						<table width="100%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td width="19%" class="tdtexttablebold">Dirección:</td>
								<td width="81%" class="tdpadleft5"><select name="cboDireccion" class="field" id="cboDireccion" language="javascript" onchange="return cboDireccion_onchange()">
										<option value="0" selected>--- Elija una dirección ---</option>
										<option value="-1">Todas las direcciones</option>
									</select>
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold">Zona:</td>
								<td class="tdpadleft5"><select name="cboZona" class="field" id="cboZona" language="javascript" onchange="return cboZona_onchange()">
										<option value="0" selected>Elija una zona</option>
										<option value="-1">Todas las zonas</option>
									</select>
								</td>
							</tr>
						</table>
						<br>
						<p>Elija la(s) sucursal(es) que desea asignar a la empresa, y oprima el botón 
							“Asignar”. Para elegir más de una sucursal, haga clic en los nombres 
							correspondientes.
						</p>
						<table width="100%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td class="tdtexttablebold"><input name="chkSeleccionarTodasSucursales" type="checkbox" id="chkSeleccionarTodasSucursales"
										value="True" language="javascript" onclick="return chkSeleccionarTodasSucursales_onclick()">
									&nbsp;Seleccionar todas</td>
							</tr>
							<tr>
								<td class="tdblueframe"><select name="cboSucursales" size="10" multiple class="fieldcomment" id="cboSucursales">
									</select>
								</td>
							</tr>
						</table>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="tdtexttablebold" width="30%">Forma de Pago:</td>
								<td class="tdtexttablebold" width="30%">Monto Máximo:</td>
							</tr>
							<tr>
							<td class="tdpadleft5" width="70%"><select class="fieldcomment" id="cboFormaPago" name="cboFormaPago" size="10" multiple>
										<option value="0" selected>» Elija una Forma de Pago «</option>
									</select>
								</td>
								<td class="tdpadleft5" width="70%" valign='top'><input class="field" id="txtMontoMaximo" type="text" maxLength="20" size="20" name="txtMontoMaximo"></td>
							</tr>
						</table>
						<br>
						<span class="tdpadleft5"><input name="cmdCancelar" type="button" class="button" id="cmdCancelar" value="Cancelar"
								language="javascript" onclick="return cmdCancelar_onclick()"> &nbsp;&nbsp; <input name="cmdAsignar" type="submit" class="button" id="cmdAsignar" value="Asignar" language="javascript"
								onclick="return cmdAsignar_onclick()"> </span>
					</td>
				</tr>
			</table>
			<input name="txtEmpresaServicioId" type="hidden"> <input name="txtEmpresaServicioIdOculto" type="hidden">
			<br>
			<INPUT type="hidden" name="txtComisionOculto">
			<table width="360" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td><script language="JavaScript">crearTablaFooterPop()</script>
					</td>
				</tr>
			</table>
		</form>
</BODY>
