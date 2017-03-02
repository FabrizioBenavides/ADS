<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalEmpresasServiciosEditarSucursalEmpresa.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalEmpresasServiciosEditarSucursalEmpresa"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="css/menu.css" type="text/css" rel="stylesheet">
			<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
				<script language="JavaScript" src="js/menu.js" type="text/JavaScript"></script>
				<script language="JavaScript" src="js/menu_items.js" type="text/JavaScript"></script>
				<script language="JavaScript" src="js/menu_tpl.js" type="text/JavaScript"></script>
				<script language="JavaScript" src="js/headerfooter.js" type="text/JavaScript"></script>
				<script language="JavaScript" src="../static/scripts/Tools.js" type="text/JavaScript"></script>
				<script language="JavaScript" src="js/calendario.js"></script>
				<script language="JavaScript" src="js/cal_format00.js"></script>
				<script language="javascript" id="clientEventHandlersJS">
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() 
{   
   document.forms[0].action = "<%= strFormAction %>";
   <%= strLlenarFormaPagoComboBox() %>
   
		document.forms[0].elements["txtEmpresaServicioId"].value = "<%= intEmpresaServicioId %>";
		document.forms[0].elements["txtEmpresaServicioNombre"].value = "<%= strEmpresaServicioNombre %>";
		
        document.forms[0].elements["txtCompaniaId"].value = "<%= intCompaniaId %>";
        document.forms[0].elements["txtSucursalId"].value = "<%= intSucursalId %>";  
        document.forms[0].elements["txtSucursalNombre"].value = "<%= strSucursalNombre %>";
   
		document.forms[0].elements["txtEmpresaServicioIdAnterior"].value = "<%= intEmpresaServicioIdAnterior %>";
   
   document.forms[0].txtMontoMaximo.focus();
   
   <%= strJavascriptWindowOnLoadCommands %>
}

function cmdGuardar_onclick() {
   var blnReturn = blnFormValidator();
   if ( blnReturn == true) {
      
       document.forms[0].action += "?strCmd=Salvar";
       document.forms(0).submit();
   }
   return (blnReturn);
}


function cmdCancelar_onclick() {
   window.location.href = "SucursalEmpresasServiciosAdministrarEmpresas.aspx";
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

function blnFormValidator() 
{
   var blnReturn = false;
   
   /*Validación del campo "txtMontoMaximo" */
   if(blnValidarCampo(document.forms[0].elements["txtMontoMaximo"], true, "Monto Máximo", cintTipoCampoAlfanumerico, 50, 1, "") == true) 
   {
     /*Validar decimales campo txtEmpresaServicioComsion*/
	 if (checkDecimals(document.forms[0].elements["txtMontoMaximo"],document.forms[0].elements["txtMontoMaximo"].value,"Monto Máximo")== true) {
		/* Validar que haya seleccionado una Forma de Pago */
		if (document.forms[0].cboFormaPago[0].selected){
		alert("Por favor seleccione una forma de Pago");
		document.forms[0].elements["cboFormaPago"].focus();
		blnReturn = false;
		}
		else
		{
		blnReturn = true;
		}    
	 }
   }         
   return (blnReturn);
}

//-->
				</script>
	</HEAD>
	<body language="javascript" onload="return window_onload()">
		<form name="frmPage" action="about:blank" method="post">
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
							Empresas de Servicios :</A> <A href="SucursalEmpresasServiciosAdministrarEmpresas.aspx">
							Administrar Empresas </A>: <A href="SucursalEmpresasServiciosAgregarEmpresa">Asignar 
							Empresa</A>: Editar Montos
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td class="tdgeneralcontent">
						<h1>Editar Montos Máximos</h1>
						<p>Aquí podrá editar la configuración de los montos máximos de la empresa de 
							servicio en una sucursal.</p>
						<h2>Datos de la Empresa de Servicio</h2>
						<table cellSpacing="0" cellPadding="0" border="0">
							<tr>
								<td class="tdtexttablebold" width="164" height="46"><label for="txtEmpresaNombre">Nombre 
										de la Empresa:</label>
								</td>
								<td class="tdpadleft5"><input class="campotablaresultado" id="txtEmpresaServicioNombre" readOnly type="text" maxLength="50"
										size="80" name="txtEmpresaServicioNombre">
								</td>
							</tr>
							<!--
							<tr>
								<td class="tdtexttablebold" width="164"><label for="chkEmpresaActiva">¿Activa?</label>
								</td>
								<td class="tdpadleft5"><input class="fieldborderless" id="chkEmpresaServicioActiva" readOnly type="checkbox" CHECKED
										value="True" name="chkEmpresaServicioActiva">
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" width="164"><label for="chkSolicitarRecaptura">¿Solicitar 
										Recaptura?</label>
								</td>
								<td class="tdpadleft5"><INPUT class="fieldborderless" id="chkEmpresaServicioSolicitarRecaptura" readOnly type="checkbox"
										CHECKED value="True" name="chkEmpresaServicioSolicitarRecaptura">
								</td>
							</tr>
							-->
							<TR>
								<td class="tdtexttablebold" width="164">
								</td>
								<td class="tdpadleft5">
								</td>
							<tr>
								<td class="tdtexttablebold" valign="middle"><h2>Datos de la Sucursal</h2>
								</td>
								<td class="tdpadleft5">
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" width="120">
									<p><label for="txtCompaniaId">Compania:</label>
									</p>
								</td>
								<td class="tdpadleft5" width="499"><input class="campotablaresultado" id="txtCompaniaId" readOnly type="text" maxLength="80"
										size="80" name="txtCompaniaId" value="17">
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" width="120">
									<p><label for="txtSucursalId">Sucursal:</label>
									</p>
								</td>
								<td class="tdpadleft5" width="499"><input class="campotablaresultado" id="txtSucursalId" readOnly type="text" maxLength="80"
										size="80" name="txtSucursalId" value="47">
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold"><label for="txtSucursalNombre">Nombre:</label>
								</td>
								<td class="tdpadleft5"><input class="campotablaresultado" id="txtSucursalNombre" readOnly type="text" maxLength="80"
										size="80" name="txtSucursalNombre" value="Suc. Vasconselos">
								</td>
							</tr>
							<TR>
								<td class="tdtexttablebold" width="164">
								</td>
								<td class="tdpadleft5">
								</td>
							<tr>
								<td class="tdtexttablebold" valign="middle"><h2>Configuración de Montos</h2>
								</td>
								<td class="tdpadleft5">
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" width="120">Forma de Pago:</td>
								<td class="tdpadleft5" width="499"><select class="campotabla" id="cboFormaPago" name="cboFormaPago">
										<option value="0" selected>» Elija una Forma de Pago «</option>
									</select>
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" width="120">Monto Máximo:</td>
								<td class="tdpadleft5" width="499"><input class="field" id="txtMontoMaximo" type="text" maxLength="20" size="20" name="txtMontoMaximo"></td>
							</tr>
							<tr>
								<td class="txaccion" vAlign="top" align="right" colSpan="2" height="10">&nbsp;</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" vAlign="top" colSpan="2"><input language="javascript" class="button" id="cmdCancelar" onclick="return cmdCancelar_onclick()"
										type="button" value="Regresar" name="cmdCancelar"> <input language="javascript" class="button" id="cmdGuardar" onclick="return cmdGuardar_onclick()"
										type="submit" value="Guardar" name="cmdGuardar">
								</td>
							</tr>
						</table>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td>
									<%= strGetRecordBrowserHTML() %>
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
			<input type="hidden" name="txtEmpresaServicioIdAnterior"> <input type="hidden" name="txtEmpresaServicioId">
			<script language="JavaScript">
    <!--
    new menu (MENU_ITEMS, MENU_POS);
    //-->
			</script>
		</form>
	</body>
</HTML>
