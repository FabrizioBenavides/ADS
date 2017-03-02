<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PopMovimientosAntibioticos.aspx.vb" Inherits="com.isocraft.backbone.ccentral.PopMovimientosAntibioticos" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD html 4.0 transitional//EN">
<HTML>
	<HEAD>
		<title>Sistema Administrador de Sucursal</title>
		<% 
'====================================================================
' Page          : 
' Title         : 
' Description   : 
' Copyright     : 
' Company       : 
' Author        : J.Antonio Hernández Dávila
' Version       : 1.0
' Last Modified : 
'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
'====================================================================	
%>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<link href="../static/css/print.css" rel="stylesheet">
			<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
			<script language="javascript" id="clientEventHandlersJS">
//<!--
		
function window_onload() {
				document.forms[0].action = "PopMovimientosAntibioticos.aspx";
				return(true);
}
	
		
function cmdImprimir_onclick() 
{
		if (window.print) 
		{
			document.ifrPageToPrint.document.all.ToPrintTxtFecha.innerHTML    =document.all.ToPrintTxtFecha.innerText;
			document.ifrPageToPrint.document.all.ToPrintTxtSucursal.innerHTML =document.all.ToPrintTxtSucursal.innerText;
			document.ifrPageToPrint.document.all.ToPrintHtmContenido.innerHTML=document.all.ToPrintHtmContenido.innerHTML;
			document.ifrPageToPrint.focus();
			window.print();        
		} 
		else 
			alert("Tu navegador no soporta la función: Print.");
			
		return(false);
}
	
function cmdCerrar_onclick() {	
	window.close();
  return(true);
}
	
function window_onunload() {
			<% if Request.QueryString("strEvalJs")<>"" then %>
			eval("<%=Request.QueryString("strEvalJs")%>");
			<% end if %>
}

//-->
			</script>
	</HEAD>
	<body language="javascript" onload="return window_onload()" leftmargin="0" topmargin="0"
		marginheight="0" marginwidth="0" onUnload="return window_onunload()">
		<form name="frmPopAntibiotico" action="about:blank" method="post" bgcolor="#ffffff">
			<table cellspacing="0" cellpadding="0" width="100%" border="0" bgcolor="#ffffff">
				<tr>
					<td class="tdlogopop" colspan="2" height="54"><script language="javascript">crearTablaHeaderPop()</script></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0" bgcolor="#ffffff">
				<tr>
					<td width="10">&nbsp;</td>
					<td class="tdtablacont" vAlign="top" width="950">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td width="100%"><script language="JavaScript">crearDatosSucursal()</script>
									<br>
								</td>
							</tr>
							<tr>
								<td class="tdconttablas" vAlign="middle" width="100%" align="left"><input name="cmdCerrar" type="submit" class="boton" id="cmdCerrar" value="Cerrar" onClick="return cmdCerrar_onclick()">
									&nbsp; <input name="cmdImprimir" type="submit" class="boton" id="cmdImprimir" value="Imprimir"
										onclick="return cmdImprimir_onclick()"></td>
							</tr>
							<tr>
								<td class="tdconttablas" vAlign="middle" width="100%" align="left"><div id="ToPrintHtmContenido"><%= strRecordBrowserHTML %>
									</div>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
		<iframe name="ifrPageToPrint" src="../static/PageToPrint.htm" width="0" height="0"></iframe>
		<%= strJavascriptWindowOnLoadCommands %>
	</body>
</HTML>
