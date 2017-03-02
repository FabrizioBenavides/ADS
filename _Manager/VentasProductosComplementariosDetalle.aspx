<%@ Page Language="vb" AutoEventWireup="false" Codebehind="VentasProductosComplementariosDetalle.aspx.vb" Inherits="com.isocraft.backbone.ccentral.VentasProductosComplementariosDetalle" codePage="1252" EnableSessionState="False" enableViewState="False" %>
<html>
<head>
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
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

function window_onload() {
  document.forms[0].action = "<%= strFormAction %>";
  document.forms[0].elements["txtArticuloId"].value = "<%= intArticuloId %>";
  document.forms[0].elements["txtArticuloDescripcion"].value = "<%= Benavides.POSAdmin.Commons.clsCommons.strGenerateJavascriptString(strtxtArticuloDescripcion) %>";
}

function cmdBorrar_onclick() {
  if (confirm("¿Esta seguro que desea eliminar este elemento?") == true) {
    document.forms[0].action += "?strCmd=Eliminar";
    return(true);
  }
  return(false);
}

function cmdEditar_onclick() {
  window.location.href = "VentasProductosComplementariosAgregar.aspx?strCmd=Registrar&strOrigen=Detalle&intArticuloId=<%= intArticuloId %>";
}

function cmdRegresar_onclick() {
  window.location.href = "VentasProductosComplementariosConsultar.aspx?strCmd=Consultar&intArticuloId=<%= intArticuloId %>";
}

//-->
</script>
</head>
<body language=javascript onLoad="return window_onload()">
<form name="frmMain" action="about:blank" method="post">
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr> 
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr> 
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Está en : <a href="Ventas.htm">Ventas</a> 
        : <a href="VentasProductosComplementarios.aspx"> Productos de venta cruzada</a> 
        : Detalle de producto</td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr> 
      <td class="tdgeneralcontent"><h1>Detalle de producto </h1>
        <p>En esta parte usted puede consultar los productos que cuentan con artículos 
          de venta cruzada</p>
        <h2>Buscar productos </h2>
        <table width="70%" border="0" cellspacing="0" cellpadding="0">
          <tr> 
            <td width="93" class="tdtexttablebold">Código:</td>
            <td width="438" valign="top" class="tdcontentableblue"><span class="tdpadleft5"> 
              <input name="txtArticuloId" type="text" class="campotablaresultado" size="40" border="0" id="txtArticuloId" readonly>
              </span></td>
          </tr>
          <tr> 
            <td class="tdtexttablebold"> Descripción: </td>
            <td valign="top" class="tdcontentableblue"><span class="tdpadleft5"> 
              <input name="txtArticuloDescripcion" type="text" class="campotablaresultado" size="40" border="0" id="txtArticuloDescripcion" readonly>
              </span></td>
          </tr>
        </table>
        <p><br>
          <%= strObtenerProductosComplementariosDeUnArticulo()%></p>
        <p> 
          <input name="cmdRegresar" type="button" class="button" id="cmdRegresar" 
							value="Regresar" language="javascript" onClick="return cmdRegresar_onclick()">
          &nbsp; 
          <input name="cmdEditar" type="button" class="button" id="cmdEditar" 
							value="Editar" language="javascript" onClick="return cmdEditar_onclick()">
          &nbsp; 
          <input name="cmdBorrar" type="submit" class="button" id="cmdBorrar" value="Borrar" language="javascript" onClick="return cmdBorrar_onclick()">
        </p></td>
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
