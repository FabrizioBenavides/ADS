<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaNotasCargoProveedor.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaNotasCargoProveedor" codePage="28592"%>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaNotasCargoProveedor.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página para verificar las notas de cargo por proveedor
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Jorge Tamez Sánchez
    ' Version       : 1.0
    ' Last Modified : Miercoles, Diciembre 17, 2003
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<link rel="stylesheet" href="../static/../static/css/menu.css">
<link rel="stylesheet" href="../static/../static/css/menu2.css">
<link rel="stylesheet" href="../static/../static/css/estilo.css">
<script language="JavaScript" src="../static/../static/scripts/Tools.js"></script>
<script language="JavaScript" src="../static/../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/../static/scripts/menu_tpl2.js"></script>
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
function frmMercanciaNotasCargoProveedor_onsubmit() {
  valida=true;
	return(valida);
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
function frm_onsubmit() {
  valida=true;
	return(valida);
}


function strProveedorId(){
 document.write("<%=strProveedorId%>");
 return(true);
}

function strRazonSocialProveedor(){
 document.write("<%=strRazonSocialProveedor%>");
 return(true);
}

function strRecordBrowserHTML(){
 document.write("<%=strRecordBrowserHTML%>");
 return(true);
}

function cmdCancelar_onclick() {
 strRedireccionaPOSAdmin('MercanciaEntradas.aspx');
 return(true);
}

function window_onload() {
 MM_preloadImages('../static/../static/images/bsalir_on.gif','../static/../static/images/bayuda_on.gif');
 document.forms[0].action = "<%=strFormAction%>";

 document.forms[0].elements['txtFiltro'].value = "<%=strTipoFiltro%>";
 document.forms[0].elements['txtTipoNota'].value = "<%=strTipoNota%>";

 document.forms[0].elements['rdoTipoNota'].value = "<%= Request("rdoTipoNota") %>";
 document.forms[0].elements['rdoFiltro'].value = "<%= Request("rdoFiltro") %>"; 
 
 document.forms[0].elements['txtProveedor'].value = "<%=strProveedorId%>";
 document.forms[0].elements['txtFechaInicial'].value = "<%= Request("txtFechaInicial") %>";
 document.forms[0].elements['txtFechaFinal'].value = "<%= Request("txtFechaFinal") %>";  
 
 return(true);
}

function cmdRegresar_onclick(){
 document.forms[0].action = "MercanciaConsultarNotasCargo.aspx";
 document.forms[0].submit();
}
//-->
</script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaNotasCargoProveedor" onSubmit="return frmMercanciaNotasCargoProveedor_onsubmit()">
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
            <td width="10" bgcolor="#FFFFFF"><img src="../static/../static/images/pixel.gif" width="10" height="8"></td>
            <td width="583" class="tdmigaja"><span class="txdmigaja">Est&aacute; 
              en : </span><a href="Mercancia.aspx" class="txdmigaja">Mercanc&iacute;a</a><span class="txdmigaja"> 
              : <a href="javascript:strRedireccionaPOSAdmin('MercanciaEntradas.aspx')" class="txdmigaja">Entradas</a></span><span class="txdmigaja"> 
              : </span><span class="txdmigaja">Notas de cargo de proveedor</span></td>
            <td width="182" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script></td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont"><span class="txtitulo">Notas 
              de cargo de proveedor</span><span class="txcontenido">La siguiente 
              lista muestra las notas de cargo de un proveedor. Para ver el detalle 
              de una, haga clic en su folio.</span><br> <span class="txsubtitulo"><img src="../static/../static/images/bullet_subtitulos.gif" width="17" height="11" align="absmiddle"> 
              Notas de cargo de: 
              <script language="JavaScript">strRazonSocialProveedor();</script>
              &nbsp;&nbsp;[ 
              <script language="JavaScript">strProveedorId();</script>
              ]</span> <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="112" class="tdtittablas">Tipo de notas:</td>
                  <td width="471" class="tdconttablas"><input name="txtTipoNota" type="text" class="campotablaresultado" value="" size="50" maxlength="50" readonly="true"> 
                    <input type="hidden" name="rdoTipoNota" value=""> <input type="hidden" name="rdoFiltro" value=""> 
                    <input type="hidden" name="txtProveedor" value=""> </td>
                </tr>
                <tr> 
                  <td class="tdtittablas">Filtro de consulta:</td>
                  <td class="tdconttablas"><input name="txtFiltro" type="text" class="campotablaresultado" value=""  size="50" maxlength="50"  readonly="true"> 
                    <input type="hidden" name="txtFechaInicial" value=""> <input type="hidden" name="txtFechaFinal" value=""> 
                </tr>
              </table>
              <br> <script language="JavaScript">strRecordBrowserHTML();</script> 
              <br> <input name="cmdCancelar" type="button" class="boton" id="cmdCancelar" value="Cancelar" onClick="return cmdCancelar_onclick()"> 
              &nbsp;&nbsp; <input name="cmdRegresar" type="button" class="boton" id="cmdRegresar" value="Regresar" onClick="return cmdRegresar_onclick()"> 
              <br> <br> </td>
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
</form></form>
</body>
</html>
