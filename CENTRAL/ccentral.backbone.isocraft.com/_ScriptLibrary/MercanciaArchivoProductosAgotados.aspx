<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaArchivoProductosAgotados.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaArchivoProductosAgotados" codePage="28592"%>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%
    '====================================================================
    ' Page          : MercanciaArchivoProductosAgotados.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página que muestra los productos agotados por fechas
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Jorge Tamez Sánchez
    ' Version       : 1.0
    ' Last Modified : Lunes, Noviembre 17, 2003
    '                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA	
    '====================================================================
%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<link rel="stylesheet" href="../static/css/menu.css">
<link rel="stylesheet" href="../static/css/menu2.css">
<link rel="stylesheet" href="../static/css/estilo.css">
<script language="JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" src="../static/scripts/calendar1.js"></script>
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">
<!--
// Onload
function window_onload() {
  MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
  document.forms[0].action = "<%=strFormAction%>";
  
  document.forms[0].elements['dtmFechaInicial'].value = "<%=Request.Form("dtmFechaInicial")%>";
  document.forms[0].elements['dtmFechaFinal'].value = "<%=Request.Form("dtmFechaFinal")%>";  
     
  return(true);
}
function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
	return(true);
}
// Submit
function frmMercanciaArchivoProductosAgotados_onsubmit() {
  valida=true;
  
  
  // Validamos la fecha inicial
  if (valida){ valida=blnValidarCampo(document.forms[0].elements("dtmFechaInicial"),true,"Fecha Inicial",cintTipoCampoFecha,10,10,""); 
     if (!valida){
       return(valida);
     }
  } 
  
  // Validamos la fecha inicial
  if (valida){ valida=blnValidarCampo(document.forms[0].elements("dtmFechaFinal"),true,"Fecha Final",cintTipoCampoFecha,10,10,""); 
     if (!valida){
       return(valida);
     }
  } 
  
  // Validamos que la fecha inicial sea menor igual que la fecha final
    if (Date.parse(document.forms[0].elements("dtmFechaInicial").value) > Date.parse(document.forms[0].elements("dtmFechaFinal").value)){
       alert("La fecha inicial debe ser menor o igual que la final.");
       return(false);     
    }
   
  return(valida);
}

// RecordBrowser
function strRecordBrowserHTML(){
 document.write("<%=strRecordBrowserHTML%>");
 return(true);
}

// Botones 
function strGeneraBotonesHTML(){
 document.write("<%=strGeneraBotonesHTML%>");
 return(true);
}

// Regresar
function cmdRegresar_onClick(){
   javascript:strRedireccionaPOSAdmin('MercanciaInventariosProductosAgotados.aspx');
   return(true);
}

function cmdLimpiar_onClick(){

 // Inicializamos las fechas
 document.forms[0].elements['dtmFechaInicial'].value = '';
 document.forms[0].elements['dtmFechaFinal'].value = ''; 
 
 // Mandamos ejecutar la pagina
 document.forms[0].action = "<%=strFormAction%>";
 document.forms[0].submit();
}

//-->
</script>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaArchivoProductosAgotados" onSubmit="return frmMercanciaArchivoProductosAgotados_onsubmit()">
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
            <td width="583" class="tdmigaja"><span class="txdmigaja">Est&aacute; 
              en : </span><a href="Mercancia.aspx" class="txdmigaja">Mercanc&iacute;a</a><span class="txdmigaja"> 
              : <a href="javascript:strRedireccionaPOSAdmin('MercanciaInventarios.aspx')" class="txdmigaja">Inventarios</a></span><span class="txdmigaja"> 
              </span><span class="txdmigaja">: </span><span class="txdmigaja"> 
              <a href="javascript:strRedireccionaPOSAdmin('MercanciaInventariosProductosAgotados.aspx')" class="txdmigaja">Productos 
              agotados </a></span> <span class="txdmigaja">: </span> <span class="txdmigaja">Archivo 
              de productos agotados</span></td>
            <td width="187" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script></td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top"><table width="583" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="100%" colspan="3" class="tdtablacont"> <p><span class="txtitulo">Archivo 
                      de productos agotados</span><span class="txcontenido">Configure 
                      la consulta que desea hacer sobre los reportes de productos 
                      agotados en su sucursal.</span> 
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                      <tr> 
                        <td width="112" class="tdtittablas">Consultar desde el:</td>
                        <td width="119" valign="middle" class="tdpadleft5"> <input name="dtmFechaInicial" type="text" class="campotabla" id="txtFechaInicio" size="9" maxlength="10"> 
                          <img src="../static/images/icono_calendario.gif" width="20" height="13" align="absmiddle" style="cursor:hand" onClick="if(blnValidarCampo(document.forms('frmMercanciaArchivoProductosAgotados').elements('dtmFechaInicial'),false,'Fecha Inicial',cintTipoCampoFecha,10,10,'')){objCalendar1.popup();}">&nbsp;&nbsp;&nbsp; 
                        </td>
                        <td width="67" valign="middle" class="tdtittablas">Y hasta 
                          el:</td>
                        <td width="270" valign="middle" class="tdconttablas"><input name="dtmFechaFinal" type="text" class="campotabla" id="txtFechaFin" size="9" maxlength="10"> 
                          <img src="../static/images/icono_calendario.gif" width="20" height="13" align="absmiddle" style="cursor:hand" onClick="if(blnValidarCampo(document.forms('frmMercanciaArchivoProductosAgotados').elements('dtmFechaFinal'),false,'Fecha Final',cintTipoCampoFecha,10,10,'')){objCalendar2.popup();}">&nbsp;&nbsp;&nbsp; 
                        </td>
                      </tr>
                    </table>
                    <br> <input name="cmdConsultar" type="submit" class="boton" id="cmdConsultar" value="Consultar"> 
                    <br> <script language="JavaScript">strRecordBrowserHTML()</script> 
                    <br> <script language="JavaScript">strGeneraBotonesHTML()</script> 
                    <br> </td>
                </tr>
              </table></td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader"><script language="javascript">strGeneraTablaAyuda('');</script></td>
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
    var objCalendar1 = new calendar1(document.forms['frmMercanciaArchivoProductosAgotados'].elements['dtmFechaInicial']);
    var objCalendar2 = new calendar1(document.forms['frmMercanciaArchivoProductosAgotados'].elements['dtmFechaFinal']);	
	//-->
</script>
</form>
</body>
</html>
