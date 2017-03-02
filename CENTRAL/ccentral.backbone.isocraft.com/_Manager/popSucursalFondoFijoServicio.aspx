<%@ Import Namespace="Benavides.POSAdmin.Commons" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="popSucursalFondoFijoServicio.aspx.vb" Inherits="com.isocraft.backbone.ccentral.popSucursalFondoFijoServicio" EnableSessionState="False" enableViewState="False"%>
<HTML>
	<HEAD>
		<title>ADS CENTRAL</title>
		<%  '====================================================================
    ' Page          : popSucursalFondoFijoServicio.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : 
    ' Copyright     : 2010
    ' Company       : Farmacias Benavides
    ' Author        : Softtek - Vanessa Sánchez G. 
    ' Last Modified : 30 de Diciembre 2010
    '====================================================================
%>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
			<script language="JavaScript" src="js/headerfooter.js" type="text/JavaScript"></script>
			<script language="JavaScript" src="../static/scripts/Tools.js" type="text/JavaScript"></script>
			<script language="javascript" id="clientEventHandlersJS">

<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
	document.forms[0].action = "popSucursalFondoFijoServicio.aspx";
	return(true);
}

function cmdImprimir_onclick() 
{
	if (window.print) 
	{
		document.ifrPageToPrint.document.all.ToPrintTxtFecha.innerHTML    =document.all.ToPrintTxtFecha.innerText;
		document.ifrPageToPrint.document.all.ToPrintHtmContenido.innerHTML=document.all.ToPrintHtmContenido.innerHTML;
		document.ifrPageToPrint.focus();
		window.print();        
	} 
	else 
		alert("Tu navegador no soporta la función: Print.");
		
	return(false);
}

function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
	return(true);
}

function cmdCerrar_onclick() {	
	window.close();	
	return(true);
}

//-->
			</script>
	</HEAD>
	<body language="javascript" leftMargin="0" topMargin="0" onload="return window_onload()">
		<form name="frmPopSucursalFondoFijoServicio" method="post" encType="multipart/form-data"
			runat="server" ID="Form1">
			<table height="158" cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td width="2%">&nbsp;</td>
					<td width="96%">
						<table width="100%" align="center">
							<tr>
								<td class="tdlogopop" height="21">
									<img height="54" src="../static/images/logo_pop.gif" width="177"></td>
							</tr>
						</table>
						<table width="100%" border="0" cellpadding="0" cellspacing="0" id="Table1">
							<tr>
								<td class="tdtexttablebold" vAlign="middle" width="12%">Fecha y hora:</td>
								<td class="tdconttablas" vAlign="middle" width="88%">
									<div id="ToPrintTxtFecha">
										<script language="javascript">strGetCustomDateTime()</script>
									</div>
								</td>
							</tr>
						</table>
						<table width="100%">
							<tr>
								<td class="tdconttablas" vAlign="middle" width="60%" colspan="2" align="left"><br>
									<input name="cmdCerrar" type="submit" class="boton" id="cmdCerrar" value="Cerrar" onClick="return cmdCerrar_onclick()">
									&nbsp; <input name="cmdImprimir" type="submit" class="boton" id="cmdImprimir" value="Imprimir"
										onclick="return cmdImprimir_onclick()"></td>
							</tr>
							<tr>
								<td>
									<div id="ToPrintHtmContenido">
										<%= strRecordBrowserHtml %>
									</div>
								</td>
							</tr>
						</table>
					</td>
					<td width="2%">&nbsp;</td>
				</tr>
			</table>
		</form>
		<iframe name="ifrPageToPrint" src="PageToPrint.htm" width="0" height="0"></iframe>
		<%= strJavascriptWindowOnLoadCommands %>
	</body>
</HTML>
