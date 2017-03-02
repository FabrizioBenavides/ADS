<%@ Import Namespace="Benavides.POSAdmin.Commons" %>
<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PopPlanograma.aspx.vb" Inherits="com.isocraft.backbone.ccentral.PopPlanograma" %>

<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%  '====================================================================
    ' Page          : PopPlanoCenefa.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Popup para selecionar el Planograma
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Enrique Longoria
    ' Version       : 1.0
    ' Last Modified : Lunes,09 de Mayo, 2005
	'                 25 de Febrero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<link href="../static/css/estilo.css" rel="stylesheet">
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--

    function window_onload() {
        MM_preloadImages('../static/images/bsalir_on.gif', '../static/images/bayuda_on.gif');
        document.forms[0].action = "<%=strFormAction%>";
        document.forms[0].cmdCerrar.focus();

        return (true);
    }

    function strRecordBrowserHTML() {
        var strResponse = "<%=strRecordBrowserHTML()%>";
    if (strResponse.length > 5) {
        if (strResponse.substring(0, 7) == 'onlyReg') {
            var selected = strResponse.split('*');
            ClosePopup(selected[1], selected[2], '', '', '', '');
        }
        else { document.write(strResponse); }
    }
    return (true);
}

function cmdCerrar_onclick() {
    intValor = 0;
    strNombre = '';

    opener.document.forms[0].elements['<%=Request.QueryString("strPlanograma")%>'].value = intValor;
    opener.document.forms[0].elements['<%=Request.QueryString("strPlanogramaNombreId")%>'].value = strNombre;
	
	<% if Request.QueryString("strEvalJs")<>"" then %>
    eval("<%=Request.QueryString("strEvalJs")%>");
	<% end if %>

    window.close();
    return (true);
}

function ClosePopup(intValor, strNombre, strPrecioNormal, strPrecioPromocion, strFechaInicio, strFechaFinal) {
    opener.document.forms[0].elements['<%=Request.QueryString("strPlanograma")%>'].value = intValor;
    //opener.document.forms[0].elements['hdnPlanogramaId'].value = intValor;
    opener.document.forms[0].elements['<%=Request.QueryString("strPlanogramaNombreId")%>'].value = strNombre;

	<% if Request.QueryString("strEvalJsClosePopup")<>"" then %>
    eval("<%=Request.QueryString("strEvalJsClosePopup")%>");
    <% end if %>
	
	<% if Request.QueryString("strEvalJs")<>"" then %>
    eval("<%=Request.QueryString("strEvalJs")%>");
	<% end if %>

    self.close();
    return (true);
}

//-->
</script>
</HEAD>
<body bgcolor="#ffffff" leftmargin="0" topmargin="0" marginheight="0" marginwidth="0" onload=window_onload()>
<form name="frmPopArticulo" action="about:blank" method="post">
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
      <td valign="top" height="30"><span class="txtitulo">Catalogo Planogramas</span><span class="txcontenido">Selecciona 
        el Planograma haciendo clic en el nombre.<br>
        <br>
        </span> <script language="javascript">strRecordBrowserHTML()</script> 
        <span class="txcontenido"></span></td>
    </tr>
    <tr> 
      <td width="2%">&nbsp;</td>
      <td><input name="cmdCerrar" type="submit" class="boton" id="cmdCerrar" value="Cerrar" onclick="return cmdCerrar_onclick()"> 
        <br> <br> </td>
    </tr>
  </table>
</form>
</body>
</HTML>
