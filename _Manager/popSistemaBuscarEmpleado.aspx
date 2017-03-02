<%@ Page CodeBehind="popSistemaBuscarEmpleado.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsPopSistemaBuscarEmpleado" Explicit="True" Trace="False" Strict="True" codePage="1252" EnableSessionState="False" enableViewState="False"%>
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
<%= strLlenarEmpleadosComboBox() %>
  if (document.forms[0].elements["cboEmpleados"].length == 0) {
    document.forms[0].elements["cmdCerrar"].disabled = true;
    alert("No hay empleados disponibles.");
    window.close();
  }
}


function cmdCancelar_onclick() {
  window.close();
}


function cmdCerrar_onclick() {
  var blnSelected = false;
  for (var intCounter = 0; intCounter < document.forms[0].elements["cboEmpleados"].length; intCounter++) {
    blnSelected = document.forms[0].elements["cboEmpleados"].options[intCounter].selected;
    if (blnSelected == true) {
      break;
    }
  }
  if (blnSelected == true) {
    document.forms[0].elements["txtEmpleadoNombre"].value= document.forms[0].elements["cboEmpleados"].options[document.forms[0].elements["cboEmpleados"].selectedIndex].text;
    document.forms[0].action += "?strCmd=Cerrar";
    document.forms[0].submit();
  } else {
    alert("Por favor seleccione al menos un Empleado.");
    document.forms[0].elements["cboEmpleados"].focus();
    return(false);
  }
}

</script>
</head>
<body onload="return window_onload()">
<form method="POST" action="about:blank" name="frmPopSucursalBuscarEmpleado">
  <input type="hidden" name="txtEmpleadoNombre">
  <table width="360" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeaderPop()</script></td>
    </tr>
  </table>
  <table width="360" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td class="tdgeneralcontentpop"><h2>Elegir empleado </h2>

 <br>
        <p>Elija el empleado al que desea asignarle usuario y oprima el bot&oacute;n &quot;Cerrar selecci&oacute;n&quot;.</p>
        <table width="100%"  border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="81%" class="tdpadleft5"><select name="cboEmpleados" size="10">
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
