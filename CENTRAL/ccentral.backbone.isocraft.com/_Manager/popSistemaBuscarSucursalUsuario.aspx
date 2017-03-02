<%@ Page CodeBehind="popSistemaBuscarSucursalUsuario.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsPopSistemaBuscarSucursalUsuario" Explicit="True" Trace="False" Strict="True" codePage="1252" EnableSessionState="False" enableViewState="False"%>
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
<%= strJavascriptWindowOnLoadCommands %>
<%= strLlenarSucursalesComboBox() %>
  if (document.forms[0].elements["cboSucursales"].length == 0) {
    document.forms[0].elements["cmdCerrar"].disabled = true;
    alert("No hay sucursales disponibles.");
    window.close();
  }
}

function strSucursalNombre() {
  document.write("<%= strSucursalNombre() %>");
}

function cmdCancelar_onclick() {
  window.close();
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
    document.forms[0].elements["txtSucursalNombre"].value= document.forms[0].elements["cboSucursales"].options[document.forms[0].elements["cboSucursales"].selectedIndex].text;
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
<form method="POST" action="about:blank" name="frmPopSucursalBuscarSucursalUsuario">
  <input type="hidden" name="txtSucursalNombre">
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
            <td width="40%" class="tdtexttablebold"> Texto buscado: </td>
            <td width="60%" class="tdcontentableblue"><script language="javascript">strSucursalNombre()</script></td>
          </tr>
        </table>
 <br>
        <p>Elija la sucursal en la que desea buscar el usuario y oprima el bot&oacute;n &quot;Cerrar selecci&oacute;n&quot;.</p>
        <table width="100%"  border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="81%" class="tdpadleft5"><select name="cboSucursales" size="10">
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
