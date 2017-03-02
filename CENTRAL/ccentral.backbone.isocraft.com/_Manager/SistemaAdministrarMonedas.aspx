<%@ Page CodeBehind="SistemaAdministrarMonedas.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSistemaAdministrarMonedas" Explicit="True" Trace="False" Strict="True" codePage="1252" EnableSessionState="False" enableViewState="False"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
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

function window_onload() {
  document.forms[0].action = "<%= strThisPageName %>";
<%= strJavascriptWindowOnLoadCommands %>
}

function cmdSalvar_onclick() {
  document.forms[0].action += "?strCmd=<%= strCmd %>";
  return(true);
}

function blnFormValidator(theForm) {
  
  var blnReturn = false;
  
  /* Validación del campo "txtMonedaNombreId" */
  if (blnValidarCampo(theForm.elements["txtMonedaNombreId"], true, "Identificador", cintTipoCampoAlfanumerico, 50, 1, "") == true) {
  
    /* Validación del campo "txtMonedaNombre" */
    blnReturn = blnValidarCampo(theForm.elements["txtMonedaNombre"], true, "Nombre", cintTipoCampoAlfanumerico, 50, 1, "");
  
  } 

  return (blnReturn);
}

//-->
</script>
</head>
<body onload="return window_onload()">
<form method="POST" action="about:blank" name="frmSistemaAdministrarMonedas" onSubmit="return blnFormValidator(this)">
  <input type="hidden" name="txtMonedaId" value="0">
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Est&aacute; en : Sistema : Admnistrar monedas</td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="tdgeneralcontent"><h1>Administrar monedas </h1>
        <p>En esta parte del sistema usted dar&aacute; de alta o editar&aacute; las monedas que podr&aacute;n ser aceptadas por las sucursales.</p>
        <table width="320" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td ><h2>Datos de la moneda </h2>
              <table width="100%"  border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td class="tdtexttablebold">Identificador:</td>
                  <td align="right" class="tdpadleft5"><input name="txtMonedaNombreId" type="text" class="field" id="txtMonedaNombreId" size="50" maxlength="50" <%= strReadOnlyId %>></td>
                </tr>
                <tr>
                  <td width="115" class="tdtexttablebold">Nombre: </td>
                  <td align="right" class="tdpadleft5"><input name="txtMonedaNombre" type="text" class="field" id="txtMonedaNombre" size="50" maxlength="50"></td>
                </tr>
                <tr>
                  <td height="10" colspan="2"><img src="images/pixel.gif" width="1" height="10"></td>
                </tr>
                <tr>
                  <td class="tdtexttablebold">&nbsp;</td>
                  <td align="right" class="tdpadleft5"><input name="cmdSalvar" type="submit" class="button" id="cmdSalvar" value="Salvar datos" onclick="return cmdSalvar_onclick()"></td>
                </tr>
              </table></td>
          </tr>
        </table>
        <%= strRecordBrowserHTML() %> </td>
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
