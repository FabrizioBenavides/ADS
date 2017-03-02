<%@ Page Language="vb" AutoEventWireup="false" Codebehind="AdminAsignacionesHome.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsAdminAsignacionHome" Explicit="True" Trace="False" Strict="True" codePage="1252" EnableSessionState="true" enableViewState="False" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Benavides : Administrador de Puntos de Venta</TITLE>
		<%
    '====================================================================
    ' Page          : ArticuloFotolabaspx
    ' Title         : Cat�logo de Articulos
    ' Description   : Cat�logo de Clasificacion de Art�culos Por Sucursal
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
    <td width="770" class="tdtab">Est&aacute; en : ADMIN : Asignaciones </td>
  </tr>
</table>

<table width="780" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdgeneralcontent"><h1>Men� de Asignaciones </h1>
      <p>En esta parte usted podr&aacute; administrar las Asignacioines; en concreto podr&aacute; asignar Farmacias a Laboratorios,<br> 
      as&iacute; como la asignaci�n de Trabajos a Laboratorios.</p>
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="358"><span class="txbluebold12"><a href="AsignacionFotolabAFarmacia.aspx" class="txbluebold12">Farmacia a Laboratorio</a></span></td>
          <td width="43">&nbsp;</td>
          <td width="358"><span class="txbluebold12"><a href="AsignacionTrabajosAFotolab.aspx" class="txbluebold12">Trabajos  a Laboratorio</a></span></td>
        </tr>
        <tr>
          <td width="358"><p>Pantalla para asignar a los laboratorios, las farmacias a las cuales se les producir&aacute;n trabajos.</p></td>
          <td width="43">&nbsp;</td>
          <td><p>Pantalla para asignar a los laboratorios, los trabajos que podr� producir.</p></td>
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