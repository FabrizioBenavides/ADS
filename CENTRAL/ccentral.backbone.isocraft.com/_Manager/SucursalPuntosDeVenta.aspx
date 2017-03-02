<%@ Page CodeBehind="SucursalPuntosDeVenta.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSucursalPuntosDeVenta" %>
<html>
<head>
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<meta name="description" content="Javascript Menu">
<meta name="keywords" content="JavaScript menu, javascript, html, client side, netscape, explorer, IE, menu, DHTML, DOM, control">
<link href="css/menu.css" rel="stylesheet" type="text/css">
<link href="css/estilo.css" rel="stylesheet" type="text/css">
<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
<script id=clientEventHandlersJS language=javascript>
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function goToURL(where) 
	{
	top.location = where; 
	}
	
// done hiding -->
</script>
</head>
<body>
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><script language="JavaScript">crearTablaHeader()</script></td>
  </tr>
</table>
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="10">&nbsp;</td>
    <td width="770" class="tdtab">Est&aacute; en : <a href="Sucursal.htm">Sucursal</a> : Puntos de venta </td>
  </tr>
</table>
<table width="780" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdgeneralcontent"><h1>Puntos de venta </h1>
      <p>En esta parte usted podr&aacute; administrar los puntos de venta; en concreto podr&aacute; consultar cajas en sucursales y cajas<br>
      inhabilitadas, as&iacute; como administrar pol&iacute;ticas de POS, formatos de datos de pol&iacute;ticas de POS y estados operativos.</p>
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="358"><span class="txbluebold12"><a href="SucursalConsultarCajasEnSucursales.aspx" class="txbluebold12">Consultar cajas en sucursales</a></span></td>
          <td width="43">&nbsp;</td>
          <td width="358"><span class="txbluebold12"><a href="SucursalAdministrarFormatoDatoPoliticaPos.aspx" class="txbluebold12">Administrar formato de datos de políticas POS</a></span></td>
        </tr>
        <tr>
          <td width="358"><p>Consultar detalle de cajas en sucursales
            espec&iacute;ficas.</p></td>
          <td width="43">&nbsp;</td>
          <td><p>Alta y edici&oacute;n de formatos de datos para pol&iacute;ticas
            asignadas a puntos de venta.</p></td>
        </tr>
        <tr>
          <td><span class="txbluebold12"><a href="SucursalConsultarCajasInhabilitadas.aspx" class="txbluebold12">Consultar cajas inhabilitadas</a></span></td>
          <td>&nbsp;</td>
          <td><span class="txbluebold12"><a href="SucursalAdministrarEstadoOperativoCaja.aspx" class="txbluebold12">Administrar estados operativos</a></span></td>
        </tr>
        <tr>
          <td><p>Consultar cajas que se encuentran inhabilitadas
            con base en una fecha determinada.</p></td>
          <td>&nbsp;</td>
          <td><p>Alta y edici&oacute;n de estados operativos de cajas.</p></td>
        </tr>
        <tr>
          <td><span class="txbluebold12"><a href="SucursalAdministrarPoliticasDePos.aspx" class="txbluebold12">Administrar pol&iacute;ticas de POS</a></span></td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td><p>Asignaci&oacute;n, edici&oacute;n y cancelaci&oacute;n de diferentes
            pol&iacute;ticas para puntos de venta.</p></td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
      </table>      </td>
  </tr>
</table>
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><script language="JavaScript">crearTablaFooterCentral()</script></td>
  </tr>
</table>
<script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	//-->
</script>
</body>
</html>
