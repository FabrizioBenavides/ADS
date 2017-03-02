<%@ Page Language="vb" AutoEventWireup="false" Codebehind="VentasProductosComplementarios.aspx.vb" Inherits="com.isocraft.backbone.ccentral.VentasProductosComplementarios" codePage="1252" EnableSessionState="False" enableViewState="False" %>
<html>
<head>
<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<link href="css/menu.css" rel="stylesheet" type="text/css">
<link href="css/estilo.css" rel="stylesheet" type="text/css">
<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
<script id=clientEventHandlersJS language=javascript>
<!--

//Esta página no se está utilizando desde el proyecto Integración de comisiones al POS (IPC)
//Noviembre 2008 ATTE. Javier Augusto Pérez González -- SOFTTEK GDC Monterrey


strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";
	
// done hiding -->
</script>
</head>
<body>
<form name="frmMain" action="about:blank" method="post">
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr> 
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr> 
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Est&aacute; en : <a href="Ventas.htm">Ventas</a> 
        : Productos de venta cruzada</td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr> 
      <td class="tdgeneralcontent"><h1>Productos de venta cruzada </h1>
        <p>En esta parte usted puede administrar productos de venta cruzada para 
          el POS.</p>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr> 
            <td width="358"><a href="VentasProductosComplementariosConsultar.aspx" class="txbluebold12">Consultar 
              productos</a></td>
            <td width="43">&nbsp;</td>
            <td width="358"><a href="VentasProductosComplementariosCargaArchivo.aspx" class="txbluebold12">Agregar 
              productos por archivo</a></td>
          </tr>
          <tr> 
            <td width="358"><p>Consulta de productos que cuentan con artículos 
                de venta cruzada.</p></td>
            <td width="43">&nbsp;</td>
            <td><p>Alta de productos padre y sus art&iacute;culos de venta cruzada 
                de manera masiva por medio de un archivo.</p></td>
          </tr>
          <tr> 
            <td><a href="VentasProductosComplementariosAgregar.aspx?strCmd=Menu" class="txbluebold12">Agregar 
              productos individualmente</a></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
          </tr>
          <tr> 
            <td><p>Alta de productos padre de manera individual y asignación de<br>
                artículos de venta cruzada.</p></td>
            <td>&nbsp;</td>
            <td><p>&nbsp;</p></td>
          </tr>
        </table></td>
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
</form>
</body>
</html>
