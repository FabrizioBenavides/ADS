<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="PopDoctor.aspx.vb" Inherits="com.isocraft.backbone.ccentral.PopDoctor" codePage="28592"%>
<%@ Import Namespace="Benavides.POSAdmin.Commons" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD html 4.0 transitional//EN">
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<% 
'====================================================================
' Page          : PopDoctor.aspx
' Title         : 
' Description   : 
' Copyright     : 
' Company       : BENAVIDES
' Author        : J.Antonio Hernández Dávila
' Version       : 1.0
' Last Modified : 
'                
'               
'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
'====================================================================	
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<LINK href="../static/css/estilo.css" rel="stylesheet">
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="javascript" id="clientEventHandlersJS">
//<!--
		
			function window_onload() {
				document.forms[0].action = "PopDoctor.aspx";
				return(true);
				}
			

		function cmdCerrar_onclick() 
		{
			document.forms[0].action += "?strCmd=Cerrar";
			document.forms[0].submit();
		}
		
	
		function window_onunload() {
			<% if Request.QueryString("strEvalJs")<>"" then %>
			eval("<%=Request.QueryString("strEvalJs")%>");
			<% end if %>
		}

//-->
</script>
</HEAD>
<body language="javascript" bgColor="#ffffff" leftMargin="0" topMargin="0" onload="return window_onload()" onunload="return window_onunload()" marginwidth="0" marginheight="0">
<form name="frmPopDoctor" action="about:blank" method="post">
  <table height="158" cellspacing="0" cellpadding="0" width="100%" bgcolor="#ffffff" border="0">
    <tr> 
      <td class="tdlogopop" colspan="2" height="54"><script language="javascript">crearTablaHeaderPop()</script></td>
    </tr>
    <tr> 
      <td width="2%">&nbsp;</td>
      <td valign="top" width="99%" height="10">&nbsp;</td>
    </tr>
    <tr> 
      <td width="2%">&nbsp;</td>
      <td valign="top" height="30"><span class="txtitulo">Información del Doctor<br>
        </span> <span class="txcontenido"><%= strRecordBrowserHTML %> </span></td>
    </tr>
    <tr> 
      <td width="2%">&nbsp;</td>
      <td><input class="boton" id="cmdCerrar" onclick="return cmdCerrar_onclick()" type="submit"
							value="Cerrar" name="cmdCerrar"> </td>
    </tr>
  </table>
</form>
<%= strJavascriptWindowOnLoadCommands %> 
</body>
</HTML>
