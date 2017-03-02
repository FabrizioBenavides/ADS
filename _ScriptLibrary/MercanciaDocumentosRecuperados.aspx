<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaDocumentosRecuperados.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaDocumentosRecuperados" codePage="28592"%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaDocumentosRecuperados.aspx
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
%>
<meta name="description" content="Javascript Menu">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
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

function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
	return(true);
}

function frmMercanciaDocumentosRecuperados_onsubmit() {
  valida=true;
  //No hay nada que validar submit en Automatico
  document.frmMercanciaDocumentosRecuperados.action="<%=strFormAction%>";
  document.frmMercanciaDocumentosRecuperados.submit();
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
function strHrefMercanciaConsultarFacturaRemision(){
	document.location.href='MercanciaConsultarFacturaRemision.aspx';
}
function cmdOtraConsulta_onclick() {
	//ir a la pagina de Archivo de Facturas y remisiones
	strHrefMercanciaConsultarFacturaRemision();
}
function cmdTerminar_onclick() {
	strHrefMercancia();
}
function cmdImprimir_onclick() {
	printContent();
}
function strTipoDocumentosRecuperados(){
	document.write("<%=strmTipoDocumentosRecuperados%>");
}
function strRangoDeConsulta(){
	document.write("<%=strmRangoDeConsulta%>");
}
function window_onload() {
	MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
	strRdoOrdenarPor = '<%=strRdoOrdenarPor%>';
	
	if(strRdoOrdenarPor=='1'){
		document.forms[0].elements['rdoOrdenarPor1'].checked=true;
	}
	if(strRdoOrdenarPor=='2'){
		document.forms[0].elements['rdoOrdenarPor2'].checked=true;
	}
	if(strRdoOrdenarPor=='3'){
		document.forms[0].elements['rdoOrdenarPor3'].checked=true;
	}
	if(strRdoOrdenarPor=='4'){
		document.forms[0].elements['rdoOrdenarPor4'].checked=true;
	}
	
	document.forms[0].elements['rdoQueDeseaRecuperar'].value='<%=strRdoQueDeseaRecuperar%>';
	document.forms[0].elements['rdoRangoDeConsulta'].value='<%=strRdoRangoDeConsulta%>';
}
function rdoOrdenarPor1_onclick() {
	frmMercanciaDocumentosRecuperados_onsubmit();
}
function rdoOrdenarPor2_onclick() {
	frmMercanciaDocumentosRecuperados_onsubmit();
}
function rdoOrdenarPor3_onclick() {
	frmMercanciaDocumentosRecuperados_onsubmit();
}
function rdoOrdenarPor4_onclick() {
	frmMercanciaDocumentosRecuperados_onsubmit();
}

//-->
</script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaDocumentosRecuperados" onSubmit="return frmMercanciaDocumentosRecuperados_onsubmit()">
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
            <td width="583" class="tdmigaja"><div id="ToPrintTxtMigaja"><span class="txdmigaja"> 
                Está en: </span> <a href="javascript:strHrefMercancia();" class="txdmigaja">Mercancía</a><span class="txdmigaja">: 
                <a href="javascript:strHrefMercanciaEntradas();" class="txdmigaja">Entradas</a>: 
                <a href="javascript:strHrefMercanciaEntradasRecepcion();" class="txdmigaja">Recepción 
                de mercancía</a>: <a href="javascript:strHrefMercanciaConsultarFacturaRemision();" title="Archivo de facturas y remisiones"
												class="txdmigaja">Archivo de facturas,remisiones</a>: 
                <a title="Documentos recuperados">Documentos recuper</a></span></div></td>
            <td width="182" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script></td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont"> <span class="txtitulo">Documentos 
              recuperados</span> <span class="txcontenido">La siguiente lista 
              contiene los documentos que se ajustan a su criterio de búsqueda. 
              Elija uno para consultar y luego haga click sobre su número de folio 
              para ver su detalle.<br>
              </span> <script language="JavaScript">crearDatosSucursal()</script> 
              <span class="txsubtitulo"><br>
              <img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle"> 
              Resultados de la búsqueda</span> <br> 
              <!-- -->
              <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="155" class="tdtittablas">Documentos recuperados:</td>
                  <td width="428" class="tdconttablas"><script language="javascript">strTipoDocumentosRecuperados()</script></td>
                </tr>
                <tr> 
                  <td class="tdtittablas">Rango de consulta:</td>
                  <td class="tdconttablas"><script language="javascript">strRangoDeConsulta()</script></td>
                </tr>
                <tr> 
                  <td class="tdtittablas">Ordenar por:</td>
                  <td valign="top" class="tdconttablas"> <input type="radio" name="rdoOrdenarPor" id="rdoOrdenarPor1" value="1" onClick="return rdoOrdenarPor1_onclick()">
                    No. proveedor</td>
                </tr>
                <tr> 
                  <td class="tdtittablas">&nbsp;</td>
                  <td class="tdconttablas"> <input type="radio" name="rdoOrdenarPor" id="rdoOrdenarPor2" value="2" onClick="return rdoOrdenarPor2_onclick()">
                    No. documento</td>
                </tr>
                <tr> 
                  <td class="tdtittablas">&nbsp;</td>
                  <td class="tdconttablas"> <input type="radio" name="rdoOrdenarPor" id="rdoOrdenarPor3" value="3" onClick="return rdoOrdenarPor3_onclick()">
                    Folio (nota de entrada)</td>
                </tr>
                <tr> 
                  <td class="tdtittablas">&nbsp;</td>
                  <td class="tdconttablas"> <input type="radio" name="rdoOrdenarPor" id="rdoOrdenarPor4" value="4" onClick="return rdoOrdenarPor4_onclick()">
                    Fecha</td>
                </tr>
              </table>
              <div id="ToPrintHtmContenido"> 
                <script language="javascript">strRecordBrowserHTML()</script>
              </div>
              <br> &nbsp;&nbsp;&nbsp; <input name="cmdOtraConsulta" type="button" class="boton" value="Otra consulta" onClick="return cmdOtraConsulta_onclick()"> 
              &nbsp;&nbsp;&nbsp; <input name="cmdImprimir" type="button" class="boton" value="Imprimir la lista" onClick="return cmdImprimir_onclick()"> 
              <br> </td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader"><script language="javascript">strGeneraTablaAyuda('');</script> 
            </td>
          </tr>
          <tr> 
            <td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script></td>
          </tr>
        </table></td>
    </tr>
    <tr> 
      <td> <input type="hidden" name="rdoQueDeseaRecuperar"> <input type="hidden" name="rdoRangoDeConsulta"></td>
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
