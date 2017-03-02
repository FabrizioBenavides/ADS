<%@ Page CodeBehind="popSistemaAgregarAtributosATipoDeReceta.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsPopSistemaAgregarAtributosATipoDeReceta" codePage="1252" EnableSessionState="False" enableViewState="False"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5" />
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<link href="css/estilo.css" rel="stylesheet" type="text/css" />
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<!-- <script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script> -->
<script language="JavaScript" type="text/JavaScript" src="js/tools.js"></script>
<script id=clientEventHandlersJS language=javascript>
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
  document.forms[0].action = "<%= strFormAction %>";
  document.forms[0].elements["txtTipoFormaCapturaId"].value = "<%= intTipoFormaCapturaId %>";
<%= strLlenarGrupoComboBox() %>
<%= strJavascriptWindowOnLoadCommands %>
}

function cmdCancelar_onclick() {
  window.close();
}

function cmdAgregar_onclick() {
  var blnReturn = false;
  if (blnComboBoxHasAnElementSelected(document.forms[0].elements["cboAtributos"]) == false) {
    alert("Por favor seleccione al menos un \'Atributo\'.");
    document.forms[0].elements["cboAtributos"].focus();
  } else {
    document.forms[0].action += "?strCmd=Agregar";
    blnReturn = true;
  }
  return(blnReturn);
}

//-->
</script>
</head>
<body onload="return window_onload()">
<form method="POST" action="about:blank" name="frmPage">
  <input type="hidden" name="txtTipoFormaCapturaId" />
  <table width="360" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeaderPop()</script></td>
    </tr>
  </table>
  <table width="360" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td class="tdgeneralcontentpop"><h2>Agregar atributos a tipo de receta</h2>
        <p>Elija el (los) atributo(s) que desea agregar al tipo de receta<br />
          y oprima el bot&oacute;n &ldquo;Agregar&rdquo;. Para elegir m&aacute;s de un atributo,<br />
          haga clic en los nombres correspondientes.</p>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td class="tdblueframe"><select name="cboAtributos" size="20" multiple="MULTIPLE" class="fieldcomment">
              </select></td>
          </tr>
        </table>
        <br />
        <span class="tdpadleft5">
        <input name="cmdCancelar" type="button" class="button" id="cmdCancelar" value="Cancelar"  language=javascript onclick="return cmdCancelar_onclick()"/>
&nbsp;&nbsp;
        <input name="cmdAgregar" type="submit" class="button" id="cmdAgregar" value="Agregar"  language=javascript onclick="return cmdAgregar_onclick()"/>
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
