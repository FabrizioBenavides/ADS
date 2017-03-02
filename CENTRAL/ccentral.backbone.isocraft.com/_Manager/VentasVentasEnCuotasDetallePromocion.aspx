<%@ Page CodeBehind="VentasVentasEnCuotasDetallePromocion.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsVentasVentasEnCuotasDetallePromocion" codePage="1252" EnableSessionState="False" enableViewState="False"%>
<html>
<head>
<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<link href="css/menu.css" rel="stylesheet" type="text/css">
<link href="css/estilo.css" rel="stylesheet" type="text/css">
<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--
strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
  document.forms[0].action = "<%= strFormAction %>";
  document.forms[0].elements["txtNombre"].value = "<%= strtxtNombre %>";
  document.forms[0].elements["txtPlazo"].value = "<%= strtxtPlazo %>";
  document.forms[0].elements["txtMonto"].value = "<%= strtxtMonto %>";
  document.forms[0].elements["txtVigencia"].value = "<%= strtxtVigencia %>";
  document.forms[0].elements["txtEstatus"].value = "<%= strtxtEstatus %>";
  <%= strJavascriptWindowOnLoadCommands %>
}

function cmdRegresar_onclick() {
//onclick="gotopage('VentasVentasEnCuotasConsultar.htm')"
window.location.href = "<%= "VentasVentasEnCuotasConsultar.aspx" %>";
return(true);
}

function cmdBorrar_onclick() {
  var intPromocionVentaCuotasId = "<%= intPromocionVentaCuotasId %>";
  document.forms[0].action += "?strCmd=Eliminar&intPromocionVentaCuotasId=" + intPromocionVentaCuotasId;
return(true);
}

function cmdEditar_onclick() {
//onclick="gotopage('VentasVentasEnCuotasAgregar.htm')"
window.location.href = "<%= "VentasVentasEnCuotasAgregar.aspx?strCmd=Editar&intPromocionVentaCuotasId=" & intPromocionVentaCuotasId %>";
return(true);
}

//-->
</script>
</head>
<body language=javascript onload="return window_onload()">
<form name="frmMain" action="about:blank" method="post">
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><script language="JavaScript">crearTablaHeader()</script></td>
  </tr>
</table>
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="10">&nbsp;</td>
    <td width="770" class="tdtab">Est&aacute; en : <a href="VentasHome.aspx">Ventas</a> : <a href="VentasVentasEnCuotas.aspx">Ventas en cuotas </a> : Detalle de promoci&oacute;n de ventas en cuotas </td>
  </tr>
</table>
<table width="780" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdgeneralcontent"><h1>Detalle de promoci&oacute;n de venta en cuotas </h1>
      <table width="70%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="93" class="tdtexttablebold">Nombre:</td>
          <td width="438" valign="top" class="tdcontentableblue"><span class="tdpadleft5">
            <input name="txtNombre" type="text" class="campotablaresultado" size="40" border="0" id="txtNombre" readonly>
          </span></td>
        </tr>
        <tr>
          <td height="28" class="tdtexttablebold"> Plazo: </td>
          <td valign="top" class="tdcontentableblue"><span class="tdpadleft5">
            <input name="txtPlazo" type="text" class="campotablaresultado" size="40" border="0" id="txtPlazo" readonly>
          </span></td>
        </tr>
        <tr>
          <td class="tdtexttablebold">Monto m&iacute;nimo: </td>
          <td valign="top" class="tdcontentableblue"><span class="tdpadleft5">
            <input name="txtMonto" type="text" class="campotablaresultado" size="40" border="0" id="txtMonto" readonly>
          </span></td>
        </tr>
        <tr>
          <td class="tdtexttablebold">Vigencia:</td>
          <td valign="top" class="tdcontentableblue"><span class="tdpadleft5">
            <input name="txtVigencia" type="text" class="campotablaresultado" size="40" border="0" id="txtVigencia" readonly>
          </span></td>
        </tr>
        <tr>
          <td class="tdtexttablebold">Estatus:</td>
          <td valign="top" class="tdcontentableblue"><span class="tdpadleft5">
            <input name="txtEstatus" type="text" class="campotablaresultado" size="40" border="0" id="txtEstatus" readonly>
          </span></td>
        </tr>
      </table>
      <p>&nbsp;</p>
      <p><%=strObtenerArticulosIncluidos()%>          </p>
      <p>          <input name="cmdRegresar" type="button" class="button" id="cmdRegresar" onclick="return cmdRegresar_onclick()" value="Regresar">
&nbsp;
        <input name="cmdEditar" type="button" class="button" id="cmdEditar"  value="Editar" language=javascript onclick="return cmdEditar_onclick()">
&nbsp;
        <input name="cmdBorrar" type="submit" class="button" id="cmdBorrar" value="Borrar" language=javascript onclick="return cmdBorrar_onclick()">
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
