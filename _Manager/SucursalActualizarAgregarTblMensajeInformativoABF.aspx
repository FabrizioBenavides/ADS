<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalActualizarAgregarTblMensajeInformativoABF.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalActualizarAgregarTblMensajeInformativoABF"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
		<%
		'====================================================================
		' Page          : SucursalAvisosABF.aspx
		' Title         : 
		' Description   : 
		' Copyright     :  
		' Company       :  
		' Author        : Rocio Esquivel [RERA]
		' Version       : 1.0
		' Last Modified : 09 de Mayo 2012 [RERA]    
		'====================================================================
		%>
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
 		document.forms[0].elements["txtAvisosABFId"].value = "<%= IntAvisosABFId %>";
		document.forms[0].elements["txtClienteABF"].value = "<%= strClienteABF %>";
		document.forms[0].elements["txtDescripcion"].value = "<%= strDescripcion %>";
		document.forms[0].elements["txtDiasAviso"].value = "<%= intDiasMensajeInformativoABF %>";
		document.forms[0].elements["txtMensajeInformativo"].value = "<%= strMensajeInformativoABF %>";
		document.forms[0].elements["chkActivo"].checked = <%= blnMensajeInformativoABFActivo.ToString().ToLower() %>;
		document.forms[0].elements["txtClienteABF"].disabled = true;
		document.forms[0].elements["txtDescripcion"].disabled = true;
		//La asignacion al campo del valor al campo txtTarjetaRegaloDescripcion se encuentra en la seccion de html debido a que no se encontro la manera de realizarlo con javascript
	}
   else
   {
         //No hacer nada
   }
   
   
     <%= strJavascriptWindowOnLoadCommands %>
}

function cmdGuardar_onclick() {
   var blnReturn = blnFormValidator();
      
   if ( blnReturn == true) {
       document.forms[0].action += "?strCmd=Salvar&intAvisosABFId=" + <%= intAvisosABFId %>;
   }
   
   return (blnReturn);
}


function cmdCancelar_onclick() {
   window.location.href = "SucursalAvisosABF.aspx";
}


function blnFormValidator() 
{
   var blnReturn = false;
      		
   			/* Validación del campo "txtClienteABF" */
			if(blnValidarCampo(document.forms[0].elements["txtDiasAviso"], true, "Cliente ABF", cintTipoCampoAlfanumerico, 80, 1, "") == true)
			{
        		blnReturn = true;
        	}	
			else 
           	{
           		document.forms[0].elements["txtClienteABF"].focus();
           		blnReturn = false;
			}
			
   return (blnReturn);
 }
 
 // PPSV RERA 05/05/2014 Función que verifica si se estan introduciendo datos numéricos
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
		<form method="post" name="SucursalActualizarAgregarTblMensajeInformativoABF" action="about:blank">
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
					<td class="tdtab" width="770">Está en : <A href="SucursalHome.aspx">Sucursal</A> : <A href="SucursalAvisosABF.aspx">
							Avisos ABF </A>: <A href="SucursalActualizarAgregarTblMensajeInformativoABF.aspx">
							Actualizar - Agregar MensajeInformativo &nbsp; </A>
					</td>
				</tr>
			</table>
			<table border="0" cellSpacing="0" cellPadding="0" width="780">
				<tr>
					<td class="tdgeneralcontent">
						<h1>Actualizar Mensaje Informativo ABF</h1>
						<p>Aquí podrá dar de alta y modificar los Mensajes Informativos ABF.</p>
						<h2>Definir Mensaje Informativo</h2>
						<table border="0" cellSpacing="0" cellPadding="0">
							<tr>
								<td class="tdtexttablebold" height="46" width="230"><label for="txtClienteABF">Cliente ABF:</label>
								</td>
								<td class="tdpadleft5" width="402"><input id="txtClienteABF" class="field" maxLength="255" size="80" name="txtclienteABF">
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" height="46" width="230"><label for="txtDescripcion">Descripción:</label>
								</td>
								<td class="tdpadleft5" width="402"><input id="txtDescripcion" class="field" maxLength="255" size="80" name="txtDescripcion">
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" height="46" width="230"><label for="txtDiasAviso">Días Aviso:</label>
								</td>
								<td class="tdpadleft5" width="402"><input id="txtDiasAviso" class="field" maxLength="255" size="80" name="txtDiasAviso">
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" height="46" width="168"><label for="chkActivo">Activo:</label>
								</td>
								<td class="tdpadleft5" width="402">&nbsp;<INPUT style="Z-INDEX: 0" id="chkActivo" class="fieldborderless" value="True" type="checkbox"
										name="chkActivo">
								</td>
							<tr>
								<td class="txaccion" vAlign="top" align="right" colSpan="2" height="10" width="632">&nbsp;</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" height="46" width="230"><label for="txtMensajeInformativo">Mensaje Informativo:</label>
								</td>
								<td class="tdpadleft5" width="402"><input id="txtMensajeInformativo" class="field" maxLength="255" size="80" name="txtMensajeInformativo">
								</td>
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
			<input type="hidden" name="txtAvisosABFId">
			<script language="JavaScript">
    <!--
    new menu (MENU_ITEMS, MENU_POS);
    //-->
			</script>
		</form>
	</body>
</HTML>
