<%@ Import Namespace="Benavides.POSAdmin.Commons" %>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="PopSucursal.aspx.vb" Inherits="com.isocraft.backbone.ccentral.PopSucursal" codePage="28592"%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%  '====================================================================
    ' Page          : PopSucursal.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Popup para selecionar una sucursal
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Raul Corral Gonzalez
    ' Version       : 1.0
    ' Last Modified : Sabado, 01 de Noviembre, 2003
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<link href="../static/css/estilo.css" rel="stylesheet">
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--
intGlobal = 0;

function window_onload() {
	MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
	document.forms[0].action = "<%=strFormAction%>";
	return(true);
}

function strRecordBrowserHTML() {
  document.write("<%=strRecordBrowserHTML%>");
   return(true);
}

function cmdCerrar_onclick() {
	if(intGlobal==1){return}
	
	intValorCia=0;
	intValorSuc=0;
	strNombre='';
	opener.document.forms[0].elements['<%=Request.QueryString("strObjCiaId")%>'].value =intValorCia;
	opener.document.forms[0].elements['<%=Request.QueryString("strObjSucId")%>'].value =intValorSuc;
	opener.document.forms[0].elements['<%=Request.QueryString("strObjDescripcion")%>'].value = strNombre;
	
	strEvalJs="<%=Request("strEvalJs")%>";
	if(strEvalJs!=""){
		eval(strEvalJs);
	}
	
	window.close();
  return(true);
}

function ClosePopup(intValorCia, intValorSuc,strNombre)
{
	intGlobal = 1;
    opener.document.forms[0].elements['<%=Request.QueryString("strObjCiaId")%>'].value = intValorCia;
	opener.document.forms[0].elements['<%=Request.QueryString("strObjSucId")%>'].value = intValorSuc;
	opener.document.forms[0].elements['<%=Request.QueryString("strObjDescripcion")%>'].value = strNombre;

	strEvalJs="<%=Request("strEvalJs")%>";
	if(strEvalJs!=""){
		eval(strEvalJs);
	}
		
	self.close();
    return(true);
}

function window_onunload() {
	cmdCerrar_onclick();
}

//-->
</script>
</head>
<body bgcolor="#ffffff" leftmargin="0" topmargin="0" marginheight="0" marginwidth="0" onunload="return window_onunload()">
<form name=frmPopSucursal action=about:blank method=post>
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
      <td valign="top" height="30"><span class="txtitulo">Catalogo Sucursales</span><span class="txcontenido">Selecciona 
        la Sucursal haciendo clic en el nombre.<br>
        <br>
        </span> <script language="javascript">strRecordBrowserHTML()</script> 
        <span class="txcontenido"></span></td>
    </tr>
    <tr> 
      <td width="2%">&nbsp;</td>
      <td><input name=cmdCerrar type=submit class=boton id="cmdCerrar" value=Cerrar onclick="return cmdCerrar_onclick()"> 
        <br> <br> </td>
    </tr>
  </table>
</form>
</body>
</html>
