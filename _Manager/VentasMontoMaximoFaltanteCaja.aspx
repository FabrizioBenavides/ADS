<%@ Page Language="vb" AutoEventWireup="false" Codebehind="VentasMontoMaximoFaltanteCaja.aspx.vb" Inherits="com.isocraft.backbone.ccentral.VentasMontoMaximoFaltanteCaja" %>
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
  document.forms[0].action = "<%= strThisPageName %>";
  
  
}

function cmdGuardar_onclick() {
   var blnReturn = blnFormValidator();
      
   if ( blnReturn == true) {
       document.forms[0].action += "?strCmd=Guardar";
   }
   
   return (blnReturn);
}


function blnFormValidator() 
{
   var blnReturn = false;
      		
   			/* Validación del campo "txtTipoServicioVirtualDescripcion" */
			if(blnValidarCampo(document.forms[0].elements["txtMontoMaximoFaltanteCaja"], true, "Monto Limite para Faltantes de Caja", cintTipoCampoReal, 80, 1, "") == true)
			{
        		blnReturn = true;
        	}	
			else 
           	{
           		document.forms[0].elements["txtMontoMaximoFaltanteCaja"].focus();
           		blnReturn = false;
			}
			
   return (blnReturn);
}

//-->
				</script>
	</HEAD>
	<body onload="window_onload();">
		<form name="SucursalEmpresasServiciosAgregarEmpresa" action="about:blank" method="post">
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
					<td class="tdtab" width="770">Está en : <A href="SucursalHome.aspx">Ventas</A>: 
						Entrega de Valores <A href="SucursalTipoServicioVirtual.aspx">:</A>&nbsp;Consultas
						<A>&nbsp; </A>
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td class="tdgeneralcontent">
						<h1>Monto Máximo para Faltante de Cajero</h1>
						<p>Aquí podrá dar de alta y modificar el monto máximo del faltante para cajeros.</p>
						<table cellSpacing="0" cellPadding="0" border="0">
							<tr>
								<td class="tdtexttablebold" width="230" height="46"><label for="txtEmpresaNombre">Importe Tope:</label>
								</td>
								<td class="tdpadleft5"><input class="field" id="txtMontoMaximoFaltanteCaja" type="text" maxLength="255" size="42"
										name="txtMontoMaximoFaltanteCaja">
								</td>
							</tr>
							<tr>
								<td class="txaccion" vAlign="top" align="right" colSpan="2" height="10">&nbsp;</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" vAlign="top" colSpan="2">&nbsp; <input language="javascript" class="button" id="cmdGuardar" onclick="return cmdGuardar_onclick()"
										type="submit" value="Guardar" name="cmdGuardar">
								</td>
							</tr>
							<tr>
								<%= strRecordBrowserHTML() %>
							<tr>
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
			&nbsp;
			<script language="JavaScript">
    <!--
    new menu (MENU_ITEMS, MENU_POS);
    //-->
			</script>
		</form>
	</body>
</HTML>

