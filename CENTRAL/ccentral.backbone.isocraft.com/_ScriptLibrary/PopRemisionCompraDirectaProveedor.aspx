<%@ Import Namespace="Benavides.POSAdmin.Commons" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PopRemisionCompraDirectaProveedor.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsPopRemisionCompraDirectaProveedor" codePage="28592" %>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<% 
    '====================================================================
    ' Page          : PopRemisionCompraDirectaProveedor.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Consulta y seleccion de proveedor
    ' Copyright     : 2012 All rights reserved.
    ' Company       : Farmacias Benavides
    ' Author        : [JAHD] 
    ' Version       : 1.0
    ' Last Modified : 
    '                 16 de Marzo 2012 [JAHD]  remisiones de compra directa
    '====================================================================	
%>
<link href="../static/css/estilo.css" rel="stylesheet">
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--
var blnSinSeleccion =true;

function strRecordBrowserHTML() {
  document.write("<%=strRecordBrowserHTML%>");
  return(true);
}

function cmdCerrar_onclick() {
   ClosePopup("","","");
}

function ClosePopup(intProveedorId,strProveedorNombreId,strProveedorRazonSocial)
{ 
   var strCampoDestino = "";
  
   strCampoDestino = '<%=Request.QueryString("campoProveedorId")%>';  
   if (strCampoDestino.length > 0) {
       opener.document.forms[0].elements[strCampoDestino].value = intProveedorId;
   }
   
   strCampoDestino = '<%=Request.QueryString("campoProveedorNombreId")%>';  
   if (strCampoDestino.length > 0) {
       opener.document.forms[0].elements[strCampoDestino].value = strProveedorNombreId;
   }    
   
   strCampoDestino = '<%=Request.QueryString("campoProveedorRazonSocial")%>';  
   if (strCampoDestino.length > 0) {
       opener.document.forms[0].elements[strCampoDestino].value = strProveedorRazonSocial;
   }   
   
   <% if Request.QueryString("strEvalJs")<>"" then %>
       eval("<%=Request.QueryString("strEvalJs")%>");
   <% end if %>
   
   blnSinSeleccion = false;
   self.close();   
   return(true);
}

function window_onunload() {
if(blnSinSeleccion) {
   ClosePopup("","",""); 
   }
}

//-->
			</script>
</HEAD>
<body bgcolor="#ffffff" leftmargin="0" topmargin="0" marginheight="0" marginwidth="0" onunload="return window_onunload()">
<form name="frmPopRemisionCompraDirectaProveedor" action="about:blank" method="post">
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
      <td valign="top" height="30"><span class="txtitulo">Proveedores</span><span class="txcontenido">Selecciona 
        el Proveedor haciendo clic en el nombre.<br>
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
