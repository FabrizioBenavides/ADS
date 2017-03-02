<%@ Page CodeBehind="Sistema.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSistema" enableViewState="False" EnableSessionState="False"%>
<html>
<head>
<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
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
    <td width="770" class="tdtab">Est&aacute; en : Sistema</td>
  </tr>
</table>
<table width="780" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdgeneralcontent"><h1>Sistema</h1>
      <p>En esta parte usted puede realizar actividades de administraci&oacute;n del sistema CTX. Cuenta con los siguientes apartados:</p>
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="358"><span class="txbluebold12"><a href="SistemaTransmisiones.aspx" class="txbluebold12">Transmisiones</a></span></td>
          <td width="43">&nbsp;</td>
          <td width="358"><span class="txbluebold12"><a href="SistemaMonedas.aspx" class="txbluebold12">Monedas</a></span></td>
        </tr>
        <tr>
          <td width="358"><p>Consulta de transmisiones realizadas y pendientes con base en fechas determinadas.</p></td>
          <td width="43">&nbsp;</td>
          <td><p>Administraci&oacute;n de los tipos de monedas utilizadas por las sucursales.</p></td>
        </tr>
        <tr>
          <td><span class="txbluebold12"><a href="SistemaTiendas.aspx" class="txbluebold12">Tiendas</a></span></td>
          <td>&nbsp;</td>
          <td><span class="txbluebold12"><a href="SistemaCuentas.aspx" class="txbluebold12">Cuentas</a></span></td>
        </tr>
        <tr>
          <td><p>Administraci&oacute;n de las diferentes tiendas y sus sucursales.</p></td>
          <td>&nbsp;</td>
          <td><p>Administraci&oacute;n de datos que se refieren a cuentas bancarias.</p></td>
        </tr>
        <tr>
          <td><span class="txbluebold12"><a href="SistemaUsuarios.aspx" class="txbluebold12">Usuarios</a></span></td>
          <td>&nbsp;</td>
          <td><span class="txbluebold12"><a href="SistemaClientesEspeciales.aspx" class="txbluebold12">Clientes especiales</a></span></td>
        </tr>
        <tr>
          <td><p>Administraci&oacute;n de los usuarios que interact&uacute;an con el sistema.</p></td>
          <td>&nbsp;</td>
          <td><p>Administraci&oacute;n de los clientes especiales de las sucursales.</p></td>
        </tr>
        <tr>
          <td><span class="txbluebold12"><a href="SistemaEmpresasRecolectoras.aspx" class="txbluebold12">Empresas recolectoras</a></span></td>
          <td>&nbsp;</td>
          <td><span class="txbluebold12"><a href="SistemaComisionesDex.aspx" class="txbluebold12">Comisiones DEX</a></span></td>
        </tr>
        <tr>
          <td><p>Administraci&oacute;n de las empresas recolectoras utilizadas en el sistema.</p></td>
          <td>&nbsp;</td>
          <td><p>Consulta y edici&oacute;n de las diferentes comisiones utilizadas en las operaciones de Dinero Express.</p></td>
        </tr>
		<tr>
          <td><span class="txbluebold12"><a href="SistemaBines.aspx" class="txbluebold12">BINes</a></span></td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td><p>En esta parte usted podr&aacute; administrar la informaci&oacute;n correspondiente a los BINes que son utilizados en el sistema; en concreto podr&aacute; realizar consultas, as&iacute; como dar de alta y editar BINes.</p></td>
          <td>&nbsp;</td>
          <td><p>&nbsp;</p></td>
        </tr>

      </table>
      <p>&nbsp;</p></td>
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
