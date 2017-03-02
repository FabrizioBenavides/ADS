<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Mensaje.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMensaje" Explicit="True" Trace="False" Strict="True" codePage="1252" EnableSessionState="true" enableViewState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Benavides</TITLE>
		<%
    '====================================================================
    ' Page          : CapturaConsumidorcom.isocraft.backbone.ccentral.aspx
    ' Title         : Pantalla de captura de Consumidor
    ' Description   :Pantalla de captura de Consumidor
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Neitek Solutions S.A. de C.V.
    ' Author        : Enrique Longoria
    ' Version       : 1.0
    ' Last Modified : Monday, Feb 16th, 2005
    '====================================================================
%>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">		
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="js/menu.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="js/menu_items.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="js/menu_tpl.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="js/headerfooter.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="js/FotoLabUtils.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="js/calendario.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="js/cal_format00.js" type="text/JavaScript"></script>
		<style>
		.textomensaje {
font-family: Arial, Helvetica, sans-serif;
font-size: 12px;
color: #00005C;
padding: 0 0 5px 0;
}
.tdmensaje {
font-size: 9px;
color: #767373;
background-color: #E6E6E6;
padding-left: 10px;
border-bottom: 1px solid #666;
border-top: 1px solid #C2C2C2;
}
</style>
<script language="javascript" id="clientEventHandlersJS">
strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";
strSucursalNombre = "<%= strNombreSucursal %>";
strSucursalId = "<%= strSucursalId%>";

function window_onload() 
{
	
 }

function doSubmit()
{  args = doSubmit.arguments;
    var action = args[0];
	if (action == "<%=Me._GUARDAR %>")
	{
	//validateForm()
	}		
	var params = ""
	for (i=1; i < (args.length-1); i +=2)
	{params+= "&" + args[i] + "=" + args[i+1]}
    document.forms[0].action = "<%= strThisPageName %>?strCmd=" + action + params    
    document.forms[0].submit();  
}
//-->
</script>
	</HEAD>
	<body onload="window_onload()">
	<table width="500" border="0" cellspacing="0" cellpadding="0">
		<tr>
			<td width="152"><img src="images/imgBenavidesLogoPop.gif" width="152" height="51"></td>
		</tr>
	</table>
	<table width="500" border="0" cellspacing="0" cellpadding="0">
		<tr>
			<td class="tdclosewindow">x <a href="#" onClick="window.close();">cerrar ventana </a> </td>
		</tr>
	</table>
	<table width="500" border="0" cellspacing="0" cellpadding="0">
		<tr>
			<td class="textomensaje" Align=center><br><%=Request("strmensaje") %></td>
		</tr>
	</table>

		<table cellSpacing="0" cellPadding="0" width="300" border="0">
		<tr>	
			<td>
				<div style='position:absolute;top:140'>
					<table width="500" border="0" cellpadding="0" cellspacing="0">
						<tr>
							<td class="tdmensaje">Sistema Administrador de Puntos de Venta  &copy; 2005 Farmacias Benavides</td>
						</tr>
					</table>
				</div>
			</td>
		</tr>	
		</table>
	</form>		
	</body>
</HTML>

