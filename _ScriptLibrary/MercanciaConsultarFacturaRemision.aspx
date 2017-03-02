<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaConsultarFacturaRemision.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaConsultarFacturaRemision" codePage="28592"%>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaConsultarFacturaRemision.aspx
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

function frmMercanciaConsultarFacturaRemision_onsubmit() {
  valida=true;
  document.frmMercanciaConsultarFacturaRemision.action='MercanciaDocumentosRecuperados.aspx';
  return(valida);
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
<form action="about:blank" method="post" name="frmMercanciaConsultarFacturaRemision" onSubmit="return frmMercanciaConsultarFacturaRemision_onsubmit()">
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
              de mercanc&iacute;a</a> : Archivo de facturas y remisiones</span></td>
            <td width="182" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script></td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont"> <span class="txtitulo">Archivo 
              de facturas y remisiones</span> <span class="txcontenido">Utilice 
              los filtros siguientes para configurar la consulta en el archivo, 
              y luego oprima "Consultar".<br>
              </span> <script language="JavaScript">crearDatosSucursal()</script> 
              <br> <span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absmiddle"> 
              Filtros de consulta</span> <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td class="tdtittablas">&iquest;Que desea recuperar?:</td>
                  <td width="424" class="tdconttablas"> <input type="radio" name="rdoQueDeseaRecuperar" id="rdoQueDeseaRecuperar1" value="1" checked>
                    Remisiones&nbsp;&nbsp;&nbsp; <input type="radio" name="rdoQueDeseaRecuperar" id="rdoQueDeseaRecuperar2" value="2">
                    Facturas </td>
                </tr>
                <tr> 
                  <td colspan="2">&nbsp;</td>
                </tr>
                <tr> 
                  <td class="tdtittablas">Rango de consulta:</td>
                  <td class="tdconttablas"> <input type="radio" name="rdoRangoDeConsulta" id="rdoRangoDeConsulta1" value="1" checked>
                    Mes actual&nbsp;&nbsp;&nbsp;&nbsp; <input type="radio" name="rdoRangoDeConsulta" id="rdoRangoDeConsulta2" value="2">
                    Mes anterior </td>
                </tr>
                <tr> 
                  <td colspan="2">&nbsp;</td>
                </tr>
                <tr> 
                  <td width="144" class="tdtittablas">Ordenar por:</td>
                  <td class="tdconttablas"> <input type="radio" name="rdoOrdenarPor" id="rdoOrdenarPor1" value="1" checked>
                    N&uacute;mero del proveedor </td>
                </tr>
                <tr> 
                  <td class="tdtittablas">&nbsp;</td>
                  <td class="tdconttablas"> <input type="radio" name="rdoOrdenarPor" id="rdoOrdenarPor2" value="2">
                    N&uacute;mero de factura/remisi&oacute;n </td>
                </tr>
                <tr> 
                  <td class="tdtittablas">&nbsp;</td>
                  <td height="40" class="tdconttablas"> <input type="radio" name="rdoOrdenarPor" id="rdoOrdenarPor3" value="3">
                    Nota (folio de confirmaci&oacute;n) </td>
                </tr>
                <tr> 
                  <td>&nbsp;</td>
                  <td height="27" class="tdconttablas"> <input type="radio" name="rdoOrdenarPor" id="rdoOrdenarPor4" value="4">
                    Fecha de confirmaci&oacute;n </td>
                </tr>
              </table>
              <br> <input name="cmdRegresar" type="button" class="boton" value="Regresar" onClick="return cmdRegresar_onclick()"> 
              <input name="strCmd" type="submit" class="boton" value="Consultar"> 
              <br> <br> </td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader"> <script language="javascript">strGeneraTablaAyuda('');</script> 
            </td>
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
</body>
</html>
