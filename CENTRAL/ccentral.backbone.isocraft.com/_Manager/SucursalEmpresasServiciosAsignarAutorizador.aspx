<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalEmpresasServiciosAsignarAutorizador.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalEmpresasServiciosAsignarAutorizador"%>
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
   <%= strLlenarAutorizadorComboBox() %>
   
   if("<%= strCmd %>" == "Asignar")
	{
   
		document.forms[0].elements["txtEmpresaServicioId"].value = "<%= intEmpresaServicioId %>";
		document.forms[0].elements["txtEmpresaServicioNombre"].value = "<%= strEmpresaServicioNombre %>";
		   
		document.forms[0].elements["txtEmpresaServicioIdAnterior"].value = "<%= intEmpresaServicioIdAnterior %>";
		if("<%= intAutorizadorId %>" != "0")
		{
		document.forms[0].elements["txtCodigoServicio"].value = "<%= strEmpresaServicioCodigoServicio %>";
		document.forms[0].elements["txtComisionCompartida"].value = "<%= fltEmpresaServicioComisionCompartida %>";
		document.forms[0].elements["chkAutorizadorActivo"].checked = <%= blnEmpresaServicioAutorizadorActivo.ToString().ToLower()  %>;
		document.forms[0].elements["txtEmpresaServicioInformacionTicket"].value = "<%= strEmpresaServicioInformacionTicket %>";
		}
   }
   else
   {
		if ("<%= strEmpresaServicioAutorizadorMensaje %>" == "Error")
		{
			alert("No es posible asignar un segundo autorizador si ya existe otro activo");
		    document.forms[0].elements["txtCodigoServicio"].value = "<%= strEmpresaServicioCodigoServicio %>";
		    document.forms[0].elements["txtComisionCompartida"].value = "<%= fltEmpresaServicioComisionCompartida %>";
		    document.forms[0].elements["chkAutorizadorActivo"].checked = <%= blnEmpresaServicioAutorizadorActivo.ToString().ToLower()  %>;
		    document.forms[0].elements["txtEmpresaServicioInformacionTicket"].value = "<%= strEmpresaServicioInformacionTicket %>";
			
		}
   }
   
   document.forms[0].txtCodigoServicio.focus();
   
   <%= strJavascriptWindowOnLoadCommands %>
}

function cmdGuardar_onclick() {
   var blnReturn = blnFormValidator();
   
   if ( blnReturn == true) {
       document.forms[0].action += "?strCmd=Salvar&intEmpresaServicioId=<%= intEmpresaServicioId %>";
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
   
   		/* Validación del campo "txtCodigoServicioId" */
		if(blnValidarCampo(document.forms[0].elements["txtCodigoServicio"], true, "Código de servicio", cintTipoCampoAlfanumerico, 80, 1, "") == true)
		{
   			
           			/*Validación del campo "txtComisionCompartida" */
					if(blnValidarCampo(document.forms[0].elements["txtComisionCompartida"], true, "Comisión Compartida", cintTipoCampoAlfanumerico, 50, 1, "") == true) 
					{
						/*Validar decimales campo txtEmpresaServicioComsion*/
						 if (checkDecimals(document.forms[0].elements["txtComisionCompartida"],document.forms[0].elements["txtComisionCompartida"].value,"Comisión Compartida")== true) {
						 
						 /* Validar que haya seleccionado un Autorizador */
		                 if (document.forms[0].cboAutorizador[0].selected){
		                     alert("Por favor seleccione un autorizador");
		                     document.forms[0].elements["cboAutorizador"].focus();
		                     blnReturn = false;
		                     }
		                     else
		                     {
		                     blnReturn = true;
		                     }    
							
						}

					}				
		}
		
				          
   return (blnReturn);
}

function cboAutorizador_onchange()
{
  var selectedOption;
  selectedOption = document.forms[0].elements["cboAutorizador"].value;
  window.location.href="SucursalEmpresasServiciosAsignarAutorizador.aspx?strCmd=Asignar&intEmpresaServicioId=<%= intEmpresaServicioId %>&intAutorizadorId=" + selectedOption ;
  form.submit();
  
}

//-->
				</script>
	</HEAD>
	<body language="javascript" onload="return window_onload()">
		<form name="frmPage" action="about:blank" method="post">
			&nbsp;
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
							Administrar Empresas </A>: Asignar Autorizadores
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td class="tdgeneralcontent">
						<h1>Asignar&nbsp;Autorizadores</h1>
						<p>Aquí podrá asignar un autorizador a una empresa de servicio.</p>
						<h2>Datos de la Empresa de Servicio</h2>
						<table cellSpacing="0" cellPadding="0" border="0" height="383">
							<tr>
								<td class="tdtexttablebold" width="164" height="46"><label for="txtEmpresaNombre">Nombre de la Empresa:</label>
								</td>
								<td class="tdpadleft5"><input class="campotablaresultado" id="txtEmpresaServicioNombre" readOnly type="text" maxLength="50"
										size="80" name="txtEmpresaServicioNombre">
								</td>
							</tr>
							<TR>
								<td class="tdtexttablebold" width="164"></td>
								<td class="tdpadleft5"></td>
							<tr>
								<td class="tdtexttablebold" vAlign="middle">
									<h2>Definir Autorizador</h2>
								</td>
								<td class="tdpadleft5"></td>
							</tr>
							<tr>
								<td class="tdtexttablebold" width="164" height="46"><label for="txtAutorizador">Autorizador:</label>
								</td>
								<td class="tdpadleft5"><select class="campotabla" id="cboAutorizador" name="cboAutorizador" onchange="cboAutorizador_onchange()">
										<option value="0" selected>» Elija un Autorizador «</option>
									</select>
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" width="168" height="46">
									<label for="txtEmpresaNombre">Código de servicio (Guía CIE):</label>
								</td>
								<td class="tdpadleft5"><input class="field" id="txtCodigoServicio" type="text" maxLength="15" size="20" name="txtCodigoServicio">
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" width="164" height="46"><label for="txtEmpresaNombre">Comisión compartida:</label>
								</td>
								<td class="tdpadleft5"><input class="field" id="txtComisionCompartida" type="text" maxLength="10" size="20" name="txtComisionCompartida">
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" width="164">¿Autorizador Activo?
								</td>
								<td class="tdpadleft5"><input class="fieldborderless" id="chkAutorizadorActivo" type="checkbox" CHECKED value="True"
										name="chkAutorizadorActivo">
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" width="164"><label for="txtInformacionTicket">Información del 
            Ticket:</label>
								</td>
							</tr>
							<tr>
								<td class="tdpadleft5" vAlign="top" width="164"><TEXTAREA class="txaccion" id="txtEmpresaServicioInformacionTicket" name="txtEmpresaServicioInformacionTicket"
										rows="10" cols="20"></TEXTAREA>
								</td>
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
