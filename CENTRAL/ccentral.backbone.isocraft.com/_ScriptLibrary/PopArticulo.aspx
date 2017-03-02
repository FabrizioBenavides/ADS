<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="PopArticulo.aspx.vb" Inherits="com.isocraft.backbone.ccentral.PopArticulo" codePage="28592"%>
<%@ Import Namespace="Benavides.POSAdmin.Commons" %>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : popArticulo.aspx
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
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<link href="../static/css/estilo.css" rel="stylesheet">
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--
function window_onload() {
  MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
  document.forms[0].action = "<%= strFormAction %>";
  return(true);
}

function strRecordBrowserHTML() {
  document.write("<%=strRecordBrowserHTML%>");
   return(true);
}
function cmdCerrar_onclick() {
	opener.document.forms[0].elements['<%=Request.QueryString("strArticulo")%>'].value = 0;
	opener.document.forms[0].elements['<%=Request.QueryString("strArticuloNombreId")%>'].value = "";
	
	<% if Request.QueryString("strEvalJs")<>"" then %>
	eval("<%=Request.QueryString("strEvalJs")%>");
	<% end if %>	
	
	window.close();
  return(true);
}

function ClosePopup(intValor,strNombre,intDepartamento)
{
	opener.document.forms[0].elements['<%=Request.QueryString("strArticulo")%>'].value = intValor;
	opener.document.forms[0].elements['<%=Request.QueryString("strArticuloNombreId")%>'].value = strNombre;
	
	<% if Request.QueryString("strEvalJs")<>"" then %>
	eval("<%=Request.QueryString("strEvalJs")%>");
	<% end if %>		
	
	<% if Request.QueryString("strEvalJsClosePopup")<>"" then %>
	eval("<%=Request.QueryString("strEvalJsClosePopup")%>");
	<% end if %>		
	
	self.close();
    return(true);
}

function window_onunload() {
	<% if Request.QueryString("strEvalJs")<>"" then %>
	eval("<%=Request.QueryString("strEvalJs")%>");
	<% end if %>
}

//-->
</script>
</head>
<body bgcolor="#ffffff" leftmargin="0" topmargin="0" marginheight="0" marginwidth="0" onUnload="return window_onunload()">
<form name=frmPopArticulo action=about:blank method=post>
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
      <td valign="top" height="30"><span class="txtitulo">Catalogo Articulos</span><span class="txcontenido">Selecciona 
        el Articulo haciendo clic en el nombre.<br>
        <br>
        </span> <script language="javascript">strRecordBrowserHTML()</script> 
        <span class="txcontenido"></span></td>
    </tr>
    <tr> 
      <td width="2%">&nbsp;</td>
      <td><input name=cmdCerrar type=submit class=boton id="cmdCerrar" value=Cerrar onClick="return cmdCerrar_onclick()"> 
        <br> <br> </td>
    </tr>
  </table>
</form>
<%= strJavascriptWindowOnLoadCommands %> 
</body>
</html>
