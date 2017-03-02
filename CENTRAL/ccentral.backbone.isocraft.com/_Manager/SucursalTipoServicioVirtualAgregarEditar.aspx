<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalTipoServicioVirtualAgregarEditar.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalTipoServicioVirtualAgregarEditar" %>
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
   
		document.forms[0].elements["txtTipoServicioVirtualDescripcion"].value = "<%= strTipoServicioVirtualDescripcion %>";
		document.forms[0].elements["chkAplicarDevolucion"].checked= <%= blnTipoServicioVirtualAplicaDevolucion.ToString.ToLower() %>;
		// JPMB , Para Administracion de la pagina , en Central 
		document.forms[0].elements["chkMuestaenPuntodeVenta"].checked= <%= blnTipoServicioVirtualMuestraenPuntodeVenta.ToString.ToLower() %>;
		
	}
   else
   {
        //No hacer nada
   }
   
   document.forms[0].txtTipoServicioVirtualDescripcion.focus();
   
   <%= strJavascriptWindowOnLoadCommands %>
}

function cmdGuardar_onclick() {
   var blnReturn = blnFormValidator();
      
   if ( blnReturn == true) {
       document.forms[0].action += "?strCmd=Salvar&intTipoServicioId=" + <%= intTipoServicioVirtualId %>;
   }
   
   return (blnReturn);
}


function cmdCancelar_onclick() {
   window.location.href = "SucursalTipoServicioVirtual.aspx";
}


function blnFormValidator() 
{
   var blnReturn = false;
      		
   			/* Validación del campo "txtTipoServicioVirtualDescripcion" */
			if(blnValidarCampo(document.forms[0].elements["txtTipoServicioVirtualDescripcion"], true, "Descripcion del tipo de servicio", cintTipoCampoAlfanumerico, 80, 1, "") == true)
			{
        		blnReturn = true;
        	}	
			else 
           	{
           		document.forms[0].elements["txtTipoServicioVirtualDescripcion"].focus();
           		blnReturn = false;
			}
			
   return (blnReturn);
}

//-->
				</script>
	</HEAD>
	<body onload="window_onload();">
		<form method="post" name="SucursalEmpresasServiciosAgregarEmpresa" action="about:blank">
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
							Tipo Servicio :</A> <A>Agregar - Editar Tipo de Servicio&nbsp; </A>
					</td>
				</tr>
			</table>
			<table border="0" cellSpacing="0" cellPadding="0" width="780">
				<tr>
					<td class="tdgeneralcontent">
						<h1>Datos del Tipo de Servicio Virtual</h1>
						<p>Aquí podrá dar de alta y modificar un tipo de servicio virtual.</p>
						<h2>Definir tipo de servicio virtual</h2>
						<table border="0" cellSpacing="0" cellPadding="0">
							<tr>
								<td class="tdtexttablebold" height="34" width="231"><label for="txtEmpresaNombre">Descripción del Tipo de Servicio 
            Virtual:</label>
								</td>
								<td class="tdpadleft5" height="34"><input id="txtTipoServicioVirtualDescripcion" class="field" maxLength="255" size="80" name="txtTipoServicioVirtualDescripcion">
								</td>
							</tr>
							<TR>
								<TD class="tdtexttablebold" height="34" width="231"><LABEL style="Z-INDEX: 0" for="txtEmpresaNombre"><LABEL for="txtEmpresaNombre">Aplica Devolución:</LABEL>
									</LABEL></TD>
								<TD class="tdpadleft5" height="34"><INPUT style="Z-INDEX: 0" id="chkAplicarDevolucion" class="fieldborderless" value="True"
										type="checkbox" name="chkAplicarDevolucion"></TD>
							</TR>
								<%-- Fecha : 26 Noviembre 2013
								 stkmtyPPSV JPMB -- Add CheckBox , muestra Datos en POS 
								 "Star" --%>
							<TR>
								<TD class="tdtexttablebold" height="34" width="231"><LABEL style="Z-INDEX: 0" for="txtEmpresaNombre"><LABEL for="txtEmpresaNombre">Mostar en Punto de Venta:</LABEL>
									</LABEL></TD>
								<TD class="tdpadleft5" height="34"><INPUT style="Z-INDEX: 0" id="chkMuestaenPuntodeVenta" class="fieldborderless" value="True"
										type="checkbox" name="chkMuestaenPuntodeVenta"></TD>
							</TR>
							<%-- "END" --%>
							<tr>
								<td class="txaccion" height="41" vAlign="top" colSpan="2" align="right">
									<P class="tdtexttablebold" align="left">&nbsp;</P>
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" vAlign="top" colSpan="2"><input id="cmdCancelar" language="javascript" class="button" onclick="return cmdCancelar_onclick()"
										value="Regresar" type="button" name="cmdCancelar"> <input id="cmdGuardar" language="javascript" class="button" onclick="return cmdGuardar_onclick()"
										value="Guardar" type="submit" name="cmdGuardar">
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<table border="0" cellSpacing="0" cellPadding="0" width="780">
				<tr>
					<td>
						<script language="JavaScript">crearTablaFooterCentral()</script>
					</td>
				</tr>
			</table>
			<input type="hidden" name="txtTipoServicioVirtualIdAnterior"> <input type="hidden" name="txtTipoServicioVirtualId">
			<script language="JavaScript">
    <!--
    new menu (MENU_ITEMS, MENU_POS);
    //-->
			</script>
		</form>
	</body>
</HTML>
