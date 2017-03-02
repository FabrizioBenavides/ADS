<%@ Page CodeBehind="popSucursalElegirMonedas.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsPopSucursalElegirMonedas" Explicit="True" Trace="False" Strict="True" codePage="1252" EnableSessionState="False" enableViewState="False"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<meta name="description" content="Javascript Menu">
<meta name="keywords" content="JavaScript menu, javascript, html, client side, netscape, explorer, IE, menu, DHTML, DOM, control">
<link href="css/estilo.css" rel="stylesheet" type="text/css">
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
<script id=clientEventHandlersJS language=javascript>

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
  document.forms[0].action = "<%= strThisPageName %>";
  document.forms[0].elements["txtDireccionId"].value = "<%= intDireccionId %>";
  document.forms[0].elements["txtZonaId"].value = "<%= intZonaId %>";
  document.forms[0].elements["txtCompaniaId"].value = "<%= intCompaniaId %>";
  document.forms[0].elements["txtSucursalId"].value = "<%= intSucursalId %>";
<%= strJavascriptWindowOnLoadCommands %>
<%= strLlenarMonedasComboBox() %>
  if (document.forms[0].elements["cboMonedas"].length == 0) {
    document.forms[0].elements["cmdCerrar"].disabled = true;
    alert("No hay monedas disponibles para asignarse a la sucursal.");
    window.close();
  }
}

function strDireccionOperativaNombre() {
  document.write("<%= strDireccionOperativaNombre %>");
}

function strZonaOperativaNombre() {
  document.write("<%= strZonaOperativaNombre() %>");
}

function strSucursalNombre() {
  document.write("<%= strSucursalNombre() %>");
}
function cmdCancelar_onclick() {
  window.close();
}

function chkTodo_onclick() {
  for (var intCounter = 0; intCounter < document.forms[0].elements["cboMonedas"].length; intCounter++) {
    document.forms[0].elements["cboMonedas"].options[intCounter].selected = document.forms[0].elements["chkTodo"].checked;
  }
}

function cmdCerrar_onclick() {
  var blnSelected = false;
  for (var intCounter = 0; intCounter < document.forms[0].elements["cboMonedas"].length; intCounter++) {
    blnSelected = document.forms[0].elements["cboMonedas"].options[intCounter].selected;
    if (blnSelected == true) {
      break;
    }
  }
  if (blnSelected == true) {
    document.forms[0].action += "?strCmd=Cerrar";
    document.forms[0].submit();
  } else {
    alert("Por favor seleccione al menos una moneda.");
    document.forms[0].elements["cboMonedas"].focus();
    return(false);
  }
}

</script>
</head>
<body onload="return window_onload()">
<form method="POST" action="about:blank" name="frmPopSucursalElegirMonedas">
<input type="hidden" name="txtDireccionId">
<input type="hidden" name="txtZonaId">
<input type="hidden" name="txtCompaniaId">
<input type="hidden" name="txtSucursalId">
<table width="360" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><script language="JavaScript">crearTablaHeaderPop()</script></td>
  </tr>
</table>
<table width="360" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td class="tdgeneralcontentpop"><h2>Elegir monedas </h2>
      <table width="100%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="19%" class="tdtexttablebold"> Direcci&oacute;n: </td>
          <td width="81%" class="tdcontentableblue"><script language="javascript">strDireccionOperativaNombre()</script></td>
        </tr>
        <tr>
          <td class="tdtexttablebold">Zona:</td>
          <td class="tdcontentableblue"><script language="javascript">strZonaOperativaNombre()</script></td>
        </tr>
        <tr>
          <td class="tdtexttablebold">Sucursal: </td>
          <td class="tdcontentableblue"><script language="javascript">strSucursalNombre()</script></td>
        </tr>
      </table>
 <br>
      <p>Marque las monedas que desea asignar . </p>
      <table width="100%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td class="tdtexttablebold"><input name="chkTodo" type="checkbox" id="chkTodo" value="checkbox" onclick="return chkTodo_onclick()">
&nbsp;Seleccionar todas</td>
        </tr>
        <tr>
          <td width="81%" class="tdpadleft5">
              <select name="cboMonedas" class="fieldcomment" size="5" multiple="multiple" id="cboMonedas">
              </select>
          </td>
        </tr>
      </table>
      <br>
      <span class="tdpadleft5">
      <input name="cmdCancelar" type="button" class="button" id="cmdCancelar" value="Cancelar" onclick="return cmdCancelar_onclick()">
&nbsp;&nbsp;
      <input name="cmdCerrar" type="button" class="button" id="cmdCerrar" value="Cerrar selecci&oacute;n" onclick="return cmdCerrar_onclick()">
      </span></td>
  </tr>
</table>
<table width="360" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><script language="JavaScript">crearTablaFooterPop()</script></td>
  </tr>
</table>
</form>
</body>
</html>
