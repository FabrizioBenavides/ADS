<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DetalleDeTrabajos.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsDetalleDeTrabajos" Explicit="True" Trace="False" Strict="True" codePage="1252" EnableSessionState="true" enableViewState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Benavides : Administrador del Sistema Concentrador (CTX)</TITLE>
		<%
    '====================================================================
    ' Page          : DetalleDeTrabajos.aspx
    ' Title         : Pantalla de detalle de trabajos
    ' Description   :Pantalla de detalle de trabajos
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Neitek Solutions S.A. de C.V.
    ' Author        : Enrique Longoria
    ' Version       : 1.0
    ' Last Modified : Monday, Feb 16th, 2005
    '====================================================================
%>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="css/menu.css" type="text/css" rel="stylesheet">
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="js/menu.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="js/menu_items.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="js/menu_tpl.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="js/headerfooter.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="js/FotoLabUtils.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="js/calendario.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="js/cal_format00.js" type="text/JavaScript"></script>
<script language="javascript" id="clientEventHandlersJS">
strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";
strSucursalNombre = "<%= strNombreSucursal %>";
strSucursalId = "<%= strSucursalId%>";
function window_onload()
{<%=me.strActions("Editar")%>}


function doSubmit()
{  args = doSubmit.arguments;
    var action = args[0];
	var params = ""
	var isOk=1;
	
	if (isOk==1)
	{
		for (i=1; i < (args.length-1); i +=2)
		{params+= "&" + args[i] + "=" + args[i+1]}	
		document.forms[0].action = "<%= strThisPageName %>?strCmd=" + action + params    
		document.forms[0].submit();  
    }else{return false;}
}

function loadElement()
{
 args = loadElement.arguments;
 var idValue = args[3];
 var displayValue = args[2];
/*
		alert(idValue)
		alert(displayValue)
		alert('<%=Request("displayObj")%>'); 
		alert('<%=Request("idObj")%>'); 
*/
//opener.document.forms[0].strTrabajo.value=idValue;
opener.document.forms[0].strTrabajo.value=idValue;
opener.document.forms[0].strTrabajo.focus();
opener.document.forms[0].strTrabajo.select();
window.close();
}
//-->
</script>
	</HEAD>
	<body onload=window_onload()>
		<form id="Form1" name="frmOrden" action="about:blank" method="post">			
			<input type="hidden" value="<%=Request("intSucursalIdDetalle")%>" name="intSucursalIdDetalle">
			<input type="hidden" value="<%=Request("intCompaniaIdDetalle")%>"  name="intCompaniaIdDetalle">
			
		<table width="580" border="0" cellspacing="0" cellpadding="0">
	<tr><td width="152"><img src="images/imgBenavidesLogoPop.gif" width="152" height="51"></td></tr></table>	
	<table width="600" border="0" cellspacing="0" cellpadding="0">
	<tr><td class="tdclosewindow">x <a href="#" onClick="window.close();">cerrar ventana </a> </td></tr>
	</table>
	
			<table cellSpacing="0" cellPadding="0" width="600" border="0" >
				<tr>
					<td class="tdgeneralcontent">
						<h1>Detalle de Laboratorio</h1>												
						<table class="tdenvolventetablas" cellSpacing="0" cellPadding="0" width="580" border="0" >				
							<tr><td class="txtitintabla" Align="right" width="20%">Cliente:&nbsp;</td><td class="tdconttablas" colspan=2 Align="left" width="80%"><div id=divSucursalccsss></div></td></tr>	
							<tr><td class="txtitintabla" Align="right" width="20%">Razón Social:&nbsp;</td><td class="tdconttablas" colspan=2  Align="left" width="80%"><div id=divSucursalRazonSocial></div></td></tr>						
							<tr><td class="txtitintabla" Align="right" width="20%">Zona Operativa:&nbsp;</td><td class="tdconttablas" colspan=2  Align="left" width="80%"><div id=divSucursalZonaOperativa></div></td></tr>								
						</table>		
						<br>
						<p><span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">Trabajos Asignados </span> </p>							
						<div id=divRecordBrowserHTMLSuc><%=strGenerarListado("")%></div>
											
					</td>
				</tr>
			</table>		
			<table cellSpacing="0" cellPadding="0" width="580" border="0">
				<tr>	<td><script language="JavaScript">crearTablaFooterPop2()</script></td></tr>	
			</table>
		</form>		
	</body>
</HTML>

