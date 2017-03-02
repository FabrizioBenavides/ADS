<%@ Page Language="vb" AutoEventWireup="false" Codebehind="AdminReportesHome.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsAdminReportesHome" Explicit="True" Trace="False" Strict="True" codePage="1252" EnableSessionState="true" enableViewState="False" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Benavides : Administrador de Puntos de Venta</TITLE>
		<%
    '====================================================================
    ' Page          : ArticuloFotolabaspx
    ' Title         : Catálogo de Articulos
    ' Description   : Catálogo de Clasificacion de Artículos Por Sucursal
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Neitek Solutions S.A. de C.V.
    ' Author        : Jorge Ventura Cantu Campos
    ' Version       : 1.0
    ' Last Modified : Friday, February 11Th, 2005
    '====================================================================
%>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="css/menu.css" type="text/css" rel="stylesheet">
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="js/menu.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="js/menu_items.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="js/menu_tpl.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="js/headerfooter.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="js/FotoLabUtils.js" type="text/JavaScript"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--
strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";
strSucursalNombre = "<%= strNombreSucursal %>";
strSucursalId = "<%= strSucursalId%>";

function goToURL(where) 
	{
	top.location = where; 
	}

//-->
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
    <td width="770" class="tdtab">Est&aacute; en : ADMIN : Reportes </td>
  </tr>
</table>

<table width="780" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdgeneralcontent"><h1>Menú de Reportes </h1>
      <p>En esta parte usted podr&aacute; administrar los distintos Reportes; en concreto podr&aacute; consultar el reporte de Imagen,<br>
      as&iacute; como el reporte de Trabajos y el de Producci&oacute;n</p>
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="358"><span class="txbluebold12"><a href="ReporteImagen.aspx" class="txbluebold12">Imagen</a></span></td>
          <td width="43">&nbsp;</td>
          <td width="358"><span class="txbluebold12"><a href="ReporteProduccionAdmin.aspx" class="txbluebold12">Producci&oacute;n  por Clasificación de Artículo</a></span></td>
        </tr>
        <tr>
          <td width="358"><p>Reporte de Imagen, que muestra los tiempos de 
								producci&oacute;n para las &oacute;rdenes.</p></td>
          <td width="43">&nbsp;</td>
          <td><p>Reporte que muestra el total de impresiones y rollos producidos.</p></td>
        </tr>
        <tr>
          <td width="358"><span class="txbluebold12"><a href="ReporteClasificacion2Admin.aspx" class="txbluebold12">Produccion</a></span></td>
          <td width="43">&nbsp;</td>
          <td width="358"><span class="txbluebold12">&nbsp;</span></td>
        </tr>
        <tr>
          <td width="358"><p>Reporte de Cantidad de trabajos por Farmacia y Laboratorio  por Tipo de Artículo.</p></td>
          <td width="43">&nbsp;</td>
          <td width="358"><p>&nbsp;</p></td>
        </tr>
      </table>      </td>
  </tr>
</table>
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><script language="JavaScript">crearTablaFooter()</script></td>
  </tr>
</table>
<script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	//-->
</script>
</body>
</html>