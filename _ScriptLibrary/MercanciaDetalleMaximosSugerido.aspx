<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaDetalleMaximosSugerido.aspx.vb" Inherits="com.isocraft.backbone.ccentral.MercanciaDetalleMaximosSugerido" codePage="28592"%>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaDetalleMaximosSugerido.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página de 
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : J.Antonio Hernández Dávila
    ' Version       : 1.0
    ' Last Modified : Martes, Noviembre 18, 2003
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<link href="../static/css/menu.css" rel="stylesheet">
<link href="../static/css/menu2.css" rel="stylesheet">
<link href="../static/css/estilo.css" rel="stylesheet">
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/tools.js"></script>
<script language="JavaScript" src="../static/scripts/calendar1.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">
<!--
function window_onload() {
  MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
  document.forms[0].action = "<%=strFormAction%>"; 
   
   var strMensaje = "<%=strMensaje%>";   
   var strRegistrosRecordBrowser = "<%=strRegistrosRecordBrowser%>";
    
   if (strMensaje.length > 0 ) {
       alert(strMensaje);
   } 
}

function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
	return(true);
}


function intFolioMaximo() {
	document.write("&nbsp;"+"<%=intFolioMaximo%>");
	return(true);
}
function strFechaMaximo() {
	document.write("&nbsp;"+"<%=strFechaMaximo%>");
	return(true);
}
function strRecordBrowserHTML(){  
     document.write("<%=strRecordBrowserHTML%>");   
}

function frmMercanciaDetalleMaximosSugerido_onsubmit() { 
   var regreso = true;        
   return(regreso);
}


function cmdImprimir_onclick() {
   printContent();
   return(true);
}

function cmdRegresar_onclick() {
   window.location = "MercanciaArchivoMaximoSugerido.aspx?strConsulta=Maximos&rdoFiltroConsulta=" + "<%=rdoFiltroConsulta%>" + "&rdoOrdenConsulta=" + "<%=rdoOrdenConsulta%>";
}

//-->
</script>
</head>
<body leftmargin="0" topmargin="0" onLoad="return window_onload()" marginheight="0" marginwidth="0">
<form name="frmMercanciaDetalleMaximosSugerido" onSubmit="return frmMercanciaDetalleMaximosSugerido_onsubmit()" action="about:blank" method="post">
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr> 
      <td valign="top" height="98" width="100%"><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
    <tr> 
      <td valign="top" height="34" width="100%"><img src="../static/images/pixel.gif" width="1" height="34"></td>
    </tr>
    <tr> 
      <td width="100%"> <table width="100%" border="0" cellpadding="0" cellspacing="0">
          <tr> 
            <td width="10" bgcolor="#ffffff"><img src="../static/images/pixel.gif" width="10" height="8"></td>
            <td width="583" class="tdmigaja"><div id="ToPrintTxtMigaja"><span class="txdmigaja">Está 
                en : </span><a href="mer003.htm" class="txdmigaja">Mercancía</a><span class="txdmigaja"> 
                : <a href="mer018.htm" class="txdmigaja">Inventarios</a></span><span class="txdmigaja"> 
                </span><span class="txdmigaja">: </span><span class="txdmigaja"> 
                </span><span class="txdmigaja"><a href="mer155bis.htm" class="txdmigaja">Máximos 
                por producto </a></span><span class="txdmigaja">: </span><span class="txdmigaja">Detalle 
                de sugerencia de máximos</span></div></td>
            <td width="182" class="tdfechahora"> <script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont"><span class="txtitulo">Detalle 
              de sugerencia de máximos</span><span class="txcontenido">La siguiente 
              tabla describe una sugerencia de máximos registrada por su sucursal 
              en la fecha descrita.</span> <script language="JavaScript">crearDatosSucursal()</script> 
              <div id='ToPrintHtmContenido'> 
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                  <tr> 
                    <td width="123" class="tdtittablas">Folio</td>
                    <td width="460" class="tdconttablas"><script language="javascript">intFolioMaximo()</script> 
                    </td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">Fecha de envío</td>
                    <td class="tdconttablas"><script language="javascript">strFechaMaximo()</script> 
                    </td>
                  </tr>
                </table>
                <br>
                <script language="JavaScript">strRecordBrowserHTML()</script>
              </div>
              <br> <input name="cmdRegresar" type="button" class="boton" value="Regresar" onClick="return cmdRegresar_onclick()"> 
              &nbsp;&nbsp;&nbsp; <input name="cmdImprimir" type="button" class="boton" value="Imprimir Sugerencia" onClick="return cmdImprimir_onclick()"> 
              &nbsp;&nbsp; </td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader">&nbsp;</td>
          </tr>
          <tr> 
            <td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script></td>
          </tr>
        </table></td>
    </tr>
  </table>
  <script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	new menu (MENU_ITEMS2, MENU_POS2);
	//-->
</script>
</form>
<iframe name="ifrPageToPrint" src="../static/PageToPrint.htm" width="0" height="0"></iframe>
</body>
</html>
