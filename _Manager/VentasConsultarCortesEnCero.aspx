<%@ Page CodeBehind="VentasConsultarCortesEnCero.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsVentasConsultarCortesEnCero" codePage="28591"%>
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
<script language="JavaScript" src="js/calendario.js"></script>
<script language="JavaScript" src="js/cal_format00.js"></script>
<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
<script id=clientEventHandlersJS language=javascript>
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
  document.forms[0].action = "<%= strThisPageName %>";
  document.forms[0].elements["txtFechaInicial"].value = "<%= strFechaInicial %>";
  document.forms[0].elements["txtFechaFinal"].value = "<%= strFechaFinal %>";
}

function cmdConsultar_onclick() {

  /* Validación del campo "txtFechaInicial" */
  if (blnValidarCampo(document.forms[0].elements["txtFechaInicial"], true, "Desde", cintTipoCampoFecha, 10, 1, "") == true) {
  
    /* Validación del campo "txtFechaFinal" */
    if (blnValidarCampo(document.forms[0].elements["txtFechaFinal"], true, "Hasta", cintTipoCampoFecha, 10, 1, "") == true) {
      document.forms[0].action += "?strCmd=Consultar";
      return(true);
    }
  
  } 
  return(false);
}

// done hiding -->
</script>
</head>
<body language=javascript onload="return window_onload()">
<form method="POST" action="about:blank" name="frmMain">
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><script language="JavaScript">crearTablaHeader()</script></td>
  </tr>
</table>
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="10">&nbsp;</td>
    <td width="770" class="tdtab">Est&aacute; en : Ventas : Cierres : Consultar cortes en cero </td>
  </tr>
</table>
<table width="780" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdgeneralcontent"><h1>Consultar cortes en cero </h1>
      <h2>Configurar la consulta</h2>
      <table width="60%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td class="tdtexttablebold">&nbsp;&nbsp;Desde:</td>
          <td class="tdpadleft5"><input name="txtFechaInicial" id="txtFechaInicial" class="field" size="12" maxlength="12" type="text">
            <a href="javascript:cal1.popup()"><img src="images/imgCalendarIcon.gif" width="16" height="15" border="0" align="absmiddle"></a></td>
        </tr>
        <tr>
          <td width="18%" class="tdtexttablebold">&nbsp;&nbsp;Hasta: </td>
          <td width="82%" class="tdpadleft5"><input name="txtFechaFinal" id="txtFechaFinal" class="field" size="12" maxlength="12" type="text">
            <a href="javascript:cal2.popup()"><img src="images/imgCalendarIcon.gif" width="16" height="15" border="0" align="absmiddle"></a></td>
        </tr>
      </table>
      <br>
      <input name="cmdConsultar" type="submit" class="button" id="cmdConsultar" value="Realizar consulta" language=javascript onclick="return cmdConsultar_onclick()">
      <br>
      <%= strRecordBrowserHTML() %> <br>
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
var cal1 = new calendar(null, document.forms[0].elements["txtFechaInicial"]);
var cal2 = new calendar(null, document.forms[0].elements["txtFechaFinal"]);
//-->
</script>
</body>
</html>
