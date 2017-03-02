<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MercanciaDetalleProductosAgotados.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaDetalleProductosAgotados" codePage="28592"%>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaDetalleProductosAgotados.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página que muestra el detalle de los productos negados 
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Jorge Tamez Sánchez
    ' Version       : 1.0
    ' Last Modified : Lunes, Noviembre 17, 2003
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<link rel="stylesheet" href="../static/css/menu.css">
<link rel="stylesheet" href="../static/css/menu2.css">
<link rel="stylesheet" href="../static/css/estilo.css">
<script language="JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">
<!--

// Despliega basicos
function strCompaniaSucursal() {
	document.write(<%=intCompaniaId%> + " - " + <%=intSucursalId%>);
	return(true);
}
function strSucursalNombre() {
	document.write("&nbsp;"+"<%=strSucursalNombre%>");
	return(true);
}
function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
	return(true);
}
function strUsuarioNombre() {
	document.write("<%=strUsuarioNombre%>");
	return(true);
}
function strSucursalNombre() {
	document.write("&nbsp;"+"<%=strSucursalNombre%>");
	return(true);
}
function frmMercanciaDetalleProductosAgotados_onsubmit() {
  strFechaInicial = "<%=Request.QueryString("dtmFechaInicial")%>";
  strFechaFinal = "<%=Request.QueryString("dtmFechaFinal")%>";  
  
 if (strFechaInicial.length > 0 && strFechaFinal.length > 0){
     document.forms[0].action = "MercanciaArchivoProductosAgotados.aspx?strCmd=Consultar" 
    } 
  else{
     document.forms[0].action = "MercanciaArchivoProductosAgotados.aspx" 
  }  
 return(true);
}

function strFechaConsulta(){
 document.write("<%=strFechaConsulta%>");
 return(true);
}
// Folio Inventario
function intFolioInventarioAgotadoId(){
 document.write("<%=intFolioInventarioAgotadoId%>");
 return(true);
}

// RecordBrowser
function strRecordBrowserHTML(){
 document.write("<%=strRecordBrowserHTML%>");
 return(true);
}

// Load
function window_onload() {
 MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
 document.forms[0].action = "<%=strFormAction%>";
 
 document.forms[0].elements['dtmFechaInicial'].value = "<%=Request.QueryString("dtmFechaInicial")%>";
 document.forms[0].elements['dtmFechaFinal'].value = "<%=Request.QueryString("dtmFechaFinal")%>";
 return(true);
}

function cmdImprimir_onclick() {
 printContent();
 return(true);
}

//-->
</script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaDetalleProductosAgotados" onSubmit="return frmMercanciaDetalleProductosAgotados_onsubmit()">
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
            <td width="10" bgcolor="#FFFFFF"><img src="../static/images/pixel.gif" width="10" height="8"></td>
            <td width="583" class="tdmigaja"><div id="ToPrintTxtMigaja"><span class="txdmigaja">Est&aacute; 
                en:</span> <a href="Mercancia.aspx" class="txdmigaja">Mercanc&iacute;a</a><span class="txdmigaja"> 
                : <a href="javascript:strRedireccionaPOSAdmin('MercanciaInventarios.aspx')" class="txdmigaja">Inventarios</a></span><span class="txdmigaja"> 
                </span><span class="txdmigaja">: </span><span class="txdmigaja"> 
                <a href="javascript:strRedireccionaPOSAdmin('MercanciaInventariosProductosAgotados.aspx')" class="txdmigaja">Productos 
                agotados </a></span> <span class="txdmigaja">: </span> <span class="txdmigaja">Detalle 
                de reporte de productos agotados</span> </div></td>
            <td width="182" class="tdfechahora"> <script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top"><table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="100%" colspan="3" valign="top" class="tdtablacont"> 
                    <p><span class="txtitulo">Detalle de reporte de productos 
                      agotados</span> 
                      <script language="JavaScript">crearDatosSucursal()</script>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                      <tr> 
                        <td width="112" class="tdtittablas">Folio consultado:</td>
                        <td width="119" valign="middle" class="tdconttablas"><script language="JavaScript">intFolioInventarioAgotadoId()</script></td>
                        <td width="46" valign="middle" class="tdtittablas">Fecha:</td>
                        <td width="291" valign="middle" class="tdconttablas"><script language="JavaScript">strFechaConsulta()</script> 
                          <input type="hidden" name="dtmFechaInicial"> <input name="dtmFechaFinal" type="hidden"></td>
                      </tr>
                    </table>
                    <br> <div id="ToPrintHtmContenido"> 
                      <script language="JavaScript">strRecordBrowserHTML()</script>
                    </div>
                    <br> <input name="cmdVerFolio" type="submit" class="boton" id="cmdVerFolio" value="Ver otro folio"> 
                    &nbsp;&nbsp; <input name="cmdImprimir" type="button" class="boton" id="cmdImprimir" value="Imprimir reporte" onClick="return cmdImprimir_onclick()"> 
                    <br> <br> </td>
                </tr>
              </table></td>
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
