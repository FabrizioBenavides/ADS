<%@ Page CodeBehind="SistemaVerTienda.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSistemaVerTienda" Explicit="True" Trace="False" Strict="True" codePage="1252" %>
<html>
<head>
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<link href="css/menu.css" rel="stylesheet" type="text/css">
<link href="css/estilo.css" rel="stylesheet" type="text/css">
<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<script language="JavaScript" type="text/JavaScript">

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";


function window_onload() {
  document.forms[0].action = "<%= strThisPageName %>";
}

</script>
<script id=clientEventHandlersJS language=javascript>
<!--

function cmdEditar_onclick() {
  window.location.href="SistemaEditarTienda.aspx?strCmd=Editar&intTiendaId=<%=intTiendaId%>&intDireccionId=&intZonaId=";
}

function cmdRegresar_onclick() {
  window.location.href = "SistemaAdministrarTiendas.aspx?strCmd=Consultar&intDireccionId=<%=intDireccionId%>&intZonaId=<%=intZonaId%>";
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
    <td width="770" class="tdtab">Est&aacute; en : Sistema : Administrar tiendas : Ver tienda </td>
  </tr>
</table>
<table width="780" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdgeneralcontent"><h1>Ver tienda </h1>
      <table width="60%"  border="0" cellspacing="0" cellpadding="0">
        <%=strObtenerDetalleTienda()%>
        <tr>
          <td class="tdtexttablebold">Sucursales vinculadas: </td>
          <td class="tdcontentableblue">&nbsp;</td>
        </tr>
        
        <%=strObtenerSucursalesVinculadas()%>

      </table>
  <br>
      <input name="cmdRegresar" type="button" class="button" value="Regresar" onclick="return cmdRegresar_onclick()">
&nbsp;&nbsp;
      <input name="cmdEditar" type="button" class="button" value="Editar datos" onclick="return cmdEditar_onclick()">
&nbsp;&nbsp;
      <input name="cmdPrint" type="button" class="button" value="Imprimir datos" onclick="javascript:window.print();">
    </td>
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
</html>
