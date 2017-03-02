<%@ Page CodeBehind="SistemaTransmisiones.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSistemaTransmisiones" %>
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
    <td><script language="JavaScript">crearTablaHeader()</script>
    </td>
  </tr>
</table>
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="10">&nbsp;</td>
    <td width="770" class="tdtab">Est&aacute; en : Sistema : Transmisones </td>
  </tr>
</table>
<table width="780" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdgeneralcontent"><h1>Transmisiones</h1>
      <p>En esta parte usted podr&aacute; realizar consultas de transmisiones;
        en concreto podr&aacute; consultar el nivel de servicio en<br>
        transmisiones, transmisiones pendientes y actualizaciones pendientes.</p>
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="358"><span class="txbluebold12"><a href="SistemaConsultarNivelDeServicioEnTransmisiones.aspx" class="txbluebold12">Consultar
                nivel de servicio en transmisiones</a></span></td>
          <td width="43">&nbsp;</td>
          <td width="358"><span class="txbluebold12"><a href="SistemaConsultarActualizacionesPendientes.aspx" class="txbluebold12">Consultar
                actualizaciones pendientes</a></span></td>
        </tr>
        <tr>
          <td width="358"><p>Consultar reportes de nivel de servicio de transmisiones
              con base en una fecha espec&iacute;fica.</p>
          </td>
          <td width="43">&nbsp;</td>
          <td><p>Consultar puntos de venta con actualizaciones pendientes. Imprimir
              reportes.</p>
          </td>
        </tr>
        <tr>
          <td><span class="txbluebold12"><a href="SistemaConsultarTransmisionesPendientes.aspx" class="txbluebold12">Consultar
                transmisiones pendientes</a></span></td>
          <td>&nbsp;</td>
          <td width="358"><span class="txbluebold12"><a href="SistemaActualizarSucursal.aspx" class="txbluebold12">Enviar
                Catalogos a sucursal</a></span></td>
        </tr>
        <tr>
          <td><p>Consultar el detalle de diferentes tipos de transmisiones pendientes.</p>
          </td>
          <td>&nbsp;</td>
          <td><p>Enviar las actualizaciones de catalogos a sucursal(es) seleccionada(s).</p>
          </td>
        </tr>
      </table>
    </td>
  </tr>
</table>
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><script language="JavaScript">crearTablaFooterCentral()</script>
    </td>
  </tr>
</table>
<script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	//-->
</script>
</body>
</html>
