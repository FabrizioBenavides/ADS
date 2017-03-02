<%@ Page CodeBehind="PickupArticulo.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsPickupArticulo" Explicit="True" Trace="False" Strict="True" codePage="1252"  EnableSessionState="true" enableViewState="False" %>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : PickupArticulo.aspx
    ' Title         : Inventarios Rotativos
    ' Description   : Seleccion de articulos
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Neitek Solutions S.A. de C.V.
    ' Author        : Carolina Caballero
    ' Version       : 1.0
    ' Last Modified : Monday, Nov 1, 2004
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<LINK href="../static/css/estilo.css" rel="stylesheet">
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">
<!--
var clickOnButton = false;
var strPaginaAyuda
strPaginaAyuda = "<%=strThisPageName%>";

function window_onload(){
}

function doClose()
{
	window.opener.document.forms[0].intCodigoArticulo.select()
	window.opener.document.forms[0].intCodigoArticulo.focus()
	self.close()
}
function doSubmit()
{
    args = doSubmit.arguments;
    var action = args[0];
	if (action == "Seleccionar")
	{	
		window.opener.document.forms[0].intCodigoArticulo.value = args[2];
		//window.opener.buscaArticulo()
		window.opener.document.forms[0].strDescripcionArticulo.value = args[4];
		window.opener.document.forms[0].intExistencia.focus()
		self.close();
	}
	else
	{
		var params = ""
		for (i=1; i < (args.length-1); i +=2)
		{
			params+= "&" + args[i] + "=" + args[i+1]
		}
		document.forms[0].action = "PickupArticulo.aspx?strCmd=" + action + params
		document.forms[0].submit();  
	}
}
 
//-->
</script>
</HEAD>
<body leftMargin="0" background="" topMargin="0" onload="window_onload()" marginwidth="0" marginheight="0">
<form id="Form1" name="frmConsulta" onsubmit="return validateForm()" method="post" runAt="server">
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
      <td valign="top" height="30"><span class="txtitulo">Catalogo Artículos</span><span class="txcontenido">Seleccione 
        el Artículo haciendo clic en el nombre.<br>
        <br>
        </span> <%= strRecordBrowserHTML() %> <span class="txcontenido"></span></td>
    </tr>
    <tr> 
      <td width="2%">&nbsp;</td>
      <td><input name="cmdCerrar" type="button" class="boton" id="cmdCerrar" value="Cerrar" onclick="javascript:doClose()"> 
        <br> <br> </td>
    </tr>
  </table>
</form>
</body>
</HTML>
