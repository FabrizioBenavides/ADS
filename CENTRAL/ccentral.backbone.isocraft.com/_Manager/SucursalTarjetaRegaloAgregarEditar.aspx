<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalTarjetaRegaloAgregarEditar.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalTarjetaRegaloAgregarEditar"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
		<meta content="text/html; charset=iso-8859-1" http-equiv="Content-Type">
		<LINK rel="stylesheet" type="text/css" href="css/menu.css">
			<LINK rel="stylesheet" type="text/css" href="css/estilo.css">
				<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
				<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
				<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
				<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
				<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
				<script language="JavaScript" src="js/calendario.js"></script>
				<script language="JavaScript" src="js/cal_format00.js"></script>
				<script id="clientEventHandlersJS" language="javascript"></script>
				<script language="JavaScript" type="text/JavaScript">
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() 
{   
   document.forms[0].action = "<%= strFormAction %>";
   
   if("<%= strCmd %>" == "Editar")
	{
   
		document.forms[0].elements["txtTarjetaRegaloId"].value = "<%= intTarjetaRegaloId %>";
		document.forms[0].elements["txtTarjetaRegaloCodigoProducto"].value = "<%= strTarjetaRegaloCodigoProducto %>";
		document.forms[0].elements["txtTarjetaRegaloDescripcion"].value = "<%= strTarjetaRegaloDescripcion %>";
		document.forms[0].elements["chkTarjetaRegaloEliminado"].checked = <%= blnTarjetaRegaloEliminado.ToString().ToLower() %>;
		document.forms[0].elements["txtTarjetaRegaloMonto"].value = "<%= fltTarjetaRegaloMonto %>";
		document.forms[0].elements["txtTarjetaRegaloMontoaCobrar"].value = "<%= fltTarjetaRegaloMontoaCobrar %>";
		document.forms[0].elements["txtTarjetaRegaloCodigoProducto"].disabled = true;
		//La asignacion al campo del valor al campo txtTarjetaRegaloDescripcion se encuentra en la seccion de html debido a que no se encontro la manera de realizarlo con javascript
	}
   else
   {
        //No hacer nada
   }
   
   document.forms[0].txtTarjetaRegaloDescripcion.focus();
   
   <%= strJavascriptWindowOnLoadCommands %>
}

function cmdGuardar_onclick() {
   var blnReturn = blnFormValidator();
      
   if ( blnReturn == true) {
       document.forms[0].action += "?strCmd=Salvar&intTarjetaRegaloId=" + <%= intTarjetaRegaloId %>;
   }
   
   return (blnReturn);
}


function cmdCancelar_onclick() {
   window.location.href = "SucursalAsignacionDeArticuloTarjetaRegalo.aspx";
}


function blnFormValidator() 
{
   var blnReturn = false;
      		
   			/* Validación del campo "txtTipoServicioVirtualDescripcion" */
			if(blnValidarCampo(document.forms[0].elements["txtTarjetaRegaloDescripcion"], true, "Descripcion De La Tarjeta de Regalo", cintTipoCampoAlfanumerico, 80, 1, "") == true)
			{
        		blnReturn = true;
        	}	
			else 
           	{
           		document.forms[0].elements["txtTarjetaRegaloDescripcion"].focus();
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
		<form method="post" name="SucursalTarjetaRegaloAgregarEditar" action="about:blank">
			<table border="0" cellSpacing="0" cellPadding="0" width="780">
				<tr>
					<td>
						<script language="JavaScript">crearTablaHeader()</script>
					</td>
				</tr>
			</table>
			<table border="0" cellSpacing="0" cellPadding="0" width="780">
				<tr>
					<td width="10">&nbsp;</td>
					<td class="tdtab" width="770">Está en : <A href="SucursalHome.aspx">Sucursal</A> : <A href="SucursalTipoServicioVirtual.aspx">
							Tarjeta Regalo :</A> <A>Agregar - Editar Tipo Tarjeta de Regalo&nbsp; </A>
					</td>
				</tr>
			</table>
			<table border="0" cellSpacing="0" cellPadding="0" width="780">
				<tr>
					<td class="tdgeneralcontent">
						<h1>Datos de la Tarjeta de Regalo</h1>
						<p>Aquí podrá dar de alta y modifica las Tarjetas de Regalo.</p>
						<h2>Definir Tarjeta De Regalo</h2>
						<table border="0" cellSpacing="0" cellPadding="0">
							<tr>
								<td class="tdtexttablebold" height="46" width="230"><label for="txtEmpresaDEX">Descripcion 
										de la Tarjeta:</label>
								</td>
								<td class="tdpadleft5" width="402"><input id="txtTarjetaRegaloDescripcion" class="field" maxLength="255" size="80" name="txtTarjetaRegaloDescripcion">
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" height="46" width="230"><label for="txtEmpresaNombre">Codigo 
										de la Tarjeta:</label>
								</td>
								<td class="tdpadleft5" width="402"><input id="txtTarjetaRegaloCodigoProducto" class="field" maxLength="255" size="80" name="txtTarjetaRegaloCodigoProducto">
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" height="62" width="230"><label for="txtEmpresaNombre">Texto 
										de Impresion:</label>
								</td>
								<td class="tdpadleft5" width="402" height="61">
									<textarea id="txtTarjetaRegaloTextoImprimir" name="txtTarjetaRegaloTextoImprimir" cols="47"
										rows="3">								<%= strTarjetaRegaloTextoImprimir %>
									</textarea>
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" height="46" width="230"><label for="txtEmpresaNombre">Monto 
										de La Tarjeta:</label>
								</td>
								<td class="tdpadleft5" width="402"><input id="txtTarjetaRegaloMonto" class="field" maxLength="255" size="80" name="txtTarjetaRegaloMonto"
										onkeypress="return isNumber()">
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" height="46" width="230"><label for="txtEmpresaNombre">Monto 
										a Cobrar de La Tarjeta:</label>
								</td>
								<td class="tdpadleft5" width="402"><input class="field" id="txtTarjetaRegaloMontoaCobrar" maxLength="255" size="80" name="txtTarjetaRegaloMontoaCobrar"
										onkeypress="return isNumber()">
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" height="46" width="168"><label for="txtFacturaVenta">Tarjeta Eliminada:</label>
								</td>
								<td class="tdpadleft5" width="402">&nbsp;<INPUT style="Z-INDEX: 0" id="chkTarjetaRegaloEliminado" class="fieldborderless" value="True"
										type="checkbox" name="chkTarjetaRegaloEliminado">
								</td>
							<tr>
								<td class="txaccion" vAlign="top" align="right" colSpan="2" height="10" width="632">&nbsp;</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" vAlign="top" colSpan="2" width="632"><input language="javascript" class="button" id="cmdCancelar" onclick="return cmdCancelar_onclick()"
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
			<input type="hidden" name="txtTarjetaRegaloIdAnterior"> <input type="hidden" name="txtTarjetaRegaloId">
			<script language="JavaScript">
    <!--
    new menu (MENU_ITEMS, MENU_POS);
    //-->
			</script>
		</form>
	</body>
</HTML>
