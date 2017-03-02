<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaConsultarFacturaRemisionManual.aspx.vb" Inherits="com.isocraft.backbone.ccentral.MercanciaConsultarFacturaRemisionManual" codePage="28592"%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaConsultarFacturaRemisionManual.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página para 
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Raúl Corral González
    ' Version       : 1.0
    ' Last Modified : Day, Month Day, 2003
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<meta content="Javascript Menu" name="description">
<meta content="JavaScript menu, javascript, html, client side, netscape, explorer, IE, menu, DHTML, DOM, control" name="keywords">
<link href="../static/css/menu.css" rel="stylesheet">
<link href="../static/css/menu2.css" rel="stylesheet">
<link href="../static/css/estilo.css" rel="stylesheet">
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

function strHrefMercancia(){
	document.location.href='Mercancia.aspx';
}
function strHrefMercanciaEntradas(){
	document.location.href='CCRedirectorPOSAdmin.aspx?strPageName=MercanciaEntradas.aspx';
}
function strHrefMercanciaEntradasRecepcion(){
	document.location.href='CCRedirectorPOSAdmin.aspx?strPageName=MercanciaEntradasRecepcion.aspx';
}

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
function strRecordBrowserHTML(){  
     document.write("<%=strRecordBrowserHTML%>");   
}

function window_onload() {
   MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
   document.forms[0].action = "<%=strFormAction%>";
   
   
   var strMensaje = "<%=strMensaje%>";
   var rdoFiltroSeleccionado = "<%=rdoFiltroConsulta%>";
   var rdoRangoSeleccionado = "<%=rdoRangoConsulta%>";
   var rdoEdoSeleccionado = "<%=rdoEdoConsulta%>";
   var rdoOrdenSeleccionado = "<%=rdoOrdenConsulta%>";
   var strRegistrosRecordBrowser = "<%=strRegistrosRecordBrowser%>";
      
   if (rdoFiltroSeleccionado == "1") {
     document.forms[0].elements['rdoFiltroConsulta1'].checked = true;     
   }   
   if (rdoFiltroSeleccionado == "2") {
     document.forms[0].elements['rdoFiltroConsulta2'].checked = true;     
   }   
   if (rdoRangoSeleccionado == "1") {
     document.forms[0].elements['rdoRangoConsulta1'].checked = true;     
   }   
   if (rdoRangoSeleccionado == "2") {
     document.forms[0].elements['rdoRangoConsulta2'].checked = true;     
   }
   
   if (rdoEdoSeleccionado == "1") {
     document.forms[0].elements['rdoEdoConsulta1'].checked = true;     
   }   
   if (rdoEdoSeleccionado == "2") {
     document.forms[0].elements['rdoEdoConsulta2'].checked = true;     
   }
      
   if (rdoOrdenSeleccionado == "1") {
     document.forms[0].elements['rdoOrdenConsulta1'].checked = true;     
   }      
   if (rdoOrdenSeleccionado == "2") {
     document.forms[0].elements['rdoOrdenConsulta2'].checked = true;     
   }   
   if (rdoOrdenSeleccionado == "3") {
     document.forms[0].elements['rdoOrdenConsulta3'].checked = true;     
   }
   if (rdoOrdenSeleccionado == "4") {
     document.forms[0].elements['rdoOrdenConsulta4'].checked = true;     
   }
      
   if (strMensaje.length > 0 ) {
       alert(strMensaje);
   }
   
   if (strRegistrosRecordBrowser.length > 0) {   
       document.forms[0].elements['rdoFiltroConsulta1'].disabled=true;
       document.forms[0].elements['rdoFiltroConsulta2'].disabled=true;
       
       document.forms[0].elements['rdoRangoConsulta1'].disabled=true;
       document.forms[0].elements['rdoRangoConsulta2'].disabled=true;
       
       document.forms[0].elements['rdoEdoConsulta1'].disabled=true;
       document.forms[0].elements['rdoEdoConsulta2'].disabled=true;
          
       document.forms[0].elements['cmdRegresar'].style.display='none';
       document.forms[0].elements['cmdConsultar'].style.display='none';       
   }   
	
}

function frmMercanciaConsultarFacturaRemisionManual_onsubmit() {
   var regreso = true;
   var rdoFiltroSeleccionado = "";
   var rdoRangoSeleccionado  = "";
   var rdoEdoSeleccionado  = "";
   var rdoOrdenSeleccionado  = "";
          
   if (document.forms[0].elements['rdoFiltroConsulta1'].checked==true) {
       rdoFiltroSeleccionado = "1";    
   }
   if (document.forms[0].elements['rdoFiltroConsulta2'].checked==true) {
       rdoFiltroSeleccionado = "2";    
   }
   
   if (document.forms[0].elements['rdoRangoConsulta1'].checked==true) {
       rdoRangoSeleccionado = "1";    
   }
   if (document.forms[0].elements['rdoRangoConsulta2'].checked==true) {
       rdoRangoSeleccionado = "2";    
   }

   if (document.forms[0].elements['rdoEdoConsulta1'].checked==true) {
       rdoEdoSeleccionado = "1";    
   }
   if (document.forms[0].elements['rdoEdoConsulta2'].checked==true) {
       rdoEdoSeleccionado = "2";    
   }
         
   if (document.forms[0].elements['rdoOrdenConsulta1'].checked == true) {
       rdoOrdenSeleccionado = "1";
   }
   if (document.forms[0].elements['rdoOrdenConsulta2'].checked == true) {
       rdoOrdenSeleccionado = "2";
   }
   if (document.forms[0].elements['rdoOrdenConsulta3'].checked == true) {
       rdoOrdenSeleccionado = "3";
   }
   if (document.forms[0].elements['rdoOrdenConsulta4'].checked == true) {
       rdoOrdenSeleccionado = "4";
   }
      
   if (rdoFiltroSeleccionado == "") {
       alert("Seleccionar el tipo de documento para la consulta");
       regreso = false;
   }
   
   if (rdoRangoSeleccionado == "" && regreso) {
       alert("Seleccionar un rango para la consulta");
       regreso = false;
   }
   
   if (rdoEdoSeleccionado == "" && regreso) {
       alert("Seleccionar un estado del documento para la consulta");
       regreso = false;
   }   
   
   if (rdoOrdenSeleccionado == ""  && regreso) {
       alert("Seleccionar orden para la consulta");
       regreso = false;
   }
   
   if (regreso)   {
       document.forms[0].action = "<%=strFormAction%>" +"?strConsultar=1&rdoFiltroConsulta="+rdoFiltroSeleccionado+"&rdoRangoConsulta="+rdoRangoSeleccionado+"&rdoEdoConsulta="+rdoEdoSeleccionado+ "&rdoOrdenConsulta="+rdoOrdenSeleccionado;
   }
     
   return(regreso);
}

function cmdRegresar_onclick() {
	strHrefMercanciaEntradasRecepcion();
}


function rdoOrdenConsulta_onclick() {    
    var strRegistrosRecordBrowser = "<%=strRegistrosRecordBrowser%>";
    var rdoFiltroSeleccionado = "";
    var rdoRangoSeleccionado = "";
    var rdoEdoSeleccionado = "";
    var rdoOrdenSeleccionado  = "";
       
   if (document.forms[0].elements['rdoFiltroConsulta1'].checked==true) {
       rdoFiltroSeleccionado = "1";    
   }
   if (document.forms[0].elements['rdoFiltroConsulta2'].checked==true) {
       rdoFiltroSeleccionado = "2";    
   }
   
   if (document.forms[0].elements['rdoRangoConsulta1'].checked==true) {
       rdoRangoSeleccionado = "1";    
   }
   if (document.forms[0].elements['rdoRangoConsulta2'].checked==true) {
       rdoRangoSeleccionado = "2";    
   }

   if (document.forms[0].elements['rdoEdoConsulta1'].checked==true) {
       rdoEdoSeleccionado = "1";    
   }
   if (document.forms[0].elements['rdoEdoConsulta2'].checked==true) {
       rdoEdoSeleccionado = "2";    
   }
         
   if (document.forms[0].elements['rdoOrdenConsulta1'].checked == true) {
       rdoOrdenSeleccionado = "1";
   }
   if (document.forms[0].elements['rdoOrdenConsulta2'].checked == true) {
       rdoOrdenSeleccionado = "2";
   }
   if (document.forms[0].elements['rdoOrdenConsulta3'].checked == true) {
       rdoOrdenSeleccionado = "3";
   }
   if (document.forms[0].elements['rdoOrdenConsulta4'].checked == true) {
       rdoOrdenSeleccionado = "4";
   }
         
   if (strRegistrosRecordBrowser.length > 0) {   
	   document.forms[0].action = "<%=strFormAction%>" +"?strConsultar=1&rdoFiltroConsulta="+rdoFiltroSeleccionado+"&rdoRangoConsulta="+rdoRangoSeleccionado+"&rdoEdoConsulta="+rdoEdoSeleccionado+ "&rdoOrdenConsulta="+rdoOrdenSeleccionado;
	   document.forms[0].submit();
	}
}

function cmdOtra_onclick() {
   document.forms[0].elements['rdoFiltroConsulta1'].disabled=false;
   document.forms[0].elements['rdoFiltroConsulta2'].disabled=false;
   
   document.forms[0].elements['rdoRangoConsulta1'].disabled=false;
   document.forms[0].elements['rdoRangoConsulta2'].disabled=false;
   
   document.forms[0].elements['rdoEdoConsulta1'].disabled=false;
   document.forms[0].elements['rdoEdoConsulta2'].disabled=false;

   document.forms[0].elements['rdoFiltroConsulta1'].checked = false; 
   document.forms[0].elements['rdoFiltroConsulta2'].checked = false; 
   
   document.forms[0].elements['rdoRangoConsulta1'].checked = false; 
   document.forms[0].elements['rdoRangoConsulta2'].checked = false; 
   
   document.forms[0].elements['rdoOrdenConsulta1'].checked = false;     
   document.forms[0].elements['rdoOrdenConsulta2'].checked = false;     
   document.forms[0].elements['rdoOrdenConsulta3'].checked = false;     
   document.forms[0].elements['rdoOrdenConsulta4'].checked = false;     
   document.forms[0].action = "<%=strFormAction%>";
   
   document.forms[0].submit();      
}

function cmdImprimir_onclick() {
   printContent();
   return(true);
}

//-->
</script>
</head>
<body leftmargin="0" topmargin="0" onLoad="return window_onload()" marginheight="0" marginwidth="0">
<form name="frmMercanciaConsultarFacturaRemisionManual" onSubmit="return frmMercanciaConsultarFacturaRemisionManual_onsubmit()" action="about:blank" method="post">
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
            <td width="10" bgcolor="#ffffff"> <img height="8" src="../static/images/pixel.gif" width="10"></td>
            <td class="tdmigaja" width="583"><div id="ToPrintTxtMigaja"><span class="txdmigaja">Está 
                en : </span><a class="txdmigaja" href="javascript:strHrefMercancia();">Mercancía</a><span class="txdmigaja"> 
                : <a class="txdmigaja" href="javascript:strHrefMercanciaEntradas();">Entradas</a> 
                : <a class="txdmigaja" href="javascript:strHrefMercanciaEntradasRecepcion();"> 
                Recepción de mercancía</a> : Archivo de facturas y remisiones 
                manuales</span></div></td>
            <td class="tdfechahora" width="182"> <script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td class="tdtablacont" valign="top" width="583"> <span class="txtitulo">Archivo 
              de Facturas y Remisiones Manuales</span> <span class="txcontenido">Utilice 
              los filtros siguientes para configurar la consulta en el archivo, 
              y luego oprima "Consultar".<br>
              </span> <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr> 
                  <td class="tdtittablas" width="63">Sucursal:</td>
                  <td class="tdconttablas" valign="middle" width="190"> <script language="javascript">strCompaniaSucursal()</script> 
                    <script language="javascript">strSucursalNombre()</script> 
                  </td>
                  <td class="tdtittablas" valign="middle" width="84">Fecha y hora:</td>
                  <td class="tdconttablas" valign="middle" width="231"><div id="ToPrintTxtFecha"> 
                      <script language="javascript">strGetCustomDateTime()</script>
                    </div></td>
                </tr>
              </table>
              <br> <span class="txsubtitulo"> <img height="11" src="../static/images/bullet_subtitulos.gif" width="17" align="absMiddle"> 
              Filtros de consulta</span> <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr> 
                  <td class="tdtittablas">¿Que desea recuperar?:</td>
                  <td class="tdconttablas" width="424"> <input id="rdoFiltroConsulta1" type="radio" value="1" name="rdoFiltroConsulta">
                    Remisiones&nbsp;&nbsp;&nbsp; <input id="rdoFiltroConsulta2" type="radio" value="2" name="rdoFiltroConsulta">
                    Facturas </td>
                </tr>
                <tr> 
                  <td colspan="2">&nbsp;</td>
                </tr>
                <tr> 
                  <td class="tdtittablas">Rango de consulta:</td>
                  <td class="tdconttablas"> <input id="rdoRangoConsulta1" type="radio" value="1" name="rdoRangoConsulta">
                    Mes actual&nbsp;&nbsp;&nbsp;&nbsp; <input id="rdoRangoConsulta2" type="radio" value="2" name="rdoRangoConsulta">
                    Mes anterior </td>
                </tr>
                <tr> 
                  <td colspan="2">&nbsp;</td>
                </tr>
                <tr> 
                  <td class="tdtittablas">Estado del Documento:</td>
                  <td class="tdconttablas"> <input id="rdoEdoConsulta1" type="radio" value="1" name="rdoEdoConsulta">
                    Confirmados&nbsp; <input id="rdoEdoConsulta2" type="radio" value="2" name="rdoEdoConsulta">
                    Sin Confirmar </td>
                </tr>
                <tr> 
                  <td colspan="2">&nbsp;</td>
                </tr>
                <tr> 
                  <td class="tdtittablas" width="144">Ordenar por:</td>
                  <td class="tdconttablas"> <input id="rdoOrdenConsulta1" type="radio" value="1" name="rdoOrdenConsulta" onClick="return rdoOrdenConsulta_onclick()">
                    Número del proveedor </td>
                </tr>
                <tr> 
                  <td class="tdtittablas">&nbsp;</td>
                  <td class="tdconttablas"> <input id="rdoOrdenConsulta2" type="radio" value="2" name="rdoOrdenConsulta" onClick="return rdoOrdenConsulta_onclick()">
                    Número de factura/remisión </td>
                </tr>
                <tr> 
                  <td class="tdtittablas">&nbsp;</td>
                  <td class="tdconttablas" height="40"> <input id="rdoOrdenConsulta3" type="radio" value="3" name="rdoOrdenConsulta" onClick="return rdoOrdenConsulta_onclick()">
                    Nota (folio de confirmación) </td>
                </tr>
                <tr> 
                  <td>&nbsp;</td>
                  <td class="tdconttablas" height="27"> <input id="rdoOrdenConsulta4" type="radio" value="4" name="rdoOrdenConsulta" onClick="return rdoOrdenConsulta_onclick()">
                    Fecha de confirmación </td>
                </tr>
              </table>
              <input class="boton" onClick="return cmdRegresar_onclick()" type="button" value="Regresar" name="cmdRegresar"> 
              <input class="boton" type="submit" value="Consultar" name="cmdConsultar"> 
              <br> <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr> 
                  <td colspan="2"> <script language="javascript" >strRecordBrowserHTML()</script> 
                  </td>
                </tr>
              </table></td>
            <td class="tdcolumnader" valign="top" width="182" rowspan="2">&nbsp;</td>
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
