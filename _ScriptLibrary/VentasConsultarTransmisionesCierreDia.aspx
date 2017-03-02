<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="VentasConsultarTransmisionesCierreDia.aspx.vb" codePage="28592" Inherits="com.isocraft.backbone.ccentral.VentasConsultarTransmisionesCierreDia" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : VentasConsultarTransmisionesCierreDia.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : P�gina que muestra desde el ADS las transmisiones 
    '                 hacia el CTX de p�liza, ventas y cr�dito empresas.
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Servicios Operacionales Benavides
    ' Author        : Griselda G�mez Ponce
    ' Version       : 1.0
    ' Last Modified : Martes, 08 de Marzo, 2005
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
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

function window_onLoad(){
   MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
   document.forms[0].action="<%=strFormAction%>";
   
   //Inicializa las fechas de consulta con la fecha del dia de hoy
     document.forms[0].elements('txtFechaConsultaInicio').value="<%=strFechaConsultaInicio%>";
     document.forms[0].elements('txtFechaConsultaFin').value="<%=strFechaConsultaFin%>";

  
   //obtiene el criterio de consulta selecionado
   if ("<%=strRangoConsulta%>" == "1") {
     document.forms[0].elements['rdoRangoConsulta1'].checked = true;     
   }
   if ("<%=strRangoConsulta%>" == "2") {
     document.forms[0].elements['rdoRangoConsulta2'].checked = true;     
   }
   if ("<%=strRangoConsulta%>" == "3") {
     document.forms[0].elements['rdoRangoConsulta3'].checked = true;       
   } 
  
  
  // Validamos que haya informaci�n en el record Browser
  
  if ("<%=strMensaje%>" != ""){
      alert("<%=strMensaje%>");
  }
   
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

function strRecordBrowserHTML(){  
     document.write("<%=strRecordBrowserHTML%>");   
}

function frmVentasConsultarTransmisionesCierreDia_onsubmit() {
  valida=true;
  
  if (document.forms[0].elements('rdoRangoConsulta3').checked==true){
   
     if (document.forms[0].elements('txtFechaConsultaInicio').value==""){
        alert("Capturar fecha de inicio");
        valida=false;
     }
     
     if (valida){
        if (document.forms[0].elements('txtFechaConsultaFin').value==""){
           alert("Capturar fecha fin");
          valida=false;
        }
     }   
     
     if(valida){
           valida = blnValidarCampo(document.forms[0].elements('txtFechaConsultaInicio'),true,'Fecha Consulta Inicio',cintTipoCampoFecha,10,10,'');
     }
     
     if(valida){
           valida = blnValidarCampo(document.forms[0].elements('txtFechaConsultaFin'),true,'Fecha Consulta Fin',cintTipoCampoFecha,10,10,'');
     }
     
     if(valida){
         if (document.forms[0].elements('txtFechaConsultaInicio').value > document.forms[0].elements('txtFechaConsultaFin').value ){
              alert("Fecha fin debe ser mayor que fecha inicio") ;
              document.forms[0].elements('txtFechaConsultaInicio').focus();
              valida=false;
         }
          else{
               valida=true;
          }
    }
  }
  return(valida);
}


//valida que la fecha de inicio sea v�lida
function fncValidarFechaInicio(){
   valida=true;
   
   if (document.forms[0].elements('rdoRangoConsulta3').checked==true){
         if(valida){
            valida = blnValidarCampo(document.forms[0].elements('txtFechaConsultaInicio'),false,'Fecha Consulta Inicio',cintTipoCampoFecha,10,10,'');
         }
         
         if (valida){
         objCalendar1.popup();
   }     }
   return(valida);
}

//valida que la fecha fin sea v�lida
function fncValidarFechaFin(){
   valida=true;
   
   if (document.forms[0].elements('rdoRangoConsulta3').checked==true){
    
        if(valida){
           valida = blnValidarCampo(document.forms[0].elements('txtFechaConsultaFin'),false,'Fecha Consulta Fin',cintTipoCampoFecha,10,10,'');
        }
        if (valida){
        objCalendar2.popup();
        }
    }    
   return(valida);
}



function cmdRegresar_onclick() {
   //Redireccionamos al home de Ventas Cierre del d�a
   strRedireccionaPOSAdmin('VentasCierreDelDia.aspx');
}

//-->
</script>
</HEAD>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onLoad()">
<form action="about:blank" method="post" name="frmVentasConsultarTransmisionesCierreDia"
			onSubmit="return frmVentasConsultarTransmisionesCierreDia_onsubmit()">
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
            <td width="583" class="tdmigaja"><span class="txdmigaja">Est� en : 
              </span><a href="Mercancia.aspx" class="txdmigaja">Ventas</a><span class="txdmigaja"> 
              : <a href="javascript:strRedireccionaPOSAdmin('Ventas.aspx')" class="txdmigaja">Cierre 
              del D�a</a> : </span><span class="txdmigaja"> <a href="javascript:strRedireccionaPOSAdmin('VentasCierreDelDia.aspx')" class="txdmigaja"> 
              Consulta de Transmisiones</a></span></td>
            <td width="182" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top"><table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="100%" colspan="3" valign="top" class="tdtablacont"> 
                    <p><span class="txtitulo">Consultar Transmisiones del Cierre 
                      del d�a</span><br>
                      <span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">Criterios 
                      de b�squeda</span> 
                      <script language="JavaScript">crearDatosSucursal()</script>
                      <br>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                      <tr> 
                        <td class="tdtittablas">Elija un rango de consulta</td>
                        <td colspan="5" valign="middle" class="tdconttablas"><input type="radio" name="rdoRangoConsulta" value="1" id="rdoRangoConsulta1" checked>
                          D�a de hoy</td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas">&nbsp;</td>
                        <td colspan="5" valign="middle" class="tdconttablas"><input type="radio" name="rdoRangoConsulta" value="2" id="rdoRangoConsulta2">
                          D�a de ayer</td>
                      </tr>
                      <tr> 
                        <td width="166" class="tdtittablas">&nbsp;</td>
                        <td width="135" valign="middle" class="tdconttablas"><input type="radio" name="rdoRangoConsulta" value="3" id="rdoRangoConsulta3">
                          Rango de fechas</td>
                        <td width="36" valign="middle" class="tdconttablas">Del:</td>
                        <td width="103" valign="middle" class="tdpadleft5"> <input name="txtFechaConsultaInicio" type="text" class="campotabla" size="10" maxlength="10"> 
                          <img src="../static/images/icono_calendario.gif" width="20" height="13" align="absMiddle"
																	onClick="return fncValidarFechaInicio()"></td>
                        <td width="25" valign="middle" class="tdconttablas">Al:</td>
                        <td width="103" valign="middle" class="tdpadleft5"> <input name="txtFechaConsultaFin" type="text" class="campotabla" size="10" maxlength="10"> 
                          <img src="../static/images/icono_calendario.gif" width="20" height="13" align="absMiddle"
																	onClick="return fncValidarFechaFin()"></td>
                      </tr>
                    </table>
                    <br> <script language="JavaScript">strRecordBrowserHTML()</script> 
                    <br> <input name="cmdRegresar" type="button" class="boton" value="Regresar" onClick="return cmdRegresar_onclick()"> 
                    &nbsp;&nbsp; <input name="cmdConsultar" type="submit" class="boton" value="Consultar"> 
                    <br> <br> </p> </td>
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
var objCalendar1 = new calendar1(document.forms['frmVentasConsultarTransmisionesCierreDia'].elements['txtFechaConsultaInicio']);
var objCalendar2 = new calendar1(document.forms['frmVentasConsultarTransmisionesCierreDia'].elements['txtFechaConsultaFin']);
	//-->
			</script>
</form>
</body>
</HTML>
