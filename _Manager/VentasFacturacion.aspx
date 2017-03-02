<%@ Page Language="vb" AutoEventWireup="false" Codebehind="VentasFacturacion.aspx.vb" Inherits="com.isocraft.backbone.ccentral.VentasFacturacion"%>
<HTML>
<HEAD>
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
<script id="clientEventHandlersJS" language="javascript">
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function goToURL(where) 
	{
	top.location = where; 
	}
	
// done hiding -->
				</script>
<style type="text/css"> <!-- .style1 {font-size: 10px}
	--></style>
</HEAD>
<body>
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr> 
    <td><script language="JavaScript">crearTablaHeader()</script></td>
  </tr>
</table>
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr> 
    <td width="10">&nbsp;</td>
    <td width="770" class="tdtab">Está en : <a href="VentasHome.aspx">Ventas</a> 
      : Facturación</td>
  </tr>
</table>
<table width="780" border="0" cellpadding="0" cellspacing="0">
  <tr> 
    <td class="tdgeneralcontent"><h1>Facturaci&oacute;n</h1>
      <p>En esta parte usted puede realizar actividades relacionadas directamente 
        con la facturación de las ventas de sucursales</p>
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr> 
          <td width="358"><span class="txbluebold12"><a href="VentasFacturacionGlobal.aspx" class="txbluebold12">Facturación 
            Global</a></span></td>
          <td width="43">&nbsp;</td>
          <td height="18"><span class="txbluebold12"><a href="VentasFacturacionReporteSucursal.aspx"  class="txbluebold12">Reporte 
            Facturación Sucursal</a></span></td>
        </tr>
        <tr> 
          <td width="358"><p>En esta parte se genera la facura global de las ventas 
              de todas las sucursales que emiten CFD.</p></td>
          <td width="43">&nbsp;</td>
          <TD> <P>En esta parte se consultan las facturas emitidas en sucursales.</P></TD>
        </tr>
        <tr> 
          <td width="358"><span class="txbluebold12"><a href="VentasFacturacionGlobalDiaria.aspx" class="txbluebold12">Facturación 
            Global CFDI</a></span></td>
          <td width="43">&nbsp;</td>
          <td height="18"><span class="txbluebold12">&nbsp;</td>
        </tr>
        <tr> 
          <td width="358"><p>En esta parte se genera la facura global de las ventas 
              de todas las sucursales que emiten CFDI.</p></td>
          <td width="43">&nbsp;</td>
          <TD>&nbsp;</TD>
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
</body>
</HTML>
