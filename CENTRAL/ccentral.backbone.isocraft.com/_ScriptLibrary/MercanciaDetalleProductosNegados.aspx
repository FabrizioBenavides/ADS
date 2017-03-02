<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaDetalleProductosNegados.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaDetalleProductosNegados" codePage="28592"%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%  '====================================================================
    ' Page          : MercanciaDetalleProductosNegados.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página detalle de productos devueltos.
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Carlos E. Pérez Torres
    ' Version       : 1.0
    ' Last Modified : October 29, 2003
    '====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<link rel="stylesheet" href="../static/css/menu.css">
<link rel="stylesheet" href="../static/css/menu2.css">
<link rel="stylesheet" href="../static/css/estilo.css">
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--


function window_onload() {
		MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
		document.forms[0].action = "<%=strFormAction%>"; 
         return(true);
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
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")%>");
	return(true);
}

function strUsuarioNombre() {
	document.write("<%=strUsuarioNombre%>");
	return(true);
}

function strRecordBrowserHTML() {
	document.write("<%=strRecordBrowserHTML%>");
	return(true);
}

// Escribimos las funciones para llenar los datos de la página.
function intFolioId() {
	document.write("<%=intFolioId%>");
	return(true);
}

function dtmFecha() {
	document.write("<%=dtmFecha%>");
	return(true);
}

function btnSalir_onclick() {
	window.location = "MercanciaEntradas.aspx"
	return(true);
}

//-->
</script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0"  onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaDetalleProductosNegados">
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
              </span><a href="Mecancia.aspx" class="txdmigaja">Mercancía</a><span class="txdmigaja"> 
              : <a href="MercanciaInventarios.aspx" class="txdmigaja">Inventarios</a></span><span class="txdmigaja"> 
              </span><span class="txdmigaja">: </span><span class="txdmigaja"> 
              <a href="MercanciaArchivoProductosNegados.aspx" class="txdmigaja">Productos 
              negados</a></span> <span class="txdmigaja">: </span> <span class="txdmigaja">Detalle 
              de productos negados</span></td>
            <td width="182" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top"><table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="100%" colspan="3" valign="top" class="tdtablacont"> 
                    <p><span class="txtitulo">Detalle de reporte de productos 
                      negados</span> 
                      <script language="JavaScript">crearDatosSucursal()</script>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                      <tr> 
                        <td width="112" class="tdtittablas">Folio consultado:</td>
                        <td width="119" valign="middle" class="tdconttablas"><script language="javascript">intFolioId()</script> 
                        </td>
                        <td width="46" valign="middle" class="tdtittablas">Fecha:</td>
                        <td width="291" valign="middle" class="tdconttablas"><script language="javascript">dtmFecha()</script> 
                        </td>
                      </tr>
                    </table>
                    <br> <script language="javascript">strRecordBrowserHTML()</script> 
                    <!--
                  <table width="98%" border="0" cellpadding="0" cellspacing="0">
                    <tr class="trtitulos"> 
                      <th width="74" class="rayita">C&oacute;digo</th>
                      <th width="300" class="rayita">Descripci&oacute;n</th>
                      <th width="183" class="rayita">Veces negado</th>
                    </tr>
                    <tr> 
                      <td class="tdceleste"><a href="#" class="txaccion">12543</a></td>
                      <td class="tdceleste">Neuroflax Fco. Amp. 4 ml</td>
                      <td class="tdceleste">1</td>
                    </tr>
                    <tr> 
                      <td class="tdblanco"><a href="#" class="txaccion">76453</a></td>
                      <td class="tdblanco">Sebryl Plus 150 ml</td>
                      <td class="tdblanco">4</td>
                    </tr>
                    <tr> 
                      <td class="tdceleste"><a href="#" class="txaccion">31234</a></td>
                      <td class="tdceleste">Bye bye mosquitos</td>
                      <td class="tdceleste">8</td>
                    </tr>
                  </table>
-->
                    <br> <input name="btnSalir" type="button" class="boton" value="Regresar" onClick="return btnSalir_onclick();"> 
                    &nbsp;&nbsp; <input name="btnOtroFolio" type="button" class="boton" value="Ver otro folio" onClick="history.go(-1);"> 
                    &nbsp;&nbsp; <input name="boton23232322" type="button" class="boton" value="Imprimir reporte" onClick="window.print();"> 
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
	//-->
</script>
</form>
</body>
</html>
