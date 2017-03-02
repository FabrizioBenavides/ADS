<%@ Page CodeBehind="SucursalAsignacionDeCuotas.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSucursalAsignacionDeCuotas" codePage="1252" EnableSessionState="False" enableViewState="False"%>
<html>
<head>
<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
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
    <td width="770" class="tdtab">Est&aacute; en : Sucursal : Asignaci&oacute;n de cuotas </td>
  </tr>
</table>
<table width="780" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdgeneralcontent"><h1>Asignaci&oacute;n de cuotas</h1>
      <p>En esta parte usted puede administrar y asignar diferentes cuotas y m&aacute;rgenes de compra; en concreto podr&aacute;<br>
      administrar y asignar cuotas de venta, as&iacute; como administrar m&aacute;rgenes de compra.</p>
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="358"><span class="txbluebold12"><a href="SucursalAdministrarCuotasDeVenta.aspx" class="txbluebold12">Administrar cuotas de venta</a></span></td>
          <td width="43">&nbsp;</td>
          <td width="358"><span class="txbluebold12"><a href="SucursalAdministrarMargenesDeCompra.aspx" class="txbluebold12">Administrar m&aacute;rgenes de compra</a></span></td>
        </tr>
        <tr>
          <td width="358"><p>Agregar y editar cuotas de venta para las diferentes<br>
          sucursales.</p></td>
          <td width="43">&nbsp;</td>
          <td><p>Asignar y cancelar m&aacute;rgenes de compra a sucursales<br>
            espec&iacute;ficas.</p></td>
        </tr>
        <tr>
          <td><span class="txbluebold12"><a href="SucursalAsignarCuotasdeVenta.aspx" class="txbluebold12">Asignar cuotas de venta</a></span></td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td><p>Asignar cuotas de venta preestablecidas a sucursales<br>
            determinadas.</p></td>
          <td>&nbsp;</td>
          <td></td>
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
