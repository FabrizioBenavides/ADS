<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaConfirmarRemisionElectronica.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaConfirmarRemisionElectronica" codePage="28592"%>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaConfirmarRemisionElectronica.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página para 
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Raúl Corral González
    ' Version       : 1.0
    ' Last Modified : Day, Month Day, 2003
	'                 20 de Marzo 2007             Actualizacion por SAP
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
%><html>
<head>
<meta name="description" content="Javascript Menu">
<meta name="keywords" content="JavaScript menu, javascript, html, client side, netscape, explorer, IE, menu, DHTML, DOM, control">
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
function window_onload() {
	MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
}
function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
	return(true);
}
function frmMercanciaConfirmarRemisionElectronica_onsubmit() {
    valida=true;
	return(valida);
}
function strRecordBrowserHTML() {
	document.write("<%=strRecordBrowserHTML%>");
	return(true);
}
function strHrefMercancia(){
	document.location.href='Mercancia.aspx';
}
function strHrefMercanciaEntradas(){
	document.location.href='MercanciaEntradas.aspx';
}
function strHrefMercanciaEntradasRecepcion(){
	document.location.href='MercanciaEntradasRecepcion.aspx';
}

function cmdRegresar_onclick() {
	strHrefMercanciaEntradasRecepcion();
}
//-->
</script>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaConfirmarRemisionElectronica" onSubmit="return frmMercanciaConfirmarRemisionElectronica_onsubmit()">
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
            <td width="583" class="tdmigaja"><span class="txdmigaja"> Est&aacute; 
              en : </span> <a href="javascript:strHrefMercancia();" class="txdmigaja">Mercanc&iacute;a</a><span class="txdmigaja"> 
              : <a href="javascript:strHrefMercanciaEntradas();" class="txdmigaja">Entradas</a> 
              : <a href="javascript:strHrefMercanciaEntradasRecepcion();" class="txdmigaja">Recepci&oacute;n 
              de mercanc&iacute;a</a> : Confirmar remisi&oacute;n electr&oacute;nica</span></td>
            <td width="187" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont"><span class="txtitulo">Confirmar 
              remisi&oacute;n electr&oacute;nica</span><span class="txcontenido">Para 
              confirmar una remisi&oacute;n electr&oacute;nica, elija primero 
              un proveedor con remisiones pendientes. Esto lo llevar&aacute; a 
              la lista de remisiones, donde podr&aacute; elegir una para confirmar.<br>
              </span> <script language="JavaScript">crearDatosSucursal()</script> 
              <br> <script language="javascript">strRecordBrowserHTML()</script> 
              <br> <input name="cmdRegresar" type="button" class="boton" value="Regresar" onClick="return cmdRegresar_onclick()"> 
              <br> <br> </td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader"><script language="javascript">strGeneraTablaAyuda('');</script> 
            </td>
          </tr>
          <tr> 
            <td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script> 
            </td>
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
</body>
</html>
