<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalInventarioRotativoSucursales.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalInventarioRotativoSucursales"%>
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
    <td width="770" class="tdtab">Est&aacute; en : <a href="SucursalHome.aspx">Sucursal</a>:<a href="SucursalInventarioRotativoHome.aspx">Inventario
        Rotativo</a>:Sucursales</td>
  </tr>
</table>
<table width="780" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdgeneralcontent"><h1>Sucursales</h1>
      <p>En esta parte usted puede administrar las sucursales para la toma de
        Inventarios Rotativos.</p>
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="358"><span class="txbluebold12"><a href="SucursalSinCierreInventario.aspx" class="txbluebold12">Consultar
                Sucursales sin Cierre de Inventarios</a></span></td>
          <td width="43">&nbsp;</td>
          <td width="358"><span class="txbluebold12"><a href="SucursalHabilitarInventarioRotativo.aspx" class="txbluebold12">Deshabilitar
                Sucursales</a></span></td>
        </tr>
        <tr>
          <td width="358"><p>Aqu&iacute; podr&aacute; consultar las sucursales
              que No han Cerrado su Inventario.</p>
          </td>
          <td width="43">&nbsp;</td>
          <td><p>Aqu&iacute; podr&aacute; deshabilitar/habilitar la toma de inventario
              a las sucursales..</p>
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
