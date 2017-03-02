<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="popRemisionCompraDirectaConsultar.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsPopRemisionCompraDirectaConsultar" codePage="28592" %>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaRemisionCompraDirectaCaptura.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Consulta Remisiones de Compra Directa
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

function ActivateRow(intRowToShow) {
   var table = document.all? document.all.tableRegistro : document.getElementById('tableRegistro');
   table.rows[intRowToShow-1].style.display = 'none';
   table.rows[intRowToShow].style.display = '';
   table.rows[intRowToShow + 1].style.display = '';
}

function DeactivateRow(intRowToHide) {
  
   var table = document.all? document.all.tableRegistro : document.getElementById('tableRegistro');   
   table.rows[intRowToHide- 1].style.display = '';
   table.rows[intRowToHide].style.display = 'none';
   table.rows[intRowToHide+ 1].style.display = 'none';	
}

function strRecordBrowserHTML() {
  document.write("<%=strRecordBrowserHTML%>");
  return(true);
}

function cmdCerrar_onclick() {
   ClosePopup("","");	
}

function ClosePopup(intRemisionCompraDirectaId,intRemisionCompraDirectaFolio)
{
   var strCampoDestino = "";

   strCampoDestino = '<%=Request.QueryString("campoRemisionId")%>';  
   if (strCampoDestino.length > 0) {   
       opener.document.forms[0].elements[strCampoDestino].value = intRemisionCompraDirectaId;
   }
   
   strCampoDestino = '<%=Request.QueryString("campoRemisionFolio")%>';  
   if (strCampoDestino.length > 0) {   
       opener.document.forms[0].elements[strCampoDestino].value = intRemisionCompraDirectaFolio;
   }
      
   <% if Request.QueryString("strEvalJs")<>"" then %>
       eval("<%=Request.QueryString("strEvalJs")%>");
   <% end if %>
        
    blnSinSeleccion = false;
	self.close();
    return(true);
}

function window_onload() {
 <%=strCierraDetalleTablaRemision%>
}

function window_onunload() {
if(blnSinSeleccion) {
      ClosePopup("","");
   }
}
//-->
</script>
</HEAD>
<body bgcolor="#ffffff" leftmargin="0" topmargin="0" marginheight="0" marginwidth="0" onLoad="return window_onload()" onunload="return window_onunload()">
<form name="frmPopRemisionCompraDirectaConsultar" action="about:blank" method="post">
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
      <td valign="top" height="30" width="99%"><span class="txtitulo">Remisiones 
        </span><span class="txcontenido">Selecciona la remisión haciendo clic 
        en el Folio.<br>
        </span> <script language="javascript">strRecordBrowserHTML()</script> 
      </td>
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
