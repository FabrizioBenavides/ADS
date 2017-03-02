<%@ Page CodeBehind="SistemaAdministrarUbicacionesBancarias.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSistemaAdministrarUbicacionesBancarias" codePage="1252" EnableSessionState="False" enableViewState="False"%>
<html>
<head>
<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
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
  
  /* Validación del campo "txtUbicacionBancoNombreId" */
  if (blnValidarCampo(document.forms[0].elements["txtUbicacionBancoNombreId"], true, "Identificador", cintTipoCampoAlfanumerico, 50, 1, "") == true) {
  
    /* Validación del campo "txtUbicacionBancoNombre" */
    blnReturn = blnValidarCampo(document.forms[0].elements["txtUbicacionBancoNombre"], true, "Nombre", cintTipoCampoAlfanumerico, 50, 1, "");
  
  } 

  return (blnReturn);
}

//-->
</script>
</head>
<body onload="return window_onload()">
<form method="POST" action="about:blank" name="frmSistemaAdministrarMonedas" onSubmit="return blnFormValidator(this)">
  <input type="hidden" name="txtUbicacionBancoId" value="0">
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Est&aacute; en : Sistema : Cuentas : Administrar ubicaciones bancarias </td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="tdgeneralcontent"><h1>Administrar ubicaciones bancarias</h1>
        <table width="60%"  border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="31%" class="tdtexttablebold">Identificador:</td>
            <td width="69%" class="tdpadleft5"><input name="txtUbicacionBancoNombreId" type="text" class="field" id="txtUbicacionBancoNombreId" size="35" maxlength="35"></td>
          </tr>
          <tr>
            <td class="tdtexttablebold">Nombre:</td>
            <td class="tdpadleft5"><input name="txtUbicacionBancoNombre" type="text" class="field" id="txtUbicacionBancoNombre" size="35" maxlength="35"></td>
          </tr>
          <tr>
            <td height="10" colspan="2"><img src="images/pixel.gif" width="1" height="10"></td>
          </tr>
        </table>
        <input name="cmdAgregar" type="submit" class="button" id="cmdSalvar" value="Salvar datos" onclick="cmdSalvar_onclick()">
        <br>
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
