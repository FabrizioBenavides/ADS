<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PopupDocumento.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsPopupDocumento" Explicit="True" Trace="False" Strict="True" codePage="1252" EnableSessionState="true" enableViewState="False" %>
<HTML>
	<HEAD>
		<TITLE>Benavides</TITLE>
		<%
'====================================================================
' Page          : PopupDocumento.aspx
' Title         :	 PopupDocumento
' Description   : Listado Popup de Seleccion  
' Copyright     : 2003-2006 All rights reserved.
' Company       : Neitek Solutions S.A. de C.V.
' Author        : Enrique Longoria
' Version       : 1.0
' Last Modified : Monday, Feb 25th, 2005
'====================================================================
%>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="js/headerfooter.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="js/FotoLabUtils.js" type="text/JavaScript"></script>
		<script language="javascript" id="clientEventHandlersJS">
strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";
strSucursalNombre = "<%= strNombreSucursal %>";
strSucursalId = "<%= strSucursalId%>";

function window_onload()
{ 

	if (location.href.indexOf('&strFilterValues=')>0 ) 
	{   
	   document.forms[0].params.value=location.href.substring(location.href.indexOf('&strFilterValues='),location.href.length);
	   document.forms[0].params.value= document.forms[0].params.value.replace('<%=Request("displayObj")%>','non');
	}    
opener.document.forms[0].<%=Request("displayObj")%>.value='';
opener.document.forms[0].<%=Request("idObj")%>.value='';
<%= displayPopupList() %>
 }

function goToURL(urlStr)
{location.href=urlStr;}

function showError(msg)
{alert (msg);}

function doSubmit()
{
    args = doSubmit.arguments;
    var action = args[0];
	var params = ""
	for (i=1; i < (args.length-1); i +=2)
	{params+= "&" + args[i] + "=" + args[i+1]}	   
    document.forms[0].action = "<%= strThisPageName %>?strCmd=" + action + params +'&<%=Request("displayObj")%>=<%=Request("strfilterValues")%>'+document.forms[0].params.value;
     document.forms[0].submit();  
}

function loadElement()
{
 args = loadElement.arguments;
 var idValue = args[2];
 var displayValue = args[3];
	/*
		alert(idValue)
		alert(displayValue)

		alert('<%=Request("displayObj")%>'); 
		alert('<%=Request("idObj")%>'); */		
		
<%= desplegarExtraScript() %>	

opener.document.forms[0].<%=Request("displayObj")%>.value=displayValue;
opener.document.forms[0].<%=Request("idObj")%>.value=idValue;
opener.document.forms[0].<%=Request("displayObj")%>.focus();
<% if request("nextfocus")<>"" then%>
	opener.document.forms[0].<%=Request("nextfocus")%>.focus();
<% end if %>
window.close();
}
//-->
		</script>
	</HEAD>
	<body onload="javascript:window_onload()">
		<!-- javascript:openPopup('Listado de Consumidores','tblConsumidorFotolab',document.forms[0].strConsumidorFotolabRazonSocial.value,'intConsumidorFotolabId','strConsumidorFotolabRazonSocial')"-->
		<form id="Form1" name="frmPopupDocumento" action="about:blank" method="post">
			<input type="hidden" value='<%=Request("idObj")%>' name="idObj"> <input type="hidden" value='<%=Request("displayObj")%>' name="displayObj">
			<input type="hidden" value='<%=Request("strfilterValues")%>' name="strfilterValues">
			<input type="hidden" value='<%=Request("header")%>' name="header"> <input type="hidden" value='<%=Request("screenName")%>' name="screenName">
			<input type="hidden" name="params">
			<table cellSpacing="0" cellPadding="0" width="580" border="0">
				<tr>
					<td><script language="JavaScript">crearTablaHeaderPop2()</script>
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="580" border="0">
				<tr>
					<td class="tdgeneralcontentPop">
						<p><%= desplegarExtraHtmlInicio() %></p>
						<h1><%= Request("header") %></h1>
						<p>Para seleccionar un valor oprimir la imagen de la acción</p>
						<%= PopupListHtml %>
						<p><%= desplegarExtraHtmlFinal() %></p>
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="580" border="0">
				<tr>
					<td><script language="JavaScript">crearTablaFooterPop2()</script></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
