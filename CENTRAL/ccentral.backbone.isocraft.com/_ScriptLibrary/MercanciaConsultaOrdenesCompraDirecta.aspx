<%@ Page Language="vb"  AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaConsultaOrdenesCompraDirecta.aspx.vb" Inherits="com.isocraft.backbone.ccentral.MercanciaConsultaOrdenesCompraDirecta" codePage="28592"%>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%
'====================================================================
' Page          : MercanciaConsultaOrdenesCompraDirecta.aspx
' Title         : Administracion POS y BackOffice
' Description   : Consulta las ordenes de compra de ASR disponibles para el proveedor
' Copyright     : 2008
' Company       : BENAVIDES
' Author        : J.Antonio Hern�ndez D�vila
' Version       : 1.0
' Last Modified : 
'                 Jueves, 14 de Febrero 2008   ORDENES ASR
'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
'====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<link href="../static/css/estilo.css" rel="stylesheet">
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--
var blnSinSeleccion =true;

function window_onload() {
	MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
	document.forms[0].action = "<%=strFormAction%>";
	return(true);
}
function strRecordBrowserHTML() {
  document.write("<%=strOrdenesCompra%>");
  return(true);
}

function cmdVerDetalleOrden(intFolioOrdenId) {
   url = 'MercanciaConsultaDetalleOrdenCompraDirecta.aspx';       
   par = '?intProveedorId=' + '<%=Request.QueryString("intProveedorId")%>' + '&'; 
   par = par + 'strProveedorNombreId=' + '<%=Request.QueryString("strProveedorNombreId")%>'  + '&'; 
   par = par + 'strProveedorRazonSocial=' + '<%=Request.QueryString("strProveedorRazonSocial")%>' + '&'; 
   par = par + 'intFolioOrdenId=' + intFolioOrdenId;
      
   var WinVerDetaller = window.open(url+par,'PopVerDetalleOrden','width=720,height=600,left=20,top=10,resizable=no,scrollbars=yes,menubar=no,status=no' );
   return;
}

function cmdCerrar_onclick() {
   ClosePopup("");	
}

function ClosePopup(intFolioOrdenId)
{
   var strCampoDestino = "";

   strCampoDestino = '<%=Request.QueryString("campoOrdenId")%>';  
   if (strCampoDestino.length > 0) {   
       opener.document.forms[0].elements[strCampoDestino].value = intFolioOrdenId;
   }
   
   <% if Request.QueryString("strEvalJs")<>"" then %>
       eval("<%=Request.QueryString("strEvalJs")%>");
   <% end if %>	

   blnSinSeleccion = false;
   self.close();  
}

function window_onunload() {
if(blnSinSeleccion) {
   ClosePopup(""); 
   }
}

//-->
</script>
</HEAD>
<body bgcolor="#ffffff" leftmargin="0" topmargin="0" marginheight="0" marginwidth="0" onunload="return window_onunload()">
<form name="frmConsultaOrdenesCompraDirecta.aspx" action="about:blank" method="post">
  <table height="158" cellspacing="0" cellpadding="0" width="100%" bgcolor="#ffffff" border="0">
    <tr> 
      <td class="tdlogopop" colspan="2" height="54"><script language="javascript">crearTablaHeaderPop()</script></td>
    </tr>
    <tr> 
      <td width="2%" >&nbsp;</td>
      <td valign="top" width="99%" height="10">&nbsp;</td>
    </tr>
    <tr> 
      <td width="2%">&nbsp;</td>
      <td valign="top" height="30"><span class="txsubtitulo"><%= strTituloConsulta%></span> 
        <span class="txcontenido"> 
        <script language="javascript">strRecordBrowserHTML()</script>
        </span> </td>
    </tr>
    <tr> 
      <td width="2%">&nbsp;</td>
      <td><input name="cmdCerrar" type="button" class="boton" id="cmdCerrar" value="Cerrar" onclick="return cmdCerrar_onclick()"> 
        <br> <br> </td>
    </tr>
  </table>
</form>
</body>
</HTML>
