<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalDineroExpressAgregarEditar.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalDineroExpressAgregarEditar"%>
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
		<script language="javascript" id="clientEventHandlersJS"></script>
		<script language="JavaScript" type="text/JavaScript">
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() 
{   
   document.forms[0].action = "<%= strFormAction %>";
   
   if("<%= strCmd %>" == "Editar")
	{
   
		document.forms[0].elements["txtTipoOperacionDEXNombreId"].value = "<%= strTipoOperacionDEXNombreId %>";
		document.forms[0].elements["txtTipoOperacionDEXNombre"].value = "<%= strTipoOperacionDEXNombre %>";
		document.forms[0].elements["txtTipoOperacionDEXNombreId"].disabled = true;
	}
   else
   {
        //No hacer nada
   }
   
   document.forms[0].txtTipoOperacionDEXNombreId.focus();
   
   <%= strJavascriptWindowOnLoadCommands %>
}

function cmdGuardar_onclick() {
   var blnReturn = blnFormValidator();
      
   if ( blnReturn == true) {
       document.forms[0].action += "?strCmd=Salvar&intTipoOperacionDEXId=" + <%= intTipoOperacionDEXId %>;
   }
   
   return (blnReturn);
}


function cmdCancelar_onclick() {
   window.location.href = "SucursalAsignacionDeArticuloDineroExpress.aspx";
}


function blnFormValidator() 
{
   var blnReturn = false;
      		
   			/* Validación del campo "txtTipoServicioVirtualDescripcion" */
			if(blnValidarCampo(document.forms[0].elements["txtTipoOperacionDEXNombreId"], true, "Descripcion Del La Operacion DEX", cintTipoCampoAlfanumerico, 80, 1, "") == true)
			{
        		blnReturn = true;
        	}	
			else 
           	{
           		document.forms[0].elements["txtTipoOperacionDEXNombreId"].focus();
           		blnReturn = false;
			}
			
   return (blnReturn);
}

// PPSV JPMB 16/07/2013 Función que verifica si se estan introduciendo datos numéricos
// Entra Como Parte de La Validacion del Bug De las Lista 
function isNumber()
{
	var charCode = event.keyCode;
	if (charCode > 31 && (charCode < 48 || charCode > 57))
	{
		return false;
	}
	return true;
}

//-->
		</script>
	</HEAD>
	<body onload="window_onload();">
		<form name="SucursalDineroExpressAgregarEditar" action="about:blank" method="post">
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
					<td class="tdtab" width="770">Está en : <A href="SucursalHome.aspx">Sucursal</A> : <A href="SucursalTipoServicioVirtual.aspx">
							Tipo Servicio :</A> <A>Agregar - Editar Tipo de Servicio&nbsp; </A>
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td class="tdgeneralcontent">
						<h1>Datos del Tipo de Operacion DEX</h1>
						<p>Aquí podrá dar de alta y modificar un tipo de Operaciones DEX.</p>
						<h2>Definir tipo de Operacion DEX</h2>
						<table cellSpacing="0" cellPadding="0" border="0">
							<tr>
								<td class="tdtexttablebold" width="230" height="46"><label for="txtEmpresaDEX">Tipo Operacion DEX:</label>
								</td>
								<td class="tdpadleft5"><input class="field" id="txtTipoOperacionDEXNombreId" maxLength="255" size="80" name="txtTipoOperacionDEXNombreId">
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" width="230" height="46"><label for="txtEmpresaNombre">Descripción 
										de la Operacion DEX:</label>
								</td>
								<td class="tdpadleft5"><input class="field" id="txtTipoOperacionDEXNombre" maxLength="255" size="80" name="txtTipoOperacionDEXNombre">
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
			<input type="hidden" name="intTipoOperacionDEXIdAnterior"> <input type="hidden" name="intTipoOperacionDEXId">
			<script language="JavaScript">
    <!--
    new menu (MENU_ITEMS, MENU_POS);
    //-->
			</script>
		</form>
	</body>
</HTML>
