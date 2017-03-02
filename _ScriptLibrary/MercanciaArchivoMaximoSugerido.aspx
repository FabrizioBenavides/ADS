<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaArchivoMaximoSugerido.aspx.vb" Inherits="com.isocraft.backbone.ccentral.MercanciaArchivoMaximoSugerido" codePage="28592"%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaArchivoMaximoSugerido.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página de productos Reclamados.
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : J.Antonio Hernández Dávila
    ' Version       : 1.0
    ' Last Modified : Martes, Octubre 28, 2003
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
   var rdoFiltroSeleccionado = "<%=rdoFiltroConsulta%>";
   var rdoOrdenSeleccionado = "<%=rdoOrdenConsulta%>";      
   var strRegistrosRecordBrowser = "<%=strRegistrosRecordBrowser%>";
         
   if (rdoFiltroSeleccionado == "1") {
     document.forms[0].elements['rdoFiltroConsulta1'].checked = true;     
   }
   
   if (rdoFiltroSeleccionado == "2") {
     document.forms[0].elements['rdoFiltroConsulta2'].checked = true;     
   }
   
   if (rdoOrdenSeleccionado == "1") {
     document.forms[0].elements['rdoOrdenConsulta1'].checked = true;     
   }
   
   if (rdoOrdenSeleccionado == "2") {
     document.forms[0].elements['rdoOrdenConsulta2'].checked = true;     
   }
      
   if (strRegistrosRecordBrowser.length > 0) {     
       document.forms[0].elements['rdoFiltroConsulta1'].disabled=true;
       document.forms[0].elements['rdoFiltroConsulta2'].disabled=true;

       document.forms[0].elements['cmdRegresar'].style.display='none';
       document.forms[0].elements['cmdConsultar'].style.display='none';                       
   }  
    
   if (strMensaje.length > 0 ) {
       alert(strMensaje);
   } 
}
function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
	return(true);
}
function strRecordBrowserHTML(){  
     document.write("<%=strRecordBrowserHTML%>");   
}
function rdoOrdenConsulta_onclick() {
   var regreso = true;
   var strRegistrosRecordBrowser = "<%=strRegistrosRecordBrowser%>";

   if (strRegistrosRecordBrowser.length > 0) {     
       var strFiltroConsulta = 0;
       var strOrdenConsulta = 0;
          
       if (document.forms[0].elements['rdoFiltroConsulta1'].checked == true) {
           strFiltroConsulta = 1;
       }
       if (document.forms[0].elements['rdoFiltroConsulta2'].checked == true) {
           strFiltroConsulta = 2;
       }
       if (document.forms[0].elements['rdoOrdenConsulta1'].checked == true) {
           strOrdenConsulta = 1;
       }
       if (document.forms[0].elements['rdoOrdenConsulta2'].checked == true) {
           strOrdenConsulta = 2;
       }
          
       if (strFiltroConsulta == 0) {
            alert("Seleccionar Periodo a Consultar");
            regreso = false;
       }
       
       if (regreso) {
           document.forms[0].action = "<%=strFormAction%>?strConsulta=Maximos" + "&rdoFiltroConsulta=" + strFiltroConsulta + "&rdoOrdenConsulta=" + strOrdenConsulta; 
           document.forms[0].submit();
       }   
   }   
}

function frmMercanciaArchivoMaximoSugerido_onsubmit() { 
   var regreso = true;   
   var strFiltroConsulta = 0;
   var strOrdenConsulta = 0;
   
   if (document.forms[0].elements['rdoFiltroConsulta1'].checked == true) {
       strFiltroConsulta = 1;
   }
   if (document.forms[0].elements['rdoFiltroConsulta2'].checked == true) {
       strFiltroConsulta = 2;
   }
   if (document.forms[0].elements['rdoOrdenConsulta1'].checked == true) {
       strOrdenConsulta = 1;
   }
   if (document.forms[0].elements['rdoOrdenConsulta2'].checked == true) {
       strOrdenConsulta = 2;
   }
   
   if (strFiltroConsulta == 0) {
       alert("Seleccionar Periodo a Consultar");
       regreso = false;
   }
   
   if (regreso) {
       if (strOrdenConsulta == 0) {
           alert("Seleccionar Orden para la Consulta");
           regreso = false;
       }
   }
   
   document.forms[0].action = "<%=strFormAction%>?strConsulta=Maximos" + "&rdoFiltroConsulta=" + strFiltroConsulta + "&rdoOrdenConsulta=" + strOrdenConsulta; 
     
   return(regreso);
}

function cmdRegresar_onclick() {
    document.location.href= "MercanciaInventariosMaximosDeProductos.aspx";
}
function cmdOtra_onclick() {      
   document.forms[0].action = "<%=strFormAction%>";   
   document.forms[0].submit();      
}

//-->
</script>
</head>
<body leftmargin="0" topmargin="0" onLoad="return window_onload()" marginheight="0" marginwidth="0">
<form name="frmMercanciaArchivoMaximoSugerido" onSubmit="return frmMercanciaArchivoMaximoSugerido_onsubmit()" action="about:blank" method="post">
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
            <td width="583" class="tdmigaja"><span class="txdmigaja">Está en : 
              </span><a href="Mercancia.aspx" class="txdmigaja">Mercancía</a><span class="txdmigaja"> 
              : <a href="MercanciaInventarios.aspx" class="txdmigaja">Inventarios</a></span><span class="txdmigaja"> 
              </span><span class="txdmigaja">: </span><span class="txdmigaja"> 
              </span><span class="txdmigaja"><a href="MercanciaInventariosMaximosDeProductos.aspx" class="txdmigaja">Máximos 
              por producto </a></span><span class="txdmigaja">: </span><span class="txdmigaja">Archivo 
              de sugerencias de máximos</span></td>
            <td width="187" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont"><span class="txtitulo">Archivo 
              de sugerencias de máximos</span><span class="txcontenido">Para consultar 
              el archivo de sugerencias de máximos, elija el periodo a consultar 
              y el orden en que quiere ver los resultados. Luego oprima &#8216;Consultar&#8217;. 
              Para ver el detalle de una sugerencia, haga clic en su número.</span><span class="txsubtitulo"><br>
              <img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle"> 
              Configurar la consulta</span> <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="166" class="tdtittablas">Período a consultar:</td>
                  <td class="tdconttablas" width=115> <input type="radio" id ="rdoFiltroConsulta1" name="rdoFiltroConsulta" value="1">
                    Mes Actual&nbsp;&nbsp; </td>
                  <td class="tdconttablas"> <input type="radio" id ="rdoFiltroConsulta2" name="rdoFiltroConsulta" value="2">
                    Mes Anterior </td>
                </tr>
                <tr> 
                  <td class="tdtittablas" width=166>Orden de despliegue:</td>
                  <td class="tdconttablas" width=115> <input type="radio" id ="rdoOrdenConsulta1" name="rdoOrdenConsulta" value="1" onClick="return rdoOrdenConsulta_onclick()">
                    Por folio&nbsp;&nbsp; </td>
                  <td class="tdconttablas"> <input type="radio" id ="rdoOrdenConsulta2" name="rdoOrdenConsulta" value="2" onClick="return rdoOrdenConsulta_onclick()">
                    Por fecha </td>
                </tr>
                <tr> 
                  <td colspan="3"></td>
                </tr>
                <tr> 
                  <td > <input name="cmdRegresar" type="button" class="boton" value="Regresar" onClick="cmdRegresar_onclick()"> 
                    <input name="cmdConsultar" type=  "submit" class="boton" value="Consultar"> 
                  </td>
                  <td colspan="1"  width=115></td>
                </tr>
              </table>
              <br> <script language="JavaScript">strRecordBrowserHTML()</script> 
            </td>
            <td width="187" rowspan="2" valign="top" class="tdcolumnader"><script language="javascript">strGeneraTablaAyuda('');</script> 
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
