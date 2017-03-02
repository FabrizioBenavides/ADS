<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaReporteTomaFisica.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaReporteTomaFisica" codePage="28592"%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaReporteTomaFisica.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página para 
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Raúl Corral González
    ' Version       : 1.0
    ' Last Modified : Friday, October 31, 2003
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<meta name="description" content="Javascript Menu">
<meta name="keywords"    content="JavaScript menu, javascript, html, client side, netscape, explorer, IE, menu, DHTML, DOM, control">
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

var strPaginaAyuda
strPaginaAyuda = "<%=strThisPageName%>";

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

function strGetCustomDateTimeDMY(blnRegresarString){
	if(blnRegresarString){
	  return("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy") %>");
	}
	else {
	  document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy") %>");
	  return(true);
	}
}

function strGetCustomDateTimeNombreDia() {
	document.write("<%=clsCommons.strNombreDia(cdate(clsCommons.strGetCustomDateTime("MM/dd/yyyy"))) %>");
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

function strHrefMigaja1(){
	document.location.href='Mercancia.aspx';
}
function strHrefMigaja2(){
	document.location.href='CCRedirectorPOSAdmin.aspx?strPageName=MercanciaInventarios.aspx';
}
function strHrefMigaja3(){
	document.location.href='CCRedirectorPOSAdmin.aspx?strPageName=MercanciaInventariosRotativos.aspx';
}
function strHrefMigaja4(){
	document.location.href='';
}
function cmdRegresar_onclick() {
	strHrefMigaja3();
}

function strTituloMigaja1(){
	document.write("Mercancía");
}
function strTituloMigaja2(){
	document.write("Inventarios");
}
function strTituloMigaja3(){
	document.write("Inventarios rotativos");
}
function strTituloPrincipalDePagina() {
	document.write("Reporte para toma física de inventario");
}
function strDescripcionPrincipalDePagina() {
	document.write("Seleccione el día que deseea imprimir y oprimia \42Aceptar\42. El sistema desplegará los números de plano para el día elegido.");
}
function strRecordBrowserHTML() {
	document.write("<%=strGeneraTablaHTML%>");
}

function strGetCustomDateTimeAyer(blnRegresarString){
	if(blnRegresarString){
	  return("<%=strAyer %>");
	}
	else {
	  document.write("<%=strAyer %>");
	  return(true);
	}
}

function strAyerNombreDia(){
	document.write("<%=strAyerNombreDia %>");
	return(true);
}

function window_onload() {
	MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');

	//hdnDtmFechaConsulta1 Hoy
	document.forms(0).elements('hdnDtmFechaConsulta1').value = strGetCustomDateTimeDMY(true);
	
	//hdnDtmFechaConsulta2 Ayer
	document.forms(0).elements('hdnDtmFechaConsulta2').value = strGetCustomDateTimeAyer(true);

	var strChkDtmFechaConsulta="<%=strChkDtmFechaConsulta%>";
	if(strChkDtmFechaConsulta=="1"){
		document.forms(0).elements('chkDtmFechaConsulta1').checked=true;
	}
	if(strChkDtmFechaConsulta=="2"){
		document.forms(0).elements('chkDtmFechaConsulta2').checked=true;
	}

	<% if Len(Trim(strGeneraTablaHTML))>0 then %>
	document.forms(0).elements('cmdRegresar').style.display="";
	document.forms(0).elements('cmdImprimir').style.display="";
	<% end if %>
}

function frmMercanciaReporteTomaFisica_onsubmit() {
	document.forms(0).action="MercanciaReporteTomaFisica.aspx"
	return(true); 
}

function cmdImprimir_onclick() {
	hdnTotalDePartidas = (document.forms(0).elements('hdnTotalDePartidas').value) * 1;
	dtmFechaConsultaElegida = document.forms(0).elements('dtmFechaConsultaElegida').value;
           
	parametros = "";
	parametros = parametros + "strCmd=imprimir";
	
	for(i=1;i<=hdnTotalDePartidas;i++){
		parametros = parametros + "&intPlanoId=" + document.forms(0).elements("intPlanoId_"+i).value;
	}
	
	parametros = parametros + "&dtmFechaConsulta=" + dtmFechaConsultaElegida;
	
	document.ifrOculto.document.location.href="MercanciaReporteTomaFisicaIframe.aspx?" + parametros;
}

//**************************************
function fnImprimirPartida(intPlanoId,blnPlanoSucursalCapturado,dtmFechaConsulta){
     
	parametros = "";
	parametros = parametros + "strCmd=imprimir";
	parametros = parametros + "&intPlanoId=" + intPlanoId + "&dtmFechaConsulta=" + dtmFechaConsulta;	
	document.ifrOculto.document.location.href="MercanciaReporteTomaFisicaIframe.aspx?" + parametros;
}

function fnGraficoPartida(intPlanoId,blnPlanoSucursalCapturado,dtmPlanoRegistro){
    strNombreArchivo = "../static/PDF/Planos/Pa" + intPlanoId + ".pdf";
	window.open(strNombreArchivo,"winPdf");	
}

function fnTextoPartida(intPlanoId,blnPlanoSucursalCapturado,dtmPlanoRegistro){
	parametros = "";
	parametros = parametros + "intPlanoId=" + intPlanoId;
	document.location.href="MercanciaConsultarPlanogramaTexto.aspx?" + parametros;
}
//**************************************
//-->
</script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0"  onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaReporteTomaFisica" onSubmit="return frmMercanciaReporteTomaFisica_onsubmit()">
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
                Está en : </span> <a href="javascript:strHrefMigaja1();" class="txdmigaja"> 
                <script language="javascript">strTituloMigaja1()</script>
                </a><span class="txdmigaja"> : <a href="javascript:strHrefMigaja2();" class="txdmigaja"> 
                <script language="javascript">strTituloMigaja2()</script>
                </a> : <a href="javascript:strHrefMigaja3();" class="txdmigaja"> 
                <script language="javascript">strTituloMigaja3()</script>
                </a> : 
                <script language="javascript">strTituloPrincipalDePagina()</script>
                </span></div></td>
            <td width="182" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script></td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont"> <span class="txtitulo"> 
              <script    language="javascript">strTituloPrincipalDePagina()</script>
              </span> <span class="txcontenido"> 
              <script language="javascript">strDescripcionPrincipalDePagina()</script>
              <br>
              </span> <script language="JavaScript">crearDatosSucursal()</script> 
              <br> <div id="ToPrintHtmContenido"> <span class="txsubtitulo"> <img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle"> 
                Día a imprimir</span> 
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                  <tr> 
                    <td width="91" class="tdtittablas"><input type="radio"  name="chkDtmFechaConsulta" id="chkDtmFechaConsulta1" value="1" checked>
                      Hoy 
                      <input type="hidden" name="hdnDtmFechaConsulta1"></td>
                    <td width="477" valign="middle" 
                          class="tdconttablas"><script language="javascript">strGetCustomDateTimeDMY(false);document.write(" ");strGetCustomDateTimeNombreDia();</script></td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas"><input type="radio"  name="chkDtmFechaConsulta" id="chkDtmFechaConsulta2" value="2">
                      Ayer 
                      <input type="hidden" name="hdnDtmFechaConsulta2"></td>
                    <td valign="middle" 
                          class="tdconttablas"><script language="javascript">strGetCustomDateTimeAyer(false);document.write(" ");strAyerNombreDia();</script></td>
                  </tr>
                </table><span class="txsubtitulo">
                <br>
                <input name="cmdConsultar" type="submit" class="boton" value="Consultar">
                <br>
                <br>
                <!-- -->
                <script language="javascript">strRecordBrowserHTML()</script>
              </div>
              <br> <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="317"> &nbsp;&nbsp;&nbsp; <input	name="cmdRegresar"   type="button" class="boton" value="Regresar" 
											onClick="return cmdRegresar_onclick()" style="DISPLAY:none"> 
                    &nbsp;&nbsp;&nbsp; <input	name="cmdImprimir"   type="button" class="boton" value="Imprimir todos los reportes" 
											onClick="return cmdImprimir_onclick()" style="DISPLAY:none"> 
                  </td>
                </tr>
              </table>
              <br></td>
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
<iframe name="ifrOculto" height="00" width="00" src=""></iframe>
<iframe name="ifrPageToPrint" src="../static/PageToPrint.htm" width="0" height="0"></iframe>
</body>
</html>
