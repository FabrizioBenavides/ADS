<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaArchivodeRecibos.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaArchivoDeRecibos" codePage="28592"%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaArchivodeRecibos.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página Consulta las Transferencias Recibidas
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : J.Antonio Hernández Dávila
    ' Version       : 1.0
    ' Last Modified : Viernes, Octubre 24, 2003   
    '                 20 de Marzo 2007             Actualizacion por SAP
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
   var rdoSeleccionado = "<%=rdoFiltroConsulta%>";
   
   if (rdoSeleccionado == "1") {
     document.forms[0].elements['rdoFiltroConsulta1'].checked = true;     
   }
   if (rdoSeleccionado == "2") {
     document.forms[0].elements['rdoFiltroConsulta2'].checked = true;     
   }
   if (rdoSeleccionado == "3") {
     document.forms[0].elements['rdoFiltroConsulta3'].checked = true;       
     document.forms[0].elements['dtmInicio'].value = "<%=dtmInicio%>"; 
     document.forms[0].elements['dtmFin'].value = "<%=dtmFin%>"; 
   }   
   if (strMensaje.length > 0 ) {
       alert(strMensaje);
   }
}
function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
	return(true);
}
function dtmInicio_onfocus() {
   document.frmMercanciaArchivodeRecibos.rdoFiltroConsulta3.checked = true;
}

function dtmFin_onfocus() {
   document.frmMercanciaArchivodeRecibos.rdoFiltroConsulta3.checked = true;
}

function strRecordBrowserHTML(){  
     document.write("<%=strRecordBrowserHTML%>");   
}

function cmdRegresar_onclick() {
   document.location.href= "MercanciaEntradasTransferencia.aspx";
}

function frmMercanciaArchivodeRecibos_onsubmit() {
   var regreso = true;
   
   if (document.forms[0].elements['rdoFiltroConsulta1'].checked == false && document.forms[0].elements['rdoFiltroConsulta2'].checked == false && document.forms[0].elements['rdoFiltroConsulta3'].checked == false ) {
       alert("Seleccionar algun criterio para la consulta");
       regreso = false;
   }
   
   if (regreso) {
       if (document.forms[0].elements['rdoFiltroConsulta3'].checked) {
           if (regreso) {
               regreso = blnValidarCampo(document.forms[0].elements['dtmInicio'],true,'Fecha Inico Consulta',cintTipoCampoFecha,10,10,'');
           }
                
           if (regreso){
               regreso = blnValidarCampo(document.forms[0].elements['dtmFin'],true,'Fecha Final Consulta',cintTipoCampoFecha,10,10,'');
           }
       }
   }
   
   return(regreso);
}

//-->
</script>
</head>
<body leftmargin="0" topmargin="0" onLoad="return window_onload()" marginwidth="0" marginheight="0">
<form name="frmMercanciaArchivodeRecibos" onSubmit="return frmMercanciaArchivodeRecibos_onsubmit()" action="about:blank" method="post">
  <table cellspacing="0" cellpadding="0" width="780" border="0">
    <tr> 
      <td valign="top" height="98" width="100%"><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
    <tr> 
      <td  valign="top" height="34" width="100%"> <img height="34" src="../static/images/pixel.gif" width="1"></td>
    </tr>
    <tr> 
      <td width="100%"> <table cellspacing="0" cellpadding="0" width="100%" border="0">
          <tr> 
            <td width="10" bgcolor="#ffffff"> <img height="8" src="../static/images/pixel.gif" width="10"></td>
            <td class="tdmigaja" width="583"><span class="txdmigaja">Está en : 
              </span><a class="txdmigaja" href="Mercancia.aspx">Mercancía</a><span class="txdmigaja"> 
              : <a class="txdmigaja" href="MercanciaEntradas.aspx">Entradas</a></span><span class="txdmigaja"> 
              : </span><span class="txdmigaja"></span><span class="txdmigaja"> 
              <a class="txdmigaja" href="MercanciaEntradasTransferencia.aspx">Transferencias 
              de otra sucursal</a></span><span class="txdmigaja"> : </span><span class="txdmigaja"></span><span class="txdmigaja"></span><span class="txdmigaja"></span><span class="txdmigaja"></span> 
              <span class="txdmigaja">Consultar archivo de recibos</span></td>
            <td class="tdfechahora" width="187"> <script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td class="tdtablacont" valign="top" width="583"> <span class="txtitulo">Consultar 
              archivo de recibos</span><span class="txcontenido">Defina su búsqueda 
              y luego ejecute la consulta. Para ver el detalle de un recibo, haga 
              clic en su folio.</span><span class="txsubtitulo"> <img height="11" src="../static/images/bullet_subtitulos.gif" width="17" align="absMiddle"> 
              Criterios de búsqueda</span> <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr> 
                  <td class="tdtittablas" width="10%" rowspan="3">Elija un criterio 
                    de consulta</td>
                  <td class="tdconttablas" colspan="6" width="90%"> <input id="rdoFiltroConsulta1" type="radio" value="1" name="rdoFiltroConsulta">
                    Mes actual&nbsp;&nbsp;&nbsp; </td>
                </tr>
                <tr> 
                  <td class="tdconttablas" colspan="5" width="90%"> <input id="rdoFiltroConsulta2" type="radio" value="2" name="rdoFiltroConsulta">
                    Mes anterior&nbsp;&nbsp;&nbsp; </td>
                </tr>
                <tr> 
                  <td class="tdconttablas" width="24%" > <input id="rdoFiltroConsulta3" type="radio" value="3" name="rdoFiltroConsulta">
                    Rango de fechas</td>
                  <td class="tdconttablas" width="5%">Del</td>
                  <td class="tdpadleft5" width="28%"> <input class="campotabla" onFocus="return dtmInicio_onfocus()" type="text" maxlength="10" onChange="return dtmInicio_onchange()" size="10" name="dtmInicio"> 
                    <a href="javascript:objdtmInicio.popup();"> <img onClick="return blnValidarCampo(document.forms('frmMercanciaArchivodeRecibos').elements('dtmInicio'),false,'Fecha',cintTipoCampoFecha,10,10,'');" height="13" alt="Clic para seleccionar la fecha." src="../static/images/icono_calendario.gif" width="20" border="0"></a> 
                  </td>
                  <td class="tdconttablas" width="5%">Al:</td>
                  <td class="tdpadleft5" width="28%"> <input class="campotabla" type="text" maxlength="10" size="10" name="dtmFin" onFocus="return dtmFin_onfocus()"> 
                    <a href="javascript:objdtmFin.popup();"><img onClick="return blnValidarCampo(document.forms('frmMercanciaArchivodeRecibos').elements('dtmFin'),false,'Fecha',cintTipoCampoFecha,10,10,'');"
														height="13" alt="Clic para seleccionar la fecha." src="../static/images/icono_calendario.gif" width="20" border="0"></a> 
                  </td>
                </tr>
              </table>
              <br> <script language="JavaScript">strRecordBrowserHTML()</script> 
              <br> <input class="boton" onClick="return cmdRegresar_onclick()" type="button" value="Regresar"
										name="cmdRegresar"> <input class="boton" type="submit" value="Consultar" name="cmdConsultar"> 
            </td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader"><script language="javascript">strGeneraTablaAyuda('');</script></td>
          </tr>
          <tr> 
            <td class="tdbottom" colspan="2"><script language="JavaScript">crearTablaFooter()</script> 
            </td>
          </tr>
        </table></td>
    </tr>
  </table>
  <script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	new menu (MENU_ITEMS2, MENU_POS2);

    var objdtmInicio = new calendar1(document.forms['frmMercanciaArchivodeRecibos'].elements['dtmInicio']);
	var objdtmFin = new calendar1(document.forms['frmMercanciaArchivodeRecibos'].elements['dtmFin']);
	//-->
</script>
</form>
</body>
</html>
