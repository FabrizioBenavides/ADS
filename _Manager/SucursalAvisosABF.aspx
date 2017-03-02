<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalAvisosABF.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalAvisosABF1"%>
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


function window_onload() {    
   document.forms[0].action = "<%= strFormAction %>";
   document.forms[0].elements["txtDescripcion"].disabled = true;
   
   
   
   if("<%= strCmd %>" == "Editar")
	{
	
	   	document.forms[0].elements["txtAvisosABFId"].value = "<%= IntAvisosABFId %>";
		document.forms[0].elements["txtCliente"].value = "<%= strCliente %>";
		document.forms[0].elements["txtDescripcion"].value = "<%= strDescripcion %>";
		document.forms[0].elements["txtdiasaviso"].value = "<%= intDiasMensajeInformativoABF %>";
		document.forms[0].elements["txtmensaje"].value = "<%= strMensajeInformativoABF %>";
		document.forms[0].elements["chkActivo"].checked = <%= blnMensajeInformativoABFActivo.ToString().ToLower() %>;
		document.forms[0].elements["txtCliente"].disabled = true;
		document.forms[0].elements["txtDescripcion"].disabled = true;
	//La asignacion al campo del valor al campo txtTarjetaRegaloDescripcion se encuentra en la seccion de html debido a que no se encontro la manera de realizarlo con javascript
	}
   else
   {
        //No hacer nada
   }
   
   document.forms[0].txtCliente.focus();
   
   <%= strJavascriptWindowOnLoadCommands %>
}

	function ConsultarClienteABF() 
	{	
		if (blnValidarCampo(document.forms[0].elements["txtCliente"], true, "Cliente ABF", cintTipoCampoAlfanumerico, 255, 1, "") == true)
		{
			document.forms[0].elements["txtDescripcion"].disabled = true;
			{
				window.open("popBuscarClienteABF.aspx?blnSucursal=false&strClienteABF=" + document.forms[0].elements["txtCliente"].value + "&strCliente=txtCliente&strClienteABFDesc=txtDescripcion&strEvalJs=opener.AutoSubmit()", "Pop", "width=500,height=540,left=280,top=168,resizable=no,scrollbars=yes,menubar=no,status=no");
			}
		}
	}
	
function cmdAgregar_onclick() 
{
	if (blnValidarCampo(document.forms[0].elements["txtCliente"], true, "Cliente", cintTipoCampoAlfanumerico, 255, 1, "") == true)
	{
		if (blnValidarCampo(document.forms[0].elements["txtdiasaviso"], true, "Dias Aviso", cintTipoCampoEntero, 4, 1, "") == true)
		{
			if (parseInt(document.forms[0].elements["txtdiasaviso"].value) > 0)
			{
				if (blnValidarCampo(document.forms[0].elements["txtmensaje"], true, "Mensaje Informativo", cintTipoCampoAlfanumerico, 255, 1, "") == true)
				{
					document.forms[0].action = "SucursalAvisosABF.aspx?strCmd=Agregar";
					document.forms[0].submit();
				}
			}
			else 
				{	 
				alert("El campo Días Aviso no puede ser negativo.");
				}
		}
		
	}
	
}
  

function cmdCancelar_onclick() {
    window.location.href = "SucursalHome.aspx";   
}



//-->

				</script>
	</HEAD>
	<body onload="window_onload();">
		<form method="post" name="SucursalAvisosABFAgregarEditar" action="about:blank">
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
					<td class="tdtab" width="770">Está en : <A href="SucursalHome.aspx">Sucursal</A> :<A href="SucursalAvisosABF.aspx">
							Avisos ABF </A><A></A>
					</td>
				</tr>
			</table>
			<table border="0" cellSpacing="0" cellPadding="0" width="780">
				<tr>
					<td class="tdgeneralcontent">
						<table style="Z-INDEX: 0" border="0" cellSpacing="0" cellPadding="0" width="700" height="150">
							<TBODY>
								<tr>
									<h1>Avisos ABF</h1>
								</tr>
								<TR>
									<td class="tdtexttablebold" height="50" width="70"><label for="txtCliente">Cliente ABF:</label>
									</td>
									<td class="tdpadleft5" height="26" width="298"><input id="txtCliente" class="field" maxLength="50" size="50" name="txtCliente">
										&nbsp;&nbsp; <A href="javascript:ConsultarClienteABF()"><IMG border="0" align="absMiddle" src="../static/images/icono_lupa.gif" width="17" height="17"></A>&nbsp;
									</td>
									<td class="tdtexttablebold" height="50" width="240"><label for="txtDescripcion">Descripcion:</label>
									</td>
									<td class="tdpadleft5" height="26"><input onblur="return txtDescripcion_onblur()" style="Z-INDEX: 0" onkeydown="txtDescripcion_onKeyDown()"
											id="txtDescripcion" class="field" maxLength="50" size="50" name="txtDescripcion" autocomplete="off">&nbsp;&nbsp;&nbsp;&nbsp;
									</td>
								</TR>
								<TR>
									<td class="tdtexttablebold" height="50" width="70"><label for="txtdiasaviso">Días Aviso:</label>
									</td>
									<td class="tdpadleft5" width="298"><input id="txtdiasaviso" class="field" maxLength="255" size="14" name="txtdiasaviso">
									</td>
									<td class="tdtexttablebold" width="164"><label for="chkEmpresaActiva">Activo</label>
									</td>
									<td class="tdpadleft5"><input id="chkActivo" class="fieldborderless" value="True" CHECKED type="checkbox" name="chkActivo">
									</td>
								</TR>
								<tr>
									<td class="tdtexttablebold" height="50" width="70"><label for="txtEmpresaNombre">Mensaje Informativo:</label>
									</td>
									<td class="tdpadleft5" width="298"><input id="txtmensaje" class="field" maxLength="255" size="80" name="txtmensaje">
									</td>
								</tr>
								<TR>
									<td class="txaccion" height="10" vAlign="top" width="780" colSpan="2" align="right">&nbsp;</td>
								</TR>
								<tr>
									<td class="tdtexttablebold" vAlign="top" align="right" width="71"><input id="cmdAgregar" language="javascript" class="button" onclick="return cmdAgregar_onclick()"
											value="Agregar" type="button" name="cmdAgregar">
									</td>
								</tr>
							</TBODY></table>
						<table border="0" cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td height="17">
									<%= strGetRecordBrowserHTML() %>
								</td>
							</tr>
							<tr>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" vAlign="top"><input id="cmdCancelar" language="javascript" class="button" onclick="return cmdCancelar_onclick()"
										value="Regresar" type="button" name="cmdCancelar">
								</td>
							</tr>
						</table>
					</td>
					</TD></tr>
			</table>
			<table border="0" cellSpacing="0" cellPadding="0" width="780">
				<tr>
					<td>
						<script language="JavaScript">crearTablaFooterCentral()</script>
					</td>
				</tr>
			</table>
			<input type="hidden" name="txtAvisosABFId"> </input>
			<script language="JavaScript">
			<!--
				new menu (MENU_ITEMS, MENU_POS);
				//-->
			</script>
		</form>
	</body>
</HTML>
