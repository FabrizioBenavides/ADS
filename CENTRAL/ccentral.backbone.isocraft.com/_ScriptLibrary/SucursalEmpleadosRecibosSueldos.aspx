<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="SucursalEmpleadosRecibosSueldos.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalEmpleadosRecibosSueldos" codePage="28592"%>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : SucursalEmpleadosRecibosSueldos.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página de Comisiones Diferenciadas de Empleados.
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : J.Antonio Hernández Dávila
    ' Version       : 1.0
    ' Last Modified : Miercoles, Mayo 11, 2004
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
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">
<!--


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
  document.iframeLayout.document.location =  "<%=strNombreArchivoRecibos%>";
  
}
function frmSucursalEmpleadosRecibosSueldos_onsubmit() { 
   var regreso = true;
   return(regreso);
}

function cmdRegresar_onclick() {
    strRedireccionaPOSAdmin("SucursalEmpleados.aspx");
}

//-->
</script>
</head>
<body leftmargin="0" topmargin="0" onload="return window_onload()" marginheight="0" marginwidth="0">
<form name="frmSucursalEmpleadosRecibosSueldos" onsubmit="return frmSucursalEmpleadosRecibosSueldos_onsubmit()" action="about:blank" method="post">
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
                en :</span><span class="txdmigaja"> <a href="javascript:strRedireccionaPOSAdmin('Sucursal.aspx')" class="txdmigaja">Sucursal</a> 
                : <a href="javascript:strRedireccionaPOSAdmin('SucursalEmpleados.aspx')" class="txdmigaja">Empleados</a> 
                : Archivo Recibos de Sueldos</span></div></td>
            <td width="182" class="tdfechahora"> <script language="javascript">strGetCustomDateTime()</script></td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" > <table width="100%" border="0" cellpadding="0" cellspacing="0" >
                <tr> 
                  <td width="100%" colspan="3" valign="top" class="tdtablacont"> 
                    <script language="JavaScript">crearDatosSucursal()</script> 
                    <br> <table width="100%" border="0" cellpadding="0" cellspacing="0" height="460">
                      <tr> 
                        <td><iframe name="iframeLayout" id="iframeLayout" src="" frameborder="0" width="100%" scroll="yes" height="100%" marginwidth="0" marginheight="0"> 
                          </iframe> </td>
                      </tr>
                    </table>
                    <br> <br> <input name="cmdRegresar" type="button" class="boton" value="Regresar" onclick="return cmdRegresar_onclick()"> 
                    &nbsp;&nbsp;&nbsp; &nbsp;&nbsp; <br> </p> </td>
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
  <p> 
    <script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	new menu (MENU_ITEMS2, MENU_POS2);
	//-->
</script>
  </p>
</form>
</body>
</html>
