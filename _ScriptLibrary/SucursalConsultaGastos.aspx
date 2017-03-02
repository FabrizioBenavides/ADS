<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalConsultaGastos.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalConsultaGastos"%>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : SucursalConsultaGastos.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página para accesar al sistema de consulta de gastos
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : J.Antonio Hernández Dávila
    ' Version       : 1.0
    ' Last Modified : Jueves, Octubre 13, 2005
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
var blnConsultar;
blnConsultar=true;


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

function window_onload() {  
  MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
  document.forms[0].action = "<%=strFormAction%>";  

   strGastosSesion =  strURLGastosSesion() + "ADSuser=1&" +
                      "txtUsuario="       + "<%=strUsuarioGastos%>"   + 
                      "&txtContrasena="   + "<%=strPasswordGastos%>"  +
                      "&urlConcentrador=" + "<%=strURLConcentrador%>" + "/_ScriptLibrary/CCEscribeCookie.aspx";
                      
   strOnePageSesion = strURLOnePageSesion() + "ADSuser=1&" +
                      "txtUsuario="       + "<%=strUsuarioGastos%>"   + 
                      "&txtContrasena="   + "<%=strPasswordGastos%>"  +
                      "&urlConcentrador=" + "<%=strURLConcentrador%>" + "/_ScriptLibrary/CCEscribeCookie.aspx";
                                           

   
   document.ifraOculto1.document.location = strGastosSesion;
   document.ifraOculto2.document.location = strOnePageSesion;
   
}
  
function cmdConsultar_onclick() {    
   var intSesion = document.cookie.indexOf("intEntroAComDif=1")
   
   if (intSesion > -1) {
       valida = false;
       if (document.forms[0].elements['rdoFiltroConsulta1'].checked==true) {
           strParametros = strURLGastosOperacionesConsulta();
           valida = true;
       }
       if (document.forms[0].elements['rdoFiltroConsulta2'].checked==true) {
           strParametros = strURLGastosOnePageConsulta();
           valida = true;
       }       
       
       if (valida) {                              
           window.open(strParametros,'xName','left=0, top=0, height=500,width=750,status=yes, toolbar=no, menubar=no, scrollbars=yes, location=no, titlebar=no, resizable=yes');   
       }  
       else {
           alert("Seleccionar el Reporte a ver");
       }          
   }     
}

function cmdRegresar_onclick() {
    strRedireccionaPOSAdmin("Inicio.aspx");
}

//-->
					</script>
</HEAD>
<body leftmargin="0" topmargin="0" onLoad="return window_onload()" marginheight="0" marginwidth="0">
<form name="frmSucursalConsultaGastos" action="about:blank" method="post">
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
            <td width="583" class="tdmigaja"><div id="ToPrintTxtMigaja"><span class="txdmigaja">Está 
                en :</span><span class="txdmigaja"> <a href="javascript:strRedireccionaPOSAdmin('Sucursal.aspx')" class="txdmigaja"> 
                Sucursal</a> :&nbsp; Gastos&nbsp;</span></div></td>
            <td width="182" class="tdfechahora"> <script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top"> <script language="JavaScript">crearDatosSucursal()</script> 
              <br> <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td colspan="3" class="tdconttablas"><input id="rdoFiltroConsulta1" type="radio" value="1" name="rdoFiltroConsulta">
                    Detalle de Gastos </td>
                </tr>
                <tr> 
                  <td colspan="3" class="tdconttablas"><input id="rdoFiltroConsulta2" type="radio" value="2" name="rdoFiltroConsulta"> 
                    &nbsp;One Page&nbsp; </td>
                </tr>
                <tr> 
                  <td colspan="3"><br> <input name="cmdRegresar" type="button" class="boton" value="Regresar" onClick="return cmdRegresar_onclick()"> 
                    <input name="cmdConsultar" type="button" class="boton" value="Consultar" onClick="return cmdConsultar_onclick()"> 
                  </td>
                </tr>
                <tr> 
                  <td colspan="3" class="tdtablacont" width="100%"> <table border="0" cellpadding="0" cellspacing="0" width="100%" height="400">
                      <tr> 
                        <td width="100%"><iframe name="iframeLayout" id="iframeLayout" src="" frameborder="0" width="100%" scroll="yes"
																height="100%" marginwidth="0" marginheight="0"></iframe> 
                        </td>
                      </tr>
                    </table></td>
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
<iframe name="ifraOculto1" src="" width="0" height="0"></iframe>
<iframe name="ifraOculto2" src="" width="0" height="0"></iframe>
</body>
</HTML>
