<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PopArticuloProveedorInsumosMateriaPrima.aspx.vb" Inherits="com.isocraft.backbone.ccentral.PopArticuloProveedorInsumosMateriaPrima" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons" %>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%  '====================================================================
    ' Page          : PopArticuloProveedorInsumosMateriaPrima.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Popup para selecionar el Articulo
    ' Copyright     : 2014 All rights reserved.
    ' Company       : Deintec
    ' Author        : Carlos Vazquez
    ' Version       : 1.0
    ' Last Modified : Miercoles, Agosto 13, 2014
    '====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<link href="../static/css/estilo.css" rel="stylesheet">
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--
    function window_onload() {
        MM_preloadImages('../static/images/bsalir_on.gif', '../static/images/bayuda_on.gif');
        document.forms(0).action = "<%=strFormAction%>";

	return (true);
}

function strRecordBrowserHTML() {
    document.write("<%=strRecordBrowserHTML%>");
    return (true);
}
function cmdCerrar_onclick() {
    ClosePopup("", "", "", "");
}

function ClosePopup(intArticuloId, strArticuloDescripcion, fltArticuloCostoReposicion) {
    var strCampoDestino = "";

    strCampoDestino = '<%=Request.QueryString("campoArticuloId")%>';
    if (strCampoDestino.length > 0) {
        opener.document.forms[0].elements[strCampoDestino].value = intArticuloId;
    }

    strCampoDestino = '<%=Request.QueryString("campoArticuloDescripcion")%>';
   if (strCampoDestino.length > 0) {
       opener.document.forms[0].elements[strCampoDestino].value = strArticuloDescripcion;
   }

   strCampoDestino = '<%=Request.QueryString("campoArticuloCostoReposicion")%>';
   if (strCampoDestino.length > 0) {
       opener.document.forms[0].elements[strCampoDestino].value = fltArticuloCostoReposicion;
   }

   <% if Request.QueryString("strEvalJs")<>"" then %>
    eval("<%=Request.QueryString("strEvalJs")%>");
    <% end if %>	

    self.close();
    return (true);
}

//-->
			</script>
</HEAD>
<body bgcolor="#ffffff" leftmargin="0" topmargin="0" marginheight="0" marginwidth="0">
<form name="frmPopArticuloProveedorInsumosMateriaPrima" action="about:blank" method="post">
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
      <td><input name="cmdCerrar" type="submit" class="boton" id="cmdCerrar" value="Cerrar" onclick="return cmdCerrar_onclick()"> 
        <br> <br> </td>
    </tr>
  </table>
</form>
</body>
</HTML>
