<%@ Import Namespace="Benavides.POSAdmin.Commons" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PopProveedor.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsPopProveedor"%>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<% 
'====================================================================
' Page          : PopProveedor.aspx
' Title         : Administracion POS y BackOffice
' Description   : Consulta y seleccion de proveedor
' Copyright     : 2008
' Company       : BENAVIDES
' Author        : J.Antonio Hernández Dávila
' Version       : 1.0
' Last Modified : 
'                 Sábado, 25 de Octubre, 2003
'                 20 de Marzo 2007             Actualizacion por SAP
'                 Jueves, 14 de Febrero 2008   ORDENES ASR
'                 Viernes 15 de Mayo    2009   Validacion Vigencia proveedor
'                 25 de Enero 2011 [JAHD]      Actualizacion por CADENA
'                 16 de Marzo 2012 [JAHD]      Remisiones de compra directa
'                 18 de Septiembre 2012 [JAHD] No Captura de Costo de Articulo
'====================================================================	
%>
<link href="../static/css/estilo.css" rel="stylesheet">
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--
var blnSinSeleccion =true;

// Funcion donde Eliminamos los guiones de alguna cadena.
function strEliminaGuiones(objCampo){
 var strInicial, strFinal, strResultado;
 
 strInicial = objCampo;
 strFinal = strInicial.split("-");

    strResultado = '';
    for (intContador = 0; intContador < strFinal.length; intContador++){
         strResultado = strResultado + strFinal[intContador];  
    }
    
 return(strResultado); 
}

function window_onload() {
	document.forms[0].action = "<%=strFormAction%>";
	return(true);
}

function strRecordBrowserHTML() {
  document.write("<%=strRecordBrowserHTML%>");
  return(true);
}

function cmdCerrar_onclick() {
   ClosePopup(0,"","","","","","","");
}

function ClosePopup(intProveedorId,strProveedorNombreId,strProveedorRazonSocial,strProveedorRFC,blnSoloOrden,blnOrdenDisponible,blnCapturaRemision, blnRemisionDisponible, blnCapturaCosto, fltMargenFactura)
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
   
   strCampoDestino = '<%=Request.QueryString("campoProveedorRFC")%>';  
   if (strCampoDestino.length > 0) {
       opener.document.forms[0].elements[strCampoDestino].value = strEliminaGuiones(strProveedorRFC);
   }  

   strCampoDestino = '<%=Request.QueryString("campoCapturaRemision")%>';  
   if (strCampoDestino.length > 0) {
       opener.document.forms[0].elements[strCampoDestino].value = blnCapturaRemision;
   }   
   strCampoDestino = '<%=Request.QueryString("campoRemisionDisponible")%>';  
   if (strCampoDestino.length > 0) {
       opener.document.forms[0].elements[strCampoDestino].value = blnRemisionDisponible;
   }
       
   strCampoDestino = '<%=Request.QueryString("campoSoloOrden")%>';  
   if (strCampoDestino.length > 0) {
       opener.document.forms[0].elements[strCampoDestino].value = blnSoloOrden;
   }   
   strCampoDestino = '<%=Request.QueryString("campoOrdenDisponible")%>';  
   if (strCampoDestino.length > 0) {
       opener.document.forms[0].elements[strCampoDestino].value = blnOrdenDisponible;
   } 
    
   strCampoDestino = '<%=Request.QueryString("campoCapturaCosto")%>';  
   if (strCampoDestino.length > 0) {
       opener.document.forms[0].elements[strCampoDestino].value = blnCapturaCosto;
   }   
   strCampoDestino = '<%=Request.QueryString("campoMargenFactura")%>';  
   if (strCampoDestino.length > 0) {
       opener.document.forms[0].elements[strCampoDestino].value = fltMargenFactura;
   }  
      
   <% if Request.QueryString("strEvalJs")<>"" then %>
       eval("<%=Request.QueryString("strEvalJs")%>");
   <% end if %>
   
   blnSinSeleccion = false;
   self.close();   
}

function window_onunload() {
if(blnSinSeleccion) {
   ClosePopup(0,"","","","","","","","",0); 
   }
}

//-->
			</script>
</HEAD>
<body bgcolor="#ffffff" leftmargin="0" topmargin="0" marginheight="0" marginwidth="0" onunload="return window_onunload()">
<form name="frmPopProveedor" action="about:blank" method="post">
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
