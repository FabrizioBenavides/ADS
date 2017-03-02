<%@ Page CodeBehind="popSucursalElegirSucursales.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsPopSucursalElegirSucursales" Explicit="True" Trace="False" Strict="True" codePage="1252" EnableSessionState="False" enableViewState="False"%>
<html>
<head>
<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<link href="css/estilo.css" rel="stylesheet" type="text/css">
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<script id=clientEventHandlersJS language=javascript>

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
  document.forms[0].action = "<%= strThisPageName %>";
  document.forms[0].elements["txtMonedaId"].value = "<%= intMonedaId %>";
  document.forms[0].elements["txtDireccionId"].value = "<%= intDireccionId %>";
  document.forms[0].elements["txtZonaId"].value = "<%= intZonaId %>";
<%= strJavascriptWindowOnLoadCommands %>
<%= strLlenarSucursalesComboBox() %>
  if (document.forms[0].elements["cboSucursales"].length == 0) {
    document.forms[0].elements["cmdCerrar"].disabled = true;
    alert("No hay sucursales disponibles.");
    window.close();
  }
}

function strMonedaNombre() {
  document.write("<%= strMonedaNombre() %>");
}

function strDireccionOperativaNombre() {
  document.write("<%= strDireccionOperativaNombre %>");
}

function strZonaOperativaNombre() {
  document.write("<%= strZonaOperativaNombre() %>");
}

function cmdCancelar_onclick() {
  window.close();
}

function chkTodo_onclick() {
  for (var intCounter = 0; intCounter < document.forms[0].elements["cboSucursales"].length; intCounter++) {
    document.forms[0].elements["cboSucursales"].options[intCounter].selected = document.forms[0].elements["chkTodo"].checked;
  }
}

function cmdCerrar_onclick() {
  var blnSelected = false;
  for (var intCounter = 0; intCounter < document.forms[0].elements["cboSucursales"].length; intCounter++) {
    blnSelected = document.forms[0].elements["cboSucursales"].options[intCounter].selected;
    if (blnSelected == true) {
      break;
    }
  }
  if (blnSelected == true) {
    document.forms[0].action += "?strCmd=Cerrar";
    document.forms[0].submit();
  } else {
    alert("Por favor seleccione al menos una sucursal.");
    document.forms[0].elements["cboSucursales"].focus();
    return(false);
  }
}

</script>
</head>
<body onload="return window_onload()">
<form method="POST" action="about:blank" name="frmPopSucursalElegirSucursales">
  <input type="hidden" name="txtMonedaId">
  <input type="hidden" name="txtDireccionId">
  <input type="hidden" name="txtZonaId">
  <table width="360" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeaderPop()</script></td>
    </tr>
  </table>
  <table width="360" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td class="tdgeneralcontentpop"><h2>Elegir sucursales </h2>
        <table width="100%"  border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="19%" class="tdtexttablebold"> Moneda: </td>
            <td width="81%" class="tdcontentableblue"><script language="javascript">strMonedaNombre()</script></td>
          </tr>
          <tr>
            <td class="tdtexttablebold">Direcci&oacute;n:</td>
            <td class="tdcontentableblue"><script language="javascript">strDireccionOperativaNombre()</script></td>
          </tr>
          <tr>
            <td class="tdtexttablebold">Zona: </td>
            <td class="tdcontentableblue"><script language="javascript">strZonaOperativaNombre()</script></td>
          </tr>
        </table>
 <br>
        <p>Elija la sucursal a la que quiere asignar el tipo de cambio y oprima el bot&oacute;n &quot;Cerrar selecci&oacute;n&quot;. Para elegir m&aacute;s de una sucursal, haga clic en los nombres correspondientes. </p>
        <table width="100%"  border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td class="tdtexttablebold"><input type="checkbox" name="chkTodo" value="checkbox" onclick="return chkTodo_onclick()">
&nbsp;Seleccionar todas</td>
          </tr>
          <tr>
            <td width="81%" class="tdpadleft5"><select name="cboSucursales" size="10" multiple="multiple">
              </select>
            </td>
          </tr>
        </table>
        <br>
        <span class="tdpadleft5">
        <input name="cmdCancelar" type="button" class="button" value="Cancelar" onclick="return cmdCancelar_onclick()">
&nbsp;&nbsp;
        <input name="cmdCerrar" type="button" class="button" value="Cerrar selecci&oacute;n" onclick="return cmdCerrar_onclick()">
        </span> </td>
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
