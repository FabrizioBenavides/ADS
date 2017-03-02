<%@ Page CodeBehind="SistemaAdministrarDiasInhabiles.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSistemaAdministrarDiasInhabiles" codePage="1252" EnableSessionState="False" enableViewState="False"%>
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
<script language="JavaScript" src="js/calendario.js"></script>
<script language="JavaScript" src="js/cal_format00.js"></script>
<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
<script id=clientEventHandlersJS language=javascript>
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
  document.forms[0].action = "<%= strThisPageName %>";
}

function cmdAgregar_onclick() {
  if (blnValidarCampo(document.forms[0].elements["txtDiaInhabil"], true, "Elija nuevo día inhábil", cintTipoCampoFecha, 10, 1, "") == true) {
    document.forms[0].action += "?strCmd=SalvarAgregar";
    document.forms[0].submit();
  }
}

//-->
</script>
</head>
<body onload="return window_onload()">
<form method="POST" action="about:blank" name="frmSistemaAdministrarDiasInhabiles">
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><script language="JavaScript">crearTablaHeader()</script></td>
  </tr>
</table>
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="10">&nbsp;</td>
    <td width="770" class="tdtab">Est&aacute; en : Sistema : Cuentas : Administrar d&iacute;as inh&aacute;biles </td>
  </tr>
</table>
<table width="780" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdgeneralcontent"><h1>Administrar d&iacute;as inh&aacute;biles </h1>
      <table width="60%"  border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="30%" class="tdtexttablebold">Elija nuevo d&iacute;a inh&aacute;bil: </td>
            <td width="70%" class="tdpadleft5"><input name="txtDiaInhabil" id="txtDiaInhabil" class="field" size="12" maxlength="12" type="text">
              <a href="javascript:cal1.popup()"><img src="images/imgCalendarIcon.gif" width="16" height="15" border="0" align="absmiddle"></a></td>
          </tr>
          <tr>
            <td height="10" colspan="2"><img src="images/pixel.gif" width="1" height="10"></td>
          </tr>
      </table>
      <input name="cmdAgregar" type="button" class="button" id="cmdAgregar" value="Agregar el día" language=javascript onclick="return cmdAgregar_onclick()">
      <br>
      <%= strRecordBrowserHTML() %>
    </td>
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
<script language="JavaScript">
	<!-- // create calendar object(s) just after form tag closed
	var cal1 = new calendar(null, document.forms[0].elements["txtDiaInhabil"]);
	//-->
</script>
</form>
</body>
</html>
