<%@ Page CodeBehind="SistemaEmpresasRecolectoras.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSistemaEmpresasRecolectoras" %>
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

function goToURL(where) {
    top.location = where; 
}
	
// done hiding -->
</script>
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
    <td width="770" class="tdtab">Está en : <a href="Sistema.aspx">Sistema</a> : Empresas recolectoras</td> 
  </tr> 
</table> 
<table width="780" border="0" cellpadding="0" cellspacing="0"> 
  <tr> 
    <td class="tdgeneralcontent"><h1>Empresas Recolectoras</h1> 
      <p>En esta parte usted puede administrar y asignar a las sucursales diferentes empresas recolectoras.</p> 
      <table width="100%" border="0" cellspacing="0" cellpadding="0"> 
        <tr> 
          <td width="358"><a href="SistemaEmpresasRecolectorasAdministrarEmpresasRecolectoras.aspx" class="txbluebold12">Administrar empresas recolectoras </a> </td> 
          <td width="43">&nbsp;</td> 
          <td width="358"><a href="SistemaEmpresasRecolectorasAsignarRecolectoras.aspx" class="txbluebold12">Asignar recolectoras a sucursales </a> </td> 
        </tr> 
        <tr> 
          <td width="358"><p>Alta y edición en el sistema de diferentes empresas recolectoras.</p></td> 
          <td width="43">&nbsp;</td> 
          <td><p>Asignación de empresas recolectoras a las sucursales.</p></td> 
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
