<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalFotolabHome.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalFotolabHome"%>
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
    <td width="770" class="tdtab">Est&aacute; en : <a href="SucursalHome.aspx">Sucursal</a>:
      Fotolab</td>
  </tr>
</table>
<table width="780" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdgeneralcontent"><h1>Fotolab</h1>
      <p>En esta parte usted puede administrar los FOTOLABS.</p>
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="358"><span class="txbluebold12"><a href="AdminOrdenesHome.aspx" class="txbluebold12">Ordenes</a></span></td>
          <td width="43">&nbsp;</td>
          <td width="358"><span class="txbluebold12"><a href="AdminCatalogosHome.aspx" class="txbluebold12">Catalogos</a></span></td>
        </tr>
        <tr>
          <td width="358"><p>En esta parte usted podrá consultar las Ordenes.</p>
          </td>
          <td width="43">&nbsp;</td>
          <td><p>En esta parte usted podr&aacute; administrar los cat&aacute;logos;
              en concreto podr&aacute; consultar art&iacute;culos y clasificaci&oacute;n<br>
              de art&iacute;culos , as&iacute; como la consulta de farmacias
              y marcas de rollo.</p>
          </td>
        </tr>
        <tr>
          <td><span class="txbluebold12"><a href="AdminAsignacionesHome.aspx" class="txbluebold12">Asignaciones</a></span></td>
          <td>&nbsp;</td>
          <td width="358"><span class="txbluebold12"><a href="AdminReportesHome.aspx" class="txbluebold12">Reportes</a></span></td>
        </tr>
        <tr>
          <td><p>En esta parte usted podr&aacute; administrar las Asignacioines;
              en concreto podr&aacute; asignar Farmacias a Laboratorios,<br>
              as&iacute; como la asignaci&oacute;n de Trabajos a Laboratorios.</p>
          </td>
          <td>&nbsp;</td>
          <td><p>En esta parte usted podrá administrar los distintos Reportes;
              en concreto podrá consultar el reporte de Imagen, así como el reporte
              de Trabajos y el de Producción.</p>
          </td>
        </tr>
        <tr>
          <td><span class="txbluebold12"><a href="AdminRemisionesHome.aspx" class="txbluebold12">Remisiones</a></span></td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td><p>En esta parte usted podr&aacute; consultar las Remisiones.</p>
          </td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
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
