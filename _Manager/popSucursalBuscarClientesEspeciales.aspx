<%@ Page CodeBehind="popSucursalBuscarClientesEspeciales.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsPopSucursalBuscarClientesEspeciales" codePage="1252" EnableSessionState="False" enableViewState="False"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5" />
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<link href="css/estilo.css" rel="stylesheet" type="text/css" />
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/tools.js"></script>
<script id=clientEventHandlersJS language=javascript>
<!--

function cmdCancelar_onclick() {
  window.close();
}

function cmdSeleccionar_onclick() {
  if (blnComboBoxHasAnElementSelected(document.forms[0].elements["cboClienteEspecial"]) == false) {
    alert("Por favor seleccione al menos un cliente.");
    document.forms[0].elements["cboClienteEspecial"].focus();
    return(false);
  }
  document.forms[0].action += "?strCmd=Seleccionar";
  return(true);
}

function window_onload() {
  document.forms[0].action = "<%= strFormAction %>";
  document.forms[0].elements["txtTargetFieldOne"].value = "<%= strTargetFieldOne %>";
  document.forms[0].elements["txtTargetFieldTwo"].value = "<%= strTargetFieldTwo %>";
  document.forms[0].elements["txtTargetFieldThree"].value = "<%= strTargetFieldThree %>";
  document.forms[0].elements["txtTargetFieldFour"].value = "<%= strTargetFieldFour %>";
  document.forms[0].elements["txtSourceValue"].value = "<%= Isocraft.Web.Convert.ConvertToJavascriptString(strSourceValue) %>";
<%= strLlenarClienteEspecialComboBox() %>
<%= strJavascriptWindowOnLoadCommands %>
}

function cboClienteEspecial_ondblclick() {
  if (cmdSeleccionar_onclick() == true) {
    document.forms[0].submit();
  }
}

//-->
</script>
</head>
<body language=javascript onload="return window_onload()">
<form method="POST" action="about:blank" name="frmPage">
  <input type="hidden" name="txtTargetFieldOne" />
  <input type="hidden" name="txtTargetFieldTwo" />
  <input type="hidden" name="txtTargetFieldThree" />
  <input type="hidden" name="txtTargetFieldFour" />
  <input type="hidden" name="txtSourceValue" />
  <table width="360" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeaderPop()</script></td>
    </tr>
  </table>
  <table width="360" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td class="tdgeneralcontentpop"><h2>Buscar clientes especiales </h2>
        <p>Localice en la lista siguiente el nombre del cliente especial<br />
          deseado. Ponga el cursor sobre &eacute;l y oprima &ldquo;Seleccionar&rdquo;<br />
          para colocarlo en la forma.</p>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td class="tdblueframe"><select name="cboClienteEspecial" size="10" class="fieldcomment" id="cboClienteEspecial" language=javascript ondblclick="return cboClienteEspecial_ondblclick()">
              </select></td>
          </tr>
        </table>
        <br />
        <span class="tdpadleft5">
        <input name="cmdCancelar" type="button" class="button" id="cmdCancelar" value="Cancelar"  language=javascript onclick="return cmdCancelar_onclick()"/>
&nbsp;&nbsp;
        <input name="cmdSeleccionar" type="submit" class="button" id="cmdSeleccionar" value="Seleccionar"  language=javascript onclick="return cmdSeleccionar_onclick()"/>
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
