<%@ Page CodeBehind="SistemaCuentas.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSistemaCuentas" %>
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
    <td width="770" class="tdtab">Est&aacute; en : Sistema : Cuentas </td>
  </tr>
</table>
<table width="780" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdgeneralcontent"><h1>Cuentas</h1>
      <p>En esta parte usted podr&aacute; administrar datos relacionados con cuentas bancarias; en concreto podr&aacute; administrar
      cuentas, d&iacute;as inh&aacute;biles y ubicaciones bancarias.</p>
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="358"><span class="txbluebold12"><a href="SucursalAdministrarCuentas.aspx" class="txbluebold12">Administrar cuentas</a></span></td>
          <td width="43">&nbsp;</td>
          <td width="358"><span class="txbluebold12"><a href="SistemaAdministrarUbicacionesBancarias.aspx" class="txbluebold12">Administrar ubicaciones bancarias</a></span></td>
        </tr>
        <tr>
          <td width="358"><p>Alta y edici&oacute;n de cuentas bancarias con diferentes
            caracter&iacute;sticas.</p></td>
          <td width="43">&nbsp;</td>
          <td><p>Alta y edici&oacute;n de diferentes ubicaciones bancarias.</p></td>
        </tr>
        <tr>
          <td><span class="txbluebold12"><a href="SistemaAdministrarDiasInhabiles.aspx" class="txbluebold12">Administrar d&iacute;as inh&aacute;biles</a></span></td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td><p>Alta y edici&oacute;n de d&iacute;as inh&aacute;biles que se deben tomar<br>
            en cuenta para la realizaci&oacute;n de pagos.</p></td>
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
