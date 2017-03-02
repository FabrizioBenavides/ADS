<%@ Page CodeBehind="VentasDescuentosyExceptos.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsVentasDescuentosyExceptos" %>
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
    <td width="770" class="tdtab">Est&aacute; en : Ventas : Descuentos y exceptos </td>
  </tr>
</table>
<table width="780" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdgeneralcontent"><h1>Descuentos y exceptos</h1>
      <p>En esta parte usted puede administrar art&iacute;culos y descuentos espec&iacute;ficos; en concreto podr&aacute; administrar art&iacute;culos no<br>
      autorizados, art&iacute;culos exceptos, descuentos por cliente y descuentos por departamento.</p>
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="358"><span class="txbluebold12"><a href="VentasAdministrarArticulosNoAutorizados.aspx" class="txbluebold12">Administrar art&iacute;culos no autorizados</a></span></td>
          <td width="43">&nbsp;</td>
          <td width="358"><span class="txbluebold12"><a href="VentasAdministrarDescuentosPorCliente.aspx" class="txbluebold12">Administrar descuentos por cliente</a></span></td>
        </tr>
        <tr>
          <td width="358"><p>Agregar y asignar a clientes determinados art&iacute;culos para ventas de cr&eacute;dito.</p></td>
          <td width="43">&nbsp;</td>
          <td><p>Agregar y asignar art&iacute;culos con descuento para<br>
            clientes espec&iacute;ficos.</p></td>
        </tr>
        <tr>
          <td><span class="txbluebold12"><a href="VentasAdministrarArticulosExceptosDeDescuento.aspx" class="txbluebold12">Administrar art&iacute;culos exceptos de descuento</a></span></td>
          <td>&nbsp;</td>
          <td><span class="txbluebold12"><a href="VentasAdministrarDescuentosPorDepartamento.aspx" class="txbluebold12">Administrar descuentos por departamento</a></span></td>
        </tr>
        <tr>
          <td><p>Agregar o reemplazar art&iacute;culos exceptos de<br>
            descuento.</p></td>
          <td>&nbsp;</td>
          <td><p>Importar lotes. Agregar y editar las diferentes<br>
            pol&iacute;ticas relacionadas con ellos.</p></td>
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
