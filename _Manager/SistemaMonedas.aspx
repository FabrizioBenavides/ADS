<%@ Page CodeBehind="SistemaMonedas.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSistemaMonedas" %>
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
    <td width="770" class="tdtab">Est&aacute; en : Sistema : Monedas</td>
  </tr>
</table>
<table width="780" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdgeneralcontent"><h1>Monedas</h1>
      <p>En esta parte usted podr&aacute; administrar los tipos de monedas utilizadas por sucursales; en concreto podr&aacute; administrar los
      tipos de moneda a utilizar, asignar monedas a una sucursal, as&iacute; como asignar diferentes tipos de cambio.</p>
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="358"><span class="txbluebold12"><a href="SistemaAdministrarMonedas.aspx" class="txbluebold12">Administrar monedas</a></span></td>
          <td width="43">&nbsp;</td>
          <td width="358"><span class="txbluebold12"><a href="SistemaAsignarTipoDeCambio.aspx" class="txbluebold12">Asignar tipo de cambio</a></span></td>
        </tr>
        <tr>
          <td width="358"><p>Alta y edici&oacute;n de las monedas que ser&aacute;n utilizadas
            por las sucursales.</p></td>
          <td width="43">&nbsp;</td>
          <td><p>Asignar y editar el tipo de cambio a una moneda
            espec&iacute;fica utilizada por una sucursal.</p></td>
        </tr>
        <tr>
          <td><span class="txbluebold12"><a href="SistemaAsignarMonedas.aspx" class="txbluebold12">Asignar monedas a sucursal</a></span></td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td><p>Asignar monedas a una sucursal determinada.</p></td>
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
