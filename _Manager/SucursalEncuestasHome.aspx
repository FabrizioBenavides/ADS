<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalEncuestasHome.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalEncuestasHome"%>
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
      Encuestas</td>
  </tr>
</table>
<table width="780" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdgeneralcontent"><h1>Encuestas</h1>
      <p>En esta parte usted puede administrar las encuestas para sucursales</p>
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="358"><span class="txbluebold12"><a href="SucursalEncuestaAdministrarRespuestas.aspx" class="txbluebold12">Respuestas</a></span></td>
          <td width="43">&nbsp;</td>
          <td width="358"><span class="txbluebold12"><a href="SucursalEncuestaReporteSucursales.aspx" class="txbluebold12">Reportes</a></span></td>
        </tr>
        <tr>
          <td width="358"><p>Aqu&iacute; podr&aacute; dar de alta o modificar
              las respuestas a las preguntas de la encuesta.</p>
          </td>
          <td width="43">&nbsp;</td>
          <td><p>Aqu&iacute; podr&aacute; consultar los resultados de las encuestas
              aplicadas en sucursales.</p>
          </td>
        </tr>
        <tr>
          <td><span class="txbluebold12"><a href="SucursalEncuestaAdministrarPreguntas.aspx" class="txbluebold12">Preguntas</a></span></td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td><p>Aqu&iacute; podr&aacute; dar de alta o modificar las preguntas
              para las encuestas.</p>
          </td>
          <td>&nbsp;</td>
          <td>&nbsp; </td>
        </tr>
        <tr>
          <td><span class="txbluebold12"><a href="SucursalEncuestaAdministrarEncuestas.aspx" class="txbluebold12">Encuestas</a></span></td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td><p>Aqu&iacute; podr&aacute; dar de alta o modificar las encuestas.
              Asignarla a las sucursales.</p>
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
