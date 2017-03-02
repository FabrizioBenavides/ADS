<%@ Page CodeBehind="SistemaConsultarNivelDeServicioEnTransmisiones.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSistemaConsultarNivelDeServicioEnTransmisiones" codePage="1252" EnableSessionState="False" enableViewState="False"%>
<html>
<head>
<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<meta name="description" content="Javascript Menu">
<meta name="keywords" content="JavaScript menu, javascript, html, client side, netscape, explorer, IE, menu, DHTML, DOM, control">
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
<%= strLlenarDireccionComboBox() %>
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

function cboZona_onchange() {
  document.forms[0].elements["cboSucursal"].selectedIndex = 0;
  document.forms[0].submit();
  return(true);
}

function cboSucursal_onchange() {
  document.forms[0].submit();
}

function cmdBuscar_onclick() {
  return(cmdConsultar_onclick());
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
      <td width="770" class="tdtab">Est&aacute; en : Sistema : Trasmisiones : Consultar nivel de servicio en transmisiones</td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="tdgeneralcontent"><h1>Consultar nivel de servicio en trasmisiones </h1>
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
        <%= strRecordBrowserHTML() %>
        <br>
        <br>
        <h2>Reconfigurar reporte </h2>
        <p>Puede ver los totales para los tres tipos de reportes en otro rango de alcance. Use los selectores para definir el rango de cobertura y luego oprima &quot;Actualizar reporte&quot;. </p>
        <table width="60%"  border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="14%" class="tdtexttablebold">Direcci&oacute;n: </td>
            <td width="86%" class="tdpadleft5"><select name="cboDireccion" class="field" id="cboDireccion">
                <option value="0">Nombre direcci&oacute;n</option>
              </select>
            </td>
          </tr>
        </table>
        <br>
        <input name="cmdBuscar" type="submit" class="button" id="cmdBuscar" value="Actualizar reporte" language=javascript onclick="return cmdBuscar_onclick()">
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
</form>
</body>
</html>
