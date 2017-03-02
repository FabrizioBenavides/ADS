<%@ Page Language="vb" AutoEventWireup="false" Codebehind="AdminCatalogosHome.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsAdminCatalogosHome" Explicit="True" Trace="False" Strict="True" codePage="1252" EnableSessionState="true" enableViewState="False" %>

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
    <td width="770" class="tdtab">Est&aacute; en : ADMIN : Cátalogos </td>
  </tr>
</table>

<table width="780" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdgeneralcontent"><h1>Menú de Catálogos </h1>
      <p>En esta parte usted podr&aacute; administrar los cat&aacute;logos; en concreto podr&aacute; consultar art&iacute;culos y clasificaci&oacute;n<br>
      de art&iacute;culos , as&iacute; como la consulta de farmacias y marcas de rollo.</p>
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="358"><span class="txbluebold12"><a href="ArticuloFotolab.aspx" class="txbluebold12">Artículos</a></span></td>
          <td width="43">&nbsp;</td>
          <td width="358"><span class="txbluebold12"><a href="ClasificacionDeArticulo.aspx" class="txbluebold12">Clasificaci&oacute;n de Art&iacute;culos</a></span></td>
        </tr>
        <tr>
          <td width="358"><p>Consulta del Cat&aacute;logo de Art&iacute;culos.</p></td>
          <td width="43">&nbsp;</td>
          <td><p>Consulta del Cat&aacute;logo de Clasificaci&oacute;n de Art&iacute;culos.</p></td>
        </tr>
        <tr>
          <td width="358"><span class="txbluebold12"><a href="ConsultaClientesAdmin.aspx" class="txbluebold12">Farmacias</a></span></td>
          <td width="43">&nbsp;</td>
          <td width="358"><span class="txbluebold12"><a href="MarcaRollo.aspx" class="txbluebold12">Marcas de Rollos</a></span></td>
        </tr>
        <tr>
          <td width="358"><p>Pantalla de consulta de las Farmacias. </p></td>
          <td width="43">&nbsp;</td>
          <td><p>Consulta del Cat&aacute;logo de Marcas de Rollos.</p></td>
        </tr>
        
           <tr>
          <td width="358"><span class="txbluebold12"><a href="ClasificacionDeArticulo2Admin.aspx" class="txbluebold12">Tipo de Artículos</a></span></td>
          <td width="43">&nbsp;</td>
          <td width="358">&nbsp;</td>
        </tr>
        <tr>
          <td width="358"><p>Pantalla de consulta y cambio de Catálogo de Tipo de Artículos.</p></td>
          <td width="43">&nbsp;</td>
          <td>&nbsp;</td>
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